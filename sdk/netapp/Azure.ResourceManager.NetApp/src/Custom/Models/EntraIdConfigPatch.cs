// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.NetApp.Models
{
    // The 2026 TypeSpec model removed the legacy Entra ID patch wrapper.
    // Preserve the shipped constructor/property shape for source compatibility.
    /// <summary> Entra ID configuration patch. </summary>
    public partial class EntraIdConfigPatch : IJsonModel<EntraIdConfigPatch>, IPersistableModel<EntraIdConfigPatch>
    {
        /// <summary> Initializes a new instance of <see cref="EntraIdConfigPatch"/>. </summary>
        public EntraIdConfigPatch()
        {
        }

        /// <summary> The application identifier. </summary>
        public string ApplicationId { get; set; }

        /// <summary> The domain name. </summary>
        public string Domain { get; set; }

        /// <summary> The server name prefix. </summary>
        public string ServerNamePrefix { get; set; }

        /// <summary> The Azure Key Vault configuration. </summary>
        public EntraIdAkvConfigPatch EntraIdAkvConfig { get; set; }

        protected virtual EntraIdConfigPatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdConfigPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeEntraIdConfigPatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(EntraIdConfigPatch)} does not support reading '{options.Format}' format.");
            }
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdConfigPatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetAppContext.Default);
                default:
                    throw new FormatException($"The model {nameof(EntraIdConfigPatch)} does not support writing '{options.Format}' format.");
            }
        }

        EntraIdConfigPatch IPersistableModel<EntraIdConfigPatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<EntraIdConfigPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<EntraIdConfigPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<EntraIdConfigPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        EntraIdConfigPatch IJsonModel<EntraIdConfigPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdConfigPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EntraIdConfigPatch)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(ApplicationId))
            {
                writer.WritePropertyName("applicationId"u8);
                writer.WriteStringValue(ApplicationId);
            }
            if (Optional.IsDefined(Domain))
            {
                writer.WritePropertyName("domain"u8);
                writer.WriteStringValue(Domain);
            }
            if (Optional.IsDefined(ServerNamePrefix))
            {
                writer.WritePropertyName("serverNamePrefix"u8);
                writer.WriteStringValue(ServerNamePrefix);
            }
            if (Optional.IsDefined(EntraIdAkvConfig))
            {
                writer.WritePropertyName("entraIdAkvConfig"u8);
                writer.WriteObjectValue(EntraIdAkvConfig, options);
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

        protected virtual EntraIdConfigPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdConfigPatch>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EntraIdConfigPatch)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEntraIdConfigPatch(document.RootElement, options);
        }
    }
}
