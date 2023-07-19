// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
#if NETFRAMEWORK
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    internal class HttpWebRequestTransport : HttpPipelineTransport
    {
        private readonly Action<HttpWebRequest> _configureRequest;
        public static readonly HttpWebRequestTransport Shared = new HttpWebRequestTransport();
        private readonly IWebProxy? _environmentProxy;

        /// <summary>
        /// Creates a new instance of <see cref="HttpWebRequestTransport"/>
        /// </summary>
        public HttpWebRequestTransport() : this(_ => { })
        {
        }

        internal HttpWebRequestTransport(HttpPipelineTransportOptions options)
            : this(req => ApplyOptionsToRequest(req, options))
        { }

        internal HttpWebRequestTransport(Action<HttpWebRequest> configureRequest)
        {
            _configureRequest = configureRequest;
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

            message.ClearResponse();

            using var registration = message.CancellationToken.Register(state => ((HttpWebRequest)state).Abort(), request);
            try
            {
                if (message.Request.Content != null)
                {
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
                    // match the behavior of HttpClient
                    if (message.Request.Method != RequestMethod.Head &&
                         message.Request.Method != RequestMethod.Get &&
                         message.Request.Method != RequestMethod.Delete)
                    {
                        request.ContentLength = 0;
                    }

                    request.ContentType = null;
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

                message.Response = new HttpWebResponseImplementation(message.Request.ClientRequestId, (HttpWebResponse)webResponse);
            }
            // ObjectDisposedException might be thrown if the request is aborted during the content upload via SSL
            catch (ObjectDisposedException) when (message.CancellationToken.IsCancellationRequested)
            {
                CancellationHelper.ThrowIfCancellationRequested(message.CancellationToken);
            }
            catch (WebException webException)
            {
                // WebException is thrown in the case of .Abort() call
                CancellationHelper.ThrowIfCancellationRequested(message.CancellationToken);
                throw new RequestFailedException(0, webException.Message, webException);
            }
        }

        private HttpWebRequest CreateRequest(Request messageRequest)
        {
            var request = WebRequest.CreateHttp(messageRequest.Uri.ToUri());

            // Timeouts are handled by the pipeline
            request.Timeout = Timeout.Infinite;
            request.ReadWriteTimeout = Timeout.Infinite;

            // Redirect is handled by the pipeline
            request.AllowAutoRedirect = false;

            // Don't disable the default proxy when there is no environment proxy configured
            if (_environmentProxy != null)
            {
                request.Proxy = _environmentProxy;
            }

            request.ServicePoint.Expect100Continue = false;

            _configureRequest(request);

            request.Method = messageRequest.Method.Method;
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

                if (string.Equals(messageRequestHeader.Name, HttpHeader.Names.IfModifiedSince, StringComparison.OrdinalIgnoreCase))
                {
                    request.IfModifiedSince = DateTime.Parse(messageRequestHeader.Value, CultureInfo.InvariantCulture);
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, "Expect", StringComparison.OrdinalIgnoreCase))
                {
                    if (messageRequestHeader.Value == "100-continue")
                    {
                        request.ServicePoint.Expect100Continue = true;
                    }
                    else
                    {
                        request.Expect = messageRequestHeader.Value;
                    }
                    continue;
                }

                if (string.Equals(messageRequestHeader.Name, "Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
                {
                    request.TransferEncoding = messageRequestHeader.Value;
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

            if (request.ContentLength == -1 &&
                messageRequest.Content != null &&
                messageRequest.Content.TryComputeLength(out var length))
            {
                request.ContentLength = length;
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

        private sealed class HttpWebResponseImplementation : Response
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

            public override int Status => (int)_webResponse.StatusCode;

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
                // In the case of failed response the content stream would be
                // pre-buffered subclass of MemoryStream
                // keep it alive because the ResponseBodyPolicy won't re-buffer it
                DisposeStreamIfNotBuffered(ref _originalContentStream);
                DisposeStreamIfNotBuffered(ref _contentStream);
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

        private sealed class HttpWebRequestImplementation : Request
        {
            public HttpWebRequestImplementation()
            {
                Method = RequestMethod.Get;
            }

            private string? _clientRequestId;
            private readonly DictionaryHeaders _headers = new();

            protected internal override void SetHeader(string name, string value) => _headers.SetHeader(name, value);

            protected internal override void AddHeader(string name, string value) => _headers.AddHeader(name, value);

            protected internal override bool TryGetHeader(string name, out string value) => _headers.TryGetHeader(name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => _headers.TryGetHeaderValues(name, out values);

            protected internal override bool ContainsHeader(string name) => _headers.TryGetHeaderValues(name, out _);

            protected internal override bool RemoveHeader(string name) => _headers.RemoveHeader(name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => _headers.EnumerateHeaders();

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
                var content = Content;
                if (content != null)
                {
                    Content = null;
                    content.Dispose();
                }
            }
        }

        private static void ApplyOptionsToRequest(HttpWebRequest request, HttpPipelineTransportOptions options)
        {
            if (options == null)
            {
                return;
            }

            // ServerCertificateCustomValidationCallback
            if (options.ServerCertificateCustomValidationCallback != null)
            {
                request.ServerCertificateValidationCallback =
                    (request, certificate, x509Chain, sslPolicyErrors) => options.ServerCertificateCustomValidationCallback(
                        new ServerCertificateCustomValidationArgs(
                            new X509Certificate2(certificate),
                            x509Chain,
                            sslPolicyErrors));
            }
            // Set ClientCertificates
            foreach (var cert in options.ClientCertificates)
            {
                request.ClientCertificates.Add(cert);
            }
        }
    }
#endif
}
