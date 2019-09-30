// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Azure.Core.Http;

namespace Azure.Core.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureCoreEventSource : EventSource
    {
        private const string EventSourceName = "Azure-Core";

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

        private AzureCoreEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue) { }

        public static AzureCoreEventSource Singleton { get; } = new AzureCoreEventSource();

        [NonEvent]
        public void Request(Request request)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                Request(request.ClientRequestId, request.Method.ToString().ToUpperInvariant(), request.Uri.ToString(), FormatHeaders(request.Headers));
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
        public void ErrorResponse(Response response)
        {
            if (IsEnabled(EventLevel.Warning, EventKeywords.None))
            {
                ErrorResponse(response.ClientRequestId, response.Status, FormatHeaders(response.Headers));
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
        public void RequestContent(string requestId, byte[] content)
        {
            WriteEvent(RequestContentEvent, requestId, content);
        }

        [Event(RequestContentTextEvent, Level = EventLevel.Verbose)]
        public void RequestContentText(string requestId, string content)
        {
            WriteEvent(RequestContentTextEvent, requestId, content);
        }

        [Event(ResponseEvent, Level = EventLevel.Informational)]
        private void Response(string requestId, int status, string headers)
        {
            WriteEvent(ResponseEvent, requestId, status, headers);
        }

        [Event(ResponseContentEvent, Level = EventLevel.Verbose)]
        public void ResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ResponseContentEvent, requestId, content);
        }

        [Event(ResponseContentBlockEvent, Level = EventLevel.Verbose)]
        public void ResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ResponseContentTextEvent, Level = EventLevel.Verbose)]
        public void ResponseContentText(string requestId, string content)
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
        public void ErrorResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ErrorResponseContentEvent, requestId, content);
        }

        [Event(ErrorResponseContentBlockEvent, Level = EventLevel.Informational)]
        public void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ErrorResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ErrorResponseContentTextEvent, Level = EventLevel.Informational)]
        public void ErrorResponseContentText(string requestId, string content)
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

        private static string FormatHeaders(IEnumerable<HttpHeader> headers)
        {
            var stringBuilder = new StringBuilder();
            foreach (HttpHeader header in headers)
            {
                stringBuilder.AppendLine(header.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
