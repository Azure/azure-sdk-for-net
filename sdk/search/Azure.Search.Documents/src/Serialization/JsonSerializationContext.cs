// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.GeoJson;

namespace Azure.Search.Documents
{
    [JsonSerializable(typeof(GeoPoint))]
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    internal partial class JsonSerializationContext : JsonSerializerContext
    {
    }
}
