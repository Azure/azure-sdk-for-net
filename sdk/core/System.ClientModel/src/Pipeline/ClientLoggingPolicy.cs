// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// TODO.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongTime = 3.0; // sec

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly ILogger _logger;
    private readonly string? _correlationIdHeaderName;
    private readonly string _clientAssembly = "System-ClientModel";

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    public ClientLoggingPolicy(LoggingOptions? options = default)
    {
        LoggingOptions loggingOptions = options ?? new LoggingOptions();
        _logContent = loggingOptions.IsLoggingContentEnabled;
        _maxLength = loggingOptions.LoggedContentSizeLimit;
        _sanitizer = new PipelineMessageSanitizer(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());
        _logger = loggingOptions.LoggerFactory.CreateLogger("System-ClientModel");
        _correlationIdHeaderName = loggingOptions.CorrelationIdHeaderName;
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bytes"></param>
    /// <param name="encoding"></param>
    protected virtual void OnSendingRequest(PipelineMessage message, byte[]? bytes, Encoding? encoding) { }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bytes"></param>
    /// <param name="encoding"></param>
    protected virtual ValueTask OnSendingRequestAsync(PipelineMessage message, byte[]? bytes, Encoding? encoding) => default;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="elapsed"></param>
    protected virtual void OnLogResponse(PipelineMessage message, double elapsed) { }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="elapsed"></param>
    protected virtual ValueTask OnLogResponseAsync(PipelineMessage message, double elapsed) => default;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bytes"></param>
    /// <param name="textEncoding"></param>
    /// <param name="block"></param>
    protected virtual void OnLogResponseContent(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block) { }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bytes"></param>
    /// <param name="textEncoding"></param>
    /// <param name="block"></param>
    /// <returns></returns>
    protected virtual ValueTask OnLogResponseContentAsync(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block) => default;

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        bool isLoggerEnabled = _logger.IsEnabled(LogLevel.Warning); // We only log warnings, information, and trace
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled();
        var isLoggingEnabled = isLoggerEnabled || isEventSourceEnabled;

        if (!isLoggingEnabled)
        {
            if (async)
            {
                await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline, currentIndex);
            }
            return;
        }

        // Log the request

        PipelineRequest request = message.Request;

        // If a request Id wasn't set, generate one so at least all the logs for this request and its corresponding response
        // can be correlated with each other.
        string requestId = GetCorrelationIdFromHeaders(request.Headers) ?? Guid.NewGuid().ToString();
        message.LoggingCorrelationId = requestId;

        LogRequest(requestId, request, message, async);

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
            ClientModelEventSource.Log.ExceptionResponse(requestId, ex.ToString());

            throw;
        }

        var after = Stopwatch.GetTimestamp();

        // Log the response

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        // Prefer the value from the service if one is provided
        string responseId = GetCorrelationIdFromHeaders(response.Headers) ?? requestId; // Use the request ID if there was no response id
        message.LoggingCorrelationId = responseId;

        LogResponse(_logger, response, responseId, elapsed);

        if (async)
        {
            await OnLogResponseAsync(message, elapsed).ConfigureAwait(false);
        }
        else
        {
            OnLogResponse(message, elapsed);
        }

        if (_logContent)
        {
            LogResponseContent(_logger, message, responseId, message.BufferResponse, async);
        }

        if (elapsed > RequestTooLongTime)
        {
            ClientModelEventSource.Log.ResponseDelay(responseId, elapsed);
        }
    }

    private bool IsLoggingEnabled(LogLevel logLevel, EventLevel eventLevel, EventKeywords keywords = EventKeywords.None)
    {
        return _logger.IsEnabled(logLevel) || ClientModelEventSource.Log.IsEnabled(eventLevel, keywords);
    }

    private async void LogRequest(string requestId, PipelineRequest request, PipelineMessage message, bool async)
    {
        // Log the request

        if (IsLoggingEnabled(LogLevel.Information, EventLevel.Informational))
        {
            ClientModelEventSource.Log.Request(requestId, request, _clientAssembly, _sanitizer);
        }

        // Log the request content

        byte[]? bytes = null;
        Encoding? encoding = null;

        if (_logContent && request.Content != null && IsLoggingEnabled(LogLevel.Information, EventLevel.Informational))
        {
            // Convert binary content to bytes
            using var memoryStream = new MaxLengthStream(_maxLength);

            if (async)
            {
                await request.Content.WriteToAsync(memoryStream, message.CancellationToken).ConfigureAwait(false);
            }
            else
            {
                request.Content.WriteTo(memoryStream, message.CancellationToken);
            }

            bytes = memoryStream.ToArray();

            // Try to extract a text encoding from the headers
            if (request.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out encoding);
            }

            ClientModelEventSource.Log.RequestContent(requestId, bytes, encoding);
        }

        if (async)
        {
            await OnSendingRequestAsync(message, bytes, encoding).ConfigureAwait(false);
        }
        else
        {
            OnSendingRequest(message, bytes, encoding);
        }
    }

    private void LogResponse(ILogger logger, PipelineResponse response, string responseId, double elapsed)
    {
        bool isEnabled = response.IsError ?
            IsLoggingEnabled(LogLevel.Warning, EventLevel.Warning)
            : IsLoggingEnabled(LogLevel.Information, EventLevel.Informational);

        if (!isEnabled)
        {
            return;
        }

        if (response.IsError)
        {
            ClientModelEventSource.Log.ErrorResponse(responseId, response, _sanitizer, elapsed);
        }
        else
        {
            ClientModelEventSource.Log.Response(responseId, response, _sanitizer, elapsed);
        }
    }

    private async void LogResponseContent(ILogger logger, PipelineMessage message, string responseId, bool contentBuffered, bool async)
    {
        PipelineResponse response = message.Response!;

        if (response.ContentStream == null || !IsLoggingEnabled(LogLevel.Information, EventLevel.Informational))
        {
            return;
        }

        // Try to extract a text encoding from the headers
        Encoding? responseTextEncoding = null;

        if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
        {
            ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
        }

        if (contentBuffered)
        {
            // Content is buffered, so log the first _maxLength bytes
            ReadOnlyMemory<byte> contentAsMemory = response.Content.ToMemory();
            var length = Math.Min(contentAsMemory.Length, _maxLength);
            byte[] bytes = contentAsMemory.Span.Slice(0, length).ToArray();

            if (response.IsError)
            {
                ClientModelEventSource.Log.ErrorResponseContent(responseId, bytes, responseTextEncoding);
            }
            else
            {
                ClientModelEventSource.Log.ResponseContent(responseId, bytes, responseTextEncoding);
            }

            if (async)
            {
                await OnLogResponseContentAsync(message, bytes, responseTextEncoding, null).ConfigureAwait(false);
            }
            else
            {
                OnLogResponseContent(message, bytes, responseTextEncoding, null);
            }

            return;
        }

        // We check content stream is not null above
        if (response.ContentStream.CanSeek)
        {
            byte[] bytes = new byte[_maxLength];
            response.ContentStream.Read(bytes, 0, _maxLength);
            response.ContentStream.Seek(0, SeekOrigin.Begin);

            if (response.IsError)
            {
                ClientModelEventSource.Log.ErrorResponseContent(responseId, bytes, responseTextEncoding);
            }
            else
            {
                ClientModelEventSource.Log.ResponseContent(responseId, bytes, responseTextEncoding);
            }

            if (async)
            {
                await OnLogResponseContentAsync(message, bytes, responseTextEncoding, null).ConfigureAwait(false);
            }
            else
            {
                OnLogResponseContent(message, bytes, responseTextEncoding, null);
            }

            return;
        }

        response.ContentStream = new LoggingStream(this, logger, responseId, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding, message);
    }

    #region Formatting Helpers
    private string? GetCorrelationIdFromHeaders(PipelineRequestHeaders keyValuePairs)
    {
        if (_correlationIdHeaderName == null)
        {
            return null;
        }
        keyValuePairs.TryGetValue(_correlationIdHeaderName, out var clientRequestId);
        return clientRequestId;
    }

    private string? GetCorrelationIdFromHeaders(PipelineResponseHeaders keyValuePairs)
    {
        if (_correlationIdHeaderName == null)
        {
            return null;
        }
        keyValuePairs.TryGetValue(_correlationIdHeaderName, out var clientRequestId);
        return clientRequestId;
    }

    #endregion

    #region MaxLengthStream
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
    #endregion

    #region LoggingStream
    private class LoggingStream : Stream
    {
        private readonly string _requestId;
        private int _maxLoggedBytes;
        private int _originalMaxLength;
        private readonly Stream _originalStream;
        private readonly bool _error;
        private readonly Encoding? _textEncoding;
        private int _blockNumber;
        private readonly ILogger _logger;
        private readonly PipelineMessage _message;
        private readonly ClientLoggingPolicy _policy;

        public LoggingStream(ClientLoggingPolicy policy, ILogger logger, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding, PipelineMessage message)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _logger = logger;
            _message = message;
            _policy = policy;
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
            LogBuffer(buffer, offset, countToLog, false);

            return result;
        }

        private async void LogBuffer(byte[] buffer, int offset, int length, bool async)
        {
            if (length == 0 || buffer == null)
            {
                return;
            }

            var logLength = Math.Min(length, _originalMaxLength);

            byte[] bytes;
            if (length == logLength && offset == 0)
            {
                bytes = buffer;
            }
            else
            {
                bytes = new byte[logLength];
                Buffer.BlockCopy(buffer, offset, bytes, 0, logLength);
            }

            if (_error)
            {
                ClientModelEventSource.Log.ErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                ClientModelEventSource.Log.ResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }

            if (async)
            {
                await _policy.OnLogResponseContentAsync(_message, bytes, _textEncoding, _blockNumber).ConfigureAwait(false);
            }
            else
            {
                _policy.OnLogResponseContent(_message, bytes, _textEncoding, _blockNumber);
            }

            _blockNumber++;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in netstandard2.0
            var result = await _originalStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in netstandard2.0

            var countToLog = result;
            DecrementLength(ref countToLog);
            LogBuffer(buffer, offset, countToLog, true);

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

        // Make this stream readonly
        public override bool CanWrite => false;

        // Make this stream readonly
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("This stream is read-only.");
        }

        // Make this stream readonly
        public override void SetLength(long value)
        {
            throw new NotSupportedException("This stream is read-only.");
        }

        public override void Flush()
        {
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
    }
    #endregion
}
