// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class RenewCertificateOrderContent : IUtf8JsonSerializable, IJsonModel<RenewCertificateOrderContent>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<RenewCertificateOrderContent>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<RenewCertificateOrderContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenewCertificateOrderContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RenewCertificateOrderContent)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Kind))
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(KeySize))
            {
                writer.WritePropertyName("keySize"u8);
                writer.WriteNumberValue(KeySize.Value);
            }
            if (Optional.IsDefined(Csr))
            {
                writer.WritePropertyName("csr"u8);
                writer.WriteStringValue(Csr);
            }
            if (Optional.IsDefined(IsPrivateKeyExternal))
            {
                writer.WritePropertyName("isPrivateKeyExternal"u8);
                writer.WriteBooleanValue(IsPrivateKeyExternal.Value);
            }
            writer.WriteEndObject();
        }

        RenewCertificateOrderContent IJsonModel<RenewCertificateOrderContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenewCertificateOrderContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RenewCertificateOrderContent)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRenewCertificateOrderContent(document.RootElement, options);
        }

        internal static RenewCertificateOrderContent DeserializeRenewCertificateOrderContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            int? keySize = default;
            string csr = default;
            bool? isPrivateKeyExternal = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<Azure.ResourceManager.Models.SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("keySize"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            keySize = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("csr"u8))
                        {
                            csr = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("isPrivateKeyExternal"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            isPrivateKeyExternal = property0.Value.GetBoolean();
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
            return new RenewCertificateOrderContent(
                id,
                name,
                type,
                systemData,
                keySize,
                csr,
                isPrivateKeyExternal,
                kind,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<RenewCertificateOrderContent>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenewCertificateOrderContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(RenewCertificateOrderContent)} does not support writing '{options.Format}' format.");
            }
        }

        RenewCertificateOrderContent IPersistableModel<RenewCertificateOrderContent>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RenewCertificateOrderContent>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeRenewCertificateOrderContent(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RenewCertificateOrderContent)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RenewCertificateOrderContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
