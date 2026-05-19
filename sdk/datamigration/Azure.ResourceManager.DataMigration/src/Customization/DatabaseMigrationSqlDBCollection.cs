// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compatible overloads for GA DatabaseMigrationSqlDBCollection APIs.
    public partial class DatabaseMigrationSqlDBCollection
    {
        // Backward-compatible overload. The sqlDbInstanceName parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlDBResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sqlDbInstanceName, string targetDbName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, targetDbName, data, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlDBResource> CreateOrUpdate(WaitUntil waitUntil, string sqlDbInstanceName, string targetDbName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, targetDbName, data, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlDBResource> Get(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Get(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return ExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Exists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlDBResource>> GetIfExistsAsync(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlDBResource> GetIfExists(string sqlDbInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }
    }
}
