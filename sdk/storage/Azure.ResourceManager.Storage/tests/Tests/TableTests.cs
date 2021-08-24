// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class TableTests:StorageTestBase
    {
        private ResourceGroup resourceGroup;
        private StorageAccount storageAccount;
        private TableServiceContainer tableServiceContainer;
        private TableService tableService;
        private TableContainer tableContainer;
        public TableTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task CreateStorageAccountAndGetTableContainer()
        {
            resourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOperation= await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            storageAccount = await accountCreateOperation.WaitForCompletionAsync();
            tableServiceContainer = storageAccount.GetTableServices();
            tableService = await tableServiceContainer.GetAsync("default");
            tableContainer = tableService.GetTables();
        }
        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (resourceGroup != null)
            {
                var storageAccountContainer = resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                resourceGroup = null;
                storageAccount = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteTable()
        {
            //create table
            string tableName = Recording.GenerateAssetName("testtable");
            TableCreateOperation tableCreateOperation=await tableContainer.CreateOrUpdateAsync(tableName);
            Table table1 = await tableCreateOperation.WaitForCompletionAsync();
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);

            //validate if created successfully
            Table table2 = await tableContainer.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.IsTrue(await tableContainer.CheckIfExistsAsync(tableName));
            Assert.IsFalse(await tableContainer.CheckIfExistsAsync(tableName+ "1"));

            //delete table
            await table1.DeleteAsync();

            //validate if deleted successfully
            Assert.IsFalse(await tableContainer.CheckIfExistsAsync(tableName));
            Table table3 = await tableContainer.GetIfExistsAsync(tableName);
            Assert.IsNull(table3);
        }
        [Test]
        [RecordedTest]
        public async Task GetAllTables()
        {
            //create two tables
            string tableName1 = Recording.GenerateAssetName("testtable1");
            string tableName2 = Recording.GenerateAssetName("testtable2");
            TableCreateOperation tableCreateOperation1 = await tableContainer.CreateOrUpdateAsync(tableName1);
            Table table1 = await tableCreateOperation1.WaitForCompletionAsync();
            TableCreateOperation tableCreateOperation2 = await tableContainer.CreateOrUpdateAsync(tableName2);
            Table table2 = await tableCreateOperation2.WaitForCompletionAsync();

            //validate two tables
            Table table3 = null;
            Table table4 = null;
            int count = 0;
            await foreach (Table table in tableContainer.GetAllAsync())
            {
                count++;
                if (table.Id.Name == tableName1)
                {
                    table3 = table;
                }
                if (table.Id.Name == tableName2)
                {
                    table4 = table;
                }
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(table3);
            Assert.IsNotNull(table4);
        }
    }
}
