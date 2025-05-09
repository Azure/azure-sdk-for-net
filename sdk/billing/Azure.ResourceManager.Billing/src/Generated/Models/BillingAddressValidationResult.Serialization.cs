// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Models
{
    public partial class BillingAddressValidationResult : IUtf8JsonSerializable, IJsonModel<BillingAddressValidationResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BillingAddressValidationResult>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<BillingAddressValidationResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BillingAddressValidationResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingAddressValidationResult)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(SuggestedAddresses))
            {
                writer.WritePropertyName("suggestedAddresses"u8);
                writer.WriteStartArray();
                foreach (var item in SuggestedAddresses)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(ValidationMessage))
            {
                writer.WritePropertyName("validationMessage"u8);
                writer.WriteStringValue(ValidationMessage);
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

        BillingAddressValidationResult IJsonModel<BillingAddressValidationResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BillingAddressValidationResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(BillingAddressValidationResult)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBillingAddressValidationResult(document.RootElement, options);
        }

        internal static BillingAddressValidationResult DeserializeBillingAddressValidationResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BillingAddressValidationStatus? status = default;
            IReadOnlyList<BillingAddressDetails> suggestedAddresses = default;
            string validationMessage = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new BillingAddressValidationStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("suggestedAddresses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BillingAddressDetails> array = new List<BillingAddressDetails>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(BillingAddressDetails.DeserializeBillingAddressDetails(item, options));
                    }
                    suggestedAddresses = array;
                    continue;
                }
                if (property.NameEquals("validationMessage"u8))
                {
                    validationMessage = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new BillingAddressValidationResult(status, suggestedAddresses ?? new ChangeTrackingList<BillingAddressDetails>(), validationMessage, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Status), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  status: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Status))
                {
                    builder.Append("  status: ");
                    builder.AppendLine($"'{Status.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SuggestedAddresses), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  suggestedAddresses: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(SuggestedAddresses))
                {
                    if (SuggestedAddresses.Any())
                    {
                        builder.Append("  suggestedAddresses: ");
                        builder.AppendLine("[");
                        foreach (var item in SuggestedAddresses)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  suggestedAddresses: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ValidationMessage), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  validationMessage: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ValidationMessage))
                {
                    builder.Append("  validationMessage: ");
                    if (ValidationMessage.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ValidationMessage}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ValidationMessage}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<BillingAddressValidationResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BillingAddressValidationResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerBillingContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(BillingAddressValidationResult)} does not support writing '{options.Format}' format.");
            }
        }

        BillingAddressValidationResult IPersistableModel<BillingAddressValidationResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BillingAddressValidationResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeBillingAddressValidationResult(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(BillingAddressValidationResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<BillingAddressValidationResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
