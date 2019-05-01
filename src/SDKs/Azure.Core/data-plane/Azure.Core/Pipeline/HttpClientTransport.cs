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
        static readonly HttpClient s_defaultClient = new HttpClient();

        readonly HttpClient _client;

        public HttpClientTransport(HttpClient client = null)
            => _client = client == null ? s_defaultClient : client;

        public readonly static HttpClientTransport Shared = new HttpClientTransport();

        public sealed override Request CreateRequest(IServiceProvider services)
            => new PipelineRequest();

        public sealed override async Task ProcessAsync(HttpPipelineMessage message)
        {
            var pipelineRequest = message.Request as PipelineRequest;
            if (pipelineRequest == null)
                throw new InvalidOperationException("the request is not compatible with the transport");

            using (HttpRequestMessage httpRequest = pipelineRequest.BuildRequestMessage(message.Cancellation))
            {
                HttpResponseMessage responseMessage = await ProcessCoreAsync(message.Cancellation, httpRequest).ConfigureAwait(false);
                message.Response = new PipelineResponse(message.Request.ClientRequestId, responseMessage);
            }
        }

        protected virtual async Task<HttpResponseMessage> ProcessCoreAsync(CancellationToken cancellation, HttpRequestMessage httpRequest)
            => await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellation).ConfigureAwait(false);


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
                    _wasSent = true;
                }

                currentRequest.RequestUri = UriBuilder.Uri;

                if (_requestContent?.PipelineContent != null)
                {
                    currentRequest.Content = new PipelineContentAdapter()
                    {
                        CancellationToken = cancellation,
                        PipelineContent = _requestContent.PipelineContent
                    };
                    CopyHeaders(_requestContent.Headers, currentRequest.Content.Headers);
                }

                return currentRequest;
            }

            public override void Dispose()
            {
                _requestMessage.Dispose();
            }

            public override string ToString() => _requestMessage.ToString();

            readonly static HttpMethod s_patch = new HttpMethod("PATCH");
            public static HttpMethod ToHttpClientMethod(HttpPipelineMethod method)
            {
                switch (method)
                {
                    case HttpPipelineMethod.Get:
                        return HttpMethod.Get;
                    case HttpPipelineMethod.Post:
                        return HttpMethod.Post;
                    case HttpPipelineMethod.Put:
                        return HttpMethod.Put;
                    case HttpPipelineMethod.Delete:
                        return HttpMethod.Delete;
                    case HttpPipelineMethod.Patch:
                        return s_patch;
                    case HttpPipelineMethod.Head:
                        return HttpMethod.Head;

                    default:
                        throw new NotImplementedException();
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
                    await PipelineContent.WriteTo(stream, CancellationToken).ConfigureAwait(false);
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
                await EnsureStreamAsync();
                return await _contentStream.ReadAsync(buffer, offset, count, cancellationToken);
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
                    _contentStream = await _contentTask;
                }

                return _contentStream == null ? EnsureStreamAsyncImpl() : Task.CompletedTask;
            }
        }
    }
}
