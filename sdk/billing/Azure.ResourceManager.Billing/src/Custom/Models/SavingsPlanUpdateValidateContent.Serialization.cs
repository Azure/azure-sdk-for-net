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
    // 1.2.2 serialization contract. Benefits is { get; } with a List initializer
    // (no setter), so the internal Deserialize path uses the parameterless ctor
    // and Add()s each item to the existing collection rather than reassigning.
    public partial class SavingsPlanUpdateValidateContent : IJsonModel<SavingsPlanUpdateValidateContent>, IPersistableModel<SavingsPlanUpdateValidateContent>
    {
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        void IJsonModel<SavingsPlanUpdateValidateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SavingsPlanUpdateValidateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SavingsPlanUpdateValidateContent)} does not support writing '{format}' format.");
            }

            if (Optional.IsCollectionDefined(Benefits))
            {
                writer.WritePropertyName("benefits"u8);
                writer.WriteStartArray();
                foreach (var item in Benefits)
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

        SavingsPlanUpdateValidateContent IJsonModel<SavingsPlanUpdateValidateContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SavingsPlanUpdateValidateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SavingsPlanUpdateValidateContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSavingsPlanUpdateValidateContent(document.RootElement, options);
        }

        internal static SavingsPlanUpdateValidateContent DeserializeSavingsPlanUpdateValidateContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SavingsPlanUpdateValidateContent result = new SavingsPlanUpdateValidateContent();
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("benefits"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Benefits.Add(SavingsPlanUpdateRequestProperties.DeserializeSavingsPlanUpdateRequestProperties(item, options));
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            result._serializedAdditionalRawData = rawDataDictionary;
            return result;
        }

        BinaryData IPersistableModel<SavingsPlanUpdateValidateContent>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SavingsPlanUpdateValidateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                default:
                    throw new FormatException($"The model {nameof(SavingsPlanUpdateValidateContent)} does not support writing '{options.Format}' format.");
            }
        }

        SavingsPlanUpdateValidateContent IPersistableModel<SavingsPlanUpdateValidateContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SavingsPlanUpdateValidateContent>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeSavingsPlanUpdateValidateContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SavingsPlanUpdateValidateContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SavingsPlanUpdateValidateContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
