// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> The parameters for updating a machine learning workspace. </summary>
    public partial class MachineLearningWorkspacePatch : Azure.ResourceManager.MachineLearning.Models.WorkspacePatch, IJsonModel<MachineLearningWorkspacePatch>
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningWorkspacePatch"/>. </summary>
        public MachineLearningWorkspacePatch()
        {
        }

        internal MachineLearningWorkspacePatch(WorkspacePatch patch)
            : base(patch.Identity, patch.Properties, patch.Sku, patch.Tags, additionalBinaryDataProperties: null)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new MachineLearningPublicNetworkAccess? PublicNetworkAccess
        {
            get => base.PublicNetworkAccess?.ToString();
            set => base.PublicNetworkAccess = value?.ToString();
        }

        /// <summary> Gets or sets the CosmosDbCollectionsThroughput. </summary>
        [WirePath("properties.serviceManagedResourcesSettings.cosmosDb.collectionsThroughput")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CosmosDbCollectionsThroughput
        {
            get => ServiceManagedResourcesCosmosDbCollectionsThroughput;
            set => ServiceManagedResourcesCosmosDbCollectionsThroughput = value;
        }

        /// <summary> Gets or sets the KeyIdentifier. </summary>
        [WirePath("properties.encryption.keyVaultProperties.keyIdentifier")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyIdentifier
        {
            get => EncryptionKeyIdentifier;
            set => EncryptionKeyIdentifier = value;
        }

        /// <summary> Enabling v1_legacy_mode may prevent you from using features provided by the v2 API. </summary>
        [WirePath("properties.v1LegacyMode")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? V1LegacyMode
        {
            get => IsV1LegacyMode;
            set => IsV1LegacyMode = value;
        }

        void IJsonModel<MachineLearningWorkspacePatch>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<WorkspacePatch>)this).Write(writer, options);
        }

        MachineLearningWorkspacePatch IJsonModel<MachineLearningWorkspacePatch>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMachineLearningWorkspacePatch(document.RootElement, options);
        }

        BinaryData IPersistableModel<MachineLearningWorkspacePatch>.Write(ModelReaderWriterOptions options)
        {
            return ((IPersistableModel<WorkspacePatch>)this).Write(options);
        }

        MachineLearningWorkspacePatch IPersistableModel<MachineLearningWorkspacePatch>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MachineLearningWorkspacePatch>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        return DeserializeMachineLearningWorkspacePatch(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MachineLearningWorkspacePatch)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MachineLearningWorkspacePatch>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningWorkspacePatch DeserializeMachineLearningWorkspacePatch(JsonElement element, ModelReaderWriterOptions options)
        {
            WorkspacePatch patch = WorkspacePatch.DeserializeWorkspacePatch(element, options);
            return patch is null ? null : new MachineLearningWorkspacePatch(patch);
        }
    }
}
