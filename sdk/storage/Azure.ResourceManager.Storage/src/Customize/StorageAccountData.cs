// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;
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

        // --- Renamed property aliases (these use different names so they can coexist) ---

        /// <summary> Backward-compatible alias for AccountMigrationInProgress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsAccountMigrationInProgress { get => Properties?.AccountMigrationInProgress; }

        /// <summary> Backward-compatible alias for DefaultToOAuthAuthentication. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsDefaultToOAuthAuthentication { get => Properties?.DefaultToOAuthAuthentication; }

        /// <summary> Backward-compatible alias for EnableExtendedGroups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsExtendedGroupEnabled { get => Properties?.EnableExtendedGroups; }

        /// <summary> Backward-compatible alias for FailoverInProgress. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsFailoverInProgress { get => Properties?.FailoverInProgress; }

        /// <summary> Backward-compatible alias for PublishIpv6Endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsIPv6EndpointToBePublished { get => Properties?.PublishIpv6Endpoint; }

        /// <summary> Backward-compatible alias for EnableNfsV3. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsNfsV3Enabled { get => Properties?.EnableNfsV3; }
    }
}
