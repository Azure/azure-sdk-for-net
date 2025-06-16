// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(ManagedServiceIdentity))]
    [JsonSerializable(typeof(ManagedServiceIdentityType))]
    [JsonSerializable(typeof(UserAssignedIdentity))]
    [JsonSerializable(typeof(ArmEnvironment))]
    [JsonSerializable(typeof(Dictionary<string, Dictionary<string, JsonElement>>))]
    internal partial class AzureResourceManagerJsonContext : JsonSerializerContext
    {
    }
}
