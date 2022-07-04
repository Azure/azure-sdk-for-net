// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
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
                await InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.ResourceGroupPrefix);
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

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase, Order(1)]
        public async Task TableCreateAndUpdateTest()
        {
            Table table1 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(
                    resourceGroupName,
                    databaseAccountName,
                    tableName,
                    new TableCreateUpdateParameters(new TableResource(tableName), new CosmosDBCreateUpdateConfig())));
            Assert.IsNotNull(table1);
            Assert.AreEqual(tableName, table1.Resource.Id);
            ThroughputSettingsData throughputSettings1 =
                await CosmosDBManagementClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(throughputSettings1);
            Assert.AreEqual(defaultThroughput, throughputSettings1.Resource.Throughput);
            Assert.AreEqual(tableThroughputType, throughputSettings1.Type);
            Table table2 = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(table2);
            VerifyTables(table1, table2);

            Table table3 = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartCreateUpdateTableAsync(
                    resourceGroupName,
                    databaseAccountName,
                    tableName,
                    new TableCreateUpdateParameters(new TableResource(tableName), new CosmosDBCreateUpdateConfig(sampleThroughput, new AutoscaleSettings()))));
            Assert.IsNotNull(table3);
            Assert.AreEqual(tableName, table3.Resource.Id);
            ThroughputSettingsData throughputSettings2 =
                await CosmosDBManagementClient.TableResources.GetTableThroughputAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(throughputSettings2);
            Assert.AreEqual(sampleThroughput, throughputSettings2.Resource.Throughput);
            Assert.AreEqual(tableThroughputType, throughputSettings2.Type);
            Table table4 = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            Assert.IsNotNull(table4);
            VerifyTables(table3, table4);
        }

        [TestCase, Order(2)]
        public async Task TableListTest()
        {
            List<Table> tables = await CosmosDBManagementClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
            Assert.IsNotNull(tables);
            Assert.AreEqual(1, tables.Count);
            Table table = await CosmosDBManagementClient.TableResources.GetTableAsync(resourceGroupName, databaseAccountName, tableName);
            VerifyTables(table, tables[0]);
        }

        [TestCase, Order(2)]
        public async Task TableMigrateToAutoscaleTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartMigrateTableToAutoscaleAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNotNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.AutoscaleSettings.MaxThroughput);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(3)]
        public async Task TableMigrateToManualThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
                await CosmosDBManagementClient.TableResources.StartMigrateTableToManualThroughputAsync(resourceGroupName, databaseAccountName, tableName));
            Assert.IsNotNull(throughputSettings);
            Assert.IsNull(throughputSettings.Resource.AutoscaleSettings);
            Assert.AreEqual(defaultMaxThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(4)]
        public async Task TableUpdateThroughputTest()
        {
            ThroughputSettingsData ThroughputSettingsData = await WaitForCompletionAsync(
               await CosmosDBManagementClient.TableResources.StartUpdateTableThroughputAsync(
                   resourceGroupName,
                   databaseAccountName,
                   tableName,
                   new ThroughputSettingsUpdateParameters(new ThroughputSettingsResource(defaultThroughput, null, null, null))));
            Assert.IsNotNull(throughputSettings);
            Assert.AreEqual(defaultThroughput, throughputSettings.Resource.Throughput);
        }

        [TestCase, Order(5)]
        public async Task TableDeleteTest()
        {
            await WaitForCompletionAsync(await CosmosDBManagementClient.TableResources.StartDeleteTableAsync(resourceGroupName, databaseAccountName, tableName));
            List<Table> tables = await CosmosDBManagementClient.TableResources.ListTablesAsync(resourceGroupName, databaseAccountName).ToEnumerableAsync();
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

        private void VerifyTables(Table expectedValue, Table actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Timestamp, actualValue.Resource.Timestamp);
            Assert.AreEqual(expectedValue.Resource.ETag, actualValue.Resource.ETag);
        }
    }
}
#endif
