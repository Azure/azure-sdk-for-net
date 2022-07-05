// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit;
using NUnit.Framework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class SqlResourcesOperationsTests : CosmosDBManagementClientBase
    {
        private string location;
        private string resourceGroupName;
        private string databaseAccountName;
        private string databaseName;
        private string containerName;
        private string storedProcedureName;
        private string triggerName;
        private string userDefinedFunctionName;
        private string sqlContainersThroughputType;
        private string sqlDatabasesThroughputType;
        private int sampleThroughput1;
        private int sampleThroughput2;
        private int defaultThroughput;
        private int defaultMaxThroughput;
        private bool setupRun = false;
        private Dictionary<string, string> tags = new Dictionary<string, string>
        {
            {"key3","value3"},
            {"key4","value4"}
        };
        public SqlResourcesOperationsTests(bool isAsync) : base(isAsync)
        {
        }
        private void GenerateSampleValues()
        {
            resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
            databaseAccountName = Recording.GenerateAssetName("cosmosdb");
            databaseName = Recording.GenerateAssetName("databaseName");
            containerName = Recording.GenerateAssetName("containerName");
            storedProcedureName = Recording.GenerateAssetName("storedProcedureName");
            triggerName = Recording.GenerateAssetName("triggerName");
            userDefinedFunctionName = Recording.GenerateAssetName("userDefinedFunctionName");
            location = "EAST US";
            sqlContainersThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/throughputSettings";
            sqlDatabasesThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings";
            sampleThroughput1 = 700;
            sampleThroughput2 = 1000;
            defaultThroughput = 400;
            defaultMaxThroughput = 4000;
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
                {
                    await InitializeClients();
                    GenerateSampleValues();
                    await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                        CosmosDBTestUtilities.Location,
                        this.resourceGroupName);
                    await PrepareDatabaseAccount();
                    setupRun = true;
                }
                else if (setupRun)
                {
                    await initNewRecord();
                }
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task SqlDatabaseCreateAndUpdateTest()
        {
            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters1 = new SqlDatabaseCreateUpdateParameters(
                new CosmosDBSqlDatabaseResource(databaseName), new CosmosDBCreateUpdateConfig(sampleThroughput1, new AutoscaleSettings()));
            CosmosDBSqlDatabaseResource sqlDatabase1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(
                    resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters1));
            Assert.NotNull(sqlDatabase1);
            CosmosDBSqlDatabaseResource sqlDatabase2 = await CosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(
                resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlDatabase2);
            VerifySqlDatabases(sqlDatabase1, sqlDatabase2);
            ThroughputSettingsData throughputSettings1 =
                await CosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(throughputSettings1);
            Assert.NotNull(throughputSettings1.Name);
            Assert.AreEqual(sqlDatabasesThroughputType, throughputSettings1.Type);
            Assert.AreEqual(sampleThroughput1, throughputSettings1.Resource.Throughput);

            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 =
                new SqlDatabaseCreateUpdateParameters(
                    id: default(string),
                    name: default(string),
                    type: default(string),
                    location: location,
                    tags: tags,
                    resource: new CosmosDBSqlDatabaseResource(databaseName),
                    options: new CosmosDBCreateUpdateConfig { Throughput = sampleThroughput2 });
            CosmosDBSqlDatabaseResource sqlDatabase3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(
                    resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters2));
            Assert.NotNull(sqlDatabase3);
            CosmosDBSqlDatabaseResource sqlDatabase4 = await CosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(
                resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlDatabase4);
            VerifySqlDatabases(sqlDatabase3, sqlDatabase4);
            ThroughputSettingsData throughputSettings2 =
                await CosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(sqlDatabasesThroughputType, throughputSettings2.Type);
            Assert.AreEqual(sampleThroughput2, throughputSettings2.Resource.Throughput);
        }

        [TestCase, Order(2)]
        public async Task SqlDatabaseListTest()
        {
            List<CosmosDBSqlDatabaseResource> sqlDatabases = await CosmosDBManagementClient.SqlResources.ListSqlDatabasesAsync(
                resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(sqlDatabases);
            Assert.AreEqual(1, sqlDatabases.Count);
            CosmosDBSqlDatabaseResource sqlDatabase = await CosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(
                resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlDatabase);
            Assert.AreEqual(sqlDatabase.Name, sqlDatabases[0].Name);
            VerifySqlDatabases(sqlDatabase, sqlDatabases[0]);
        }

        [TestCase, Order(2)]
        public async Task SqlDatabaseThroughputUpdateTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartUpdateSqlDatabaseThroughputAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput2, null, null, null))));
            Assert.NotNull(throughputSettings);
            Assert.AreEqual(sampleThroughput2, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task SqlDatabaseMigrateToAutoscaleTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartMigrateSqlDatabaseToAutoscaleAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task SqlDatabaseMigrateToManualThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartMigrateSqlDatabaseToManualThroughputAsync(resourceGroupName, databaseAccountName, databaseName));
            Assert.NotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(2)]
        public async Task SqlContainerCreateAndUpdateTest()
        {
            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters(
                resource: new CosmosDBSqlContainerResource(containerName)
                {
                    PartitionKeyResource = new ContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null)
                    {
                        Kind = new PartitionKind("Hash")
                    },
                    IndexingPolicyResource = new IndexingPolicy(
                        true,
                        IndexingMode.Consistent,
                        new List<IncludedPath>
                        {
                            new IncludedPath { Path = "/*"}
                        },
                        new List<ExcludedPath>
                        {
                            new ExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                        new List<IList<CompositePath>>
                        {
                            new List<CompositePath>
                            {
                                new CompositePath { Path = "/orderByPath1", Order = CompositePathSortOrder.Ascending },
                                new CompositePath { Path = "/orderByPath2", Order = CompositePathSortOrder.Descending }
                            }
                        },
                        new List<SpatialSpec>
                        {
                            new SpatialSpec
                            (
                                    "/*",
                                    new List<SpatialType>
                                    {
                                        new SpatialType("Point")
                                    }
                            ),
                        }
                    )
                },
                options: new CosmosDBCreateUpdateConfig
                {
                    Throughput = sampleThroughput1
                }
            );
            CosmosDBSqlContainerResource sqlContainer1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlContainerAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters));
            Assert.NotNull(sqlContainer1);
            CosmosDBSqlContainerResource sqlContainer2 = await CosmosDBManagementClient.SqlResources.GetSqlContainerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlContainer2);
            VerifySqlContainers(sqlContainer1, sqlContainer2);
            ThroughputSettingsData throughputSettings1 =
                await CosmosDBManagementClient.SqlResources.GetSqlContainerThroughputAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(throughputSettings1);
            Assert.NotNull(throughputSettings1.Name);
            Assert.AreEqual(sqlContainersThroughputType, throughputSettings1.Type);
            Assert.AreEqual(sampleThroughput1, throughputSettings1.Resource.Throughput);

            sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters(
                resource: new CosmosDBSqlContainerResource(containerName)
                {
                    PartitionKeyResource = new ContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null)
                    {
                        Kind = new PartitionKind("Hash")
                    },
                    IndexingPolicyResource = new IndexingPolicy(
                        true,
                        IndexingMode.Consistent,
                        new List<IncludedPath>
                        {
                            new IncludedPath { Path = "/*"}
                        },
                        new List<ExcludedPath>
                        {
                            new ExcludedPath { Path = "/pathToNotIndex/*"}
                        },
                        new List<IList<CompositePath>>
                        {
                            new List<CompositePath>
                            {
                                new CompositePath { Path = "/orderByPath3", Order = CompositePathSortOrder.Ascending },
                                new CompositePath { Path = "/orderByPath4", Order = CompositePathSortOrder.Descending }
                            }
                        },
                        new List<SpatialSpec>
                        {
                            new SpatialSpec
                            (
                                    "/*",
                                    new List<SpatialType>
                                    {
                                        new SpatialType("Point")
                                    }
                            ),
                        }
                    )
                },
                options: new CosmosDBCreateUpdateConfig
                {
                    Throughput = sampleThroughput2
                }
            );
            CosmosDBSqlContainerResource sqlContainer3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlContainerAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters));
            Assert.NotNull(sqlContainer3);
            CosmosDBSqlContainerResource sqlContainer4 = await CosmosDBManagementClient.SqlResources.GetSqlContainerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlContainer4);
            VerifySqlContainers(sqlContainer3, sqlContainer4);
            ThroughputSettingsData throughputSettings2 =
                await CosmosDBManagementClient.SqlResources.GetSqlContainerThroughputAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(throughputSettings2);
            Assert.NotNull(throughputSettings2.Name);
            Assert.AreEqual(sqlContainersThroughputType, throughputSettings2.Type);
            Assert.AreEqual(sampleThroughput2, throughputSettings2.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task SqlContainerListTest()
        {
            List<CosmosDBSqlContainerResource> sqlContainers = await CosmosDBManagementClient.SqlResources.ListSqlContainersAsync(
                resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(sqlContainers);
            Assert.AreEqual(1, sqlContainers.Count);
            CosmosDBSqlContainerResource sqlContainer = await CosmosDBManagementClient.SqlResources.GetSqlContainerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlContainer);
            VerifySqlContainers(sqlContainer, sqlContainers[0]);
        }

        [TestCase, Order(3)]
        public async Task SqlContainerUpdateThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartUpdateSqlContainerThroughputAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(sampleThroughput2, null, null, null))));
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Name);
            Assert.AreEqual(sqlContainersThroughputType, throughputSettings.Type);
            Assert.AreEqual(sampleThroughput2, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task SqlContainerMigrateToAutoscaleTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartMigrateSqlContainerToAutoscaleAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName));
            Assert.NotNull(throughputSettings);
            Assert.NotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task SqlContainerMigrateToManualThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartMigrateSqlContainerToManualThroughputAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName));
            Assert.NotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task SqlStoredProcedureCreateAndUpdateTest()
        {
            SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters(
                new SqlStoredProcedureResource(storedProcedureName)
                {
                    Body = "function () { var updatetext = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('First Hello World');" +
                            "}"
                },
                new CosmosDBCreateUpdateConfig()
            );
            ;
            SqlStoredProcedureResource sqlStoredProcedure1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlStoredProcedureAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters));
            Assert.NotNull(sqlStoredProcedure1);
            SqlStoredProcedureResource sqlStoredProcedure2 = await CosmosDBManagementClient.SqlResources.GetSqlStoredProcedureAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName);
            Assert.NotNull(sqlStoredProcedure2);
            VerifySqlStoredProcedures(sqlStoredProcedure1, sqlStoredProcedure2);

            sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters(
                new SqlStoredProcedureResource(storedProcedureName)
                {
                    Body = "function () { var updatetext = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Second Hello World');" +
                            "}"
                },
                new CosmosDBCreateUpdateConfig()
            );
            SqlStoredProcedureResource sqlStoredProcedure3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlStoredProcedureAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters));
            Assert.NotNull(sqlStoredProcedure3);
            SqlStoredProcedureResource sqlStoredProcedure4 = await CosmosDBManagementClient.SqlResources.GetSqlStoredProcedureAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName);
            Assert.NotNull(sqlStoredProcedure4);
            VerifySqlStoredProcedures(sqlStoredProcedure3, sqlStoredProcedure4);
        }

        [TestCase, Order(4)]
        public async Task SqlStoredProcedureListTest()
        {
            List<SqlStoredProcedureResource> sqlStoredProcedures = await CosmosDBManagementClient.SqlResources.ListSqlStoredProceduresAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlStoredProcedures);
            Assert.AreEqual(1, sqlStoredProcedures.Count);
            SqlStoredProcedureResource sqlStoredProcedure = await CosmosDBManagementClient.SqlResources.GetSqlStoredProcedureAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName);
            Assert.NotNull(sqlStoredProcedure);
            VerifySqlStoredProcedures(sqlStoredProcedure, sqlStoredProcedures[0]);
        }

        [TestCase, Order(3)]
        public async Task SqlUserDefinedFunctionCreateAndUpdateTest()
        {
            SqlUserDefinedFunctionCreateUpdateParameters sqlUserDefinedFunctionCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters(
                resource: new SqlUserDefinedFunctionResource(userDefinedFunctionName)
                {
                    Body = "function () { var updatetext = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('First Hello World');" +
                            "}"
                },
                options: new CosmosDBCreateUpdateConfig()
            );
            SqlUserDefinedFunctionResource sqlUserDefinedFunction1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlUserDefinedFunctionAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters));
            Assert.NotNull(sqlUserDefinedFunction1);
            SqlUserDefinedFunctionResource sqlUserDefinedFunction2 = await CosmosDBManagementClient.SqlResources.GetSqlUserDefinedFunctionAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName);
            Assert.NotNull(sqlUserDefinedFunction2);
            VerifySqlUserDefinedFunctions(sqlUserDefinedFunction1, sqlUserDefinedFunction2);

            sqlUserDefinedFunctionCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters(
                resource: new SqlUserDefinedFunctionResource(userDefinedFunctionName)
                {
                    Body = "function () { var updatetext = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Second Hello World');" +
                            "}"
                },
                options: new CosmosDBCreateUpdateConfig()
            );
            SqlUserDefinedFunctionResource sqlUserDefinedFunction3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlUserDefinedFunctionAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters));
            Assert.NotNull(sqlUserDefinedFunction3);
            SqlUserDefinedFunctionResource sqlUserDefinedFunction4 = await CosmosDBManagementClient.SqlResources.GetSqlUserDefinedFunctionAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName);
            Assert.NotNull(sqlUserDefinedFunction4);
            VerifySqlUserDefinedFunctions(sqlUserDefinedFunction3, sqlUserDefinedFunction4);
        }

        [TestCase, Order(4)]
        public async Task SqlUserDefinedFunctionListTest()
        {
            List<SqlUserDefinedFunctionResource> sqlUserDefinedFunctions = await CosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlUserDefinedFunctions);
            Assert.AreEqual(1, sqlUserDefinedFunctions.Count);
            SqlUserDefinedFunctionResource sqlUserDefinedFunction = await CosmosDBManagementClient.SqlResources.GetSqlUserDefinedFunctionAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName);
            VerifySqlUserDefinedFunctions(sqlUserDefinedFunction, sqlUserDefinedFunctions[0]);
        }

        [TestCase, Order(3)]
        public async Task SqlTriggerCreateAndUpdateTest()
        {
            SqlTriggerCreateUpdateParameters sqlTriggerCreateUpdateParameters = new SqlTriggerCreateUpdateParameters(
                resource: new CosmosDBSqlTriggerResource(triggerName)
                {
                    TriggerOperation = "All",
                    TriggerType = "Pre",
                    Body = "function () { var context = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('First Hello World');" +
                            "}"
                },
                options: new CosmosDBCreateUpdateConfig()
            );
            CosmosDBSqlTriggerResource sqlTrigger1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlTriggerAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters));
            Assert.NotNull(sqlTrigger1);
            CosmosDBSqlTriggerResource sqlTrigger2 = await CosmosDBManagementClient.SqlResources.GetSqlTriggerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, triggerName);
            Assert.NotNull(sqlTrigger2);
            VerifySqlTriggers(sqlTrigger1, sqlTrigger2);

            sqlTriggerCreateUpdateParameters = new SqlTriggerCreateUpdateParameters(
                resource: new CosmosDBSqlTriggerResource(triggerName)
                {
                    TriggerOperation = "All",
                    TriggerType = "Post",
                    Body = "function () { var context = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Second Hello World');" +
                            "}"
                },
                options: new CosmosDBCreateUpdateConfig()
            );
            CosmosDBSqlTriggerResource sqlTrigger3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlTriggerAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters));
            Assert.NotNull(sqlTrigger3);
            CosmosDBSqlTriggerResource sqlTrigger4 = await CosmosDBManagementClient.SqlResources.GetSqlTriggerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, triggerName);
            Assert.NotNull(sqlTrigger4);
            VerifySqlTriggers(sqlTrigger3, sqlTrigger4);
        }

        [TestCase, Order(4)]
        public async Task SqlTriggerListTest()
        {
            List<CosmosDBSqlTriggerResource> sqlTriggers = await CosmosDBManagementClient.SqlResources.ListSqlTriggersAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlTriggers);
            Assert.AreEqual(1, sqlTriggers.Count);
            CosmosDBSqlTriggerResource sqlTrigger = await CosmosDBManagementClient.SqlResources.GetSqlTriggerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, triggerName);
            VerifySqlTriggers(sqlTrigger, sqlTriggers[0]);
        }

        [TestCase, Order(5)]
        public async Task SqlDeleteTests()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlTriggerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, triggerName));
            List<CosmosDBSqlTriggerResource> sqlTriggers = await CosmosDBManagementClient.SqlResources.ListSqlTriggersAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlTriggers);
            Assert.AreEqual(0, sqlTriggers.Count);

            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlUserDefinedFunctionAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName));
            List<SqlUserDefinedFunctionResource> sqlUserDefinedFunctions = await CosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlUserDefinedFunctions);
            Assert.AreEqual(0, sqlUserDefinedFunctions.Count);

            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlStoredProcedureAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName));
            List<SqlStoredProcedureResource> sqlStoredProcedures = await CosmosDBManagementClient.SqlResources.ListSqlStoredProceduresAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlStoredProcedures);
            Assert.AreEqual(0, sqlStoredProcedures.Count);

            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName));
            List<CosmosDBSqlContainerResource> sqlContainers = await CosmosDBManagementClient.SqlResources.ListSqlContainersAsync(
                resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(sqlContainers);
            Assert.AreEqual(0, sqlContainers.Count);

            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            List<CosmosDBSqlDatabaseResource> sqlDatabases = await CosmosDBManagementClient.SqlResources.ListSqlDatabasesAsync(
                resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(sqlDatabases);
            Assert.AreEqual(0, sqlDatabases.Count);
        }

        private async Task PrepareDatabaseAccount()
        {
            var locations = new List<Location>()
            {
                {
                    new Location(
                        id:default(string),
                        locationName: location,
                        documentEndpoint:default(string),
                        provisioningState: default(string),
                        failoverPriority: default(int?),
                        isZoneRedundant: default(bool?))
                }
            };
            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations)
            {
                Location = location,
                Kind = DatabaseAccountKind.GlobalDocumentDB,
            };
            CosmosDBAccountResource databaseAccount = await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));
            Assert.AreEqual(databaseAccount.Name, databaseAccountName);
            var isDatabaseNameExists = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(true, isDatabaseNameExists.Value);
            Assert.AreEqual(200, isDatabaseNameExists.GetRawResponse().Status);
        }

        private void VerifySqlContainers(CosmosDBSqlContainerResource expectedValue, CosmosDBSqlContainerResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IndexingMode, actualValue.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Kind, actualValue.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Paths, actualValue.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Resource.DefaultTtl, actualValue.Resource.DefaultTtl);
        }

        private void VerifySqlDatabases(CosmosDBSqlDatabaseResource expectedValue, CosmosDBSqlDatabaseResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
            Assert.AreEqual(expectedValue.Resource.Colls, actualValue.Resource.Colls);
            Assert.AreEqual(expectedValue.Resource.Users, actualValue.Resource.Users);
        }

        private void VerifySqlStoredProcedures(SqlStoredProcedureResource expectedValue, SqlStoredProcedureResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
            Assert.AreEqual(expectedValue.Resource.Body, actualValue.Resource.Body);
        }

        private void VerifySqlTriggers(CosmosDBSqlTriggerResource expectedValue, CosmosDBSqlTriggerResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
            Assert.AreEqual(expectedValue.Resource.Body, actualValue.Resource.Body);
            Assert.AreEqual(expectedValue.Resource.TriggerType, actualValue.Resource.TriggerType);
            Assert.AreEqual(expectedValue.Resource.TriggerOperation, actualValue.Resource.TriggerOperation);
        }

        private void VerifySqlUserDefinedFunctions(SqlUserDefinedFunctionResource expectedValue, SqlUserDefinedFunctionResource actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
            Assert.AreEqual(expectedValue.Resource.Body, actualValue.Resource.Body);
        }
    }
}
#endif
