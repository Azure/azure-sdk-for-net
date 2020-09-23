// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
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
        private string sqlThroughputType;
        private int sampleThroughput;
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
            sqlThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings";
            sampleThroughput = 700;
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
                {
                    InitializeClients();
                    GenerateSampleValues();
                    await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                        CosmosDBTestUtilities.Location,
                        this.resourceGroupName);
                    await PrepareDatabaseAccount();
                    setupRun = true;
                }
                else if (setupRun)
                {
                    initNewRecord();
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
            SqlDatabaseGetResults sqlDatabaseGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    new SqlDatabaseCreateUpdateParameters(new SqlDatabaseResource(databaseName), new CreateUpdateOptions())));
            Assert.NotNull(sqlDatabaseGetResults);
            Assert.AreEqual(databaseName, sqlDatabaseGetResults.Name);
            SqlDatabaseGetResults sqlDatabaseGetResults2 = await CosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlDatabaseGetResults2);
            Assert.AreEqual(databaseName, sqlDatabaseGetResults2.Name);
            VerifySqlDatabases(sqlDatabaseGetResults, sqlDatabaseGetResults2);

            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 =
                new SqlDatabaseCreateUpdateParameters(
                    id: default(string),
                    name: default(string),
                    type: default(string),
                    location: location,
                    tags: tags,
                    resource: new SqlDatabaseResource(databaseName),
                    options: new CreateUpdateOptions { Throughput = sampleThroughput });
            SqlDatabaseGetResults sqlDatabaseGetResults3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters2));
            Assert.NotNull(sqlDatabaseGetResults3);
            Assert.AreEqual(databaseName, sqlDatabaseGetResults3.Name);
            ThroughputSettingsGetResults throughputSettingsGetResults =
                await CosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(sqlThroughputType, throughputSettingsGetResults.Type);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(2)]
        public async Task SqlDatabaseListTest()
        {
            List<SqlDatabaseGetResults> sqlDatabases = await CosmosDBManagementClient.SqlResources.ListSqlDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.NotNull(sqlDatabases);
            Assert.AreEqual(1, sqlDatabases.Count);
            SqlDatabaseGetResults sqlDatabaseGetResults = await CosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlDatabaseGetResults);
            Assert.AreEqual(sqlDatabaseGetResults.Name, sqlDatabases[0].Name);
            Assert.AreEqual(sqlDatabaseGetResults, sqlDatabases[0]);
        }

        /*[TestCase, Order(2)]
        public async Task SqlDatabaseThroughputUpdateTest()
        {

        }

        [TestCase, Order(3)]
        public async Task SqlDatabaseMigrateToAutoscaleTest()
        {

        }

        [TestCase, Order(4)]
        public async Task SqlDatabaseMigrateToManualThroughputTest()
        {

        }*/

        [TestCase, Order(2)]
        public async Task SqlContainerCreateAndUpdateTest()
        {
            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters(
                resource: new SqlContainerResource(containerName)
                {
                    PartitionKey = new ContainerPartitionKey(new List<string> { "/address/zipCode" }, null, null)
                    {
                        Kind = new PartitionKind("Hash")
                    },
                    IndexingPolicy = new IndexingPolicy(true, IndexingMode.Consistent,
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
                                },
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
                options: new CreateUpdateOptions
                {
                    Throughput = sampleThroughput
                }
            );
            SqlContainerGetResults sqlContainerGetResults1 = await WaitForCompletionAsync(await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters));
            Assert.NotNull(sqlContainerGetResults1);
            SqlContainerGetResults sqlContainerGetResults2 = await CosmosDBManagementClient.SqlResources.GetSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            VerifySqlContainers(sqlContainerGetResults1, sqlContainerGetResults2);

            // TODO: test update
        }

        [TestCase, Order(3)]
        public async Task SqlContainerListTest()
        {
            List<SqlContainerGetResults> sqlContainers = await CosmosDBManagementClient.SqlResources.ListSqlContainersAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(sqlContainers);
            Assert.AreEqual(1, sqlContainers.Count);
            SqlContainerGetResults sqlContainerGetResults = await CosmosDBManagementClient.SqlResources.GetSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlContainerGetResults);
            VerifySqlContainers(sqlContainerGetResults, sqlContainers[0]);
        }

        // TODO: test throughout update, migrate to autoscale and migrate to manual throughput

        [TestCase, Order(2)]
        public async Task SqlStoredProcedureCreateAndUpdateTest()
        {
            SqlStoredProcedureCreateUpdateParameters sqlStoredProcedureCreateUpdateParameters = new SqlStoredProcedureCreateUpdateParameters(
                new SqlStoredProcedureResource(storedProcedureName)
                {
                    Body = "function () { var context = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Hello, World');" +
                            "}"
                },
                new CreateUpdateOptions()
            );
            SqlStoredProcedureGetResults sqlStoredProcedureGetResults = await WaitForCompletionAsync(await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters));
            Assert.NotNull(sqlStoredProcedureGetResults);
            Assert.AreEqual(sqlStoredProcedureGetResults.Resource.Body, sqlStoredProcedureGetResults.Resource.Body);

            // TODO: test update
        }

        [TestCase, Order(3)]
        public async Task SqlStoredProcedureListTest()
        {
            List<SqlStoredProcedureGetResults> sqlStoredProcedures = await CosmosDBManagementClient.SqlResources.ListSqlStoredProceduresAsync(resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlStoredProcedures);
            Assert.AreEqual(1, sqlStoredProcedures.Count);
            SqlStoredProcedureGetResults sqlStoredProcedureGetResults = await CosmosDBManagementClient.SqlResources.GetSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName);
            Assert.NotNull(sqlStoredProcedureGetResults);
            //VerifySqlStoredProcedures(sqlStoredProcedureGetResults, sqlStoredProcedures[0]);
        }

        [TestCase, Order(2)]
        public async Task SqlUserDefinedFunctionCreateAndUpdateTest()
        {
            SqlUserDefinedFunctionCreateUpdateParameters sqlUserDefinedFunctionCreateUpdateParameters = new SqlUserDefinedFunctionCreateUpdateParameters(
                resource: new SqlUserDefinedFunctionResource(userDefinedFunctionName)
                {
                    Body = "function () { var context = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Hello, World');" +
                            "}"
                },
                options: new CreateUpdateOptions()
            );

            SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlUserDefinedFunctionAsync(
                    resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters));
            Assert.NotNull(sqlUserDefinedFunctionGetResults);
            Assert.AreEqual(sqlUserDefinedFunctionGetResults.Resource.Body, sqlUserDefinedFunctionGetResults.Resource.Body);

            // TODO: test update
        }

        [TestCase, Order(3)]
        public async Task SqlUserDefinedFunctionListTest()
        {
            List<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = await CosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlUserDefinedFunctions);
            Assert.AreEqual(1, sqlUserDefinedFunctions.Count);
            SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = await CosmosDBManagementClient.SqlResources.GetSqlUserDefinedFunctionAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName);
            //VerifySqlUserDefinedFunctions(sqlUserDefinedFunctionGetResults, sqlUserDefinedFunctions[0]);
        }

        [TestCase, Order(2)]
        public async Task SqlTriggerCreateAndUpdateTest()
        {
            SqlTriggerCreateUpdateParameters sqlTriggerCreateUpdateParameters = new SqlTriggerCreateUpdateParameters(
                resource: new SqlTriggerResource(triggerName)
                {
                    TriggerOperation = "All",
                    TriggerType = "Pre",
                    Body = "function () { var context = getContext(); " +
                            "var response = context.getResponse();" +
                            "response.setBody('Hello, World');" +
                            "}"
                },
                options: new CreateUpdateOptions()
            );

            SqlTriggerGetResults sqlTriggerGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartCreateUpdateSqlTriggerAsync(
                    resourceGroupName,
                    databaseAccountName,
                    databaseName,
                    containerName,
                    triggerName,
                    sqlTriggerCreateUpdateParameters));
            Assert.NotNull(sqlTriggerGetResults);
            Assert.AreEqual(sqlTriggerGetResults.Resource.TriggerType, sqlTriggerCreateUpdateParameters.Resource.TriggerType);
            Assert.AreEqual(sqlTriggerGetResults.Resource.TriggerOperation, sqlTriggerCreateUpdateParameters.Resource.TriggerOperation);
            Assert.AreEqual(sqlTriggerGetResults.Resource.Body, sqlTriggerCreateUpdateParameters.Resource.Body);

            // TODO: test update
        }

        [TestCase, Order(3)]
        public async Task SqlTriggerListTest()
        {
            List<SqlTriggerGetResults> sqlTriggers = await CosmosDBManagementClient.SqlResources.ListSqlTriggersAsync(resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlTriggers);
            Assert.AreEqual(1, sqlTriggers.Count);
            SqlTriggerGetResults sqlTriggerGetResults = await CosmosDBManagementClient.SqlResources.GetSqlTriggerAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName);
            //VerifySqlTriggers(sqlTriggers, sqlTriggerGetResults[0]);
        }

        [TestCase, Order(4)]
        public async Task SqlDeleteTests()
        {
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlTriggerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, triggerName));
            List<SqlTriggerGetResults> sqlTriggers = await CosmosDBManagementClient.SqlResources.ListSqlTriggersAsync(resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlTriggers);
            Assert.AreEqual(0, sqlTriggers.Count);
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlUserDefinedFunctionAsync(resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName));
            List<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = await CosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsAsync(
                resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlUserDefinedFunctions);
            Assert.AreEqual(0, sqlUserDefinedFunctions.Count);
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName));
            List<SqlStoredProcedureGetResults> sqlStoredProcedures = await CosmosDBManagementClient.SqlResources.ListSqlStoredProceduresAsync(resourceGroupName, databaseAccountName, databaseName, containerName).ToEnumerableAsync();
            Assert.NotNull(sqlStoredProcedures);
            Assert.AreEqual(0, sqlStoredProcedures.Count);
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName));
            List<SqlContainerGetResults> sqlContainers = await CosmosDBManagementClient.SqlResources.ListSqlContainersAsync(resourceGroupName, databaseAccountName, databaseName).ToEnumerableAsync();
            Assert.NotNull(sqlContainers);
            Assert.AreEqual(0, sqlContainers.Count);
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.SqlResources.StartDeleteSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName));
            List<SqlDatabaseGetResults> sqlDatabases = await CosmosDBManagementClient.SqlResources.ListSqlDatabasesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
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
            DatabaseAccountGetResults databaseAccount = await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));
            Assert.AreEqual(databaseAccount.Name, databaseAccountName);
            Response isDatabaseNameExists = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(200, isDatabaseNameExists.Status);
        }

        private void VerifySqlContainers(SqlContainerGetResults expectedValue, SqlContainerGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.IndexingPolicy.IndexingMode, actualValue.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Kind, actualValue.Resource.PartitionKey.Kind);
            Assert.AreEqual(expectedValue.Resource.PartitionKey.Paths, actualValue.Resource.PartitionKey.Paths);
            Assert.AreEqual(expectedValue.Resource.DefaultTtl, actualValue.Resource.DefaultTtl);
        }

        private void VerifySqlDatabases(SqlDatabaseGetResults expectedValue, SqlDatabaseGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
            Assert.AreEqual(expectedValue.Resource.Colls, actualValue.Resource.Colls);
            Assert.AreEqual(expectedValue.Resource.Users, actualValue.Resource.Users);
        }
    }
}
