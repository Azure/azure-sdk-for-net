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
        /// <param name="messageHandler">The instance of <see cref="HttpMessageHandler"/> to use.</param>
        public HttpClientTransport(HttpMessageHandler messageHandler)
        {
            _client = new HttpClient(messageHandler) ?? throw new ArgumentNullException(nameof(messageHandler));
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
#if NET5_0
            ProcessAsync(message, false).EnsureCompleted();
#else
            // Intentionally blocking here
            ProcessAsync(message).AsTask().GetAwaiter().GetResult();
#endif
        }

        /// <inheritdoc />
        public sealed override async ValueTask ProcessAsync(HttpMessage message)
        {
            await ProcessAsync(message, true).ConfigureAwait(false);
        }

#pragma warning disable CA1801 // async parameter unused on netstandard
        private async Task ProcessAsync(HttpMessage message, bool async)
#pragma warning restore CA1801
        {
            using HttpRequestMessage httpRequest = BuildRequestMessage(message);
            HttpResponseMessage responseMessage;
            Stream? contentStream = null;
            try
            {
#if NET5_0
                if (!async)
                {
                    responseMessage = _client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken);
                }
                else
#endif
                {
                    responseMessage = await _client.SendAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead, message.CancellationToken)
                        .ConfigureAwait(false);
                }

                if (responseMessage.Content != null)
                {
#if NET5_0
                    if (async)
                    {
                        contentStream = await responseMessage.Content.ReadAsStreamAsync(message.CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        contentStream = responseMessage.Content.ReadAsStream(message.CancellationToken);
                    }
#else
                    contentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif

                }
            }
            catch (HttpRequestException e)
            {
                throw new RequestFailedException(e.Message, e);
            }

            message.Response = new PipelineResponse(message.Request.ClientRequestId, responseMessage, contentStream);
        }

        private static HttpClient CreateDefaultClient()
        {
            var httpClientHandler = new HttpClientHandler();
            if (HttpEnvironmentProxy.TryCreate(out IWebProxy webProxy))
            {
                httpClientHandler.Proxy = webProxy;
            }

#if NETFRAMEWORK
            ServicePointHelpers.SetLimits(httpClientHandler);
#endif

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
            return headers.TryGetValues(name, out values) ||
                   content != null &&
                   content.Headers.TryGetValues(name, out values);
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
            private bool _wasSent;
            private readonly HttpRequestMessage _requestMessage;

            private PipelineContentAdapter? _requestContent;
            private string? _clientRequestId;

            public PipelineRequest()
            {
                _requestMessage = new HttpRequestMessage();
            }

            public override RequestMethod Method
            {
                get => RequestMethod.Parse(_requestMessage.Method.Method);
                set => _requestMessage.Method = ToHttpClientMethod(value);
            }

            public override RequestContent? Content { get; set; }

            public override string ClientRequestId
            {
                get => _clientRequestId ??= Guid.NewGuid().ToString();
                set
                {
                    Argument.AssertNotNull(value, nameof(value));
                    _clientRequestId = value;
                }
            }

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
                _requestContent?.Dispose();
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

                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
                {
                    Debug.Assert(PipelineContent != null);
                    await PipelineContent!.WriteToAsync(stream, CancellationToken).ConfigureAwait(false);
                }

                protected override bool TryComputeLength(out long length)
                {
                    Debug.Assert(PipelineContent != null);

                    return PipelineContent!.TryComputeLength(out length);
                }

#if NET5_0
                protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    Debug.Assert(PipelineContent != null);
                    await PipelineContent!.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
                }

                protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
                {
                    Debug.Assert(PipelineContent != null);
                    PipelineContent.WriteTo(stream, cancellationToken);
                }
#endif
            }
        }

        private sealed class PipelineResponse : Response
        {
            private readonly HttpResponseMessage _responseMessage;

            private readonly HttpContent _responseContent;

#pragma warning disable CA2213 // Content stream is intentionally not disposed
            private Stream? _contentStream;
#pragma warning restore CA2213

            public PipelineResponse(string requestId, HttpResponseMessage responseMessage, Stream? contentStream)
            {
                ClientRequestId = requestId ?? throw new ArgumentNullException(nameof(requestId));
                _responseMessage = responseMessage ?? throw new ArgumentNullException(nameof(responseMessage));
                _contentStream = contentStream;
                _responseContent = _responseMessage.Content;
            }

            public override int Status => (int)_responseMessage.StatusCode;

            public override string ReasonPhrase => _responseMessage.ReasonPhrase ?? string.Empty;

            public override Stream? ContentStream
            {
                get => _contentStream;
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
    }
}
