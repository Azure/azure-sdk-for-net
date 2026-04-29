// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserves the old FlexibleServersExtensions type name for backward compatibility.
    /// <summary> A class to add extension methods to Azure.ResourceManager.PostgreSql.FlexibleServers. </summary>
    public static partial class FlexibleServersExtensions
    {
        // Helper methods that delegate to the mockable resources (same pattern as generated PostgreSqlFlexibleServersExtensions)
        private static MockablePostgreSqlFlexibleServersTenantResource GetMockablePostgreSqlFlexibleServersTenantResource(TenantResource tenantResource)
        {
            return tenantResource.GetCachedClient(client => new MockablePostgreSqlFlexibleServersTenantResource(client, tenantResource.Id));
        }

        private static MockablePostgreSqlFlexibleServersSubscriptionResource GetMockablePostgreSqlFlexibleServersSubscriptionResource(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient(client => new MockablePostgreSqlFlexibleServersSubscriptionResource(client, subscriptionResource.Id));
        }
        /// <summary>
        /// Gets an object representing a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource" /> along with the instance operations that can be performed on it but with no data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.")]
        public static PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.");
        }

        /// <summary> Gets the private DNS zone suffix. </summary>
        public static async Task<Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockablePostgreSqlFlexibleServersTenantResource(tenantResource).ExecuteGetPrivateDnsZoneSuffixAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the private DNS zone suffix. </summary>
        public static Response<string> ExecuteGetPrivateDnsZoneSuffix(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockablePostgreSqlFlexibleServersTenantResource(tenantResource).ExecuteGetPrivateDnsZoneSuffix(cancellationToken);
        }

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(this SubscriptionResource subscriptionResource, string locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return await GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(locationName, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(this SubscriptionResource subscriptionResource, string locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(locationName, content, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this SubscriptionResource subscriptionResource, string locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteLocationBasedCapabilitiesAsync(locationName, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this SubscriptionResource subscriptionResource, string locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteLocationBasedCapabilities(locationName, cancellationToken);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this SubscriptionResource subscriptionResource, string locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return await GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteVirtualNetworkSubnetUsageAsync(locationName, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this SubscriptionResource subscriptionResource, string locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).ExecuteVirtualNetworkSubnetUsage(locationName, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(this SubscriptionResource subscriptionResource, string locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).GetQuotaUsagesAsync(locationName, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(this SubscriptionResource subscriptionResource, string locationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockablePostgreSqlFlexibleServersSubscriptionResource(subscriptionResource).GetQuotaUsages(locationName, cancellationToken);
        }

        // =====================================================================
        // ArmClient resource getter extensions (delegate to generated class)
        // =====================================================================

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerBackupResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerBackupResource GetPostgreSqlFlexibleServerBackupResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerBackupResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerConfigurationResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerConfigurationResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerDatabaseResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerDatabaseResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerFirewallRuleResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerFirewallRuleResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServersPrivateEndpointConnectionResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServersPrivateLinkResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersPrivateLinkResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlFlexibleServerTuningOptionResource"/> from an ArmClient. </summary>
        public static PostgreSqlFlexibleServerTuningOptionResource GetPostgreSqlFlexibleServerTuningOptionResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerTuningOptionResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlLtrServerBackupOperationResource"/> from an ArmClient. </summary>
        public static PostgreSqlLtrServerBackupOperationResource GetPostgreSqlLtrServerBackupOperationResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlLtrServerBackupOperationResource(client, id);
        }

        /// <summary> Gets a <see cref="PostgreSqlMigrationResource"/> from an ArmClient. </summary>
        public static PostgreSqlMigrationResource GetPostgreSqlMigrationResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlMigrationResource(client, id);
        }

        /// <summary> Gets a <see cref="ServerThreatProtectionSettingsModelResource"/> from an ArmClient. </summary>
        public static ServerThreatProtectionSettingsModelResource GetServerThreatProtectionSettingsModelResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetServerThreatProtectionSettingsModelResource(client, id);
        }

        /// <summary> Gets a <see cref="VirtualEndpointResource"/> from an ArmClient. </summary>
        public static VirtualEndpointResource GetVirtualEndpointResource(this ArmClient client, ResourceIdentifier id)
        {
            return PostgreSqlFlexibleServersExtensions.GetVirtualEndpointResource(client, id);
        }

        // =====================================================================
        // ResourceGroup-level extensions (delegate to generated class)
        // =====================================================================

        /// <summary> Gets a collection of PostgreSqlFlexibleServers in the ResourceGroupResource. </summary>
        public static PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers(this ResourceGroupResource resourceGroupResource)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServers(resourceGroupResource);
        }

        /// <summary> Gets information about an existing server. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(this ResourceGroupResource resourceGroupResource, string serverName, CancellationToken cancellationToken = default)
        {
            return await PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerAsync(resourceGroupResource, serverName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets information about an existing server. </summary>
        [ForwardsClientCalls]
        public static Response<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(this ResourceGroupResource resourceGroupResource, string serverName, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServer(resourceGroupResource, serverName, cancellationToken);
        }

        // =====================================================================
        // Subscription-level extensions (delegate to generated class)
        // =====================================================================

        /// <summary> Checks the validity and availability of the given name. </summary>
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityAsync(this SubscriptionResource subscriptionResource, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await PostgreSqlFlexibleServersExtensions.CheckPostgreSqlFlexibleServerNameAvailabilityAsync(subscriptionResource, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks the validity and availability of the given name. </summary>
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailability(this SubscriptionResource subscriptionResource, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.CheckPostgreSqlFlexibleServerNameAvailability(subscriptionResource, content, cancellationToken);
        }

        /// <summary> Lists all servers in a subscription. </summary>
        public static AsyncPageable<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersAsync(subscriptionResource, cancellationToken);
        }

        /// <summary> Lists all servers in a subscription. </summary>
        public static Pageable<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServers(subscriptionResource, cancellationToken);
        }

        // =====================================================================
        // AzureLocation overloads for existing string-based methods
        // =====================================================================

        /// <summary> Check the availability of name for resource. </summary>
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await PostgreSqlFlexibleServersExtensions.CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(subscriptionResource, locationName, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check the availability of name for resource. </summary>
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(subscriptionResource, locationName, content, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        public static AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.ExecuteLocationBasedCapabilitiesAsync(subscriptionResource, locationName, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        public static Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.ExecuteLocationBasedCapabilities(subscriptionResource, locationName, cancellationToken);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        public static async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return await PostgreSqlFlexibleServersExtensions.ExecuteVirtualNetworkSubnetUsageAsync(subscriptionResource, locationName, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        public static Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.ExecuteVirtualNetworkSubnetUsage(subscriptionResource, locationName, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        public static AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.GetQuotaUsagesAsync(subscriptionResource, locationName, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        public static Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return PostgreSqlFlexibleServersExtensions.GetQuotaUsages(subscriptionResource, locationName, cancellationToken);
        }
    }
}
