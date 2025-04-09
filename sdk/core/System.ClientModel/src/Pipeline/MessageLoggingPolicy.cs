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

    private readonly ClientLoggingOptions _loggingOptions;
    private PipelineMessageLogger? _messageLogger;
    private readonly string _clientAssembly = typeof(MessageLoggingPolicy).Assembly.GetName().Name!;

    private bool _enableMessageContentLogging => _loggingOptions.EnableMessageContentLogging ?? ClientLoggingOptions.DefaultEnableMessageContentLogging;
    private int _maxLength => _loggingOptions.MessageContentSizeLimit ?? ClientLoggingOptions.DefaultMessageContentSizeLimitBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="MessageLoggingPolicy"/> class.
    /// </summary>
    /// <param name="options">The user-provided logging options object.</param>
    public MessageLoggingPolicy(ClientLoggingOptions? options = default)
    {
        _loggingOptions = options ?? new();
    }

    /// <inheritdoc/>
    public sealed override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public sealed override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        _messageLogger ??= new PipelineMessageLogger(_loggingOptions.GetPipelineMessageSanitizer(), _loggingOptions.LoggerFactory);

        // EventLevel.Warning / LogLevel.Warning is the highest level logged by this policy.
        // PipelineMessageLogger.IsEnabled checks to see: if an ILogger was provided - ensure it is enabled for at least LogLevel.Warning OR if
        // an ILogger was not provided, see if an EventListener exists that is actively listening for at least EventLevel.Warning.
        // If nothing is listening for logs then this policy immediately passes control to the next policy in the pipeline and returns when control
        // is passed back. This avoids any performance hit from logging when no one is listening/collecting logs.
        if (!_messageLogger.IsEnabled(LogLevel.Warning, EventLevel.Warning))
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

        string requestId = message.Request.ClientRequestId ?? string.Empty;

        _messageLogger.LogRequest(requestId, request, _clientAssembly);

        if (_enableMessageContentLogging && request.Content != null && _messageLogger.IsEnabled(LogLevel.Debug, EventLevel.Verbose))
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

            Encoding? requestTextEncoding = null;
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
                    using var memoryStream = new MaxLengthStream(_maxLength);
                    if (async)
                    {
                        await response.ContentStream.CopyToAsync(memoryStream).ConfigureAwait(false);
                    }
                    else
                    {
                        response.ContentStream.CopyTo(memoryStream);
                    }
                    responseBytes = memoryStream.ToArray();
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
        private int _remainingBytesToLog;
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
            _remainingBytesToLog = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _messageLogger = messageLogger;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var numBytesRead = _originalStream.Read(buffer, offset, count);

            LogBuffer(buffer, offset, numBytesRead);

            return numBytesRead;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var numBytesRead = await _originalStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);

            LogBuffer(buffer, offset, numBytesRead);

            return numBytesRead;
        }

#if !NETSTANDARD2_0

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            var numBytesRead = await _originalStream.ReadAsync(buffer, cancellationToken).ConfigureAwait(false);

            LogMemory(buffer, numBytesRead);

            return numBytesRead;
        }
#endif

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

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("This stream does not support seek operations.");
        }

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
            _originalStream.Flush();
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

        #region Helpers

        private void LogMemory(Memory<byte> memory, int numBytesReadIntoMemory)
        {
            // This is intentionally not thread-safe because synchronizing reads
            // should be done by the caller.
            var bytesToLog = Math.Min(numBytesReadIntoMemory, _remainingBytesToLog);
            _remainingBytesToLog -= bytesToLog;

            if (bytesToLog == 0)
            {
                return;
            }

            byte[] bytes = new byte[bytesToLog];
            memory.Slice(0, bytesToLog).Span.CopyTo(bytes);

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

        private void LogBuffer(byte[] buffer, int offset, int numBytesReadIntoBuffer)
        {
            // This is intentionally not thread-safe because synchronizing reads
            // should be done by the caller.
            var bytesToLog = Math.Min(numBytesReadIntoBuffer, _remainingBytesToLog);
            _remainingBytesToLog -= bytesToLog;

            if (bytesToLog == 0 || buffer == null)
            {
                return;
            }

            byte[] bytes;
            if (bytesToLog == numBytesReadIntoBuffer && offset == 0)
            {
                bytes = buffer;
            }
            else
            {
                bytes = new byte[bytesToLog];
                Buffer.BlockCopy(buffer, offset, bytes, 0, bytesToLog);
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
        #endregion
    }
    #endregion
}
