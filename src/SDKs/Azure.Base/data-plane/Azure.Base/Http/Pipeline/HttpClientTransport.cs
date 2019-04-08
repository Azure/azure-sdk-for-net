// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Base.Http.Pipeline
{
    public class HttpClientTransport : HttpPipelineTransport
    {
        static readonly HttpClient s_defaultClient = new HttpClient();

        readonly HttpClient _client;

        public HttpClientTransport(HttpClient client = null)
            => _client = client == null ? s_defaultClient : client;

        public readonly static HttpClientTransport Shared = new HttpClientTransport();

        public sealed override HttpPipelineRequest CreateRequest(IServiceProvider services)
            => new PipelineRequest();

        public sealed override async Task ProcessAsync(HttpPipelineMessage message)
        {
            using (HttpRequestMessage httpRequest = BuildRequestMessage(message))
            {
                SetResponse(message, await _client.SendAsync(httpRequest, message.Cancellation).ConfigureAwait(false));
            }
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            using (HttpRequestMessage httpRequest = BuildRequestMessage(message))
            {
                var client = new SyncHttpClientHandler();
                SetResponse(message, client.Send(httpRequest, message.Cancellation));
            }
        }

        private HttpRequestMessage BuildRequestMessage(HttpPipelineMessage message)
        {
            if (!(message.Request is PipelineRequest pipelineRequest))
            {
                throw new InvalidOperationException("the request is not compatible with the transport");
            }

            return pipelineRequest.BuildRequestMessage(message.Cancellation);
        }

        private void SetResponse(HttpPipelineMessage message, HttpResponseMessage httpResponseMessage)
        {
            message.Response = new PipelineResponse(message.Request.RequestId, httpResponseMessage);
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent content, string name, out string value)
        {
            if (headers.TryGetValues(name, out var values) ||
                (content != null && content.Headers.TryGetValues(name, out values)))
            {
                value = JoinHeaderValues(values);
                return true;
            }

            value = null;
            return false;
        }

        internal static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers, HttpContent content)
        {
            foreach (var header in headers)
            {
                yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
            }

            if (content != null)
            {
                foreach (var header in content.Headers)
                {
                    yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
                }
            }
        }

        internal static void CopyHeaders(HttpHeaders from, HttpHeaders to)
        {
            foreach (var header in from)
            {
                if (!to.TryAddWithoutValidation(header.Key, header.Value))
                {
                    throw new InvalidOperationException($"Unable to add header {header} to header collection.");
                }
            }
        }

        private static string JoinHeaderValues(IEnumerable<string> values)
        {
            return string.Join(",", values);
        }

        sealed class PipelineRequest : HttpPipelineRequest
        {
            private readonly HttpRequestMessage _requestMessage;

            private PipelineContentAdapter _requestContent;

            public PipelineRequest()
            {
                _requestMessage = new HttpRequestMessage();
                RequestId = Guid.NewGuid().ToString();
            }

            public override Uri Uri
            {
                get => _requestMessage.RequestUri;
                set => _requestMessage.RequestUri = value;
            }

            public override HttpPipelineMethod Method
            {
                get => HttpPipelineMethodConverter.Parse(_requestMessage.Method.Method);
                set => _requestMessage.Method = ToHttpClientMethod(value);
            }

            public override HttpPipelineRequestContent Content
            {
                get => _requestContent?.PipelineContent;
                set
                {
                    EnsureContentInitialized();
                    _requestContent.PipelineContent = value;
                }
            }

            public override string RequestId { get; set; }

            public override void AddHeader(HttpHeader header)
            {
                AddHeader(header.Name, header.Value);
            }

            public override void AddHeader(string name, string value)
            {
                if (_requestMessage.Headers.TryAddWithoutValidation(name, value))
                {
                    return;
                }

                EnsureContentInitialized();
                if (!_requestContent.Headers.TryAddWithoutValidation(name, value))
                {
                    throw new InvalidOperationException("Unable to add header to request or content");
                }
            }

            public override bool TryGetHeader(string name, out string value) => HttpClientTransport.TryGetHeader(_requestMessage.Headers, _requestContent, name, out value);

            public override IEnumerable<HttpHeader> Headers => HttpClientTransport.GetHeaders(_requestMessage.Headers, _requestContent);

            public HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                // A copy of a message needs to be made because HttpClient does not allow sending the same message twice,
                // and so the retry logic fails.
                var request = new HttpRequestMessage(_requestMessage.Method, _requestMessage.RequestUri);

                CopyHeaders(_requestMessage.Headers, request.Headers);

                if (_requestContent?.PipelineContent != null)
                {
                    request.Content = new PipelineContentAdapter()
                    {
                        CancellationToken = cancellation,
                        PipelineContent = _requestContent.PipelineContent
                    };
                    CopyHeaders(_requestContent.Headers, request.Content.Headers);
                }

                return request;
            }

            public override void Dispose()
            {
                _requestMessage.Dispose();
            }

            public override string ToString() =>  _requestMessage.ToString();

            readonly static HttpMethod s_patch = new HttpMethod("PATCH");
            public static HttpMethod ToHttpClientMethod(HttpPipelineMethod method)
            {
                switch (method) {
                    case HttpPipelineMethod.Get: return HttpMethod.Get;
                    case HttpPipelineMethod.Post: return HttpMethod.Post;
                    case HttpPipelineMethod.Put: return HttpMethod.Put;
                    case HttpPipelineMethod.Delete: return HttpMethod.Delete;
                    case HttpPipelineMethod.Patch: return s_patch;

                    default: throw new NotImplementedException();
                }
            }

            private void EnsureContentInitialized()
            {
                if (_requestContent == null)
                {
                    _requestContent = new PipelineContentAdapter();
                }
            }

            sealed class PipelineContentAdapter : HttpContent
            {
                public HttpPipelineRequestContent PipelineContent { get; set; }

                public CancellationToken CancellationToken { get; set; }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
                {
                    Debug.Assert(PipelineContent != null);
                    await PipelineContent.WriteToAsync(stream, CancellationToken).ConfigureAwait(false);
                }

                protected override bool TryComputeLength(out long length)
                {
                    Debug.Assert(PipelineContent != null);

                    return PipelineContent.TryComputeLength(out length);
                }


                protected override void Dispose(bool disposing)
                {
                    PipelineContent?.Dispose();
                    base.Dispose(disposing);
                }
            }
        }

        sealed class PipelineResponse : HttpPipelineResponse
        {
            readonly HttpResponseMessage _responseMessage;

            public PipelineResponse(string requestId, HttpResponseMessage responseMessage)
            {
                RequestId = requestId;
                _responseMessage = responseMessage;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            // TODO (pri 1): is it ok to just call GetResult here?
            public override Stream ResponseContentStream
                => _responseMessage?.Content?.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            public override string RequestId { get; set; }

            public override bool TryGetHeader(string name, out string value) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseMessage.Content, name, out value);

            public override IEnumerable<HttpHeader> Headers => HttpClientTransport.GetHeaders(_responseMessage.Headers, _responseMessage.Content);

            public override void Dispose()
            {
                _responseMessage?.Dispose();
            }

            public override string ToString() => _responseMessage.ToString();
        }

        private class SyncHttpClientHandler : HttpClientHandler
        {
            public HttpResponseMessage Send(HttpRequestMessage message, CancellationToken cancellationToken)
            {
                return SendAsync(message, cancellationToken).GetAwaiter().GetResult();
            }
        }
    }
}
