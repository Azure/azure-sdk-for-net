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
        private const int ClientStateChangesId = 2;
        private const int ConnectionStartingId = 3;
        private const int ConnectionClosedId = 4;
        private const int FailedToHandleMessageId = 5;
        private const int FailedReceivingBytesId = 6;
        private const int FailedToChangeClientStateId = 7;
        private const int StopRecoveryId = 8;
        private const int RecoveryAttemptFailedId = 9;

        public static WebPubSubClientEventSource Log { get; } = new WebPubSubClientEventSource();

        [Event(1, Level = EventLevel.Verbose, Message = "Client starting.")]
        public virtual void ClientStarting()
        {
            if (IsEnabled())
            {
                WriteEvent(ClientStartingId);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "The client state transient from the '{0}' state to the '{1}' state.")]
        public virtual void ClientStateChanges(string newState, string currentState)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientStateChangesId, currentState, newState);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "Connection start to connect with subprotocol {0}.")]
        public virtual void ConnectionStarting(string subprotocol)
        {
            if (IsEnabled())
            {
                WriteEvent(ConnectionStartingId, subprotocol);
            }
        }

        [Event(4, Level = EventLevel.Informational, Message = "Connection closed.")]
        public virtual void ConnectionClosed()
        {
            if (IsEnabled())
            {
                WriteEvent(ConnectionClosedId);
            }
        }

        [Event(5, Level = EventLevel.Warning, Message = "An exception occurred while handling message from the service.")]
        public virtual void FailedToHandleMessage(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToHandleMessageId, errorMessage);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "An exception occurred while receiving bytes.")]
        public virtual void FailedReceivingBytes(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedReceivingBytesId, errorMessage);
            }
        }

        [Event(7, Level = EventLevel.Warning, Message = "The client failed to transition from the '{0}' state to the '{1}' state because it was actually in the '{2}' state.")]
        public virtual void FailedToChangeClientState(string expectedState, string newState, string currentState)
        {
            if (IsEnabled())
            {
                WriteEvent(FailedToChangeClientStateId, expectedState, newState, currentState);
            }
        }

        [Event(8, Level = EventLevel.Warning, Message = "Stop try to recover the connection with connectionId: {0} cause of {1}.")]
        public virtual void StopRecovery(string connectionId, string reason)
        {
            if (IsEnabled())
            {
                WriteEvent(StopRecoveryId, connectionId, reason);
            }
        }

        [Event(9, Level = EventLevel.Informational, Message = "An attempt to recover connection with connectionId: {0} failed, will retry later.")]
        public virtual void RecoveryAttemptFailed(string connectionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(RecoveryAttemptFailedId, connectionId, errorMessage);
            }
        }
    }
}
