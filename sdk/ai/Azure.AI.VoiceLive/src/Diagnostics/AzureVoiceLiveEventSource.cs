// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Text;
using Azure.Core.Diagnostics;

namespace Azure.AI.VoiceLive.Diagnostics
{
    /// <summary>
    /// EventSource for Azure.AI.VoiceLive WebSocket operations.
    /// </summary>
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureVoiceLiveEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-VoiceLive";

        internal const int WebSocketConnectionOpeningEvent = 1;
        internal const int WebSocketConnectionOpenedEvent = 2;
        internal const int WebSocketConnectionClosingEvent = 3;
        internal const int WebSocketConnectionClosedEvent = 4;
        internal const int WebSocketMessageSentEvent = 5;
        internal const int WebSocketMessageSentContentEvent = 6;
        internal const int WebSocketMessageSentContentTextEvent = 7;
        internal const int WebSocketMessageReceivedEvent = 8;
        internal const int WebSocketMessageReceivedContentEvent = 9;
        internal const int WebSocketMessageReceivedContentTextEvent = 10;
        internal const int WebSocketMessageErrorEvent = 11;
        internal const int WebSocketMessageErrorContentEvent = 12;
        internal const int WebSocketMessageErrorContentTextEvent = 13;

        private AzureVoiceLiveEventSource() : base(EventSourceName) { }

        /// <summary>
        /// Gets the singleton instance of the AzureVoiceLiveEventSource.
        /// </summary>
        public static AzureVoiceLiveEventSource Singleton { get; } = new AzureVoiceLiveEventSource();

        [Event(WebSocketConnectionOpeningEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] opening to {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketConnectionOpening(string connectionId, string uri)
        {
            WriteEvent(WebSocketConnectionOpeningEvent, connectionId, uri);
        }

        [Event(WebSocketConnectionOpenedEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] opened")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketConnectionOpened(string connectionId)
        {
            WriteEvent(WebSocketConnectionOpenedEvent, connectionId);
        }

        [Event(WebSocketConnectionClosingEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] closing {1} Reason: {2}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketConnectionClosing(string connectionId, int closeCode, string reason)
        {
            WriteEvent(WebSocketConnectionClosingEvent, connectionId, closeCode, reason);
        }

        [Event(WebSocketConnectionClosedEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] closed.")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketConnectionClosed(string connectionId)
        {
            WriteEvent(WebSocketConnectionClosedEvent, connectionId);
        }

        [Event(WebSocketMessageSentEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] sent message type: {1}, size: {2} bytes")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageSent(string connectionId, string messageType, int size)
        {
            WriteEvent(WebSocketMessageSentEvent, connectionId, messageType, size);
        }

        [NonEvent]
        public void WebSocketMessageSentContent(string connectionId, byte[] content, Encoding? textEncoding = null)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                if (textEncoding != null)
                {
                    WebSocketMessageSentContentText(connectionId, textEncoding.GetString(content));
                }
                else
                {
                    WebSocketMessageSentContent(connectionId, content);
                }
            }
        }

        [Event(WebSocketMessageSentContentEvent, Level = EventLevel.Verbose, Message = "VoiceLive WebSocket [{0}] sent content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
        public void WebSocketMessageSentContent(string connectionId, byte[] content)
        {
            WriteEvent(WebSocketMessageSentContentEvent, connectionId, content);
        }

        [Event(WebSocketMessageSentContentTextEvent, Level = EventLevel.Verbose, Message = "VoiceLive WebSocket [{0}] sent content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageSentContentText(string connectionId, string content)
        {
            WriteEvent(WebSocketMessageSentContentTextEvent, connectionId, content);
        }

        [Event(WebSocketMessageReceivedEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] received message type: {1}, size: {2} bytes")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageReceived(string connectionId, string messageType, int size)
        {
            WriteEvent(WebSocketMessageReceivedEvent, connectionId, messageType, size);
        }

        [NonEvent]
        public void WebSocketMessageReceivedContent(string connectionId, byte[] content, Encoding? textEncoding = null)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                if (textEncoding != null)
                {
                    WebSocketMessageReceivedContentText(connectionId, textEncoding.GetString(content));
                }
                else
                {
                    WebSocketMessageReceivedContent(connectionId, content);
                }
            }
        }

        [Event(WebSocketMessageReceivedContentEvent, Level = EventLevel.Verbose, Message = "VoiceLive WebSocket [{0}] received content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
        public void WebSocketMessageReceivedContent(string connectionId, byte[] content)
        {
            WriteEvent(WebSocketMessageReceivedContentEvent, connectionId, content);
        }

        [Event(WebSocketMessageReceivedContentTextEvent, Level = EventLevel.Verbose, Message = "VoiceLive WebSocket [{0}] received content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageReceivedContentText(string connectionId, string content)
        {
            WriteEvent(WebSocketMessageReceivedContentTextEvent, connectionId, content);
        }

        [Event(WebSocketMessageErrorEvent, Level = EventLevel.Warning, Message = "VoiceLive WebSocket [{0}] error: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageError(string connectionId, string error)
        {
            WriteEvent(WebSocketMessageErrorEvent, connectionId, error);
        }

        [NonEvent]
        public void WebSocketMessageErrorContent(string connectionId, byte[] content, Encoding? textEncoding = null)
        {
            // Error content is logged at Informational level (like Azure.Core does for HTTP error responses)
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                if (textEncoding != null)
                {
                    WebSocketMessageErrorContentText(connectionId, textEncoding.GetString(content));
                }
                else
                {
                    WebSocketMessageErrorContent(connectionId, content);
                }
            }
        }

        [Event(WebSocketMessageErrorContentEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] error content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "WriteEvent is used with an array with primitive type elements.")]
        public void WebSocketMessageErrorContent(string connectionId, byte[] content)
        {
            WriteEvent(WebSocketMessageErrorContentEvent, connectionId, content);
        }

        [Event(WebSocketMessageErrorContentTextEvent, Level = EventLevel.Informational, Message = "VoiceLive WebSocket [{0}] error content: {1}")]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        public void WebSocketMessageErrorContentText(string connectionId, string content)
        {
            WriteEvent(WebSocketMessageErrorContentTextEvent, connectionId, content);
        }
    }
}
