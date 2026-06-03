// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Billing.Models
{
    // Hand-written IJsonModel/IPersistableModel implementation that restores the GA
    // 1.2.2 serialization contract. The GA wire shape wraps both properties inside
    // a "properties" envelope: { "properties": { "recipientEmailId": ..., "resellerId": ... } }.
    public partial class PartnerTransferDetailCreateOrUpdateContent : IJsonModel<PartnerTransferDetailCreateOrUpdateContent>, IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal PartnerTransferDetailCreateOrUpdateContent(string recipientEmailId, string resellerId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RecipientEmailId = recipientEmailId;
            ResellerId = resellerId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        void IJsonModel<PartnerTransferDetailCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PartnerTransferDetailCreateOrUpdateContent)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(RecipientEmailId))
            {
                writer.WritePropertyName("recipientEmailId"u8);
                writer.WriteStringValue(RecipientEmailId);
            }
            if (Optional.IsDefined(ResellerId))
            {
                writer.WritePropertyName("resellerId"u8);
                writer.WriteStringValue(ResellerId);
            }
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

        PartnerTransferDetailCreateOrUpdateContent IJsonModel<PartnerTransferDetailCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PartnerTransferDetailCreateOrUpdateContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePartnerTransferDetailCreateOrUpdateContent(document.RootElement, options);
        }

        internal static PartnerTransferDetailCreateOrUpdateContent DeserializePartnerTransferDetailCreateOrUpdateContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string recipientEmailId = default;
            string resellerId = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("recipientEmailId"u8))
                        {
                            recipientEmailId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("resellerId"u8))
                        {
                            resellerId = property0.Value.GetString();
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
            return new PartnerTransferDetailCreateOrUpdateContent(recipientEmailId, resellerId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(PartnerTransferDetailCreateOrUpdateContent)} does not support writing '{options.Format}' format.");
            }
        }

        PartnerTransferDetailCreateOrUpdateContent IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializePartnerTransferDetailCreateOrUpdateContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PartnerTransferDetailCreateOrUpdateContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PartnerTransferDetailCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
