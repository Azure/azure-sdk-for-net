// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests
{
    public class TableTests : StorageTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private TableServiceResource _tableService;
        private TableCollection _tableCollection;
        public TableTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetTableCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            _tableService = await _storageAccount.GetTableService().GetAsync();
            _tableCollection = _tableService.GetTables();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccountResource account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteTable()
        {
            //create table
            string tableName = Recording.GenerateAssetName("testtable");
            TableResource table1 = (await _tableCollection.CreateOrUpdateAsync(WaitUntil.Completed, tableName, new TableData())).Value;
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);

            //validate if created successfully
            TableResource table2 = await _tableCollection.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.IsTrue(await _tableCollection.ExistsAsync(tableName));
            Assert.IsFalse(await _tableCollection.ExistsAsync(tableName + "1"));

            //delete table
            await table1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await _tableCollection.ExistsAsync(tableName));
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _tableCollection.GetAsync(tableName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllTables()
        {
            //create two tables
            string tableName1 = Recording.GenerateAssetName("testtable1");
            string tableName2 = Recording.GenerateAssetName("testtable2");
            TableResource table1 = (await _tableCollection.CreateOrUpdateAsync(WaitUntil.Completed, tableName1, new TableData())).Value;
            TableResource table2 = (await _tableCollection.CreateOrUpdateAsync(WaitUntil.Completed, tableName2, new TableData())).Value;

            //validate two tables
            TableResource table3 = null;
            TableResource table4 = null;
            int count = 0;
            await foreach (TableResource table in _tableCollection.GetAllAsync())
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

        [Test]
        [RecordedTest]
        public async Task UpdateTableService()
        {
            //update cors
            TableServiceData parameter = new TableServiceData()
            {
                Cors = new StorageCorsRules() {
                    CorsRules =
                    {
                        new StorageCorsRule(
                            allowedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                            allowedMethods: new CorsRuleAllowedMethod[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                             allowedOrigins: new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                            exposedHeaders: new string[] { "x-ms-meta-*" },
                            maxAgeInSeconds: 100)
                    }
                }
            };
            _tableService = (await _tableService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //validate
            Assert.AreEqual(_tableService.Data.Cors.CorsRules.Count, 1);
        }
    }
}
