// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Custom serialization override — replaces Generated/Models/CertificateAuthorityConfiguration.Serialization.cs
// (which is excluded from compilation via .csproj Compile Remove).
//
// Purpose: Always serialize keyType on the wire for PUT (create) requests.
// The generator incorrectly guards keyType with `options.Format != "W"`, treating it as
// read-only due to @visibility(Lifecycle.Create, Lifecycle.Read) in the TypeSpec definition.
// However, the 2026-03-01-preview API requires keyType in the request payload for PUT.
//
// Changes from generated version:
//   - keyType: removed `options.Format != "W"` guard → always serialized
//   - subject, validityNotBefore, validityNotAfter: kept as read-only (still guarded)

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.DeviceRegistry;

namespace Azure.ResourceManager.DeviceRegistry.Models
{
    /// <summary> The configuration to set up an ICA. </summary>
    public partial class CertificateAuthorityConfiguration : IJsonModel<CertificateAuthorityConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="CertificateAuthorityConfiguration"/> for deserialization. </summary>
        internal CertificateAuthorityConfiguration()
        {
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CertificateAuthorityConfiguration PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateAuthorityConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeCertificateAuthorityConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CertificateAuthorityConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateAuthorityConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDeviceRegistryContext.Default);
                default:
                    throw new FormatException($"The model {nameof(CertificateAuthorityConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<CertificateAuthorityConfiguration>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        CertificateAuthorityConfiguration IPersistableModel<CertificateAuthorityConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<CertificateAuthorityConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<CertificateAuthorityConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateAuthorityConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CertificateAuthorityConfiguration)} does not support writing '{format}' format.");
            }
            // CUSTOM FIX: Always serialize keyType — the API requires it on PUT (create).
            // The generator incorrectly guarded this with `options.Format != "W"` due to
            // @visibility(Lifecycle.Create, Lifecycle.Read) in the TypeSpec definition,
            // which caused keyType to be omitted from wire-format (HTTP request) payloads.
            writer.WritePropertyName("keyType"u8);
            writer.WriteStringValue(KeyType.ToString());
            if (options.Format != "W" && Optional.IsDefined(Subject))
            {
                writer.WritePropertyName("subject"u8);
                writer.WriteStringValue(Subject);
            }
            if (options.Format != "W" && Optional.IsDefined(ValidityNotBefore))
            {
                writer.WritePropertyName("validityNotBefore"u8);
                writer.WriteStringValue(ValidityNotBefore.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(ValidityNotAfter))
            {
                writer.WritePropertyName("validityNotAfter"u8);
                writer.WriteStringValue(ValidityNotAfter.Value, "O");
            }
            if (Optional.IsDefined(BringYourOwnRoot))
            {
                writer.WritePropertyName("bringYourOwnRoot"u8);
                writer.WriteObjectValue(BringYourOwnRoot, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        CertificateAuthorityConfiguration IJsonModel<CertificateAuthorityConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CertificateAuthorityConfiguration JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateAuthorityConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CertificateAuthorityConfiguration)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCertificateAuthorityConfiguration(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static CertificateAuthorityConfiguration DeserializeCertificateAuthorityConfiguration(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SupportedKeyType keyType = default;
            string subject = default;
            DateTimeOffset? validityNotBefore = default;
            DateTimeOffset? validityNotAfter = default;
            BringYourOwnRoot bringYourOwnRoot = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("keyType"u8))
                {
                    keyType = new SupportedKeyType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("subject"u8))
                {
                    subject = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("validityNotBefore"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    validityNotBefore = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (prop.NameEquals("validityNotAfter"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    validityNotAfter = prop.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (prop.NameEquals("bringYourOwnRoot"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bringYourOwnRoot = BringYourOwnRoot.DeserializeBringYourOwnRoot(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new CertificateAuthorityConfiguration(
                keyType,
                subject,
                validityNotBefore,
                validityNotAfter,
                bringYourOwnRoot,
                additionalBinaryDataProperties);
        }
    }
}
