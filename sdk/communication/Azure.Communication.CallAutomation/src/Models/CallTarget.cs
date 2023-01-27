// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Call target class
    /// </summary>
    public class CallTarget
    {
        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targetPhoneNumberIdentity"></param>
        /// <param name="callerIdNumber"></param>
        public CallTarget(PhoneNumberIdentifier targetPhoneNumberIdentity, PhoneNumberIdentifier callerIdNumber)
        {
            TargetIdentity = targetPhoneNumberIdentity;
            SourceCallerIdNumber = callerIdNumber;
        }

        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targetPhoneNumber"></param>
        /// <param name="callerIdNumber"></param>
        public CallTarget(string targetPhoneNumber, string callerIdNumber)
        {
            TargetIdentity = new PhoneNumberIdentifier(targetPhoneNumber);
            SourceCallerIdNumber = new PhoneNumberIdentifier(callerIdNumber);
        }

        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallTarget(CommunicationUserIdentifier targetIdentity)
        {
            TargetIdentity = targetIdentity;
        }

        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallTarget(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            TargetIdentity = targetIdentity;
        }

        /// <summary>
        /// Summary
        /// </summary>
        /// <param name="targetRawId"></param>
        public CallTarget(string targetRawId)
        {
            TargetIdentity = CommunicationIdentifier.FromRawId(targetRawId);
        }

        /// <summary>
        /// Summary
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier TargetIdentity { get; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string SourceDisplayName { get; set; }

        /// <summary>
        /// (Optional) The identifier of the source of the call for this invite operation. If SourceDisplayName
        /// is not set, the display name of the source will be used by default when adding a PSTN participant or teams user.
        /// </summary>
        public CommunicationIdentifier SourceIdentifier { get; set; }

        /// <summary>
        /// TODO: Combine this with SourceIdentifier
        /// </summary>
        /// <value></value>
        internal PhoneNumberIdentifier SourceCallerIdNumber { get; set; }

        /// <summary> Used by customer to pass in context to targets. </summary>
        public CustomContext CustomContext { get; set; }
    }
}
