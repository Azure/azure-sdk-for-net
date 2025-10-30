// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.AI.VoiceLive;
using Azure.Core;

namespace Azure.AI.VoiceLive.Samples
{
    /// <summary>
    /// Example EventListener that handles both Azure.Core HTTP and Azure.VoiceLive WebSocket events.
    /// </summary>
    public class UnifiedEventListener : EventListener
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="eventSource"></param>
        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // Listen to both Azure-Core (HTTP) and Azure-VoiceLive (WebSocket) events
            if (eventSource.Name.StartsWith("Azure-"))
            {
                // Enable Verbose level to see content, Informational to see errors
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventData"></param>
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            var source = eventData.EventSource.Name;
            var timestamp = DateTime.UtcNow.ToString("HH:mm:ss.fff");

            switch (source)
            {
                case "Azure-Core":
                    HandleAzureCoreEvent(eventData, timestamp);
                    break;
                case "Azure-VoiceLive":
                    HandleVoiceLiveEvent(eventData, timestamp);
                    break;
            }
        }

        private void HandleAzureCoreEvent(EventWrittenEventArgs eventData, string timestamp)
        {
            // Handle HTTP pipeline events from Azure.Core
            switch (eventData.EventId)
            {
                case 1: // Request
                    Console.WriteLine($"[{timestamp}] [HTTP] {eventData.Message}");
                    break;
                case 17: // RequestContentText
                    var requestId = eventData.Payload?[0];
                    var requestContent = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [HTTP] Request [{requestId}] content: {requestContent}");
                    break;
                case 5: // Response
                    Console.WriteLine($"[{timestamp}] [HTTP] {eventData.Message}");
                    break;
                case 13: // ResponseContentText
                    var responseRequestId = eventData.Payload?[0];
                    var responseContent = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [HTTP] Response [{responseRequestId}] content: {responseContent}");
                    break;
                case 14: // ErrorResponseContentText
                    var errorRequestId = eventData.Payload?[0];
                    var errorContent = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [HTTP] ERROR Response [{errorRequestId}] content: {errorContent}");
                    break;
            }
        }

        private void HandleVoiceLiveEvent(EventWrittenEventArgs eventData, string timestamp)
        {
            // Handle WebSocket events from Azure.VoiceLive
            switch (eventData.EventId)
            {
                case 1001: // WebSocketConnectionOpen
                    Console.WriteLine($"[{timestamp}] [VoiceLive] {eventData.Message}");
                    break;
                case 1002: // WebSocketConnectionClose
                    Console.WriteLine($"[{timestamp}] [VoiceLive] {eventData.Message}");
                    break;
                case 1003: // WebSocketMessageSent
                    Console.WriteLine($"[{timestamp}] [VoiceLive] {eventData.Message}");
                    break;
                case 1005: // WebSocketMessageSentContentText
                    var sentConnectionId = eventData.Payload?[0];
                    var sentContent = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [VoiceLive] Sent [{sentConnectionId}] content: {sentContent}");
                    break;
                case 1006: // WebSocketMessageReceived
                    Console.WriteLine($"[{timestamp}] [VoiceLive] {eventData.Message}");
                    break;
                case 1008: // WebSocketMessageReceivedContentText
                    var receivedConnectionId = eventData.Payload?[0];
                    var receivedContent = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [VoiceLive] Received [{receivedConnectionId}] content: {receivedContent}");
                    break;
                case 1009: // WebSocketMessageError
                    Console.WriteLine($"[{timestamp}] [VoiceLive] ERROR: {eventData.Message}");
                    break;
                case 1011: // WebSocketMessageErrorContentText
                    var errorConnectionId = eventData.Payload?[0];
                    var errorContentText = eventData.Payload?[1];
                    Console.WriteLine($"[{timestamp}] [VoiceLive] ERROR [{errorConnectionId}] content: {errorContentText}");
                    break;
            }
        }
    }
}
