// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal sealed class AzurePipelineResponse : PipelineResponse
    {
        private readonly PipelineResponseHeaders _headers;
        private readonly int _status;
        private readonly string _reasonPhrase;
        private Stream? _contentStream;

        internal AzurePipelineResponse(HttpMessage message)
        {
            Response response = message.Response;
            _headers = new AzurePipelineResponseHeaders(response.Headers);
            _status = response.Status;
            _reasonPhrase = response.ReasonPhrase;
            _contentStream = message.ExtractResponseContent();
        }

        internal static void ConfigureSse(
            HttpMessage message,
            HttpPipeline pipeline,
            RequestContext? context)
        {
            RedirectPolicy.SetAllowAutoRedirect(message, false);
            message.ResponseClassifier =
                new SseResponseClassifier(message.ResponseClassifier);
            message.SetProperty(
                typeof(SseReconnectState),
                new SseReconnectState(message, pipeline, context));
        }

        internal static Func<string?, CancellationToken, ValueTask<PipelineResponse>>
            GetSseReconnectCallback(HttpMessage message)
        {
            if (message.TryGetProperty(
                typeof(SseReconnectState),
                out object? value) &&
                value is SseReconnectState state)
            {
                state.SetInitialResponse(message);
                return state.ReconnectAsync;
            }

            throw new InvalidOperationException(
                "The SSE response was not configured for reconnection.");
        }

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        internal static AsyncStreamingClientResult<SseItem<T>> CreateSse<T>(
            PipelineResponse response,
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect,
            SseItemParser<T> itemParser,
            Func<SseItem<BinaryData>, bool>? isTerminal = null,
            CancellationToken operationCancellationToken = default)
        {
            if (!operationCancellationToken.CanBeCanceled &&
                reconnect.Target is SseReconnectState state)
            {
                operationCancellationToken = state.CancellationToken;
            }

            var producer = new SseProducer<T>(
                response.Status,
                reconnect,
                itemParser,
                isTerminal);
            if ((response.Status == 204 ||
                IsRedirectStatus(response.Status)) &&
                response.ContentStream is null)
            {
                response.ContentStream = Stream.Null;
            }
            return AsyncStreamingClientResult.Create(
                response,
                producer.Enumerate,
                operationCancellationToken);
        }

        internal static AsyncStreamingClientResult<SseItem<BinaryData>> CreateSse(
            PipelineResponse response,
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect,
            Func<SseItem<BinaryData>, bool>? isTerminal = null,
            CancellationToken operationCancellationToken = default)
            => CreateSse(
                response,
                reconnect,
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal,
                operationCancellationToken);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        public override int Status => _status;

        public override string ReasonPhrase => _reasonPhrase;

        protected override PipelineResponseHeaders HeadersCore => _headers;

        public override Stream? ContentStream
        {
            get => _contentStream;
            set => _contentStream = value;
        }

        public override BinaryData Content
        {
            get
            {
                if (_contentStream is null)
                {
                    return BinaryData.Empty;
                }

                if (_contentStream is not MemoryStream content)
                {
                    throw new InvalidOperationException("The response is not buffered.");
                }

                return content.TryGetBuffer(out ArraySegment<byte> segment)
                    ? new BinaryData(segment.AsMemory())
                    : new BinaryData(content.ToArray());
            }
        }

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = ContentStream;
            if (responseContentStream is not MemoryStream)
            {
                var content = new MemoryStream();
                try
                {
                    if (responseContentStream is not null)
                    {
                        CopyTo(responseContentStream, content, cancellationToken);
                    }
                    content.Position = 0;
                    responseContentStream?.Dispose();
                    ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return Content;
        }

        public override async ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        {
            Stream? responseContentStream = ContentStream;
            if (responseContentStream is not MemoryStream)
            {
                var content = new MemoryStream();
                try
                {
                    if (responseContentStream is not null)
                    {
                        await responseContentStream.CopyToAsync(content, 81920, cancellationToken).ConfigureAwait(false);
                    }
                    content.Position = 0;
                    responseContentStream?.Dispose();
                    ContentStream = content;
                }
                catch
                {
                    content.Dispose();
                    throw;
                }
            }

            return Content;
        }

        public override void Dispose()
        {
            _contentStream?.Dispose();
            _contentStream = null;
        }

        private static void CopyTo(Stream source, Stream destination, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[81920];
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                int bytesRead = source.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    return;
                }

                destination.Write(buffer, 0, bytesRead);
            }
        }

        private static bool IsRedirectStatus(int status)
            => status is 300 or 301 or 302 or 303 or 307 or 308;

        private sealed class SseReconnectState
        {
            private const int MaxRedirects = 50;
            private readonly HttpPipeline _pipeline;
            private readonly RequestContext? _context;
            private readonly ResponseClassifier _responseClassifier;
            private readonly Uri _allowedAuthority;
            private Uri _uri;
            private RequestMethod _method;
            private readonly List<HttpHeader> _headers;
            private BinaryData? _content;
            private SseRedirect? _pendingRedirect;
            private bool _invalidInitialRedirect;

            internal CancellationToken CancellationToken
                => _context?.CancellationToken ?? CancellationToken.None;

            internal SseReconnectState(
                HttpMessage message,
                HttpPipeline pipeline,
                RequestContext? context)
            {
                _pipeline = pipeline;
                _context = context;
                _responseClassifier = message.ResponseClassifier;
                _uri = message.Request.Uri.ToUri();
                _allowedAuthority = _uri;
                _method = message.Request.Method;
                _headers = new List<HttpHeader>();
                foreach (HttpHeader header in message.Request.Headers)
                {
                    if (!header.Name.Equals(
                        "Last-Event-ID",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        _headers.Add(header);
                    }
                }

                if (message.Request.Content is RequestContent content)
                {
                    using var stream = new MemoryStream();
                    content.WriteTo(
                        stream,
                        context?.CancellationToken ?? CancellationToken.None);
                    _content = BinaryData.FromBytes(stream.ToArray());
                    content.Dispose();
                    message.Request.Content = RequestContent.Create(_content);
                }
            }

            internal void SetInitialResponse(HttpMessage message)
            {
                if (!message.HasResponse ||
                    !IsRedirectStatus(message.Response.Status))
                {
                    return;
                }

                _invalidInitialRedirect = !TryGetRedirect(
                    message.Response,
                    message.Request.Uri.ToUri(),
                    message.Request.Method,
                    out SseRedirect redirect);
                _pendingRedirect = _invalidInitialRedirect ? null : redirect;
            }

            internal async ValueTask<PipelineResponse> ReconnectAsync(
                string? lastEventId,
                CancellationToken cancellationToken)
            {
                if (_invalidInitialRedirect)
                {
                    _invalidInitialRedirect = false;
                    throw new InvalidOperationException(
                        "The SSE redirect response did not contain a valid Location header.");
                }

                Uri requestUri = _uri;
                RequestMethod method = _method;
                BinaryData? content = _content;
                bool dropContentHeaders = false;
                if (_pendingRedirect is SseRedirect pendingRedirect)
                {
                    _pendingRedirect = null;
                    ApplyRedirect(
                        pendingRedirect,
                        ref requestUri,
                        ref method,
                        ref content,
                        ref dropContentHeaders);
                }

                for (int redirectCount = 0; ; redirectCount++)
                {
                    if (redirectCount > MaxRedirects)
                    {
                        throw new InvalidOperationException(
                            $"The SSE request exceeded the maximum of {MaxRedirects} redirects.");
                    }
                    if (!HasSameAuthority(_allowedAuthority, requestUri))
                    {
                        throw new InvalidOperationException(
                            "SSE redirects to a different authority are not allowed.");
                    }

                    using HttpMessage message = _pipeline.CreateMessage(_context);
                    message.ResponseClassifier = _responseClassifier;
                    message.BufferResponse = false;
                    RedirectPolicy.SetAllowAutoRedirect(message, false);
                    message.Request.Uri.Reset(requestUri);
                    message.Request.Method = method;
                    foreach (HttpHeader header in _headers)
                    {
                        if (!dropContentHeaders ||
                            !IsContentHeader(header.Name))
                        {
                            message.Request.Headers.SetValue(
                                header.Name,
                                header.Value ?? string.Empty);
                        }
                    }
                    if (content is not null)
                    {
                        message.Request.Content =
                            RequestContent.Create(content);
                    }
                    if (!string.IsNullOrEmpty(lastEventId))
                    {
                        message.Request.Headers.SetValue(
                            "Last-Event-ID",
                            lastEventId!);
                    }

                    try
                    {
                        await SendAsync(
                            message,
                            cancellationToken).ConfigureAwait(false);
                    }
                    catch (Exception exception)
                        when (!cancellationToken.IsCancellationRequested &&
                            IsRetriableException(exception))
                    {
                        throw new IOException(
                            "The SSE reconnect attempt failed.",
                            exception);
                    }
                    if (TryGetRedirect(
                        message.Response,
                        requestUri,
                        method,
                        out SseRedirect redirect))
                    {
                        ApplyRedirect(
                            redirect,
                            ref requestUri,
                            ref method,
                            ref content,
                            ref dropContentHeaders);
                        continue;
                    }

                    if (message.Response.IsError &&
                        _context?.ErrorOptions != ErrorOptions.NoThrow)
                    {
                        throw new RequestFailedException(message.Response);
                    }
                    return new AzurePipelineResponse(message);
                }
            }

            private async ValueTask SendAsync(
                HttpMessage message,
                CancellationToken cancellationToken)
            {
                CancellationToken contextCancellationToken =
                    _context?.CancellationToken ?? CancellationToken.None;
                if (contextCancellationToken.CanBeCanceled &&
                    cancellationToken.CanBeCanceled)
                {
                    using var linkedCancellation = CancellationTokenSource
                        .CreateLinkedTokenSource(
                            contextCancellationToken,
                            cancellationToken);
                    await _pipeline.SendAsync(
                        message,
                        linkedCancellation.Token).ConfigureAwait(false);
                }
                else
                {
                    await _pipeline.SendAsync(
                        message,
                        cancellationToken.CanBeCanceled
                            ? cancellationToken
                            : contextCancellationToken).ConfigureAwait(false);
                }
            }

            private void ApplyRedirect(
                SseRedirect redirect,
                ref Uri requestUri,
                ref RequestMethod method,
                ref BinaryData? content,
                ref bool dropContentHeaders)
            {
                requestUri = redirect.Uri;
                if (redirect.ForceGet)
                {
                    method = RequestMethod.Get;
                    content = null;
                    dropContentHeaders = true;
                }

                if (redirect.Permanent)
                {
                    _uri = requestUri;
                    _method = method;
                    _content = content;
                    if (dropContentHeaders)
                    {
                        _headers.RemoveAll(
                            static header => IsContentHeader(header.Name));
                    }
                }
            }

            private static bool TryGetRedirect(
                Response response,
                Uri requestUri,
                RequestMethod requestMethod,
                out SseRedirect redirect)
            {
                int status = response.Status;
                if (!IsRedirectStatus(status) ||
                    !response.Headers.TryGetValue(
                        "Location",
                        out string? locationValue) ||
                    !Uri.TryCreate(
                        locationValue,
                        UriKind.RelativeOrAbsolute,
                        out Uri? location))
                {
                    redirect = null!;
                    return false;
                }

                Uri redirectUri;
                if (location.IsAbsoluteUri)
                {
                    redirectUri = location;
                }
                else if (!Uri.TryCreate(
                    requestUri,
                    location,
                    out Uri? resolvedUri))
                {
                    redirect = null!;
                    return false;
                }
                else
                {
                    redirectUri = resolvedUri;
                }
                bool forceGet = status switch
                {
                    300 or 301 or 302 => requestMethod == RequestMethod.Post,
                    303 => requestMethod != RequestMethod.Get &&
                        requestMethod != RequestMethod.Head,
                    _ => false
                };
                redirect = new SseRedirect(
                    redirectUri,
                    status is 301 or 308,
                    forceGet);
                return true;
            }

            private static bool HasSameAuthority(Uri left, Uri right)
                => Uri.Compare(
                    left,
                    right,
                    UriComponents.SchemeAndServer,
                    UriFormat.SafeUnescaped,
                    StringComparison.OrdinalIgnoreCase) == 0;

            private bool IsRetriableException(Exception exception)
            {
                if (exception is not AggregateException aggregate)
                {
                    return _responseClassifier.IsRetriableException(exception);
                }

                if (aggregate.InnerExceptions.Count == 0)
                {
                    return false;
                }
                foreach (Exception innerException in aggregate.InnerExceptions)
                {
                    if (!_responseClassifier.IsRetriableException(innerException))
                    {
                        return false;
                    }
                }
                return true;
            }

            private static bool IsContentHeader(string name)
                => name.Equals(
                    "Content-Length",
                    StringComparison.OrdinalIgnoreCase) ||
                    name.Equals(
                        "Content-Type",
                        StringComparison.OrdinalIgnoreCase) ||
                    name.Equals(
                        "Transfer-Encoding",
                        StringComparison.OrdinalIgnoreCase);

            private sealed class SseRedirect(
                Uri uri,
                bool permanent,
                bool forceGet)
            {
                internal Uri Uri { get; } = uri;

                internal bool Permanent { get; } = permanent;

                internal bool ForceGet { get; } = forceGet;
            }
        }

        private sealed class SseProducer<T>(
            int initialStatus,
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect,
            SseItemParser<T> itemParser,
            Func<SseItem<BinaryData>, bool>? isTerminal)
        {
            private static readonly TimeSpan s_defaultReconnectionInterval =
                TimeSpan.FromSeconds(3);
            private readonly object _sync = new object();
            private PipelineResponse? _activeResponse;

            internal async IAsyncEnumerable<SseItem<T>> Enumerate(
                Stream initialStream,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                if (initialStatus == 204)
                {
                    yield break;
                }
                if (initialStatus != 200 &&
                    !IsRedirectStatus(initialStatus))
                {
                    throw new InvalidOperationException(
                        $"An SSE response must have status code 200 or 204, but received {initialStatus}.");
                }

                using CancellationTokenRegistration registration =
                    cancellationToken.Register(
                        static state => ((SseProducer<T>)state!).CloseActiveResponse(),
                        this);

                Stream stream = initialStream;
                string? lastEventId = null;
                TimeSpan reconnectionInterval = s_defaultReconnectionInterval;
                if (IsRedirectStatus(initialStatus))
                {
                    initialStream.Dispose();
                    PipelineResponse redirectedResponse = await reconnect(
                        null,
                        cancellationToken).ConfigureAwait(false);
                    if (redirectedResponse.Status == 204)
                    {
                        redirectedResponse.Dispose();
                        yield break;
                    }
                    if (redirectedResponse.Status != 200)
                    {
                        int status = redirectedResponse.Status;
                        redirectedResponse.Dispose();
                        throw new InvalidOperationException(
                            $"An SSE response must have status code 200 or 204, but received {status}.");
                    }

                    Stream redirectedStream =
                        redirectedResponse.ContentStream ??
                        throw DisposeAndCreateInvalidResponseException(
                            redirectedResponse);
                    SetActiveResponse(
                        redirectedResponse,
                        cancellationToken);
                    stream = redirectedStream;
                }

                while (true)
                {
                    bool terminalReceived = false;
                    try
                    {
                        SseParser<BinaryData> parser = SseParser.Create(
                            stream,
                            static (_, data) => BinaryData.FromBytes(data.ToArray()));
                        IAsyncEnumerator<SseItem<BinaryData>> enumerator =
                            parser.EnumerateAsync(cancellationToken)
                                .GetAsyncEnumerator(cancellationToken);
                        try
                        {
                            while (await MoveNextOrReconnectAsync(
                                enumerator,
                                cancellationToken).ConfigureAwait(false))
                            {
                                SseItem<BinaryData> item = enumerator.Current;
                                if (item.EventId is not null)
                                {
                                    lastEventId = item.EventId;
                                }
                                if (item.ReconnectionInterval is TimeSpan retry)
                                {
                                    reconnectionInterval = retry;
                                }
                                if (isTerminal?.Invoke(item) == true)
                                {
                                    terminalReceived = true;
                                    break;
                                }

                                T data = itemParser(
                                    item.EventType,
                                    item.Data.ToMemory().Span);
                                yield return new SseItem<T>(data, item.EventType)
                                {
                                    EventId = item.EventId,
                                    ReconnectionInterval = item.ReconnectionInterval
                                };
                            }
                        }
                        finally
                        {
                            await enumerator.DisposeAsync().ConfigureAwait(false);
                        }
                    }
                    finally
                    {
                        CloseActiveResponse();
                    }

                    if (terminalReceived)
                    {
                        yield break;
                    }

                    PipelineResponse nextResponse;
                    while (true)
                    {
                        await Task.Delay(
                            reconnectionInterval,
                            cancellationToken).ConfigureAwait(false);
                        try
                        {
                            nextResponse = await reconnect(
                                string.IsNullOrEmpty(lastEventId)
                                    ? null
                                    : lastEventId,
                                cancellationToken).ConfigureAwait(false);
                            break;
                        }
                        catch (IOException)
                            when (!cancellationToken.IsCancellationRequested)
                        {
                            continue;
                        }
                    }
                    if (nextResponse.Status == 204)
                    {
                        nextResponse.Dispose();
                        yield break;
                    }
                    if (nextResponse.Status != 200)
                    {
                        int status = nextResponse.Status;
                        nextResponse.Dispose();
                        throw new InvalidOperationException(
                            $"An SSE response must have status code 200 or 204, but received {status}.");
                    }

                    Stream nextStream = nextResponse.ContentStream ??
                        throw DisposeAndCreateInvalidResponseException(nextResponse);
                    SetActiveResponse(nextResponse, cancellationToken);
                    stream = nextStream;
                }
            }

            private static async ValueTask<bool> MoveNextOrReconnectAsync(
                IAsyncEnumerator<SseItem<BinaryData>> enumerator,
                CancellationToken cancellationToken)
            {
                try
                {
                    return await enumerator.MoveNextAsync().ConfigureAwait(false);
                }
                catch (IOException) when (!cancellationToken.IsCancellationRequested)
                {
                    return false;
                }
            }

            private void SetActiveResponse(
                PipelineResponse response,
                CancellationToken cancellationToken)
            {
                try
                {
                    lock (_sync)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        _activeResponse = response;
                    }
                }
                catch
                {
                    response.Dispose();
                    throw;
                }
            }

            private void CloseActiveResponse()
            {
                PipelineResponse? response;
                lock (_sync)
                {
                    response = _activeResponse;
                    _activeResponse = null;
                }
                response?.Dispose();
            }

            private static InvalidOperationException
                DisposeAndCreateInvalidResponseException(PipelineResponse response)
            {
                response.Dispose();
                return new InvalidOperationException(
                    "An established SSE response must have a content stream.");
            }
        }

        private sealed class SseResponseClassifier(
            ResponseClassifier inner) : ResponseClassifier
        {
            public override bool IsErrorResponse(HttpMessage message)
                => message.Response.Status != 204 &&
                    !IsRedirectStatus(message.Response.Status) &&
                    inner.IsErrorResponse(message);

            public override bool IsRetriableResponse(HttpMessage message)
                => inner.IsRetriableResponse(message);

            public override bool IsRetriableException(Exception exception)
                => inner.IsRetriableException(exception);

            public override bool IsRetriable(
                HttpMessage message,
                Exception exception)
                => inner.IsRetriable(message, exception);
        }

        private sealed class AzurePipelineResponseHeaders : PipelineResponseHeaders
        {
            private readonly Dictionary<string, string> _headerValues;
            private readonly Dictionary<string, IEnumerable<string>> _headerValueCollections;
            private readonly List<KeyValuePair<string, string>> _headerList;

            internal AzurePipelineResponseHeaders(ResponseHeaders headers)
            {
                _headerValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                _headerValueCollections = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);
                _headerList = new List<KeyValuePair<string, string>>();
                foreach (HttpHeader header in headers)
                {
                    if (!_headerValues.ContainsKey(header.Name))
                    {
                        _headerValues.Add(header.Name, header.Value);
                    }
                    if (!_headerValueCollections.ContainsKey(header.Name)
                        && headers.TryGetValues(header.Name, out IEnumerable<string>? values))
                    {
                        _headerValueCollections.Add(header.Name, new List<string>(values));
                    }
                    _headerList.Add(new KeyValuePair<string, string>(header.Name, header.Value));
                }
            }

            public override bool TryGetValue(string name, out string? value)
                => _headerValues.TryGetValue(name, out value);

            public override bool TryGetValues(string name, out IEnumerable<string>? values)
                => _headerValueCollections.TryGetValue(name, out values);

            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                foreach (KeyValuePair<string, string> header in _headerList)
                {
                    yield return header;
                }
            }
        }
    }
}
