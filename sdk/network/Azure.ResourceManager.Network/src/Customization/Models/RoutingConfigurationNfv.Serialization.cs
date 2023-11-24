// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfigurationNfv : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(AssociatedRouteTable))
            {
                writer.WritePropertyName("associatedRouteTable"u8);
                writer.WriteObjectValue(AssociatedRouteTable);
            }
            if (Optional.IsDefined(PropagatedRouteTables))
            {
                writer.WritePropertyName("propagatedRouteTables"u8);
                writer.WriteObjectValue(PropagatedRouteTables);
            }
            if (Optional.IsDefined(InboundRouteMap))
            {
                writer.WritePropertyName("inboundRouteMap"u8);
                writer.WriteObjectValue(InboundRouteMap);
            }
            if (Optional.IsDefined(OutboundRouteMap))
            {
                writer.WritePropertyName("outboundRouteMap"u8);
                writer.WriteObjectValue(OutboundRouteMap);
            }
            writer.WriteEndObject();
        }

        internal static RoutingConfigurationNfv DeserializeRoutingConfigurationNfv(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<RoutingConfigurationNfvSubResource> associatedRouteTable = default;
            Optional<PropagatedRouteTableNfv> propagatedRouteTables = default;
            Optional<RoutingConfigurationNfvSubResource> inboundRouteMap = default;
            Optional<RoutingConfigurationNfvSubResource> outboundRouteMap = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("associatedRouteTable"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    associatedRouteTable = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value);
                    continue;
                }
                if (property.NameEquals("propagatedRouteTables"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propagatedRouteTables = PropagatedRouteTableNfv.DeserializePropagatedRouteTableNfv(property.Value);
                    continue;
                }
                if (property.NameEquals("inboundRouteMap"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inboundRouteMap = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value);
                    continue;
                }
                if (property.NameEquals("outboundRouteMap"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    outboundRouteMap = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value);
                    continue;
                }
            }
            return new RoutingConfigurationNfv(associatedRouteTable.Value, propagatedRouteTables.Value, inboundRouteMap.Value, outboundRouteMap.Value);
        }
    }
}
