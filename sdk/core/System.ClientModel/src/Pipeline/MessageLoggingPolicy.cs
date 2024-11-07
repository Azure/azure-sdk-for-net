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
using Microsoft.Extensions.Logging;

namespace System.ClientModel.Primitives;

/// <summary>
/// A <see cref="PipelinePolicy"/> used by a <see cref="ClientPipeline"/> to
/// log request and response information.
/// </summary>
public class MessageLoggingPolicy : PipelinePolicy
{
    /// <summary>
    /// The <see cref="ClientRetryPolicy"/> instance used by a default
    /// <see cref="ClientPipeline"/>.
    /// </summary>
    public static MessageLoggingPolicy Default { get; } = new MessageLoggingPolicy();

    private readonly bool _enableMessageContentLogging;
    private readonly int _maxLength;
    private readonly PipelineMessageLogger _messageLogger;
    private readonly string _clientAssembly = typeof(MessageLoggingPolicy).Assembly.GetName().Name!;

    /// <summary>
    /// Creates a new instance of the <see cref="MessageLoggingPolicy"/> class.
    /// </summary>
    /// <param name="options">The user-provided logging options object.</param>
    public MessageLoggingPolicy(ClientLoggingOptions? options = default)
    {
        _enableMessageContentLogging = options?.EnableMessageContentLogging ?? ClientLoggingOptions.DefaultEnableMessageContentLogging;
        _maxLength = options?.MessageContentSizeLimit ?? ClientLoggingOptions.DefaultMessageContentSizeLimit;

        PipelineMessageSanitizer sanitizer = options?.GetPipelineMessageSanitizer() ?? ClientLoggingOptions.DefaultSanitizer;

        _messageLogger = new PipelineMessageLogger(sanitizer, options?.LoggerFactory);
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!_messageLogger.IsEnabled(LogLevel.Warning, EventLevel.Warning)) // Warning is the highest level logged
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

        string requestId = Guid.NewGuid().ToString(); // TODO where should this be set?
        message.Request.ClientRequestId = requestId;

        _messageLogger.LogRequest(requestId, request, _clientAssembly);

        byte[]? bytes = null;
        Encoding? requestTextEncoding = null;

        if (_enableMessageContentLogging && request.Content != null && _messageLogger.IsEnabled(LogLevel.Information, EventLevel.Informational))
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

            _messageLogger.LogRequestContent(requestId, bytes, requestTextEncoding);
        }

        var before = Stopwatch.GetTimestamp();

        // Any exceptions thrown are logged in the transport

        if (async)
        {
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
        else
        {
            ProcessNext(message, pipeline, currentIndex);
        }

        var after = Stopwatch.GetTimestamp();

        PipelineResponse response = message.Response!;
        response.ClientRequestId = requestId;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        if (response.IsError)
        {
            _messageLogger.LogErrorResponse(requestId, response, elapsed);
        }
        else
        {
            _messageLogger.LogResponse(requestId, response, elapsed);
        }

        if (_enableMessageContentLogging && response.ContentStream != null && _messageLogger.IsEnabled(LogLevel.Information, EventLevel.Informational))
        {
            Encoding? responseTextEncoding = null;

            if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
            }

            if (message.BufferResponse || response.ContentStream.CanSeek)
            {
                byte[]? responseBytes;
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
                    _messageLogger.LogErrorResponseContent(requestId, responseBytes, responseTextEncoding);
                }
                else
                {
                    _messageLogger.LogResponseContent(requestId, responseBytes, responseTextEncoding);
                }
            }
            else
            {
                response.ContentStream = new LoggingStream(_messageLogger, requestId, _maxLength, response.ContentStream, response.IsError, responseTextEncoding);
            }
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
        private readonly int _originalMaxLength;
        private readonly Stream _originalStream;
        private readonly bool _error;
        private readonly Encoding? _textEncoding;
        private int _blockNumber;
        private readonly PipelineMessageLogger _messageLogger;

        public LoggingStream(PipelineMessageLogger messageLogger, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _messageLogger = messageLogger;
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

        private void LogBuffer(byte[] buffer, int offset, int length, bool async)
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
                _messageLogger.LogErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                _messageLogger.LogResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
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
