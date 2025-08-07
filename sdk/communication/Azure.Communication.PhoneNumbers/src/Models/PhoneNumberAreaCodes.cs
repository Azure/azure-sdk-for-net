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
    [CodeGenModel("PhoneNumberAreaCodes")]
    [CodeGenSuppress("PhoneNumberAreaCodes", typeof(IEnumerable<PhoneNumberAreaCode>))]
    [CodeGenSuppress("PhoneNumberAreaCodes", typeof(IReadOnlyList<PhoneNumberAreaCode>), typeof(string))]
    [CodeGenSuppress("AreaCodes", typeof(IReadOnlyList<PhoneNumberAreaCode>))]
    [CodeGenSuppress("NextLink", typeof(string))]
    [CodeGenSuppress("DeserializePhoneNumberAreaCodes", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    internal partial class PhoneNumberAreaCodes
    {
    }
}
