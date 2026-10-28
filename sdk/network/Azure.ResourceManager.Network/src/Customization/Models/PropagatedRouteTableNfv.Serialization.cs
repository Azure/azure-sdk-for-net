// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class PropagatedRouteTableNfv : IJsonModel<PropagatedRouteTableNfv>
    {
        void IJsonModel<PropagatedRouteTableNfv>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Labels))
            {
                writer.WritePropertyName("labels"u8);
                writer.WriteStartArray();
                foreach (string item in Labels)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Ids))
            {
                writer.WritePropertyName("ids"u8);
                writer.WriteStartArray();
                foreach (RoutingConfigurationNfvSubResource item in Ids)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        PropagatedRouteTableNfv IJsonModel<PropagatedRouteTableNfv>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePropagatedRouteTableNfv(document.RootElement, options);
        }

        internal static PropagatedRouteTableNfv DeserializePropagatedRouteTableNfv(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            ValidateFormat(options);
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> labels = new ChangeTrackingList<string>();
            IList<RoutingConfigurationNfvSubResource> ids = new ChangeTrackingList<RoutingConfigurationNfvSubResource>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                if (property.NameEquals("labels"u8))
                {
                    labels = new List<string>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        labels.Add(item.GetString());
                    }
                }
                else if (property.NameEquals("ids"u8))
                {
                    ids = new List<RoutingConfigurationNfvSubResource>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        ids.Add(RoutingConfigurationNfvSubResource.DeserializeRoutingConfigurationNfvSubResource(item, options));
                    }
                }
            }
            return new PropagatedRouteTableNfv(labels, ids);
        }

        BinaryData IPersistableModel<PropagatedRouteTableNfv>.Write(ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<PropagatedRouteTableNfv>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        PropagatedRouteTableNfv IPersistableModel<PropagatedRouteTableNfv>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePropagatedRouteTableNfv(document.RootElement, options);
        }

        string IPersistableModel<PropagatedRouteTableNfv>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static void ValidateFormat(ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(PropagatedRouteTableNfv)} does not support '{options.Format}' format.");
            }
        }
    }
}
