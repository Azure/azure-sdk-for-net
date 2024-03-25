// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Capabilities of a phone number. </summary>
    public partial class PhoneNumberCapabilities
    {
        /// <summary> Initializes a new instance of <see cref="PurchasedPhoneNumberCapabilities"/>. </summary>
        /// <param name="calling"> Capability value for calling. </param>
        /// <param name="sms"> Capability value for SMS. </param>
        /// <param name="tenDLCCampaignBriefId"> Ten DLC campaign brief id attached to the number. </param>
        internal PhoneNumberCapabilities(PhoneNumberCapabilityType calling, PhoneNumberCapabilityType sms, string tenDLCCampaignBriefId)
        {
            Calling = calling;
            Sms = sms;
            TenDLCCampaignBriefId = tenDLCCampaignBriefId;
        }

        /// <summary> Ten DLC campaign brief id attached to the number. </summary>
        public string TenDLCCampaignBriefId { get; }
    }
}
