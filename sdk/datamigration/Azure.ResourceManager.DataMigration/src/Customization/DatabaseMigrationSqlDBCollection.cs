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
    // Backward-compat justification: the GA collection accepted the parent SQL server name and Guid migration operation ID.
    public partial class DatabaseMigrationSqlDBCollection
    {
        private const string CompatPlaceholderSqlServerName = "__compat_rg_scope__";

        private DatabaseMigrationSqlDBCollection GetCompatCollection(string sqlDBInstanceName)
            => Id.Name == CompatPlaceholderSqlServerName ? new DatabaseMigrationSqlDBCollection(Client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}")) : this;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlDBResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).CreateOrUpdateAsync(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlDBResource> CreateOrUpdate(WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).CreateOrUpdate(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).ExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).Exists(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlDBResource> Get(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).Get(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlDBResource>> GetIfExistsAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetIfExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlDBResource> GetIfExists(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetIfExists(targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
