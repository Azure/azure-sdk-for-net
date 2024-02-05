// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfigurationNfvSubResource : IUtf8JsonSerializable, IJsonModel<RoutingConfigurationNfvSubResource>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RoutingConfigurationNfvSubResource>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<RoutingConfigurationNfvSubResource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfvSubResource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfvSubResource)} does not support '{format}' format.");
            }

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
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfvSubResource>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RoutingConfigurationNfvSubResource)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
        }

        internal static RoutingConfigurationNfvSubResource DeserializeRoutingConfigurationNfvSubResource(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

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

        BinaryData IPersistableModel<RoutingConfigurationNfvSubResource>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfvSubResource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RoutingConfigurationNfvSubResource)} does not support '{options.Format}' format.");
            }
        }

        RoutingConfigurationNfvSubResource IPersistableModel<RoutingConfigurationNfvSubResource>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RoutingConfigurationNfvSubResource>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRoutingConfigurationNfvSubResource(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RoutingConfigurationNfvSubResource)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RoutingConfigurationNfvSubResource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
