// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Cancel add participant failed event.
    /// </summary>
    public class CancelAddParticipantFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CancelAddParticipantFailedEvent. </summary>
        internal CancelAddParticipantFailed()
        {
        }

        /// <summary> Initializes a new instance of CancelAddParticipantFailed event. </summary>
        /// <param name="internalEvent">Internal Representation of the CancelAddParticipantFailed. </param>
        internal CancelAddParticipantFailed(CancelAddParticipantFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            InvitationId = internalEvent.InvitationId;
        }

        /// <summary> Invitation ID used to cancel the request. </summary>
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
