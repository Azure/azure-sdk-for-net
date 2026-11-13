// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal sealed class SseHttpPipelineResponseHandler : IDisposable
    {
        private const int MaxRedirects = 50;

        // Replaying a request on reconnect requires a private snapshot of the
        // body taken at send time: holding the caller's content instead would
        // transmit whatever those bytes happen to be at reconnect time, which
        // for pooled or reused buffers can be unrelated - possibly another
        // tenant's - data. Snapshotting a large body is an unbounded memory
        // cost per in-flight stream, so requests with a large or unmeasurable
        // body opt out of reconnection and keep their original one-shot
        // behaviour. Callers who need those replayed can do so far more
        // cheaply than this type can: they still own the content, so they can
        // re-send it without a snapshot at all. The limit is set to cover
        // ordinary streaming requests, including long conversations and a
        // single inline image, since a large request tends to produce a
        // long-running stream that is the most exposed to a drop.
        private const long MaxReplayableContentLength = 4 * 1024 * 1024;

        private static readonly Type s_reconnectMessageKey =
            typeof(SseReconnectMessage);

        private readonly HttpPipeline _pipeline;
        private readonly HttpMessage _templateMessage;
        private readonly ResponseClassifier _classifier;
        private readonly Uri _allowedAuthority;
        private readonly List<HttpHeader> _headers;
        private readonly CancellationToken _operationCancellationToken;
        private readonly object _sync = new();
        private readonly string? _initialLastEventId;
        private Uri _uri;
        private RequestMethod _method;
        private BinaryData? _content;
        private bool _initialSendWasAsync;
        private bool _disposed;

        private SseHttpPipelineResponseHandler(
            HttpPipeline pipeline,
            HttpMessage message,
            Uri uri,
            RequestMethod method,
            List<HttpHeader> headers,
            BinaryData? content)
        {
            _pipeline = pipeline;
            _classifier = message.ResponseClassifier;
            _operationCancellationToken = message.CancellationToken;
            _allowedAuthority = uri;
            _uri = uri;
            _method = method;
            _headers = headers;
            _content = content;
            message.Request.Headers.TryGetValue(
                "Last-Event-ID",
                out _initialLastEventId);
            _templateMessage = pipeline.CreateMessage();
            message.CopyPipelineStateTo(_templateMessage);
        }

        public static SseHttpPipelineResponseHandler? TryCreate(
            HttpPipeline pipeline,
            HttpMessage message)
        {
            if (message.BufferResponse ||
                message.TryGetProperty(
                    s_reconnectMessageKey,
                    out _) ||
                !message.Request.Headers.TryGetValues(
                    "Accept",
                    out IEnumerable<string>? values) ||
                !ContainsEventStream(values))
            {
                return null;
            }

            if (!CanSnapshotContent(message.Request.Content))
            {
                return null;
            }

            BinaryData? content = null;
            if (message.Request.Content != null)
            {
                using var buffer = new MemoryStream();
                RequestContent originalContent =
                    message.Request.Content;
                originalContent.WriteTo(
                    buffer,
                    message.CancellationToken);
                // The buffer is not shared, so the replay copy can wrap its
                // backing array directly instead of duplicating the body a
                // second time via ToArray.
                content = BinaryData.FromBytes(
                    new ReadOnlyMemory<byte>(
                        buffer.GetBuffer(),
                        0,
                        (int)buffer.Length));
                message.Request.Content =
                    RequestContent.Create(content);
                originalContent.Dispose();
            }

            RedirectPolicy.SetAllowAutoRedirect(
                message,
                allowAutoRedirect: false);
            var headers = new List<HttpHeader>();
            foreach (HttpHeader header in message.Request.Headers)
            {
                if (!header.Name.Equals(
                    "Last-Event-ID",
                    StringComparison.OrdinalIgnoreCase))
                {
                    headers.Add(header);
                }
            }

            return new SseHttpPipelineResponseHandler(
                pipeline,
                message,
                message.Request.Uri.ToUri(),
                message.Request.Method,
                headers,
                content);
        }

        private static bool CanSnapshotContent(RequestContent? content)
        {
            if (content is null)
            {
                return true;
            }

            return content.TryComputeLength(out long length) &&
                length <= MaxReplayableContentLength;
        }

        public Response WrapInitialResponse(Response response)
        {
            _initialSendWasAsync = false;
            try
            {
                Response current = response;
                Uri requestUri = _uri;
                RequestMethod method = _method;
                BinaryData? content = _content;
                bool dropContentHeaders = false;

                for (int redirectCount = 0;
                    IsRedirectStatus(current.Status);
                    redirectCount++)
                {
                    EnsureRedirectLimit(redirectCount);
                    if (!TryGetRedirect(
                        current,
                        requestUri,
                        method,
                        out SseRedirect redirect))
                    {
                        current.Dispose();
                        throw new InvalidOperationException(
                            "The SSE redirect response did not contain a valid Location header.");
                    }
                    current.Dispose();
                    ApplyRedirect(
                        redirect,
                        ref requestUri,
                        ref method,
                        ref content,
                        ref dropContentHeaders);
                    current = Send(
                        requestUri,
                        method,
                        content,
                        dropContentHeaders,
                        _initialLastEventId,
                        classifyResponse: false,
                        _operationCancellationToken).Response;
                }

                return WrapResponse(current);
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        public async ValueTask<Response> WrapInitialResponseAsync(
            Response response)
        {
            _initialSendWasAsync = true;
            try
            {
                Response current = response;
                Uri requestUri = _uri;
                RequestMethod method = _method;
                BinaryData? content = _content;
                bool dropContentHeaders = false;

                for (int redirectCount = 0;
                    IsRedirectStatus(current.Status);
                    redirectCount++)
                {
                    EnsureRedirectLimit(redirectCount);
                    if (!TryGetRedirect(
                        current,
                        requestUri,
                        method,
                        out SseRedirect redirect))
                    {
                        current.Dispose();
                        throw new InvalidOperationException(
                            "The SSE redirect response did not contain a valid Location header.");
                    }
                    current.Dispose();
                    ApplyRedirect(
                        redirect,
                        ref requestUri,
                        ref method,
                        ref content,
                        ref dropContentHeaders);
                    current = (await SendAsync(
                        requestUri,
                        method,
                        content,
                        dropContentHeaders,
                        _initialLastEventId,
                        classifyResponse: false,
                        _operationCancellationToken).ConfigureAwait(false))
                        .Response;
                }

                return WrapResponse(current);
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        private Response WrapResponse(Response response)
        {
            if (response.Status == 204)
            {
                response.ContentStream?.Dispose();
                response.ContentStream = Stream.Null;
                response.IsError = false;
                Dispose();
                return response;
            }

            if (response.Status != 200)
            {
                Dispose();
                return response;
            }

            // Accept only states a preference. If the service or an
            // intermediary answered with a different media type, parsing it
            // as an event stream would hand the caller an empty stream and
            // silently discard the body, so leave the response untouched.
            if (!IsEventStreamResponse(response))
            {
                Dispose();
                return response;
            }

            Stream initialStream = response.ContentStream ??
                throw DisposeAndCreateInvalidResponseException(response);
            response.ContentStream = new SseReconnectingStream(
                initialStream,
                Reconnect,
                ReconnectAsync,
                _operationCancellationToken,
                reconnectOwner: this,
                initialLastEventId: _initialLastEventId,
                requireLastEventId: !IsIdempotent(_method));
            return response;
        }

        // RFC 9110 section 9.2.2: a client should not automatically retry a
        // request with a non-idempotent method unless it knows the request
        // was never applied. A dropped SSE stream gives no such assurance -
        // the service may have already acted on the request - so replaying
        // one of these is only safe once the service has published a
        // resumption token that tells it to continue rather than repeat the
        // work.
        private static bool IsIdempotent(RequestMethod method)
            => method == RequestMethod.Get ||
                method == RequestMethod.Head ||
                method == RequestMethod.Options ||
                method == RequestMethod.Trace ||
                method == RequestMethod.Put ||
                method == RequestMethod.Delete;

        // Reconnects always use the same pipeline send mode as the initial
        // request. Process and ProcessAsync are independent transport
        // extension points, so a transport that implements only the one
        // used to establish the stream would otherwise fail on the first
        // reconnect.
        private SseReconnectResult? Reconnect(
            string? lastEventId,
            CancellationToken cancellationToken)
        {
            if (!_initialSendWasAsync)
            {
                return ReconnectCoreAsync(
                    false,
                    lastEventId,
                    cancellationToken).EnsureCompleted();
            }

            // The stream was established with SendAsync, so the transport
            // is only known to support ProcessAsync. Blocking here is safe
            // because the reconnect path awaits with ConfigureAwait(false)
            // throughout.
#pragma warning disable AZC0102
            return ReconnectCoreAsync(true, lastEventId, cancellationToken)
                .AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102
        }

        private async ValueTask<SseReconnectResult?> ReconnectAsync(
            string? lastEventId,
            CancellationToken cancellationToken)
#pragma warning disable AZC0108
            => await ReconnectCoreAsync(
                _initialSendWasAsync,
                lastEventId,
                cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0108

        private async ValueTask<SseReconnectResult?>
            ReconnectCoreAsync(
                bool async,
                string? lastEventId,
                CancellationToken cancellationToken)
        {
            Uri requestUri = _uri;
            RequestMethod method = _method;
            BinaryData? content = _content;
            bool dropContentHeaders = false;

            for (int redirectCount = 0; ;)
            {
                EnsureRedirectLimit(redirectCount);
                SseSendResult result = async
                    ? await SendAsync(
                        requestUri,
                        method,
                        content,
                        dropContentHeaders,
                        lastEventId,
                        classifyResponse: true,
                        cancellationToken).ConfigureAwait(false)
                    : Send(
                        requestUri,
                        method,
                        content,
                        dropContentHeaders,
                        lastEventId,
                        classifyResponse: true,
                        cancellationToken);
                Response response = result.Response;

                if (TryGetRedirect(
                    response,
                    requestUri,
                    method,
                    out SseRedirect redirect))
                {
                    response.Dispose();
                    ApplyRedirect(
                        redirect,
                        ref requestUri,
                        ref method,
                        ref content,
                        ref dropContentHeaders);
                    redirectCount++;
                    continue;
                }

                if (response.Status == 204)
                {
                    response.Dispose();
                    return null;
                }

                if (result.IsRetriable)
                {
                    int status = response.Status;
                    response.Dispose();
                    throw new IOException(
                        $"The SSE connection failed with status {status}.");
                }

                if (response.Status != 200)
                {
                    int status = response.Status;
                    response.Dispose();
                    throw new InvalidOperationException(
                        $"An SSE response must have status code 200 or 204, but received {status}.");
                }

                // A successful response that is not an event stream cannot be
                // spliced onto the events already delivered. Ending the
                // stream quietly would be indistinguishable from the 204 stop
                // signal and would present a truncated stream as a complete
                // one, so surface the protocol violation instead.
                if (!IsEventStreamResponse(response))
                {
                    string? contentType = GetContentType(response);
                    response.Dispose();
                    throw new InvalidOperationException(
                        "An SSE reconnect response must have content type " +
                        "'text/event-stream', but received " +
                        $"'{contentType ?? "none"}'.");
                }

                Stream stream = response.ContentStream ??
                    throw DisposeAndCreateInvalidResponseException(response);
                return new SseReconnectResult(stream, response);
            }
        }

        private SseSendResult Send(
            Uri uri,
            RequestMethod method,
            BinaryData? content,
            bool dropContentHeaders,
            string? lastEventId,
            bool classifyResponse,
            CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateMessage(
                uri,
                method,
                content,
                dropContentHeaders,
                lastEventId);
            try
            {
                _pipeline.Send(message, cancellationToken);
            }
            catch (Exception exception) when (
                IsRetriable(message, exception, cancellationToken))
            {
                throw new IOException(
                    "The SSE connection failed.",
                    exception);
            }

            Response response = message.Response;
            bool isRetriable = classifyResponse &&
                _classifier.IsRetriableResponse(message);
            message.ClearResponse();
            return new SseSendResult(response, isRetriable);
        }

        private async ValueTask<SseSendResult> SendAsync(
            Uri uri,
            RequestMethod method,
            BinaryData? content,
            bool dropContentHeaders,
            string? lastEventId,
            bool classifyResponse,
            CancellationToken cancellationToken)
        {
            using HttpMessage message = CreateMessage(
                uri,
                method,
                content,
                dropContentHeaders,
                lastEventId);
            try
            {
                await _pipeline.SendAsync(
                    message,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception) when (
                IsRetriable(message, exception, cancellationToken))
            {
                throw new IOException(
                    "The SSE connection failed.",
                    exception);
            }

            Response response = message.Response;
            bool isRetriable = classifyResponse &&
                _classifier.IsRetriableResponse(message);
            message.ClearResponse();
            return new SseSendResult(response, isRetriable);
        }

        private HttpMessage CreateMessage(
            Uri uri,
            RequestMethod method,
            BinaryData? content,
            bool dropContentHeaders,
            string? lastEventId)
        {
            HttpMessage message = _pipeline.CreateMessage();
            lock (_sync)
            {
                if (_disposed)
                {
                    message.Dispose();
                    throw new ObjectDisposedException(
                        GetType().FullName);
                }
                _templateMessage.CopyPipelineStateTo(message);
            }
            message.BufferResponse = false;
            message.ResponseClassifier = _classifier;
            message.SetProperty(s_reconnectMessageKey, true);
            RedirectPolicy.SetAllowAutoRedirect(
                message,
                allowAutoRedirect: false);
            message.Request.Uri.Reset(uri);
            message.Request.Method = method;

            foreach (HttpHeader header in _headers)
            {
                if (!dropContentHeaders ||
                    !IsContentHeader(header.Name))
                {
                    message.Request.Headers.Add(header);
                }
            }

            if (content != null)
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

            return message;
        }

        private bool IsRetriable(
            HttpMessage message,
            Exception exception,
            CancellationToken cancellationToken)
            => !cancellationToken.IsCancellationRequested &&
                IsRetriableException(message, exception);

        // A retry policy reports an exhausted retry cycle as an
        // AggregateException holding one failure per attempt, and response
        // classifiers only recognize the individual transport exceptions.
        // Classifying the wrapper would therefore end the stream on the
        // first exhausted cycle, which is the outage reconnection exists to
        // survive, so classify the inner exceptions instead.
        private bool IsRetriableException(
            HttpMessage message,
            Exception exception)
        {
            if (exception is AggregateException aggregate)
            {
                if (aggregate.InnerExceptions.Count == 0)
                {
                    return false;
                }

                foreach (Exception innerException in aggregate.InnerExceptions)
                {
                    if (!IsRetriableException(message, innerException))
                    {
                        return false;
                    }
                }

                return true;
            }

            return _classifier.IsRetriable(message, exception);
        }

        private static string? GetContentType(Response response)
            => response.Headers.TryGetValue(
                "Content-Type",
                out string? contentType)
                    ? contentType
                    : null;

        private static bool IsEventStreamResponse(Response response)
            => response.Headers.TryGetValue(
                    "Content-Type",
                    out string? contentType) &&
                IsEventStreamMediaType(contentType);

        private static bool IsEventStreamMediaType(string? contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return false;
            }

            int separator = contentType!.IndexOf(';');
            string mediaType = separator < 0
                ? contentType
                : contentType.Substring(0, separator);
            return mediaType.Trim().Equals(
                "text/event-stream",
                StringComparison.OrdinalIgnoreCase);
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
                    out string? location) ||
                !Uri.TryCreate(
                    requestUri,
                    location,
                    out Uri? redirectUri) ||
                redirectUri == null)
            {
                redirect = null!;
                return false;
            }

            bool forceGet = status switch
            {
                300 or 301 or 302 =>
                    requestMethod == RequestMethod.Post,
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

        private void ApplyRedirect(
            SseRedirect redirect,
            ref Uri requestUri,
            ref RequestMethod method,
            ref BinaryData? content,
            ref bool dropContentHeaders)
        {
            EnsureSameAuthority(redirect.Uri);
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
                        static header =>
                            IsContentHeader(header.Name));
                }
            }
        }

        private void EnsureSameAuthority(Uri uri)
        {
            if (Uri.Compare(
                _allowedAuthority,
                uri,
                UriComponents.SchemeAndServer,
                UriFormat.SafeUnescaped,
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                throw new InvalidOperationException(
                    "SSE redirects to a different authority are not allowed.");
            }
        }

        private static void EnsureRedirectLimit(int redirectCount)
        {
            if (redirectCount >= MaxRedirects)
            {
                throw new InvalidOperationException(
                    $"The SSE request exceeded the maximum of {MaxRedirects} redirects.");
            }
        }

        private static bool ContainsEventStream(
            IEnumerable<string> values)
        {
            foreach (string value in values)
            {
                foreach (string part in SplitOutsideQuotes(value, ','))
                {
                    List<string> mediaRange = SplitOutsideQuotes(part, ';');
                    if (!string.Equals(
                        mediaRange[0].Trim(),
                        "text/event-stream",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // RFC 9110 section 12.4.2: a weight of zero means "not
                    // acceptable". Accept is what opts a request into
                    // snapshotting and reconnection, so a caller that
                    // explicitly rejects event streams must not be opted in
                    // by the same token.
                    if (!HasZeroWeight(mediaRange))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // RFC 9110 sections 5.6.4 and 5.6.6: a parameter value may be a
        // quoted string, and text inside double quotes is a single value
        // rather than syntax. A comma or semicolon there separates nothing,
        // so splitting on every occurrence would both end a media range
        // early - letting 'profile="a,b";q=0' escape its own weight - and
        // invent parameters, letting 'profile="a;q=0;b"' reject a stream the
        // caller accepted.
        private static List<string> SplitOutsideQuotes(
            string value,
            char delimiter)
        {
            List<string> parts = new();
            bool quoted = false;
            int start = 0;

            for (int i = 0; i < value.Length; i++)
            {
                char current = value[i];

                if (quoted && current == '\\' && i + 1 < value.Length)
                {
                    // A quoted-pair escapes the character that follows it,
                    // which may be the quote that would otherwise close the
                    // string.
                    i++;
                    continue;
                }

                if (current == '"')
                {
                    quoted = !quoted;
                }
                else if (current == delimiter && !quoted)
                {
                    parts.Add(value.Substring(start, i - start));
                    start = i + 1;
                }
            }

            parts.Add(value.Substring(start));
            return parts;
        }

        private static bool HasZeroWeight(List<string> mediaRange)
        {
            for (int i = 1; i < mediaRange.Count; i++)
            {
                int separator = mediaRange[i].IndexOf('=');
                if (separator < 0)
                {
                    continue;
                }

                // Parameter names are tokens, never quoted strings, so the
                // first '=' always separates this parameter's name from its
                // value.
                if (!mediaRange[i].Substring(0, separator).Trim().Equals(
                    "q",
                    StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Only the first weight is a quality value; parameters after
                // it are accept extensions and do not affect acceptability.
                return double.TryParse(
                    mediaRange[i].Substring(separator + 1).Trim(),
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out double quality) && quality <= 0;
            }

            return false;
        }

        private static bool IsRedirectStatus(int status)
            => status is 300 or 301 or 302 or 303 or 307 or 308;

        private static bool IsContentHeader(string name)
            => name.StartsWith(
                "Content-",
                StringComparison.OrdinalIgnoreCase) ||
            name.Equals(
                "Transfer-Encoding",
                StringComparison.OrdinalIgnoreCase);

        private static InvalidOperationException
            DisposeAndCreateInvalidResponseException(Response response)
        {
            response.Dispose();
            return new InvalidOperationException(
                "An established SSE response must have a content stream.");
        }

        public void Dispose()
        {
            lock (_sync)
            {
                if (!_disposed)
                {
                    _disposed = true;
                    _templateMessage.Dispose();
                }
            }
        }

        private sealed class SseRedirect(
            Uri uri,
            bool permanent,
            bool forceGet)
        {
            internal Uri Uri { get; } = uri;
            internal bool Permanent { get; } = permanent;
            internal bool ForceGet { get; } = forceGet;
        }

        private sealed class SseSendResult(
            Response response,
            bool isRetriable)
        {
            internal Response Response { get; } = response;
            internal bool IsRetriable { get; } = isRetriable;
        }

        private sealed class SseReconnectMessage
        {
        }
    }
}
