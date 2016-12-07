// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using SqlElasticPool.Definition;
    using SqlElasticPools.SqlElasticPoolsCreatable;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SQLElasticPools and its parent interfaces.
    /// </summary>
    internal partial class SqlElasticPoolsImpl :
        IndependentChildResourcesImpl<ISqlElasticPool, SqlElasticPoolImpl, ElasticPoolInner, IElasticPoolsOperations, SqlManager>,
        ISqlElasticPoolsCreatable,
        ISupportsGettingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>,
        ISupportsListingByParent<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool>
    {
        private IDatabasesOperations databasesInner;
        private DatabasesImpl databasesImpl;

        internal SqlElasticPoolsImpl(IElasticPoolsOperations innerCollection, SqlManager manager, IDatabasesOperations databasesInner, DatabasesImpl databasesImpl)
            : base(innerCollection, manager)
        {
            this.databasesInner = databasesInner;
            this.databasesImpl = databasesImpl;
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(string resourceGroupName, string sqlServerName)
        {
            return new List<ISqlElasticPool>(this.ListByParent(resourceGroupName, sqlServerName));
        }

        public IList<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> ListBySqlServer(IGroupableResource sqlServer)
        {
            return new List<ISqlElasticPool>(this.ListByParent(sqlServer));
        }

        public override async Task<PagedList<ISqlElasticPool>> ListByParentAsync(string resourceGroupName, string parentName, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapList(new PagedList<ElasticPoolInner>(await this.innerCollection.ListByServerAsync(resourceGroupName, parentName, cancellationToken)));
        }

        public ISqlElasticPool GetBySqlServer(string resourceGroup, string sqlServerName, string name)
        {
            return this.GetByParent(resourceGroup, sqlServerName, name);
        }

        public ISqlElasticPool GetBySqlServer(IGroupableResource sqlServer, string name)
        {
            return this.GetByParent(sqlServer, name);
        }

        public override async Task DeleteByParentAsync(string groupName, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteAsync(groupName, parentName, name);
        }

        public ICreatable<ISqlElasticPool> DefinedWithSqlServer(string resourceGroupName, string sqlServerName, string elasticPoolName, Region region)
        {
            ElasticPoolInner inner = new ElasticPoolInner();
            inner.Location = region.ToString();

            return new SqlElasticPoolImpl(
                elasticPoolName,
                inner,
                this.innerCollection,
                this.databasesInner,
                this.databasesImpl).WithExistingParentResource(resourceGroupName, sqlServerName);
        }

        public override async Task<ISqlElasticPool> GetByParentAsync(string resourceGroup, string parentName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.innerCollection.GetAsync(resourceGroup, parentName, name, cancellationToken));
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        protected override SqlElasticPoolImpl WrapModel(string name)
        {
            ElasticPoolInner inner = new ElasticPoolInner();
            return new SqlElasticPoolImpl(
                name,
                inner,
                this.innerCollection,
                this.databasesInner,
                this.databasesImpl);
        }

        protected override ISqlElasticPool WrapModel(ElasticPoolInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SqlElasticPoolImpl(inner.Name, inner, this.innerCollection, this.databasesInner, this.databasesImpl);
        }
    }
}