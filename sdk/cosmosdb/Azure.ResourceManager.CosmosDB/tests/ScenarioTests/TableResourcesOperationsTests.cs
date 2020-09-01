// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.CosmosDB.Models;
using System.Collections.Generic;
using static Azure.Core.Pipeline.TaskExtensions;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class TableResourcesOperationsTests : CosmosDBManagementClientBase
    {
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
        {
        }

        [SetUp]
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
            Assert.AreEqual(expectedValue.Resource.Id, actualValue.Resource.Id);
            Assert.AreEqual(expectedValue.Resource.Rid, actualValue.Resource.Rid);
            Assert.AreEqual(expectedValue.Resource.Ts, actualValue.Resource.Ts);
            Assert.AreEqual(expectedValue.Resource.Etag, actualValue.Resource.Etag);
        }
    }
}
