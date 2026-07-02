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
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
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
        }

        protected virtual EntraIdAkvConfig JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new EntraIdAkvConfig();
        }
    }
}
