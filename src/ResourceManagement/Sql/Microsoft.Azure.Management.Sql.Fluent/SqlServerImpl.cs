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
            SqlManager,
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

        internal SqlServerImpl(string name, ServerInner innerObject, IServersOperations innerCollection,
            SqlManager manager, IElasticPoolsOperations elasticPoolsInner, IDatabasesOperations databasesInner,
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

        public SqlServerImpl WithoutFirewallRule(string firewallRuleName)
        {
            this.firewallRulesToDelete.Add(firewallRuleName);
            return this;
        }

        public string AdministratorLogin()
        {
            return this.Inner.AdministratorLogin;
        }

        private async Task DeleteChildResourcesAsync()
        {
            await Task.WhenAll(DeleteFirewallRuleAsync(), DeleteDatabasesAndElasticPoolsAsync());
        }

        private async Task CreateOrUpdateChildResourcesAsync()
        {
            await Task.WhenAll(CreateOrUpdateFirewallRulesAsync(), CreateOrUpdateElasticPoolsAndDatabasesAsync());
        }

        private async Task DeleteFirewallRuleAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(this.firewallRulesToDelete.Select((firewallRuleToDelete) => this.firewallRulesImpl.DeleteAsync(firewallRuleToDelete)));
        }

        public IList<IServiceObjective> ListServiceObjectives()
        {
            var serviceObjectives = this.innerCollection.ListServiceObjectives(
                this.ResourceGroupName,
                this.Name);
            return serviceObjectives.Select((serviceObjectiveInner) => (IServiceObjective)new ServiceObjectiveImpl(serviceObjectiveInner, innerCollection)).ToList();
        }

        public SqlServerImpl WithAdministratorLogin(string administratorLogin)
        {
            this.Inner.AdministratorLogin = administratorLogin;
            return this;
        }

        public SqlServerImpl WithAdministratorPassword(string administratorLoginPassword)
        {
            this.Inner.AdministratorLoginPassword = administratorLoginPassword;
            return this;
        }

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

        public override async Task<ISqlServer> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var serverInner = await this.innerCollection.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            SetInner(serverInner);

            await DeleteChildResourcesAsync();
            await CreateOrUpdateChildResourcesAsync();

            return this;
        }

        public SqlServerImpl WithNewFirewallRule(string ipAddress)
        {
            return this.WithNewFirewallRule(ipAddress, ipAddress);
        }

        public SqlServerImpl WithNewFirewallRule(string startIpAddress, string endIpAddress)
        {
            return this.WithNewFirewallRule(startIpAddress, endIpAddress, ResourceNamer.RandomResourceName("firewall_", 15));
        }

        public SqlServerImpl WithNewFirewallRule(string startIpAddress, string endIpAddress, string firewallRuleName)
        {
            this.firewallRuleCreatableMap.Remove(firewallRuleName);

            this.firewallRuleCreatableMap.Add(firewallRuleName,
                this.firewallRulesImpl.Define(firewallRuleName).WithIpAddressRange(startIpAddress, endIpAddress));
            return this;
        }

        public IDatabases Databases()
        {
            if (this.databasesImpl == null)
            {
                this.databasesImpl = new DatabasesImpl(this.databasesInner, this.Manager, this.ResourceGroupName, this.Name, this.Region);
            }
            return this.databasesImpl;
        }

        public SqlServerImpl WithoutDatabase(string databaseName)
        {
            this.databasesToDelete.Add(databaseName);
            return this;
        }

        public IList<IServerMetric> ListUsages()
        {
            var usages = this.innerCollection.ListUsages(
            this.ResourceGroupName,
            this.Name);
            return usages.Select((serverMetricInner) => (IServerMetric)new ServerMetricImpl(serverMetricInner)).ToList();
        }

        public string FullyQualifiedDomainName()
        {
            return this.Inner.FullyQualifiedDomainName;
        }

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

        public override ISqlServer Refresh()
        {
            var response = this.innerCollection.GetByResourceGroup(this.ResourceGroupName, this.Name);
            this.SetInner(response);

            return this;
        }

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

        public SqlServerImpl WithNewElasticPool(string elasticPoolName, string elasticPoolEdition)
        {
            return WithNewElasticPool(elasticPoolName, elasticPoolEdition, null);
        }

        private async Task DeleteDatabasesAndElasticPoolsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(databasesToDelete.Select((databaseName) => this.Databases().DeleteAsync(databaseName)));
            await Task.WhenAll(elasticPoolsToDelete.Select((elasticPoolName) => this.ElasticPools().DeleteAsync(elasticPoolName)));
        }

        public string Version()
        {
            return this.Inner.Version;
        }

        public SqlServerImpl WithNewDatabase(string databaseName)
        {
            this.databaseCreatableMap.Remove(databaseName);

            this.databaseCreatableMap.Add(databaseName,
                this.Databases().Define(databaseName).WithoutElasticPool().WithoutSourceDatabaseId());

            return this;
        }

        private async Task CreateOrUpdateFirewallRulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.firewallRulesImpl.SqlFirewallRules().CreateAsync(this.firewallRuleCreatableMap.Values.Select(firewallRule => firewallRule as ICreatable<ISqlFirewallRule>).ToArray());
            this.firewallRuleCreatableMap.Clear();
        }

        public IServiceObjective GetServiceObjective(string serviceObjectiveName)
        {
            return new ServiceObjectiveImpl(
                this.innerCollection.GetServiceObjective(this.ResourceGroupName, this.Name, serviceObjectiveName),
                this.innerCollection);
        }

        private async Task CreateOrUpdateElasticPoolsAndDatabasesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.elasticPoolsImpl.ElasticPools.CreateAsync(
                this.elasticPoolCreatableMap.Values.Select(
                    elasticPool => elasticPool as ICreatable<ISqlElasticPool>).ToArray());
            this.elasticPoolCreatableMap.Clear();

            await this.databasesImpl.Databases.CreateAsync(
                this.databaseCreatableMap.Values.Select(
                    database => database as ICreatable<ISqlDatabase>).ToArray());
            this.databaseCreatableMap.Clear();
        }

        public SqlServerImpl WithoutElasticPool(string elasticPoolName)
        {
            this.elasticPoolsToDelete.Add(elasticPoolName);

            return this;
        }

        private void WithDatabaseInElasticPool(string databaseName, string elasticPoolName)
        {
            this.databaseCreatableMap.Remove(databaseName);

            this.databaseCreatableMap.Add(databaseName, this.Databases()
                .Define(databaseName)
                .WithExistingElasticPool(elasticPoolName)
                .WithoutSourceDatabaseId());
        }

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