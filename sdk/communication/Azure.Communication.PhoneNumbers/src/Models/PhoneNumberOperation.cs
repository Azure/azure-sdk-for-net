// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers
{
    [CodeGenModel("PhoneNumberOperation")]
    [CodeGenSuppress("PhoneNumberOperation")]
    [CodeGenSuppress("PhoneNumberOperation", typeof(PhoneNumberOperationType), typeof(PhoneNumberOperationStatus), typeof(DateTimeOffset), typeof(string))]
    [CodeGenSuppress("PhoneNumberOperation", typeof(PhoneNumberOperationType), typeof(PhoneNumberOperationStatus), typeof(string), typeof(DateTimeOffset), typeof(CommunicationError), typeof(string), typeof(DateTimeOffset?))]
    [CodeGenSuppress("OperationType")]
    [CodeGenSuppress("Status")]
    [CodeGenSuppress("ResourceLocation")]
    [CodeGenSuppress("CreatedDateTime")]
    [CodeGenSuppress("Error")]
    [CodeGenSuppress("Id")]
    [CodeGenSuppress("LastActionDateTime")]
    [CodeGenSuppress("DeserializePhoneNumberOperation", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    internal partial class PhoneNumberOperation
    {
    }
}
