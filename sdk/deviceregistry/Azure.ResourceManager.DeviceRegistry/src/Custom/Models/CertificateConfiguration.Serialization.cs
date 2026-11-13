// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Custom serialization override — replaces Generated/Models/CertificateConfiguration.Serialization.cs
// (which is excluded from compilation via .csproj Compile Remove).
//
// Purpose: Makes certificateAuthorityConfiguration conditional (null-safe) in serialization.
// This allows PATCH operations to omit certificateAuthorityConfiguration entirely, which
// contains immutable properties (keyType, bringYourOwnRoot) that the 2026-03-01-preview API
// rejects on PATCH requests.
//
// For PUT (create): CertificateAuthorityConfiguration is set → serialized with keyType → API happy
// For PATCH (update): CertificateAuthorityConfiguration is null → not serialized → API happy
//
// The .NET SDK generator does not honor @visibility(Lifecycle.Create, Lifecycle.Read) and
// always serializes certificateAuthorityConfiguration unconditionally.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.DeviceRegistry;

namespace Azure.ResourceManager.DeviceRegistry.Models
{
    /// <summary> The certificate configuration. </summary>
    public partial class CertificateConfiguration : IJsonModel<CertificateConfiguration>
    {
        /// <summary> Initializes a new instance of <see cref="CertificateConfiguration"/> for deserialization. </summary>
        internal CertificateConfiguration()
        {
        }

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CertificateConfiguration PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeCertificateConfiguration(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CertificateConfiguration)} does not support reading '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerDeviceRegistryContext.Default);
                default:
                    throw new FormatException($"The model {nameof(CertificateConfiguration)} does not support writing '{options.Format}' format.");
            }
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        BinaryData IPersistableModel<CertificateConfiguration>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        CertificateConfiguration IPersistableModel<CertificateConfiguration>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="options"> The client options for reading and writing models. </param>
        string IPersistableModel<CertificateConfiguration>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        void IJsonModel<CertificateConfiguration>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CertificateConfiguration)} does not support writing '{format}' format.");
            }
            // CUSTOM FIX: Only serialize certificateAuthorityConfiguration when present.
            // For PATCH operations, CertificateAuthorityConfiguration is null (using the
            // int-only constructor), so this block is skipped — preventing keyType and
            // bringYourOwnRoot from being sent. The API rejects these immutable properties
            // on PATCH. For PUT operations, the full constructor sets it → serialized normally.
            if (CertificateAuthorityConfiguration != null)
            {
                writer.WritePropertyName("certificateAuthorityConfiguration"u8);
                writer.WriteObjectValue(CertificateAuthorityConfiguration, options);
            }
            if (LeafCertificateConfiguration != null)
            {
                writer.WritePropertyName("leafCertificateConfiguration"u8);
                writer.WriteObjectValue(LeafCertificateConfiguration, options);
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
        CertificateConfiguration IJsonModel<CertificateConfiguration>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual CertificateConfiguration JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CertificateConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CertificateConfiguration)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCertificateConfiguration(document.RootElement, options);
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static CertificateConfiguration DeserializeCertificateConfiguration(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CertificateAuthorityConfiguration certificateAuthorityConfiguration = default;
            LeafCertificateConfiguration leafCertificateConfiguration = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("certificateAuthorityConfiguration"u8))
                {
                    certificateAuthorityConfiguration = CertificateAuthorityConfiguration.DeserializeCertificateAuthorityConfiguration(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("leafCertificateConfiguration"u8))
                {
                    leafCertificateConfiguration = LeafCertificateConfiguration.DeserializeLeafCertificateConfiguration(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new CertificateConfiguration(certificateAuthorityConfiguration, leafCertificateConfiguration, additionalBinaryDataProperties);
        }
    }
}
