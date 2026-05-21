// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.DataMigration
{
    // Backward-compat justification: the GA resource used Guid? for migrationOperationId.
    public partial class DatabaseMigrationSqlDBResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetAsync(migrationOperationId?.ToString(), expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DatabaseMigrationSqlDBResource> Get(Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => Get(migrationOperationId?.ToString(), expand, cancellationToken);
    }
}
