// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;

namespace Azure.ResourceManager.NetApp.Models
{
    // The 2026 TypeSpec model removed the legacy Entra ID account wrapper.
    // Preserve the shipped constructor/property shape for source compatibility.
    /// <summary> Entra ID configuration. </summary>
    public partial class EntraIdConfig : IJsonModel<EntraIdConfig>, IPersistableModel<EntraIdConfig>
    {
        /// <summary> Initializes a new instance of <see cref="EntraIdConfig"/>. </summary>
        public EntraIdConfig(string applicationId, string domain, string serverNamePrefix)
        {
            ApplicationId = applicationId;
            Domain = domain;
            ServerNamePrefix = serverNamePrefix;
        }

        /// <summary> The application identifier. </summary>
        public string ApplicationId { get; set; }

        /// <summary> The domain name. </summary>
        public string Domain { get; set; }

        /// <summary> The server name prefix. </summary>
        public string ServerNamePrefix { get; set; }

        /// <summary> The Azure Key Vault configuration. </summary>
        public EntraIdAkvConfig EntraIdAkvConfig { get; set; }

        protected virtual EntraIdConfig PersistableModelCreateCore(System.BinaryData data, ModelReaderWriterOptions options)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            return JsonModelCreateCore(ref reader, options);
        }

        protected virtual System.BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            return System.BinaryData.FromString("{}");
        }

        EntraIdConfig IPersistableModel<EntraIdConfig>.Create(System.BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        string IPersistableModel<EntraIdConfig>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        System.BinaryData IPersistableModel<EntraIdConfig>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        void IJsonModel<EntraIdConfig>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        EntraIdConfig IJsonModel<EntraIdConfig>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        protected virtual EntraIdConfig JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            return new EntraIdConfig(null, null, null);
        }
    }
}
