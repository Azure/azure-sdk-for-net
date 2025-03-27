// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Communication.PhoneNumbers
{
    public static partial class PhoneNumbersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PhoneNumbers.PhoneNumberSearchResult"/>. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="phoneNumbers"> The phone numbers that are available. Can be fewer than the desired search quantity. </param>
        /// <param name="phoneNumberType"> The phone number's type, e.g. geographic, or tollFree. </param>
        /// <param name="assignmentType"> Phone number's assignment type. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="cost"> The incurred cost for a single phone number. </param>
        /// <param name="searchExpiresOn"> The date that this search result expires and phone numbers are no longer on hold. A search result expires in less than 15min, e.g. 2020-11-19T16:31:49.048Z. </param>
        /// <param name="errorCode"> The error code of the search. </param>
        /// <param name="error"> Mapping Error Messages to Codes. </param>
        /// <returns> A new <see cref="PhoneNumbers.PhoneNumberSearchResult"/> instance for mocking. </returns>
        public static PhoneNumberSearchResult PhoneNumberSearchResult(string searchId = null, IEnumerable<string> phoneNumbers = null, PhoneNumberType phoneNumberType = default, PhoneNumberAssignmentType assignmentType = default, PhoneNumberCapabilities capabilities = null, PhoneNumberCost cost = null, DateTimeOffset searchExpiresOn = default, int? errorCode = null, PhoneNumberSearchResultError? error = null)
        {
            phoneNumbers ??= new List<string>();

            return new PhoneNumberSearchResult(
                searchId,
                phoneNumbers?.ToList(),
                phoneNumberType,
                assignmentType,
                capabilities,
                cost,
                searchExpiresOn,
                false,
                errorCode,
                error);
        }
    }
}
