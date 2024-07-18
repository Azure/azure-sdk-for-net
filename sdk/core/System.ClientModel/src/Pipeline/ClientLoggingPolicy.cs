// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
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
    /// <param name="clientAssembly"></param>
    /// <param name="options"></param>
    protected ClientLoggingPolicy(string clientAssembly, LoggingOptions? options = default) : this(options)
    {
        _clientAssembly = clientAssembly;
    }

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

    internal string? GetCorrelationIdFromHeaders(PipelineRequestHeaders keyValuePairs)
    {
        if (_correlationIdHeaderName == null)
        {
            return null;
        }
        keyValuePairs.TryGetValue(_correlationIdHeaderName, out var clientRequestId);
        return clientRequestId;
    }

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

        LogRequest(_logger, request, requestId);

        if (_logContent)
        {
            await LogRequestContent(message, _logger, request, requestId, async, message.CancellationToken).ConfigureAwait(false);
        }
        else
        {
            // OnSendingRequest is called in LogRequestContent if content logging is enabled
            if (async)
            {
                await OnSendingRequestAsync(message, null, null).ConfigureAwait(false);
            }
            else
            {
                OnSendingRequest(message, null, null);
            }
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
            ClientModelLogMessages.ExceptionResponse(_logger, requestId, ex.ToString());
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
            ClientModelLogMessages.ResponseDelay(_logger, responseId, elapsed);
            ClientModelEventSource.Log.ResponseDelay(responseId, elapsed);
        }
    }

    private void LogRequest(ILogger logger, PipelineRequest request, string requestId)
    {
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);

        if (!isLoggerEnabled && !isEventSourceEnabled)
        {
            return;
        }

        string uri = _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri);
        string headers = FormatHeaders(request.Headers, _sanitizer);

        ClientModelLogMessages.Request(logger, requestId, request.Method, uri, headers, _clientAssembly);
        ClientModelEventSource.Log.Request(requestId, request.Method, uri, headers, _clientAssembly);
    }

    private async Task LogRequestContent(PipelineMessage message, ILogger logger, PipelineRequest request, string requestId, bool async, CancellationToken cancellationToken)
    {
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);

        if (request.Content == null || !(isLoggerEnabled || isEventSourceEnabled))
        {
            return;
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

        // Log text event
        if (requestTextEncoding != null)
        {
            string content = requestTextEncoding.GetString(bytes);
            ClientModelEventSource.Log.RequestContentText(requestId, content);
            ClientModelLogMessages.RequestContentText(logger, requestId, content);
        }
        else // Log bytes
        {
            ClientModelEventSource.Log.RequestContent(requestId, bytes);
            ClientModelLogMessages.RequestContent(logger, requestId, bytes);
        }

        if (async)
        {
            await OnSendingRequestAsync(message, bytes, requestTextEncoding).ConfigureAwait(false);
        }
        else
        {
            OnSendingRequest(message, bytes, requestTextEncoding);
        }
    }

    private void LogResponse(ILogger logger, PipelineResponse response, string responseId, double elapsed)
    {
        bool isEnabled = response.IsError
            ? (logger.IsEnabled(LogLevel.Warning) || ClientModelEventSource.Log.IsEnabled(EventLevel.Warning, EventKeywords.None))
            : (logger.IsEnabled(LogLevel.Information) || ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None));

        if (!isEnabled)
        {
            return;
        }

        string headers = FormatHeaders(response.Headers, _sanitizer);

        if (response.IsError)
        {
            ClientModelLogMessages.ErrorResponse(logger, responseId, response.Status, response.ReasonPhrase, headers, elapsed);
            ClientModelEventSource.Log.ErrorResponse(responseId, response.Status, response.ReasonPhrase, headers, elapsed);
        }
        else
        {
            ClientModelLogMessages.Response(logger, responseId, response.Status, response.ReasonPhrase, headers, elapsed);
            ClientModelEventSource.Log.Response(responseId, response.Status, response.ReasonPhrase, headers, elapsed);
        }
    }

    private async void LogResponseContent(ILogger logger, PipelineMessage message, string responseId, bool contentBuffered, bool async)
    {
        PipelineResponse response = message.Response!;
        bool isLoggerEnabled = logger.IsEnabled(LogLevel.Information);
        bool isEventSourceEnabled = ClientModelEventSource.Log.IsEnabled(EventLevel.Informational, EventKeywords.None);

        if (response.ContentStream == null || !(isLoggerEnabled || isEventSourceEnabled))
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

            LogFormattedResponseContent(logger, response.IsError, responseId, bytes, responseTextEncoding);

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

            LogFormattedResponseContent(logger, response.IsError, responseId, bytes, responseTextEncoding);

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

    private static void LogFormattedResponseContent(ILogger logger, bool isError, string responseId, byte[] bytes, Encoding? encoding)
    {
        switch (isError, encoding)
        {
            case (true, null):
                ClientModelLogMessages.ErrorResponseContent(logger, responseId, bytes);
                ClientModelEventSource.Log.ErrorResponseContent(responseId, bytes);
                break;
            case (true, not null):
                string encodedErrorContent = encoding.GetString(bytes);
                ClientModelLogMessages.ErrorResponseContentText(logger, responseId, encodedErrorContent);
                ClientModelEventSource.Log.ErrorResponseContentText(responseId, encodedErrorContent);
                break;
            case (false, null):
                ClientModelLogMessages.ResponseContent(logger, responseId, bytes);
                ClientModelEventSource.Log.ResponseContent(responseId, bytes);
                break;
            case (false, not null):
                string encodedContent = encoding.GetString(bytes);
                ClientModelLogMessages.ResponseContentText(logger, responseId, encoding.GetString(bytes));
                ClientModelEventSource.Log.ResponseContentText(responseId, encodedContent);
                break;
        }
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

    private static string FormatHeaders(IEnumerable<KeyValuePair<string, string>> headers, PipelineMessageSanitizer sanitizer)
    {
        var stringBuilder = new StringBuilder();
        foreach (var header in headers)
        {
            stringBuilder.Append(header.Key);
            stringBuilder.Append(':');
            stringBuilder.Append(sanitizer.SanitizeHeader(header.Key, header.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
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

            switch (_error, _textEncoding)
            {
                case (true, null):
                    ClientModelLogMessages.ErrorResponseContentBlock(_logger, _requestId, _blockNumber, bytes);
                    ClientModelEventSource.Log.ErrorResponseContentBlock(_requestId, _blockNumber, bytes);
                    break;
                case (true, not null):
                    ClientModelLogMessages.ErrorResponseContentTextBlock(_logger, _requestId, _blockNumber, _textEncoding.GetString(bytes));
                    ClientModelEventSource.Log.ErrorResponseContentTextBlock(_requestId, _blockNumber, _textEncoding.GetString(bytes));
                    break;
                case (false, null):
                    ClientModelLogMessages.ResponseContentBlock(_logger, _requestId, _blockNumber, bytes);
                    ClientModelEventSource.Log.ResponseContentBlock(_requestId, _blockNumber, bytes);
                    break;
                case (false, not null):
                    ClientModelLogMessages.ResponseContentTextBlock(_logger, _requestId, _blockNumber, _textEncoding.GetString(bytes));
                    ClientModelEventSource.Log.ResponseContentTextBlock(_requestId, _blockNumber, _textEncoding.GetString(bytes));
                    break;
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
