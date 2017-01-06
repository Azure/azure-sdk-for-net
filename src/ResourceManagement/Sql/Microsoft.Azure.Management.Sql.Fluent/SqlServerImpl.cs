// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core.ResourceActions;
    using SqlServer.Databases;
    using SqlServer.ElasticPools;
    using SqlServer.FirewallRules;
    using SqlServer.Update;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for SqlServer and its parent interfaces.
    /// </summary>
    internal partial class SqlServerImpl :
        GroupableResource<
            ISqlServer,
            ServerInner,
            SqlServerImpl,
            ISqlManager,
            SqlServer.Definition.IWithGroup,
            SqlServer.Definition.IWithAdministratorLogin,
            SqlServer.Definition.IWithCreate,
            SqlServer.Update.IUpdate>,
        ISqlServer,
        SqlServer.Definition.IDefinition,
        IUpdate
    {
        private IServersOperations innerCollection;
        private IElasticPoolsOperations elasticPoolsInner;
        private IDatabasesOperations databasesInner;
        private IRecommendedElasticPoolsOperations recommendedElasticPoolsInner;
        private IDictionary<string, SqlElasticPool.Definition.IWithCreate> elasticPoolCreatableMap;
        private IDictionary<string, SqlFirewallRule.Definition.IWithCreate> firewallRuleCreatableMap;
        private IDictionary<string, SqlDatabase.Definition.IWithCreate> databaseCreatableMap;
        private FirewallRulesImpl firewallRulesImpl;
        private ElasticPoolsImpl elasticPoolsImpl;
        private DatabasesImpl databasesImpl;
        private IList<string> elasticPoolsToDelete;
        private IList<string> firewallRulesToDelete;
        private IList<string> databasesToDelete;

        ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTZXJ2ZXJJbXBs
        internal SqlServerImpl(string name, ServerInner innerObject, IServersOperations innerCollection,
            ISqlManager manager, IElasticPoolsOperations elasticPoolsInner, IDatabasesOperations databasesInner,
            IRecommendedElasticPoolsOperations recommendedElasticPoolsInner)
            : base(name, innerObject, manager)
        {
            this.innerCollection = innerCollection;
            this.elasticPoolsInner = elasticPoolsInner;
            this.databasesInner = databasesInner;
            this.recommendedElasticPoolsInner = recommendedElasticPoolsInner;

            this.databaseCreatableMap = new Dictionary<string, SqlDatabase.Definition.IWithCreate>();
            this.elasticPoolCreatableMap = new Dictionary<string, SqlElasticPool.Definition.IWithCreate>();
            this.firewallRuleCreatableMap = new Dictionary<string, SqlFirewallRule.Definition.IWithCreate>();

            this.elasticPoolsToDelete = new List<string>();
            this.databasesToDelete = new List<string>();
            this.firewallRulesToDelete = new List<string>();
        }

        ///GENMHASH:D14E9D120B5AE20CBE29EEDB19E51726:9F7A942C3CD9C1E1D14B752782BC5635
        public SqlServerImpl WithoutFirewallRule(string firewallRuleName)
        {
            this.firewallRulesToDelete.Add(firewallRuleName);
            return this;
        }

        ///GENMHASH:76CA3DF47AE2173C7DD2F7771FDD2AD0:B347DF5D92EFFF6EC992D5C6C59BB49E
        public string AdministratorLogin()
        {
            return this.Inner.AdministratorLogin;
        }

        ///GENMHASH:E8FF0EA4C9A70B28C5CC2D7109717350:1E18DC483BE5652C158841887DD5936F
        private async Task DeleteChildResourcesAsync()
        {
            await Task.WhenAll(DeleteFirewallRuleAsync(), DeleteDatabasesAndElasticPoolsAsync());
        }

        ///GENMHASH:B78DFDEE870AD37F60EF238FF854629E:6F640C7F45F52AB9BB3143BCD2962AC5
        private async Task CreateOrUpdateChildResourcesAsync()
        {
            await Task.WhenAll(CreateOrUpdateFirewallRulesAsync(), CreateOrUpdateElasticPoolsAndDatabasesAsync());
        }

        ///GENMHASH:7E50AD9C0C3F4B5336C13F19E4DAF04D:2BA4F314D86877439CDB39BE947335E8
        private async Task DeleteFirewallRuleAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(this.firewallRulesToDelete.Select((firewallRuleToDelete) => this.firewallRulesImpl.DeleteAsync(firewallRuleToDelete)));
        }

        ///GENMHASH:2A59E18DA93663D485FB24124FE696D7:A9A12F1824E7FC07247043927FEEBFC2
        public IList<IServiceObjective> ListServiceObjectives()
        {
            var serviceObjectives = this.innerCollection.ListServiceObjectives(
                this.ResourceGroupName,
                this.Name);
            return serviceObjectives.Select((serviceObjectiveInner) => (IServiceObjective)new ServiceObjectiveImpl(serviceObjectiveInner, innerCollection)).ToList();
        }

        ///GENMHASH:2F58B86CF4C09A3821196E375EB636F4:AA91D65BA65D340B46D6B88D4467855D
        public SqlServerImpl WithAdministratorLogin(string administratorLogin)
        {
            this.Inner.AdministratorLogin = administratorLogin;
            return this;
        }

        ///GENMHASH:618686B3EE435187E4F949C115EFA823:983FBE57E91E1FA947BEA694720011F0
        public SqlServerImpl WithAdministratorPassword(string administratorLoginPassword)
        {
            this.Inner.AdministratorLoginPassword = administratorLoginPassword;
            return this;
        }

        ///GENMHASH:42238C96020583EAD41C40C184F554ED:69F489ECA959B263C944C8127108388F
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Sql.Fluent.IRecommendedElasticPool> ListRecommendedElasticPools()
        {
            var recommendedElasticPools = this.recommendedElasticPoolsInner.List(
            this.ResourceGroupName,
            this.Name);

            return new ReadOnlyDictionary<string, IRecommendedElasticPool>(recommendedElasticPools.ToDictionary(
                    recommendedElasticPoolInner => recommendedElasticPoolInner.Name,
                    recommendedElasticPoolInner => (IRecommendedElasticPool)new RecommendedElasticPoolImpl(
                        recommendedElasticPoolInner, this.databasesInner, this.recommendedElasticPoolsInner)));
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:3A15AE6B9ADA17FBEC37A8078DA08565
        public override async Task<ISqlServer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverInner = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            SetInner(serverInner);

            await DeleteChildResourcesAsync();
            await CreateOrUpdateChildResourcesAsync();

            return this;
        }

        ///GENMHASH:4693BD7957E2D51A8D0B8B0AFDDA3A22:053C528D1658BA9F774BF38FF3DDB425
        public SqlServerImpl WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress, ipAddress);
        }

        ///GENMHASH:B586503226700C805360D5B6E3725EF6:E505BA6DA6C53CDACAB31669A8BAC1D2
        public SqlServerImpl WithNewFirewallRule(string startIpAddress, string endIpAddress)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress, SharedSettings.RandomResourceName("firewall_", 15));
        }

        ///GENMHASH:69FD06084D43219AA18CD7D3D99C1279:4CFE3B40F5F4B89B4325AA4C436DF8EE
        public SqlServerImpl WithNewFirewallRule(string startIpAddress, string endIpAddress, string firewallRuleName)
        {
            this.firewallRuleCreatableMap.Remove(firewallRuleName);

            this.firewallRuleCreatableMap.Add(firewallRuleName,
                this.FirewallRules().Define(firewallRuleName).WithIpAddressRange(startIpAddress, endIpAddress));
            return this;
        }

        ///GENMHASH:DF46C62E0E8998CD0340B3F8A136F135:162FCA0A7E0415224BF3AD6DEFD9DC00
        public IDatabases Databases()
        {
            if (this.databasesImpl == null)
            {
                this.databasesImpl = new DatabasesImpl(this.databasesInner, this.Manager, this.ResourceGroupName, this.Name, this.Region);
            }
            return this.databasesImpl;
        }

        ///GENMHASH:39211D199FB6D28F49ADF0BA2BA3CF1E:B4D84A42F3D3231B1FFD5AD6C788EA45
        public SqlServerImpl WithoutDatabase(string databaseName)
        {
            this.databasesToDelete.Add(databaseName);
            return this;
        }

        ///GENMHASH:0E666BFDFC9A666CA31FD735D7839414:2AAE577C01D4088729534C3BC39664A7
        public IList<IServerMetric> ListUsages()
        {
            var usages = this.innerCollection.ListUsages(
            this.ResourceGroupName,
            this.Name);
            return usages.Select((serverMetricInner) => (IServerMetric)new ServerMetricImpl(serverMetricInner)).ToList();
        }

        ///GENMHASH:207CF59627452C607A1B799233F875B9:24C6C69C18977BD264EC783E32744339
        public string FullyQualifiedDomainName()
        {
            return this.Inner.FullyQualifiedDomainName;
        }

        ///GENMHASH:22ED13819FBF2CA919B55726AC1FB656:470E0AF821791A8E1F0273443B706FEA
        public IElasticPools ElasticPools()
        {
            if (this.elasticPoolsImpl == null)
            {
                this.elasticPoolsImpl = new ElasticPoolsImpl(
                this.elasticPoolsInner,
                this.Manager,
                this.databasesInner,
                (DatabasesImpl)this.Databases(),
                this.ResourceGroupName,
                this.Name,
                this.Region);
            }
            return this.elasticPoolsImpl;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:62957758FC09C0990CF1236E4DBFE16D
        public override ISqlServer Refresh()
        {
            var response = this.innerCollection.GetByResourceGroup(this.ResourceGroupName, this.Name);
            this.SetInner(response);

            return this;
        }

        ///GENMHASH:7D636B43F636D47A310AB1AF99E3C582:8AD037D8825930A5FDA5752A92895784
        public SqlServerImpl WithNewElasticPool(string elasticPoolName, string elasticPoolEdition, params string[] databaseNames)
        {
            if (!elasticPoolCreatableMap.ContainsKey(elasticPoolName))
            {
                this.elasticPoolCreatableMap.Add(elasticPoolName, this.ElasticPools().Define(elasticPoolName).WithEdition(elasticPoolEdition));
            }

            if (databaseNames != null)
            {
                foreach (var databaseName in databaseNames)
                {
                    WithDatabaseInElasticPool(databaseName, elasticPoolName);
                }
            }

            return this;
        }

        ///GENMHASH:15C6DE336A70D5E1EDFAC74C3066EED7:6CC0DB20CC1C8B5143A66E5EC134B6B9
        public SqlServerImpl WithNewElasticPool(string elasticPoolName, string elasticPoolEdition)
        {
            return WithNewElasticPool(elasticPoolName, elasticPoolEdition, null);
        }

        ///GENMHASH:E32216D611BFF265A1F25D65E5EFA4A3:5A4B9BD63AA8FEB5746A72A9F3CFED28
        private async Task DeleteDatabasesAndElasticPoolsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(databasesToDelete.Select((databaseName) => this.Databases().DeleteAsync(databaseName)));
            await Task.WhenAll(elasticPoolsToDelete.Select((elasticPoolName) => this.ElasticPools().DeleteAsync(elasticPoolName)));
        }

        ///GENMHASH:493B1EDB88EACA3A476D936362A5B14C:583937857C93CEEDEFD65D6B38E46ADD
        public string Version()
        {
            return this.Inner.Version;
        }

        ///GENMHASH:D7949083DDCDE361387E2A975A1A1DE5:C1BF60564A7C5B160B5E34171A73CC9C
        public SqlServerImpl WithNewDatabase(string databaseName)
        {
            this.databaseCreatableMap.Remove(databaseName);

            this.databaseCreatableMap.Add(databaseName,
                this.Databases().Define(databaseName).WithoutElasticPool().WithoutSourceDatabaseId());

            return this;
        }

        ///GENMHASH:D8D142E7FD8CC54428AA984C509B8FC8:D3504AC2A9A0717A59959BE778357FC7
        private async Task CreateOrUpdateFirewallRulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.firewallRuleCreatableMap.Any())
            {
                var firewallCreatables = this.firewallRuleCreatableMap.Values.Select(firewallRule => firewallRule as ICreatable<ISqlFirewallRule>).ToArray();
                await this.firewallRulesImpl.SqlFirewallRules().CreateAsync(firewallCreatables);
                this.firewallRuleCreatableMap.Clear();
            }
        }

        ///GENMHASH:32076B0182F921179C1E78728F749DBF:1711ED7C1A451D45F74D5A94B70C7907
        public IServiceObjective GetServiceObjective(string serviceObjectiveName)
        {
            return new ServiceObjectiveImpl(
                this.innerCollection.GetServiceObjective(this.ResourceGroupName, this.Name, serviceObjectiveName),
                this.innerCollection);
        }

        ///GENMHASH:0E72E9CA1B7053C3FF04E00B992D9096:C708FFD899243CFE1DDD3607C4089B6A
        private async Task CreateOrUpdateElasticPoolsAndDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.elasticPoolCreatableMap.Any())
            {
                await this.elasticPoolsImpl.ElasticPools.CreateAsync(
                    this.elasticPoolCreatableMap.Values.Select(
                        elasticPool => elasticPool as ICreatable<ISqlElasticPool>).ToArray());
                this.elasticPoolCreatableMap.Clear();
            }

            if (this.databaseCreatableMap.Any())
            {
                await this.databasesImpl.Databases.CreateAsync(
                    this.databaseCreatableMap.Values.Select(
                        database => database as ICreatable<ISqlDatabase>).ToArray());
                this.databaseCreatableMap.Clear();
            }
        }

        ///GENMHASH:16B9C6819B9C7B3C705BAABCD3F0D40E:B348E6639CB1D40C9D96A7C2987DEA0C
        public SqlServerImpl WithoutElasticPool(string elasticPoolName)
        {
            this.elasticPoolsToDelete.Add(elasticPoolName);

            return this;
        }

        ///GENMHASH:77FCE079B32B71295AE582EB77E23D52:96B9EEEE3F1DEFD789BCB8A2254A6BC8
        private void WithDatabaseInElasticPool(string databaseName, string elasticPoolName)
        {
            this.databaseCreatableMap.Remove(databaseName);

            this.databaseCreatableMap.Add(databaseName, this.Databases()
                .Define(databaseName)
                .WithExistingElasticPool(elasticPoolName)
                .WithoutSourceDatabaseId());
        }

        ///GENMHASH:7DDEADFB2FB27BEC42C0B993AB65C3CB:0D8D2B5DE282DE762F97F0E96C5562F9
        public IFirewallRules FirewallRules()
        {
            if (this.firewallRulesImpl == null)
            {
                this.firewallRulesImpl = new FirewallRulesImpl(this.innerCollection, this.Manager, this.ResourceGroupName, this.Name);
            }
            return this.firewallRulesImpl;
        }
    }
}
