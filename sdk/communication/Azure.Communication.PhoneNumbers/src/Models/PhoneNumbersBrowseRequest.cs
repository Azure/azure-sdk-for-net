// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumbersBrowseRequest")]
    [CodeGenSuppress("PhoneNumbersBrowseRequest", typeof(PhoneNumberType))]
    [CodeGenSuppress("PhoneNumbersBrowseRequest", typeof(PhoneNumberType), typeof(PhoneNumberBrowseCapabilitiesRequest), typeof(PhoneNumberAssignmentType?), typeof(IList<string>))]
    public partial class PhoneNumbersBrowseRequest
    {
        // For (de)serialization to work as expected with the generated client, we need a ChangeTrackingList.
        // However, we don't want to expose this type in the public API. Because of this, we use a private field and a public property backed by this field.
        private ChangeTrackingList<string> _phoneNumberPrefixes;

        /// <summary>
        /// Creates a new instance of <see cref="PhoneNumbersBrowseRequest"/>.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="phoneNumberType"></param>
        public PhoneNumbersBrowseRequest(string countryCode, PhoneNumberType phoneNumberType)
        {
            CountryCode = countryCode;
            PhoneNumberType = phoneNumberType;
            _phoneNumberPrefixes = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Two-letter ISO 3166-1 alpha-2 country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The phone number prefix to match. If specified, the search will be limited to phone numbers that start with the any of the given prefixes.
        /// </summary>
        public IList<string> PhoneNumberPrefixes
        {
            get { return _phoneNumberPrefixes; }
            set
            {
                _phoneNumberPrefixes = new ChangeTrackingList<string>(value);
            }
        }

        /// <summary>
        /// The minimum desired capabilities for the browse operation request.
        /// </summary>
        public PhoneNumberCapabilities Capabilities { get; set; }
    }
}
