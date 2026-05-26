// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.DataMigration.Mocking
{
    // Backward-compat justification: the GA mockable resource-group helpers exposed collection getters and Get overloads with Guid?.
    public partial class MockableDataMigrationResourceGroupResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlDBCollection GetDatabaseMigrationSqlDBs()
            => Client.GetDatabaseMigrationSqlDBs(Id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlDBResource> GetDatabaseMigrationSqlDB(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlDBs().Get(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetDatabaseMigrationSqlDBAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlDBs().GetAsync(sqlDBInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlMICollection GetDatabaseMigrationSqlMIs()
            => Client.GetDatabaseMigrationSqlMIs(Id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlMIResource> GetDatabaseMigrationSqlMI(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlMIs().Get(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetDatabaseMigrationSqlMIAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlMIs().GetAsync(managedInstanceName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DatabaseMigrationSqlVmCollection GetDatabaseMigrationSqlVms()
            => Client.GetDatabaseMigrationSqlVms(Id);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<DatabaseMigrationSqlVmResource> GetDatabaseMigrationSqlVm(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlVms().Get(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<Response<DatabaseMigrationSqlVmResource>> GetDatabaseMigrationSqlVmAsync(string sqlVirtualMachineName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetDatabaseMigrationSqlVms().GetAsync(sqlVirtualMachineName, targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
