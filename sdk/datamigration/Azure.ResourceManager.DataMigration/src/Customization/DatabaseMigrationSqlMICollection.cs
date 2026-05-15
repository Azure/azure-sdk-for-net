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
    /// <summary>Backward-compatible overloads for GA DatabaseMigrationSqlMICollection APIs.</summary>
    public partial class DatabaseMigrationSqlMICollection
    {
        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlMIResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string targetDbName, string managedInstanceName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlMIResource> CreateOrUpdate(WaitUntil waitUntil, string targetDbName, string managedInstanceName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, targetDbName, data, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetAsync(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlMIResource> Get(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Get(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return ExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Exists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlMIResource>> GetIfExistsAsync(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        /// <summary> Backward-compatible overload. The <paramref name="managedInstanceName"/> parameter is no longer needed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlMIResource> GetIfExists(string targetDbName, string managedInstanceName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }
    }
}
