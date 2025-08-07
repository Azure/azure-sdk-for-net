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
    [CodeGenModel("PhoneNumberCountries")]
    [CodeGenSuppress("PhoneNumberCountries")]
    [CodeGenSuppress("PhoneNumberCountries", typeof(IEnumerable<PhoneNumberCountry>))]
    [CodeGenSuppress("PhoneNumberCountries", typeof(IReadOnlyList<PhoneNumberCountry>), typeof(string))]
    [CodeGenSuppress("DeserializePhoneNumberCountries", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("Countries", typeof(IReadOnlyList<PhoneNumberCountry>))]
    [CodeGenSuppress("NextLink", typeof(string))]
    internal partial class PhoneNumberCountries
    {
    }
}
