// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Common.Custom.Models
{
    [JsonSourceGenerationOptions(WriteIndented = true)]
    [JsonSerializable(typeof(ManagedServiceIdentity))]
    [JsonSerializable(typeof(ManagedServiceIdentityType))]
    [JsonSerializable(typeof(UserAssignedIdentity))]
    internal partial class AzureResourceManagerJsonSerializerContext : JsonSerializerContext
    {
    }
}
