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
            CustomCallingContext = new CustomCallingContext(sipHeaders: new Dictionary<string, string>(), voipHeaders: null);
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(CommunicationUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomCallingContext = new CustomCallingContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomCallingContext = new CustomCallingContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        public TransferToParticipantOptions(TeamsExtensionUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomCallingContext = new CustomCallingContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
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
        public CustomCallingContext CustomCallingContext { get; }

        /// <summary>
        /// The callee that being transferred
        /// </summary>
        public CommunicationIdentifier Transferee { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }

        /// <summary>
        /// The phone number that will be used as the transferor(Contoso) caller id when transfering a call a pstn target.
        /// </summary>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; set; }
    }
}
