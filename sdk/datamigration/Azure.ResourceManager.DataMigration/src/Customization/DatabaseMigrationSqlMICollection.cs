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
    // Backward-compat justification: the GA collection accepted the parent managed instance name and Guid migration operation ID.
    // the GA collection scope to resource group and needs parent SQL server name and target DB name to build full url.
    // new codegen collection scope to parent Microsoft.Sql/managedInstances and only accepts target DB name.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ValidateResourceId")]
    public partial class DatabaseMigrationSqlMICollection
    {
        private DatabaseMigrationSqlMICollection GetCompatCollection(string managedInstanceName)
            => Id.Name == managedInstanceName && Id.ResourceType == "Microsoft.Sql/managedInstances" ? this : new DatabaseMigrationSqlMICollection(Client, new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}/resourceGroups/{Id.ResourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}"));

        /// <param name="id"></param>
        [System.Diagnostics.Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if ((id.ResourceType != "Microsoft.Sql/managedInstances") && (id.ResourceType != "Microsoft.Resources/resourceGroups"))
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, "Microsoft.Sql/managedInstances"), nameof(id));
            }
        }

        public virtual Task<ArmOperation<DatabaseMigrationSqlMIResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string managedInstanceName, string targetDBName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).CreateOrUpdateAsync(waitUntil, targetDBName, data, cancellationToken);

        public virtual ArmOperation<DatabaseMigrationSqlMIResource> CreateOrUpdate(WaitUntil waitUntil, string managedInstanceName, string targetDBName, DatabaseMigrationSqlMIData data, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).CreateOrUpdate(waitUntil, targetDBName, data, cancellationToken);

        public virtual Task<Response<bool>> ExistsAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).ExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Response<bool> Exists(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).Exists(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Task<Response<DatabaseMigrationSqlMIResource>> GetAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Response<DatabaseMigrationSqlMIResource> Get(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).Get(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual Task<NullableResponse<DatabaseMigrationSqlMIResource>> GetIfExistsAsync(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetIfExistsAsync(targetDBName, migrationOperationId, expand, cancellationToken);

        public virtual NullableResponse<DatabaseMigrationSqlMIResource> GetIfExists(string managedInstanceName, string targetDBName, Guid? migrationOperationId = null, string expand = null, CancellationToken cancellationToken = default)
            => GetCompatCollection(managedInstanceName).GetIfExists(targetDBName, migrationOperationId, expand, cancellationToken);
    }
}
