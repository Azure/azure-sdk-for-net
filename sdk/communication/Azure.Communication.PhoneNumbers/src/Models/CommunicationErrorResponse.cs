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
    [CodeGenModel("CommunicationErrorResponse")]
    [CodeGenSuppress("CommunicationErrorResponse", typeof(CommunicationError))]
    [CodeGenSuppress("Error", typeof(CommunicationError))]
    [CodeGenSuppress("DeserializeCommunicationErrorResponse", typeof(JsonElement))]
    [CodeGenSuppress("FromResponse", typeof(Response))]
    internal partial class CommunicationErrorResponse
    {
    }
}
