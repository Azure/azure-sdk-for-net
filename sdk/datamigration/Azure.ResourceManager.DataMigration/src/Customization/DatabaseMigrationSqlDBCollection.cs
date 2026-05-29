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
    // Backward-compat justification:
    // the GA collection scope to resource group and needs parent SQL server name and target DB name to build full url.
    // new codegen collection scope to parent Microsoft.Sql/servers and only accepts target DB name.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ValidateResourceId")]
    public partial class DatabaseMigrationSqlDBCollection
    {
        private DatabaseMigrationSqlDBCollection GetCompatCollection(string sqlDBInstanceName)
            => Id.Name == sqlDBInstanceName && Id.ResourceType == "Microsoft.Sql/servers" ? this : new DatabaseMigrationSqlDBCollection(Client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}/providers/Microsoft.Sql/servers/{sqlDBInstanceName}"));

        /// <param name="id"></param>
        [System.Diagnostics.Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if ((id.ResourceType != "Microsoft.Sql/servers") && (id.ResourceType != "Microsoft.Resources/resourceGroups"))
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, "Microsoft.Sql/servers"), nameof(id));
            }
        }

        public virtual Task<ArmOperation<DatabaseMigrationSqlDBResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).CreateOrUpdateAsync(waitUntil, targetDBName, data, cancellationToken);

        public virtual ArmOperation<DatabaseMigrationSqlDBResource> CreateOrUpdate(WaitUntil waitUntil, string sqlDBInstanceName, string targetDBName, DatabaseMigrationSqlDBData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).CreateOrUpdate(waitUntil, targetDBName, data, cancellationToken);

        public virtual Task<Response<bool>> ExistsAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).ExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Response<bool> Exists(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).Exists(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Task<Response<DatabaseMigrationSqlDBResource>> GetAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Response<DatabaseMigrationSqlDBResource> Get(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).Get(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Task<NullableResponse<DatabaseMigrationSqlDBResource>> GetIfExistsAsync(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetIfExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual NullableResponse<DatabaseMigrationSqlDBResource> GetIfExists(string sqlDBInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(sqlDBInstanceName).GetIfExists(targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
