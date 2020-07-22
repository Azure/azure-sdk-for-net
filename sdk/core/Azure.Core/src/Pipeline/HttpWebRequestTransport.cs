// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// The <see cref="HttpWebRequest"/> based <see cref="HttpPipelineTransport"/> implementation.
    /// </summary>
    public class HttpWebRequestTransport : HttpPipelineTransport
    {
        private readonly IWebProxy? _proxy;

        /// <summary>
        /// Creates a new instance of <see cref="HttpWebRequestTransport"/>
        /// </summary>
        public HttpWebRequestTransport()
        {
            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                _proxy = webProxy;
            }
        }

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
            var request = CreateRequest(message.Request);
            using var registration = message.CancellationToken.Register(() => request.Abort());
            try
            {
                if (message.Request.Content != null)
                {
                    if (message.Request.Content.TryComputeLength(out var length))
                    {
                        request.ContentLength = length;
                    }

                    var requestStream = request.GetRequestStream();
                    message.Request.Content.WriteTo(requestStream, message.CancellationToken);
                }

                message.Response = new HttpWebResponseImplementation(message.Request.ClientRequestId, (HttpWebResponse) request.GetResponse());
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
            request.Proxy = _proxy;
            foreach (var messageRequestHeader in messageRequest.Headers)
            {
                request.Headers.Add(messageRequestHeader.Name, messageRequestHeader.Value);
            }

            return request;
        }

        /// <inheritdoc />
        public override ValueTask ProcessAsync(HttpMessage message)
        {
            Process(message);
            return default;
        }

        /// <inheritdoc />
        public override Request CreateRequest()
        {
            return new HttpWebRequestImplementation();
        }

        private sealed class HttpWebResponseImplementation: Response
        {
            private readonly HttpWebResponse _webResponse;

            public HttpWebResponseImplementation(string clientRequestId, HttpWebResponse webResponse)
            {
                _webResponse = webResponse;

                ContentStream = _webResponse.GetResponseStream();
                ClientRequestId = clientRequestId;
            }

            public override int Status => (int) _webResponse.StatusCode;

            public override string ReasonPhrase => _webResponse.StatusDescription;

            public override Stream? ContentStream { get; set; }

            public override string ClientRequestId { get; set; }

            public override void Dispose()
            {
                _webResponse.Dispose();
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
}