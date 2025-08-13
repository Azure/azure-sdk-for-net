// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The remove participant succeeded event.
    /// </summary>
    public class RemoveParticipantSucceeded: CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of RemoveParticipantSucceededInternal. </summary>
        internal RemoveParticipantSucceeded()
        {
        }

        /// <summary> Initializes a new instance of RemoveParticipantSucceededInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the RemoveParticipantSucceededEvent. </param>
        internal RemoveParticipantSucceeded(RemoveParticipantSucceededInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participant = CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.Participant);
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Participant removed. </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary>
        /// Deserialize <see cref="RemoveParticipantSucceeded"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RemoveParticipantSucceeded"/> object.</returns>
        public static RemoveParticipantSucceeded Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = RemoveParticipantSucceededInternal.DeserializeRemoveParticipantSucceededInternal(element);
            return new RemoveParticipantSucceeded(internalEvent);
        }
    }
}
