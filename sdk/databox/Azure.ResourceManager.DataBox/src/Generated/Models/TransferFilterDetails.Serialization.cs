// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class TransferFilterDetails : IUtf8JsonSerializable, IJsonModel<TransferFilterDetails>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<TransferFilterDetails>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<TransferFilterDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TransferFilterDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TransferFilterDetails)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("dataAccountType"u8);
            writer.WriteStringValue(DataAccountType.ToSerialString());
            if (Optional.IsDefined(BlobFilterDetails))
            {
                writer.WritePropertyName("blobFilterDetails"u8);
                writer.WriteObjectValue(BlobFilterDetails, options);
            }
            if (Optional.IsDefined(AzureFileFilterDetails))
            {
                writer.WritePropertyName("azureFileFilterDetails"u8);
                writer.WriteObjectValue(AzureFileFilterDetails, options);
            }
            if (Optional.IsCollectionDefined(FilterFileDetails))
            {
                writer.WritePropertyName("filterFileDetails"u8);
                writer.WriteStartArray();
                foreach (var item in FilterFileDetails)
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

        TransferFilterDetails IJsonModel<TransferFilterDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TransferFilterDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TransferFilterDetails)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeTransferFilterDetails(document.RootElement, options);
        }

        internal static TransferFilterDetails DeserializeTransferFilterDetails(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DataAccountType dataAccountType = default;
            BlobFilterDetails blobFilterDetails = default;
            AzureFileFilterDetails azureFileFilterDetails = default;
            IList<FilterFileDetails> filterFileDetails = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dataAccountType"u8))
                {
                    dataAccountType = property.Value.GetString().ToDataAccountType();
                    continue;
                }
                if (property.NameEquals("blobFilterDetails"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    blobFilterDetails = BlobFilterDetails.DeserializeBlobFilterDetails(property.Value, options);
                    continue;
                }
                if (property.NameEquals("azureFileFilterDetails"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    azureFileFilterDetails = AzureFileFilterDetails.DeserializeAzureFileFilterDetails(property.Value, options);
                    continue;
                }
                if (property.NameEquals("filterFileDetails"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<FilterFileDetails> array = new List<FilterFileDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Models.FilterFileDetails.DeserializeFilterFileDetails(item, options));
                    }
                    filterFileDetails = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new TransferFilterDetails(dataAccountType, blobFilterDetails, azureFileFilterDetails, filterFileDetails ?? new ChangeTrackingList<FilterFileDetails>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<TransferFilterDetails>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TransferFilterDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDataBoxContext.Default);
                default:
                    throw new FormatException($"The model {nameof(TransferFilterDetails)} does not support writing '{options.Format}' format.");
            }
        }

        TransferFilterDetails IPersistableModel<TransferFilterDetails>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TransferFilterDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeTransferFilterDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(TransferFilterDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<TransferFilterDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
