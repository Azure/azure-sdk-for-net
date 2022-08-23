// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    public abstract partial class TargetServiceBaseInfo : IUtf8JsonSerializable
    {
        internal static TargetServiceBaseInfo DeserializeTargetServiceBaseInfo(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "AzureResource": return AzureResourceInfo.DeserializeAzureResourceInfo(element);
                    case "ConfluentBootstrapServer": return ConfluentBootstrapServerInfo.DeserializeConfluentBootstrapServerInfo(element);
                    case "ConfluentSchemaRegistry": return ConfluentSchemaRegistryInfo.DeserializeConfluentSchemaRegistryInfo(element);
                }
            }
            throw new JsonException($"The deserialization of {typeof(TargetServiceBaseInfo)} failed because of the invalid discriminator value.");
        }
    }
}
