// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.PhoneNumbers.Models
{
    /// <summary> Represents a phone number search options to find phone numbers. </summary>
    public class PhoneNumberSearchOptions
    {
        /// <summary> The area code of the desired phone number, e.g. 425. </summary>
        public string AreaCode { get; set; }

        /// <summary> The quantity of desired phone numbers. The default value is 1. </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// <summary> Initializes a new instance of PhoneNumberSearchOptions. </summary>
        /// </summary>
        /// <param name="areaCode"></param>
        /// <param name="quantity"></param>
        public PhoneNumberSearchOptions(string areaCode = null, int? quantity = null)
        {
            AreaCode = areaCode;
            Quantity = quantity;
        }
    }
}
