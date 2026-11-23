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
    // The 2026 TypeSpec model removed the legacy Entra ID key vault wrapper.
    // Keep the old source surface so older callers can still construct account config objects.
    /// <summary> Entra ID Azure Key Vault configuration. </summary>
    public partial class EntraIdAkvConfig : IJsonModel<EntraIdAkvConfig>, IPersistableModel<EntraIdAkvConfig>
    {
        /// <summary> Initializes a new instance of <see cref="EntraIdAkvConfig"/>. </summary>
        public EntraIdAkvConfig()
        {
        }

        /// <summary> Initializes a new instance of <see cref="EntraIdAkvConfig"/>. </summary>
        public EntraIdAkvConfig(Uri azureKeyVaultUri, string certificateName)
        {
            AzureKeyVaultUri = azureKeyVaultUri;
            CertificateName = certificateName;
        }

        /// <summary> The Azure Key Vault URI. </summary>
        public Uri AzureKeyVaultUri { get; set; }

        /// <summary> The certificate name. </summary>
        public string CertificateName { get; set; }

        /// <summary> The user-assigned managed identity. </summary>
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get; set; }

        protected virtual EntraIdAkvConfig PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdAkvConfig>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeEntraIdAkvConfig(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(EntraIdAkvConfig)} does not support reading '{options.Format}' format.");
            }
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdAkvConfig>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerNetAppContext.Default);
                default:
                    throw new FormatException($"The model {nameof(EntraIdAkvConfig)} does not support writing '{options.Format}' format.");
            }
        }

        EntraIdAkvConfig IPersistableModel<EntraIdAkvConfig>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<EntraIdAkvConfig>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<EntraIdAkvConfig>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<EntraIdAkvConfig>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        EntraIdAkvConfig IJsonModel<EntraIdAkvConfig>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdAkvConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EntraIdAkvConfig)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(AzureKeyVaultUri))
            {
                writer.WritePropertyName("azureKeyVaultUri"u8);
                writer.WriteStringValue(AzureKeyVaultUri.OriginalString);
            }
            if (Optional.IsDefined(CertificateName))
            {
                writer.WritePropertyName("certificateName"u8);
                writer.WriteStringValue(CertificateName);
            }
            if (Optional.IsDefined(UserAssignedIdentity))
            {
                writer.WritePropertyName("userAssignedIdentity"u8);
                writer.WriteStringValue(UserAssignedIdentity);
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

        protected virtual EntraIdAkvConfig JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<EntraIdAkvConfig>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EntraIdAkvConfig)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEntraIdAkvConfig(document.RootElement, options);
        }
    }
}
