// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    public partial class PhoneNumberCost
    {
        /// <summary> The ISO 4217 currency code for the cost amount, e.g. USD. </summary>
        [CodeGenMember("CurrencyCode")]
        public string IsoCurrencySymbol { get; }
    }
}
