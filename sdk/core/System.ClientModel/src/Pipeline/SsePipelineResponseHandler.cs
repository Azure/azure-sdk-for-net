// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

internal sealed class SsePipelineResponseHandler : IDisposable
{
    private const int MaxRedirects = 50;

    // Replaying a request on reconnect requires a private snapshot of the
    // body taken at send time: holding the caller's content instead would
    // transmit whatever those bytes happen to be at reconnect time, which for
    // pooled or reused buffers can be unrelated - possibly another tenant's -
    // data. Snapshotting a large body is an unbounded memory cost per
    // in-flight stream, so requests with a large or unmeasurable body opt out
    // of reconnection and keep their original one-shot behaviour. Callers who
    // need those replayed can do so far more cheaply than this type can: they
    // still own the content, so they can re-send it without a snapshot at all.
    // The limit is set to cover ordinary streaming requests, including long
    // conversations and a single inline image, since a large request tends to
    // produce a long-running stream that is the most exposed to a drop.
    private const long MaxReplayableContentLength = 4 * 1024 * 1024;

    private readonly ClientPipeline _pipeline;
    private readonly PipelineMessage _templateMessage;
    private readonly PipelineMessageClassifier _classifier;
    private readonly Uri _allowedAuthority;
    private readonly List<KeyValuePair<string, string>> _headers = [];
    private readonly CancellationToken _operationCancellationToken;
    private readonly object _sync = new();
    private readonly string? _initialLastEventId;
    private Uri _uri;
    private string _method;
    private BinaryData? _content;
    private bool _initialSendWasAsync;
    private bool _disposed;

    private SsePipelineResponseHandler(
        ClientPipeline pipeline,
        PipelineMessage message)
    {
        _pipeline = pipeline;
        _classifier = message.ResponseClassifier;
        _operationCancellationToken = message.CancellationToken;
        _uri = message.Request.Uri ??
            throw new InvalidOperationException(
                "An SSE request must have a URI.");
        _allowedAuthority = _uri;
        _method = message.Request.Method;
        message.Request.Headers.TryGetValue(
            "Last-Event-ID",
            out _initialLastEventId);
        foreach (KeyValuePair<string, string> header in message.Request.Headers)
        {
            if (!header.Key.Equals(
                "Last-Event-ID",
                StringComparison.OrdinalIgnoreCase))
            {
                _headers.Add(header);
            }
        }

        if (message.Request.Content is BinaryContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, message.CancellationToken);
            // The buffer is not shared, so the replay copy can wrap its
            // backing array directly instead of duplicating the body a
            // second time via ToArray.
            _content = BinaryData.FromBytes(
                new ReadOnlyMemory<byte>(
                    stream.GetBuffer(),
                    0,
                    (int)stream.Length));
            content.Dispose();
            message.Request.Content = BinaryContent.Create(_content);
        }

        _templateMessage = pipeline.CreateMessage();
        message.CopyPipelineStateTo(_templateMessage);
        message.ResponseClassifier =
            new SseMessageClassifier(_classifier);
    }

    internal static SsePipelineResponseHandler? TryCreate(
        ClientPipeline pipeline,
        PipelineMessage message)
    {
        if (message.TryGetProperty(
            typeof(SseReconnectRequest),
            out object? value) &&
            value is true)
        {
            return null;
        }
        if (message.BufferResponse ||
            !message.Request.Headers.TryGetValue(
                "Accept",
                out string? accept) ||
            !ContainsEventStream(accept))
        {
            return null;
        }
        if (!CanSnapshotContent(message.Request.Content))
        {
            return null;
        }

        return new SsePipelineResponseHandler(pipeline, message);
    }

    private static bool CanSnapshotContent(BinaryContent? content)
    {
        if (content is null)
        {
            return true;
        }

        return content.TryComputeLength(out long length) &&
            length <= MaxReplayableContentLength;
    }

    internal void WrapResponse(PipelineMessage message)
    {
        _initialSendWasAsync = false;
        PipelineResponse response = message.Response ??
            throw new InvalidOperationException(
                "The SSE request did not produce a response.");
        if (IsRedirectStatus(response.Status))
        {
            response = FollowInitialRedirects(response);
            message.Response = response;
        }

        message.ResponseClassifier = _classifier;
        WrapEstablishedResponse(response);
    }

    internal async ValueTask WrapResponseAsync(PipelineMessage message)
    {
        _initialSendWasAsync = true;
        PipelineResponse response = message.Response ??
            throw new InvalidOperationException(
                "The SSE request did not produce a response.");
        if (IsRedirectStatus(response.Status))
        {
            response = await FollowInitialRedirectsAsync(
                response).ConfigureAwait(false);
            message.Response = response;
        }

        message.ResponseClassifier = _classifier;
        WrapEstablishedResponse(response);
    }

    // The caller's message carries a private classifier for the duration of
    // the send so that a 204 or a redirect is not treated as an error by the
    // classifier the caller supplied. If the send fails, the message is still
    // observable to the caller, so the original contract has to be put back
    // before the exception escapes.
    internal void RestoreClassifier(PipelineMessage message)
        => message.ResponseClassifier = _classifier;

    private void WrapEstablishedResponse(PipelineResponse response)
    {
        if (response.Status == 204)
        {
            response.ContentStream?.Dispose();
            response.ContentStream = Stream.Null;
            Dispose();
            return;
        }
        if (response.Status != 200)
        {
            Dispose();
            return;
        }

        // Accept only states a preference. If the service or an intermediary
        // answered with a different media type, parsing it as an event stream
        // would hand the caller an empty stream and silently discard the
        // body, so leave the response untouched.
        if (!IsEventStreamResponse(response))
        {
            Dispose();
            return;
        }

        Stream initialStream = response.ContentStream ??
            throw new InvalidOperationException(
                "An established SSE response must have a content stream.");

        response.ContentStream = new SseReconnectingStream(
            initialStream,
            Reconnect,
            ReconnectAsync,
            _operationCancellationToken,
            reconnectOwner: this,
            initialLastEventId: _initialLastEventId,
            requireLastEventId: !IsIdempotent(_method));
    }

    // RFC 9110 section 9.2.2: a client should not automatically retry a
    // request with a non-idempotent method unless it knows the request was
    // never applied. A dropped SSE stream gives no such assurance - the
    // service may have already acted on the request - so replaying one of
    // these is only safe once the service has published a resumption token
    // that tells it to continue rather than repeat the work.
    private static bool IsIdempotent(string method)
        => method.Equals("GET", StringComparison.OrdinalIgnoreCase) ||
            method.Equals("HEAD", StringComparison.OrdinalIgnoreCase) ||
            method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase) ||
            method.Equals("TRACE", StringComparison.OrdinalIgnoreCase) ||
            method.Equals("PUT", StringComparison.OrdinalIgnoreCase) ||
            method.Equals("DELETE", StringComparison.OrdinalIgnoreCase);

    // Reconnects always use the same pipeline send mode as the initial
    // request. Process and ProcessAsync are independent transport
    // extension points, so a transport that implements only the one used
    // to establish the stream would otherwise fail on the first reconnect.
    private SseReconnectResult? Reconnect(
        string? lastEventId,
        CancellationToken cancellationToken)
    {
        if (!_initialSendWasAsync)
        {
            return ReconnectCoreAsync(false, lastEventId, cancellationToken)
                .EnsureCompleted();
        }

        // The stream was established with SendAsync, so the transport is
        // only known to support ProcessAsync. Blocking here is safe because
        // the reconnect path awaits with ConfigureAwait(false) throughout.
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

    private async ValueTask<SseReconnectResult?> ReconnectCoreAsync(
        bool async,
        string? lastEventId,
        CancellationToken cancellationToken)
    {
        Uri requestUri = _uri;
        string method = _method;
        BinaryData? content = _content;
        bool dropContentHeaders = false;

        for (int redirectCount = 0; ; redirectCount++)
        {
            if (redirectCount >= MaxRedirects)
            {
                throw new InvalidOperationException(
                    $"The SSE request exceeded the maximum of {MaxRedirects} redirects.");
            }
            EnsureSameAuthority(requestUri);

            using PipelineMessage message = CreateReconnectMessage(
                requestUri,
                method,
                content,
                dropContentHeaders,
                lastEventId,
                cancellationToken);

            try
            {
                if (async)
                {
                    await _pipeline.SendAsync(message).ConfigureAwait(false);
                }
                else
                {
                    _pipeline.Send(message);
                }
            }
            catch (Exception exception)
                when (!cancellationToken.IsCancellationRequested &&
                    IsRetriable(message, exception))
            {
                throw new IOException(
                    "The SSE reconnect attempt failed.",
                    exception);
            }

            PipelineResponse response = message.ExtractResponse() ??
                throw new InvalidOperationException(
                    "The SSE reconnect attempt did not produce a response.");
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
                continue;
            }
            if (response.Status == 204)
            {
                response.Dispose();
                return null;
            }
            if (IsRetriableResponse(message, response))
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
            // spliced onto the events already delivered. Ending the stream
            // quietly would be indistinguishable from the 204 stop signal and
            // would present a truncated stream as a complete one, so surface
            // the protocol violation instead.
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

    private PipelineResponse FollowInitialRedirects(
        PipelineResponse response)
    {
        Uri requestUri = _uri;
        string method = _method;
        BinaryData? content = _content;
        bool dropContentHeaders = false;
        PipelineResponse current = response;

        for (int redirectCount = 0; ;)
        {
            if (redirectCount >= MaxRedirects)
            {
                current.Dispose();
                throw new InvalidOperationException(
                    $"The SSE request exceeded the maximum of {MaxRedirects} redirects.");
            }
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
            using PipelineMessage redirectMessage =
                CreateReconnectMessage(
                    requestUri,
                    method,
                    content,
                    dropContentHeaders,
                    _initialLastEventId,
                    _operationCancellationToken);
            _pipeline.Send(redirectMessage);
            current = redirectMessage.ExtractResponse() ??
                throw new InvalidOperationException(
                    "The SSE redirect request did not produce a response.");
            if (!IsRedirectStatus(current.Status))
            {
                return current;
            }
            redirectCount++;
        }
    }

    private async ValueTask<PipelineResponse>
        FollowInitialRedirectsAsync(PipelineResponse response)
    {
        Uri requestUri = _uri;
        string method = _method;
        BinaryData? content = _content;
        bool dropContentHeaders = false;
        PipelineResponse current = response;

        for (int redirectCount = 0; ;)
        {
            if (redirectCount >= MaxRedirects)
            {
                current.Dispose();
                throw new InvalidOperationException(
                    $"The SSE request exceeded the maximum of {MaxRedirects} redirects.");
            }
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
            using PipelineMessage redirectMessage =
                CreateReconnectMessage(
                    requestUri,
                    method,
                    content,
                    dropContentHeaders,
                    _initialLastEventId,
                    _operationCancellationToken);
            await _pipeline.SendAsync(
                redirectMessage).ConfigureAwait(false);
            current = redirectMessage.ExtractResponse() ??
                throw new InvalidOperationException(
                    "The SSE redirect request did not produce a response.");
            if (!IsRedirectStatus(current.Status))
            {
                return current;
            }
            redirectCount++;
        }
    }

    private PipelineMessage CreateReconnectMessage(
        Uri requestUri,
        string method,
        BinaryData? content,
        bool dropContentHeaders,
        string? lastEventId,
        CancellationToken cancellationToken)
    {
        PipelineMessage message = _pipeline.CreateMessage();
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
        message.SetProperty(typeof(SseReconnectRequest), true);
        message.BufferResponse = false;
        message.CancellationToken = cancellationToken;
        message.ResponseClassifier =
            new SseMessageClassifier(_classifier);
        message.Request.Uri = requestUri;
        message.Request.Method = method;
        foreach (KeyValuePair<string, string> header in _headers)
        {
            if (!dropContentHeaders ||
                !IsContentHeader(header.Key))
            {
                message.Request.Headers.Add(
                    header.Key,
                    header.Value);
            }
        }
        if (content is not null)
        {
            message.Request.Content = BinaryContent.Create(content);
        }
        if (!string.IsNullOrEmpty(lastEventId))
        {
            message.Request.Headers.Set(
                "Last-Event-ID",
                lastEventId!);
        }

        return message;
    }

    private void ApplyRedirect(
        SseRedirect redirect,
        ref Uri requestUri,
        ref string method,
        ref BinaryData? content,
        ref bool dropContentHeaders)
    {
        EnsureSameAuthority(redirect.Uri);
        requestUri = redirect.Uri;
        if (redirect.ForceGet)
        {
            method = "GET";
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
                    static header => IsContentHeader(header.Key));
            }
        }
    }

    private bool IsRetriable(
        PipelineMessage message,
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
                if (!IsRetriable(message, innerException))
                {
                    return false;
                }
            }
            return true;
        }

        return (_classifier.TryClassify(
                message,
                exception,
                out bool isRetriable) ||
            PipelineMessageClassifier.Default.TryClassify(
                message,
                exception,
                out isRetriable)) &&
            isRetriable;
    }

    private static string? GetContentType(PipelineResponse response)
        => response.Headers.TryGetValue(
            "Content-Type",
            out string? contentType)
                ? contentType
                : null;

    private static bool IsEventStreamResponse(PipelineResponse response)
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

    private bool IsRetriableResponse(
        PipelineMessage message,
        PipelineResponse response)
    {
        message.Response = response;
        bool classified =
            _classifier.TryClassify(
                message,
                exception: null,
                out bool isRetriable) ||
            PipelineMessageClassifier.Default.TryClassify(
                message,
                exception: null,
                out isRetriable);
        message.Response = null;
        return classified && isRetriable;
    }

    private static bool TryGetRedirect(
        PipelineResponse response,
        Uri requestUri,
        string requestMethod,
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
            300 or 301 or 302 =>
                requestMethod.Equals(
                    "POST",
                    StringComparison.OrdinalIgnoreCase),
            303 => !requestMethod.Equals(
                    "GET",
                    StringComparison.OrdinalIgnoreCase) &&
                !requestMethod.Equals(
                    "HEAD",
                    StringComparison.OrdinalIgnoreCase),
            _ => false
        };
        redirect = new SseRedirect(
            redirectUri,
            status is 301 or 308,
            forceGet);
        return true;
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

    private static bool IsRedirectStatus(int status)
        => status is 300 or 301 or 302 or 303 or 307 or 308;

    private static bool IsContentHeader(string name)
        => name.StartsWith(
                "Content-",
                StringComparison.OrdinalIgnoreCase) ||
            name.Equals(
                "Transfer-Encoding",
                StringComparison.OrdinalIgnoreCase);

    private static bool ContainsEventStream(string? accept)
    {
        if (accept is null)
        {
            return false;
        }

        foreach (string value in accept.Split(','))
        {
            string[] mediaRange = value.Split(';');
            if (!string.Equals(
                mediaRange[0].Trim(),
                "text/event-stream",
                StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // RFC 9110 section 12.4.2: a weight of zero means "not
            // acceptable". Accept is what opts a request into snapshotting
            // and reconnection, so a caller that explicitly rejects event
            // streams must not be opted in by the same token.
            if (!HasZeroWeight(mediaRange))
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasZeroWeight(string[] mediaRange)
    {
        for (int i = 1; i < mediaRange.Length; i++)
        {
            int separator = mediaRange[i].IndexOf('=');
            if (separator < 0)
            {
                continue;
            }

            if (!mediaRange[i].Substring(0, separator).Trim().Equals(
                "q",
                StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            // Only the first weight is a quality value; parameters after it
            // are accept extensions and do not affect acceptability.
            return double.TryParse(
                mediaRange[i].Substring(separator + 1).Trim(),
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out double quality) && quality <= 0;
        }

        return false;
    }

    private static InvalidOperationException
        DisposeAndCreateInvalidResponseException(PipelineResponse response)
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

    private sealed class SseMessageClassifier(
        PipelineMessageClassifier inner) : PipelineMessageClassifier
    {
        public override bool TryClassify(
            PipelineMessage message,
            out bool isError)
        {
            if (message.Response?.Status == 204 ||
                IsRedirectStatus(message.Response?.Status ?? 0))
            {
                isError = false;
                return true;
            }

            return inner.TryClassify(message, out isError);
        }

        public override bool TryClassify(
            PipelineMessage message,
            Exception? exception,
            out bool isRetriable)
            => inner.TryClassify(
                message,
                exception,
                out isRetriable);
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

    private sealed class SseReconnectRequest
    {
    }
}
