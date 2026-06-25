// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.MachineLearning.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve GA property shapes. CosmosDbCollectionsThroughput is a flattened alias
    // over generated service-managed settings, Encryption uses a legacy compatibility model, and
    // PublicNetworkAccess used Azure.Core.PublicNetworkAccess.
    [CodeGenSuppress("Encryption")]
    [CodeGenSuppress("PublicNetworkAccess")]
    public partial class MachineLearningWorkspaceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningWorkspaceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningWorkspaceData(AzureLocation location)
            : base(location)
        {
        }

        /// <summary> Gets or sets the CosmosDbCollectionsThroughput. </summary>
        [WirePath("properties.serviceManagedResourcesSettings.cosmosDb.collectionsThroughput")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CosmosDbCollectionsThroughput
        {
            get => ServiceManagedResourcesCosmosDbCollectionsThroughput;
            set => ServiceManagedResourcesCosmosDbCollectionsThroughput = value;
        }

        /// <summary> Gets or sets the Encryption. </summary>
        [WirePath("properties.encryption")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningEncryptionSetting Encryption
        {
            get
            {
                if (Properties?.Encryption is null)
                {
                    return default;
                }

                if (Properties.Encryption.KeyVaultProperties is null)
                {
                    return default;
                }

                Azure.ResourceManager.MachineLearning.Models.KeyVaultProperties keyVaultProperties = Properties.Encryption.KeyVaultProperties;
                var legacyKeyVaultProperties = new MachineLearningEncryptionKeyVaultProperties(keyVaultProperties.KeyVaultArmId, keyVaultProperties.KeyIdentifier)
                {
                    IdentityClientId = keyVaultProperties.IdentityClientId
                };
                return new MachineLearningEncryptionSetting(Properties.Encryption.Status, Properties.Encryption.UserAssignedIdentity is null ? null : new MachineLearningCmkIdentity(new ResourceIdentifier(Properties.Encryption.UserAssignedIdentity), serializedAdditionalRawData: null), legacyKeyVaultProperties, serializedAdditionalRawData: null);
            }
            set
            {
                Properties ??= new WorkspaceProperties();
                Properties.Encryption = value is null ? null : new EncryptionProperty(
                    cosmosDbResourceId: default,
                    identity: value.UserAssignedIdentity is null ? null : new IdentityForCmk(value.UserAssignedIdentity.ToString(), additionalBinaryDataProperties: null),
                    keyVaultProperties: value.KeyVaultProperties is null ? null : new Azure.ResourceManager.MachineLearning.Models.KeyVaultProperties(value.KeyVaultProperties.KeyIdentifier, value.KeyVaultProperties.KeyVaultArmId)
                    {
                        IdentityClientId = value.KeyVaultProperties.IdentityClientId
                    },
                    searchAccountResourceId: default,
                    status: value.Status,
                    storageAccountResourceId: default,
                    additionalBinaryDataProperties: null);
            }
        }

        /// <summary> Whether requests from Public Network are allowed. </summary>
        [WirePath("properties.publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PublicNetworkAccess? PublicNetworkAccessType
        {
            get => PublicNetworkAccess.HasValue ? new PublicNetworkAccess(PublicNetworkAccess.Value.ToString()) : null;
            set => PublicNetworkAccess = value.HasValue ? new MachineLearningPublicNetworkAccess(value.Value.ToString()) : null;
        }

        /// <summary> Whether requests from Public Network are allowed. </summary>
        [WirePath("properties.publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPublicNetworkAccess? PublicNetworkAccess { get; set; }
    }
}
