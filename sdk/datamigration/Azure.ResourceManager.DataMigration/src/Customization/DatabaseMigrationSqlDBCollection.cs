// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Azure.ResourceManager.DataMigration
{
    /// <summary>Backward-compatible overloads for GA DatabaseMigrationSqlDBCollection APIs.</summary>
    public partial class DatabaseMigrationSqlDBCollection
    {
        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlDBResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string targetDbName, string sqlDbInstanceName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlDBResource> CreateOrUpdate(WaitUntil waitUntil, string targetDbName, string sqlDbInstanceName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlDBResource> Get(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Get(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return ExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Exists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlDBResource>> GetIfExistsAsync(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlDbInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlDBResource> GetIfExists(string targetDbName, string sqlDbInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }
    }
}
