// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Options;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Security.Cryptography;
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
    private const int DefaultLoggedContentSizeLimit = 4 * 1024;
    private static ClientModelEventSource? s_eventSource;
    private const string DefaultEventSourceName = "System.ClientModel";

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly string? _assemblyName;
    private readonly string? _clientRequestIdHeaderName;
    private readonly bool _isLoggingEnabled;

    internal static ClientModelEventSource Singleton { get => s_eventSource ??= ClientModelEventSource.Create(DefaultEventSourceName, Array.Empty<string>()); } //TODO add traits

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="eventSourceName"></param>
    /// <param name="eventSourceTraits"></param>
    /// <param name="options"></param>
    protected ClientLoggingPolicy(string? eventSourceName, string[]? eventSourceTraits = default, DiagnosticsOptions? options = default) : this(options)
    {
        if (s_eventSource != null && !string.IsNullOrEmpty(eventSourceName) && eventSourceName != s_eventSource.Name)
        {
            throw new ArgumentException("Cannot use multiple event source names in the same application.");
        }

        if (s_eventSource == null)
        {
            s_eventSource = ClientModelEventSource.Create(eventSourceName ?? DefaultEventSourceName, eventSourceTraits);
        }
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    public ClientLoggingPolicy(DiagnosticsOptions? options = default)
    {
        _logContent = options?.IsLoggingContentEnabled ?? false;
        _maxLength = options?.LoggedContentSizeLimit ?? DefaultLoggedContentSizeLimit;
        _assemblyName = options?.LoggedClientAssemblyName;
        _clientRequestIdHeaderName = options?.RequestIdHeaderName;
        _isLoggingEnabled = options?.IsLoggingEnabled ?? true;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    internal PipelineMessageSanitizer? Sanitizer { get; set; }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!_isLoggingEnabled || !Singleton.IsEnabled())
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
        string? requestId = GetRequestIdFromHeaders(request.Headers);

        LogRequest(request, requestId);
        await LogRequestContent(request, requestId, async, message.CancellationToken).ConfigureAwait(false);

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
            Singleton.ExceptionResponse(requestId ?? string.Empty, ex.ToString());
            throw;
        }

        var after = Stopwatch.GetTimestamp();

        // Log the response

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        string? responseId = GetResponseIdFromHeaders(response.Headers);
        responseId = string.IsNullOrEmpty(responseId) ? requestId : responseId; // Use the request ID if there was no response id

        LogResponse(response, responseId, elapsed);
        await LogResponseContent(response, responseId, message.BufferResponse, async, message.CancellationToken).ConfigureAwait(false);

        if (elapsed > RequestTooLongTime)
        {
            Singleton.ResponseDelay(responseId ?? string.Empty, elapsed);
        }
    }

    private void LogRequest(PipelineRequest request, string? requestId)
    {
        Singleton.Request(request, requestId ?? string.Empty, _assemblyName, Sanitizer!);
    }

    private async Task LogRequestContent(PipelineRequest request, string? requestId, bool async, CancellationToken cancellationToken)
    {
        // If logging content is disabled, or the request content is null, or informational logs are not enabled, return
        // Checking the log level prevents expensive operations from being executed
        if (!_logContent || request.Content == null || !Singleton.IsEnabled(EventLevel.Informational, EventKeywords.All))
        {
            return; // nothing to log
        }

        // Convert binary content to bytes
        using var memoryStream = new MaxLengthStream(_maxLength);
        if (async)
        {
            await request.Content.WriteToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            request.Content.WriteTo(memoryStream, cancellationToken);
        }
        var bytes = memoryStream.ToArray();

        // Try to extract a text encoding from the headers
        Encoding? requestTextEncoding = null;

        if (request.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
        {
            ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
        }

        // Log to event source
        Singleton.RequestContent(requestId ?? string.Empty, bytes, requestTextEncoding);
    }

    private void LogResponse(PipelineResponse response, string? responseId, double elapsed)
    {
        bool isError = response.IsError;
        if (isError)
        {
            Singleton.ErrorResponse(response, responseId ?? string.Empty, Sanitizer!, elapsed);
        }
        else
        {
            Singleton.Response(response, responseId ?? string.Empty, Sanitizer!, elapsed);
        }
    }

    private async Task LogResponseContent(PipelineResponse response, string? responseId, bool bufferResponse, bool async, CancellationToken cancellationToken)
    {
        // If logging content is disabled, or the request content is null, or informational logs are not enabled, return.
        // Checking the log level prevents expensive operations from being executed
        // TODO - consider moving this down to LoggingStream
        var logErrorResponseContent = response.IsError && Singleton.IsEnabled(EventLevel.Warning, EventKeywords.All);
        var logResponseContent = Singleton.IsEnabled(EventLevel.Informational, EventKeywords.All) || logErrorResponseContent;

        if (!_logContent || !logResponseContent)
        {
            return; // nothing to log
        }

        // Determine if the content stream should be wrapped in a logging stream, which logs the stream in blocks as it is being read
        var wrapContent =
            !bufferResponse // Content is not buffered - content should be in the content stream
            && response.ContentStream != null // Content stream is available
            && response.ContentStream?.CanSeek == false; // Content stream is not seekable - if it's seekable we can just log directly

        // Try to extract a text encoding from the headers
        Encoding? responseTextEncoding = null;

        if (response.Headers.TryGetValue("Content-Type", out var contentType) && contentType != null)
        {
            ContentTypeUtilities.TryGetTextEncoding(contentType, out responseTextEncoding);
        }

        if (wrapContent)
        {
            response.ContentStream = new LoggingStream(responseId ?? string.Empty, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding);
        }
        else
        {
            byte[]? bytes = null;
            if (bufferResponse)
            {
                // TODO - is this the best way to do this
                var allBytes = response.Content.ToArray();
                var length = Math.Min(allBytes.Length, _maxLength);
                bytes = new byte[length];
                Buffer.BlockCopy(allBytes, 0, bytes, 0, length);
            }
            else
            {
                if (response.ContentStream != null)
                {
                    using var memoryStream = new MaxLengthStream(_maxLength);
                    if (async)
                    {
                        await response.ContentStream.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        response.ContentStream.CopyTo(memoryStream);
                    }
                    response.ContentStream.Seek(0, SeekOrigin.Begin);

                    bytes = memoryStream.ToArray();
                }
            }

            if (response.IsError)
            {
                Singleton.ErrorResponseContent(responseId ?? string.Empty, bytes ?? Array.Empty<byte>(), responseTextEncoding);
            }
            else
            {
                Singleton.ResponseContent(responseId ?? string.Empty, bytes ?? Array.Empty<byte>(), responseTextEncoding);
            }
        }
    }

    private string? GetResponseIdFromHeaders(PipelineResponseHeaders keyValuePairs)
    {
        if (string.IsNullOrEmpty(_clientRequestIdHeaderName))
        {
            return null;
        }
        keyValuePairs.TryGetValue(_clientRequestIdHeaderName!, out var clientRequestId);
        return clientRequestId;
    }

    private string? GetRequestIdFromHeaders(PipelineRequestHeaders keyValuePairs)
    {
        if (string.IsNullOrEmpty(_clientRequestIdHeaderName))
        {
            return null;
        }
        keyValuePairs.TryGetValue(_clientRequestIdHeaderName!, out var clientRequestId);
        return clientRequestId;
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

        public LoggingStream(string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
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

        private void LogBuffer(byte[] buffer, int offset, int length)
        {
            if (length == 0 || buffer == null) // TODO - more checks needed
            {
                return;
            }

            //_eventSourceWrapper.Log(_requestId, _error, buffer, offset, count, _textEncoding, _blockNumber);
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
                // Array.Copy(buffer, offset, bytes, 0, logLength); TODO - will it break to use buffer. instead?
            }

            if (_error)
            {
                // TODO - store event source in LoggingStream? might need if I move above checks back
                Singleton.ErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                Singleton.ResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }

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
