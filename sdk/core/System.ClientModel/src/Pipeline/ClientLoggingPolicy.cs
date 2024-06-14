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
/// TODO.
/// </summary>
public class ClientLoggingPolicy : PipelinePolicy
{
    private const double RequestTooLongTime = 3.0; // sec

    private readonly bool _logContent;
    private readonly int _maxLength;
    private readonly string? _assemblyName;
    private readonly string? _clientRequestIdHeaderName;
    private readonly bool _isLoggingEnabled;
    private readonly PipelineMessageSanitizer _sanitizer;
    private readonly ILogger? _logger;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="options"></param>
    public ClientLoggingPolicy(LoggingOptions? options = default)
    {
        LoggingOptions loggingOptions = options ?? new LoggingOptions();
        _logContent = loggingOptions.IsLoggingContentEnabled;
        _maxLength = loggingOptions.LoggedContentSizeLimit;
        _assemblyName = loggingOptions.LoggedClientAssemblyName;
        _clientRequestIdHeaderName = loggingOptions.RequestIdHeaderName;
        _isLoggingEnabled = loggingOptions.IsLoggingEnabled;
        _sanitizer = new PipelineMessageSanitizer(loggingOptions.AllowedQueryParameters.ToArray(), loggingOptions.AllowedHeaderNames.ToArray());
        _logger = loggingOptions.LoggerFactory?.CreateLogger("System-ClientModel"); // TODO name conventions?
    }

    /// <inheritdoc/>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        ProcessSyncOrAsync(message, pipeline, currentIndex, async: false).EnsureCompleted();

    /// <inheritdoc/>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex) =>
        await ProcessSyncOrAsync(message, pipeline, currentIndex, async: true).ConfigureAwait(false);

    private async ValueTask ProcessSyncOrAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool async)
    {
        if (!_isLoggingEnabled || _logger == null)
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

        LogRequest(_logger, request, requestId);
        if (_logContent)
        {
            await LogRequestContent(_logger, request, requestId, async, message.CancellationToken).ConfigureAwait(false);
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
            throw;
        }

        var after = Stopwatch.GetTimestamp();

        // Log the response

        PipelineResponse response = message.Response!;

        double elapsed = (after - before) / (double)Stopwatch.Frequency;

        string responseId = GetResponseIdFromHeaders(response.Headers) ?? requestId; // Use the request ID if there was no response id

        LogResponse(_logger, response, responseId, elapsed);
        if (_logContent)
        {
            LogResponseContent(_logger, response, responseId, message.BufferResponse);
        }

        if (elapsed > RequestTooLongTime)
        {
            ClientModelLogMessages.ResponseDelay(_logger, responseId, elapsed);
        }
    }

    internal string? GetRequestIdFromHeaders(PipelineRequestHeaders keyValuePairs)
    {
        if (string.IsNullOrEmpty(_clientRequestIdHeaderName))
        {
            return null;
        }
        keyValuePairs.TryGetValue(_clientRequestIdHeaderName!, out var clientRequestId);
        return clientRequestId;
    }

    private void LogRequest(ILogger logger, PipelineRequest request, string requestId)
    {
        if (!logger.IsEnabled(LogLevel.Information))
        {
            return;
        }

        string uri = _sanitizer.SanitizeUrl(request.Uri!.AbsoluteUri);
        string headers = FormatHeaders(request.Headers, _sanitizer);
        ClientModelLogMessages.Request(logger, requestId, request.Method, uri, headers, _assemblyName);
    }

    private async Task LogRequestContent(ILogger logger, PipelineRequest request, string requestId, bool async, CancellationToken cancellationToken)
    {
        if (!logger.IsEnabled(LogLevel.Information) || request.Content == null)
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
            ClientModelLogMessages.RequestContentText(logger, requestId, content);
        }
        else // Log bytes
        {
            ClientModelLogMessages.RequestContent(logger, requestId, bytes);
        }
    }

    private void LogResponse(ILogger logger, PipelineResponse response, string responseId, double elapsed)
    {
        bool isEnabled = response.IsError ? logger.IsEnabled(LogLevel.Warning) : logger.IsEnabled(LogLevel.Information);
        if (!isEnabled)
        {
            return;
        }

        string headers = FormatHeaders(response.Headers, _sanitizer);

        if (response.IsError)
        {
            ClientModelLogMessages.ErrorResponse(logger, responseId, response.Status, response.ReasonPhrase, elapsed, headers);
        }
        else
        {
            ClientModelLogMessages.Response(logger, responseId, response.Status, response.ReasonPhrase, elapsed, headers);
        }
    }

    private void LogResponseContent(ILogger logger, PipelineResponse response, string responseId, bool contentBuffered)
    {
        if (!logger.IsEnabled(LogLevel.Information) || response.ContentStream == null)
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

            return;
        }

        // We check content stream is not null above
        if (response.ContentStream.CanSeek)
        {
            byte[] bytes = new byte[_maxLength];
            response.ContentStream.Read(bytes, 0, _maxLength);
            response.ContentStream.Seek(0, SeekOrigin.Begin);

            LogFormattedResponseContent(logger, response.IsError, responseId, bytes, responseTextEncoding);

            return;
        }

        response.ContentStream = new LoggingStream(logger, responseId, _maxLength, response.ContentStream!, response.IsError, responseTextEncoding);
    }

    private static void LogFormattedResponseContent(ILogger logger, bool isError, string responseId, byte[] bytes, Encoding? encoding)
    {
        switch (isError, encoding)
        {
            case (true, null):
                ClientModelLogMessages.ErrorResponseContent(logger, responseId, bytes);
                break;
            case (true, not null):
                ClientModelLogMessages.ErrorResponseContentText(logger, responseId, encoding.GetString(bytes));
                break;
            case (false, null):
                ClientModelLogMessages.ResponseContent(logger, responseId, bytes);
                break;
            case (false, not null):
                ClientModelLogMessages.ResponseContentText(logger, responseId, encoding.GetString(bytes));
                break;
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

        public LoggingStream(ILogger logger, string requestId, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
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

            switch (_error, _textEncoding)
            {
                case (true, null):
                    ClientModelLogMessages.ErrorResponseContentBlock(_logger, _requestId, _blockNumber, bytes);
                    break;
                case (true, not null):
                    ClientModelLogMessages.ErrorResponseContentTextBlock(_logger, _requestId, _blockNumber, _textEncoding.GetString(bytes));
                    break;
                case (false, null):
                    ClientModelLogMessages.ResponseContentBlock(_logger, _requestId, _blockNumber, bytes);
                    break;
                case (false, not null):
                    ClientModelLogMessages.ResponseContentTextBlock(_logger, _requestId, _blockNumber, _textEncoding.GetString(bytes));
                    break;
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
