// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ApplicationGatewayAvailableSslOptionsInfo : IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>, IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>
    {
        // The legacy type has no generated reader; reuse the base reader to retain ResourceType.
        ApplicationGatewayAvailableSslOptionsInfo IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => FromMetadata(((IJsonModel<NetworkTrackedResourceData>)new NetworkTrackedResourceData()).Create(ref reader, options));

        // Call the base core directly: covariant interface delegation would re-enter this writer recursively.
        void IJsonModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            base.JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        // Reuse the generated base persistence reader; the legacy adapter currently restores only ResourceType.
        ApplicationGatewayAvailableSslOptionsInfo IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromMetadata(ModelReaderWriter.Read<NetworkTrackedResourceData>(data, options, AzureResourceManagerNetworkContext.Default));

        string IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        // Preserve native metadata persistence and the base writer's read-only wire visibility rules.
        BinaryData IPersistableModel<ApplicationGatewayAvailableSslOptionsInfo>.Write(ModelReaderWriterOptions options)
            => ModelReaderWriter.Write<NetworkTrackedResourceData>(this, options, AzureResourceManagerNetworkContext.Default);

        // Transfer only the repaired ResourceType path; this is not full legacy-payload deserialization.
        private static ApplicationGatewayAvailableSslOptionsInfo FromMetadata(NetworkTrackedResourceData metadata)
        {
            if (metadata is null)
            {
                return null;
            }
            var result = new ApplicationGatewayAvailableSslOptionsInfo();
            ((NetworkTrackedResourceData)result).ResourceType = metadata.ResourceType;
            return result;
        }

        // Let the generated base serialize metadata and decide which fields belong in persisted versus wire JSON.
        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => base.JsonModelWriteCore(writer, options);
    }
}
