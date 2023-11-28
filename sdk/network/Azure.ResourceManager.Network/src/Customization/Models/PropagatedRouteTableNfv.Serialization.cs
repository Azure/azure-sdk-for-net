// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class PropagatedRouteTableNfv : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Labels))
            {
                writer.WritePropertyName("labels"u8);
                writer.WriteStartArray();
                foreach (var item in Labels)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Ids))
            {
                writer.WritePropertyName("ids"u8);
                writer.WriteStartArray();
                foreach (var item in Ids)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static PropagatedRouteTableNfv DeserializePropagatedRouteTableNfv(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> labels = default;
            Optional<IList<RoutingConfigurationNfvSubResource>> ids = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("labels"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    labels = array;
                    continue;
                }
                if (property.NameEquals("ids"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<RoutingConfigurationNfvSubResource> array = new List<RoutingConfigurationNfvSubResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(item));
                    }
                    ids = array;
                    continue;
                }
            }
            return new PropagatedRouteTableNfv(Optional.ToList(labels), Optional.ToList(ids));
        }
    }
}
