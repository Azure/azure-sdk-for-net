// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// An <see cref="HttpPipelineTransport"/> implementation that uses <see cref="HttpClient"/> as the transport.
    /// </summary>
    public class HttpClientTransport : HttpPipelineTransport
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Creates a new <see cref="HttpClientTransport"/> instance using default configuration.
        /// </summary>
        public HttpClientTransport() : this(CreateDefaultClient())
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="HttpClientTransport"/> using the provided client instance.
        /// </summary>
        /// <param name="client">The instance of <see cref="HttpClient"/> to use.</param>
        public HttpClientTransport(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// A shared instance of <see cref="HttpClientTransport"/> with default parameters.
        /// </summary>
        public static readonly HttpClientTransport Shared = new HttpClientTransport();

        /// <inheritdoc />
        public sealed override Request CreateRequest()
            => new PipelineRequest();

        /// <inheritdoc />
        public override void Process(HttpMessage message)
        {
            // Intentionally blocking here
            ProcessAsync(message).GetAwaiter().GetResult();
        }

        /// <inheritdoc />
        public sealed override async ValueTask ProcessAsync(HttpMessage message)
        {
            using (HttpRequestMessage httpRequest = BuildRequestMessage(message))
            {
                HttpResponseMessage responseMessage;
                try
                {
                    responseMessage = await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken)
                        .ConfigureAwait(false);
                }
                catch (HttpRequestException e)
                {
                    throw new RequestFailedException(e.Message, e);
                }

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

        private static HttpRequestMessage BuildRequestMessage(HttpMessage message)
        {
            if (!(message.Request is PipelineRequest pipelineRequest))
            {
                throw new InvalidOperationException("the request is not compatible with the transport");
            }
            return pipelineRequest.BuildRequestMessage(message.CancellationToken);
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out string? value)
        {
            if (TryGetHeader(headers, content, name, out IEnumerable<string>? values))
            {
                value = JoinHeaderValues(values);
                return true;
            }

            value = null;
            return false;
        }

        internal static bool TryGetHeader(HttpHeaders headers, HttpContent? content, string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            return headers.TryGetValues(name, out values) || content?.Headers.TryGetValues(name, out values) == true;
        }

        internal static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers, HttpContent? content)
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
            }

            if (content != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in content.Headers)
                {
                    yield return new HttpHeader(header.Key, JoinHeaderValues(header.Value));
                }
            }
        }

        internal static bool RemoveHeader(HttpHeaders headers, HttpContent? content, string name)
        {
            // .Remove throws on invalid header name so use TryGet here to check
            if (headers.TryGetValues(name, out _) && headers.Remove(name))
            {
                return true;
            }

            return content?.Headers.TryGetValues(name, out _) == true && content.Headers.Remove(name);
        }

        internal static bool ContainsHeader(HttpHeaders headers, HttpContent? content, string name)
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
            foreach (KeyValuePair<string, IEnumerable<string>> header in from)
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

        private sealed class PipelineRequest : Request
        {
            private bool _wasSent = false;
            private readonly HttpRequestMessage _requestMessage;

            private PipelineContentAdapter? _requestContent;

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

            public override RequestContent? Content { get; set; }

            public override string ClientRequestId { get; set; }

            protected internal override void AddHeader(string name, string value)
            {
                if (_requestMessage.Headers.TryAddWithoutValidation(name, value))
                {
                    return;
                }

                PipelineContentAdapter requestContent = EnsureContentInitialized();
                if (!requestContent.Headers.TryAddWithoutValidation(name, value))
                {
                    throw new InvalidOperationException("Unable to add header to request or content");
                }
            }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => HttpClientTransport.TryGetHeader(_requestMessage.Headers, _requestContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => HttpClientTransport.TryGetHeader(_requestMessage.Headers, _requestContent, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_requestMessage.Headers, _requestContent, name);

            protected internal override bool RemoveHeader(string name) => HttpClientTransport.RemoveHeader(_requestMessage.Headers, _requestContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => GetHeaders(_requestMessage.Headers, _requestContent);

            public HttpRequestMessage BuildRequestMessage(CancellationToken cancellation)
            {
                HttpRequestMessage currentRequest;
                if (_wasSent)
                {
                    // A copy of a message needs to be made because HttpClient does not allow sending the same message twice,
                    // and so the retry logic fails.
                    currentRequest = new HttpRequestMessage(_requestMessage.Method, Uri.ToUri());
                    CopyHeaders(_requestMessage.Headers, currentRequest.Headers);
                }
                else
                {
                    currentRequest = _requestMessage;
                }

                currentRequest.RequestUri = Uri.ToUri();


                if (Content != null)
                {
                    PipelineContentAdapter currentContent;
                    if (_wasSent)
                    {
                        currentContent = new PipelineContentAdapter();
                        CopyHeaders(_requestContent!.Headers, currentContent.Headers);
                    }
                    else
                    {
                        currentContent = EnsureContentInitialized();
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

            private static readonly HttpMethod s_patch = new HttpMethod("PATCH");

            private static HttpMethod ToHttpClientMethod(RequestMethod requestMethod)
            {
                var method = requestMethod.Method;
                // Fast-path common values
                if (method.Length == 3)
                {
                    if (string.Equals(method, "GET", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Get;
                    }

                    if (string.Equals(method, "PUT", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Put;
                    }
                }
                else if (method.Length == 4)
                {
                    if (string.Equals(method, "POST", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Post;
                    }
                    if (string.Equals(method, "HEAD", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Head;
                    }
                }
                else
                {
                    if (string.Equals(method, "PATCH", StringComparison.OrdinalIgnoreCase))
                    {
                        return s_patch;
                    }
                    if (string.Equals(method, "DELETE", StringComparison.OrdinalIgnoreCase))
                    {
                        return HttpMethod.Delete;
                    }
                }

                return new HttpMethod(method);
            }

            private PipelineContentAdapter EnsureContentInitialized()
            {
                if (_requestContent == null)
                {
                    _requestContent = new PipelineContentAdapter();
                }

                return _requestContent;
            }

            private sealed class PipelineContentAdapter : HttpContent
            {
                public RequestContent? PipelineContent { get; set; }

                public CancellationToken CancellationToken { get; set; }

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
                {
                    Debug.Assert(PipelineContent != null);
                    await PipelineContent!.WriteToAsync(stream, CancellationToken).ConfigureAwait(false);
                }

                protected override bool TryComputeLength(out long length)
                {
                    Debug.Assert(PipelineContent != null);

                    return PipelineContent!.TryComputeLength(out length);
                }
            }
        }

        private sealed class PipelineResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;

            private readonly HttpContent _responseContent;

            private Stream? _contentStream;

            public PipelineResponse(string requestId, HttpResponseMessage responseMessage)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
                _responseContent = _responseMessage.Content;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase;

            public override Stream? ContentStream
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
                    // Make sure we don't dispose the content if the stream was replaced
                    _responseMessage.Content = null;

                    _contentStream = value;
                }
            }

            public override string ClientRequestId { get; set; }

            protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out value);

            protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values) => HttpClientTransport.TryGetHeader(_responseMessage.Headers, _responseContent, name, out values);

            protected internal override bool ContainsHeader(string name) => HttpClientTransport.ContainsHeader(_responseMessage.Headers, _responseContent, name);

            protected internal override IEnumerable<HttpHeader> EnumerateHeaders() => GetHeaders(_responseMessage.Headers, _responseContent);

            public override void Dispose()
            {
                _responseMessage?.Dispose();
            }

            public override string ToString() => _responseMessage.ToString();
        }

        private class ContentStream : ReadOnlyStream
        {
            private readonly Task<Stream> _contentTask;
            private Stream? _contentStream;

            public ContentStream(Task<Stream> contentTask)
            {
                _contentTask = contentTask;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return Stream.Seek(offset, origin);
            }

            public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                await EnsureStreamAsync().ConfigureAwait(false);
                return await Stream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                return Stream.Read(buffer, offset, count);
            }

            public override bool CanRead
            {
                get
                {
                    return Stream.CanRead;
                }
            }

            public override bool CanSeek
            {
                get
                {
                    return Stream.CanSeek;
                }
            }

            public override long Length
            {
                get
                {
                    return Stream.Length;
                }
            }

            public override long Position
            {
                get
                {
                    return Stream.Position;
                }
                set
                {
                    Stream.Position = value;
                }
            }

            private Stream Stream
            {
                get
                {
                    if (_contentStream == null)
                    {
                        return EnsureStreamAsync().GetAwaiter().GetResult();
                    }

                    return _contentStream;
                }
            }

            private ValueTask<Stream> EnsureStreamAsync()
            {
                async ValueTask<Stream> EnsureStreamAsyncImpl()
                {
                    return (_contentStream = await _contentTask.ConfigureAwait(false));
                }

                return _contentStream == null ? EnsureStreamAsyncImpl() : new ValueTask<Stream>(_contentStream);
            }
        }
    }
}
