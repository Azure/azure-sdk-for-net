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
        public virtual Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailability(PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckGlobally(content, cancellationToken);

        /// <summary> Check the availability of name for resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityAsync(PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => await CheckGloballyAsync(content, cancellationToken).ConfigureAwait(false);

        /// <summary> Check the availability of name for resource with location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerNameAvailabilityResult> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocation(AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckWithLocation(locationName.Name, content, cancellationToken);

        /// <summary> Check the availability of name for resource with location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerNameAvailabilityResult>> CheckPostgreSqlFlexibleServerNameAvailabilityWithLocationAsync(AzureLocation locationName, PostgreSqlFlexibleServerNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => await CheckWithLocationAsync(locationName.Name, content, cancellationToken).ConfigureAwait(false);

        /// <summary> Get location-based capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilities(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetLocationCapabilities(locationName.Name, cancellationToken);

        /// <summary> Get location-based capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerCapabilityProperties> ExecuteLocationBasedCapabilitiesAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetLocationCapabilitiesAsync(locationName.Name, cancellationToken);

        /// <summary> Get virtual network subnet usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteVirtualNetworkSubnetUsage(AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter parameter, CancellationToken cancellationToken = default)
            => GetAll(locationName.Name, parameter, cancellationToken);

        /// <summary> Get virtual network subnet usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteVirtualNetworkSubnetUsageAsync(AzureLocation locationName, PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter parameter, CancellationToken cancellationToken = default)
            => await GetAllAsync(locationName.Name, parameter, cancellationToken).ConfigureAwait(false);

        /// <summary> Get quota usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsages(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetLocationQuotaUsages(locationName.Name, cancellationToken);

        /// <summary> Get quota usages. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerQuotaUsage> GetQuotaUsagesAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetLocationQuotaUsagesAsync(locationName.Name, cancellationToken);
    }
}
