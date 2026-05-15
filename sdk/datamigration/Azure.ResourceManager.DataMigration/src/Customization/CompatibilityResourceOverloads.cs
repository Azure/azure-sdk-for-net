// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, SA1649, CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.DataMigration
{
    /// <summary>Backward-compatible overloads for GA resource APIs.</summary>
    public partial class DatabaseMigrationSqlDBResource
    {
        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlDBResource> Get(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => Get(migrationOperationId?.ToString(), expand, cancellationToken);

        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetAsync(migrationOperationId?.ToString(), expand, cancellationToken);
    }

    /// <summary>Backward-compatible overloads for GA resource APIs.</summary>
    public partial class DatabaseMigrationSqlMIResource
    {
        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlMIResource> Get(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => Get(migrationOperationId?.ToString(), expand, cancellationToken);

        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetAsync(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetAsync(migrationOperationId?.ToString(), expand, cancellationToken);
    }

    /// <summary>Backward-compatible overloads for GA resource APIs.</summary>
    public partial class DatabaseMigrationSqlVmResource
    {
        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlVmResource> Get(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => Get(migrationOperationId?.ToString(), expand, cancellationToken);

        // Backward-compatible overload that accepts the GA Guid? migration operation id.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlVmResource>> GetAsync(Guid? migrationOperationId, string expand, CancellationToken cancellationToken = default)
            => GetAsync(migrationOperationId?.ToString(), expand, cancellationToken);
    }
}
