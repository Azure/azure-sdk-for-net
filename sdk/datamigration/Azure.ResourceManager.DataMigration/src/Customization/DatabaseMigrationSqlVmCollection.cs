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
    // Backward-compat justification: the GA collection accepted the parent SQL VM name and Guid migration operation ID.
    public partial class DatabaseMigrationSqlVmCollection
    {
        private const string CompatPlaceholderSqlVmName = "__compat_rg_scope__";

        private DatabaseMigrationSqlVmCollection GetCompatCollection(string sqlVirtualMachineName)
            => Id.Name == CompatPlaceholderSqlVmName ? new DatabaseMigrationSqlVmCollection(Client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}")) : this;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlVmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sqlVirtualMachineName, string targetDBName, DatabaseMigrationSqlVmData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).CreateOrUpdateAsync(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlVmResource> CreateOrUpdate(WaitUntil waitUntil, string sqlVirtualMachineName, string targetDBName, DatabaseMigrationSqlVmData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).CreateOrUpdate(waitUntil, targetDBName, data, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).ExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).Exists(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlVmResource>> GetAsync(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).GetAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlVmResource> Get(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).Get(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlVmResource>> GetIfExistsAsync(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).GetIfExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlVmResource> GetIfExists(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlVirtualMachineName).GetIfExists(targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
