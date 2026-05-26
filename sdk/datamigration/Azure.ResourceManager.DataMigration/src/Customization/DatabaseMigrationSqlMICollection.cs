// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA collection accepted the parent managed instance name and Guid migration operation ID.
    public partial class DatabaseMigrationSqlMICollection
    {
        private const string CompatPlaceholderManagedInstanceName = "__compat_rg_scope__";

        private DatabaseMigrationSqlMICollection GetCompatCollection(string managedInstanceName)
            => Id.Name == CompatPlaceholderManagedInstanceName ? new DatabaseMigrationSqlMICollection(Client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}")) : this;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlMIResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedInstanceName, string targetDBName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).CreateOrUpdateAsync(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlMIResource> CreateOrUpdate(WaitUntil waitUntil, string managedInstanceName, string targetDBName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).CreateOrUpdate(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).ExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).Exists(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlMIResource> Get(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).Get(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlMIResource>> GetIfExistsAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetIfExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlMIResource> GetIfExists(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetIfExists(targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
