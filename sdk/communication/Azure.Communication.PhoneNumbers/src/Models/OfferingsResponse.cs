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
    [CodeGenModel("OfferingsResponse")]
    [CodeGenSuppress("OfferingsResponse")]
    [CodeGenSuppress("OfferingsResponse", typeof(IReadOnlyList<PhoneNumberOffering>), typeof(string))]
    [CodeGenSuppress("DeserializeOfferingsResponse", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("PhoneNumberOfferings", typeof(IReadOnlyList<PhoneNumberOffering>))]
    [CodeGenSuppress("NextLink", typeof(string))]
    internal partial class OfferingsResponse
    {
    }
}
