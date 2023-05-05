// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The remove participant failed event.
    /// </summary>
    public class RemoveParticipantFailedEventData : CallAutomationEventData
    {
        /// <summary> Initializes a new instance of RemoveParticipantFailedEvent. </summary>
        internal RemoveParticipantFailedEventData()
        {
        }

        /// <summary> Initializes a new instance of RemoveParticipantFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the RemoveParticipantFailedEvent. </param>
        internal RemoveParticipantFailedEventData(RemoveParticipantFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant failed to be removed. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="RemoveParticipantFailedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RemoveParticipantFailedEventData"/> object.</returns>
        public static RemoveParticipantFailedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = RemoveParticipantFailedInternal.DeserializeRemoveParticipantFailedInternal(element);
            return new RemoveParticipantFailedEventData(internalEvent);
        }
    }
}
