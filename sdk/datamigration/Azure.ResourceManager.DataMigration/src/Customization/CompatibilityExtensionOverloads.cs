// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, SA1649, CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.DataMigration.Mocking;
using Azure.ResourceManager.DataMigration.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataMigration
{
    /// <summary>Backward-compatible extension members for GA signatures.</summary>
    public static partial class DataMigrationExtensions
    {
        // Backward-compatible overload that preserved the AzureLocation parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).CheckDataMigrationNameAvailability(location, content, cancellationToken);
        }

        // Backward-compatible overload that preserved the AzureLocation parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).CheckDataMigrationNameAvailabilityAsync(location, content, cancellationToken);
        }

        // Backward-compatible GA name for the skus listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DataMigrationSku> GetSkusResourceSkus(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetSkusResourceSkus(cancellationToken);
        }

        // Backward-compatible GA name for the skus listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DataMigrationSku> GetSkusResourceSkusAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetSkusResourceSkusAsync(cancellationToken);
        }

        // Backward-compatible GA name for the usages listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DataMigrationQuota> GetUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetUsages(location, cancellationToken);
        }

        // Backward-compatible GA name for the usages listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DataMigrationQuota> GetUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetUsagesAsync(location, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBs();
        }

        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDB(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBAsync(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIs();
        }

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMI(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIAsync(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVms();
        }

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVm(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(this ResourceGroupResource resourceGroupResource, string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVmAsync(parentName, targetDbName, migrationOperationId, expand, cancellationToken);
        }
    }
}

namespace Azure.ResourceManager.DataMigration.Mocking
{
    /// <summary>Backward-compatible mockable members for GA signatures.</summary>
    public partial class MockableDataMigrationSubscriptionResource
    {
        // Backward-compatible overload that preserved the AzureLocation parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailability(location.ToString(), content, cancellationToken);

        // Backward-compatible overload that preserved the AzureLocation parameter type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => CheckDataMigrationNameAvailabilityAsync(location.ToString(), content, cancellationToken);

        // Backward-compatible GA name for the skus listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationSku> GetSkusResourceSkus(CancellationToken cancellationToken = default)
            => GetSkus(cancellationToken);

        // Backward-compatible GA name for the skus listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationSku> GetSkusResourceSkusAsync(CancellationToken cancellationToken = default)
            => GetSkusAsync(cancellationToken);

        // Backward-compatible GA name for the usages listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<DataMigrationQuota> GetUsages(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsages(location.ToString(), cancellationToken);

        // Backward-compatible GA name for the usages listing API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<DataMigrationQuota> GetUsagesAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsagesAsync(location.ToString(), cancellationToken);
    }

    /// <summary>Backward-compatible mockable members for GA signatures.</summary>
    public partial class MockableDataMigrationResourceGroupResource
    {
        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs()
            => GetCachedClient(client => new DatabaseMigrationSqlDBCollection(client, Id));

        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlDBs().Get(targetDbName, parentName, migrationOperationId, expand, cancellationToken);

        // Backward-compatible overload preserving the old SQL DB resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlDBs().GetAsync(targetDbName, parentName, migrationOperationId, expand, cancellationToken);

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs()
            => GetCachedClient(client => new DatabaseMigrationSqlMICollection(client, Id));

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlMIs().Get(targetDbName, parentName, migrationOperationId, expand, cancellationToken);

        // Backward-compatible overload preserving the old SQL MI resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlMIs().GetAsync(targetDbName, parentName, migrationOperationId, expand, cancellationToken);

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms()
            => GetCachedClient(client => new DatabaseMigrationSqlVmCollection(client, Id));

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlVms().Get(targetDbName, parentName, migrationOperationId, expand, cancellationToken);

        // Backward-compatible overload preserving the old SQL VM resource-group shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(string parentName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlVms().GetAsync(targetDbName, parentName, migrationOperationId, expand, cancellationToken);
    }
}
