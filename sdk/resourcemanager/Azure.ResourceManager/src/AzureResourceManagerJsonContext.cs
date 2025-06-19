// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(ArmEnvironment))]
    [JsonSerializable(typeof(Dictionary<string, Dictionary<string, JsonElement>>))]
    [JsonSerializable(typeof(Dictionary<string, object>))]
    [JsonSerializable(typeof(List<string>))]
    internal partial class AzureResourceManagerJsonContext : JsonSerializerContext
    {
    }
}
