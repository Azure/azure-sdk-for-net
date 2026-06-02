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
    }
}
