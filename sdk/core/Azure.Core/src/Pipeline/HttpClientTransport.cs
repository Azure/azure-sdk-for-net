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

namespace Azure.Core.Pipeline
{
    public class HttpClientTransport : HttpPipelineTransport
    {
        private readonly HttpClient _client;

        public HttpClientTransport() : this(CreateDefaultClient())
        {
        }

        public HttpClientTransport(HttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            _client = client;
        }

        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        public sealed override Request CreateRequest()
            => new PipelineRequest();

        public override void Process(HttpPipelineMessage message)
        {
            // Intentionally blocking here
            ProcessAsync(message).GetAwaiter().GetResult();
        }

        public sealed override async Task ProcessAsync(HttpPipelineMessage message)
        {
            using (HttpRequestMessage httpRequest = BuildRequestMessage(message))
            {
                HttpResponseMessage responseMessage = await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken)
                    .ConfigureAwait(false);
                message.Response = new PipelineResponse(message.Request.ClientRequestId, responseMessage);
            }
        }

        private static HttpClient CreateDefaultClient()
        {
            var httpClientHandler = new HttpClientHandler();
            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                httpClientHandler.Proxy = webProxy;
            }

            return new HttpClient(httpClientHandler);
        }

        private static HttpRequestMessage BuildRequestMessage(HttpPipelineMessage message)
        {
            var pipelineRequest = message.Request as PipelineRequest;
            if (pipelineRequest == null)
            {
                throw new InvalidOperationException("the request is not compatible with the transport");
            }
            return pipelineRequest.BuildRequestMessage(message.CancellationToken);
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent content, string name, out string value)
        {
            if (TryGetHeader(headers, content, name, out IEnumerable<string> values))
            {
                value = JoinHeaderValues(values);
                return true;
            }

            value = null;
            return false;
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent content, string name, out IEnumerable<string> values)
        {
            return headers.TryGetValues(name, out values) || content?.Headers.TryGetValues(name, out values) == true;
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

        internal static bool RemoveHeader(HttpHeaders headers, HttpContent content, string name)
        {
            // .Remove throws on invalid header name so use TryGet here to check
            if (headers.TryGetValues(name, out _ ) && headers.Remove(name))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _ ) == true && content.Headers.Remove(name);
        }

        internal static bool ContainsHeader(HttpHeaders headers, HttpContent content, string name)
        {
            // .Contains throws on invalid header name so use TryGet here
            if (headers.TryGetValues(name, out _))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _) == true;
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

        sealed class PipelineRequest : Request
        {
            private bool _wasSent = false;
            private readonly HttpRequestMessage _requestMessage;

            private PipelineContentAdapter _requestContent;

            public PipelineRequest()
            {
                _requestMessage = new HttpRequestMessage();
                ClientRequestId = Guid.NewGuid().ToString();
            }

            public override RequestMethod Method
            {
                get => RequestMethod.Parse(_requestMessage.Method.Method);
                set => _requestMessage.Method = ToHttpClientMethod(value);
            }

            public override HttpPipelineRequestContent Content { get; set; }

            public override string ClientRequestId { get; set; }

            protected internal override void AddHeader(string name, string value)
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

            protected internal override bool TryGetHeader(string name, out string value) => HttpClientTransport.TryGetHeader(_requestMessage.Headers, _requestContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => HttpClientTransport.TryGetHeader(_requestMessage.Headers, _requestContent, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_requestMessage.Headers, _requestContent, name);

            protected internal override bool RemoveHeader(string name) => HttpClientTransport.RemoveHeader(_requestMessage.Headers, _requestContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => HttpClientTransport.GetHeaders(_requestMessage.Headers, _requestContent);

            public HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                HttpRequestMessage currentRequest;
                if (_wasSent)
                {
                    // A copy of a message needs to be made because HttpClient does not allow sending the same message twice,
                    // and so the retry logic fails.
                    currentRequest = new HttpRequestMessage(_requestMessage.Method, UriBuilder.Uri);
                    CopyHeaders(_requestMessage.Headers, currentRequest.Headers);
                }
                else
                {
                    currentRequest = _requestMessage;
                }

                currentRequest.RequestUri = UriBuilder.Uri;


                if (Content != null)
                {
                    PipelineContentAdapter currentContent;
                    if (_wasSent)
                    {
                        currentContent = new PipelineContentAdapter();
                        CopyHeaders(_requestContent.Headers, currentContent.Headers);
                    }
                    else
                    {
                        EnsureContentInitialized();
                        currentContent = _requestContent;
                    }

                    currentContent.CancellationToken = cancellation;
                    currentContent.PipelineContent = Content;
                    currentRequest.Content = currentContent;
                }

                _wasSent = true;
                return currentRequest;
            }

            public override void Dispose()
            {
                Content?.Dispose();
                _requestMessage.Dispose();
            }

            public override string ToString() => _requestMessage.ToString();

            readonly static HttpMethod s_patch = new HttpMethod("PATCH");

            private static HttpMethod ToHttpClientMethod(RequestMethod method)
            {
                switch (method.Method)
                {
                    case "GET":
                        return HttpMethod.Get;
                    case "POST":
                        return HttpMethod.Post;
                    case "PUT":
                        return HttpMethod.Put;
                    case "DELETE":
                        return HttpMethod.Delete;
                    case "PATCH":
                        return s_patch;
                    case "HEAD":
                        return HttpMethod.Head;
                    default:
                        return new HttpMethod(method.Method);
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
            }
        }

        sealed class PipelineResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;

            private Stream _contentStream;

            public PipelineResponse(string requestId, HttpResponseMessage responseMessage)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase;

            public override Stream ContentStream
            {
                get
                {
                    if (_contentStream != null)
                    {
                        return _contentStream;
                    }

                    if (_responseMessage.Content == null)
                    {
                        return null;
                    }

                    Task<Stream> contentTask = _responseMessage.Content.ReadAsStreamAsync();

                    if (contentTask.IsCompleted)
                    {
                        _contentStream = contentTask.GetAwaiter().GetResult();
                    }
                    else
                    {
                        _contentStream = new ContentStream(contentTask);
                    }

                    return _contentStream;
                }
                set
                {
                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            protected internal override bool TryGetHeader(string name, out string value) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseMessage.Content, name, out value);

            protected internal override bool TryGetHeaderValues(string name, out IEnumerable<string> values) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseMessage.Content, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_responseMessage.Headers, _responseMessage.Content, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => HttpClientTransport.GetHeaders(_responseMessage.Headers, _responseMessage.Content);

            public override void Dispose()
            {
                _responseMessage?.Dispose();
            }

            public override string ToString() => _responseMessage.ToString();
        }

        private class ContentStream : ReadOnlyStream
        {
            private readonly Task<Stream> _contentTask;
            private Stream _contentStream;

            public ContentStream(Task<Stream> contentTask)
            {
                _contentTask = contentTask;
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                EnsureStream();
                return _contentStream.Seek(offset, origin);
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                await EnsureStreamAsync().ConfigureAwait(false);
                return await _contentStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                EnsureStream();
                return _contentStream.Read(buffer, offset, count);
            }

            public override bool CanRead
            {
                get
                {
                    EnsureStream();
                    return _contentStream.CanRead;
                }
            }

            public override bool CanSeek
            {
                get
                {
                    EnsureStream();
                    return _contentStream.CanSeek;
                }
            }

            public override long Length
            {
                get
                {
                    EnsureStream();
                    return _contentStream.Length;
                }
            }

            public override long Position
            {
                get
                {
                    EnsureStream();
                    return _contentStream.Position;
                }
                set
                {
                    EnsureStream();
                    _contentStream.Position = value;
                }
            }

            private void EnsureStream()
            {
                if (_contentStream != null)
                {
                    EnsureStreamAsync().GetAwaiter().GetResult();
                }
            }

            private Task EnsureStreamAsync()
            {
                async Task EnsureStreamAsyncImpl()
                {
                    _contentStream = await _contentTask.ConfigureAwait(false);
                }

                return _contentStream == null ? EnsureStreamAsyncImpl() : Task.CompletedTask;
            }
        }
    }
}
