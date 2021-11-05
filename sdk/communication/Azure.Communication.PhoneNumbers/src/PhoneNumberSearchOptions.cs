// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary> Represents a phone number search options to find phone numbers. </summary>
    public class PhoneNumberSearchOptions
    {
        /// <summary> The area code of the desired phone number, e.g. 425. </summary>
        public string AreaCode { get; set; }

        /// <summary> The quantity of desired phone numbers. The default value is 1. </summary>
        public int? Quantity { get; set; }
    }
}
