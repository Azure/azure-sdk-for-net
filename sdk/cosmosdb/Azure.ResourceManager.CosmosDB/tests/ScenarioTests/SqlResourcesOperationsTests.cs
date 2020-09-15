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
    public class SqlResourcesOperationsTests: CosmosDBManagementClientBase
    {
        private string location;

        // using an existing DB account, since Account provisioning takes 10-15 minutes
        private string resourceGroupName;
        private string databaseAccountName;

        private string databaseName;
        private string databaseName2;
        private string containerName;
        private string storedProcedureName;
        private string triggerName ;
        private string userDefinedFunctionName ;

        private string sqlThroughputType;

        private int sampleThroughput;

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
            location = CosmosDBTestUtilities.Location;
            resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
            databaseAccountName = Recording.GenerateAssetName("cosmosdb");
            databaseName = Recording.GenerateAssetName("databaseName");
            databaseName2 = Recording.GenerateAssetName("databaseName");
            containerName = Recording.GenerateAssetName("containerName");
            storedProcedureName = Recording.GenerateAssetName("storedProcedureName");
            triggerName = Recording.GenerateAssetName("triggerName");
            userDefinedFunctionName = Recording.GenerateAssetName("userDefinedFunctionName");
            sqlThroughputType = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/throughputSettings";
            sampleThroughput = 700;
        }
        [SetUp]
        public async Task ClearAndInitialize()
        {
            GenerateSampleValues();
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                //Creates or updates a resource group
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    location,
                    resourceGroupName);
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task SqlCRUDTests()
        {
            CosmosDBManagementClient cosmosDBManagementClient = GetCosmosDBManagementClient();
            DatabaseAccountGetResults databaseAccount = null;

            var locations = new List<Location>()
                {
                  {new Location(id:default(string),locationName: location, documentEndpoint:default(string), provisioningState: default(string), failoverPriority: default(int?), isZoneRedundant: default(bool?)) }
                };
            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations)
            {
                Location = location,
                Kind = DatabaseAccountKind.GlobalDocumentDB,
            };
            databaseAccount = await WaitForCompletionAsync(await cosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountCreateUpdateParameters));
            Assert.AreEqual(databaseAccount.Name, databaseAccountName);

            Response isDatabaseNameExists = await cosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(200, isDatabaseNameExists.Status);

            //Create sql database
            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters(new SqlDatabaseResource(databaseName), new CreateUpdateOptions());
            SqlDatabaseGetResults sqlDatabaseGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName, sqlDatabaseCreateUpdateParameters));
            Assert.NotNull(sqlDatabaseGetResults);
            Assert.AreEqual(databaseName, sqlDatabaseGetResults.Name);

            SqlDatabaseGetResults sqlDatabaseGetResults2 = (await cosmosDBManagementClient.SqlResources.GetSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName)).Value;
            Assert.NotNull(sqlDatabaseGetResults2);
            Assert.AreEqual(databaseName, sqlDatabaseGetResults2.Name);
            VerifyEqualSqlDatabases(sqlDatabaseGetResults, sqlDatabaseGetResults2);

            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters2 = new SqlDatabaseCreateUpdateParameters(id: default(string), name: default(string), type: default(string), location: location, tags: tags, resource: new SqlDatabaseResource(databaseName2), options: new CreateUpdateOptions{Throughput = sampleThroughput});
            SqlDatabaseGetResults sqlDatabaseGetResults3 = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlDatabaseAsync(resourceGroupName, databaseAccountName, databaseName2, sqlDatabaseCreateUpdateParameters2));
            Assert.NotNull(sqlDatabaseGetResults3);
            Assert.AreEqual(databaseName2, sqlDatabaseGetResults3.Name);

            IAsyncEnumerable<SqlDatabaseGetResults> sqlDatabases = cosmosDBManagementClient.SqlResources.ListSqlDatabasesAsync(resourceGroupName, databaseAccountName);
            Assert.NotNull(sqlDatabases);

            ThroughputSettingsGetResults throughputSettingsGetResults = (await cosmosDBManagementClient.SqlResources.GetSqlDatabaseThroughputAsync(resourceGroupName, databaseAccountName, databaseName2)).Value;
            Assert.NotNull(throughputSettingsGetResults);
            Assert.NotNull(throughputSettingsGetResults.Name);
            Assert.AreEqual(sqlThroughputType, throughputSettingsGetResults.Type);

            //Create sql container
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
            SqlContainerGetResults sqlContainerGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlContainerCreateUpdateParameters));
            Assert.NotNull(sqlContainerGetResults);
            VerifySqlContainerCreation(sqlContainerGetResults, sqlContainerCreateUpdateParameters);

            IAsyncEnumerable<SqlContainerGetResults> sqlContainers = cosmosDBManagementClient.SqlResources.ListSqlContainersAsync(resourceGroupName, databaseAccountName, databaseName);
            Assert.NotNull(sqlContainers);

            //Create stored procedure
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

            SqlStoredProcedureGetResults sqlStoredProcedureGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, storedProcedureName, sqlStoredProcedureCreateUpdateParameters));
            Assert.NotNull(sqlStoredProcedureGetResults);
            Assert.AreEqual(sqlStoredProcedureGetResults.Resource.Body, sqlStoredProcedureGetResults.Resource.Body);

            IAsyncEnumerable<SqlStoredProcedureGetResults> sqlStoredProcedures = cosmosDBManagementClient.SqlResources.ListSqlStoredProceduresAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlStoredProcedures);

            //Create defined function
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

            SqlUserDefinedFunctionGetResults sqlUserDefinedFunctionGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlUserDefinedFunctionAsync(resourceGroupName, databaseAccountName, databaseName, containerName, userDefinedFunctionName, sqlUserDefinedFunctionCreateUpdateParameters));
            Assert.NotNull(sqlUserDefinedFunctionGetResults);
            Assert.AreEqual(sqlUserDefinedFunctionGetResults.Resource.Body, sqlUserDefinedFunctionGetResults.Resource.Body);


            IAsyncEnumerable<SqlUserDefinedFunctionGetResults> sqlUserDefinedFunctions = cosmosDBManagementClient.SqlResources.ListSqlUserDefinedFunctionsAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlUserDefinedFunctions);


            //Create trigger
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

            SqlTriggerGetResults sqlTriggerGetResults = await WaitForCompletionAsync(await cosmosDBManagementClient.SqlResources.StartCreateUpdateSqlTriggerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, triggerName, sqlTriggerCreateUpdateParameters));
            Assert.NotNull(sqlTriggerGetResults);
            Assert.AreEqual(sqlTriggerGetResults.Resource.TriggerType, sqlTriggerCreateUpdateParameters.Resource.TriggerType);
            Assert.AreEqual(sqlTriggerGetResults.Resource.TriggerOperation, sqlTriggerCreateUpdateParameters.Resource.TriggerOperation);
            Assert.AreEqual(sqlTriggerGetResults.Resource.Body, sqlTriggerCreateUpdateParameters.Resource.Body);

            IAsyncEnumerable<SqlTriggerGetResults> sqlTriggers = cosmosDBManagementClient.SqlResources.ListSqlTriggersAsync(resourceGroupName, databaseAccountName, databaseName, containerName);
            Assert.NotNull(sqlTriggers);

            //Delete operations
            await foreach (SqlStoredProcedureGetResults sqlStoredProcedure in sqlStoredProcedures)
            {
                await cosmosDBManagementClient.SqlResources.StartDeleteSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlStoredProcedure.Name);
            }

            await foreach (SqlUserDefinedFunctionGetResults sqlUserDefinedFunction in sqlUserDefinedFunctions)
            {
                await cosmosDBManagementClient.SqlResources.StartDeleteSqlStoredProcedureAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlUserDefinedFunction.Name);
            }

            await foreach (SqlTriggerGetResults sqlTrigger in sqlTriggers)
            {
                await cosmosDBManagementClient.SqlResources.StartDeleteSqlTriggerAsync(resourceGroupName, databaseAccountName, databaseName, containerName, sqlTrigger.Name);
            }
            await foreach (SqlContainerGetResults sqlContainer in sqlContainers)
            {
                await cosmosDBManagementClient.SqlResources.StartDeleteSqlContainerAsync(resourceGroupName, databaseAccountName, databaseName, sqlContainer.Name);
            }

            await foreach (SqlDatabaseGetResults sqlDatabase in sqlDatabases)
            {
                await cosmosDBManagementClient.SqlResources.StartDeleteSqlDatabaseAsync(resourceGroupName, databaseAccountName, sqlDatabase.Name);
            }
        }

        private void VerifySqlContainerCreation(SqlContainerGetResults sqlContainerGetResults, SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters)
        {
            Assert.AreEqual(sqlContainerGetResults.Resource.Id, sqlContainerCreateUpdateParameters.Resource.Id);
            Assert.AreEqual(sqlContainerGetResults.Resource.IndexingPolicy.IndexingMode, sqlContainerCreateUpdateParameters.Resource.IndexingPolicy.IndexingMode);
            Assert.AreEqual(sqlContainerGetResults.Resource.PartitionKey.Kind, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Kind);
            Assert.AreEqual(sqlContainerGetResults.Resource.PartitionKey.Paths, sqlContainerCreateUpdateParameters.Resource.PartitionKey.Paths);
            Assert.AreEqual(sqlContainerGetResults.Resource.DefaultTtl, sqlContainerCreateUpdateParameters.Resource.DefaultTtl);
        }

        private void VerifyEqualSqlDatabases(SqlDatabaseGetResults expectedValue, SqlDatabaseGetResults actualValue)
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
