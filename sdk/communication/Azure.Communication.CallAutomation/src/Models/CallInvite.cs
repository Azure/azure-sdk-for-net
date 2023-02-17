// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Call invitee details.
    /// </summary>
    public class CallInvite
    {
        /// <summary>
        /// Creates a new CallInvite object.
        /// </summary>
        /// <param name="targetPhoneNumberIdentity"></param>
        /// <param name="callerIdNumber"></param>
        /// /// <param name="sipHeaders"></param>
        public CallInvite(PhoneNumberIdentifier targetPhoneNumberIdentity, PhoneNumberIdentifier callerIdNumber, IDictionary<string, string> sipHeaders = null)
        {
            Target = targetPhoneNumberIdentity;
            SourceCallerIdNumber = callerIdNumber;
            SipHeaders= sipHeaders;
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// </summary>
        /// <param name="targetIdentity"></param>
        /// <param name="voipHeaders"></param>
        public CallInvite(CommunicationUserIdentifier targetIdentity, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetIdentity;
            VoipHeaders= voipHeaders;
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// </summary>
        /// <param name="targetIdentity"></param>
        /// <param name="voipHeaders"></param>
        public CallInvite(MicrosoftTeamsUserIdentifier targetIdentity, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetIdentity;
            VoipHeaders = voipHeaders;
        }

        /// <summary>
        /// The target callee.
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier Target { get; }

        /// <summary>
        /// The caller ID number to appear on target PSTN callee.
        /// </summary>
        /// <value></value>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; }

        /// <summary> Dictionary of VOIP headers. </summary>
        public IDictionary<string, string> VoipHeaders { get; }

        /// <summary> Dictionary of SIP headers. </summary>
        public IDictionary<string, string> SipHeaders { get; }

        /// <summary>
        /// The display name to appear on target callee.
        /// </summary>
        /// <value></value>
        public string SourceDisplayName { get; set; }
    }
}
