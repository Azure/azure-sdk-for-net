// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> used by a <see cref="ClientPipeline"/> to
/// log request and response information.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongSeconds = 3.0; // sec

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly string? _correlationIdHeaderName;
    private readonly string _clientAssembly = "System-ClientModel";
    private readonly bool _alwaysLog = false;

    /// <summary>
    /// Creates a new instance of the <see cref="ClientLoggingPolicy"/> class.
    /// </summary>
    /// <param name="clientAssembly">The assembly name to include with each entry.</param>
    /// <param name="alwaysLog">Always process a request/response for logging even if there are no "System-ClientModel" event listeners or a provided ILogger.
    /// This ensures the virtual methods <see cref="OnSendingRequest(PipelineMessage, byte[], Encoding?)"/> and <see cref="OnLogResponse(PipelineMessage, double)"/>
    /// or <see cref="OnSendingRequestAsync(PipelineMessage, byte[], Encoding?)"/> and <see cref="OnLogResponseAsync(PipelineMessage, double)"/> are always called.
    /// It also ensures <see cref="OnLogResponseContent(PipelineMessage, byte[], Encoding?, int?)"/>
    /// or <see cref="OnLogResponseContentAsync(PipelineMessage, byte[], Encoding?, int?)"/> is called if <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c>.</param>
    /// <param name="options">The user-provided logging options object.</param>
    protected ClientLoggingPolicy(string clientAssembly, bool alwaysLog, LoggingOptions? options = default) : this(options)
    {
        _clientAssembly = clientAssembly;
        _alwaysLog = alwaysLog;
    }

    internal readonly ILogger Logger;

    /// <summary>
    /// Creates a new instance of the <see cref="ClientLoggingPolicy"/> class.
    /// </summary>
    /// <param name="options">The user-provided logging options object.</param>
    public ClientLoggingPolicy(LoggingOptions? options = default)
    {
        LoggingOptions loggingOptions = options ?? new LoggingOptions();
        _logContent = loggingOptions.IsLoggingContentEnabled;
        _maxLength = loggingOptions.LoggedContentSizeLimit;
        _sanitizer = new PipelineMessageSanitizer(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());
        Logger = loggingOptions.LoggerFactory.CreateLogger("System-ClientModel");
        _correlationIdHeaderName = loggingOptions.CorrelationIdHeaderName;
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!(_alwaysLog || ClientModelEventSource.Log.IsEnabled() || Logger.IsEnabled(LogLevel.Warning))) // The highest LogLevel we log with is LogLevel.Warning
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

        PipelineRequest request = message.Request;

        // If a request Id wasn't set, generate one
        string requestId = GetCorrelationIdFromHeaders(request.Headers) ?? Guid.NewGuid().ToString();
        message.LoggingCorrelationId = requestId;

        LoggingHandler.LogRequest(Logger, request, requestId, _clientAssembly, _sanitizer);

        byte[]? bytes = null;
        Encoding? requestTextEncoding = null;

        // If logging content is enabled we should always process the content for OnSendingRequest/Async, we
        // shouldn't check the LogLevel/EventLevel here
        if (_logContent && request.Content != null)
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
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
            }

            LoggingHandler.LogRequestContent(Logger, requestId, bytes, requestTextEncoding);
        }

        if (async)
        {
            await OnSendingRequestAsync(message, bytes, requestTextEncoding).ConfigureAwait(false);
        }
        else
        {
            OnSendingRequest(message, bytes, requestTextEncoding);
        }

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
            LoggingHandler.LogExceptionResponse(Logger, requestId, ex);

            throw;
        }

        var after = Stopwatch.GetTimestamp();

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        // Prefer the value from the service if one is provided
        string responseId = GetCorrelationIdFromHeaders(response.Headers) ?? requestId; // Use the request ID if there was no response id
        message.LoggingCorrelationId = responseId;

        if (response.IsError)
        {
            LoggingHandler.LogErrorResponse(Logger, responseId, response, elapsed, _sanitizer);
        }
        else
        {
            LoggingHandler.LogResponse(Logger, responseId, response, elapsed, _sanitizer);
        }

        if (async)
        {
            await OnLogResponseAsync(message, elapsed).ConfigureAwait(false);
        }
        else
        {
            OnLogResponse(message, elapsed);
        }

        if (_logContent && response.ContentStream != null)
        {
            Encoding? responseTextEncoding = null;

            if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
            }

            if (message.BufferResponse || response.ContentStream.CanSeek)
            {
                byte[]? responseBytes = null;
                if (message.BufferResponse)
                {
                    // Content is buffered, so log the first _maxLength bytes
                    ReadOnlyMemory<byte> contentAsMemory = response.Content.ToMemory();
                    var length = Math.Min(contentAsMemory.Length, _maxLength);
                    responseBytes = contentAsMemory.Span.Slice(0, length).ToArray();
                }
                else
                {
                    responseBytes = new byte[_maxLength];
                    response.ContentStream.Read(responseBytes, 0, _maxLength);
                    response.ContentStream.Seek(0, SeekOrigin.Begin);
                }

                if (response.IsError)
                {
                    LoggingHandler.LogErrorResponseContent(Logger, responseId, responseBytes, responseTextEncoding);
                }
                else
                {
                    LoggingHandler.LogResponseContent(Logger, responseId, responseBytes, responseTextEncoding);
                }

                if (async)
                {
                    await OnLogResponseContentAsync(message, responseBytes, responseTextEncoding, null).ConfigureAwait(false);
                }
                else
                {
                    OnLogResponseContent(message, responseBytes, responseTextEncoding, null);
                }
            }
            else
            {
                response.ContentStream = new LoggingStream(this, Logger, responseId, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding, message);
            }
        }

        if (elapsed > RequestTooLongSeconds)
        {
            LoggingHandler.LogResponseDelay(Logger, responseId, elapsed);
        }
    }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// prior to passing control to the next policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineRequest"/> to be sent to the service.</param>
    /// <param name="bytes">The content of the request in bytes if
    /// <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c> and the
    /// request content is not <c>null</c>, <c>null</c> otherwise.</param>
    /// <param name="encoding">The text encoding of the request content if the content is
    /// text and <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c>,
    /// <c>null</c> otherwise.</param>
    protected virtual void OnSendingRequest(PipelineMessage message, byte[]? bytes, Encoding? encoding) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="ProcessAsync(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// prior to passing control to the next policy in the pipeline.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineRequest"/> to be sent to the service.</param>
    /// <param name="bytes">The content of the request in bytes if
    /// <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c> and the
    /// request content is not <c>null</c>, <c>null</c> otherwise.</param>
    /// <param name="encoding">The text encoding of the request content if the content is
    /// text and <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c>,
    /// <c>null</c> otherwise.</param>
    protected virtual ValueTask OnSendingRequestAsync(PipelineMessage message, byte[]? bytes, Encoding? encoding) => default;

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has returned from the previous policy in the pipeline, and the response
    /// has been logged.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    /// <param name="secondsElapsed">The number of seconds between sending the request and
    /// receiving a response.</param>
    protected virtual void OnLogResponse(PipelineMessage message, double secondsElapsed) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="ProcessAsync(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has returned from the previous policy in the pipeline, and the response
    /// has been logged.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    /// <param name="secondsElapsed">The number of seconds between sending the request and
    /// receiving a response.</param>
    protected virtual ValueTask OnLogResponseAsync(PipelineMessage message, double secondsElapsed) => default;

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has returned from the previous policy in the pipeline, and the
    /// response content has been logged.
    /// </summary>
    /// <remarks>
    /// This method will only be called if
    /// <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c>.
    /// </remarks>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    /// <param name="bytes">The content of the response in bytes. If the response content
    /// is <c>null</c>, then this value is <c>null</c>.</param>
    /// <param name="textEncoding">The text encoding of the response content if the content is
    /// text, <c>null</c> otherwise.</param>
    /// <param name="block">The block number of the content when the content is logged in
    /// blocks, otherwise <c>null</c>.</param>
    protected virtual void OnLogResponseContent(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block) { }

    /// <summary>
    /// A method that can be overridden by derived types to extend the default
    /// <see cref="ClientLoggingPolicy"/> logic. It is called from
    /// <see cref="Process(PipelineMessage, IReadOnlyList{PipelinePolicy}, int)"/>
    /// after control has returned from the previous policy in the pipeline, and the
    /// response content has been logged.
    /// </summary>
    /// <remarks>
    /// This method will only be called if
    /// <see cref="LoggingOptions.IsLoggingContentEnabled"/> is <c>true</c>.
    /// </remarks>
    /// <param name="message">The <see cref="PipelineMessage"/> containing the
    /// <see cref="PipelineResponse"/> that was received from the service.</param>
    /// <param name="bytes">The content of the response in bytes. If the response content
    /// is <c>null</c>, then this value is <c>null</c>.</param>
    /// <param name="textEncoding">The text encoding of the response content if the content is
    /// text, <c>null</c> otherwise.</param>
    /// <param name="block">The block number of the content when the content is logged in
    /// blocks, otherwise <c>null</c>.</param>
    protected virtual ValueTask OnLogResponseContentAsync(PipelineMessage message, byte[] bytes, Encoding? textEncoding, int? block) => default;

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
                LoggingHandler.LogErrorResponseContentBlock(_logger, _requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                LoggingHandler.LogResponseContentBlock(_logger, _requestId, _blockNumber, bytes, _textEncoding);
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
