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
        /// <param name="targetParticipant"></param>
        /// <param name="callerIdNumber"></param>
        /// /// <param name="sipHeaders"></param>
        public CallInvite(PhoneNumberIdentifier targetParticipant, PhoneNumberIdentifier callerIdNumber, IDictionary<string, string> sipHeaders = null)
        {
            Target = targetParticipant;
            SourceCallerIdNumber = callerIdNumber;
            SipHeaders= sipHeaders == null ? new Dictionary<string, string>() : sipHeaders;
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// </summary>
        /// <param name="targetParticipant"></param>
        /// <param name="voipHeaders"></param>
        public CallInvite(CommunicationUserIdentifier targetParticipant, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetParticipant;
            VoipHeaders= voipHeaders == null ? new Dictionary<string, string>() : voipHeaders;
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// </summary>
        /// <param name="targetParticipant"></param>
        /// <param name="voipHeaders"></param>
        public CallInvite(MicrosoftTeamsUserIdentifier targetParticipant, IDictionary<string, string> voipHeaders = null)
        {
            Target = targetParticipant;
            VoipHeaders = voipHeaders == null ? new Dictionary<string, string>() : voipHeaders;
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
