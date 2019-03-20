// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Buffers;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;

namespace Azure.Base.Http.Pipeline
{
    public class HttpClientTransport : HttpPipelineTransport
    {
        private static readonly HttpClient s_defaultClient = new HttpClient();

        readonly HttpClient _client;

        public HttpClientTransport(HttpClient client = null)
            => _client = client == null ? s_defaultClient : client;

        public readonly static HttpClientTransport Shared = new HttpClientTransport();

        public sealed override HttpMessage CreateMessage(IServiceProvider services, CancellationToken cancellation)
            => new Message(cancellation);

        public sealed override async Task ProcessAsync(HttpMessage message)
        {
            var httpTransportMessage = message as Message;
            if (httpTransportMessage == null) throw new InvalidOperationException("the message is not compatible with the transport");

            HttpRequestMessage httpRequest = httpTransportMessage.BuildRequestMessage();
            HttpResponseMessage responseMessage = await ProcessCoreAsync(message.Cancellation, httpRequest).ConfigureAwait(false);

            httpTransportMessage.ProcessResponseMessage(responseMessage);
        }

        protected virtual async Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage httpRequest)
            => await _client.SendAsync(httpRequest, cancellation).ConfigureAwait(false);

        sealed class Message : HttpMessage
        {
            string _contentTypeHeaderValue;
            string _contentLengthHeaderValue;
            HttpMessageContent _requestContent;
            HttpRequestMessage _requestMessage;
            HttpResponseMessage _responseMessage;

            public Message(CancellationToken cancellation) : base(cancellation)
                => _requestMessage = new HttpRequestMessage();

            #region Request
            public override void SetRequestLine(HttpVerb method, Uri uri)
            {
                _requestMessage.Method = ToHttpClientMethod(method);
                _requestMessage.RequestUri = uri;
                _requestMessage.Version = new Version(1, 1);
            }

            public override HttpVerb Method => ToPipelineMethod(_requestMessage.Method);

            public override void AddHeader(HttpHeader header)
            {
                var valueString = header.Value.AsciiToString();
                var nameString = header.Name.AsciiToString();
                AddHeader(nameString, valueString);
            }

            public override void AddHeader(string name, string value)
            {
                // TODO (pri 1): any other headers must be added to content?
                if (name.Equals("Content-Type", StringComparison.InvariantCulture)) {
                    _contentTypeHeaderValue = value;
                }
                else if (name.Equals("Content-Length", StringComparison.InvariantCulture)) {
                    _contentLengthHeaderValue = value;
                }
                else {
                    if (!_requestMessage.Headers.TryAddWithoutValidation(name, value)) {
                        throw new InvalidOperationException();
                    }
                }
            }

            public override void SetContent(HttpMessageContent content)
                => _requestContent = content;

            public HttpRequestMessage BuildRequestMessage()
            {
                // A copy of a message needs to be made because HttpClient does not allow sending the same message twice,
                // and so the retry logic fails.
                var message = new HttpRequestMessage(_requestMessage.Method, _requestMessage.RequestUri);
                foreach (var header in _requestMessage.Headers) {
                    if (!message.Headers.TryAddWithoutValidation(header.Key, header.Value)) {
                        throw new Exception("could not add header " + header.ToString());
                    }
                }

                if (_requestContent != null) {
                    message.Content = new PipelineContentAdapter(_requestContent, Cancellation);
                    if (_contentTypeHeaderValue != null) message.Content.Headers.Add("Content-Type", _contentTypeHeaderValue);
                    if (_contentLengthHeaderValue != null) message.Content.Headers.Add("Content-Length", _contentLengthHeaderValue);
                }

                return message;
            }
            #endregion

            #region Response
            internal void ProcessResponseMessage(HttpResponseMessage response) {
                _responseMessage = response;
                _requestMessage.Dispose();
            }

            protected internal override int Status => (int)_responseMessage.StatusCode;

            protected internal override bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            {
                string nameString = name.AsciiToString();
                if (!_responseMessage.Headers.TryGetValues(nameString, out var values)) {
                    if (!_responseMessage.Content.Headers.TryGetValues(nameString, out values)) {
                        value = default;
                        return false;
                    }
                }

                var all = string.Join(",", values);
                value = Encoding.ASCII.GetBytes(all);
                return true;
            }

            // TODO (pri 1): is it ok to just call .Result here?
            protected internal override Stream ResponseContentStream => _responseMessage.Content.ReadAsStreamAsync().Result;
            #endregion

            public override void Dispose()
            {
                _requestContent?.Dispose();
                _requestMessage?.Dispose();
                _responseMessage?.Dispose();
                base.Dispose();
            }

            public override string ToString() =>
                _responseMessage!=null? _responseMessage.ToString() : _requestMessage.ToString();

            readonly static HttpMethod s_patch = new HttpMethod("PATCH");
            public static HttpMethod ToHttpClientMethod(HttpVerb method)
            {
                switch (method) {
                    case HttpVerb.Get: return HttpMethod.Get;
                    case HttpVerb.Post: return HttpMethod.Post;
                    case HttpVerb.Put: return HttpMethod.Put;
                    case HttpVerb.Delete: return HttpMethod.Delete;
                    case HttpVerb.Patch: return s_patch;

                    default: throw new NotImplementedException();
                }
            }

            public static HttpVerb ToPipelineMethod(HttpMethod method)
            {
                switch (method.Method) {
                    case "GET": return HttpVerb.Get;
                    case "POST": return HttpVerb.Post;
                    case "PUT": return HttpVerb.Put;
                    case "DELETE": return HttpVerb.Delete;
                    case "PATCH": return HttpVerb.Patch;

                    // method argument is not a REST verb
                    default: throw new ArgumentOutOfRangeException(nameof(method));
                }
            }

            sealed class PipelineContentAdapter : HttpContent
            {
                HttpMessageContent _content;
                CancellationToken _cancellation;

                public PipelineContentAdapter(HttpMessageContent content, CancellationToken cancellation)
                {
                    Debug.Assert(content != null);

                    _content = content;
                    _cancellation = cancellation;
                }

                protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
                    => await _content.WriteTo(stream, _cancellation).ConfigureAwait(false);

                protected override bool TryComputeLength(out long length)
                    => _content.TryComputeLength(out length);

                protected override void Dispose(bool disposing)
                {
                    _content.Dispose();
                    base.Dispose(disposing);
                }
            }
        }
    }
}
