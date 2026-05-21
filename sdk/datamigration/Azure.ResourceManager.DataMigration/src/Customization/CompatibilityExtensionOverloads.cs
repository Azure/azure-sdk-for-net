// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DataMigration.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA extension methods exposed legacy names and AzureLocation/Guid-based overloads.
    public static partial class DataMigrationExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBs();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(this ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDB(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(this ResourceGroupResource resourceGroupResource, string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlDBAsync(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIs();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(this ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMI(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(this ResourceGroupResource resourceGroupResource, string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlMIAsync(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms(this ResourceGroupResource resourceGroupResource)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVms();

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(this ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVm(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(this ResourceGroupResource resourceGroupResource, string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationResourceGroupResource(resourceGroupResource).GetDatabaseMigrationSqlVmAsync(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<DataMigrationServiceNameAvailabilityResult> CheckDataMigrationNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).CheckDataMigrationNameAvailability(location, content, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<DataMigrationServiceNameAvailabilityResult>> CheckDataMigrationNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, DataMigrationServiceNameAvailabilityContent content, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).CheckDataMigrationNameAvailabilityAsync(location, content, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DataMigrationSku> GetSkusResourceSkus(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetSkusResourceSkus(cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DataMigrationSku> GetSkusResourceSkusAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetSkusResourceSkusAsync(cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<DataMigrationQuota> GetUsages(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetUsages(location, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<DataMigrationQuota> GetUsagesAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken = default)
            => GetMockableDataMigrationSubscriptionResource(subscriptionResource).GetUsagesAsync(location, cancellationToken);
    }
}
