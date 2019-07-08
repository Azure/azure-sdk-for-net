// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// TODO (pri 2): we should log correction/activity
// TODO (pri 2): we should log exceptions
namespace Azure.Core.Diagnostics
{
    // TODO (pri 2): make the type internal
    [EventSource(Name = EventSourceName)]
    internal sealed class HttpPipelineEventSource : EventSource
    {
        // TODO (pri 3): do we want the same source name for all SDk components?
        private const string EventSourceName = "AzureSDK";

        private const int MaxEventPayloadSize = 10 * 1024;
        private const int CopyBufferSize = 8 * 1024;

        private const int RequestEvent = 1;
        private const int RequestContentEvent = 2;
        private const int RequestContentTextEvent = 17;
        private const int ResponseEvent = 5;
        private const int ResponseContentEvent = 6;
        private const int ResponseContentTextEvent = 13;
        private const int ResponseContentBlockEvent = 11;
        private const int ResponseContentTextBlockEvent = 15;
        private const int RequestDelayEvent = 7;
        private const int ErrorResponseEvent = 8;
        private const int ErrorResponseContentEvent = 9;
        private const int ErrorResponseContentTextEvent = 14;
        private const int ErrorResponseContentBlockEvent = 12;
        private const int ErrorResponseContentTextBlockEvent = 16;
        private const int RequestRetryingEvent = 10;

        private HttpPipelineEventSource() : base(EventSourceName) { }

        internal static readonly HttpPipelineEventSource Singleton = new HttpPipelineEventSource();

        // TODO (pri 2): this logs just the URI. We need more
        [NonEvent]
        public void Request(Request request)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                Request(request.ClientRequestId, request.Method.ToString().ToUpperInvariant(), request.UriBuilder.ToString(), FormatHeaders(request.Headers));
            }
        }

        [NonEvent]
        public async Task RequestContentAsync(Request request, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestContent(request.ClientRequestId, await FormatContentAsync(request.Content, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void RequestContent(Request request, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestContent(request.ClientRequestId, FormatContent(request.Content, cancellationToken));
            }
        }

        [NonEvent]
        public async Task RequestContentTextAsync(Request request, Encoding encoding, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestContentText(request.ClientRequestId, await FormatContentStringAsync(request.Content, encoding, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void RequestContentText(Request request, Encoding encoding, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestContentText(request.ClientRequestId, FormatContentString(request.Content, encoding, cancellationToken));
            }
        }

        [NonEvent]
        public void Response(Response response)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                Response(response.ClientRequestId, response.Status, FormatHeaders(response.Headers));
            }
        }

        [NonEvent]
        public async Task ResponseContentAsync(Response response, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ResponseContent(response.ClientRequestId, await FormatContentAsync(response.ContentStream, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void ResponseContent(Response response)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ResponseContent(response.ClientRequestId, FormatContent(response.ContentStream));
            }
        }

        [NonEvent]
        public void ResponseContentBlock(string responseId, int blockNumber, byte[] data, int offset, int length)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ResponseContentBlock(responseId, blockNumber, FormatContent(data, offset, length));
            }
        }

        [NonEvent]
        public async Task ResponseContentTextAsync(Response response, Encoding encoding, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ResponseContentText(response.ClientRequestId, await FormatContentStringAsync(response.ContentStream, encoding, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void ResponseContentText(Response response, Encoding encoding)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ResponseContentText(response.ClientRequestId, FormatContentString(response.ContentStream, encoding));
            }
        }

        [NonEvent]
        public void ErrorResponse(Response response)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None))
            {
                ErrorResponse(response.ClientRequestId, response.Status, FormatHeaders(response.Headers));
            }
        }

        [NonEvent]
        public async Task ErrorResponseContentAsync(Response response, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ErrorResponseContent(response.ClientRequestId, await FormatContentAsync(response.ContentStream, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void ErrorResponseContent(Response response)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ErrorResponseContent(response.ClientRequestId, FormatContent(response.ContentStream));
            }
        }

        [NonEvent]
        public async Task ErrorResponseContentTextAsync(Response response, Encoding encoding, CancellationToken cancellationToken)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ErrorResponseContentText(response.ClientRequestId, await FormatContentStringAsync(response.ContentStream, encoding, cancellationToken).ConfigureAwait(false));
            }
        }

        [NonEvent]
        public void ErrorResponseContentText(Response response, Encoding encoding)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ErrorResponseContentText(response.ClientRequestId, FormatContentString(response.ContentStream, encoding));
            }
        }

        [NonEvent]
        public void ErrorResponseContentBlock(string responseId, int blockNumber, byte[] data, int offset, int length)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ErrorResponseContentBlock(responseId, blockNumber, FormatContent(data, offset, length));
            }
        }

        [NonEvent]
        public void ResponseDelay(Response response, long delayMilliseconds)
        {
            ResponseDelayCore(response.ClientRequestId, delayMilliseconds);
        }

        [NonEvent]
        public void RequestRetrying(Request request, int retryNumber)
        {
            RequestRetrying(request.ClientRequestId, retryNumber);
        }

        // TODO (pri 2): there are more attribute properties we might want to set
        [Event(RequestEvent, Level = EventLevel.Informational)]
        private void Request(string requestId, string method, string uri, string headers)
        {
            WriteEvent(RequestEvent, requestId, method, uri, headers);
        }

        [Event(RequestContentEvent, Level = EventLevel.Verbose)]
        private void RequestContent(string requestId, byte[] content)
        {
            WriteEvent(RequestContentEvent, requestId, content);
        }

        [Event(RequestContentTextEvent, Level = EventLevel.Verbose)]
        private void RequestContentText(string requestId, string content)
        {
            WriteEvent(RequestContentTextEvent, requestId, content);
        }

        [Event(ResponseEvent, Level = EventLevel.Informational)]
        private void Response(string requestId, int status, string headers)
        {
            WriteEvent(ResponseEvent, requestId, status, headers);
        }

        [Event(ResponseContentEvent, Level = EventLevel.Verbose)]
        private void ResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ResponseContentEvent, requestId, content);
        }

        [Event(ResponseContentBlockEvent, Level = EventLevel.Verbose)]
        private void ResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ResponseContentTextEvent, Level = EventLevel.Verbose)]
        private void ResponseContentText(string requestId, string content)
        {
            WriteEvent(ResponseContentTextEvent, requestId, content);
        }

        [Event(ResponseContentTextBlockEvent, Level = EventLevel.Verbose)]
        public void ResponseContentTextBlock(string requestId, int blockNumber, string content)
        {
            WriteEvent(ResponseContentTextBlockEvent, requestId, blockNumber, content);
        }

        [Event(ErrorResponseEvent, Level = EventLevel.Error)]
        public void ErrorResponse(string requestId, int status, string headers)
        {
            WriteEvent(ErrorResponseEvent, requestId, status, headers);
        }

        [Event(ErrorResponseContentEvent, Level = EventLevel.Informational)]
        private void ErrorResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ErrorResponseContentEvent, requestId, content);
        }

        [Event(ErrorResponseContentBlockEvent, Level = EventLevel.Informational)]
        public void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ErrorResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ErrorResponseContentTextEvent, Level = EventLevel.Informational)]
        private void ErrorResponseContentText(string requestId, string content)
        {
            WriteEvent(ErrorResponseContentTextEvent, requestId, content);
        }

        [Event(ErrorResponseContentTextBlockEvent, Level = EventLevel.Informational)]
        public void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content)
        {
            WriteEvent(ErrorResponseContentTextBlockEvent, requestId, blockNumber, content);
        }

        [Event(RequestDelayEvent, Level = EventLevel.Warning)]
        private void ResponseDelayCore(string requestId, long delayMilliseconds)
        {
            if (IsEnabled(EventLevel.Warning, EventKeywords.None))
            {
                WriteEvent(RequestDelayEvent, requestId, delayMilliseconds);
            }
        }

        [Event(RequestRetryingEvent, Level = EventLevel.Informational)]
        private void RequestRetrying(string requestId, int retryNumber)
        {
            WriteEvent(RequestRetryingEvent, requestId, retryNumber);
        }

        public bool ShouldLogContent(bool isError)
        {
            return (isError && IsEnabled(EventLevel.Informational, EventKeywords.None)) ||
                   IsEnabled(EventLevel.Verbose, EventKeywords.None);
        }

        private static byte[] FormatContent(Stream responseContent)
        {
            using (var memoryStream = new MemoryStream())
            {
                responseContent.CopyTo(memoryStream);

                // Rewind the stream
                responseContent.Position = 0;

                return FormatContent(memoryStream.ToArray());
            }
        }
        private static async Task<byte[]> FormatContentAsync(Stream responseContent, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await responseContent.CopyToAsync(memoryStream, CopyBufferSize, cancellationToken).ConfigureAwait(false);

                // Rewind the stream
                responseContent.Position = 0;

                return FormatContent(memoryStream.ToArray());
            }
        }

        private static async Task<string> FormatContentStringAsync(Stream responseContent, Encoding encoding, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await responseContent.CopyToAsync(memoryStream, CopyBufferSize, cancellationToken).ConfigureAwait(false);

                // Rewind the stream
                responseContent.Position = 0;

                byte[] buffer = memoryStream.ToArray();

                return encoding.GetString(FormatContent(buffer));
            }
        }

        private static string FormatContentString(Stream responseContent, Encoding encoding)
        {
            using (var memoryStream = new MemoryStream())
            {
                responseContent.CopyTo(memoryStream);

                // Rewind the stream
                responseContent.Position = 0;

                byte[] buffer = memoryStream.ToArray();

                return encoding.GetString(FormatContent(buffer));
            }
        }

        private static async Task<byte[]> FormatContentAsync(HttpPipelineRequestContent requestContent, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await requestContent.WriteToAsync(memoryStream, cancellation: cancellationToken).ConfigureAwait(false);

                return FormatContent(memoryStream.ToArray());
            }
        }

        private static byte[] FormatContent(HttpPipelineRequestContent requestContent, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                requestContent.WriteTo(memoryStream, cancellationToken);

                return FormatContent(memoryStream.ToArray());
            }
        }

        private static async Task<string> FormatContentStringAsync(HttpPipelineRequestContent requestContent, Encoding encoding, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                await requestContent.WriteToAsync(memoryStream, cancellation: cancellationToken).ConfigureAwait(false);

                return encoding.GetString(FormatContent(memoryStream.ToArray()));
            }
        }

        private static string FormatContentString(HttpPipelineRequestContent requestContent, Encoding encoding, CancellationToken cancellationToken)
        {
            using (var memoryStream = new MemoryStream())
            {
                requestContent.WriteTo(memoryStream, cancellationToken);

                return encoding.GetString(FormatContent(memoryStream.ToArray()));
            }
        }

        private static byte[] FormatContent(byte[] buffer)
        {
            return FormatContent(buffer, 0, buffer.Length);
        }

        private static byte[] FormatContent(byte[] buffer, int offset, int length)
        {
            int count = Math.Min(length, MaxEventPayloadSize);

            byte[] slice = buffer;
            if (count != length || offset != 0)
            {
                slice = new byte[count];
                Buffer.BlockCopy(buffer, offset, slice, 0, count);
            }

            return slice;
        }

        private static string FormatHeaders(IEnumerable<HttpHeader> headers)
        {
            var stringBuilder = new StringBuilder();
            foreach (var header in headers)
            {
                stringBuilder.AppendLine(header.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
