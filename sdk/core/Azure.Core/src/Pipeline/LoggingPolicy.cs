// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Http;

namespace Azure.Core.Pipeline
{
    internal class LoggingPolicy : HttpPipelinePolicy
    {
        public LoggingPolicy(bool logContent, int maxLength)
        {
            _logContent = logContent;
            _maxLength = maxLength;
        }

        private const long DelayWarningThreshold = 3000; // 3000ms
        private static readonly AzureCoreEventSource s_eventSource = AzureCoreEventSource.Singleton;

        private readonly bool _logContent;
        private readonly int _maxLength;

        public override async ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, pipeline, true).ConfigureAwait(false);
        }

        private async ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
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

            s_eventSource.Request(message.Request);

            Encoding? requestTextEncoding = null;

            if (message.Request.TryGetHeader(HttpHeader.Names.ContentType, out var contentType))
            {
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);
            }

            var logWrapper = new ContentEventSourceWrapper(s_eventSource, _logContent, _maxLength, message.CancellationToken);

            await logWrapper.LogAsync(message.Request.ClientRequestId, message.Request.Content, requestTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);

            var before = Stopwatch.GetTimestamp();

            if (async)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
            else
            {
                ProcessNext(message, pipeline);
            }

            var after = Stopwatch.GetTimestamp();

            bool isError = message.ResponseClassifier.IsErrorResponse(message);

            ContentTypeUtilities.TryGetTextEncoding(message.Response.Headers.ContentType, out Encoding? responseTextEncoding);

            bool wrapResponseContent = message.Response.ContentStream != null &&
                                       message.Response.ContentStream.CanSeek == false &&
                                       logWrapper.IsEnabled(isError);

            if (isError)
            {
                s_eventSource.ErrorResponse(message.Response);
            }
            else
            {
                s_eventSource.Response(message.Response);
            }

            if (wrapResponseContent)
            {
                message.Response.ContentStream = new LoggingStream(message.Response.ClientRequestId, logWrapper, _maxLength, message.Response.ContentStream!, isError, responseTextEncoding);
            }
            else
            {
                await logWrapper.LogAsync(message.Response.ClientRequestId, isError, message.Response.ContentStream, responseTextEncoding, async).ConfigureAwait(false).EnsureCompleted(async);
            }

            var elapsedMilliseconds = (after - before) * 1000 / Stopwatch.Frequency;
            if (elapsedMilliseconds > DelayWarningThreshold)
            {
                s_eventSource.ResponseDelay(message.Response, elapsedMilliseconds);
            }
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, pipeline, false).EnsureCompleted();
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
                var result = await _originalStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);

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

            public async ValueTask LogAsync(string requestId, HttpPipelineRequestContent? content, Encoding? textEncoding, bool async)
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

            private async ValueTask<byte[]> FormatAsync(HttpPipelineRequestContent requestContent, bool async)
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
