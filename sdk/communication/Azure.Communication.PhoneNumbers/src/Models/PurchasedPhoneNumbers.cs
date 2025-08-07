// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PurchasedPhoneNumbers")]
    [CodeGenSuppress("PurchasedPhoneNumbers", typeof(IEnumerable<PurchasedPhoneNumber>))]
    [CodeGenSuppress("PurchasedPhoneNumbers", typeof(IReadOnlyList<PurchasedPhoneNumber>), typeof(string))]
    [CodeGenSuppress("DeserializePurchasedPhoneNumbers", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("PhoneNumbers", typeof(IReadOnlyList<PhoneNumberCountry>))]
    [CodeGenSuppress("NextLink", typeof(string))]
    internal partial class PurchasedPhoneNumbers
    {
    }
}
