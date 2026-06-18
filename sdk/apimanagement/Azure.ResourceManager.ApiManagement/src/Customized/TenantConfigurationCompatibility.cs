// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> The identifier of the Git configuration. </summary>
    public readonly partial struct ConfigurationName : IEquatable<ConfigurationName>
    {
        private readonly string _value;
        private const string ConfigurationValue = "configuration";

        /// <summary> Initializes a new instance of <see cref="ConfigurationName"/>. </summary>
        /// <param name="value"> The value. </param>
        public ConfigurationName(string value)
        {
            Argument.AssertNotNull(value, nameof(value));
            _value = value;
        }

        /// <summary> Gets the Configuration. </summary>
        public static ConfigurationName Configuration { get; } = new ConfigurationName(ConfigurationValue);

        /// <summary> Converts a string to a <see cref="ConfigurationName"/>. </summary>
        public static implicit operator ConfigurationName(string value) => new ConfigurationName(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConfigurationName other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(ConfigurationName other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        /// <summary> Determines if two <see cref="ConfigurationName"/> values are the same. </summary>
        public static bool operator ==(ConfigurationName left, ConfigurationName right) => left.Equals(right);

        /// <summary> Determines if two <see cref="ConfigurationName"/> values are not the same. </summary>
        public static bool operator !=(ConfigurationName left, ConfigurationName right) => !left.Equals(right);

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceResource
    {
        /// <summary> Deploys the Tenant Configuration. </summary>
        public virtual async Task<ArmOperation<GitOperationResultContractData>> DeployTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).DeployTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Deploys the Tenant Configuration. </summary>
        public virtual ArmOperation<GitOperationResultContractData> DeployTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).DeployTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Saves the Tenant Configuration. </summary>
        public virtual async Task<ArmOperation<GitOperationResultContractData>> SaveTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationSaveContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).SaveTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Saves the Tenant Configuration. </summary>
        public virtual ArmOperation<GitOperationResultContractData> SaveTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationSaveContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).SaveTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Validates the Tenant Configuration. </summary>
        public virtual async Task<ArmOperation<GitOperationResultContractData>> ValidateTenantConfigurationAsync(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).ValidateTenantConfigurationAsync(waitUntil, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Validates the Tenant Configuration. </summary>
        public virtual ArmOperation<GitOperationResultContractData> ValidateTenantConfiguration(WaitUntil waitUntil, ConfigurationName configurationName, ConfigurationDeployContent content, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).ValidateTenantConfiguration(waitUntil, content, cancellationToken);

        /// <summary> Gets the Tenant Configuration Sync State. </summary>
        public virtual async Task<Response<TenantConfigurationSyncStateContract>> GetTenantConfigurationSyncStateAsync(ConfigurationName configurationName, CancellationToken cancellationToken = default)
            => await GetTenantConfigurationResource(configurationName).GetTenantConfigurationSyncStateAsync(cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the Tenant Configuration Sync State. </summary>
        public virtual Response<TenantConfigurationSyncStateContract> GetTenantConfigurationSyncState(ConfigurationName configurationName, CancellationToken cancellationToken = default)
            => GetTenantConfigurationResource(configurationName).GetTenantConfigurationSyncState(cancellationToken);

        private TenantAccessInfoResource GetTenantConfigurationResource(ConfigurationName configurationName)
        {
            ResourceIdentifier id = new ResourceIdentifier($"{Id}/tenant/{configurationName}");
            return new TenantAccessInfoResource(Client, id);
        }
    }
}
