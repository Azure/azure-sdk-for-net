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
    /// <summary>Backward-compatible overloads for GA DatabaseMigrationSqlVmCollection APIs.</summary>
    public partial class DatabaseMigrationSqlVmCollection
    {
        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlVmResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string targetDbName, string sqlVirtualMachineName, DatabaseMigrationSqlVmData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlVmResource> CreateOrUpdate(WaitUntil waitUntil, string targetDbName, string sqlVirtualMachineName, DatabaseMigrationSqlVmData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlVmResource>> GetAsync(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlVmResource> Get(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Get(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return ExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Exists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlVmResource>> GetIfExistsAsync(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="sqlVirtualMachineName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlVmResource> GetIfExists(string targetDbName, string sqlVirtualMachineName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }
    }
}
