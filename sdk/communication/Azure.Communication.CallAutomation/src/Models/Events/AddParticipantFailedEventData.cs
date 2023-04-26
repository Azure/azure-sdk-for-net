// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participant failed event.
    /// </summary>
    public class AddParticipantFailedEventData : CallAutomationEventData
    {
        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        internal AddParticipantFailedEventData()
        {
        }

        /// <summary> Initializes a new instance of AddParticipantFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantFailedEvent. </param>
        internal AddParticipantFailedEventData(AddParticipantFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant failed to be added. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantFailedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantFailedEventData"/> object.</returns>
        public static AddParticipantFailedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantFailedInternal.DeserializeAddParticipantFailedInternal(element);
            return new AddParticipantFailedEventData(internalEvent);
        }
    }
}
