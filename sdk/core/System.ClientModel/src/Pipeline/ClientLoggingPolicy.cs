// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace System.ClientModel.Primitives;

/// <summary>
/// TODO.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongTime = 3.0; // sec
    private const string DefaultEventSourceName = "System.ClientModel";

    private static readonly ConcurrentDictionary<string, ClientModelEventSource> s_singletonEventSources = new();

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly string? _assemblyName;
    private readonly string? _clientRequestIdHeaderName;
    private readonly bool _isLoggingEnabled;
    private readonly PipelineMessageSanitizer _sanitizer;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="logName"></param>
    /// <param name="logTraits"></param>
    /// <param name="options"></param>
    protected ClientLoggingPolicy(string logName, string[]? logTraits = default, LoggingOptions? options = default)
    {
        LoggingOptions loggingOptions = options ?? new LoggingOptions();
        _logContent = loggingOptions.IsLoggingContentEnabled;
        _maxLength = loggingOptions.LoggedContentSizeLimit;
        _assemblyName = loggingOptions.LoggedClientAssemblyName;
        _clientRequestIdHeaderName = loggingOptions.RequestIdHeaderName;
        _isLoggingEnabled = loggingOptions.IsLoggingEnabled;
        _sanitizer = new PipelineMessageSanitizer(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());

        string logNameToUse = logName ?? DefaultEventSourceName;
        EventSourceSingleton = s_singletonEventSources.GetOrAdd(logNameToUse, _ => ClientModelEventSource.Create(logNameToUse, logTraits));
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    public ClientLoggingPolicy(LoggingOptions? options = default) : this(DefaultEventSourceName, null, options)
    {
    }

    /// <summary>
    /// TODO
    /// </summary>
    internal ClientModelEventSource EventSourceSingleton { get; }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!_isLoggingEnabled || !EventSourceSingleton.IsEnabled())
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
        string requestId = GetRequestIdFromHeaders(request.Headers) ?? Guid.NewGuid().ToString();

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
            EventSourceSingleton.ExceptionResponse(requestId, ex.ToString());
            throw;
        }

        var after = Stopwatch.GetTimestamp();

        // Log the response

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        string responseId = GetResponseIdFromHeaders(response.Headers) ?? requestId; // Use the request ID if there was no response id

        LogResponse(response, responseId, elapsed);
        await LogResponseContent(response, responseId, message.BufferResponse, async, message.CancellationToken).ConfigureAwait(false);

        if (elapsed > RequestTooLongTime)
        {
            EventSourceSingleton.ResponseDelay(responseId, elapsed);
        }
    }

    private void LogRequest(PipelineRequest request, string? requestId)
    {
        EventSourceSingleton.Request(request, requestId, _assemblyName, _sanitizer);
    }

    private async Task LogRequestContent(PipelineRequest request, string? requestId, bool async, CancellationToken cancellationToken)
    {
        if (!_logContent || request.Content == null || !EventSourceSingleton.IsEnabled(EventLevel.Informational, EventKeywords.All))
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
        EventSourceSingleton.RequestContent(requestId, bytes, requestTextEncoding);
    }

    private void LogResponse(PipelineResponse response, string? responseId, double elapsed)
    {
        bool isError = response.IsError;
        if (isError)
        {
            EventSourceSingleton.ErrorResponse(response, responseId, _sanitizer, elapsed);
        }
        else
        {
            EventSourceSingleton.Response(response, responseId, _sanitizer, elapsed);
        }
    }

    private async Task LogResponseContent(PipelineResponse response, string? responseId, bool contentBuffered, bool async, CancellationToken cancellationToken)
    {
        var logErrorResponseContent = response.IsError && EventSourceSingleton.IsEnabled(EventLevel.Warning, EventKeywords.All);
        var logResponseContent = EventSourceSingleton.IsEnabled(EventLevel.Informational, EventKeywords.All) || logErrorResponseContent;

        if (!_logContent || !logResponseContent || response.ContentStream == null)
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

            LogFormattedResponseContent(response.IsError, responseId, bytes, responseTextEncoding);

            return;
        }

        // We check content stream is not null above
        if (response.ContentStream!.CanSeek)
        {
            using var memoryStream = new MaxLengthStream(_maxLength);
            if (async)
            {
                await response.ContentStream!.CopyToAsync(memoryStream, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                response.ContentStream!.CopyTo(memoryStream, cancellationToken);
            }
            response.ContentStream.Seek(0, SeekOrigin.Begin);

            byte[] bytes = memoryStream.ToArray();

            LogFormattedResponseContent(response.IsError, responseId, bytes, responseTextEncoding);

            return;
        }

        response.ContentStream = new LoggingStream(EventSourceSingleton, responseId, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding);
    }

    private void LogFormattedResponseContent(bool isError, string? clientId, byte[] bytes, Encoding? encoding)
    {
        if (isError)
        {
            EventSourceSingleton.ErrorResponseContent(clientId, bytes, encoding);
        }
        else
        {
            EventSourceSingleton.ResponseContent(clientId, bytes, encoding);
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
        private readonly string? _requestId;
        private int _maxLoggedBytes;
        private int _originalMaxLength;
        private readonly Stream _originalStream;
        private readonly bool _error;
        private readonly Encoding? _textEncoding;
        private int _blockNumber;
        private readonly ClientModelEventSource _eventSource;

        public LoggingStream(ClientModelEventSource eventSource, string? requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
        {
            // Should only wrap non-seekable streams
            Debug.Assert(!originalStream.CanSeek);
            _requestId = requestId;
            _maxLoggedBytes = maxLoggedBytes;
            _originalMaxLength = maxLoggedBytes;
            _originalStream = originalStream;
            _error = error;
            _textEncoding = textEncoding;
            _eventSource = eventSource;
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
                _eventSource.ErrorResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
            }
            else
            {
                _eventSource.ResponseContentBlock(_requestId, _blockNumber, bytes, _textEncoding);
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
