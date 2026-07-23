// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class RegistrationAddressInfo : IUtf8JsonSerializable, IJsonModel<RegistrationAddressInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RegistrationAddressInfo>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RegistrationAddressInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationAddressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RegistrationAddressInfo)} does not support writing '{format}' format.");
            }

            writer.WritePropertyName("address1"u8);
            writer.WriteStringValue(Address1);
            if (Optional.IsDefined(Address2))
            {
                writer.WritePropertyName("address2"u8);
                writer.WriteStringValue(Address2);
            }
            writer.WritePropertyName("city"u8);
            writer.WriteStringValue(City);
            writer.WritePropertyName("country"u8);
            writer.WriteStringValue(Country);
            writer.WritePropertyName("postalCode"u8);
            writer.WriteStringValue(PostalCode);
            writer.WritePropertyName("state"u8);
            writer.WriteStringValue(State);
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

        RegistrationAddressInfo IJsonModel<RegistrationAddressInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationAddressInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RegistrationAddressInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRegistrationAddressInfo(document.RootElement, options);
        }

        internal static RegistrationAddressInfo DeserializeRegistrationAddressInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string address1 = default;
            string address2 = default;
            string city = default;
            string country = default;
            string postalCode = default;
            string state = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("address1"u8))
                {
                    address1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("address2"u8))
                {
                    address2 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("city"u8))
                {
                    city = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("country"u8))
                {
                    country = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("postalCode"u8))
                {
                    postalCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("state"u8))
                {
                    state = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RegistrationAddressInfo(
                address1,
                address2,
                city,
                country,
                postalCode,
                state,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RegistrationAddressInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationAddressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(RegistrationAddressInfo)} does not support writing '{options.Format}' format.");
            }
        }

        RegistrationAddressInfo IPersistableModel<RegistrationAddressInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationAddressInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeRegistrationAddressInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RegistrationAddressInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RegistrationAddressInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
