// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The cancel add participant failed event.
    /// </summary>
    public class CancelAddParticipantFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CancelAddParticipantFailedEvent. </summary>
        internal CancelAddParticipantFailed()
        {
        }

        /// <summary> Initializes a new instance of CancelAddParticipantFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the CancelAddParticipantFailedEvent. </param>
        internal CancelAddParticipantFailed(CancelAddParticipantFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            InvitationId = internalEvent.InvitationId;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary>
        /// Invitation ID used to cancel the invitation.
        /// </summary>
        public string InvitationId { get; }

        /// <summary>
        /// Deserialize <see cref="CancelAddParticipantFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CancelAddParticipantFailed"/> object.</returns>
        public static CancelAddParticipantFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CancelAddParticipantFailedInternal.DeserializeCancelAddParticipantFailedInternal(element);
            return new CancelAddParticipantFailed(internalEvent);
        }
    }
}
