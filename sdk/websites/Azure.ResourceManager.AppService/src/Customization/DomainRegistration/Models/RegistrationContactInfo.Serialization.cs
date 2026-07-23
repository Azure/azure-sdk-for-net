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
    public partial class RegistrationContactInfo : IUtf8JsonSerializable, IJsonModel<RegistrationContactInfo>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RegistrationContactInfo>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RegistrationContactInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationContactInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RegistrationContactInfo)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(AddressMailing))
            {
                writer.WritePropertyName("addressMailing"u8);
                writer.WriteObjectValue(AddressMailing, options);
            }
            writer.WritePropertyName("email"u8);
            writer.WriteStringValue(Email);
            if (Optional.IsDefined(Fax))
            {
                writer.WritePropertyName("fax"u8);
                writer.WriteStringValue(Fax);
            }
            if (Optional.IsDefined(JobTitle))
            {
                writer.WritePropertyName("jobTitle"u8);
                writer.WriteStringValue(JobTitle);
            }
            writer.WritePropertyName("nameFirst"u8);
            writer.WriteStringValue(NameFirst);
            writer.WritePropertyName("nameLast"u8);
            writer.WriteStringValue(NameLast);
            if (Optional.IsDefined(NameMiddle))
            {
                writer.WritePropertyName("nameMiddle"u8);
                writer.WriteStringValue(NameMiddle);
            }
            if (Optional.IsDefined(Organization))
            {
                writer.WritePropertyName("organization"u8);
                writer.WriteStringValue(Organization);
            }
            writer.WritePropertyName("phone"u8);
            writer.WriteStringValue(Phone);
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

        RegistrationContactInfo IJsonModel<RegistrationContactInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationContactInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RegistrationContactInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRegistrationContactInfo(document.RootElement, options);
        }

        internal static RegistrationContactInfo DeserializeRegistrationContactInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RegistrationAddressInfo addressMailing = default;
            string email = default;
            string fax = default;
            string jobTitle = default;
            string nameFirst = default;
            string nameLast = default;
            string nameMiddle = default;
            string organization = default;
            string phone = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("addressMailing"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    addressMailing = RegistrationAddressInfo.DeserializeRegistrationAddressInfo(property.Value, options);
                    continue;
                }
                if (property.NameEquals("email"u8))
                {
                    email = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fax"u8))
                {
                    fax = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("jobTitle"u8))
                {
                    jobTitle = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nameFirst"u8))
                {
                    nameFirst = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nameLast"u8))
                {
                    nameLast = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("nameMiddle"u8))
                {
                    nameMiddle = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("organization"u8))
                {
                    organization = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("phone"u8))
                {
                    phone = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new RegistrationContactInfo(
                addressMailing,
                email,
                fax,
                jobTitle,
                nameFirst,
                nameLast,
                nameMiddle,
                organization,
                phone,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RegistrationContactInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationContactInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(RegistrationContactInfo)} does not support writing '{options.Format}' format.");
            }
        }

        RegistrationContactInfo IPersistableModel<RegistrationContactInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RegistrationContactInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeRegistrationContactInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RegistrationContactInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RegistrationContactInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
