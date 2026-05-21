// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailability(location.ToString(), content, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailabilityAsync(location.ToString(), content, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationSku> GetSkusResourceSkus(CancellationToken cancellationToken = default)
            => GetSkus(cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationSku> GetSkusResourceSkusAsync(CancellationToken cancellationToken = default)
            => GetSkusAsync(cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationQuota> GetUsages(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsages(location.ToString(), cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationQuota> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsagesAsync(location.ToString(), cancellationToken);
    }
}
