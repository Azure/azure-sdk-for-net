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
    // Backward-compatible overloads for GA collection APIs.
    public partial class DatabaseMigrationSqlMICollection
    {
        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<DatabaseMigrationSqlMIResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedInstanceName, string targetDbName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdateAsync(waitUntil, targetDbName, data, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DatabaseMigrationSqlMIResource> CreateOrUpdate(WaitUntil waitUntil, string managedInstanceName, string targetDbName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken)
        {
            return CreateOrUpdate(waitUntil, targetDbName, data, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetAsync(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlMIResource> Get(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Get(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return ExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return Exists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<DatabaseMigrationSqlMIResource>> GetIfExistsAsync(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExistsAsync(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }

        // Backward-compatible overload. The parent name parameter is no longer needed.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DatabaseMigrationSqlMIResource> GetIfExists(string managedInstanceName, string targetDbName, Guid? migrationOperationId, string expand, CancellationToken cancellationToken)
        {
            return GetIfExists(targetDbName, migrationOperationId?.ToString(), expand, cancellationToken);
        }
    }
}
