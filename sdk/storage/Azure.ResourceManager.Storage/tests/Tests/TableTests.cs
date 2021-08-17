// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class TableTests:StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        private TableServiceContainer tableServiceContainer;
        private TableService tableService;
        private TableContainer tableContainer;
        public TableTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task CreateStorageAccountAndGetTableService()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            tableServiceContainer = curStorageAccount.GetTableServices();
            tableService = await tableServiceContainer.GetAsync("default");
            tableContainer = tableService.GetTables();
        }
        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (curResourceGroup != null)
            {
                var storageAccountContainer = curResourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                curResourceGroup = null;
                curStorageAccount = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteTable()
        {
            //create table
            string tableName = Recording.GenerateAssetName("testtable");
            Table table1 = await tableContainer.CreateOrUpdateAsync(tableName);
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
        public async Task StartCreateDeleteTable()
        {
            //start create table and wait for complete
            string tableName = Recording.GenerateAssetName("testtable");
            TableCreateOperation tableCreateOp = await tableContainer.StartCreateOrUpdateAsync(tableName);
            Table table1 = await tableCreateOp.WaitForCompletionAsync();
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);

            //validate if created successfully
            Table table2 = await tableContainer.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.IsTrue(await tableContainer.CheckIfExistsAsync(tableName));
            Assert.IsFalse(await tableContainer.CheckIfExistsAsync(tableName + "1"));

            //start delete table and wait for complete
            TableDeleteOperation tableDeleteOp = await table1.StartDeleteAsync();
            await tableDeleteOp.WaitForCompletionResponseAsync();

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
            Table table1 = await tableContainer.CreateOrUpdateAsync(tableName1);
            Table table2 = await tableContainer.CreateOrUpdateAsync(tableName2);

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
