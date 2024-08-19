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
    private readonly string _clientAssembly = "System-ClientModel";
    private readonly ILogger _logger;
    private readonly ClientModelLogMessages _logMessages;

    /// <summary>
    /// Creates a new instance of the <see cref="ClientLoggingPolicy"/> class.
    /// </summary>
    /// <param name="clientAssembly">The assembly name to include with each entry.</param>
    /// <param name="options">The user-provided logging options object.</param>
    protected ClientLoggingPolicy(string clientAssembly, LoggingOptions? options = default) : this(options)
    {
        _clientAssembly = clientAssembly;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ClientLoggingPolicy"/> class.
    /// </summary>
    /// <param name="options">The user-provided logging options object.</param>
    public ClientLoggingPolicy(LoggingOptions? options = default)
    {
        LoggingOptions loggingOptions = options ?? new LoggingOptions();
        _logContent = loggingOptions.IsLoggingContentEnabled;
        _maxLength = loggingOptions.LoggedContentSizeLimit;
        _logger = loggingOptions.LoggerFactory.CreateLogger("System-ClientModel");
        PipelineMessageSanitizer sanitizer = new(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());
        _logMessages = new ClientModelLogMessages(_logger, sanitizer);
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!_logger.IsEnabled(LogLevel.Warning)) // The highest LogLevel we log with is LogLevel.Warning
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

        string requestId = Guid.NewGuid().ToString();
        message.LoggingCorrelationId = requestId;

        _logMessages.Request(requestId, request);

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
            byte[] bytes = memoryStream.ToArray();

            // Try to extract a text encoding from the headers
            Encoding? requestTextEncoding = null;
            if (request.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
            }

            _logMessages.RequestContent(requestId, bytes, requestTextEncoding);
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
            _logMessages.ExceptionResponse(requestId, ex);

            throw;
        }

        var after = Stopwatch.GetTimestamp();

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        if (response.IsError)
        {
            _logMessages.ErrorResponse(requestId, response, elapsed);
        }
        else
        {
            _logMessages.Response(requestId, response, elapsed);
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
                    _logMessages.ErrorResponseContent(requestId, responseBytes, responseTextEncoding);
                }
                else
                {
                    _logMessages.ResponseContent(requestId, responseBytes, responseTextEncoding);
                }
            }
            else
            {
                response.ContentStream = new LoggingStream(this, _logMessages, requestId, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding, message);
            }
        }

        if (elapsed > RequestTooLongSeconds)
        {
            _logMessages.ResponseDelay(requestId, elapsed);
        }
    }

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
        private readonly ClientModelLogMessages _logMessages;
        private readonly PipelineMessage _message;
        private readonly ClientLoggingPolicy _policy;

        public LoggingStream(ClientLoggingPolicy policy, ClientModelLogMessages logMessages, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding, PipelineMessage message)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _logMessages = logMessages;
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
            LogBuffer(buffer, offset, countToLog);

            return result;
        }

        private void LogBuffer(byte[] buffer, int offset, int length)
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
                _logMessages.ErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                _logMessages.ResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
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
