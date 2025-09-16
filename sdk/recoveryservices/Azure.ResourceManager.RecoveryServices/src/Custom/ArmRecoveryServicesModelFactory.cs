// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    public static partial class ArmRecoveryServicesModelFactory
    {
        // Manually provided factory method because VaultPropertiesRedundancySettings has public constructor with settable properties
        /// <summary> Initializes a new instance of <see cref="Models.VaultPropertiesRedundancySettings"/>. </summary>
        /// <param name="standardTierStorageRedundancy"> The storage redundancy setting of a vault. </param>
        /// <param name="crossRegionRestore"> Flag to show if Cross Region Restore is enabled on the Vault or not. </param>
        /// <returns> A new <see cref="Models.VaultPropertiesRedundancySettings"/> instance for mocking. </returns>
        public static VaultPropertiesRedundancySettings VaultPropertiesRedundancySettings(StandardTierStorageRedundancy? standardTierStorageRedundancy = null, CrossRegionRestore? crossRegionRestore = null)
        {
            return new VaultPropertiesRedundancySettings(standardTierStorageRedundancy, crossRegionRestore, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="RecoveryServices.RecoveryServicesVaultData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="identity"> Identity for the resource. </param>
        /// <param name="sku"> Identifies the unique system identifier for each Azure resource. </param>
        /// <param name="etag"> etag for the resource. </param>
        /// <returns> A new <see cref="RecoveryServices.RecoveryServicesVaultData"/> instance for mocking. </returns>
        public static RecoveryServicesVaultData RecoveryServicesVaultData(ResourceIdentifier id , string name , ResourceType resourceType , SystemData systemData , IDictionary<string, string> tags , AzureLocation location , ManagedServiceIdentity identity = null, RecoveryServicesVaultProperties properties = null, RecoveryServicesSku sku = null, ETag? etag = null)
        {
            tags ??= new Dictionary<string, string>();

            return new RecoveryServicesVaultData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                properties,
                identity,
                sku,
                etag,
                serializedAdditionalRawData: null);
        }
    }
}
