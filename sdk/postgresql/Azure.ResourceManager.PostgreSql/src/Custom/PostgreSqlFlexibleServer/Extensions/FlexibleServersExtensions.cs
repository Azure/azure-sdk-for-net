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
    /// <summary> Backward-compat extension methods using old class name. </summary>
    public static partial class FlexibleServersExtensions
    {
        /// <summary>
        /// Gets an object representing a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.")]
        public static PostgreSqlFlexibleServerActiveDirectoryAdministratorResource GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' instead.");
        }

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailability(this SubscriptionResource subscriptionResource, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.CheckGlobally(subscriptionResource, content, cancellationToken);

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityAsync(this SubscriptionResource subscriptionResource, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => await PostgreSqlFlexibleServersExtensions.CheckGloballyAsync(subscriptionResource, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Check the availability of name for resource with location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.CheckWithLocation(subscriptionResource, locationName, content, cancellationToken);

        /// <summary> Check the availability of name for resource with location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => await PostgreSqlFlexibleServersExtensions.CheckWithLocationAsync(subscriptionResource, locationName, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Get location-based capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetLocationCapabilities(subscriptionResource, locationName, cancellationToken);

        /// <summary> Get location-based capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetLocationCapabilitiesAsync(subscriptionResource, locationName, cancellationToken);

        /// <summary> Get virtual network subnet usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter parameter, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetAll(subscriptionResource, locationName, parameter, cancellationToken);

        /// <summary> Get virtual network subnet usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter parameter, CancellationToken cancellationToken = default)
            => await PostgreSqlFlexibleServersExtensions.GetAllAsync(subscriptionResource, locationName, parameter, cancellationToken).ConfigureAwait(false);

        /// <summary> Get quota usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetLocationQuotaUsages(subscriptionResource, locationName, cancellationToken);

        /// <summary> Get quota usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation locationName, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetLocationQuotaUsagesAsync(subscriptionResource, locationName, cancellationToken);

        /// <summary> Get private DNS zone suffix. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<string> ExecuteGetPrivateDnsZoneSuffix(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return tenantResource.GetCachedClient(client => new MockablePostgreSqlFlexibleServersTenantResource(client, tenantResource.Id)).ExecuteGetPrivateDnsZoneSuffix(cancellationToken);
        }

        /// <summary> Get private DNS zone suffix. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<string>> ExecuteGetPrivateDnsZoneSuffixAsync(this TenantResource tenantResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await tenantResource.GetCachedClient(client => new MockablePostgreSqlFlexibleServersTenantResource(client, tenantResource.Id)).ExecuteGetPrivateDnsZoneSuffixAsync(cancellationToken).ConfigureAwait(false);
        }

        // ARM standard extension methods that were on old FlexibleServersExtensions class.
        // Now generated on PostgreSqlFlexibleServersExtensions. These shims maintain backward compat.

        /// <summary> Gets a PostgreSqlFlexibleServerResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerBackupResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerBackupResource GetPostgreSqlFlexibleServerBackupResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerBackupResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerConfigurationResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerConfigurationResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerDatabaseResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerDatabaseResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerFirewallRuleResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerFirewallRuleResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServersPrivateEndpointConnectionResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServersPrivateLinkResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersPrivateLinkResource(client, id);

        /// <summary> Gets a PostgreSqlFlexibleServerTuningOptionResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerTuningOptionResource GetPostgreSqlFlexibleServerTuningOptionResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerTuningOptionResource(client, id);

        /// <summary> Gets a PostgreSqlLtrServerBackupOperationResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlLtrServerBackupOperationResource GetPostgreSqlLtrServerBackupOperationResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlLtrServerBackupOperationResource(client, id);

        /// <summary> Gets a PostgreSqlMigrationResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlMigrationResource GetPostgreSqlMigrationResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlMigrationResource(client, id);

        /// <summary> Gets a ServerThreatProtectionSettingsModelResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServerThreatProtectionSettingsModelResource GetServerThreatProtectionSettingsModelResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetServerThreatProtectionSettingsModelResource(client, id);

        /// <summary> Gets a VirtualEndpointResource along with instance operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VirtualEndpointResource GetVirtualEndpointResource(this ArmClient client, ResourceIdentifier id)
            => PostgreSqlFlexibleServersExtensions.GetVirtualEndpointResource(client, id);

        /// <summary> Gets a collection of PostgreSqlFlexibleServerResources. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers(this ResourceGroupResource resourceGroupResource)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServers(resourceGroupResource);

        /// <summary> Gets a PostgreSqlFlexibleServerResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(this ResourceGroupResource resourceGroupResource, string serverName, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServer(resourceGroupResource, serverName, cancellationToken);

        /// <summary> Gets a PostgreSqlFlexibleServerResource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(this ResourceGroupResource resourceGroupResource, string serverName, CancellationToken cancellationToken = default)
            => await PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerAsync(resourceGroupResource, serverName, cancellationToken).ConfigureAwait(false);

        /// <summary> Lists all PostgreSqlFlexibleServerResources in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServers(subscriptionResource, cancellationToken);

        /// <summary> Lists all PostgreSqlFlexibleServerResources in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServersAsync(subscriptionResource, cancellationToken);
    }
}
