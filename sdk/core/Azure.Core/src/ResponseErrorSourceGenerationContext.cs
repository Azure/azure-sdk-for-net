// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure
{
#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ResponseError))]
    [JsonSerializable(typeof(ResponseInnerError))]
    [JsonSerializable(typeof(JsonElement))]
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(IReadOnlyList<ResponseError>))]
    internal partial class ResponseErrorSourceGenerationContext : JsonSerializerContext
    {
    }
#endif
}
