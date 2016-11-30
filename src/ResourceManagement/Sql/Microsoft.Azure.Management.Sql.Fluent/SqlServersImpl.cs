// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using SqlServer.Definition;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlServers and its parent interfaces.
    /// </summary>
    internal partial class SqlServersImpl :
        GroupableResources<ISqlServer, SqlServerImpl, ServerInner, IServersOperations, SqlManager>,
        ISqlServers
    {
        private IElasticPoolsOperations elasticPoolsInner;
        private IDatabasesOperations databasesInner;
        private IRecommendedElasticPoolsOperations recommendedElasticPoolsInner;

        internal SqlServersImpl(IServersOperations innerCollection,
            IElasticPoolsOperations elasticPoolsInner,
            IDatabasesOperations databasesInner,
            IRecommendedElasticPoolsOperations recommendedElasticPoolsInner,
            SqlManager manager)
            : base(innerCollection, manager)
        {
            this.elasticPoolsInner = elasticPoolsInner;
            this.databasesInner = databasesInner;
            this.recommendedElasticPoolsInner = recommendedElasticPoolsInner;
        }

        public override async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.InnerCollection.DeleteAsync(groupName, name);
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public override async Task<ISqlServer> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await this.InnerCollection.GetByResourceGroupAsync(groupName, name, cancellationToken));
        }

        public PagedList<ISqlServer> List()
        {
            return WrapList(new PagedList<ServerInner>(this.InnerCollection.List()));
        }

        protected override SqlServerImpl WrapModel(string name)
        {
            ServerInner inner = new ServerInner();
            inner.Version = ServerVersion.TwoFullStopZero;
            return new SqlServerImpl(
                name,
                inner,
                this.InnerCollection,
                base.Manager,
                this.elasticPoolsInner,
                this.databasesInner,
                this.recommendedElasticPoolsInner);
        }

        protected override ISqlServer WrapModel(ServerInner inner)
        {
            if (inner == null)
            {
                return null;
            }

            return new SqlServerImpl(
                inner.Name,
                inner,
                this.InnerCollection,
                this.Manager,
                this.elasticPoolsInner,
                this.databasesInner,
                this.recommendedElasticPoolsInner);
        }

        public PagedList<ISqlServer> ListByGroup(string resourceGroupName)
        {
            return WrapList(new PagedList<ServerInner>(this.InnerCollection.ListByResourceGroup(resourceGroupName)));
        }
    }
}