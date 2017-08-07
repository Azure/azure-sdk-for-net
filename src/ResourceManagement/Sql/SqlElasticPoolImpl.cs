// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.IndependentChild.Definition;
    using Models;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.Resource.Definition;
    using SqlElasticPool.Definition;
    using SqlElasticPool.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlElasticPool and its parent interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxFbGFzdGljUG9vbEltcGw=
    internal partial class SqlElasticPoolImpl :
        IndependentChildResourceImpl<ISqlElasticPool, ISqlServer, ElasticPoolInner, SqlElasticPoolImpl, IHasId, IUpdate, ISqlManager>,
        ISqlElasticPool,
        IDefinition,
        IUpdate,
        IWithParentResource<ISqlElasticPool, ISqlServer>
    {
        private DatabasesImpl databasesImpl;
        private IDictionary<string, SqlDatabaseImpl> databaseCreatableMap;

        ///GENMHASH:1D60743D6610D89F39BC74DA9C2B8F8B:E99F7FD0EF35FEF2A4996B397160B70D
        internal SqlElasticPoolImpl(
            string name,
            ElasticPoolInner innerObject,
            DatabasesImpl databasesImpl,
            ISqlManager manager)
            : base(name, innerObject, manager)
        {
            this.databasesImpl = databasesImpl;
            this.databaseCreatableMap = new Dictionary<string, SqlDatabaseImpl>();
        }

        ///GENMHASH:C183D7089E5DF699C59758CC103308DF:9A4ADAD649EDB890CDCEB767D8708E33
        public IReadOnlyList<IElasticPoolActivity> ListActivities()
        {
            var activities = Extensions.Synchronize(() => Manager.Inner.ElasticPools.ListActivityAsync(
                ResourceGroupName,
                SqlServerName(),
                Name));

            var activitiesToReturn = new List<IElasticPoolActivity>();
            foreach (var elasticPoolActivityInner in activities)
            {
                activitiesToReturn.Add(new ElasticPoolActivityImpl(elasticPoolActivityInner));
            }

            return activitiesToReturn;
        }

        ///GENMHASH:AF85C434312924FAA083308209A3AF10:5BC46D00C0259DC73BA821EECB730B17
        private async Task CreateOrUpdateDatabaseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.databaseCreatableMap.Any())
            {
                await this.databasesImpl.Databases.CreateAsync(this.databaseCreatableMap.Values.ToArray());
                this.databaseCreatableMap.Clear();
            }
        }

        ///GENMHASH:F018FD6E531156DFCBAA9FAE7F4D8519:4FA6D0F883E9F521846C7A0D28C7480B
        public int DatabaseDtuMax()
        {
            return Inner.DatabaseDtuMax.GetValueOrDefault();
        }

        ///GENMHASH:CE6E5E981686AB8CE8A830CF9AB6387F:D3C554B6F628CA009F2AB5D1A90A12F8
        public SqlElasticPoolImpl WithEdition(string edition)
        {
            Inner.Edition = edition;
            return this;
        }

        ///GENMHASH:88F495E6170B34BE98D7ECF345A40578:86A1F833D72B342BD29B3DD462FD72B4
        public int Dtu()
        {
            return Inner.Dtu.GetValueOrDefault();
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:04B212B505D5C86A62596EEEE457DD66
        public string SqlServerName()
        {
            return this.parentName;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:EA721512D35742AECA1CE1F7CBF2BB99
        protected async override Task<ISqlElasticPool> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var elasticPoolInner = await Manager.Inner.ElasticPools.CreateOrUpdateAsync(
                ResourceGroupName,
                SqlServerName(),
                Name,
                Inner,
                cancellationToken);
            SetInner(elasticPoolInner);

            await CreateOrUpdateDatabaseAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:CD775E31F43CBA6304D6EEA9E01682A1:2A3515CB32DF22200CBB032FFC4BCCFC
        public IReadOnlyList<ISqlDatabase> ListDatabases()
        {
            var databases = Extensions.Synchronize(() => Manager.Inner.ElasticPools.ListDatabasesAsync(
                        ResourceGroupName,
                        SqlServerName(),
                        Name));
            return databases.Select((databaseInner) => (ISqlDatabase)new SqlDatabaseImpl(
                databaseInner.Name,
                databaseInner,
                Manager)).ToList();
        }

        ///GENMHASH:F5BFC9500AE4C04846BAAD2CC50792B3:DA87C4AB3EEB9D4BA746DF610E8BC39F
        public string Edition()
        {
            return Inner.Edition;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:1ACD6B53BB71F7548B6ACD87115C57CE
        protected override async Task<ElasticPoolInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.ElasticPools.GetAsync(ResourceGroupName, SqlServerName(), Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:ED7351448838F0ED89C6E4AE8FB19EAE:E3FFCB76DD3743CD850897669FC40D12
        public DateTime CreationDate()
        {
            return Inner.CreationDate.GetValueOrDefault();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:EBCADD6850E9711DA91415429B1577E3
        public void Delete()
        {
            Extensions.Synchronize(() => Manager.Inner.ElasticPools.DeleteAsync(ResourceGroupName, SqlServerName(), Name));
        }

        ///GENMHASH:D7949083DDCDE361387E2A975A1A1DE5:D78C4C70C8A28CECCD68CF0E66EED127
        public SqlElasticPoolImpl WithNewDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName,
                (SqlDatabaseImpl)this.databasesImpl.Define(databaseName).WithExistingElasticPool(this.Name));
            return this;
        }

        ///GENMHASH:DA730BE4F3BEA4D8DCD1631C079435CB:2D0DE4C2F41ED4D39BD2E654A3511EEE
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IElasticPoolDatabaseActivity> ListDatabaseActivities()
        {
            var databaseActivities = Extensions.Synchronize(() => Manager.Inner.ElasticPools.ListDatabaseActivityAsync(
                    ResourceGroupName,
                    SqlServerName(),
                    Name));
            return databaseActivities.Select((elasticPoolDatabaseActivityInner) => (IElasticPoolDatabaseActivity)new ElasticPoolDatabaseActivityImpl(elasticPoolDatabaseActivityInner)).ToList();
        }

        ///GENMHASH:5AD4BED8CF2346B6D40F11D14D91854E:7666B4D046985F07C01EE064CD7C00B4
        public int DatabaseDtuMin()
        {
            return Inner.DatabaseDtuMin.GetValueOrDefault();
        }

        ///GENMHASH:1C25D7B8D9084176A24655682A78634D:ABBCB4CE203E2AC2B27991A84095239D
        public ISqlDatabase GetDatabase(string databaseName)
        {
            DatabaseInner database = Extensions.Synchronize(() => Manager.Inner.ElasticPools.GetDatabaseAsync(
                ResourceGroupName,
                SqlServerName(),
                Name,
                databaseName));
            return new SqlDatabaseImpl(database.Name, database, Manager);
        }

        ///GENMHASH:B88CB61BDAE447E93768AB406D02A57B:0FE1382F901F74708CFA53CB4FCDAC21
        public SqlElasticPoolImpl WithExistingDatabase(string databaseName)
        {
            this.databaseCreatableMap.Add(databaseName, (SqlDatabaseImpl)this.databasesImpl.Get(databaseName).Update().WithExistingElasticPool(this.Name));
            return this;
        }

        ///GENMHASH:C10E7F9E5F3E5F8EEC698AD28741D89A:C6490D8ECDC0B138B8A9D197F5D2C831
        public SqlElasticPoolImpl WithExistingDatabase(ISqlDatabase database)
        {
            this.databaseCreatableMap.Add(database.Name, (SqlDatabaseImpl)database.Update().WithExistingElasticPool(this.Name));
            return this;
        }

        ///GENMHASH:52F9B4107BF3F85A991B429161CF5EB8:41FD2D9003985AE2BA9F4027A8AE05F9
        public SqlElasticPoolImpl WithDatabaseDtuMin(int databaseDtuMin)
        {
            Inner.DatabaseDtuMin = databaseDtuMin;
            return this;
        }

        ///GENMHASH:BE89876FF9AA93145223609370F06FD8:FBCF393F261D9724E5F8A4C1DD0CEF0D
        public SqlElasticPoolImpl WithDatabaseDtuMax(int databaseDtuMax)
        {
            Inner.DatabaseDtuMax = databaseDtuMax;
            return this;
        }

        ///GENMHASH:FB97B6A01BB44DE1679EAB5070CAB853:55229E4F94B6412796A001B6C5185A8A
        public int StorageMB()
        {
            return Inner.StorageMB.GetValueOrDefault();
        }

        ///GENMHASH:E293D352B4C8ABEA82BF928E8B1ADC36:E89B91984CA129C2BAB11F8710EC7526
        public SqlElasticPoolImpl WithDtu(int dtu)
        {
            Inner.Dtu = dtu;
            return this;
        }

        ///GENMHASH:5219D4DB320BF9F9DA49E9B44C0088EE:3721F7B0F159C1617BDBEA9251EA81E6
        public SqlElasticPoolImpl WithStorageCapacity(int storageMB)
        {
            Inner.StorageMB = storageMB;
            return this;
        }

        ///GENMHASH:AEE17FD09F624712647F5EBCEC141EA5:F31B0F3D0CD1A4C57DB28EB70C9E094A
        public string State()
        {
            return Inner.State;
        }
    }
}
