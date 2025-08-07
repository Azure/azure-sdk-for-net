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
    [CodeGenModel("PhoneNumberLocalities")]
    [CodeGenSuppress("PhoneNumberLocalities")]
    [CodeGenSuppress("PhoneNumberLocalities", typeof(IReadOnlyList<PhoneNumberLocality>), typeof(string))]
    [CodeGenSuppress("DeserializePhoneNumberLocalities", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    [CodeGenSuppress("PhoneNumberLocalitiesProperty", typeof(PhoneNumberLocality))]
    [CodeGenSuppress("NextLink", typeof(string))]
    internal partial class PhoneNumberLocalities
    {
    }
}
