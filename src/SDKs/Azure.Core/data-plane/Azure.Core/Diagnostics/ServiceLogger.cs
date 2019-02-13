// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Http;
using System;
using System.Diagnostics.Tracing;

// TODO (pri 2): we should log correction/activity
// TODO (pri 2): we should log exceptions
namespace Azure.Core.Diagnostics
{
    // TODO (pri 2): make the type internal
    [EventSource(Name = SOURCE_NAME)]
    public sealed class AzureEventSource : EventSource
    {
        // TODO (pri 3): do we want the same source name for all SDk components?
        const string SOURCE_NAME = "AzureSDK";

        const int LOG_TEXT = 1;
        const int LOG_EXCEPTION = 2;
        const int LOG_REQUEST = 3;
        const int LOG_RESPONSE = 4;
        const int LOG_DELAY = 5;
        const int LOG_ERROR_RESPONSE = 6;
               
        private AzureEventSource() : base(SOURCE_NAME) { }

        internal static readonly AzureEventSource Singleton = new AzureEventSource();

        // TODO (pri 2): this logs just the URI. We need more
        [NonEvent]
        public void ProcessingRequest(HttpMessage request)
            => ProcessingRequest(request.ToString());

        [NonEvent]
        public void ProcessingResponse(HttpMessage response)
            => ProcessingResponse(response.ToString());

        [NonEvent]
        public void ErrorResponse(HttpMessage response)
            => ErrorResponse(response.Status);

        [NonEvent]
        public void ResponseDelay(HttpMessage message, long delayMilliseconds)
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

        [Event(LOG_TEXT, Level = EventLevel.Error)]
        public void LogMessage(EventLevel level, string message)
        {
            if (IsEnabled(level, EventKeywords.None)) {
                WriteEvent(LOG_TEXT, message, level);
            }
        }

        [Event(LOG_EXCEPTION)]
        public void LogException(Exception exception)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None)) {
                // TODO (pri 2): should this filter some information?
                // TODO (pri 2): should this be more structured?
                WriteEvent(LOG_EXCEPTION, exception.ToString());
            }
        }
    }
}
