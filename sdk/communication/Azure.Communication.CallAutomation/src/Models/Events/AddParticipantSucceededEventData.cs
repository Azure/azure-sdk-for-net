// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants succeeded event.
    /// </summary>
    public class AddParticipantSucceededEventData: CallAutomationEventData
    {
        /// <summary> Initializes a new instance of AddParticipantSucceededEventInternal. </summary>
        internal AddParticipantSucceededEventData()
        {
        }

        /// <summary> Initializes a new instance of AddParticipantSucceededEventInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the AddParticipantSucceededEvent. </param>
        internal AddParticipantSucceededEventData(AddParticipantSucceededInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant added. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantSucceededEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantSucceededEventData"/> object.</returns>
        public static AddParticipantSucceededEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantSucceededInternal.DeserializeAddParticipantSucceededInternal(element);
            return new AddParticipantSucceededEventData(internalEvent);
        }
    }
}
