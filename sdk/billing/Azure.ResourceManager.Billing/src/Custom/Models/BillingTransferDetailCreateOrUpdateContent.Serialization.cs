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
    // 1.2.2 serialization contract. The GA wire shape wraps RecipientEmailId inside
    // a "properties" envelope: { "properties": { "recipientEmailId": ... } }.
    // The new InitiateTransferRequest exposes RecipientEmailId via a flattened
    // accessor over its internal Properties; the Resource shim sets it before
    // forwarding.
    public partial class BillingTransferDetailCreateOrUpdateContent : IJsonModel<BillingTransferDetailCreateOrUpdateContent>, IPersistableModel<BillingTransferDetailCreateOrUpdateContent>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal BillingTransferDetailCreateOrUpdateContent(string recipientEmailId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            RecipientEmailId = recipientEmailId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        void IJsonModel<BillingTransferDetailCreateOrUpdateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingTransferDetailCreateOrUpdateContent)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(RecipientEmailId))
            {
                writer.WritePropertyName("recipientEmailId"u8);
                writer.WriteStringValue(RecipientEmailId);
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

        BillingTransferDetailCreateOrUpdateContent IJsonModel<BillingTransferDetailCreateOrUpdateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingTransferDetailCreateOrUpdateContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBillingTransferDetailCreateOrUpdateContent(document.RootElement, options);
        }

        internal static BillingTransferDetailCreateOrUpdateContent DeserializeBillingTransferDetailCreateOrUpdateContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string recipientEmailId = default;
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
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingTransferDetailCreateOrUpdateContent(recipientEmailId, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BillingTransferDetailCreateOrUpdateContent>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(BillingTransferDetailCreateOrUpdateContent)} does not support writing '{options.Format}' format.");
            }
        }

        BillingTransferDetailCreateOrUpdateContent IPersistableModel<BillingTransferDetailCreateOrUpdateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingTransferDetailCreateOrUpdateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                    return DeserializeBillingTransferDetailCreateOrUpdateContent(document.RootElement, options);
                }
                default:
                    throw new FormatException($"The model {nameof(BillingTransferDetailCreateOrUpdateContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BillingTransferDetailCreateOrUpdateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
