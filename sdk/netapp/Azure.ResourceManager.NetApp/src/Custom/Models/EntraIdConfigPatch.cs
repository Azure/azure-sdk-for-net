// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

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
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
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
        }

        protected virtual EntraIdConfigPatch JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new EntraIdConfigPatch();
        }
    }
}
