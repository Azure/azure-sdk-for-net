// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.IndependentChild.Definition;
    using Models;
    using ResourceManager.Fluent.Core.Resource.Definition;
    using ResourceManager.Fluent.Core.ResourceActions;
    using SqlDatabase.Definition;
    using SqlDatabase.Update;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// Implementation for SqlDatabase and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUltcGw=
    internal partial class SqlDatabaseImpl :
        IndependentChildResourceImpl<ISqlDatabase, ISqlServer, DatabaseInner, SqlDatabaseImpl, IHasId, IUpdate, ISqlManager>,
        ISqlDatabase,
        IDefinition,
        IWithCreateWithElasticPoolOptions,
        IWithExistingDatabase,
        IUpdate, IWithParentResource<ISqlDatabase, ISqlServer>
    {
        private string elasticPoolCreatableKey;

        ///GENMHASH:0F0FD44A3D87F875885456FD45CEE6DF:FC20F8BEAA0D65FFE9DA4206313524DE
        internal SqlDatabaseImpl(string name, DatabaseInner innerObject, ISqlManager manager)
               : base(name, innerObject, manager)
        {
        }

        ///GENMHASH:957BA7B4E61C9B91983ED17E2B61DBD7:9549FCCFE13908133153A6585989F147
        public string ElasticPoolName()
        {
            return Inner.ElasticPoolName;
        }

        ///GENMHASH:C3E676C1E567606631528A28B60C9771:D3C554B6F628CA009F2AB5D1A90A12F8
        public SqlDatabaseImpl WithEdition(string edition)
        {
            Inner.Edition = edition;
            return this;
        }

        ///GENMHASH:396EF11BF84C5A5AEDE59746D18EF7FA:5DA565B751F97F39EE5A582282DB4BCC
        public SqlDatabaseImpl WithServiceObjective(string serviceLevelObjective)
        {
            Inner.RequestedServiceObjectiveName = serviceLevelObjective;
            Inner.RequestedServiceObjectiveId = null;

            return this;
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public string Edition()
        {
            return Inner.Edition;
        }

        ///GENMHASH:7B6933FD706B12808B9D39A178094149:67E0D89B9ED5BC9ECD83BA032F54BCDD
        public ISqlWarehouse AsWarehouse()
        {
            if (this.IsDataWarehouse())
            {
                return (ISqlWarehouse)this;
            }

            return null;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:EBCADD6850E9711DA91415429B1577E3
        public void Delete()
        {
            Extensions.Synchronize(() => Manager.Inner.Databases.DeleteAsync(ResourceGroupName, SqlServerName(), Name));
        }

        ///GENMHASH:B23645FC2F779DBC6F44B880C488B561:FD8121B9F8029AC826DD64E68A0C727C
        public SqlDatabaseImpl WithMaxSizeBytes(long maxSizeBytes)
        {
            Inner.MaxSizeBytes = maxSizeBytes.ToString();
            return this;
        }

        ///GENMHASH:D2C5B9B5EC8B12A40F6CC3A999383810:AA70F16BA24A6FB5F01832A54902603A
        public Guid CurrentServiceObjectiveId()
        {
            return Inner.CurrentServiceObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:7EF1D1197B665941F65A1D87438FFF51:6720981D90FC7BDAEC21501CC0D020D9
        public SqlDatabaseImpl WithExistingElasticPool(string elasticPoolName)
        {
            Inner.ElasticPoolName = elasticPoolName;
            return this;
        }

        ///GENMHASH:3BDABC5AAC07959FD1C78BEA74FD8712:D95E9FC81AB4F602112544DEF8D56410
        public SqlDatabaseImpl WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool.Name);
        }

        public SqlDatabaseImpl WithoutSourceDatabaseId()
        {
            return this;
        }

        ///GENMHASH:2E256CC1ACCA4253233F61C79F9D712E:B8220E91EC25625885438BBA3AFCE559
        public IUpgradeHintInterface GetUpgradeHint()
        {
            if (Inner.UpgradeHint == null)
            {
                SetInner(Extensions.Synchronize(() => Manager.Inner.Databases.GetAsync(ResourceGroupName, SqlServerName(), Name, "upgradeHint")));
            }
            if (Inner.UpgradeHint != null)
            {
                return new UpgradeHintImpl(Inner.UpgradeHint);
            }

            return null;
        }

        ///GENMHASH:A26C8D278B6519B28BA17D3966024017:F423185C6D626161C0F1E1F2B8386ECC
        public long MaxSizeBytes()
        {
            return long.Parse(Inner.MaxSizeBytes);
        }

        ///GENMHASH:68AE3BBF06B3A5F31F06F3A6A3469188:CF334608A3F1A8CD53872D1D3F94B016
        public string DefaultSecondaryLocation()
        {
            return Inner.DefaultSecondaryLocation;
        }

        ///GENMHASH:09F37EE7E8975407273D6FA4FB12441D:5B750DDCC180A5B0F60DE4E3840E3CCB
        public string Collation()
        {
            return Inner.Collation;
        }

        ///GENMHASH:41180B8AE28244EF8581E555D8B35D2B:2DF5AEC1603C5646911A31D59840F773
        public string DatabaseId()
        {
            return Inner.DatabaseId;
        }

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime EarliestRestoreDate()
        {
            return Inner.EarliestRestoreDate.GetValueOrDefault();
        }

        ///GENMHASH:DF623B844EDAA9403C7ADB3E4D089ADD:1E1FA9AB1DCE4AD9527CF761EC52F4BC
        public string RequestedServiceObjectiveName()
        {
            return Inner.RequestedServiceObjectiveName;
        }

        ///GENMHASH:94274C9965DC54702B64A387A19F1F2B:CBA2A056219E542449E5F7E9EBA4B7D8
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks()
        {
            var replicationLinks = Extensions.Synchronize(() => Manager.Inner.Databases.ListReplicationLinksAsync(
                ResourceGroupName, SqlServerName(), Name));

            IDictionary<string, IReplicationLink> result = new Dictionary<string, IReplicationLink>();
            foreach (var replicationLink in replicationLinks)
            {
                result.Add(replicationLink.Name, new ReplicationLinkImpl(replicationLink, Manager.Inner.Databases));
            }

            return new ReadOnlyDictionary<string, IReplicationLink>(result);
        }

        ///GENMHASH:36003534781597C965476F5DF65AFAE0:DA791BE2F36A2C18D1735C6D541B662C
        public SqlDatabaseImpl WithCollation(string collation)
        {
            Inner.Collation = collation;
            return this;
        }

        ///GENMHASH:A521981B274EF2B3D621C0705EFAA811:04B6FF01426ED6345B850E411A20FD6F
        public SqlDatabaseImpl WithMode(string createMode)
        {
            Inner.CreateMode = createMode;
            return this;
        }

        ///GENMHASH:0E666BFDFC9A666CA31FD735D7839414:F7AAC54BC083EB0E4E1C567F427FB501
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages()
        {
            Func<DatabaseMetric, DatabaseMetricImpl> convertor = (databaseMetricInner) => new DatabaseMetricImpl(databaseMetricInner);

            return Extensions.Synchronize(() => Manager.Inner.Databases.ListUsagesAsync(ResourceGroupName,SqlServerName(),Name))
                .Select(inner => convertor(inner)).ToList();
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:04B212B505D5C86A62596EEEE457DD66
        public string SqlServerName()
        {
            return base.parentName;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:682D8893B593BC241B04443E7DCC1934
        protected async override Task<ISqlDatabase> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SqlDatabaseImpl self = this;
            if (this.elasticPoolCreatableKey != null)
            {
                var sqlElasticPool = (ISqlElasticPool)this.CreatedResource(this.elasticPoolCreatableKey);
                WithExistingElasticPool(sqlElasticPool);
            }
            if (!string.IsNullOrWhiteSpace(Inner.ElasticPoolName))
            {
                Inner.Edition = string.Empty;
                Inner.RequestedServiceObjectiveName = string.Empty;
                Inner.RequestedServiceObjectiveId = null;
            }

            var databaseInner = await Manager.Inner.Databases.CreateOrUpdateAsync(ResourceGroupName, SqlServerName(), Name, Inner, cancellationToken);

            SetInner(databaseInner);
            elasticPoolCreatableKey = null;

            return this;
        }

        ///GENMHASH:F558A35AAC7463E4988A0A5E052953DD:E18BC7B276B57AC789E4B711EB272586
        public ITransparentDataEncryption GetTransparentDataEncryption()
        {
            return new TransparentDataEncryptionImpl(
                Extensions.Synchronize(() => Manager.Inner.Databases.GetTransparentDataEncryptionConfigurationAsync(
                    ResourceGroupName,
                    SqlServerName(),
                    Name)), 
                Manager.Inner.Databases);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:D460F07553280DBC1866880BA0BD8AEF
        protected override async Task<DatabaseInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            if (Inner.UpgradeHint != null)
            {
                return await Manager.Inner.Databases.GetAsync(ResourceGroupName, SqlServerName(), Name, cancellationToken: cancellationToken);
            }

            return await Manager.Inner.Databases.GetAsync(ResourceGroupName, SqlServerName(), Name, "upgradeHint", cancellationToken: cancellationToken);
        }

        ///GENMHASH:495111B1D55D7AA3C4EA4E49042FA05A:81AF1DB897B99ED47A56E01F499D4D5A
        public SqlDatabaseImpl WithNewElasticPool(ICreatable<ISqlElasticPool> sqlElasticPool)
        {
            if (elasticPoolCreatableKey == null)
            {
                elasticPoolCreatableKey = sqlElasticPool.Key;
                AddCreatableDependency(sqlElasticPool as IResourceCreator<IHasId>);
            }
            return this;
        }

        ///GENMHASH:37206883074CEB63F8267ADE2545CF11:7A5A0501B5D9CE9FC49981A622109CC5
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints()
        {
            Func<RestorePointInner, RestorePointImpl> convertor = (restorePointInner) => new RestorePointImpl(restorePointInner);

            return Extensions.Synchronize(() => Manager.Inner.Databases.ListRestorePointsAsync(ResourceGroupName, SqlServerName(), Name))
                .Select(inner => convertor(inner)).ToList();
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            return Inner.CreationDate.GetValueOrDefault();
        }

        ///GENMHASH:411E9B7C553E0F8FE64EB33DF4872E6A:A0F10EC124D07E925E3BE6285203F7E0
        public string ServiceLevelObjective()
        {
            return Inner.ServiceLevelObjective;
        }

        ///GENMHASH:F5717DCDC59DCEC39989A49248CA5245:753DCACCE1725C3E1909124033BA7DBE
        public SqlDatabaseImpl WithoutElasticPool()
        {
            Inner.ElasticPoolName = "";
            return this;
        }

        ///GENMHASH:547C5E4F79BCDF43D68C1D68B8233E56:9882FFBFE7BD70A7186F679ED88E4927
        public bool IsDataWarehouse()
        {
            return StringComparer.OrdinalIgnoreCase.Equals(this.Edition(), DatabaseEditions.DataWarehouse);
        }

        ///GENMHASH:B1D3E971A2C4574ED03F74E5745E8301:B5D8E6907D7456C71BFBDDD84D4CAF3D
        public Guid RequestedServiceObjectiveId()
        {
            return Inner.RequestedServiceObjectiveId.GetValueOrDefault();
        }

        ///GENMHASH:F8954D151717AC497C4A3B76321952A6:6742E1EFB9385FBFEB7C33ADDE36250E
        public IWithCreateMode WithSourceDatabase(string sourceDatabaseId)
        {
            Inner.SourceDatabaseId = sourceDatabaseId;
            return this;
        }

        ///GENMHASH:642F972C91F9E70B14E53881C1FCA8F9:6721B2671E9A8412C76AB1AA37A5742D
        public IWithCreateMode WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return WithSourceDatabase(sourceDatabase.Id);
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public string Status()
        {
            return Inner.Status;
        }

        ///GENMHASH:6F25566A2BEBF8E935396FF70D7412F6:51165F870EA30D4BEC4237182E7E63FE
        public IReadOnlyDictionary<string, IServiceTierAdvisor> ListServiceTierAdvisors()
        {
            var serviceTierAdvisorMap = new Dictionary<string, IServiceTierAdvisor>();

            foreach (var serviceTierAdvisorInner
                in Extensions.Synchronize(() => Manager.Inner.Databases.ListServiceTierAdvisorsAsync(ResourceGroupName, SqlServerName(), Name)))
            {
                serviceTierAdvisorMap.Add(serviceTierAdvisorInner.Name, new ServiceTierAdvisorImpl(serviceTierAdvisorInner,
                    Manager.Inner.Databases));
            }

            return new ReadOnlyDictionary<string, IServiceTierAdvisor>(serviceTierAdvisorMap);
        }
    }
}
