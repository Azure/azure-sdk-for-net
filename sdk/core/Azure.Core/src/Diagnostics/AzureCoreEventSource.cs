// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Azure.Core.Diagnostics
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureCoreEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Core";

        private const int RequestEvent = 1;
        private const int RequestContentEvent = 2;
        private const int ResponseEvent = 5;
        private const int ResponseContentEvent = 6;
        private const int ResponseDelayEvent = 7;
        private const int ErrorResponseEvent = 8;
        private const int ErrorResponseContentEvent = 9;
        private const int RequestRetryingEvent = 10;
        private const int ResponseContentBlockEvent = 11;
        private const int ErrorResponseContentBlockEvent = 12;
        private const int ResponseContentTextEvent = 13;
        private const int ErrorResponseContentTextEvent = 14;
        private const int ResponseContentTextBlockEvent = 15;
        private const int ErrorResponseContentTextBlockEvent = 16;
        private const int RequestContentTextEvent = 17;
        private const int ExceptionResponseEvent = 18;
        private const int BackgroundRefreshFailedEvent = 19;
        private const int RequestRedirectEvent = 20;
        private const int RequestRedirectBlockedEvent = 21;
        private const int RequestRedirectCountExceededEvent = 22;
        private const int PipelineTransportOptionsNotAppliedEvent = 23;

        private AzureCoreEventSource() : base(EventSourceName) { }

        public static AzureCoreEventSource Singleton { get; } = new AzureCoreEventSource();

        [Event(BackgroundRefreshFailedEvent, Level = EventLevel.Informational, Message = "Background token refresh [{0}] failed with exception {1}")]
        public void BackgroundRefreshFailed(string requestId, string exception)
        {
            WriteEvent(BackgroundRefreshFailedEvent, requestId, exception);
        }

        [NonEvent]
        public void Request(Request request, string? assemblyName, HttpMessageSanitizer sanitizer)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                Request(request.ClientRequestId, request.Method.ToString(), sanitizer.SanitizeUrl(request.Uri.ToString()), FormatHeaders(request.Headers, sanitizer), assemblyName);
            }
        }

        [Event(RequestEvent, Level = EventLevel.Informational, Message = "Request [{0}] {1} {2}\r\n{3}client assembly: {4}")]
        public void Request(string requestId, string method, string uri, string headers, string? clientAssembly)
        {
            WriteEvent(RequestEvent, requestId, method, uri, headers, clientAssembly);
        }

        [NonEvent]
        public void RequestContent(string requestId, byte[] content, Encoding? textEncoding)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                if (textEncoding is not null)
                {
                    RequestContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    RequestContent(requestId, content);
                }
            }
        }

        [Event(RequestContentEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
        public void RequestContent(string requestId, byte[] content)
        {
            WriteEvent(RequestContentEvent, requestId, content);
        }

        [Event(RequestContentTextEvent, Level = EventLevel.Verbose, Message = "Request [{0}] content: {1}")]
        public void RequestContentText(string requestId, string content)
        {
            WriteEvent(RequestContentTextEvent, requestId, content);
        }

        [NonEvent]
        public void Response(Response response, HttpMessageSanitizer sanitizer, double elapsed)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                Response(response.ClientRequestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), elapsed);
            }
        }

        [Event(ResponseEvent, Level = EventLevel.Informational, Message = "Response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
        public void Response(string requestId, int status, string reasonPhrase, string headers, double seconds)
        {
            WriteEvent(ResponseEvent, requestId, status, reasonPhrase, headers, seconds);
        }

        [NonEvent]
        public void ResponseContent(string requestId, byte[] content, Encoding? textEncoding)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                if (textEncoding is not null)
                {
                    ResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContent(requestId, content);
                }
            }
        }

        [Event(ResponseContentEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
        public void ResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ResponseContentEvent, requestId, content);
        }

        [Event(ResponseContentTextEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content: {1}")]
        public void ResponseContentText(string requestId, string content)
        {
            WriteEvent(ResponseContentTextEvent, requestId, content);
        }

        [NonEvent]
        public void ResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                if (textEncoding is not null)
                {
                    ResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }

        [Event(ResponseContentBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
        public void ResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ResponseContentTextBlockEvent, Level = EventLevel.Verbose, Message = "Response [{0}] content block {1}: {2}")]
        public void ResponseContentTextBlock(string requestId, int blockNumber, string content)
        {
            WriteEvent(ResponseContentTextBlockEvent, requestId, blockNumber, content);
        }

        [NonEvent]
        public void ErrorResponse(Response response, HttpMessageSanitizer sanitizer, double elapsed)
        {
            if (IsEnabled(EventLevel.Warning, EventKeywords.None))
            {
                ErrorResponse(response.ClientRequestId, response.Status, response.ReasonPhrase, FormatHeaders(response.Headers, sanitizer), elapsed);
            }
        }

        [Event(ErrorResponseEvent, Level = EventLevel.Warning, Message = "Error response [{0}] {1} {2} ({4:00.0}s)\r\n{3}")]
        public void ErrorResponse(string requestId, int status, string reasonPhrase, string headers, double seconds)
        {
            WriteEvent(ErrorResponseEvent, requestId, status, reasonPhrase, headers, seconds);
        }

        [NonEvent]
        public void ErrorResponseContent(string requestId, byte[] content, Encoding? textEncoding)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                if (textEncoding is not null)
                {
                    ErrorResponseContentText(requestId, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContent(requestId, content);
                }
            }
        }

        [Event(ErrorResponseContentEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
        public void ErrorResponseContent(string requestId, byte[] content)
        {
            WriteEvent(ErrorResponseContentEvent, requestId, content);
        }

        [Event(ErrorResponseContentTextEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content: {1}")]
        public void ErrorResponseContentText(string requestId, string content)
        {
            WriteEvent(ErrorResponseContentTextEvent, requestId, content);
        }

        [NonEvent]
        public void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content, Encoding? textEncoding)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                if (textEncoding is not null)
                {
                    ErrorResponseContentTextBlock(requestId, blockNumber, textEncoding.GetString(content));
                }
                else
                {
                    ErrorResponseContentBlock(requestId, blockNumber, content);
                }
            }
        }

        [Event(ErrorResponseContentBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
        public void ErrorResponseContentBlock(string requestId, int blockNumber, byte[] content)
        {
            WriteEvent(ErrorResponseContentBlockEvent, requestId, blockNumber, content);
        }

        [Event(ErrorResponseContentTextBlockEvent, Level = EventLevel.Informational, Message = "Error response [{0}] content block {1}: {2}")]
        public void ErrorResponseContentTextBlock(string requestId, int blockNumber, string content)
        {
            WriteEvent(ErrorResponseContentTextBlockEvent, requestId, blockNumber, content);
        }

        [Event(RequestRetryingEvent, Level = EventLevel.Informational, Message = "Request [{0}] attempt number {1} took {2:00.0}s")]
        public void RequestRetrying(string requestId, int retryNumber, double seconds)
        {
            WriteEvent(RequestRetryingEvent, requestId, retryNumber, seconds);
        }

        [Event(ResponseDelayEvent, Level = EventLevel.Warning, Message = "Response [{0}] took {1:00.0}s")]
        public void ResponseDelay(string requestId, double seconds)
        {
            WriteEvent(ResponseDelayEvent, requestId, seconds);
        }

        [Event(ExceptionResponseEvent, Level = EventLevel.Informational, Message = "Request [{0}] exception {1}")]
        public void ExceptionResponse(string requestId, string exception)
        {
            WriteEvent(ExceptionResponseEvent, requestId, exception);
        }

        [NonEvent]
        public void RequestRedirect(Request request, Uri redirectUri, Response response)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                RequestRedirect(request.ClientRequestId, request.Uri.ToString(), redirectUri.ToString(), response.Status);
            }
        }

        [Event(RequestRedirectEvent, Level = EventLevel.Verbose, Message = "Request [{0}] Redirecting from {1} to {2} in response to status code {3}")]
        public void RequestRedirect(string requestId, string from, string to, int status)
        {
            WriteEvent(RequestRedirectEvent, requestId, from, to, status);
        }

        [Event(RequestRedirectBlockedEvent, Level = EventLevel.Warning, Message = "Request [{0}] Insecure HTTPS to HTTP redirect from {1} to {2} was blocked.")]
        public void RequestRedirectBlocked(string requestId, string from, string to)
        {
            WriteEvent(RequestRedirectBlockedEvent, requestId, from, to);
        }

        [Event(RequestRedirectCountExceededEvent, Level = EventLevel.Warning, Message = "Request [{0}] Exceeded max number of redirects. Redirect from {1} to {2} blocked.")]
        public void RequestRedirectCountExceeded(string requestId, string from, string to)
        {
            WriteEvent(RequestRedirectCountExceededEvent, requestId, from, to);
        }

        [NonEvent]
        public void PipelineTransportOptionsNotApplied(Type optionsType)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                PipelineTransportOptionsNotApplied(optionsType.FullName ?? string.Empty);
            }
        }

        [Event(PipelineTransportOptionsNotAppliedEvent, Level = EventLevel.Informational, Message = "The client requires transport configuration but it was not applied because custom transport was provided. Type: {0}")]
        public void PipelineTransportOptionsNotApplied(string optionsType)
        {
            WriteEvent(PipelineTransportOptionsNotAppliedEvent, optionsType);
        }

        [NonEvent]
        private static string FormatHeaders(IEnumerable<HttpHeader> headers, HttpMessageSanitizer sanitizer)
        {
            var stringBuilder = new StringBuilder();
            foreach (HttpHeader header in headers)
            {
                stringBuilder.Append(header.Name);
                stringBuilder.Append(':');
                string newValue = sanitizer.SanitizeHeader(header.Name, header.Value);
                stringBuilder.AppendLine(newValue);
            }
            return stringBuilder.ToString();
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, double arg1)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[2];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 8;
                WriteEventCore(eventId, 2, data);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, byte[]? arg1)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;

                if (arg1 == null || arg1.Length == 0)
                {
                    var blobSize = 0;
                    data[1].DataPointer = (IntPtr)(&blobSize);
                    data[1].Size = 4;
                    data[2].DataPointer = (IntPtr)(&blobSize); // valid address instead of empty content
                    data[2].Size = 0;

                    WriteEventCore(eventId, 3, data);
                }
                else
                {
                    var blobSize = arg1.Length;
                    fixed (byte* blob = &arg1[0])
                    {
                        data[1].DataPointer = (IntPtr)(&blobSize);
                        data[1].Size = 4;
                        data[2].DataPointer = (IntPtr)blob;
                        data[2].Size = blobSize;

                        WriteEventCore(eventId, 3, data);
                    }
                }
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, int arg1, double arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)(&arg2);
                data[2].Size = 8;
                WriteEventCore(eventId, 3, data);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, int arg1, string? arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg2 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg2Ptr = arg2)
            {
                EventData* data = stackalloc EventData[3];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                WriteEventCore(eventId, 3, data);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, int arg1, byte[]? arg2)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            {
                EventData* data = stackalloc EventData[4];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;

                if (arg2 == null || arg2.Length == 0)
                {
                    var blobSize = 0;
                    data[2].DataPointer = (IntPtr)(&blobSize);
                    data[2].Size = 4;
                    data[3].DataPointer = (IntPtr)(&blobSize); // valid address instead of empty content
                    data[3].Size = 0;
                    WriteEventCore(eventId, 4, data);
                }
                else
                {
                    var blobSize = arg2.Length;
                    fixed (byte* blob = &arg2[0])
                    {
                        data[2].DataPointer = (IntPtr)(&blobSize);
                        data[2].Size = 4;
                        data[3].DataPointer = (IntPtr)blob;
                        data[3].Size = blobSize;
                        WriteEventCore(eventId, 4, data);
                    }
                }
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, string? arg1, string? arg2, int arg3)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg1 ??= string.Empty;
            arg2 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            {
                EventData* data = stackalloc EventData[4];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)arg1Ptr;
                data[1].Size = (arg1.Length + 1) * 2;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)(&arg3);
                data[3].Size = 4;
                WriteEventCore(eventId, 4, data);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, int arg1, string? arg2, string? arg3, double arg4)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg2 ??= string.Empty;
            arg3 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                EventData* data = stackalloc EventData[5];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)(&arg1);
                data[1].Size = 4;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)arg3Ptr;
                data[3].Size = (arg3.Length + 1) * 2;
                data[4].DataPointer = (IntPtr)(&arg4);
                data[4].Size = 8;
                WriteEventCore(eventId, 5, data);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, string? arg0, string? arg1, string? arg2, string? arg3, string? arg4)
        {
            if (!IsEnabled())
            {
                return;
            }

            arg0 ??= string.Empty;
            arg1 ??= string.Empty;
            arg2 ??= string.Empty;
            arg3 ??= string.Empty;
            arg4 ??= string.Empty;
            fixed (char* arg0Ptr = arg0)
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                EventData* data = stackalloc EventData[5];
                data[0].DataPointer = (IntPtr)arg0Ptr;
                data[0].Size = (arg0.Length + 1) * 2;
                data[1].DataPointer = (IntPtr)arg1Ptr;
                data[1].Size = (arg1.Length + 1) * 2;
                data[2].DataPointer = (IntPtr)arg2Ptr;
                data[2].Size = (arg2.Length + 1) * 2;
                data[3].DataPointer = (IntPtr)arg3Ptr;
                data[3].Size = (arg3.Length + 1) * 2;
                data[4].DataPointer = (IntPtr)arg4Ptr;
                data[4].Size = (arg4.Length + 1) * 2;
                WriteEventCore(eventId, 5, data);
            }
        }
    }
}
