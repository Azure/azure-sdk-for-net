// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("AvailablePhoneNumber")]
    public partial class AvailablePhoneNumber
    {
        /// <summary> The ISO 3166-2 country code, e.g. US. </summary>
        public string CountryCode { get; }

        /// <summary> The phone number in E.164 format, e.g. +11234567890. </summary>
        public string PhoneNumber { get; }

        /// <summary> Capabilities of a phone number. </summary>
        public PhoneNumberCapabilities Capabilities { get; }

        /// <summary> Represents the number type of the offering. </summary>
        public PhoneNumberType PhoneNumberType { get; }

        /// <summary> Represents the assignment type of the offering. Also known as the use case. </summary>
        public PhoneNumberAssignmentType AssignmentType { get; }

        /// <summary> Contains error details in case of failure when reserving, releasing or purchasing the phone number. Note that this is ignored by the service when present in requests. </summary>
        public ResponseError Error { get; }

        /// <summary> Represents the status of the phone number. Possible values include: 'available', 'reserved', 'expired', 'error', 'purchased'. </summary>
        public PhoneNumberAvailabilityStatus Status { get; }

        /// <summary> Indicates if do not resell agreement is required. If true, the phone number cannot be acquired unless the customer provides explicit agreement to not resell it. </summary>
        public bool IsAgreementToNotResellRequired { get; }
    }
}
