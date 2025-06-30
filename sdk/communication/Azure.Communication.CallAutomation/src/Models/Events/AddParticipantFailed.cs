// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participant failed event.
    /// </summary>
    public class AddParticipantFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        internal AddParticipantFailed()
        {
        }

        /// <summary> Initializes a new instance of AddParticipantFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantFailedEvent. </param>
        internal AddParticipantFailed(AddParticipantFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant failed to be added. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantFailed"/> object.</returns>
        public static AddParticipantFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantFailedInternal.DeserializeAddParticipantFailedInternal(element);
            return new AddParticipantFailed(internalEvent);
        }
    }
}
