// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal class HttpWebRequestTransport : HttpPipelineTransport
    {
        public static readonly HttpWebRequestTransport Shared = new HttpWebRequestTransport();
        private readonly IWebProxy? _environmentProxy;

        /// <summary>
        /// Creates a new instance of <see cref="HttpWebRequestTransport"/>
        /// </summary>
        public HttpWebRequestTransport()
        {
            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                _environmentProxy = webProxy;
            }
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
            ProcessInternal(message, false).EnsureCompleted();
        }

        /// <inheritdoc />
        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            await ProcessInternal(message, true).ConfigureAwait(false);
        }

        private async ValueTask ProcessInternal(HttpMessage message, bool async)
        {
            var request = CreateRequest(message.Request);

            ServicePointHelpers.SetLimits(request.ServicePoint);

            using var registration = message.CancellationToken.Register(state => ((HttpWebRequest) state).Abort(), request);
            try
            {
                if (message.Request.Content != null)
                {
                    if (request.ContentLength == -1 &&
                        message.Request.Content.TryComputeLength(out var length))
                    {
                        request.ContentLength = length;
                    }

                    using var requestStream = async ? await request.GetRequestStreamAsync().ConfigureAwait(false) : request.GetRequestStream();

                    if (async)
                    {
                        await message.Request.Content.WriteToAsync(requestStream, message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        message.Request.Content.WriteTo(requestStream, message.CancellationToken);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }

                WebResponse webResponse;
                try
                {
                    webResponse = async ? await request.GetResponseAsync().ConfigureAwait(false) : request.GetResponse();
                }
                // HttpWebRequest throws for error responses catch that
                catch (WebException exception) when (exception.Response != null)
                {
                    webResponse = exception.Response;
                }
                message.Response = new HttpWebResponseImplementation(message.Request.ClientRequestId, (HttpWebResponse) webResponse);
            }
            // WebException is thrown in the case of .Abort() call
            catch (WebException) when (message.CancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            catch (WebException webException)
            {
                throw new RequestFailedException(0, webException.Message);
            }
        }

        private HttpWebRequest CreateRequest(Request messageRequest)
        {
            var request = WebRequest.CreateHttp(messageRequest.Uri.ToUri());
            request.Method = messageRequest.Method.Method;
            // Don't disable the default proxy when there is no environment proxy configured
            if (_environmentProxy != null)
            {
                request.Proxy = _environmentProxy;
            }

            foreach (var messageRequestHeader in messageRequest.Headers)
            {
                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.ContentLength, StringComparison.OrdinalIgnoreCase))
                {
                    request.ContentLength = long.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Host, StringComparison.OrdinalIgnoreCase))
                {
                    request.Host = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Date, StringComparison.OrdinalIgnoreCase))
                {
                    request.Date = DateTime.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.ContentType, StringComparison.OrdinalIgnoreCase))
                {
                    request.ContentType = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.UserAgent, StringComparison.OrdinalIgnoreCase))
                {
                    request.UserAgent = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Accept, StringComparison.OrdinalIgnoreCase))
                {
                    request.Accept = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Referer, StringComparison.OrdinalIgnoreCase))
                {
                    request.Referer = messageRequestHeader.Value;
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.Range, StringComparison.OrdinalIgnoreCase))
                {
                    var value = RangeHeaderValue.Parse(messageRequestHeader.Value);
                    if (value.Unit != "bytes")
                    {
                        throw new InvalidOperationException("Only ranges with bytes unit supported.");
                    }

                    foreach (var rangeItem in value.Ranges)
                    {
                        if (rangeItem.From == null)
                        {
                            throw new InvalidOperationException("Only ranges with Offset supported.");
                        }

                        if (rangeItem.To == null)
                        {
                            request.AddRange(rangeItem.From.Value);
                        }
                        else
                        {
                            request.AddRange(rangeItem.From.Value, rangeItem.To.Value);
                        }
                    }
                    continue;
                }

                request.Headers.Add(messageRequestHeader.Name, messageRequestHeader.Value);
            }

            if (request.ContentLength != -1)
            {
                // disable buffering when the content length is known
                // as the content stream is re-playable and we don't want to allocate extra buffers
                request.AllowWriteStreamBuffering = false;
            }
            return request;
        }

        /// <inheritdoc />
        public override Request CreateRequest()
        {
            return new HttpWebRequestImplementation();
        }

        private sealed class HttpWebResponseImplementation: Response
        {
            private readonly HttpWebResponse _webResponse;
            private Stream? _contentStream;
            private Stream? _originalContentStream;

            public HttpWebResponseImplementation(string clientRequestId, HttpWebResponse webResponse)
            {
                _webResponse = webResponse;
                _originalContentStream = _webResponse.GetResponseStream();
                _contentStream = _originalContentStream;
                ClientRequestId = clientRequestId;
            }

            public override int Status => (int) _webResponse.StatusCode;

            public override string ReasonPhrase => _webResponse.StatusDescription;

            public override Stream? ContentStream
            {
                get => _contentStream;
                set
                {
                    // Make sure we don't dispose the content if the stream was replaced
                    _originalContentStream = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            public override void Dispose()
            {
                _originalContentStream?.Dispose();
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                value = _webResponse.Headers.Get(name);
                return value != null;
            }

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
            {
                values = _webResponse.Headers.GetValues(name);
                return values != null;
            }

            protected internal override bool ContainsHeader(string name)
            {
                return _webResponse.Headers.Get(name) != null;
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                foreach (var key in _webResponse.Headers.AllKeys)
                {
                    yield return new HttpHeader(key, _webResponse.Headers.Get(key));
                }
            }
        }

        private sealed class HttpWebRequestImplementation: Request
        {
            public HttpWebRequestImplementation()
            {
                Method = RequestMethod.Get;
            }

            private string? _clientRequestId;
            private readonly Dictionary<string, List<string>> _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            protected internal override void AddHeader(string name, string value)
            {
                if (!_headers.TryGetValue(name, out List<string> values))
                {
                    _headers[name] = values = new List<string>();
                }

                values.Add(value);
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            {
                if (_headers.TryGetValue(name, out List<string> values))
                {
                    value = JoinHeaderValue(values);
                    return true;
                }

                value = null;
                return false;
            }

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                var result = _headers.TryGetValue(name, out List<string> valuesList);
                values = valuesList;
                return result;
            }

            protected internal override bool ContainsHeader(string name)
            {
                return TryGetHeaderValues(name, out _);
            }

            protected internal override bool RemoveHeader(string name)
            {
                return _headers.Remove(name);
            }

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.Select(h => new HttpHeader(h.Key, JoinHeaderValue(h.Value)));

            private static string JoinHeaderValue(IEnumerable<string> values)
            {
                return string.Join(",", values);
            }
            public override string ClientRequestId
            {
                get => _clientRequestId ??= Guid.NewGuid().ToString();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _clientRequestId = value;
                }
            }

            public override RequestContent? Content { get; set; }

            public override void Dispose()
            {
                Content?.Dispose();
            }
        }
    }
#endif
}