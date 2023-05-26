// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
        /// <param name="targetPhoneNumberIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(PhoneNumberIdentifier targetPhoneNumberIdentity)
        {
            Target = targetPhoneNumberIdentity;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(CommunicationUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
        }

        /// <summary>
        /// The target callee.
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier Target { get; }

        /// <summary>
        /// The callback URI override for this transfer call request.
        /// </summary>
        public Uri CallbackUri { get; set; }
    }
}
