// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
    public partial class MachineLearningWorkspacePatch
    {
        /// <summary> Gets or sets the CosmosDbCollectionsThroughput. </summary>
        [WirePath("properties.serviceManagedResourcesSettings.cosmosDb.collectionsThroughput")]
        public int? CosmosDbCollectionsThroughput
        {
            get => ServiceManagedResourcesCosmosDbCollectionsThroughput;
            set => ServiceManagedResourcesCosmosDbCollectionsThroughput = value;
        }

        /// <summary> Gets or sets the KeyIdentifier. </summary>
        [WirePath("properties.encryption.keyVaultProperties.keyIdentifier")]
        public string KeyIdentifier
        {
            get => EncryptionKeyIdentifier;
            set => EncryptionKeyIdentifier = value;
        }

        /// <summary> Whether requests from Public Network are allowed. </summary>
        public MachineLearningPublicNetworkAccess? PublicNetworkAccess
        {
            get => PublicNetworkAccessType.HasValue ? new MachineLearningPublicNetworkAccess(PublicNetworkAccessType.Value.ToString()) : null;
            set => PublicNetworkAccessType = value.HasValue ? new PublicNetworkAccess(value.Value.ToString()) : null;
        }

        /// <summary> Enabling v1_legacy_mode may prevent you from using features provided by the v2 API. </summary>
        [WirePath("properties.v1LegacyMode")]
        public bool? V1LegacyMode
        {
            get => IsV1LegacyMode;
            set => IsV1LegacyMode = value;
        }
    }
}
