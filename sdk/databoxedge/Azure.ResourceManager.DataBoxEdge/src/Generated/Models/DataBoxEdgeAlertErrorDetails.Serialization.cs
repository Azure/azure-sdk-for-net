// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class DataBoxEdgeAlertErrorDetails : IUtf8JsonSerializable, IJsonModel<DataBoxEdgeAlertErrorDetails>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DataBoxEdgeAlertErrorDetails>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DataBoxEdgeAlertErrorDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataBoxEdgeAlertErrorDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataBoxEdgeAlertErrorDetails)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(ErrorCode))
            {
                writer.WritePropertyName("errorCode"u8);
                writer.WriteStringValue(ErrorCode);
            }
            if (options.Format != "W" && Optional.IsDefined(ErrorMessage))
            {
                writer.WritePropertyName("errorMessage"u8);
                writer.WriteStringValue(ErrorMessage);
            }
            if (options.Format != "W" && Optional.IsDefined(Occurrences))
            {
                writer.WritePropertyName("occurrences"u8);
                writer.WriteNumberValue(Occurrences.Value);
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

        DataBoxEdgeAlertErrorDetails IJsonModel<DataBoxEdgeAlertErrorDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataBoxEdgeAlertErrorDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DataBoxEdgeAlertErrorDetails)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDataBoxEdgeAlertErrorDetails(document.RootElement, options);
        }

        internal static DataBoxEdgeAlertErrorDetails DeserializeDataBoxEdgeAlertErrorDetails(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string errorCode = default;
            string errorMessage = default;
            int? occurrences = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("errorCode"u8))
                {
                    errorCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("occurrences"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    occurrences = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DataBoxEdgeAlertErrorDetails(errorCode, errorMessage, occurrences, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<DataBoxEdgeAlertErrorDetails>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataBoxEdgeAlertErrorDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDataBoxEdgeContext.Default);
                default:
                    throw new FormatException($"The model {nameof(DataBoxEdgeAlertErrorDetails)} does not support writing '{options.Format}' format.");
            }
        }

        DataBoxEdgeAlertErrorDetails IPersistableModel<DataBoxEdgeAlertErrorDetails>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DataBoxEdgeAlertErrorDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDataBoxEdgeAlertErrorDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DataBoxEdgeAlertErrorDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DataBoxEdgeAlertErrorDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
