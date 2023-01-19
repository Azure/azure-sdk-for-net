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
        /// 
        /// </summary>
        /// <param name="targetPhoneNumberIdentity"></param>
        /// <param name="callerPhoneNumber"></param>
        public CallTarget(PhoneNumberIdentifier targetPhoneNumberIdentity, PhoneNumberIdentifier callerPhoneNumber)
        {
            TargetIdentity = targetPhoneNumberIdentity;
            CallerPhoneNumber = callerPhoneNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetPhoneNumber"></param>
        /// <param name="callerPhoneNumber"></param>
        public CallTarget(string targetPhoneNumber, string callerPhoneNumber)
        {
            TargetIdentity = new PhoneNumberIdentifier(targetPhoneNumber);
            CallerPhoneNumber = new PhoneNumberIdentifier(callerPhoneNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallTarget(CommunicationUserIdentifier targetIdentity)
        {
            TargetIdentity = targetIdentity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetIdentity"></param>
        public CallTarget(MicrosoftTeamsUserIdentifier targetIdentity)
        {
            TargetIdentity = targetIdentity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetRawId"></param>
        public CallTarget(string targetRawId)
        {
            TargetIdentity = CommunicationIdentifier.FromRawId(targetRawId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public CommunicationIdentifier TargetIdentity { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public PhoneNumberIdentifier CallerPhoneNumber { get; set; }
    }
}