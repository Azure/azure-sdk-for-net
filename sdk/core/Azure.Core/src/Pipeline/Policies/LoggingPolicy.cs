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

        public static readonly LoggingPolicy Shared = new LoggingPolicy();

        // TODO (pri 1): we should remove sensitive information, e.g. keys
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, pipeline, true);
        }

        private static async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline, bool async)
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

            Encoding requestTextEncoding = null;

            bool textRequest = message.Request.TryGetHeader(HttpHeader.Names.ContentType, out var contentType) &&
                ContentTypeUtilities.TryGetTextEncoding(contentType, out requestTextEncoding);

            if (message.Request.Content != null)
            {
                if (textRequest)
                {
                    if (async)
                    {
                        await s_eventSource.RequestContentTextAsync(message.Request, requestTextEncoding, message.CancellationToken);
                    }
                    else
                    {
                        s_eventSource.RequestContentText(message.Request, requestTextEncoding, message.CancellationToken);
                    }
                }
                else
                {
                    if (async)
                    {
                        await s_eventSource.RequestContentAsync(message.Request, message.CancellationToken);
                    }
                    else
                    {
                        s_eventSource.RequestContent(message.Request, message.CancellationToken);
                    }
                }
            }

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

            bool isError = message.ResponseClassifier.IsErrorResponse(message.Response);

            var textResponse = ContentTypeUtilities.TryGetTextEncoding(message.Response.Headers.ContentType, out Encoding responseTextEncoding);

            bool wrapResponseStream = s_eventSource.ShouldLogContent(isError) && message.Response.ContentStream?.CanSeek == false;

            if (wrapResponseStream)
            {
                message.Response.ContentStream = new LoggingStream(
                    message.Response.ClientRequestId, s_eventSource, message.Response.ContentStream, isError, responseTextEncoding);
            }

            if (isError)
            {
                s_eventSource.ErrorResponse(message.Response);

                if (!wrapResponseStream && message.Response.ContentStream != null)
                {
                    if (textResponse)
                    {
                        if (async)
                        {
                            await s_eventSource.ErrorResponseContentTextAsync(message.Response, responseTextEncoding, message.CancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            s_eventSource.ErrorResponseContentText(message.Response, responseTextEncoding, message.CancellationToken);
                        }
                    }
                    else
                    {
                        if (async)
                        {
                            await s_eventSource.ErrorResponseContentAsync(message.Response, message.CancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            s_eventSource.ErrorResponseContent(message.Response);
                        }
                    }
                }
            }

            s_eventSource.Response(message.Response);

            if (!wrapResponseStream && message.Response.ContentStream != null)
            {
                if (textResponse)
                {
                    await s_eventSource.ResponseContentTextAsync(message.Response, responseTextEncoding, message.CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await s_eventSource.ResponseContentAsync(message.Response, message.CancellationToken).ConfigureAwait(false);
                }
            }

            var elapsedMilliseconds = (after - before) * 1000 / s_frequency;
            if (elapsedMilliseconds > s_delayWarningThreshold)
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
