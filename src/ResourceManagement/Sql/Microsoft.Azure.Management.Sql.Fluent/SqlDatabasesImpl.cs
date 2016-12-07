// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlDatabase.Definition;
    using SqlDatabases.SqlDatabaseCreatable;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLDatabases and its parent interfaces.
    /// </summary>
    internal partial class SqlDatabasesImpl :
        IndependentChildResourcesImpl<ISqlDatabase, SqlDatabaseImpl, DatabaseInner, IDatabasesOperations, SqlManager>,
        ISqlDatabaseCreatable,
        ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>
    {
        internal SqlDatabasesImpl(IDatabasesOperations innerCollection, SqlManager manager)
            : base(innerCollection, manager)
        {
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlDatabase>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase> ListBySqlServer(IGroupableResource sqlServer)
        {
            return new List<ISqlDatabase>(this.ListByParent(sqlServer));
        }

        public override async Task<PagedList<ISqlDatabase>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var pagedList = new PagedList<DatabaseInner>(await innerCollection.ListByServerAsync(resourceGroupName, parentName, cancellationToken));

            return WrapList(pagedList);
        }

        public ISqlDatabase GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetByParent(resourceGroup, sqlServerName, name);
        }

        public ISqlDatabase GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetByParent(sqlServer, name);
        }

        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteAsync(groupName, parentName, name);
        }

        public ICreatable<ISqlDatabase> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string databaseName, Region region)
        {
            DatabaseInner inner = new DatabaseInner();
            inner.Location = region.ToString();

            return new SqlDatabaseImpl(
                databaseName,
                inner,
                innerCollection).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        public override async Task<ISqlDatabase> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.innerCollection.GetAsync(resourceGroup, parentName, name, null, cancellationToken));
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        protected override SqlDatabaseImpl WrapModel(string name)
        {
            DatabaseInner inner = new DatabaseInner();
            return new SqlDatabaseImpl(
                name,
                inner,
                this.innerCollection);
        }

        protected override ISqlDatabase WrapModel(DatabaseInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SqlWarehouseImpl(inner.Name, inner, this.innerCollection);
        }
    }
}