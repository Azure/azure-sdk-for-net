// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline
{
    internal class LoggingPolicy : HttpPipelinePolicy
    {
        public LoggingPolicy(bool logContent, int maxLength, string[] allowedHeaderNames, string[] allowedQueryParameters, string? assemblyName)
        {
            _sanitizer = new HttpMessageSanitizer(allowedQueryParameters, allowedHeaderNames);
            _logContent = logContent;
            _maxLength = maxLength;
            _assemblyName = assemblyName;
        }

        private const double RequestTooLongTime = 3.0; // sec

        private static readonly AzureCoreEventSource s_eventSource = AzureCoreEventSource.Singleton;

        private readonly bool _logContent;
        private readonly int _maxLength;
        private HttpMessageSanitizer _sanitizer;
        private readonly string? _assemblyName;

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, pipeline, true).ConfigureAwait(false);
        }

        private async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
        {
            if (!s_eventSource.IsEnabled())
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
                return;
            }

            Request request = message.Request;

            s_eventSource.Request(request.ClientRequestId, request.Method.ToString(), FormatUri(request.Uri), FormatHeaders(request.Headers), _assemblyName);

            Encoding? requestTextEncoding = null;

            if (request.TryGetHeader(HttpHeader.Names.ContentType, out var contentType))
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
            }

            var logWrapper = new ContentEventSourceWrapper(s_eventSource, _logContent, _maxLength, message.CancellationToken);

            await logWrapper.LogAsync(request.ClientRequestId, request.Content, requestTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);

            var before = Stopwatch.GetTimestamp();

            try
            {
                if (async)
                {
                    await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
                }
                else
                {
                    ProcessNext(message, pipeline);
                }
            }
            catch (Exception ex)
            {
                s_eventSource.ExceptionResponse(request.ClientRequestId, ex.ToString());
                throw;
            }

            var after = Stopwatch.GetTimestamp();

            bool isError = message.ResponseClassifier.IsErrorResponse(message);

            Response response = message.Response;
            ContentTypeUtilities.TryGetTextEncoding(response.Headers.ContentType, out Encoding? responseTextEncoding);

            bool wrapResponseContent = response.ContentStream != null &&
                                       response.ContentStream?.CanSeek == false &&
                                       logWrapper.IsEnabled(isError);

            double elapsed = (after - before) / (double)Stopwatch.Frequency;

            if (isError)
            {
                s_eventSource.ErrorResponse(response.ClientRequestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), elapsed);
            }
            else
            {
                s_eventSource.Response(response.ClientRequestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers), elapsed);
            }

            if (wrapResponseContent)
            {
                response.ContentStream = new LoggingStream(response.ClientRequestId, logWrapper, _maxLength, response.ContentStream!, isError, responseTextEncoding);
            }
            else
            {
                await logWrapper.LogAsync(response.ClientRequestId, isError, response.ContentStream, responseTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);
            }

            if (elapsed > RequestTooLongTime)
            {
                s_eventSource.ResponseDelay(response.ClientRequestId, elapsed);
            }
        }

        private string FormatUri(RequestUriBuilder requestUri)
        {
            return _sanitizer.SanitizeUrl(requestUri.ToString());
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
        }

        private string FormatHeaders(IEnumerable<HttpHeader> headers)
        {
            var stringBuilder = new StringBuilder();
            foreach (HttpHeader header in headers)
            {
                stringBuilder.Append(header.Name);
                stringBuilder.Append(':');
                string newValue = _sanitizer.SanitizeHeader(header.Name, header.Value);
                stringBuilder.AppendLine(newValue);
            }
            return stringBuilder.ToString();
        }

        private class LoggingStream : ReadOnlyStream
        {
            private readonly string _requestId;

            private readonly ContentEventSourceWrapper _eventSourceWrapper;

            private int _maxLoggedBytes;

            private readonly Stream _originalStream;

            private readonly bool _error;

            private readonly Encoding? _textEncoding;

            private int _blockNumber;

            public LoggingStream(string requestId, ContentEventSourceWrapper eventSourceWrapper, int maxLoggedBytes, Stream originalStream, bool error, Encoding? textEncoding)
            {
                // Should only wrap non-seekable streams
                Debug.Assert(!originalStream.CanSeek);
                _requestId = requestId;
                _eventSourceWrapper = eventSourceWrapper;
                _maxLoggedBytes = maxLoggedBytes;
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

            private void LogBuffer(byte[] buffer, int offset, int count)
            {
                if (count == 0)
                {
                    return;
                }

                _eventSourceWrapper.Log(_requestId, _error, buffer, offset, count, _textEncoding, _blockNumber);

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

        private readonly struct ContentEventSourceWrapper
        {
            private const int CopyBufferSize = 8 * 1024;
            private readonly AzureCoreEventSource? _eventSource;

            private readonly int _maxLength;

            private readonly CancellationToken _cancellationToken;

            public ContentEventSourceWrapper(AzureCoreEventSource eventSource, bool logContent, int maxLength, CancellationToken cancellationToken)
            {
                _eventSource = logContent ? eventSource : null;
                _maxLength = maxLength;
                _cancellationToken = cancellationToken;
            }

            public async ValueTask LogAsync(string requestId, bool isError, Stream? stream, Encoding? textEncoding, bool async)
            {
                EventType eventType = ResponseOrError(isError);

                if (stream == null || !IsEnabled(eventType))
                {
                    return;
                }

                var bytes = await FormatAsync(stream, async).ConfigureAwait(false).EnsureCompleted(async);
                Log(requestId, eventType, bytes, textEncoding);
            }

            public async ValueTask LogAsync(string requestId, RequestContent? content, Encoding? textEncoding, bool async)
            {
                EventType eventType = EventType.Request;

                if (content == null || !IsEnabled(eventType))
                {
                    return;
                }

                var bytes = await FormatAsync(content, async).ConfigureAwait(false).EnsureCompleted(async);

                Log(requestId, eventType, bytes, textEncoding);
            }

            public void Log(string requestId, bool isError, byte[] buffer, int offset, int length, Encoding? textEncoding, int? block = null)
            {
                EventType eventType = ResponseOrError(isError);

                if (buffer == null || !IsEnabled(eventType))
                {
                    return;
                }

                var logLength = Math.Min(length, _maxLength);

                byte[] bytes;
                if (length == logLength && offset == 0)
                {
                    bytes = buffer;
                }
                else
                {
                    bytes = new byte[logLength];
                    Array.Copy(buffer, offset, bytes, 0, logLength);
                }

                Log(requestId, eventType, bytes, textEncoding, block);
            }

            public bool IsEnabled(bool isError)
            {
                return IsEnabled(ResponseOrError(isError));
            }

            private bool IsEnabled(EventType errorResponse)
            {
                return _eventSource != null &&
                       (_eventSource.IsEnabled(EventLevel.Informational, EventKeywords.All) ||
                       (errorResponse == EventType.ErrorResponse && _eventSource.IsEnabled(EventLevel.Warning, EventKeywords.All)));
            }

            private async ValueTask<byte[]> FormatAsync(RequestContent requestContent, bool async)
            {
                using var memoryStream = new MaxLengthStream(_maxLength);

                if (async)
                {
                    await requestContent.WriteToAsync(memoryStream, _cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    requestContent.WriteTo(memoryStream, _cancellationToken);
                }

                return memoryStream.ToArray();
            }

            private async ValueTask<byte[]> FormatAsync(Stream content, bool async)
            {
                using var memoryStream = new MaxLengthStream(_maxLength);

                if (async)
                {
                    await content.CopyToAsync(memoryStream, CopyBufferSize, _cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    content.CopyTo(memoryStream);
                }

                content.Seek(0, SeekOrigin.Begin);

                return memoryStream.ToArray();
            }

            private void Log(string requestId, EventType eventType, byte[] bytes, Encoding? textEncoding, int? block = null)
            {
                string? stringValue = textEncoding?.GetString(bytes);

                // We checked IsEnabled before we got here
                Debug.Assert(_eventSource != null);
                AzureCoreEventSource azureCoreEventSource = _eventSource!;

                switch (eventType)
                {
                    case EventType.Request when stringValue != null:
                        azureCoreEventSource.RequestContentText(requestId, stringValue);
                        break;
                    case EventType.Request:
                        azureCoreEventSource.RequestContent(requestId, bytes);
                        break;

                    // Response
                    case EventType.Response when block != null && stringValue != null:
                        azureCoreEventSource.ResponseContentTextBlock(requestId, block.Value, stringValue);
                        break;
                    case EventType.Response when block != null:
                        azureCoreEventSource.ResponseContentBlock(requestId, block.Value, bytes);
                        break;
                    case EventType.Response when stringValue != null:
                        azureCoreEventSource.ResponseContentText(requestId, stringValue);
                        break;
                    case EventType.Response:
                        azureCoreEventSource.ResponseContent(requestId, bytes);
                        break;

                    // ResponseError
                    case EventType.ErrorResponse when block != null && stringValue != null:
                        azureCoreEventSource.ErrorResponseContentTextBlock(requestId, block.Value, stringValue);
                        break;
                    case EventType.ErrorResponse when block != null:
                        azureCoreEventSource.ErrorResponseContentBlock(requestId, block.Value, bytes);
                        break;
                    case EventType.ErrorResponse when stringValue != null:
                        azureCoreEventSource.ErrorResponseContentText(requestId, stringValue);
                        break;
                    case EventType.ErrorResponse:
                        azureCoreEventSource.ErrorResponseContent(requestId, bytes);
                        break;
                }
            }

            private static EventType ResponseOrError(bool isError)
            {
                return isError ? EventType.ErrorResponse : EventType.Response;
            }

            private enum EventType
            {
                Request,
                Response,
                ErrorResponse
            }

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
        }
    }
}
