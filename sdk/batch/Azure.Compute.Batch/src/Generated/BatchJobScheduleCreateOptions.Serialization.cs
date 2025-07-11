// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Compute.Batch
{
    public partial class BatchJobScheduleCreateOptions : IUtf8JsonSerializable, IJsonModel<BatchJobScheduleCreateOptions>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BatchJobScheduleCreateOptions>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<BatchJobScheduleCreateOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BatchJobScheduleCreateOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BatchJobScheduleCreateOptions)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            if (Optional.IsDefined(DisplayName))
            {
                writer.WritePropertyName("displayName"u8);
                writer.WriteStringValue(DisplayName);
            }
            writer.WritePropertyName("schedule"u8);
            writer.WriteObjectValue(Schedule, options);
            writer.WritePropertyName("jobSpecification"u8);
            writer.WriteObjectValue(JobSpecification, options);
            if (Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartArray();
                foreach (var item in Metadata)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        BatchJobScheduleCreateOptions IJsonModel<BatchJobScheduleCreateOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BatchJobScheduleCreateOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BatchJobScheduleCreateOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBatchJobScheduleCreateOptions(document.RootElement, options);
        }

        internal static BatchJobScheduleCreateOptions DeserializeBatchJobScheduleCreateOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string displayName = default;
            BatchJobScheduleConfiguration schedule = default;
            BatchJobSpecification jobSpecification = default;
            IList<BatchMetadataItem> metadata = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("schedule"u8))
                {
                    schedule = BatchJobScheduleConfiguration.DeserializeBatchJobScheduleConfiguration(property.Value, options);
                    continue;
                }
                if (property.NameEquals("jobSpecification"u8))
                {
                    jobSpecification = BatchJobSpecification.DeserializeBatchJobSpecification(property.Value, options);
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BatchMetadataItem> array = new List<BatchMetadataItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BatchMetadataItem.DeserializeBatchMetadataItem(item, options));
                    }
                    metadata = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BatchJobScheduleCreateOptions(
                id,
                displayName,
                schedule,
                jobSpecification,
                metadata ?? new ChangeTrackingList<BatchMetadataItem>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BatchJobScheduleCreateOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BatchJobScheduleCreateOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureComputeBatchContext.Default);
                default:
                    throw new FormatException($"The model {nameof(BatchJobScheduleCreateOptions)} does not support writing '{options.Format}' format.");
            }
        }

        BatchJobScheduleCreateOptions IPersistableModel<BatchJobScheduleCreateOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BatchJobScheduleCreateOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeBatchJobScheduleCreateOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BatchJobScheduleCreateOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BatchJobScheduleCreateOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static BatchJobScheduleCreateOptions FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeBatchJobScheduleCreateOptions(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
