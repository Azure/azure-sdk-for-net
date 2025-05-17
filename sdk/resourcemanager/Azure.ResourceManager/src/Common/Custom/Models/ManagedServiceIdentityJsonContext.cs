// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.ResourceManager.Models
{
    [JsonSourceGenerationOptions(WriteIndented = false)]
    [JsonSerializable(typeof(ManagedServiceIdentity))]
    [JsonSerializable(typeof(ManagedServiceIdentityType))]
    [JsonSerializable(typeof(UserAssignedIdentity))]
    internal partial class ManagedServiceIdentityJsonContext : JsonSerializerContext
    {
    }
}
