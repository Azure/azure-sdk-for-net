// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
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
        private const string capability = "EnableTable";
        private const string location = "WEST US";
        private const string tableThroughputType = "Microsoft.DocumentDB/databaseAccounts/tables/throughputSettings";
        private const int sampleThroughput = 700;
        private const int defaultThroughput = 400;
        private const int defaultMaxThroughput = 4000;
        private bool setupRun = false;
        public TableResourcesOperationsTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if ((Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback) && !setupRun)
            {
                InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
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

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task TableCreateAndUpdateTest()
        {
            TableGetResults tableGetResults1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(
                    resourceGroupName,
                    databaseAccountName,
                    tableName,
                    new TableCreateUpdateParameters(new TableResource(tableName), new CreateUpdateOptions())));
            Assert.IsNotNull(tableGetResults1);
            Assert.AreEqual(tableName, tableGetResults1.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults1 =
                await CosmosDBManagementClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(throughputSettingsGetResults1);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults1.Resource.Throughput);
            Assert.AreEqual(tableThroughputType, throughputSettingsGetResults1.Type);
            TableGetResults tableGetResults2 = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(tableGetResults2);
            VerifyTables(tableGetResults1, tableGetResults2);

            TableGetResults tableGetResults3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(
                    resourceGroupName,
                    databaseAccountName,
                    tableName,
                    new TableCreateUpdateParameters(new TableResource(tableName), new CreateUpdateOptions(sampleThroughput, new AutoscaleSettings()))));
            Assert.IsNotNull(tableGetResults3);
            Assert.AreEqual(tableName, tableGetResults3.Resource.Id);
            ThroughputSettingsGetResults throughputSettingsGetResults2 =
                await CosmosDBManagementClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(throughputSettingsGetResults2);
            Assert.AreEqual(sampleThroughput, throughputSettingsGetResults2.Resource.Throughput);
            Assert.AreEqual(tableThroughputType, throughputSettingsGetResults2.Type);
            TableGetResults tableGetResults4 = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(tableGetResults4);
            VerifyTables(tableGetResults3, tableGetResults4);
        }

        [TestCase, Order(2)]
        public async Task TableListTest()
        {
            List<TableGetResults> tables = await CosmosDBManagementClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(tables);
            Assert.AreEqual(1, tables.Count);
            TableGetResults tableGetResults = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            VerifyTables(tableGetResults, tables[0]);
        }

        [TestCase, Order(2)]
        public async Task TableMigrateToAutoscaleTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartMigrateTableToAutoscaleAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNotNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task TableMigrateToManualThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartMigrateTableToManualThroughputAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.IsNull(throughputSettingsGetResults.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task TableUpdateThroughputTest()
        {
            ThroughputSettingsGetResults throughputSettingsGetResults = await WaitForCompletionAsync(
               await CosmosDBManagementClient.TableResources.StartUpdateTableThroughputAsync(
                   resourceGroupName,
                   databaseAccountName,
                   tableName,
                   new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(defaultThroughput, null, null, null))));
            Assert.IsNotNull(throughputSettingsGetResults);
            Assert.AreEqual(defaultThroughput, throughputSettingsGetResults.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task TableDeleteTest()
        {
            await WaitForCompletionAsync(await CosmosDBManagementClient.TableResources.StartDeleteTableAsync(resourceGroupName, databaseAccountName, tableName));
            List<TableGetResults> tables = await CosmosDBManagementClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(tables);
            Assert.AreEqual(0, tables.Count);
        }

        private async Task PrepareDatabaseAccount()
        {
            List<Location> locationList = new List<Location>();
            locationList.Add(new Location(id: null, locationName: location, documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: null));
            var databaseAccountsCreateOrUpdateParameters = new DatabaseAccountCreateUpdateParameters(locationList);
            databaseAccountsCreateOrUpdateParameters.Kind = DatabaseAccountKind.GlobalDocumentDB;
            databaseAccountsCreateOrUpdateParameters.Location = location;
            databaseAccountsCreateOrUpdateParameters.Capabilities.Add(new Capability(capability));
            await WaitForCompletionAsync(
                await CosmosDBManagementClient.DatabaseAccounts.StartCreateOrUpdateAsync(resourceGroupName, databaseAccountName, databaseAccountsCreateOrUpdateParameters));
            var response = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(true, response.Value);
            Assert.AreEqual(200, response.GetRawResponse().Status);
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
