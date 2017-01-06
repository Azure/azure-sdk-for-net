// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent.Core;
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
        private static string RG_NAME = null;
        private static string SQL_SERVER_NAME = null;
        private static readonly string SQL_DATABASE_NAME = "myTestDatabase2";
        private static readonly string COLLATION = "SQL_Latin1_General_CP1_CI_AS";
        private static readonly string SQL_ELASTIC_POOL_NAME = "testElasticPool";
        private static readonly string SQL_FIREWALLRULE_NAME = "firewallrule1";
        private static readonly string START_IPADDRESS = "10.102.1.10";
        private static readonly string END_IPADDRESS = "10.102.1.12";

        private static void GenerateNewRGAndSqlServerNameForTest([CallerMemberName] string methodName = "testframework_failed")
        {
            RG_NAME = TestUtilities.GenerateName("netsqlserver", methodName);
            SQL_SERVER_NAME = RG_NAME;
        }

        public void Dispose()
        {
            DeleteResourceGroup(RG_NAME);
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
                var sqlServer = rollUpClient.SqlServers.Define(SQL_SERVER_NAME)
                        .WithRegion(Region.US_CENTRAL)
                        .WithNewResourceGroup(RG_NAME)
                        .WithAdministratorLogin("userName")
                        .WithAdministratorPassword("loepop77ejk~13@@")
                        .Create();
                Assert.NotNull(sqlServer.Databases.List());
                rollUpClient.SqlServers.DeleteById(sqlServer.Id);

                DeleteResourceGroup(RG_NAME);
            }
        }

        [Fact(Skip ="This test require existing SQL server so that there can be recommended elastic pools")]
        public void CanListRecommendedElasticPools()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var sqlServerManager = TestHelper.CreateSqlManager();
                var sqlServer = sqlServerManager.SqlServers.GetByGroup("ans", "ans-secondary");
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
                var sqlServers = sqlServerManager.SqlServers.ListByGroup(RG_NAME);
                var found = false;
                foreach (var server in sqlServers)
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SQL_SERVER_NAME))
                    {
                        found = true;
                    }
                }
                Assert.True(found);
                // Get
                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                Assert.NotNull(sqlServer);

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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
                var elasticPool1Name = SQL_ELASTIC_POOL_NAME;

                // Create
                var sqlServer = sqlServerManager.SqlServers.Define(SQL_SERVER_NAME)
                    .WithRegion(Region.US_CENTRAL)
                    .WithNewResourceGroup(RG_NAME)
                    .WithAdministratorLogin("userName")
                    .WithAdministratorPassword("loepopfuejk~13@@")
                    .WithNewDatabase(SQL_DATABASE_NAME)
                    .WithNewDatabase(database2Name)
                    .WithNewElasticPool(elasticPool1Name, ElasticPoolEditions.Standard)
                    .WithNewElasticPool(elasticPool2Name, ElasticPoolEditions.Premium, database1InEPName, database2InEPName)
                    .WithNewElasticPool(elasticPool3Name, ElasticPoolEditions.Standard)
                    .WithNewFirewallRule(START_IPADDRESS, END_IPADDRESS, SQL_FIREWALLRULE_NAME)
                    .WithNewFirewallRule(START_IPADDRESS, END_IPADDRESS)
                    .WithNewFirewallRule(START_IPADDRESS)
                    .Create();

                ValidateMultiCreation(sqlServerManager, database2Name, database1InEPName, database2InEPName,
                    elasticPool1Name, elasticPool2Name, elasticPool3Name, sqlServer, false);
                elasticPool1Name = SQL_ELASTIC_POOL_NAME + " U";
                database2Name = "database2U";
                database1InEPName = "database1InEPU";
                database2InEPName = "database2InEPU";
                elasticPool2Name = "elasticPool2U";
                elasticPool3Name = "elasticPool3U";

                // Update
                sqlServer = sqlServer.Update()
                    .WithNewDatabase(SQL_DATABASE_NAME).WithNewDatabase(database2Name)
                    .WithNewElasticPool(elasticPool1Name, ElasticPoolEditions.Standard)
                    .WithNewElasticPool(elasticPool2Name, ElasticPoolEditions.Premium, database1InEPName, database2InEPName)
                    .WithNewElasticPool(elasticPool3Name, ElasticPoolEditions.Standard)
                    .WithNewFirewallRule(START_IPADDRESS, END_IPADDRESS, SQL_FIREWALLRULE_NAME)
                    .WithNewFirewallRule(START_IPADDRESS, END_IPADDRESS)
                    .WithNewFirewallRule(START_IPADDRESS)
                    .Apply();

                ValidateMultiCreation(sqlServerManager, database2Name, database1InEPName, database2InEPName,
                    elasticPool1Name, elasticPool2Name, elasticPool3Name, sqlServer, true);

                sqlServer.Refresh();
                Assert.Equal(sqlServer.ElasticPools.List().Count(), 0);

                // List
                var sqlServers = sqlServerManager.SqlServers.ListByGroup(RG_NAME);
                var found = false;
                foreach (var server in sqlServers)
                {
                    if (StringComparer.OrdinalIgnoreCase.Equals(server.Name, SQL_SERVER_NAME))
                    {
                        found = true;
                    }
                }

                Assert.True(found);
                // Get
                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                Assert.NotNull(sqlServer);

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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
            ValidateSqlServer(sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME));
            ValidateSqlDatabase(sqlServer.Databases.Get(SQL_DATABASE_NAME), SQL_DATABASE_NAME);
            ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SQL_FIREWALLRULE_NAME), SQL_FIREWALLRULE_NAME);

            var firewalls = sqlServer.FirewallRules.List();
            Assert.Equal(3, firewalls.Count());

            var startIpAddress = 0;
            var endIpAddress = 0;

            foreach (ISqlFirewallRule firewall in firewalls)
            {
                if (!StringComparer.OrdinalIgnoreCase.Equals(firewall.Name, SQL_FIREWALLRULE_NAME))
                {
                    Assert.Equal(firewall.StartIpAddress, START_IPADDRESS);
                    if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIpAddress, START_IPADDRESS))
                    {
                        startIpAddress++;
                    }
                    else if (StringComparer.OrdinalIgnoreCase.Equals(firewall.EndIpAddress, END_IPADDRESS))
                    {
                        endIpAddress++;
                    }
                }
            }

            Assert.Equal(startIpAddress, 1);
            Assert.Equal(endIpAddress, 1);

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
                sqlServer.Databases.Delete(SQL_DATABASE_NAME);

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
                        .WithoutDatabase(SQL_DATABASE_NAME)
                        .WithoutDatabase(database2InEPName)
                        .WithoutFirewallRule(SQL_FIREWALLRULE_NAME)
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
                    .Define(SQL_DATABASE_NAME)
                    .WithoutElasticPool()
                    .WithoutSourceDatabaseId()
                    .WithCollation(COLLATION)
                    .WithEdition(DatabaseEditions.Standard)
                    .Create();

                ValidateSqlDatabase(sqlDatabase, SQL_DATABASE_NAME);

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
                Assert.Equal(transparentDataEncryption.SqlServerName, SQL_SERVER_NAME);
                Assert.Equal(transparentDataEncryption.DatabaseName, SQL_DATABASE_NAME);
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

                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                ValidateSqlServer(sqlServer);

                // Create another database with above created database as source database.
                var sqlElasticPoolCreatable = sqlServer.ElasticPools
                    .Define(SQL_ELASTIC_POOL_NAME)
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
                ValidateSqlDatabase(sqlServer.Databases.Get(SQL_DATABASE_NAME), SQL_DATABASE_NAME);

                // List
                ValidateListSqlDatabase(sqlServer.Databases.List());

                // Delete
                sqlServer.Databases.Delete(SQL_DATABASE_NAME);
                ValidateSqlDatabaseNotFound(sqlServerManager, SQL_DATABASE_NAME);

                // Add another database to the server
                sqlDatabase = sqlServer.Databases
                        .Define("newDatabase")
                        .WithoutElasticPool()
                        .WithoutSourceDatabaseId()
                        .WithCollation(COLLATION)
                        .WithEdition(DatabaseEditions.Standard)
                        .Create();
                sqlServer.Databases.Delete(sqlDatabase.Name);

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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
                var anotherSqlServerName = SQL_SERVER_NAME + "another";
                var sqlServer1 = CreateSqlServer(sqlServerManager);
                var sqlServer2 = CreateSqlServer(sqlServerManager, anotherSqlServerName);

                var databaseInServer1 = sqlServer1.Databases
                    .Define(SQL_DATABASE_NAME)
                    .WithoutElasticPool()
                    .WithoutSourceDatabaseId()
                    .WithCollation(COLLATION)
                    .WithEdition(DatabaseEditions.Standard)
                    .Create();

                ValidateSqlDatabase(databaseInServer1, SQL_DATABASE_NAME);
                var databaseInServer2 = sqlServer2.Databases
                    .Define(SQL_DATABASE_NAME)
                    .WithoutElasticPool()
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

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer2.ResourceGroupName, sqlServer2.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer2);
                sqlServerManager.SqlServers.DeleteByGroup(sqlServer1.ResourceGroupName, sqlServer1.Name);
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
                        .Define(SQL_DATABASE_NAME)
                        .WithoutElasticPool()
                        .WithoutSourceDatabaseId()
                        .WithCollation(COLLATION)
                        .WithEdition(DatabaseEditions.DataWarehouse)
                        .Create();

                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.NotNull(sqlDatabase);
                Assert.True(sqlDatabase.IsDataWarehouse);

                // Get
                var dataWarehouse = sqlServer.Databases.Get(SQL_DATABASE_NAME).CastToWarehouse();

                Assert.NotNull(dataWarehouse);
                Assert.Equal(dataWarehouse.Name, SQL_DATABASE_NAME);
                Assert.Equal(dataWarehouse.Edition, DatabaseEditions.DataWarehouse);

                // List Restore points.
                Assert.NotNull(dataWarehouse.ListRestorePoints());
                // Get usages.
                Assert.NotNull(dataWarehouse.ListUsages());

                // Pause warehouse
                dataWarehouse.PauseDataWarehouse();

                // Resume warehouse
                dataWarehouse.ResumeDataWarehouse();

                sqlServer.Databases.Delete(SQL_DATABASE_NAME);

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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
                        .Define(SQL_ELASTIC_POOL_NAME)
                        .WithEdition(ElasticPoolEditions.Standard);

                var sqlDatabase = sqlServer.Databases
                        .Define(SQL_DATABASE_NAME)
                        .WithNewElasticPool(sqlElasticPoolCreatable)
                        .WithoutSourceDatabaseId()
                        .WithCollation(COLLATION)
                        .WithEdition(DatabaseEditions.Standard)
                        .WithServiceObjective(ServiceObjectiveName.S1)
                        .Create();

                ValidateSqlDatabase(sqlDatabase, SQL_DATABASE_NAME);

                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                ValidateSqlServer(sqlServer);

                // Get Elastic pool
                var elasticPool = sqlServer.ElasticPools.Get(SQL_ELASTIC_POOL_NAME);
                ValidateSqlElasticPool(elasticPool);

                // Get
                ValidateSqlDatabaseWithElasticPool(sqlServer.Databases.Get(SQL_DATABASE_NAME), SQL_DATABASE_NAME);

                // List
                ValidateListSqlDatabase(sqlServer.Databases.List());

                // Remove database from elastic pools.
                sqlDatabase.Update()
                        .WithoutElasticPool()
                        .WithEdition(DatabaseEditions.Standard)
                        .WithServiceObjective(ServiceObjectiveName.S3)
                    .Apply();
                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.Null(sqlDatabase.ElasticPoolName);

                // Update edition of the SQL database
                sqlDatabase.Update()
                        .WithEdition(DatabaseEditions.Premium)
                        .WithServiceObjective(ServiceObjectiveName.P1)
                        .Apply();
                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.Equal(sqlDatabase.Edition, DatabaseEditions.Premium);
                Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P1);

                // Update just the service level objective for database.
                sqlDatabase.Update().WithServiceObjective(ServiceObjectiveName.P2).Apply();
                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.Equal(sqlDatabase.ServiceLevelObjective, ServiceObjectiveName.P2);
                Assert.Equal(sqlDatabase.RequestedServiceObjectiveName, ServiceObjectiveName.P2);

                // Update max size bytes of the database.
                sqlDatabase.Update()
                        .WithMaxSizeBytes(268435456000L)
                        .Apply();

                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.Equal(sqlDatabase.MaxSizeBytes, 268435456000L);

                // Put the database back in elastic pool.
                sqlDatabase.Update()
                        .WithExistingElasticPool(SQL_ELASTIC_POOL_NAME)
                        .Apply();

                sqlDatabase = sqlServer.Databases.Get(SQL_DATABASE_NAME);
                Assert.Equal(sqlDatabase.ElasticPoolName, SQL_ELASTIC_POOL_NAME);

                // List Activity in elastic pool
                Assert.NotNull(elasticPool.ListActivities());

                // List Database activity in elastic pool.
                Assert.NotNull(elasticPool.ListDatabaseActivities());

                // List databases in elastic pool.
                var databasesInElasticPool = elasticPool.ListDatabases();
                Assert.NotNull(databasesInElasticPool);
                Assert.Equal(databasesInElasticPool.Count(), 1);

                // Get a particular database in elastic pool.
                var databaseInElasticPool = elasticPool.GetDatabase(SQL_DATABASE_NAME);
                ValidateSqlDatabase(databaseInElasticPool, SQL_DATABASE_NAME);

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
                sqlServer.Databases.Delete(SQL_DATABASE_NAME);
                ValidateSqlDatabaseNotFound(sqlServerManager, SQL_DATABASE_NAME);

                var sqlElasticPool = sqlServer.ElasticPools.Get(SQL_ELASTIC_POOL_NAME);

                // Add another database to the server and pool.
                sqlDatabase = sqlServer.Databases
                        .Define("newDatabase")
                        .WithExistingElasticPool(sqlElasticPool)
                        .WithoutSourceDatabaseId()
                        .WithCollation(COLLATION)
                        .WithEdition(DatabaseEditions.Standard)
                        .Create();
                sqlServer.Databases.Delete(sqlDatabase.Name);
                ValidateSqlDatabaseNotFound(sqlServerManager, "newDatabase");

                sqlServer.ElasticPools.Delete(SQL_ELASTIC_POOL_NAME);
                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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

                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                ValidateSqlServer(sqlServer);

                var sqlElasticPool = sqlServer.ElasticPools
                        .Define(SQL_ELASTIC_POOL_NAME)
                        .WithEdition(ElasticPoolEditions.Standard)
                        .Create();
                ValidateSqlElasticPool(sqlElasticPool);
                Assert.Equal(sqlElasticPool.ListDatabases().Count(), 0);

                sqlElasticPool = sqlElasticPool.Update()
                        .WithDtu(100)
                        .WithDatabaseDtuMax(20)
                        .WithDatabaseDtuMin(10)
                        .WithStorageCapacity(102400)
                        .WithNewDatabase(SQL_DATABASE_NAME)
                        .Apply();

                ValidateSqlElasticPool(sqlElasticPool);
                Assert.Equal(sqlElasticPool.ListDatabases().Count(), 1);

                // Get
                ValidateSqlElasticPool(sqlServer.ElasticPools.Get(SQL_ELASTIC_POOL_NAME));

                // List
                ValidateListSqlElasticPool(sqlServer.ElasticPools.List());

                // Delete
                sqlServer.Databases.Delete(SQL_DATABASE_NAME);
                sqlServer.ElasticPools.Delete(SQL_ELASTIC_POOL_NAME);
                ValidateSqlElasticPoolNotFound(sqlServer, SQL_ELASTIC_POOL_NAME);

                // Add another database to the server
                sqlElasticPool = sqlServer.ElasticPools
                        .Define("newElasticPool")
                        .WithEdition(ElasticPoolEditions.Standard)
                        .Create();

                sqlServer.ElasticPools.Delete(sqlElasticPool.Name);
                ValidateSqlElasticPoolNotFound(sqlServer, "newElasticPool");

                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
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

                sqlServer = sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME);
                ValidateSqlServer(sqlServer);

                var sqlFirewallRule = sqlServer.FirewallRules
                        .Define(SQL_FIREWALLRULE_NAME)
                        .WithIpAddressRange(START_IPADDRESS, END_IPADDRESS)
                        .Create();

                ValidateSqlFirewallRule(sqlFirewallRule, SQL_FIREWALLRULE_NAME);
                ValidateSqlFirewallRule(sqlServer.FirewallRules.Get(SQL_FIREWALLRULE_NAME), SQL_FIREWALLRULE_NAME);

                var secondFirewallRuleName = "secondFireWallRule";
                var secondFirewallRule = sqlServer.FirewallRules
                        .Define(secondFirewallRuleName)
                        .WithIpAddress(START_IPADDRESS)
                        .Create();

                secondFirewallRule = sqlServer.FirewallRules.Get(secondFirewallRuleName);

                Assert.NotNull(secondFirewallRule);
                Assert.Equal(START_IPADDRESS, secondFirewallRule.EndIpAddress);

                secondFirewallRule = secondFirewallRule.Update().WithEndIpAddress(END_IPADDRESS).Apply();

                ValidateSqlFirewallRule(secondFirewallRule, secondFirewallRuleName);
                sqlServer.FirewallRules.Delete(secondFirewallRuleName);
                AssertIfFound(() => sqlServer.FirewallRules.Get(secondFirewallRuleName));

                // Get
                sqlFirewallRule = sqlServer.FirewallRules.Get(SQL_FIREWALLRULE_NAME);
                ValidateSqlFirewallRule(sqlFirewallRule, SQL_FIREWALLRULE_NAME);

                // Update
                // Making start and end IP address same.
                sqlFirewallRule.Update().WithEndIpAddress(START_IPADDRESS).Apply();
                sqlFirewallRule = sqlServer.FirewallRules.Get(SQL_FIREWALLRULE_NAME);
                Assert.Equal(sqlFirewallRule.EndIpAddress, START_IPADDRESS);

                // List
                ValidateListSqlFirewallRule(sqlServer.FirewallRules.List());

                // Delete
                sqlServer.FirewallRules.Delete(sqlFirewallRule.Name);
                ValidateSqlFirewallRuleNotFound(sqlServerManager);

                // Delete server
                sqlServerManager.SqlServers.DeleteByGroup(sqlServer.ResourceGroupName, sqlServer.Name);
                ValidateSqlServerNotFound(sqlServerManager, sqlServer);
                DeleteResourceGroup(sqlServer.ResourceGroupName);
            }
        }

        private static void ValidateSqlFirewallRuleNotFound(ISqlManager sqlServerManager)
        {
            AssertIfFound(() => sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME).FirewallRules.Get(SQL_FIREWALLRULE_NAME));
        }

        private static void ValidateSqlElasticPoolNotFound(ISqlServer sqlServer, string elasticPoolName)
        {
            AssertIfFound(() => sqlServer.ElasticPools.Get(elasticPoolName));
        }

        private static void ValidateSqlDatabaseNotFound(ISqlManager sqlServerManager, String newDatabase)
        {
            AssertIfFound(() => sqlServerManager.SqlServers.GetByGroup(RG_NAME, SQL_SERVER_NAME).Databases.Get(newDatabase));
        }

        private static void ValidateSqlServerNotFound(ISqlManager sqlServerManager, ISqlServer sqlServer)
        {
            AssertIfFound(() => sqlServerManager.SqlServers.GetById("/subscriptions/9657ab5d-4a4a-4fd2-ae7a-4cd9fbd030ef/resourceGroups/netsqlserver284556/providers/Microsoft.Sql/servers/netsqlserver284556"));
        }

        private static void AssertIfFound(Action action)
        {
            try
            {
                action();
                Assert.True(false);
            }
            catch (AggregateException ex) when ((ex.InnerExceptions[0] as CloudException).Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return;
            }
            catch (CloudException ex) when (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return;
            }

            Assert.True(false);
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager)
        {
            return CreateSqlServer(sqlServerManager, SQL_SERVER_NAME);
        }

        private static ISqlServer CreateSqlServer(ISqlManager sqlServerManager, String SQL_SERVER_NAME)
        {
            return sqlServerManager.SqlServers
                    .Define(SQL_SERVER_NAME)
                    .WithRegion(Region.US_CENTRAL)
                    .WithNewResourceGroup(RG_NAME)
                    .WithAdministratorLogin("userName")
                    .WithAdministratorPassword("loepopfuejk~13@@")
                    .Create();
        }

        private static void ValidateListSqlFirewallRule(IList<ISqlFirewallRule> sqlFirewallRules)
        {
            Assert.True(sqlFirewallRules.Any(firewallRule => StringComparer.OrdinalIgnoreCase.Equals(firewallRule.Name, SQL_FIREWALLRULE_NAME)));
        }

        private static void ValidateSqlFirewallRule(ISqlFirewallRule sqlFirewallRule, string firewallName)
        {
            Assert.NotNull(sqlFirewallRule);
            Assert.Equal(firewallName, sqlFirewallRule.Name);
            Assert.Equal(SQL_SERVER_NAME, sqlFirewallRule.SqlServerName);
            Assert.Equal(START_IPADDRESS, sqlFirewallRule.StartIpAddress);
            Assert.Equal(END_IPADDRESS, sqlFirewallRule.EndIpAddress);
            Assert.Equal(RG_NAME, sqlFirewallRule.ResourceGroupName);
            Assert.Equal(SQL_SERVER_NAME, sqlFirewallRule.SqlServerName);
            Assert.Equal(Region.US_CENTRAL, sqlFirewallRule.Region);
        }

        private static void ValidateListSqlElasticPool(IList<ISqlElasticPool> sqlElasticPools)
        {
            Assert.True(sqlElasticPools.Any(elasticPool => StringComparer.OrdinalIgnoreCase.Equals(elasticPool.Name, SQL_ELASTIC_POOL_NAME)));
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool)
        {
            ValidateSqlElasticPool(sqlElasticPool, SQL_ELASTIC_POOL_NAME);
        }

        private static void ValidateSqlElasticPool(ISqlElasticPool sqlElasticPool, string elasticPoolName)
        {
            Assert.NotNull(sqlElasticPool);
            Assert.Equal(RG_NAME, sqlElasticPool.ResourceGroupName);
            Assert.Equal(elasticPoolName, sqlElasticPool.Name);
            Assert.Equal(SQL_SERVER_NAME, sqlElasticPool.SqlServerName);
            Assert.Equal(ElasticPoolEditions.Standard, sqlElasticPool.Edition);
            Assert.NotNull(sqlElasticPool.CreationDate);
            Assert.NotEqual(0, sqlElasticPool.DatabaseDtuMax);
            Assert.NotEqual(0, sqlElasticPool.Dtu);
        }

        private static void ValidateListSqlDatabase(IList<ISqlDatabase> sqlDatabases)
        {
            Assert.True(sqlDatabases.Any(database => StringComparer.OrdinalIgnoreCase.Equals(database.Name, SQL_DATABASE_NAME)));
        }

        private static void ValidateSqlServer(ISqlServer sqlServer)
        {
            Assert.NotNull(sqlServer);
            Assert.Equal(RG_NAME, sqlServer.ResourceGroupName);
            Assert.NotNull(sqlServer.FullyQualifiedDomainName);
            Assert.Equal(ServerVersion.OneTwoFullStopZero, sqlServer.Version);
            Assert.Equal("userName", sqlServer.AdministratorLogin);
        }

        private static void ValidateSqlDatabase(ISqlDatabase sqlDatabase, string databaseName)
        {
            Assert.NotNull(sqlDatabase);
            Assert.Equal(sqlDatabase.Name, databaseName);
            Assert.Equal(SQL_SERVER_NAME, sqlDatabase.SqlServerName);
            Assert.Equal(sqlDatabase.Collation, COLLATION);
            Assert.Equal(sqlDatabase.Edition, DatabaseEditions.Standard);
        }

        private static void ValidateSqlDatabaseWithElasticPool(ISqlDatabase sqlDatabase, string databaseName)
        {
            ValidateSqlDatabase(sqlDatabase, databaseName);
            Assert.Equal(SQL_ELASTIC_POOL_NAME, sqlDatabase.ElasticPoolName);
        }
    }
}