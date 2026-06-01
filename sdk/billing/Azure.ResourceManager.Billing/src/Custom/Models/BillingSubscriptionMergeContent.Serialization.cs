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
    // flat {targetBillingSubscriptionName?, quantity?} — matches GA exactly. The
    // SDK never actually transmits this payload (the Custom Resource overload
    // translates to BillingSubscriptionMergeRequest first), but the GA API surface
    // exposed the type as IJsonModel<>/IPersistableModel<>, so direct callers of
    // ModelReaderWriter.Write/Read on this type must still work.
    public partial class BillingSubscriptionMergeContent : IJsonModel<BillingSubscriptionMergeContent>, IPersistableModel<BillingSubscriptionMergeContent>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal BillingSubscriptionMergeContent(string targetBillingSubscriptionName, int? quantity, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TargetBillingSubscriptionName = targetBillingSubscriptionName;
            Quantity = quantity;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        void IJsonModel<BillingSubscriptionMergeContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionMergeContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingSubscriptionMergeContent)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(TargetBillingSubscriptionName))
            {
                writer.WritePropertyName("targetBillingSubscriptionName"u8);
                writer.WriteStringValue(TargetBillingSubscriptionName);
            }
            if (Optional.IsDefined(Quantity))
            {
                writer.WritePropertyName("quantity"u8);
                writer.WriteNumberValue(Quantity.Value);
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

        BillingSubscriptionMergeContent IJsonModel<BillingSubscriptionMergeContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionMergeContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingSubscriptionMergeContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBillingSubscriptionMergeContent(document.RootElement, options);
        }

        internal static BillingSubscriptionMergeContent DeserializeBillingSubscriptionMergeContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string targetBillingSubscriptionName = default;
            int? quantity = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("targetBillingSubscriptionName"u8))
                {
                    targetBillingSubscriptionName = property.Value.GetString();
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
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingSubscriptionMergeContent(targetBillingSubscriptionName, quantity, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BillingSubscriptionMergeContent>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionMergeContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(BillingSubscriptionMergeContent)} does not support writing '{options.Format}' format.");
            }
        }

        BillingSubscriptionMergeContent IPersistableModel<BillingSubscriptionMergeContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<BillingSubscriptionMergeContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                    return DeserializeBillingSubscriptionMergeContent(document.RootElement, options);
                }
                default:
                    throw new FormatException($"The model {nameof(BillingSubscriptionMergeContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BillingSubscriptionMergeContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
