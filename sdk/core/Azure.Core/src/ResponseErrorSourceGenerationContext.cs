// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure
{
#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ResponseError))]
    [JsonSerializable(typeof(RequestFailedException.ErrorResponse))]
    [JsonSerializable(typeof(ResponseInnerError))]
    [JsonSerializable(typeof(JsonElement))]
    [JsonSerializable(typeof(JsonDocument))]
    [JsonSerializable(typeof(JsonValueKind))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(bool))]
    [JsonSerializable(typeof(List<ResponseError>))]
    internal partial class ResponseErrorSourceGenerationContext : JsonSerializerContext
    {
    }
#endif
}
