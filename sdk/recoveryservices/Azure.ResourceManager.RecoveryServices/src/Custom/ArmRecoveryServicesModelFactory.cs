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
            return new VaultPropertiesRedundancySettings(standardTierStorageRedundancy, crossRegionRestore, additionalBinaryDataProperties: null);
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
        public static RecoveryServicesVaultData RecoveryServicesVaultData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedServiceIdentity identity = null, RecoveryServicesVaultProperties properties = null, RecoveryServicesSku sku = null, ETag? etag = null)
        {
            //return RecoveryServicesVaultData(id, name, resourceType, systemData, tags, location, properties, identity, sku, etag);
            throw new NotImplementedException();
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings" />. </summary>
        /// <param name="immutabilityState"> Immutability Settings of a vault. </param>
        /// <param name="softDeleteSettings"> Soft delete Settings of a vault. </param>
        /// <param name="multiUserAuthorization"> MUA Settings of a vault. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesSecuritySettings" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RecoveryServicesSecuritySettings RecoveryServicesSecuritySettings(ImmutabilityState? immutabilityState, RecoveryServicesSoftDeleteSettings softDeleteSettings, MultiUserAuthorization? multiUserAuthorization)
        {
            return RecoveryServicesSecuritySettings(immutabilityState: immutabilityState, softDeleteSettings: softDeleteSettings, multiUserAuthorization: multiUserAuthorization, sourceScanConfiguration: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties" />. </summary>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <param name="upgradeDetails"> Details for upgrading vault. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection. </param>
        /// <param name="privateEndpointStateForBackup"> Private endpoint state for backup. </param>
        /// <param name="privateEndpointStateForSiteRecovery"> Private endpoint state for site recovery. </param>
        /// <param name="encryption"> Customer Managed Key details of the resource. </param>
        /// <param name="moveDetails"> The details of the latest move operation performed on the Azure Resource. </param>
        /// <param name="moveState"> The State of the Resource after the move operation. </param>
        /// <param name="backupStorageVersion"> Backup storage version. </param>
        /// <param name="publicNetworkAccess"> property to enable or disable resource provider inbound network traffic from public clients. </param>
        /// <param name="monitoringSettings"> Monitoring Settings of the vault. </param>
        /// <param name="crossSubscriptionRestoreState"> Restore Settings of the vault. </param>
        /// <param name="redundancySettings"> The redundancy Settings of a Vault. </param>
        /// <param name="securitySettings"> Security Settings of the vault. </param>
        /// <param name="secureScore"> Secure Score of Recovery Services Vault. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.RecoveryServices.Models.RecoveryServicesVaultProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RecoveryServicesVaultProperties RecoveryServicesVaultProperties(string provisioningState, VaultUpgradeDetails upgradeDetails, IEnumerable<RecoveryServicesPrivateEndpointConnectionVaultProperties> privateEndpointConnections, VaultPrivateEndpointState? privateEndpointStateForBackup, VaultPrivateEndpointState? privateEndpointStateForSiteRecovery, VaultPropertiesEncryption encryption, VaultPropertiesMoveDetails moveDetails, ResourceMoveState? moveState, BackupStorageVersion? backupStorageVersion, VaultPublicNetworkAccess? publicNetworkAccess, VaultMonitoringSettings monitoringSettings, CrossSubscriptionRestoreState? crossSubscriptionRestoreState, VaultPropertiesRedundancySettings redundancySettings, RecoveryServicesSecuritySettings securitySettings, SecureScoreLevel? secureScore)
        {
            return RecoveryServicesVaultProperties(provisioningState, upgradeDetails, privateEndpointConnections, privateEndpointStateForBackup, privateEndpointStateForSiteRecovery, encryption, moveDetails, moveState, backupStorageVersion, publicNetworkAccess, monitoringSettings, restoreSettings: default, redundancySettings, securitySettings, secureScore, bcdrSecurityLevel: default, resourceGuardOperationRequests: default);
        }
    }
}
