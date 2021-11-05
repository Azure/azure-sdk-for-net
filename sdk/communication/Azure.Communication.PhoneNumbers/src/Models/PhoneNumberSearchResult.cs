// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    public partial class PhoneNumberSearchResult
    {
        /// <summary> The date that this search result expires and phone numbers are no longer on hold. A search result expires in less than 15min, e.g. 2020-11-19T16:31:49.048Z. </summary>
        [CodeGenMember("SearchExpiresBy")]
        public DateTimeOffset SearchExpiresOn { get; }
    }
}
