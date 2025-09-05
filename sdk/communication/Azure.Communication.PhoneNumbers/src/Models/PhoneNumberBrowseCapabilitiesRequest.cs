// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersBrowseCapabilitiesRequest")]
    [CodeGenSuppress("PhoneNumbersBrowseCapabilitiesRequest")]
    [CodeGenSuppress("PhoneNumbersBrowseCapabilitiesRequest", typeof(PhoneNumberCapabilityType), typeof(PhoneNumberCapabilityType))]
    internal partial class PhoneNumberBrowseCapabilitiesRequest
    {
        /// <summary> Capability value for calling. </summary>
        internal PhoneNumberCapabilityType? Calling { get; set; }
        /// <summary> Capability value for SMS. </summary>
        internal PhoneNumberCapabilityType? Sms { get; set; }
    }
}
