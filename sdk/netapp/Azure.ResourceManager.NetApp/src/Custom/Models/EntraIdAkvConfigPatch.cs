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
    // Keep the old source surface for compatibility with prior SDK releases.
    /// <summary> Entra ID Azure Key Vault configuration patch. </summary>
    public partial class EntraIdAkvConfigPatch : IJsonModel<EntraIdAkvConfigPatch>, IPersistableModel<EntraIdAkvConfigPatch>
    {
        /// <summary> Initializes a new instance of <see cref="EntraIdAkvConfigPatch"/>. </summary>
        public EntraIdAkvConfigPatch()
        {
        }

        /// <summary> The Azure Key Vault URI. </summary>
        public Uri AzureKeyVaultUri { get; set; }

        /// <summary> The certificate name. </summary>
        public string CertificateName { get; set; }

        /// <summary> The user-assigned managed identity. </summary>
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get; set; }

        protected virtual EntraIdAkvConfigPatch PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return BinaryData.FromString("{}");
        }

        EntraIdAkvConfigPatch IPersistableModel<EntraIdAkvConfigPatch>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<EntraIdAkvConfigPatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<EntraIdAkvConfigPatch>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<EntraIdAkvConfigPatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        EntraIdAkvConfigPatch IJsonModel<EntraIdAkvConfigPatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual EntraIdAkvConfigPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new EntraIdAkvConfigPatch();
        }
    }
}
