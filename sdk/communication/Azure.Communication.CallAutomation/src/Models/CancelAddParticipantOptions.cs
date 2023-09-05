// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The cancel add participant operation options.
    /// </summary>
    public class CancelAddParticipantOptions
    {
        /// <summary>
        /// Creates new CancelAddParticipantOptions object.
        /// </summary>
        /// <param name="invitationId"></param>
        public CancelAddParticipantOptions(string invitationId)
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
        /// The callback URI override for this transfer call request.
        /// </summary>
        public Uri CallbackUri { get; set; }
    }
}
