// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The transfer call to participant operation options.
    /// </summary>
    public class TransferToParticipantOptions
    {
        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="callInvite"></param>
        public TransferToParticipantOptions(CallInvite callInvite)
        {
            CallInvite = callInvite;
        }

        /// <summary>
        /// Call invitee information.
        /// </summary>
        public CallInvite CallInvite { get; }

        /// <summary>
        /// The UserToUserInformation.
        /// </summary>
        public string UserToUserInformation { get; set; }

        /// <summary>
        /// The operationContext for this transfer call.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
