// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfigurationNfvSubResource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ResourceUri))
            {
                writer.WritePropertyName("resourceUri"u8);
                writer.WriteStringValue(ResourceUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static RoutingConfigurationNfvSubResource DeserializeRoutingConfigurationNfvSubResource(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> resourceUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    resourceUri = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new RoutingConfigurationNfvSubResource(resourceUri.Value);
        }
    }
}
