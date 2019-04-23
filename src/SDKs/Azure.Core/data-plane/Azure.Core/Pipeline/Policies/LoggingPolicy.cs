// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Core.Pipeline.Policies
{
    public class LoggingPolicy : HttpPipelinePolicy
    {
        private static readonly long s_delayWarningThreshold = 3000; // 3000ms
        private static readonly long s_frequency = Stopwatch.Frequency;
        private static readonly HttpPipelineEventSource s_eventSource = HttpPipelineEventSource.Singleton;

        private int[] _excludeErrors = Array.Empty<int>();

        public static readonly LoggingPolicy Shared = new LoggingPolicy();

        public LoggingPolicy(params int[] excludeErrors)
            => _excludeErrors = excludeErrors;

        // TODO (pri 1): we should remove sensitive information, e.g. keys
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!s_eventSource.IsEnabled())
            {
                await ProcessNextAsync(pipeline, message);
                return;
            }

            s_eventSource.Request(message.Request);

            Encoding requestTextEncoding = null;
            if (message.Request.TryGetHeader(HttpHeader.Names.ContentType, out var contentType) && IsTextContentType(contentType))
            {
                requestTextEncoding = Encoding.UTF8;
            }

            if (message.Request.Content != null)
            {
                if (requestTextEncoding != null)
                {
                    await s_eventSource.RequestContentTextAsync(message.Request, requestTextEncoding, message.Cancellation);
                }
                else
                {
                    await s_eventSource.RequestContentAsync(message.Request, message.Cancellation);
                }
            }

            var before = Stopwatch.GetTimestamp();
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            var after = Stopwatch.GetTimestamp();

            bool isError = message.ResponseClassifier.IsErrorResponse(message.Response);

            Encoding responseTextEncoding = null;
            if (message.Response.TryGetHeader(HttpHeader.Names.ContentType, out contentType) && IsTextContentType(contentType))
            {
                responseTextEncoding = Encoding.UTF8;
            }

            bool wrapResponseStream = s_eventSource.ShouldLogContent(isError) && message.Response.ResponseContentStream?.CanSeek == false;

            if (wrapResponseStream)
            {
                message.Response.ResponseContentStream = new LoggingStream(message.Response.RequestId, s_eventSource, message.Response.ResponseContentStream, isError, responseTextEncoding);
            }

            if (isError)
            {
                s_eventSource.ErrorResponse(message.Response);

                if (!wrapResponseStream && message.Response.ResponseContentStream != null)
                {
                    if (responseTextEncoding != null)
                    {
                        await s_eventSource.ErrorResponseContentTextAsync(message.Response, responseTextEncoding, message.Cancellation).ConfigureAwait(false);
                    }
                    else
                    {
                        await s_eventSource.ErrorResponseContentAsync(message.Response, message.Cancellation).ConfigureAwait(false);
                    }
                }
            }

            s_eventSource.Response(message.Response);

            if (!wrapResponseStream && message.Response.ResponseContentStream != null)
            {
                if (responseTextEncoding != null)
                {
                    await s_eventSource.ResponseContentTextAsync(message.Response, responseTextEncoding, message.Cancellation).ConfigureAwait(false);

                }
                else
                {
                    await s_eventSource.ResponseContentAsync(message.Response, message.Cancellation).ConfigureAwait(false);
                }
            }

            var elapsedMilliseconds = (after - before) * 1000 / s_frequency;
            if (elapsedMilliseconds > s_delayWarningThreshold) {
                s_eventSource.ResponseDelay(message.Response, elapsedMilliseconds);
            }
        }

        private static bool IsTextContentType(string contentType)
        {
            return contentType.StartsWith("text/");
        }

        private class LoggingStream : ReadOnlyStream
        {
            private readonly string _requestId;

            private readonly HttpPipelineEventSource _eventSource;

            private readonly Stream _originalStream;

            private readonly bool _error;

            private readonly Encoding _textEncoding;

            private int _blockNumber;

            public LoggingStream(string requestId, HttpPipelineEventSource eventSource, Stream originalStream, bool error, Encoding textEncoding)
            {
                // Should only wrap non-seekable streams
                Debug.Assert(!originalStream.CanSeek);
                _requestId = requestId;
                _eventSource = eventSource;
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
                if (result == 0)
                {
                    return result;
                }

                if (_textEncoding != null)
                {
                    _eventSource.ResponseContentTextBlock(_requestId, _blockNumber, _textEncoding.GetString(buffer, offset, count));

                    if (_error)
                    {
                        _eventSource.ErrorResponseContentTextBlock(_requestId, _blockNumber, _textEncoding.GetString(buffer, offset, count));
                    }
                }
                else
                {
                    _eventSource.ResponseContentBlock(_requestId, _blockNumber, buffer, offset, count);

                    if (_error)
                    {
                        _eventSource.ErrorResponseContentBlock(_requestId, _blockNumber, buffer, offset, count);
                    }
                }

                _blockNumber++;

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
        }
    }
}
