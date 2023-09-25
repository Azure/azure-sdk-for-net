// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participant cancelled event.
    /// </summary>
    public class AddParticipantCancelled : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantCancelledEvent. </summary>
        internal AddParticipantCancelled()
        {
        }

        /// <summary> Initializes a new instance of AddParticipantCancelledEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantCancelledEvent. </param>
        internal AddParticipantCancelled(AddParticipantCancelledInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            InvitationId = internalEvent.InvitationId;
        }

        /// <summary> Participant whoose invitation has been cancelled. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Invitation ID used to cancel the invitation.
        /// </summary>
        public string InvitationId { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantCancelled"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantCancelled"/> object.</returns>
        public static AddParticipantCancelled Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantCancelledInternal.DeserializeAddParticipantCancelledInternal(element);
            return new AddParticipantCancelled(internalEvent);
        }
    }
}
