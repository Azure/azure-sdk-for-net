// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    public partial class MockablePostgreSqlFlexibleServersSubscriptionResource
    {
        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(string locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(new AzureLocation(locationName), content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(string locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(new AzureLocation(locationName), content, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(string locationName, CancellationToken cancellationToken = default)
        {
            return ExecuteLocationBasedCapabilitiesAsync(new AzureLocation(locationName), cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(string locationName, CancellationToken cancellationToken = default)
        {
            return ExecuteLocationBasedCapabilities(new AzureLocation(locationName), cancellationToken);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(string locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return await ExecuteVirtualNetworkSubnetUsageAsync(new AzureLocation(locationName), postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(string locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return ExecuteVirtualNetworkSubnetUsage(new AzureLocation(locationName), postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(string locationName, CancellationToken cancellationToken = default)
        {
            return GetQuotaUsagesAsync(new AzureLocation(locationName), cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(string locationName, CancellationToken cancellationToken = default)
        {
            return GetQuotaUsages(new AzureLocation(locationName), cancellationToken);
        }
    }
}
