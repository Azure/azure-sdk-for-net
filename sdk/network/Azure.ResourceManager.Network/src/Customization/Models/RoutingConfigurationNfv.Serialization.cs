// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfigurationNfv : IJsonModel<RoutingConfigurationNfv>
    {
        void IJsonModel<RoutingConfigurationNfv>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            writer.WriteStartObject();
            if (Optional.IsDefined(AssociatedRouteTable))
            {
                writer.WritePropertyName("associatedRouteTable"u8);
                writer.WriteObjectValue(AssociatedRouteTable, options);
            }
            if (Optional.IsDefined(PropagatedRouteTables))
            {
                writer.WritePropertyName("propagatedRouteTables"u8);
                writer.WriteObjectValue(PropagatedRouteTables, options);
            }
            if (Optional.IsDefined(InboundRouteMap))
            {
                writer.WritePropertyName("inboundRouteMap"u8);
                writer.WriteObjectValue(InboundRouteMap, options);
            }
            if (Optional.IsDefined(OutboundRouteMap))
            {
                writer.WritePropertyName("outboundRouteMap"u8);
                writer.WriteObjectValue(OutboundRouteMap, options);
            }
            writer.WriteEndObject();
        }

        RoutingConfigurationNfv IJsonModel<RoutingConfigurationNfv>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoutingConfigurationNfv(document.RootElement, options);
        }

        internal static RoutingConfigurationNfv DeserializeRoutingConfigurationNfv(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            ValidateFormat(options);
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RoutingConfigurationNfvSubResource associated = default;
            PropagatedRouteTableNfv propagated = default;
            RoutingConfigurationNfvSubResource inbound = default;
            RoutingConfigurationNfvSubResource outbound = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("associatedRouteTable"u8))
                {
                    associated = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value, options);
                }
                else if (property.NameEquals("propagatedRouteTables"u8))
                {
                    propagated = PropagatedRouteTableNfv.DeserializePropagatedRouteTableNfv(property.Value, options);
                }
                else if (property.NameEquals("inboundRouteMap"u8))
                {
                    inbound = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value, options);
                }
                else if (property.NameEquals("outboundRouteMap"u8))
                {
                    outbound = RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(property.Value, options);
                }
            }
            return new RoutingConfigurationNfv(associated, propagated, inbound, outbound);
        }

        BinaryData IPersistableModel<RoutingConfigurationNfv>.Write(ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<RoutingConfigurationNfv>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        RoutingConfigurationNfv IPersistableModel<RoutingConfigurationNfv>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRoutingConfigurationNfv(document.RootElement, options);
        }

        string IPersistableModel<RoutingConfigurationNfv>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static void ValidateFormat(ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfv)} does not support '{options.Format}' format.");
            }
        }
    }
}
