// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http;
using System;
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

        const int LOG_REQUEST = 3;
        const int LOG_RESPONSE = 4;
        const int LOG_DELAY = 5;
        const int LOG_ERROR_RESPONSE = 6;

        private HttpPipelineEventSource() : base(SOURCE_NAME) { }

        internal static readonly HttpPipelineEventSource Singleton = new HttpPipelineEventSource();

        // TODO (pri 2): this logs just the URI. We need more
        [NonEvent]
        public void ProcessingRequest(HttpPipelineRequest request)
            => ProcessingRequest(request.ToString());

        [NonEvent]
        public void ProcessingResponse(HttpPipelineResponse response)
            => ProcessingResponse(response.ToString());

        [NonEvent]
        public void ErrorResponse(HttpPipelineResponse response)
            => ErrorResponse(response.Status);

        [NonEvent]
        public void ResponseDelay(HttpPipelineResponse response, long delayMilliseconds)
            => ResponseDelayCore(delayMilliseconds);

        // TODO (pri 2): there are more attribute properties we might want to set
        [Event(LOG_REQUEST, Level = EventLevel.Informational)]
        void ProcessingRequest(string request)
        {
            // TODO (pri 2): is EventKeywords.None ok?
            if (IsEnabled(EventLevel.Informational, EventKeywords.None)) {
                WriteEvent(LOG_REQUEST, request);
            }
        }

        [Event(LOG_RESPONSE, Level = EventLevel.Informational)]
        void ProcessingResponse(string response)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None)) {
                WriteEvent(LOG_RESPONSE, response);
            }
        }

        [Event(LOG_DELAY, Level = EventLevel.Warning)]
        void ResponseDelayCore(long delayMilliseconds)
        {
            if (IsEnabled(EventLevel.Warning, EventKeywords.None)) {
                WriteEvent(LOG_DELAY, delayMilliseconds);
            }
        }

        [Event(LOG_ERROR_RESPONSE, Level = EventLevel.Error)]
        void ErrorResponse(int status)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None)) {
                WriteEvent(LOG_ERROR_RESPONSE, status);
            }
        }
    }
}
