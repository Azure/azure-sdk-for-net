// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.WebPubSub.Clients
{
    [EventSource(Name = EventSourceName)]
    internal class WebPubSubClientEventSource: AzureEventSource
    {
        private const string EventSourceName = "Azure-Messaging-WebPubSub-Client";

        private WebPubSubClientEventSource() : base(EventSourceName)
        {
        }

        // Having event ids defined as const makes it easy to keep track of them
        private const int ClientStartingId = 1;
        private const int ClientStateChangedId = 2;
        private const int WebSocketConnectingId = 3;
        private const int WebSocketClosedId = 4;
        private const int FailedToProcessMessageId = 5;
        private const int FailedToReceiveBytesId = 6;
        private const int FailedToChangeClientStateId = 7;
        private const int StopRecoveryId = 8;
        private const int FailedToRecoverConnectionId = 9;
        private const int FailedToInvokeEventId = 10;
        private const int ConnectionConnectedId = 11;
        private const int ConnectionDisconnectedId = 12;
        private const int FailedToReconnectId = 13;

        public static WebPubSubClientEventSource Log { get; } = new WebPubSubClientEventSource();

        [Event(1, Level = EventLevel.Informational, Message = "Client is starting.")]
        public virtual void ClientStarting()
        {
            if (IsEnabled())
            {
                WriteEvent(ClientStartingId);
            }
        }

        [Event(2, Level = EventLevel.Verbose, Message = "The client state changed from the '{0}' state to the '{1}' state.")]
        public virtual void ClientStateChanged(string newState, string currentState)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientStateChangedId, currentState, newState);
            }
        }

        [Event(3, Level = EventLevel.Verbose, Message = "A new WebSocket connection is starting to connect with subprotocol {0}.")]
        public virtual void WebSocketConnecting(string subprotocol)
        {
            if (IsEnabled())
            {
                WriteEvent(WebSocketConnectingId, subprotocol);
            }
        }

        [Event(4, Level = EventLevel.Verbose, Message = "WebSocket connection is closed.")]
        public virtual void WebSocketClosed()
        {
            if (IsEnabled())
            {
                WriteEvent(WebSocketClosedId);
            }
        }

        [Event(5, Level = EventLevel.Warning, Message = "An exception occurred while processing message from the service. Error Message: {0}")]
        public virtual void FailedToProcessMessage(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToProcessMessageId, errorMessage);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "An exception occurred while receiving bytes. Error Message: {0}")]
        public virtual void FailedToReceiveBytes(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToReceiveBytesId, errorMessage);
            }
        }

        [Event(7, Level = EventLevel.Warning, Message = "The client failed to change from the '{0}' state to the '{1}' state because it was actually in the '{2}' state.")]
        public virtual void FailedToChangeClientState(string expectedState, string newState, string currentState)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToChangeClientStateId, expectedState, newState, currentState);
            }
        }

        [Event(8, Level = EventLevel.Warning, Message = "Stop try to recover the connection with connection ID: {0} cause of {1}.")]
        public virtual void StopRecovery(string connectionId, string reason)
        {
            if (IsEnabled())
            {
                WriteEvent(StopRecoveryId, connectionId, reason);
            }
        }

        [Event(9, Level = EventLevel.Informational, Message = "An attempt to recover connection with connection ID: {0} failed, will retry later. Error Message: {1}")]
        public virtual void FailedToRecoverConnection(string connectionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToRecoverConnectionId, connectionId, errorMessage);
            }
        }

        [Event(10, Level = EventLevel.Warning, Message = "An exception occurred while invoking event handler {0}. Error Message: {1}")]
        public virtual void FailedToInvokeEvent(string eventName, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToInvokeEventId, eventName, errorMessage);
            }
        }

        [Event(11, Level = EventLevel.Informational, Message = "Connection with connection ID: {0} is connected.")]
        public virtual void ConnectionConnected(string connectionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ConnectionConnectedId, connectionId);
            }
        }

        [Event(12, Level = EventLevel.Informational, Message = "Connection with connection ID: {0} is disconnected.")]
        public virtual void ConnectionDisconnected(string connectionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ConnectionDisconnectedId, connectionId);
            }
        }

        [Event(13, Level = EventLevel.Warning, Message = "An attempt to reconnect connection who is the successor of connection ID: {0} failed, will retry later. Error Message: {1}")]
        public virtual void FailedToReconnect(string connectionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToReconnectId, connectionId, errorMessage);
            }
        }
    }
}
