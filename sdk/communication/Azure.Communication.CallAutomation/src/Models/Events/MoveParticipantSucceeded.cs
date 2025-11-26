// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Move participant succeeded event.
    /// </summary>
    public partial class MoveParticipantSucceeded : CallAutomationEventBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MoveParticipantSucceeded"/>
        /// </summary>
        /// <param name="internalEvent">The internal event model.</param>
        internal MoveParticipantSucceeded(MoveParticipantSucceededInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            FromCall = internalEvent.FromCall;
            Participant = CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.Participant);
        }

        /// <summary>
        /// The participant that was moved successfully.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// The call connection ID from which the participant was moved.
        /// </summary>
        public string FromCall { get; }

        /// <summary>
        /// Deserialize <see cref="MoveParticipantSucceeded"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MoveParticipantSucceeded"/> object.</returns>
        public static MoveParticipantSucceeded Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = MoveParticipantSucceededInternal.DeserializeMoveParticipantSucceededInternal(element);
            return new MoveParticipantSucceeded(internalEvent);
        }
    }
}
