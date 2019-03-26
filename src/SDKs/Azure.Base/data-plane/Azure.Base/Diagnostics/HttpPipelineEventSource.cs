// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Base.Http;
using System.Diagnostics.Tracing;

// TODO (pri 2): we should log correction/activity
// TODO (pri 2): we should log exceptions
namespace Azure.Base.Diagnostics
{
    // TODO (pri 2): make the type internal
    [EventSource(Name = SOURCE_NAME)]
    internal sealed class HttpPipelineEventSource : EventSource
    {
        // TODO (pri 3): do we want the same source name for all SDk components?
        const string SOURCE_NAME = "AzureSDK";

        // Maximum event size is 32K but we need to account for other data
        private const int MaxEventPayloadSize = 31000;
        private const int RequestEvent = 3;
        private const int RequestContentEvent = 7;
        private const int ResponseEvent = 4;
        private const int RequestDelayEvent = 5;
        private const int ResponseErrorEvent = 6;

        private HttpPipelineEventSource() : base(SOURCE_NAME) { }

        internal static readonly HttpPipelineEventSource Singleton = new HttpPipelineEventSource();

        // TODO (pri 2): this logs just the URI. We need more
        [NonEvent]
        public void ProcessingRequest(HttpPipelineRequest request)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ProcessingRequest(request.CorrelationId, request.Method.ToString(), "", FormatHeaders(request));
            }

            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ProcessingRequestContent(request.CorrelationId, FormatContent(Array.Empty<byte>(), 0));
            }

        }

        [NonEvent]
        public void ProcessingResponse(HttpPipelineResponse response)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ProcessingResponse(response.ToString());
            }

            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                ProcessingResponseContent(response.CorrelationId, FormatContent(Array.Empty<byte>(), 0));
            }
        }

        [NonEvent]
        public void ResponseDelay(HttpPipelineResponse response, long delayMilliseconds)
            => ResponseDelayCore(delayMilliseconds);

        // TODO (pri 2): there are more attribute properties we might want to set
        [Event(RequestEvent, Level = EventLevel.Informational)]
        void ProcessingRequest(string correlationId, string method, string uri, string headers)
        {
            WriteEvent(RequestEvent, correlationId, method, uri, headers);
        }

        [Event(ResponseEvent, Level = EventLevel.Informational)]
        void ProcessingResponse(string response)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None)) {
                WriteEvent(ResponseEvent, response);
            }
        }

        [Event(RequestDelayEvent, Level = EventLevel.Warning)]
        void ResponseDelayCore(long delayMilliseconds)
        {
            if (IsEnabled(EventLevel.Warning, EventKeywords.None)) {
                WriteEvent(RequestDelayEvent, delayMilliseconds);
            }
        }

        [Event(ResponseErrorEvent, Level = EventLevel.Error)]
        public void ErrorResponse(string correlationId, int status)
        {
            WriteEvent(ResponseErrorEvent, correlationId, status);
        }

        [Event(RequestContentEvent, Level = EventLevel.Verbose)]
        private void ProcessingRequestContent(string correlationId, byte[] content)
        {
            WriteEvent(ResponseErrorEvent, correlationId, content);
        }

        [Event(RequestContentEvent, Level = EventLevel.Verbose)]
        private void ProcessingResponseContent(string correlationId, byte[] content)
        {
            WriteEvent(ResponseErrorEvent, correlationId, content);
        }

        private byte[] FormatContent(byte[] buffer, int count)
        {
            count = Math.Min(count, MaxEventPayloadSize);

            byte[] slice = buffer;
            if (count != buffer.Length)
            {
                slice = new byte[count];
                Buffer.BlockCopy(buffer, 0, slice, 0, count);
            }

            return slice;
        }

        private string FormatHeaders(HttpPipelineRequest request)
        {
            return "HEADERS";
        }
    }
}
