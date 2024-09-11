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
/// A <see cref="PipelinePolicy"/> used by a <see cref="ClientPipeline"/> to
/// log request and response information.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongSeconds = 3.0; // sec

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly string _clientAssembly = "System-ClientModel";
    private readonly LoggingHandler _handler;

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
        PipelineMessageSanitizer sanitizer = new(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());
        ILogger logger = loggingOptions.LoggerFactory.CreateLogger("System.ClientModel");
        _handler = new LoggingHandler(logger, sanitizer);
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (_handler.IsEnabled(LogLevel.Warning, EventLevel.Warning)) // Warning is the highest level logged
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

        _handler.LogRequest(request, requestId, _clientAssembly);

        byte[]? bytes = null;
        Encoding? requestTextEncoding = null;

        if (_logContent && request.Content != null && _handler.IsEnabled(LogLevel.Information, EventLevel.Informational))
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

            _handler.LogRequestContent(requestId, bytes, requestTextEncoding);
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
            _handler.LogExceptionResponse(requestId, ex);

            throw;
        }

        var after = Stopwatch.GetTimestamp();

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        if (response.IsError)
        {
            _handler.LogErrorResponse(requestId, response, elapsed);
        }
        else
        {
            _handler.LogResponse(requestId, response, elapsed);
        }

        if (_logContent && response.ContentStream != null && _handler.IsEnabled(LogLevel.Information, EventLevel.Informational))
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
                    _handler.LogErrorResponseContent(requestId, responseBytes, responseTextEncoding);
                }
                else
                {
                    _handler.LogResponseContent(requestId, responseBytes, responseTextEncoding);
                }
            }
            else
            {
                response.ContentStream = new LoggingStream(_handler, requestId, _maxLength, response.ContentStream, response.IsError, responseTextEncoding);
            }
        }

        if (elapsed > RequestTooLongSeconds)
        {
            _handler.LogResponseDelay(requestId, elapsed);
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
        private readonly LoggingHandler _handler;

        public LoggingStream(LoggingHandler handler, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _handler = handler;
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
                _handler.LogErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                _handler.LogResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
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
