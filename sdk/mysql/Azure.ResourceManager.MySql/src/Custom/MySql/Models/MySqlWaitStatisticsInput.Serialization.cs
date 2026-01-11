// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Models
{
    public partial class MySqlWaitStatisticsInput : IUtf8JsonSerializable, IJsonModel<MySqlWaitStatisticsInput>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<MySqlWaitStatisticsInput>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<MySqlWaitStatisticsInput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlWaitStatisticsInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlWaitStatisticsInput)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            writer.WritePropertyName("observationStartTime"u8);
            writer.WriteStringValue(ObservationStartOn, "O");
            writer.WritePropertyName("observationEndTime"u8);
            writer.WriteStringValue(ObservationEndOn, "O");
            writer.WritePropertyName("aggregationWindow"u8);
            writer.WriteStringValue(AggregationWindow);
            writer.WriteEndObject();
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

        MySqlWaitStatisticsInput IJsonModel<MySqlWaitStatisticsInput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlWaitStatisticsInput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MySqlWaitStatisticsInput)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMySqlWaitStatisticsInput(document.RootElement, options);
        }

        internal static MySqlWaitStatisticsInput DeserializeMySqlWaitStatisticsInput(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DateTimeOffset observationStartTime = default;
            DateTimeOffset observationEndTime = default;
            string aggregationWindow = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("observationStartTime"u8))
                        {
                            observationStartTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("observationEndTime"u8))
                        {
                            observationEndTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("aggregationWindow"u8))
                        {
                            aggregationWindow = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new MySqlWaitStatisticsInput(observationStartTime, observationEndTime, aggregationWindow, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<MySqlWaitStatisticsInput>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlWaitStatisticsInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerMySqlContext.Default);
                default:
                    throw new FormatException($"The model {nameof(MySqlWaitStatisticsInput)} does not support writing '{options.Format}' format.");
            }
        }

        MySqlWaitStatisticsInput IPersistableModel<MySqlWaitStatisticsInput>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<MySqlWaitStatisticsInput>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeMySqlWaitStatisticsInput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MySqlWaitStatisticsInput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MySqlWaitStatisticsInput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}