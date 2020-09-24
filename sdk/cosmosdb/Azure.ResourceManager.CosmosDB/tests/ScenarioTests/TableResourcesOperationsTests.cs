<<<<<<< HEAD
﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.CosmosDB.Models;
using System.Collections.Generic;
using static Azure.Core.Pipeline.TaskExtensions;
=======
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core.TestFramework;
using Azure.ResourceManager.CosmosDB.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
>>>>>>> 4294e9429549950c5cc1cb75f6de16d2a8a2abf7

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class TableResourcesOperationsTests : CosmosDBManagementClientBase
    {
<<<<<<< HEAD
        private const string tableName1 = "tableName2527";
        private const string tableName2 = "tableName22527";
        private const int sampleThroughput = 700;
        private string databaseAccountName;
        private string resourceGroupName;
        private Dictionary<string, string> tags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };
        public TableResourcesOperationsTests()
            : base(true)
=======
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
>>>>>>> 4294e9429549950c5cc1cb75f6de16d2a8a2abf7
        {
        }

        [SetUp]
<<<<<<< HEAD
        public void ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                this.databaseAccountName = "testdb-001";
                this.resourceGroupName = "yalin-rg-test001";
                TestContext.Progress.WriteLine("//////////////////TestResourcesOperationsTests/////////////////////////////");
                TestContext.Progress.WriteLine(this.databaseAccountName);
                TestContext.Progress.WriteLine(this.resourceGroupName);
                /*await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.location,
                    this.resourceGroupName);*/
            }
        }

        [TearDown]
        public void CleanupResourceGroup()
        {
            /*await CleanupResourceGroupsAsync();*/
        }

        [TestCase]
        public async Task TableCRUDTest()
        {
            CosmosDBManagementClient cosmosDBMgmtClient = GetCosmosDBManagementClient();

            // create database account
           /* List<Location> locationList = new List<Location>();
            locationList.Add(new Location(id: null, locationName: "EAST US", documentEndpoint: null, provisioningState: null, failoverPriority: null, isZoneRedundant: null));
            IEnumerable<Location> locations = locationList;
            DatabaseAccountCreateUpdateParameters databaseAccountsCreateOrUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations);
            databaseAccountsCreateOrUpdateParameters.Kind = DatabaseAccountKind.GlobalDocumentDB;
            databaseAccountsCreateOrUpdateParameters.Location = "EAST US";
            databaseAccountsCreateOrUpdateParameters.Capabilities.Add(new Capability("EnableTable"));*/
            // await WaitForCompletionAsync(await cosmosDBMgmtClient.DatabaseAccounts.StartCreateOrUpdateAsync(this.resourceGroupName, this.databaseAccountName, databaseAccountsCreateOrUpdateParameters));

            /* var opTask = cosmosDBMgmtClient.DatabaseAccounts.StartCreateOrUpdateAsync(this.resourceGroupName, this.databaseAccountName, databaseAccountsCreateOrUpdateParameters);
             var op = await opTask;
             var taskValue = op.WaitForCompletionAsync();
             var value = await taskValue;*/

            /*var r = await cosmosDBMgmtClient.DatabaseAccounts.StartCreateOrUpdateAsync(this.resourceGroupName, this.databaseAccountName, databaseAccountsCreateOrUpdateParameters);
            var response = (await WaitForCompletionAsync(r)).Value;
            TestContext.Progress.WriteLine("///////////////////////////response///////////////////////");
            TestContext.Progress.WriteLine(response);*/
            /*bool isDatabaseNameExists1 = cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync(this.databaseAccountName).Result.Status == 200;
            if (!isDatabaseNameExists1)
            {
                return;
            }*/
            var taskIsDatabaseNameExists = cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync("db92834789274");
            /*var response = taskIsDatabaseNameExists;
            var isDatabaseNameExists = taskIsDatabaseNameExists.GetAwaiter().GetResult(); //get response as int -> 200 = good, 404 = not found
            if (isDatabaseNameExists.Status != 200)
            {
                return;
            }*/
            var res1 = cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync("db001");   // fake
            var res2 = cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync("testdb-001");
            /*bool isDatabaseNameExist2 = cosmosDBMgmtClient.DatabaseAccounts.CheckNameExistsAsync("db-001").Result.Status == 200;*/

            // create/update a table with tableName1
            TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters(new TableResource(tableName1), new CreateUpdateOptions());
            /*await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartCreateUpdateTableAsync(this.resourceGroupName, this.databaseAccountName, tableName1, tableCreateUpdateParameters));*/
            /*TableGetResults tableGetResults1 = (await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartCreateUpdateTableAsync(this.resourceGroupName, this.databaseAccountName, tableName1, tableCreateUpdateParameters))).Value;
            Assert.NotNull(tableGetResults1);*/

            TableGetResults tableGetResults2 = (await cosmosDBMgmtClient.TableResources.GetTableAsync(this.resourceGroupName, this.databaseAccountName, tableName1)).Value;
            TestContext.Progress.WriteLine("///////////////////////////tableGetResults2///////////////////////");
            TestContext.Progress.WriteLine(tableGetResults2);
            Assert.NotNull(tableGetResults2);

            /*VerifyEqualTables(tableGetResults1, tableGetResults2);*/

            // create/update a table with tableName2
            /*tableCreateUpdateParameters = new TableCreateUpdateParameters(new TableResource(tableName2), new CreateUpdateOptions(sampleThroughput, null));
            TableGetResults tableGetResults3 = (await WaitForCompletionAsync(await cosmosDBMgmtClient.TableResources.StartCreateUpdateTableAsync(this.resourceGroupName, this.databaseAccountName, tableName2, tableCreateUpdateParameters))).Value;
            Assert.NotNull(tableGetResults3);*/
        }

        private void VerifyEqualTables(TableGetResults expectedValue, TableGetResults actualValue)
        {
=======
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
            Response response = await CosmosDBManagementClient.DatabaseAccounts.CheckNameExistsAsync(databaseAccountName);
            Assert.AreEqual(200, response.Status);
        }

        private void VerifyTables(TableGetResults expectedValue, TableGetResults actualValue)
        {
            Assert.AreEqual(expectedValue.Id, actualValue.Id);
            Assert.AreEqual(expectedValue.Name, actualValue.Name);
>>>>>>> 4294e9429549950c5cc1cb75f6de16d2a8a2abf7
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
