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
    /// <summary> Backward-compatible extension class preserving the old type name FlexibleServersExtensions. </summary>
    public static partial class FlexibleServersExtensions
    {
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
    }
}
