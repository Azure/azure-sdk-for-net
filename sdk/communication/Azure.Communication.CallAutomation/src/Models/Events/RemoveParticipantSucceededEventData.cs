// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The remove participant succeeded event.
    /// </summary>
    public class RemoveParticipantSucceededEventData: CallAutomationEventData
    {
        /// <summary> Initializes a new instance of RemoveParticipantSucceededInternal. </summary>
        internal RemoveParticipantSucceededEventData()
        {
        }

        /// <summary> Initializes a new instance of RemoveParticipantSucceededInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the RemoveParticipantSucceededEvent. </param>
        internal RemoveParticipantSucceededEventData(RemoveParticipantSucceededInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant removed. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="RemoveParticipantSucceededEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RemoveParticipantSucceededEventData"/> object.</returns>
        public static RemoveParticipantSucceededEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = RemoveParticipantSucceededInternal.DeserializeRemoveParticipantSucceededInternal(element);
            return new RemoveParticipantSucceededEventData(internalEvent);
        }
    }
}
