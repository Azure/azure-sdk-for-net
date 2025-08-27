// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participants succeeded event.
    /// </summary>
    public class AddParticipantSucceeded: CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantSucceededEventInternal. </summary>
        internal AddParticipantSucceeded()
        {
        }

        /// <summary> Initializes a new instance of AddParticipantSucceededEventInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the AddParticipantSucceededEvent. </param>
        internal AddParticipantSucceeded(AddParticipantSucceededInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant added. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantSucceeded"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantSucceeded"/> object.</returns>
        public static AddParticipantSucceeded Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantSucceededInternal.DeserializeAddParticipantSucceededInternal(element);
            return new AddParticipantSucceeded(internalEvent);
        }
    }
}
