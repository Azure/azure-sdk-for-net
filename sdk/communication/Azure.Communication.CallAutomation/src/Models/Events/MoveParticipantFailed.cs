// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Move participant failed event.
    /// </summary>
    public class MoveParticipantFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MoveParticipantFailed"/>.
        /// </summary>
        /// <param name="internalEvent">The internal event model containing the move participant failed event data.</param>
        internal MoveParticipantFailed(MoveParticipantFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            FromCall = internalEvent.FromCall;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            ResultInformation = internalEvent.ResultInformation;
        }
        /// <summary>
        /// The CallConnectionId for the call you want to move the participant from.
        /// </summary>
        public string FromCall { get; }

        /// <summary>
        /// Participant.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="MoveParticipantFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MoveParticipantFailed"/> object.</returns>
        public static MoveParticipantFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = MoveParticipantFailedInternal.DeserializeMoveParticipantFailedInternal(element);
            return new MoveParticipantFailed(internalEvent);
        }
    }
}
