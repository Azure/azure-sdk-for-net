// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class TableResourcesOperationsTests : CosmosDBManagementClientBase
    {
        private string resourceGroupName;
        private const string databaseAccountName = "db2672";
        private const string tableName = "tableName2527";
        private const int sampleThroughput = 700;
        private const int defaultThroughput = 400;
        private const int defaultMaxThroughput = 4000;
        public TableResourcesOperationsTests()
            : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.Location,
                    this.resourceGroupName);
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task TableCRUDTest()
        {
            CosmosDBManagementClient cosmosDBMgmtClient = GetCosmosDBManagementClient();

            // prepare a database account
            List<Location> locationList = new List<Location>();
            locationList.Add(new Location(id: null, locationName: "WEST US", documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: null));
            IEnumerable<Location> locations = locationList;
            var databaseAccountsCreateOrUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountsCreateOrUpdateParameters.Kind = DatabaseAccountKind.GlobalDocumentDB;
            databaseAccountsCreateOrUpdateParameters.Location = "WEST US";
            databaseAccountsCreateOrUpdateParameters.Capabilities.Add(new Capability("EnableTable"));
            await WaitForCompletionAsync(await cosmosDBMgmtClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountsCreateOrUpdateParameters));
            Assert.AreEqual(200, cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName).Result.Status);

            var tableCreateUpdateParameters1 = new TableCreateUpdateParameters(new TableResource(tableName), new CreateUpdateOptions());
            TableGetResults tableGetResults1 = (await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartCreateUpdateTableAsync(resourceGroupName, databaseAccountName, tableName, tableCreateUpdateParameters1))).Value;
            Assert.IsNotNull(tableGetResults1);
            Assert.AreEqual(tableName, tableGetResults1.Resource.Id);

            TableGetResults tableGetResults2 = (await cosmosDBMgmtClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName)).Value;
            Assert.IsNotNull(tableGetResults2);
            VerifyTables(tableGetResults1, tableGetResults2);
            var actualThroughput = (await cosmosDBMgmtClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName)).Value.Resource.Throughput;
            Assert.AreEqual(defaultThroughput, actualThroughput);

            var tableCreateUpdateParameters2 = new TableCreateUpdateParameters(new TableResource(tableName), new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings()));
            TableGetResults tableGetResults3 = (await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartCreateUpdateTableAsync(resourceGroupName, databaseAccountName, tableName, tableCreateUpdateParameters2))).Value;
            Assert.IsNotNull(tableGetResults3);
            Assert.AreEqual(tableName, tableGetResults3.Resource.Id);
            actualThroughput = (await cosmosDBMgmtClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName)).Value.Resource.Throughput;
            Assert.AreEqual(sampleThroughput, actualThroughput);

            TableGetResults tableGetResults4 = (await cosmosDBMgmtClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName)).Value;
            Assert.IsNotNull(tableGetResults4);
            VerifyTables(tableGetResults3, tableGetResults4);

            List<TableGetResults> tables = await cosmosDBMgmtClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(tables);
            Assert.AreEqual(1, tables.Count);
            VerifyTables(tableGetResults4, tables[0]);

            ThroughputSettingsGetResults throughputSettingsGetResults1 = await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartMigrateTableToAutoscaleAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNotNull(throughputSettingsGetResults1.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults1.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults1.Resource.Throughput);

            ThroughputSettingsGetResults throughputSettingsGetResults2 = await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartMigrateTableToManualThroughputAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNull(throughputSettingsGetResults2.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults2.Resource.Throughput);

            var throughputSettingsUpdateParameters = new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(defaultThroughput, null, null, null));
            ThroughputSettingsGetResults throughputSettingsGetResults = (await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartUpdateTableThroughputAsync(resourceGroupName, databaseAccountName, tableName, throughputSettingsUpdateParameters))).Value;
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        private void VerifyTables(TableGetResults expectedValue, TableGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
