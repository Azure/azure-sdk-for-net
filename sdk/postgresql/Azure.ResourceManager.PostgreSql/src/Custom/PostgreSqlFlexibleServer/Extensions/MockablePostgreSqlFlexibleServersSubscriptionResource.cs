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
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return await CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(locationName.Name, content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Check the availability of name for resource. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            return CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(locationName.Name, content, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerCapabilityProperties"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return ExecuteLocationBasedCapabilitiesAsync(locationName.Name, cancellationToken);
        }

        /// <summary> Lists the capabilities available in a given location for a specific subscription. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerCapabilityProperties"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return ExecuteLocationBasedCapabilities(locationName.Name, cancellationToken);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return await ExecuteVirtualNetworkSubnetUsageAsync(locationName.Name, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Lists the virtual network subnet usage for a given virtual network. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, CancellationToken cancellationToken = default)
        {
            return ExecuteVirtualNetworkSubnetUsage(locationName.Name, postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerQuotaUsage"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return GetQuotaUsagesAsync(locationName.Name, cancellationToken);
        }

        /// <summary> Get quota usages at specified location in a given subscription. </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerQuotaUsage"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(AzureLocation locationName, CancellationToken cancellationToken = default)
        {
            return GetQuotaUsages(locationName.Name, cancellationToken);
        }
    }
}
