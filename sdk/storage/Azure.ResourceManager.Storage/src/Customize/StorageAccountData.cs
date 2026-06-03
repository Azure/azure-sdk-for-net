// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Converts provisioning state from generated type to legacy enum/struct style
// and adds aliases for renamed boolean properties (IsHnsEnabled, IsSftpEnabled, etc.).
// The provisioning state change requires custom code; property renames could use @@clientName.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountData : TrackedResourceData
    {
        // Prior GA exposed ProvisioningState as StorageProvisioningState enum;
        // generated code uses StorageAccountProvisioningState. This converts for backward compat.
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public StorageProvisioningState? ProvisioningState
        {
            get
            {
                var state = Properties?.ProvisioningState;
                if (state == null)
                    return null;
                return StorageProvisioningStateExtensions.ToStorageProvisioningState(state.Value.ToSerialString());
            }
        }

        // Backward-compatible alias for StorageAccountProvisioningState.
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? StorageAccountProvisioningState => Properties?.ProvisioningState;

        // --- Renamed property aliases (backward-compat, different name from generated) ---

        // Backward-compatible alias for AccountMigrationInProgress.
        /// <summary> Indicates whether account migration is in progress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.accountMigrationInProgress")]
        public bool? IsAccountMigrationInProgress { get => Properties?.IsAccountMigrationInProgress; }

        // Backward-compatible alias for IsDefaultToOAuthAuthentication.
        /// <summary> Indicates whether the default authentication is OAuth or shared key. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.defaultToOAuthAuthentication")]
        public bool? IsDefaultToOAuthAuthentication { get => Properties?.IsDefaultToOAuthAuthentication; set { } }

        // Backward-compatible alias for IsExtendedGroupEnabled.
        /// <summary> Indicates whether extended groups are enabled. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableExtendedGroups")]
        public bool? IsExtendedGroupEnabled { get => Properties?.IsExtendedGroupEnabled; set { } }

        // Backward-compatible alias for IsFailoverInProgress.
        /// <summary> Indicates whether account failover is in progress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.failoverInProgress")]
        public bool? IsFailoverInProgress { get => Properties?.IsFailoverInProgress; }

        // Backward-compatible alias for IsIPv6EndpointToBePublished.
        /// <summary> Indicates whether the IPv6 endpoint should be published for the storage account. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.dualStackEndpointPreference.publishIpv6Endpoint")]
        public bool? IsIPv6EndpointToBePublished { get => Properties?.IsIPv6EndpointToBePublished; set { } }

        // Backward-compatible alias for IsNfsV3Enabled.
        /// <summary> Account NFSv3 protocol enabled if set to true. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNfsV3Enabled")]
        public bool? IsNfsV3Enabled { get => Properties?.IsNfsV3Enabled; set { } }
    }
}
