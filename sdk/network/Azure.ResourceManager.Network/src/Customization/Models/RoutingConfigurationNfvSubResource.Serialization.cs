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
    public partial class RoutingConfigurationNfvSubResource : IJsonModel<RoutingConfigurationNfvSubResource>
    {
        void IJsonModel<RoutingConfigurationNfvSubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            writer.WriteStartObject();
            if (Optional.IsDefined(ResourceUri))
            {
                writer.WritePropertyName("resourceUri"u8);
                writer.WriteStringValue(ResourceUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        RoutingConfigurationNfvSubResource IJsonModel<RoutingConfigurationNfvSubResource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
        }

        internal static RoutingConfigurationNfvSubResource DeserializeRoutingConfigurationNfvSubResource(JsonElement element, ModelReaderWriterOptions options = null)
        {
            ValidateFormat(options ?? new ModelReaderWriterOptions("W"));
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri resourceUri = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceUri"u8) && property.Value.ValueKind != JsonValueKind.Null)
                {
                    resourceUri = new Uri(property.Value.GetString());
                }
            }
            return new RoutingConfigurationNfvSubResource(resourceUri);
        }

        BinaryData IPersistableModel<RoutingConfigurationNfvSubResource>.Write(ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using MemoryStream stream = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<RoutingConfigurationNfvSubResource>)this).Write(writer, options);
            }
            return new BinaryData(stream.ToArray());
        }

        RoutingConfigurationNfvSubResource IPersistableModel<RoutingConfigurationNfvSubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
        }

        string IPersistableModel<RoutingConfigurationNfvSubResource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static void ValidateFormat(ModelReaderWriterOptions options)
        {
            if (options.Format != "J" && options.Format != "W")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfvSubResource)} does not support '{options.Format}' format.");
            }
        }
    }
}
