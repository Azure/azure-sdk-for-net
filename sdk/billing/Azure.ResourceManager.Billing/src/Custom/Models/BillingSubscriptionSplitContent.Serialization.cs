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
    // 1.2.2 serialization contract for this back-compat POCO. The wire shape is
    // flat with TermDuration serialized as ISO8601 duration ("P"). The new
    // BillingSubscriptionSplitRequest types TermDuration as plain string, so this
    // *Content stays decoupled — the Resource.Split shim does the TimeSpan->string
    // conversion before forwarding.
    public partial class BillingSubscriptionSplitContent : IJsonModel<BillingSubscriptionSplitContent>, IPersistableModel<BillingSubscriptionSplitContent>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal BillingSubscriptionSplitContent(string targetProductTypeId, string targetSkuId, int? quantity, TimeSpan? termDuration, string billingFrequency, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TargetProductTypeId = targetProductTypeId;
            TargetSkuId = targetSkuId;
            Quantity = quantity;
            TermDuration = termDuration;
            BillingFrequency = billingFrequency;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        void IJsonModel<BillingSubscriptionSplitContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionSplitContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingSubscriptionSplitContent)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(TargetProductTypeId))
            {
                writer.WritePropertyName("targetProductTypeId"u8);
                writer.WriteStringValue(TargetProductTypeId);
            }
            if (Optional.IsDefined(TargetSkuId))
            {
                writer.WritePropertyName("targetSkuId"u8);
                writer.WriteStringValue(TargetSkuId);
            }
            if (Optional.IsDefined(Quantity))
            {
                writer.WritePropertyName("quantity"u8);
                writer.WriteNumberValue(Quantity.Value);
            }
            if (Optional.IsDefined(TermDuration))
            {
                writer.WritePropertyName("termDuration"u8);
                writer.WriteStringValue(TermDuration.Value, "P");
            }
            if (Optional.IsDefined(BillingFrequency))
            {
                writer.WritePropertyName("billingFrequency"u8);
                writer.WriteStringValue(BillingFrequency);
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

        BillingSubscriptionSplitContent IJsonModel<BillingSubscriptionSplitContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionSplitContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingSubscriptionSplitContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBillingSubscriptionSplitContent(document.RootElement, options);
        }

        internal static BillingSubscriptionSplitContent DeserializeBillingSubscriptionSplitContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string targetProductTypeId = default;
            string targetSkuId = default;
            int? quantity = default;
            TimeSpan? termDuration = default;
            string billingFrequency = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("targetProductTypeId"u8))
                {
                    targetProductTypeId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetSkuId"u8))
                {
                    targetSkuId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("quantity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    quantity = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("termDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    termDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("billingFrequency"u8))
                {
                    billingFrequency = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingSubscriptionSplitContent(
                targetProductTypeId,
                targetSkuId,
                quantity,
                termDuration,
                billingFrequency,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BillingSubscriptionSplitContent>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionSplitContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(BillingSubscriptionSplitContent)} does not support writing '{options.Format}' format.");
            }
        }

        BillingSubscriptionSplitContent IPersistableModel<BillingSubscriptionSplitContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionSplitContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeBillingSubscriptionSplitContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BillingSubscriptionSplitContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BillingSubscriptionSplitContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
