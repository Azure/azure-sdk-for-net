// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Diagnostics;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Example of how a real application would implement a unified Azure SDK event listener.
    /// This demonstrates the developer experience and captures events in a structured way.
    /// </summary>
    internal class DocumentationExampleEventListener : EventListener
    {
        private readonly List<CapturedEvent> _capturedEvents;

        public DocumentationExampleEventListener(List<CapturedEvent> capturedEvents)
        {
            _capturedEvents = capturedEvents ?? throw new ArgumentNullException(nameof(capturedEvents));
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // Listen to all Azure SDK EventSources using the standard pattern
            if (eventSource.Name.StartsWith("Azure-"))
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            var source = eventData.EventSource.Name;

            switch (source)
            {
                case "Azure-Core":
                    HandleAzureCoreEvent(eventData);
                    break;
                case "Azure-VoiceLive":
                    HandleVoiceLiveEvent(eventData);
                    break;
            }
        }

        private void HandleAzureCoreEvent(EventWrittenEventArgs eventData)
        {
            // Handle HTTP events (for comparison with WebSocket events)
            // This would capture request/response content from HTTP operations
        }

        private void HandleVoiceLiveEvent(EventWrittenEventArgs eventData)
        {
            var capturedEvent = new CapturedEvent
            {
                Source = eventData.EventSource.Name,
                Timestamp = DateTime.UtcNow,
                Level = eventData.Level
            };

            switch (eventData.EventId)
            {
                case AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent: // WebSocketConnectionOpen
                    capturedEvent.EventType = "ConnectionOpen";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.Endpoint = eventData.Payload?[1]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketConnectionClosedEvent: // WebSocketConnectionClose
                    capturedEvent.EventType = "ConnectionClose";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketMessageSentEvent: // WebSocketMessageSent
                    capturedEvent.EventType = "MessageSent";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.MessageType = eventData.Payload?[1]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent: // WebSocketMessageSentContentText
                    capturedEvent.EventType = "ContentSent";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.Content = eventData.Payload?[1]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketMessageReceivedEvent:
                    capturedEvent.EventType = "MessageReceived";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.MessageType = eventData.Payload?[1]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketMessageReceivedContentTextEvent:
                    capturedEvent.EventType = "ContentReceived";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.Content = eventData.Payload?[1]?.ToString();
                    break;

                case AzureVoiceLiveEventSource.WebSocketMessageErrorEvent: // WebSocketMessageError
                    capturedEvent.EventType = "Error";
                    capturedEvent.ConnectionId = eventData.Payload?[0]?.ToString();
                    capturedEvent.ErrorMessage = eventData.Payload?[1]?.ToString();
                    break;
            }

            _capturedEvents.Add(capturedEvent);
        }
    }
}
