// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration.Mocking
{
    // Backward-compat justification: the GA mockable subscription helpers used AzureLocation and the old GetSkusResourceSkus name.
    public partial class MockableDataMigrationSubscriptionResource
    {
        /// <summary>
        /// This method checks whether a proposed top-level resource name is valid and available.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Services_CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataMigrationServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The Azure region of the operation. </param>
        /// <param name="content"> Requested name to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailability(location.ToString(), content, cancellationToken);

        /// <summary>
        /// This method checks whether a proposed top-level resource name is valid and available.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/locations/{location}/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Services_CheckNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataMigrationServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The Azure region of the operation. </param>
        /// <param name="content"> Requested name to validate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailabilityAsync(location.ToString(), content, cancellationToken);

        /// <summary>
        /// The skus action returns the list of SKUs that DMS (classic) supports.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceSkus_ListSkus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataMigrationSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationSku> GetSkusResourceSkus(CancellationToken cancellationToken = default)
            => GetSkus(cancellationToken);

        /// <summary>
        /// The skus action returns the list of SKUs that DMS (classic) supports.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/skus</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceSkus_ListSkus</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataMigrationSku"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationSku> GetSkusResourceSkusAsync(CancellationToken cancellationToken = default)
            => GetSkusAsync(cancellationToken);

        /// <summary>
        /// This method returns region-specific quotas and resource usage information for the Azure Database Migration Service (classic).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usages_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The Azure region of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataMigrationQuota"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationQuota> GetUsages(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsages(location.ToString(), cancellationToken);

        /// <summary>
        /// This method returns region-specific quotas and resource usage information for the Azure Database Migration Service (classic).
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DataMigration/locations/{location}/usages</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Usages_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-06-30</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="location"> The Azure region of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataMigrationQuota"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationQuota> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsagesAsync(location.ToString(), cancellationToken);
    }
}
