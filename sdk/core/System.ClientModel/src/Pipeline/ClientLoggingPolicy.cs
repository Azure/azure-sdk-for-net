// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

/// <summary>
/// TODO.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongTime = 3.0; // sec
    private readonly ClientModelEventSource s_eventSource = ClientModelEventSource.Singleton("System.ClientModel");

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly string? _assemblyName;
    private readonly string? _clientRequestIdHeaderName;
    private readonly bool _isLoggingEnabled;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="isLoggingEnabled"></param>
    /// <param name="loggedHeaderNames"></param>
    /// <param name="loggedQueryParameters"></param>
    /// <param name="requestIdHeaderName"></param>
    /// <param name="logContent"></param>
    /// <param name="maxLength"></param>
    /// <param name="assemblyName"></param>
    public ClientLoggingPolicy(
        bool isLoggingEnabled = true,
        List<string>? loggedHeaderNames = default,
        List<string>? loggedQueryParameters = default,
        string? requestIdHeaderName = default,
        bool logContent = false,
        int maxLength = 4 * 1024,
        string? assemblyName = default)
    {
        LoggedHeaderNames = loggedHeaderNames ?? new List<string>();
        LoggedQueryParameters = loggedQueryParameters ?? new List<string>();
        _logContent = logContent;
        _maxLength = maxLength;
        _assemblyName = assemblyName;
        _clientRequestIdHeaderName = requestIdHeaderName;
        _isLoggingEnabled = isLoggingEnabled;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public static ClientLoggingPolicy Default { get; } = new ClientLoggingPolicy();

    /// <summary>
    /// TODO.
    /// </summary>
    public List<string> LoggedHeaderNames { get; internal set; }

    /// <summary>
    /// TODO.
    /// </summary>
    public List<string> LoggedQueryParameters { get; internal set; }

    /// <summary>
    /// TODO.
    /// </summary>
    internal PipelineMessageSanitizer? Sanitizer { get; set; }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (!_isLoggingEnabled)
        {
            ProcessNext(message, pipeline, currentIndex);
            return;
        }

        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();
    }

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        if (!_isLoggingEnabled)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
            return;
        }

        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);
    }

    internal virtual void LogRequest()
    {
        if (!s_eventSource.IsEnabled())
        {
            return;
        }
    }

    internal virtual void LogResponse()
    {
        if (!s_eventSource.IsEnabled())
        {
            return;
        }
    }

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        PipelineRequest request = message.Request;
        string requestId = string.IsNullOrEmpty(_clientRequestIdHeaderName) ? string.Empty : GetRequestIdFromHeaders(request.Headers, _clientRequestIdHeaderName!);

        s_eventSource.Request(request, requestId, _assemblyName, Sanitizer!);

        Encoding? requestTextEncoding = null;

        if (request.Headers.TryGetValue("Content-Type", out string? contentType))
        {
            ContentTypeUtilities.TryGetTextEncoding(contentType!, out requestTextEncoding);
        }

        var logWrapper = new ContentEventSourceWrapper(s_eventSource, _logContent, _maxLength, message.CancellationToken);

        await logWrapper.LogAsync(requestId, request.Content, requestTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);

        var before = Stopwatch.GetTimestamp();

        try
        {
            if (async)
            {
                await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline, currentIndex);
            }
        }
        catch (Exception ex)
        {
            s_eventSource.ExceptionResponse(requestId, ex.ToString());
            throw;
        }

        var after = Stopwatch.GetTimestamp();

        PipelineResponse response = message.Response!;
        bool isError = response.IsError;

        response.Headers.TryGetValue("Content-Type", out string? responseContentType);
        ContentTypeUtilities.TryGetTextEncoding(responseContentType!, out Encoding? responseTextEncoding);

        bool wrapResponseContent = !message.BufferResponse &&
                                   response.ContentStream != null &&
                                   response.ContentStream?.CanSeek == false &&
                                   logWrapper.IsEnabled(isError);

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        string responseId = string.IsNullOrEmpty(_clientRequestIdHeaderName) ? string.Empty : GetResponseIdFromHeaders(response.Headers);
        responseId = string.IsNullOrEmpty(responseId) ? requestId : responseId;

        if (isError)
        {
            s_eventSource.ErrorResponse(response, responseId, Sanitizer!, elapsed);
        }
        else
        {
            s_eventSource.Response(response, responseId, Sanitizer!, elapsed);
        }

        if (wrapResponseContent)
        {
            response.ContentStream = new LoggingStream(responseId, logWrapper, _maxLength, response.ContentStream!, isError, responseTextEncoding);
        }
        else
        {
            await logWrapper.LogAsync(responseId, isError, response.ContentStream, responseTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);
        }

        if (elapsed > RequestTooLongTime)
        {
            s_eventSource.ResponseDelay(responseId, elapsed);
        }
    }

    private string GetResponseIdFromHeaders(PipelineResponseHeaders keyValuePairs)
    {
        keyValuePairs.TryGetValue(_clientRequestIdHeaderName!, out var clientRequestId);
        return clientRequestId ?? string.Empty;
    }

    private string GetRequestIdFromHeaders(PipelineRequestHeaders keyValuePairs, string clientRequestIdHeaderName)
    {
        keyValuePairs.TryGetValue(clientRequestIdHeaderName, out var clientRequestId);
        return clientRequestId ?? string.Empty;
    }

    #region LoggingStream

    private class LoggingStream : Stream
    {
        private readonly string _requestId;

        private readonly ContentEventSourceWrapper _eventSourceWrapper;

        private int _maxLoggedBytes;

        private readonly Stream _originalStream;

        private readonly bool _error;

        private readonly Encoding? _textEncoding;

        private int _blockNumber;

        public LoggingStream(string requestId, ContentEventSourceWrapper eventSourceWrapper, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _eventSourceWrapper = eventSourceWrapper;
            _maxLoggedBytes = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _originalStream.Seek(offset, origin);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var result = _originalStream.Read(buffer, offset, count);

            var countToLog = result;
            DecrementLength(ref countToLog);
            LogBuffer(buffer, offset, countToLog);

            return result;
        }

        private void LogBuffer(byte[] buffer, int offset, int count)
        {
            if (count == 0)
            {
                return;
            }

            _eventSourceWrapper.Log(_requestId, _error, buffer, offset, count, _textEncoding, _blockNumber);

            _blockNumber++;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
            var result = await _originalStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets

            var countToLog = result;
            DecrementLength(ref countToLog);
            LogBuffer(buffer, offset, countToLog);

            return result;
        }

        public override bool CanRead => _originalStream.CanRead;
        public override bool CanSeek => _originalStream.CanSeek;
        public override long Length => _originalStream.Length;
        public override long Position
        {
            get => _originalStream.Position;
            set => _originalStream.Position = value;
        }

        public override void Close()
        {
            _originalStream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _originalStream.Dispose();
        }

        private void DecrementLength(ref int count)
        {
            var left = Math.Min(count, _maxLoggedBytes);
            count = left;
            _maxLoggedBytes -= count;
        }

        public override bool CanWrite => false;

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Flush()
        {
            // Flush is allowed on read-only stream
        }
    }
    #endregion

    #region ContentEventSourceWrapper

    private readonly struct ContentEventSourceWrapper
    {
        private const int CopyBufferSize = 8 * 1024;
        private readonly ClientModelEventSource? _eventSource;

        private readonly int _maxLength;

        private readonly CancellationToken _cancellationToken;

        public ContentEventSourceWrapper(ClientModelEventSource eventSource, bool logContent, int maxLength, CancellationToken cancellationToken)
        {
            _eventSource = logContent ? eventSource : null;
            _maxLength = maxLength;
            _cancellationToken = cancellationToken;
        }

        public async ValueTask LogAsync(string requestId, bool isError, Stream? stream, Encoding? textEncoding, bool async)
        {
            EventType eventType = ResponseOrError(isError);

            if (stream == null || !IsEnabled(eventType))
            {
                return;
            }

            var bytes = await FormatAsync(stream, async).ConfigureAwait(false).EnsureCompleted(async);
            Log(requestId, eventType, bytes, textEncoding);
        }

        public async ValueTask LogAsync(string requestId, BinaryContent? content, Encoding? textEncoding, bool async)
        {
            EventType eventType = EventType.Request;

            if (content == null || !IsEnabled(eventType))
            {
                return;
            }

            var bytes = await FormatAsync(content, async).ConfigureAwait(false).EnsureCompleted(async);

            Log(requestId, eventType, bytes, textEncoding);
        }

        public void Log(string requestId, bool isError, byte[] buffer, int offset, int length, Encoding? textEncoding, int? block = null)
        {
            EventType eventType = ResponseOrError(isError);

            if (buffer == null || !IsEnabled(eventType))
            {
                return;
            }

            var logLength = Math.Min(length, _maxLength);

            byte[] bytes;
            if (length == logLength && offset == 0)
            {
                bytes = buffer;
            }
            else
            {
                bytes = new byte[logLength];
                Array.Copy(buffer, offset, bytes, 0, logLength);
            }

            Log(requestId, eventType, bytes, textEncoding, block);
        }

        public bool IsEnabled(bool isError)
        {
            return IsEnabled(ResponseOrError(isError));
        }

        private bool IsEnabled(EventType errorResponse)
        {
            return _eventSource != null &&
                   (_eventSource.IsEnabled(EventLevel.Informational, EventKeywords.All) ||
                   (errorResponse == EventType.ErrorResponse && _eventSource.IsEnabled(EventLevel.Warning, EventKeywords.All)));
        }

        private async ValueTask<byte[]> FormatAsync(BinaryContent requestContent, bool async)
        {
            using var memoryStream = new MaxLengthStream(_maxLength);

            if (async)
            {
                await requestContent.WriteToAsync(memoryStream, _cancellationToken).ConfigureAwait(false);
            }
            else
            {
                requestContent.WriteTo(memoryStream, _cancellationToken);
            }

            return memoryStream.ToArray();
        }

        private async ValueTask<byte[]> FormatAsync(Stream content, bool async)
        {
            content.Seek(0, SeekOrigin.Begin);

            using var memoryStream = new MaxLengthStream(_maxLength);

            if (async)
            {
                await content.CopyToAsync(memoryStream, CopyBufferSize, _cancellationToken).ConfigureAwait(false);
            }
            else
            {
                content.CopyTo(memoryStream);
            }

            content.Seek(0, SeekOrigin.Begin);

            return memoryStream.ToArray();
        }

        private void Log(string requestId, EventType eventType, byte[] bytes, Encoding? textEncoding, int? block = null)
        {
            // We checked IsEnabled before we got here
            Debug.Assert(_eventSource != null);
            ClientModelEventSource azureCoreEventSource = _eventSource!;

            switch (eventType)
            {
                case EventType.Request:
                    azureCoreEventSource.RequestContent(requestId, bytes, textEncoding);
                    break;

                // Response
                case EventType.Response when block != null:
                    azureCoreEventSource.ResponseContentBlock(requestId, block.Value, bytes, textEncoding);
                    break;
                case EventType.Response:
                    azureCoreEventSource.ResponseContent(requestId, bytes, textEncoding);
                    break;

                // ResponseError
                case EventType.ErrorResponse when block != null:
                    azureCoreEventSource.ErrorResponseContentBlock(requestId, block.Value, bytes, textEncoding);
                    break;
                case EventType.ErrorResponse:
                    azureCoreEventSource.ErrorResponseContent(requestId, bytes, textEncoding);
                    break;
            }
        }

        private static EventType ResponseOrError(bool isError)
        {
            return isError ? EventType.ErrorResponse : EventType.Response;
        }

        private enum EventType
        {
            Request,
            Response,
            ErrorResponse
        }

        private class MaxLengthStream : MemoryStream
        {
            private int _bytesLeft;

            public MaxLengthStream(int maxLength) : base()
            {
                _bytesLeft = maxLength;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                DecrementLength(ref count);
                if (count > 0)
                {
                    base.Write(buffer, offset, count);
                }
            }

            public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                return count > 0 ? base.WriteAsync(buffer, offset, count, cancellationToken) : Task.CompletedTask;
            }

            private void DecrementLength(ref int count)
            {
                var left = Math.Min(count, _bytesLeft);
                count = left;

                _bytesLeft -= count;
            }
        }
    }
    #endregion
}
