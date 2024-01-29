// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class PropagatedRouteTableNfv : IUtf8JsonSerializable, IJsonModel<PropagatedRouteTableNfv>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PropagatedRouteTableNfv>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PropagatedRouteTableNfv>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PropagatedRouteTableNfv>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PropagatedRouteTableNfv)} does not support '{format}' format.");
            }

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

        PropagatedRouteTableNfv IJsonModel<PropagatedRouteTableNfv>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PropagatedRouteTableNfv>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PropagatedRouteTableNfv)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePropagatedRouteTableNfv(document.RootElement, options);
        }

        internal static PropagatedRouteTableNfv DeserializePropagatedRouteTableNfv(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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

        BinaryData IPersistableModel<PropagatedRouteTableNfv>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PropagatedRouteTableNfv>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(PropagatedRouteTableNfv)} does not support '{options.Format}' format.");
            }
        }

        PropagatedRouteTableNfv IPersistableModel<PropagatedRouteTableNfv>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PropagatedRouteTableNfv>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePropagatedRouteTableNfv(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PropagatedRouteTableNfv)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PropagatedRouteTableNfv>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
