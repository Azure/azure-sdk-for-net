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
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public StorageProvisioningState? ProvisioningState
        {
            get
            {
                var state = Properties?.ProvisioningState;
                if (state == null) return null;
                return StorageProvisioningStateExtensions.ToStorageProvisioningState(state.Value.ToSerialString());
            }
        }

        /// <summary> Gets the status of the storage account at the time the operation was called. Backward-compatible alias. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public Azure.ResourceManager.Storage.Models.StorageAccountProvisioningState? StorageAccountProvisioningState => Properties?.ProvisioningState;

        // --- Renamed property aliases (backward-compat, different name from generated) ---

        /// <summary> Backward-compatible alias for AccountMigrationInProgress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.accountMigrationInProgress")]
        public bool? IsAccountMigrationInProgress { get => Properties?.AccountMigrationInProgress; }

        /// <summary> Backward-compatible alias for DefaultToOAuthAuthentication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.defaultToOAuthAuthentication")]
        public bool? IsDefaultToOAuthAuthentication { get => Properties?.DefaultToOAuthAuthentication; set { } }

        /// <summary> Backward-compatible alias for EnableExtendedGroups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.enableExtendedGroups")]
        public bool? IsExtendedGroupEnabled { get => Properties?.EnableExtendedGroups; set { } }

        /// <summary> Backward-compatible alias for FailoverInProgress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.failoverInProgress")]
        public bool? IsFailoverInProgress { get => Properties?.FailoverInProgress; }

        /// <summary> Backward-compatible alias for PublishIpv6Endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.dualStackEndpointPreference.publishIpv6Endpoint")]
        public bool? IsIPv6EndpointToBePublished { get => Properties?.PublishIpv6Endpoint; set { } }

        /// <summary> Backward-compatible alias for EnableNfsV3. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNfsV3Enabled")]
        public bool? IsNfsV3Enabled { get => Properties?.EnableNfsV3; set { } }
    }
}
