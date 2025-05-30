// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class DataCollectionConfiguration : IUtf8JsonSerializable, IJsonModel<DataCollectionConfiguration>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataCollectionConfiguration>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DataCollectionConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataCollectionConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataCollectionConfiguration)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(SamplingRate))
            {
                writer.WritePropertyName("samplingRate"u8);
                writer.WriteNumberValue(SamplingRate.Value);
            }
            if (Optional.IsDefined(DataCollectionMode))
            {
                writer.WritePropertyName("dataCollectionMode"u8);
                writer.WriteStringValue(DataCollectionMode.Value.ToString());
            }
            if (Optional.IsDefined(DataId))
            {
                if (DataId != null)
                {
                    writer.WritePropertyName("dataId"u8);
                    writer.WriteStringValue(DataId);
                }
                else
                {
                    writer.WriteNull("dataId");
                }
            }
            if (Optional.IsDefined(ClientId))
            {
                if (ClientId != null)
                {
                    writer.WritePropertyName("clientId"u8);
                    writer.WriteStringValue(ClientId);
                }
                else
                {
                    writer.WriteNull("clientId");
                }
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        DataCollectionConfiguration IJsonModel<DataCollectionConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataCollectionConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataCollectionConfiguration)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataCollectionConfiguration(document.RootElement, options);
        }

        internal static DataCollectionConfiguration DeserializeDataCollectionConfiguration(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            double? samplingRate = default;
            DataCollectionMode? dataCollectionMode = default;
            string dataId = default;
            string clientId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("samplingRate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    samplingRate = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("dataCollectionMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dataCollectionMode = new DataCollectionMode(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("dataId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        dataId = null;
                        continue;
                    }
                    dataId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("clientId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        clientId = null;
                        continue;
                    }
                    clientId = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DataCollectionConfiguration(samplingRate, dataCollectionMode, dataId, clientId, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SamplingRate), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  samplingRate: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SamplingRate))
                {
                    builder.Append("  samplingRate: ");
                    builder.AppendLine($"'{SamplingRate.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DataCollectionMode), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  dataCollectionMode: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(DataCollectionMode))
                {
                    builder.Append("  dataCollectionMode: ");
                    builder.AppendLine($"'{DataCollectionMode.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DataId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  dataId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(DataId))
                {
                    builder.Append("  dataId: ");
                    if (DataId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{DataId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{DataId}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ClientId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  clientId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ClientId))
                {
                    builder.Append("  clientId: ");
                    if (ClientId.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ClientId}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ClientId}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<DataCollectionConfiguration>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataCollectionConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMachineLearningContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(DataCollectionConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        DataCollectionConfiguration IPersistableModel<DataCollectionConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataCollectionConfiguration>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDataCollectionConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DataCollectionConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DataCollectionConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
