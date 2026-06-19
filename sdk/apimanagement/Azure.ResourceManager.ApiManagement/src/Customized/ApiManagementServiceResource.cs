// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceResource
    {
        // The old SDK had Deploy/Save/Validate/GetSyncState tenant configuration operations
        // directly on ApiManagementServiceResource with a ConfigurationName parameter. The new
        // generator places them on the child TenantAccessInfoResource (configurationName is part
        // of the resource ID path). These forwarding methods preserve the old API surface.
        // Not spec-fixable: resource hierarchy change is inherent to TypeSpec ARM modeling.

        /// <summary> Deploys the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<GitOperationResultContractData>> DeployTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).DeployTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Deploys the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<GitOperationResultContractData> DeployTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).DeployTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Saves the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<GitOperationResultContractData>> SaveTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationSaveContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).SaveTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Saves the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<GitOperationResultContractData> SaveTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationSaveContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).SaveTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Validates the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<GitOperationResultContractData>> ValidateTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).ValidateTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Validates the Tenant Configuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<GitOperationResultContractData> ValidateTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).ValidateTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Gets the Tenant Configuration Sync State. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<TenantConfigurationSyncStateContract>> GetTenantConfigurationSyncStateAsync(ConfigurationName configurationName, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).GetTenantConfigurationSyncStateAsync(cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the Tenant Configuration Sync State. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<TenantConfigurationSyncStateContract> GetTenantConfigurationSyncState(ConfigurationName configurationName, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).GetTenantConfigurationSyncState(cancellationToken);

        private TenantAccessInfoResource GetTenantConfigurationResource(ConfigurationName configurationName)
        {
            ResourceIdentifier id = new ResourceIdentifier($"{Id}/tenant/{configurationName}");
            return new TenantAccessInfoResource(Client, id);
        }

        // Old SDK accepted AzureLocation; new generator uses string. Forward for compat.
        // Old SDK had a simpler MigrateToStv2 overload without MigrateToStv2Contract param.

        /// <summary> Gets the Network Status By Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<NetworkStatusContract>> GetNetworkStatusByLocationAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
            => await GetNetworkStatusByLocationAsync(locationName.ToString(), cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the Network Status By Location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<NetworkStatusContract> GetNetworkStatusByLocation(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetNetworkStatusByLocation(locationName.ToString(), cancellationToken);

        /// <summary> Migrates to stv2. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ApiManagementServiceResource>> MigrateToStv2Async(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await MigrateToStv2Async(waitUntil, default(MigrateToStv2Contract), cancellationToken).ConfigureAwait(false);

        /// <summary> Migrates to stv2. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ApiManagementServiceResource> MigrateToStv2(WaitUntil waitUntil, CancellationToken cancellationToken)
            => MigrateToStv2(waitUntil, default(MigrateToStv2Contract), cancellationToken);
    }
}
