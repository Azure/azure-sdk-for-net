// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The cancel add participant operation options.
    /// </summary>
    public class CancelAddParticipantOperationOptions
    {
        /// <summary>
        /// Creates new CancelAddParticipantOptions object.
        /// </summary>
        /// <param name="invitationId"></param>
        public CancelAddParticipantOperationOptions(string invitationId)
        {
            InvitationId = invitationId;
        }

        /// <summary>
        /// Invitation ID used to add a participant.
        /// </summary>
        public string InvitationId { get; }

        /// <summary>
        /// The operationContext for this add participants call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
