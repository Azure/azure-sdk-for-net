// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xunit;

namespace Azure.Tests.Sql
{
    public class SqlTests : IDisposable
    {
        private static string GroupName = null;
        private static string SqlServerName = null;
        private static readonly string SqlDatabaseName = "myTestDatabase2";
        private static readonly string Collation = "SQL_Latin1_General_CP1_CI_AS";
        private static readonly string SqlElasticPoolName = "testElasticPool";
        private static readonly string SqlFirewallRuleName = "firewallrule1";
        private static readonly string StartIPAddress = "10.102.1.10";
        private static readonly string EndIPAddress = "10.102.1.12";

        private static void GenerateNewRGAndSqlServerNameForTest([CallerMemberName] string methodName = "testframework_failed")
        {
            GroupName = TestUtilities.GenerateName("netsqlserver", methodName);
            SqlServerName = GroupName;
        }

        public void Dispose()
        {
            DeleteResourceGroup(GroupName);
        }

        private void DeleteResourceGroup(string resourceGroup)
        {
            var resourceManager = TestHelper.CreateResourceManager();
            try
            {
                resourceManager.ResourceGroups.DeleteByName(resourceGroup);
            }
            catch
            {
            }
        }

        [Fact]
        public void CanOperateSqlFromRollUpClient()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                GenerateNewRGAndSqlServerNameForTest();
                var rollUpClient = TestHelper.CreateRollupClient();
                var sqlServer = rollUpClient.SqlServers.Define(SqlServerName)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(GroupName)
                        .WithAdministratorLogin("userName")
                        .WithAdministratorPassword("loepop77ejk~13@@")
                        .Create();
                Assert.NotNull(sqlServer.Databases.List());
                rollUpClient.SqlServers.DeleteById(sqlServer.Id);

                DeleteResourceGroup(GroupName);
            }
        }

        [Fact(Skip = "Manual only: This test require existing SQL server so that there can be recommended elastic pools")]
        public void CanListRecommendedElasticPools()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();
                var sqlServer = sqlServerManager.SqlServers.GetByResourceGroup("ans", "ans-secondary");
                var usages = sqlServer.Databases.List().First().ListServiceTierAdvisors().Values.FirstOrDefault().ServiceLevelObjectiveUsageMetrics;
                var recommendedElasticPools = sqlServer.ListRecommendedElasticPools();
                Assert.NotNull(recommendedElasticPools);
                Assert.NotNull(sqlServer.Databases.List().FirstOrDefault().GetUpgradeHint());
            }
        }

        [Fact]
        public void CanCRUDSqlServer()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                ValidateSqlServer(sqlServer);

                var serviceObjectives = sqlServer.ListServiceObjectives();

                Assert.NotEqual(serviceObjectives.Count(), 0);
                Assert.NotNull(serviceObjectives.FirstOrDefault().Refresh());
                Assert.NotNull(sqlServer.GetServiceObjective("d1737d22-a8ea-4de7-9bd0-33395d2a7419"));

                sqlServer.Update().WithAdministratorPassword("loepop77ejk~13@@").Apply();

                // List
                var sqlServers = sqlServerManager.SqlServers.ListByResourceGroup(GroupName);
                var found = false;
                foreach (var server in sqlServers)
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SqlServerName))
                    {
                        found = true;
                    }
                }
                Assert.True(found);
                // Get
                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                Assert.NotNull(sqlServer);

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        [Fact]
        public void CanUseCoolShortcutsForResourceCreation()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                var database2Name = "database2";
                var database1InEPName = "database1InEP";
                var database2InEPName = "database2InEP";
                var elasticPool2Name = "elasticPool2";
                var elasticPool3Name = "elasticPool3";
                var elasticPool1Name = SqlElasticPoolName;

                // Create
                var sqlServer = sqlServerManager.SqlServers.Define(SqlServerName)
                    .WithRegion(Region.USCentral)
                    .WithNewResourceGroup(GroupName)
                    .WithAdministratorLogin("userName")
                    .WithAdministratorPassword("loepopfuejk~13@@")
                    .WithNewDatabase(SqlDatabaseName)
                    .WithNewDatabase(database2Name)
                    .WithNewElasticPool(elasticPool1Name, ElasticPoolEditions.Standard)
                    .WithNewElasticPool(elasticPool2Name, ElasticPoolEditions.Premium, database1InEPName, database2InEPName)
                    .WithNewElasticPool(elasticPool3Name, ElasticPoolEditions.Standard)
                    .WithNewFirewallRule(StartIPAddress, EndIPAddress, SqlFirewallRuleName)
                    .WithNewFirewallRule(StartIPAddress, EndIPAddress)
                    .WithNewFirewallRule(StartIPAddress)
                    .Create();

                ValidateMultiCreation(
                    sqlServerManager,
                    database2Name,
                    database1InEPName,
                    database2InEPName,
                    elasticPool1Name,
                    elasticPool2Name,
                    elasticPool3Name,
                    sqlServer,
                    false);
                elasticPool1Name = SqlElasticPoolName + " U";
                database2Name = "database2U";
                database1InEPName = "database1InEPU";
                database2InEPName = "database2InEPU";
                elasticPool2Name = "elasticPool2U";
                elasticPool3Name = "elasticPool3U";

                // Update
                sqlServer = sqlServer.Update()
                    .WithNewDatabase(SqlDatabaseName).WithNewDatabase(database2Name)
                    .WithNewElasticPool(elasticPool1Name, ElasticPoolEditions.Standard)
                    .WithNewElasticPool(elasticPool2Name, ElasticPoolEditions.Premium, database1InEPName, database2InEPName)
                    .WithNewElasticPool(elasticPool3Name, ElasticPoolEditions.Standard)
                    .WithNewFirewallRule(StartIPAddress, EndIPAddress, SqlFirewallRuleName)
                    .WithNewFirewallRule(StartIPAddress, EndIPAddress)
                    .WithNewFirewallRule(StartIPAddress)
                    .Apply();

                ValidateMultiCreation(
                    sqlServerManager,
                    database2Name,
                    database1InEPName,
                    database2InEPName,
                    elasticPool1Name,
                    elasticPool2Name,
                    elasticPool3Name,
                    sqlServer,
                    true);

                sqlServer.Refresh();
                Assert.Equal(sqlServer.ElasticPools.List().Count(), 0);

                // List
                var sqlServers = sqlServerManager.SqlServers.ListByResourceGroup(GroupName);
                var found = false;
                foreach (var server in sqlServers)
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SqlServerName))
                    {
                        found = true;
                    }
                }

                Assert.True(found);
                // Get
                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                Assert.NotNull(sqlServer);

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        private static void ValidateMultiCreation(
                ISqlManager sqlServerManager,
                string database2Name,
                string database1InEPName,
                string database2InEPName,
                string elasticPool1Name,
                string elasticPool2Name,
                string elasticPool3Name,
                ISqlServer sqlServer,
                bool deleteUsingUpdate)
        {
            ValidateSqlServer(sqlServer);
            ValidateSqlServer(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName));
            ValidateSqlDatabase(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);
            ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SqlFirewallRuleName), SqlFirewallRuleName);

            var firewalls = sqlServer.FirewallRules.List();
            Assert.Equal(3, firewalls.Count());

            var startIPAddress = 0;
            var endIPAddress = 0;

            foreach (ISqlFirewallRule firewall in firewalls)
            {
                if (!StringComparer.OrdinalIgnoreCase.Equals(firewall.Name, SqlFirewallRuleName))
                {
                    Assert.Equal(firewall.StartIPAddress, StartIPAddress);
                    if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIPAddress, StartIPAddress))
                    {
                        startIPAddress++;
                    }
                    else if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIPAddress, EndIPAddress))
                    {
                        endIPAddress++;
                    }
                }
            }

            Assert.Equal(startIPAddress, 1);
            Assert.Equal(endIPAddress, 1);

            Assert.NotNull(sqlServer.Databases.Get(database2Name));
            Assert.NotNull(sqlServer.Databases.Get(database1InEPName));
            Assert.NotNull(sqlServer.Databases.Get(database2InEPName));

            var ep1 = sqlServer.ElasticPools.Get(elasticPool1Name);
            ValidateSqlElasticPool(ep1, elasticPool1Name);
            var ep2 = sqlServer.ElasticPools.Get(elasticPool2Name);

            Assert.NotNull(ep2);
            Assert.Equal(ep2.Edition, ElasticPoolEditions.Premium);
            Assert.Equal(ep2.ListDatabases().Count(), 2);
            Assert.NotNull(ep2.GetDatabase(database1InEPName));
            Assert.NotNull(ep2.GetDatabase(database2InEPName));

            var ep3 = sqlServer.ElasticPools.Get(elasticPool3Name);

            Assert.NotNull(ep3);
            Assert.Equal(ep3.Edition, ElasticPoolEditions.Standard);

            if (!deleteUsingUpdate)
            {
                sqlServer.Databases.Delete(database2Name);
                sqlServer.Databases.Delete(database1InEPName);
                sqlServer.Databases.Delete(database2InEPName);
                sqlServer.Databases.Delete(SqlDatabaseName);

                Assert.Equal(ep1.ListDatabases().Count(), 0);
                Assert.Equal(ep2.ListDatabases().Count(), 0);
                Assert.Equal(ep3.ListDatabases().Count(), 0);

                sqlServer.ElasticPools.Delete(elasticPool1Name);
                sqlServer.ElasticPools.Delete(elasticPool2Name);
                sqlServer.ElasticPools.Delete(elasticPool3Name);

                firewalls = sqlServer.FirewallRules.List();

                foreach (ISqlFirewallRule firewallRule in firewalls)
                {
                    firewallRule.Delete();
                }
            }
            else
            {
                sqlServer.Update()
                        .WithoutDatabase(database2Name)
                        .WithoutElasticPool(elasticPool1Name)
                        .WithoutElasticPool(elasticPool2Name)
                        .WithoutElasticPool(elasticPool3Name)
                        .WithoutElasticPool(elasticPool1Name)
                        .WithoutDatabase(database1InEPName)
                        .WithoutDatabase(SqlDatabaseName)
                        .WithoutDatabase(database2InEPName)
                        .WithoutFirewallRule(SqlFirewallRuleName)
                        .Apply();

                Assert.Equal(sqlServer.ElasticPools.List().Count(), 0);

                firewalls = sqlServer.FirewallRules.List();
                Assert.Equal(firewalls.Count(), 2);
                foreach (ISqlFirewallRule firewallRule in firewalls)
                {
                    firewallRule.Delete();
                }
            }

            Assert.Equal(sqlServer.ElasticPools.List().Count(), 0);
            // Only master database is remaining in the SQLServer.
            Assert.Equal(sqlServer.Databases.List().Count(), 1);
        }

        [Fact]
        public void CanCRUDSqlDatabase()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                var sqlDatabase = sqlServer.Databases
                    .Define(SqlDatabaseName)
                    .WithCollation(Collation)
                    .WithEdition(DatabaseEditions.Standard)
                    .Create();

                Assert.True(sqlServer.Databases.List().Count > 0);
                ValidateSqlDatabase(sqlDatabase, SqlDatabaseName);

                // Test transparent data encryption settings.
                var transparentDataEncryption = sqlDatabase.GetTransparentDataEncryption();
                Assert.NotNull(transparentDataEncryption.Status);

                var transparentDataEncryptionActivities = transparentDataEncryption.ListActivities();
                Assert.NotNull(transparentDataEncryptionActivities);

                transparentDataEncryption = transparentDataEncryption.UpdateStatus(TransparentDataEncryptionStates.Enabled);
                Assert.NotNull(transparentDataEncryption);
                Assert.Equal(transparentDataEncryption.Status, TransparentDataEncryptionStates.Enabled);

                transparentDataEncryptionActivities = transparentDataEncryption.ListActivities();
                Assert.NotNull(transparentDataEncryptionActivities);

                TestHelper.Delay(10000);
                transparentDataEncryption = sqlDatabase.GetTransparentDataEncryption().UpdateStatus(TransparentDataEncryptionStates.Disabled);
                Assert.NotNull(transparentDataEncryption);
                Assert.Equal(transparentDataEncryption.Status, TransparentDataEncryptionStates.Disabled);
                Assert.Equal(transparentDataEncryption.SqlServerName, SqlServerName);
                Assert.Equal(transparentDataEncryption.DatabaseName, SqlDatabaseName);
                Assert.NotNull(transparentDataEncryption.Name);
                Assert.NotNull(transparentDataEncryption.Id);
                // Done testing with encryption settings.

                Assert.NotNull(sqlDatabase.GetUpgradeHint());

                // Test Service tier advisors.
                var serviceTierAdvisors = sqlDatabase.ListServiceTierAdvisors();
                Assert.NotNull(serviceTierAdvisors);
                Assert.NotNull(serviceTierAdvisors.Values.First().ServiceLevelObjectiveUsageMetrics);
                Assert.NotEqual(serviceTierAdvisors.Count(), 0);

                Assert.NotNull(serviceTierAdvisors.Values.First().Refresh());
                Assert.NotNull(serviceTierAdvisors.Values.First().ServiceLevelObjectiveUsageMetrics);
                // End of testing service tier advisors.

                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                ValidateSqlServer(sqlServer);

                // Create another database with above created database as source database.
                var sqlElasticPoolCreatable = sqlServer.ElasticPools
                    .Define(SqlElasticPoolName)
                    .WithEdition(ElasticPoolEditions.Standard);
                var anotherDatabaseName = "anotherDatabase";
                var anotherDatabase = sqlServer.Databases
                    .Define(anotherDatabaseName)
                    .WithNewElasticPool(sqlElasticPoolCreatable)
                    .WithSourceDatabase(sqlDatabase.Id)
                    .WithMode(CreateMode.Copy)
                    .Create();

                ValidateSqlDatabaseWithElasticPool(anotherDatabase, anotherDatabaseName);
                sqlServer.Databases.Delete(anotherDatabase.Name);

                // Get
                ValidateSqlDatabase(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);

                // List
                ValidateListSqlDatabase(sqlServer.Databases.List());

                // Delete
                sqlServer.Databases.Delete(SqlDatabaseName);
                ValidateSqlDatabaseNotFound(sqlServerManager, SqlDatabaseName);

                // Add another database to the server
                sqlDatabase = sqlServer.Databases
                        .Define("newDatabase")
                        .WithCollation(Collation)
                        .WithEdition(DatabaseEditions.Standard)
                        .Create();
                sqlServer.Databases.Delete(sqlDatabase.Name);

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
            }
        }

        [Fact]
        public void CanManageReplicationLinks()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var anotherSqlServerName = SqlServerName + "another";
                var sqlServer1 = CreateSqlServer(sqlServerManager);
                var sqlServer2 = CreateSqlServer(sqlServerManager, anotherSqlServerName);

                var databaseInServer1 = sqlServer1.Databases
                    .Define(SqlDatabaseName)
                    .WithCollation(Collation)
                    .WithEdition(DatabaseEditions.Standard)
                    .Create();

                ValidateSqlDatabase(databaseInServer1, SqlDatabaseName);
                var databaseInServer2 = sqlServer2.Databases
                    .Define(SqlDatabaseName)
                    .WithSourceDatabase(databaseInServer1.Id)
                    .WithMode(CreateMode.OnlineSecondary)
                    .Create();
                TestHelper.Delay(2000);
                var replicationLinksInDb1 = new List<IReplicationLink>(databaseInServer1.ListReplicationLinks().Values);

                Assert.Equal(replicationLinksInDb1.Count(), 1);
                Assert.Equal(replicationLinksInDb1.FirstOrDefault().PartnerDatabase, databaseInServer2.Name);
                Assert.Equal(replicationLinksInDb1.FirstOrDefault().PartnerServer, databaseInServer2.SqlServerName);

                var replicationLinksInDb2 = new List<IReplicationLink>(databaseInServer2.ListReplicationLinks().Values);

                Assert.Equal(replicationLinksInDb2.Count(), 1);
                Assert.Equal(replicationLinksInDb2.FirstOrDefault().PartnerDatabase, databaseInServer1.Name);
                Assert.Equal(replicationLinksInDb2.FirstOrDefault().PartnerServer, databaseInServer1.SqlServerName);

                Assert.NotNull(replicationLinksInDb1.FirstOrDefault().Refresh());

                // Failover
                replicationLinksInDb2.FirstOrDefault().Failover();
                replicationLinksInDb2.FirstOrDefault().Refresh();
                TestHelper.Delay(30000);
                // Force failover
                replicationLinksInDb1.FirstOrDefault().ForceFailoverAllowDataLoss();
                replicationLinksInDb1.FirstOrDefault().Refresh();

                TestHelper.Delay(30000);

                replicationLinksInDb2.FirstOrDefault().Delete();
                Assert.Equal(databaseInServer2.ListReplicationLinks().Count(), 0);

                sqlServer1.Databases.Delete(databaseInServer1.Name);
                sqlServer2.Databases.Delete(databaseInServer2.Name);

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer2.ResourceGroupName, sqlServer2.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer2);
                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer1.ResourceGroupName, sqlServer1.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer1);
                DeleteResourceGroup(sqlServer1.ResourceGroupName);
                DeleteResourceGroup(sqlServer2.ResourceGroupName);
            }
        }

        [Fact]
        public void CanDoOperationsOnDataWarehouse()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                ValidateSqlServer(sqlServer);

                // List usages for the server.
                Assert.NotNull(sqlServer.ListUsages());

                var sqlDatabase = sqlServer.Databases
                        .Define(SqlDatabaseName)
                        .WithCollation(Collation)
                        .WithEdition(DatabaseEditions.DataWarehouse)
                        .Create();

                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.NotNull(sqlDatabase);
                Assert.True(sqlDatabase.IsDataWarehouse);

                // Get
                var dataWarehouse = sqlServer.Databases.Get(SqlDatabaseName).AsWarehouse();

                Assert.NotNull(dataWarehouse);
                Assert.Equal(dataWarehouse.Name, SqlDatabaseName);
                Assert.Equal(dataWarehouse.Edition, DatabaseEditions.DataWarehouse);

                // List Restore points.
                Assert.NotNull(dataWarehouse.ListRestorePoints());
                // Get usages.
                Assert.NotNull(dataWarehouse.ListUsages());

                // Pause warehouse
                dataWarehouse.PauseDataWarehouse();

                // Resume warehouse
                dataWarehouse.ResumeDataWarehouse();

                sqlServer.Databases.Delete(SqlDatabaseName);

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        [Fact]
        public void CanCRUDSqlDatabaseWithElasticPool()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                var sqlElasticPoolCreatable = sqlServer.ElasticPools
                        .Define(SqlElasticPoolName)
                        .WithEdition(ElasticPoolEditions.Standard);

                var sqlDatabase = sqlServer.Databases
                        .Define(SqlDatabaseName)
                        .WithNewElasticPool(sqlElasticPoolCreatable)
                        .WithCollation(Collation)
                        .Create();

                ValidateSqlDatabase(sqlDatabase, SqlDatabaseName);

                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                ValidateSqlServer(sqlServer);

                // Get Elastic pool
                var elasticPool = sqlServer.ElasticPools.Get(SqlElasticPoolName);
                ValidateSqlElasticPool(elasticPool);

                // Get
                ValidateSqlDatabaseWithElasticPool(sqlServer.Databases.Get(SqlDatabaseName), SqlDatabaseName);

                // List
                ValidateListSqlDatabase(sqlServer.Databases.List());

                // Remove database from elastic pools.
                sqlDatabase.Update()
                        .WithoutElasticPool()
                        .WithEdition(DatabaseEditions.Standard)
                        .WithServiceObjective(ServiceObjectiveName.S3)
                    .Apply();
                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.Null(sqlDatabase.ElasticPoolName);

                // Update edition of the SQL database
                sqlDatabase.Update()
                        .WithEdition(DatabaseEditions.Premium)
                        .WithServiceObjective(ServiceObjectiveName.P1)
                        .Apply();
                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.Equal(sqlDatabase.Edition, DatabaseEditions.Premium);
                Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P1);

                // Update just the service level objective for database.
                sqlDatabase.Update().WithServiceObjective(ServiceObjectiveName.P2).Apply();
                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P2);
                Assert.Equal(sqlDatabase.RequestedServiceObjectiveName, ServiceObjectiveName.P2);

                // Update max size bytes of the database.
                sqlDatabase.Update()
                        .WithMaxSizeBytes(268435456000L)
                        .Apply();

                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.Equal(sqlDatabase.MaxSizeBytes, 268435456000L);

                // Put the database back in elastic pool.
                sqlDatabase.Update()
                        .WithExistingElasticPool(SqlElasticPoolName)
                        .Apply();

                sqlDatabase = sqlServer.Databases.Get(SqlDatabaseName);
                Assert.Equal(sqlDatabase.ElasticPoolName, SqlElasticPoolName);

                // List Activity in elastic pool
                Assert.NotNull(elasticPool.ListActivities());

                // List Database activity in elastic pool.
                Assert.NotNull(elasticPool.ListDatabaseActivities());

                // List databases in elastic pool.
                var databasesInElasticPool = elasticPool.ListDatabases();
                Assert.NotNull(databasesInElasticPool);
                Assert.Equal(databasesInElasticPool.Count(), 1);

                // Get a particular database in elastic pool.
                var databaseInElasticPool = elasticPool.GetDatabase(SqlDatabaseName);
                ValidateSqlDatabase(databaseInElasticPool, SqlDatabaseName);

                // Refresh works on the database got from elastic pool.
                databaseInElasticPool.Refresh();

                // Validate that trying to get an invalid database from elastic pool returns null.
                try
                {
                    elasticPool.GetDatabase("does_not_exist");
                    Assert.NotNull(null);
                }
                catch
                {
                }

                // Delete
                sqlServer.Databases.Delete(SqlDatabaseName);
                ValidateSqlDatabaseNotFound(sqlServerManager, SqlDatabaseName);

                var sqlElasticPool = sqlServer.ElasticPools.Get(SqlElasticPoolName);

                // Add another database to the server and pool.
                sqlDatabase = sqlServer.Databases
                        .Define("newDatabase")
                        .WithExistingElasticPool(sqlElasticPool)
                        .WithCollation(Collation)
                        .Create();
                sqlServer.Databases.Delete(sqlDatabase.Name);
                ValidateSqlDatabaseNotFound(sqlServerManager, "newDatabase");

                sqlServer.ElasticPools.Delete(SqlElasticPoolName);
                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        [Fact]
        public void CanCRUDSqlElasticPool()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                ValidateSqlServer(sqlServer);

                var sqlElasticPool = sqlServer.ElasticPools
                        .Define(SqlElasticPoolName)
                        .WithEdition(ElasticPoolEditions.Standard)
                        .Create();
                ValidateSqlElasticPool(sqlElasticPool);
                Assert.Equal(sqlElasticPool.ListDatabases().Count(), 0);

                sqlElasticPool = sqlElasticPool.Update()
                        .WithDtu(100)
                        .WithDatabaseDtuMax(20)
                        .WithDatabaseDtuMin(10)
                        .WithStorageCapacity(102400)
                        .WithNewDatabase(SqlDatabaseName)
                        .Apply();

                ValidateSqlElasticPool(sqlElasticPool);
                Assert.Equal(sqlElasticPool.ListDatabases().Count(), 1);

                // Get
                ValidateSqlElasticPool(sqlServer.ElasticPools.Get(SqlElasticPoolName));

                // List
                ValidateListSqlElasticPool(sqlServer.ElasticPools.List());

                // Delete
                sqlServer.Databases.Delete(SqlDatabaseName);
                sqlServer.ElasticPools.Delete(SqlElasticPoolName);
                ValidateSqlElasticPoolNotFound(sqlServer, SqlElasticPoolName);

                // Add another database to the server
                sqlElasticPool = sqlServer.ElasticPools
                        .Define("newElasticPool")
                        .WithEdition(ElasticPoolEditions.Standard)
                        .Create();

                sqlServer.ElasticPools.Delete(sqlElasticPool.Name);
                ValidateSqlElasticPoolNotFound(sqlServer, "newElasticPool");

                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        [Fact]
        public void CanCRUDSqlFirewallRule()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();

                GenerateNewRGAndSqlServerNameForTest();

                // Create
                var sqlServer = CreateSqlServer(sqlServerManager);

                sqlServer = sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName);
                ValidateSqlServer(sqlServer);

                var sqlFirewallRule = sqlServer.FirewallRules
                        .Define(SqlFirewallRuleName)
                        .WithIPAddressRange(StartIPAddress, EndIPAddress)
                        .Create();

                ValidateSqlFirewallRule(sqlFirewallRule, SqlFirewallRuleName);
                ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SqlFirewallRuleName), SqlFirewallRuleName);

                var secondFirewallRuleName = "secondFireWallRule";
                var secondFirewallRule = sqlServer.FirewallRules
                        .Define(secondFirewallRuleName)
                        .WithIPAddress(StartIPAddress)
                        .Create();

                secondFirewallRule = sqlServer.FirewallRules.Get(secondFirewallRuleName);

                Assert.NotNull(secondFirewallRule);
                Assert.Equal(StartIPAddress, secondFirewallRule.EndIPAddress);

                secondFirewallRule = secondFirewallRule.Update().WithEndIPAddress(EndIPAddress).Apply();

                ValidateSqlFirewallRule(secondFirewallRule, secondFirewallRuleName);
                sqlServer.FirewallRules.Delete(secondFirewallRuleName);
                Assert.Null(sqlServer.FirewallRules.Get(secondFirewallRuleName));

                // Get
                sqlFirewallRule = sqlServer.FirewallRules.Get(SqlFirewallRuleName);
                ValidateSqlFirewallRule(sqlFirewallRule, SqlFirewallRuleName);

                // Update
                // Making start and end IP address same.
                sqlFirewallRule.Update().WithEndIPAddress(StartIPAddress).Apply();
                sqlFirewallRule = sqlServer.FirewallRules.Get(SqlFirewallRuleName);
                Assert.Equal(sqlFirewallRule.EndIPAddress, StartIPAddress);

                // List
                ValidateListSqlFirewallRule(sqlServer.FirewallRules.List());

                // Delete
                sqlServer.FirewallRules.Delete(sqlFirewallRule.Name);
                ValidateSqlFirewallRuleNotFound(sqlServerManager);

                // Delete server
                sqlServerManager.SqlServers.DeleteByResourceGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        private static void ValidateSqlFirewallRuleNotFound(ISqlManager sqlServerManager)
        {
            Assert.Null(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName).FirewallRules.Get(SqlFirewallRuleName));
        }

        private static void ValidateSqlElasticPoolNotFound(ISqlServer sqlServer, string elasticPoolName)
        {
            Assert.Null(sqlServer.ElasticPools.Get(elasticPoolName));
        }

        private static void ValidateSqlDatabaseNotFound(ISqlManager sqlServerManager, String newDatabase)
        {
            Assert.Null(sqlServerManager.SqlServers.GetByResourceGroup(GroupName, SqlServerName).Databases.Get(newDatabase));
        }

        private static void ValidateSqlServerNotFound(ISqlManager sqlServerManager, ISqlServer sqlServer)
        {
            Assert.Null(sqlServerManager.SqlServers.GetById(sqlServer.Id));
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager)
        {
            return CreateSqlServer(sqlServerManager, SqlServerName);
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager, string sqlServerName)
        {
            return sqlServerManager.SqlServers
                    .Define(sqlServerName)
                    .WithRegion(Region.USCentral)
                    .WithNewResourceGroup(GroupName)
                    .WithAdministratorLogin("userName")
                    .WithAdministratorPassword("loepopfuejk~13@@")
                    .Create();
        }

        private static void ValidateListSqlFirewallRule(IReadOnlyList<ISqlFirewallRule> sqlFirewallRules)
        {
            Assert.True(sqlFirewallRules.Any(firewallRule => StringComparer.OrdinalIgnoreCase.Equals(firewallRule.Name, SqlFirewallRuleName)));
        }

        private static void ValidateSqlFirewallRule(ISqlFirewallRule sqlFirewallRule, string firewallName)
        {
            Assert.NotNull(sqlFirewallRule);
            Assert.Equal(firewallName, sqlFirewallRule.Name);
            Assert.Equal(SqlServerName, sqlFirewallRule.SqlServerName);
            Assert.Equal(StartIPAddress, sqlFirewallRule.StartIPAddress);
            Assert.Equal(EndIPAddress, sqlFirewallRule.EndIPAddress);
            Assert.Equal(GroupName, sqlFirewallRule.ResourceGroupName);
            Assert.Equal(SqlServerName, sqlFirewallRule.SqlServerName);
            Assert.Equal(Region.USCentral, sqlFirewallRule.Region);
        }

        private static void ValidateListSqlElasticPool(IReadOnlyList<ISqlElasticPool> sqlElasticPools)
        {
            Assert.True(sqlElasticPools.Any(elasticPool => StringComparer.OrdinalIgnoreCase.Equals(elasticPool.Name, SqlElasticPoolName)));
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool)
        {
            ValidateSqlElasticPool(sqlElasticPool, SqlElasticPoolName);
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool, string elasticPoolName)
        {
            Assert.NotNull(sqlElasticPool);
            Assert.Equal(GroupName, sqlElasticPool.ResourceGroupName);
            Assert.Equal(elasticPoolName, sqlElasticPool.Name);
            Assert.Equal(SqlServerName, sqlElasticPool.SqlServerName);
            Assert.Equal(ElasticPoolEditions.Standard, sqlElasticPool.Edition);
            Assert.NotNull(sqlElasticPool.CreationDate);
            Assert.NotEqual(0, sqlElasticPool.DatabaseDtuMax);
            Assert.NotEqual(0, sqlElasticPool.Dtu);
        }

        private static void ValidateListSqlDatabase(IReadOnlyList<ISqlDatabase> sqlDatabases)
        {
            Assert.True(sqlDatabases.Any(database => StringComparer.OrdinalIgnoreCase.Equals(database.Name, SqlDatabaseName)));
        }

        private static void ValidateSqlServer(ISqlServer sqlServer)
        {
            Assert.NotNull(sqlServer);
            Assert.Equal(GroupName, sqlServer.ResourceGroupName);
            Assert.NotNull(sqlServer.FullyQualifiedDomainName);
            Assert.Equal(ServerVersion.OneTwoFullStopZero, sqlServer.Version);
            Assert.Equal("userName", sqlServer.AdministratorLogin);
        }

        private static void ValidateSqlDatabase(ISqlDatabase sqlDatabase, string databaseName)
        {
            Assert.NotNull(sqlDatabase);
            Assert.Equal(sqlDatabase.Name, databaseName);
            Assert.Equal(SqlServerName, sqlDatabase.SqlServerName);
            Assert.Equal(sqlDatabase.Collation, Collation);
            Assert.Equal(sqlDatabase.Edition, DatabaseEditions.Standard);
        }

        private static void ValidateSqlDatabaseWithElasticPool(ISqlDatabase sqlDatabase, string databaseName)
        {
            ValidateSqlDatabase(sqlDatabase, databaseName);
            Assert.Equal(SqlElasticPoolName, sqlDatabase.ElasticPoolName);
        }
    }
}