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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5FbGFzdGljUG9vbHNJbXBs
    internal partial class ElasticPoolsImpl :
        IElasticPools
    {
        private string resourceGroupName;
        private string sqlServerName;
        private ISqlElasticPoolsCreatable elasticPools;
        private Region region;

        ///GENMHASH:C9332154641E1021A796A0AA87A41D7C:CB5497929793111AF874DCDF5A64A775
        internal ElasticPoolsImpl(
            ISqlManager manager,
            DatabasesImpl databasesImpl,
            string resourceGroupName,
            string sqlServerName,
            Region region)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.region = region;
            elasticPools = new SqlElasticPoolsImpl(manager, databasesImpl);
        }

        ///GENMHASH:22ED13819FBF2CA919B55726AC1FB656:D59C288EAB8D4BB7EA1BB303B03CC500
        internal ISqlElasticPools ElasticPools
        {
            get
            {
                return this.elasticPools;
            }
        }

        ///GENMHASH:206E829E50B031B66F6EA9C7402231F9:B4B93CF675F6CA4F80D1DF0B2EEB49C3
        public ISqlElasticPool Get(string elasticPoolName)
        {
            return this.elasticPools.GetBySqlServer(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:2932076A4AB17A9BE881E6A35CB896A5
        public IBlank Define(string elasticPoolName)
        {
            return this.elasticPools.DefinedWithSqlServer(this.resourceGroupName, this.sqlServerName, elasticPoolName, this.region);
        }

        ///GENMHASH:BEDEF34E57C25BFA34A4AB1C8430428E:CEA8F626147E918D12E5D00083090092
        public async Task DeleteAsync(string elasticPoolName, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.elasticPools.DeleteByParentAsync(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:4696CE89C64991C8EEE3386298E90611
        public IList<ISqlElasticPool> List()
        {
            return this.elasticPools.ListBySqlServer(this.resourceGroupName, this.sqlServerName);
        }

        ///GENMHASH:184FEA122A400D19B34517FEF358ED78:47F5DF19880EF4C6909F8DA161E5ACB1
        public void Delete(string elasticPoolName)
        {
            this.elasticPools.DeleteByParent(this.resourceGroupName, this.sqlServerName, elasticPoolName);
        }
    }
}
