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
        /// <param name="targetPhoneNumberIdentity"> The target where the call should be transferred to. </param>
        public TransferToParticipantOptions(PhoneNumberIdentifier targetPhoneNumberIdentity)
        {
            Target = targetPhoneNumberIdentity;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target where the call should be transferred to. </param>
        public TransferToParticipantOptions(CommunicationUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target where the call should be transferred to. </param>
        public TransferToParticipantOptions(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
        }

        /// <summary>
        /// The identity of the target where the call should be transferred to.
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier Target { get; }

        /// <summary>
        /// The operationContext for this transfer call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Transferee is the participant who is transferred away.
        /// </summary>
        public CommunicationIdentifier Transferee { get; set; }

        /// <summary>
        /// The Custom Context which contains SIP and voip headers
        /// </summary>
        public CustomContext CustomContext { get; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
