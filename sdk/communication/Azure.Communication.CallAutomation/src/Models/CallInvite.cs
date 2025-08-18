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
        /// When the source of the call is a Teams App source, callerIdNumber is not supported and should be null.
        /// Sip Headers are supported for PSTN calls only. Voip Headers are not supported.
        /// </summary>
        /// <param name="targetPhoneNumberIdentity"></param>
        /// <param name="callerIdNumber"></param>
        public CallInvite(PhoneNumberIdentifier targetPhoneNumberIdentity, PhoneNumberIdentifier callerIdNumber)
        {
            Target = targetPhoneNumberIdentity;
            SourceCallerIdNumber = callerIdNumber;
            CustomCallingContext = new CustomCallingContext(sipHeaders: new Dictionary<string, string>(), voipHeaders: null);
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// Sip Headers are not supported. Voip Headers are supported for ACS Users.
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallInvite(CommunicationUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomCallingContext = new CustomCallingContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// Sip Headers are not supported. Voip Headers are supported for Microsoft teams Users.
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallInvite(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            Target = targetIdentity;
            CustomCallingContext = new CustomCallingContext(sipHeaders: null, voipHeaders: new Dictionary<string, string>());
        }

        /// <summary>
        /// Creates a new CallInvite object.
        /// Sip Headers are not supported. Voip Headers are supported for Microsoft Teams Apps.
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallInvite(TeamsExtensionUserIdentifier targetIdentity)
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
        /// The caller ID number to appear on target PSTN callee.
        /// </summary>
        /// <value></value>
        public PhoneNumberIdentifier SourceCallerIdNumber { get; set;  }

        /// <summary>
        /// The display name to appear on target callee.
        /// </summary>
        /// <value></value>
        public string SourceDisplayName { get; set; }

        /// <summary>
        /// The Custom Context which contains SIP and voip headers
        /// </summary>
        public CustomCallingContext CustomCallingContext { get; }
    }
}
