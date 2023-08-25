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
            CustomContext = new CustomContext(sipHeaders: new Dictionary<string, string>(), null);
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(CommunicationUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomContext = new CustomContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomContext = new CustomContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// The target callee.
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier Target { get; }

        /// <summary>
        /// The operationContext for this transfer call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The Custom Context which contains SIP and voip headers
        /// </summary>
        public CustomContext CustomContext { get; }

        /// <summary>
        /// The callee that being transferred
        /// </summary>
        public CommunicationIdentifier Transferee { get; set; }

        /// <summary>
        /// The callback URI override for this transfer call request.
        /// </summary>
        public Uri CallbackUri { get; set; }
    }
}
