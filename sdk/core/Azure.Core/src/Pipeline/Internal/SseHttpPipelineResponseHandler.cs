// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal sealed class SseHttpPipelineResponseHandler : IDisposable
    {
        private const int MaxRedirects = 50;
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

            BinaryData? content = null;
            if (message.Request.Content != null)
            {
                using var buffer = new MemoryStream();
                RequestContent originalContent =
                    message.Request.Content;
                originalContent.WriteTo(
                    buffer,
                    message.CancellationToken);
                content = BinaryData.FromBytes(buffer.ToArray());
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

        public Response WrapInitialResponse(Response response)
        {
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

            Stream initialStream = response.ContentStream ??
                throw DisposeAndCreateInvalidResponseException(response);
            response.ContentStream = new SseReconnectingStream(
                initialStream,
                ReconnectAsync,
                _operationCancellationToken,
                reconnectOwner: this,
                initialLastEventId: _initialLastEventId);
            return response;
        }

        private async ValueTask<SseReconnectResult?>
            ReconnectAsync(
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
                SseSendResult result = await SendAsync(
                    requestUri,
                    method,
                    content,
                    dropContentHeaders,
                    lastEventId,
                    classifyResponse: true,
                    cancellationToken).ConfigureAwait(false);
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
                _classifier.IsRetriable(message, exception);

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
                foreach (string part in value.Split(','))
                {
                    string mediaType = part.Split(';')[0].Trim();
                    if (string.Equals(
                        mediaType,
                        "text/event-stream",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
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
