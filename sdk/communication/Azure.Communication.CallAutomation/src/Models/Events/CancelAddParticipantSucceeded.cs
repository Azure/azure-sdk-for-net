// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Cancel add participants succeeded event.
    /// </summary>
    public class CancelAddParticipantSucceeded: CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CancelAddParticipantSucceededEventInternal. </summary>
        internal CancelAddParticipantSucceeded()
        {
        }

        /// <summary> Initializes a new instance of CancelAddParticipantSucceededEventInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the CancelAddParticipantSucceededEvent. </param>
        internal CancelAddParticipantSucceeded(CancelAddParticipantSucceededInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            InvitationId = internalEvent.InvitationId;
        }

        /// <summary> Invitation ID used to cancel the request. </summary>
        public string InvitationId { get; }

        /// <summary>
        /// Deserialize <see cref="CancelAddParticipantSucceeded"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CancelAddParticipantSucceeded"/> object.</returns>
        public static CancelAddParticipantSucceeded Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CancelAddParticipantSucceededInternal.DeserializeCancelAddParticipantSucceededInternal(element);
            return new CancelAddParticipantSucceeded(internalEvent);
        }
    }
}
