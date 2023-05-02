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
        /// <param name="sipHeaders"> Custom Context Sip headers. </param>
        public TransferToParticipantOptions(PhoneNumberIdentifier targetPhoneNumberIdentity, IDictionary<string, string> sipHeaders = null)
        {
            Target = targetPhoneNumberIdentity;
            SipHeaders = sipHeaders == null ? new Dictionary<string, string>() : sipHeaders;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        /// <param name="voipHeaders"> Custom Context Voip headers. </param>
        public TransferToParticipantOptions(CommunicationUserIdentifier targetIdentity, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetIdentity;
            VoipHeaders = voipHeaders == null ? new Dictionary<string, string>() : voipHeaders;
        }

        /// <summary>
        /// Creates a new TransferToParticipantOptions object.
        /// </summary>
        /// <param name="targetIdentity"> The target to transfer the call to. </param>
        /// <param name="voipHeaders"> Custom Context Voip headers. </param>
        public TransferToParticipantOptions(MicrosoftTeamsUserIdentifier targetIdentity, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetIdentity;
            VoipHeaders = voipHeaders == null ? new Dictionary<string, string>() : voipHeaders;
        }

        /// <summary>
        /// The target callee.
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier Target { get; }

        /// <summary> Dictionary of VOIP headers. </summary>
        public IDictionary<string, string> VoipHeaders { get; }

        /// <summary> Dictionary of SIP headers. </summary>
        public IDictionary<string, string> SipHeaders { get; }

        /// <summary>
        /// The operationContext for this transfer call.
        /// </summary>
        public string OperationContext { get; set; }
    }
}
