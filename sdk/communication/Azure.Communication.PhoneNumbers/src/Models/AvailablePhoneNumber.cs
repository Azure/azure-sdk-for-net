// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("AvailablePhoneNumber")]
    public partial class AvailablePhoneNumber
    {
        /// <summary> The ISO 3166-2 country code, e.g. US. </summary>
        [CodeGenMember("CountryCode")]
        public string CountryCode { get; }

        /// <summary> The phone number in E.164 format, e.g. +11234567890. </summary>
        [CodeGenMember("PhoneNumber")]
        public string PhoneNumber { get; }

        /// <summary> Capabilities of a phone number. </summary>
        [CodeGenMember("Capabilities")]
        public PhoneNumberCapabilities Capabilities { get; }

        /// <summary> Represents the number type of the offering. </summary>
        [CodeGenMember("PhoneNumberType")]
        public PhoneNumberType PhoneNumberType { get; }

        /// <summary> Contains error details in case of failure when reserving, releasing or purchasing the phone number. Note that this is ignored by the service when present in requests. </summary>
        [CodeGenMember("Error")]
        public ResponseError Error { get; }
    }
}
