// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("OperationalInsightsClusterSku")]
namespace Azure.ResourceManager.OperationalInsights.Models
{
    public partial class OperationalInsightsClusterSku : IUtf8JsonSerializable, IJsonModel<OperationalInsightsClusterSku>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OperationalInsightsClusterSku>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OperationalInsightsClusterSku>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(Capacity.Value.ToSerialInt64());
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name.Value.ToString());
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        OperationalInsightsClusterSku IJsonModel<OperationalInsightsClusterSku>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OperationalInsightsClusterSku>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OperationalInsightsClusterSku)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOperationalInsightsClusterSku(document.RootElement, options);
        }

        internal static OperationalInsightsClusterSku DeserializeOperationalInsightsClusterSku(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<OperationalInsightsClusterCapacity> capacity = default;
            Optional<OperationalInsightsClusterSkuName> name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt64().ToOperationalInsightsClusterCapacity();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    name = new OperationalInsightsClusterSkuName(property.Value.GetString());
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OperationalInsightsClusterSku(Optional.ToNullable(capacity), Optional.ToNullable(name), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OperationalInsightsClusterSku>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OperationalInsightsClusterSku>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OperationalInsightsClusterSku)} does not support '{options.Format}' format.");
            }
        }

        OperationalInsightsClusterSku IPersistableModel<OperationalInsightsClusterSku>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OperationalInsightsClusterSku>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOperationalInsightsClusterSku(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OperationalInsightsClusterSku)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<OperationalInsightsClusterSku>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
