// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using SqlElasticPool.Definition;
    using SqlElasticPools.SqlElasticPoolsCreatable;
    using SqlServer.ElasticPools;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation of SqlServer.ElasticPools, which enables the creating the elastic pools from the SQLServer directly.
    /// </summary>
    internal partial class ElasticPoolsImpl :
        IElasticPools
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlElasticPoolsCreatable elasticPools;
        private Region region;

        internal ElasticPoolsImpl(IElasticPoolsOperations innerCollection,
            SqlManager manager,
            IDatabasesOperations databasesInner,
            DatabasesImpl databasesImpl,
            string resourceGroupName,
            string sqlServerName,
            Region region)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.region = region;
            this.elasticPools = new SqlElasticPoolsImpl(innerCollection, manager, databasesInner, databasesImpl);
        }

        internal ISqlElasticPools ElasticPools
        {
            get
            {
                return this.elasticPools;
            }
        }

        public ISqlElasticPool Get(string elasticPoolName)
        {
            return this.elasticPools.GetBySqlServer(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }

        public IBlank Define(string elasticPoolName)
        {
            return this.elasticPools.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, elasticPoolName, this.region);
        }

        public async Task DeleteAsync(string elasticPoolName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.elasticPools.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }

        public IList<ISqlElasticPool> List()
        {
            return this.elasticPools.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        public void Delete(string elasticPoolName)
        {
            this.elasticPools.DeleteByParent(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }
    }
}