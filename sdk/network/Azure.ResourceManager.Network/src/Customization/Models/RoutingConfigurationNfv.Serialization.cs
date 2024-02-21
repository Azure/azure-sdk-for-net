// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfigurationNfv : IUtf8JsonSerializable, IJsonModel<RoutingConfigurationNfv>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RoutingConfigurationNfv>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RoutingConfigurationNfv>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfv>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfv)} does not support '{format}' format.");
            }

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

        RoutingConfigurationNfv IJsonModel<RoutingConfigurationNfv>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfv>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfv)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoutingConfigurationNfv(document.RootElement, options);
        }

        internal static RoutingConfigurationNfv DeserializeRoutingConfigurationNfv(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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

        BinaryData IPersistableModel<RoutingConfigurationNfv>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfv>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RoutingConfigurationNfv)} does not support '{options.Format}' format.");
            }
        }

        RoutingConfigurationNfv IPersistableModel<RoutingConfigurationNfv>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfv>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRoutingConfigurationNfv(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RoutingConfigurationNfv)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RoutingConfigurationNfv>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
