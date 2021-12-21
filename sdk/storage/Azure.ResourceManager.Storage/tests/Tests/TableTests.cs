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
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private TableService _tableService;
        private TableCollection _tableCollection;
        public TableTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetTableCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _tableService = _storageAccount.GetTableService();
            _tableService = await _tableService.GetAsync();
            _tableCollection = _tableService.GetTables();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync();
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
            Table table1 = (await _tableCollection.CreateOrUpdateAsync(tableName)).Value;
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);

            //validate if created successfully
            Table table2 = await _tableCollection.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.IsTrue(await _tableCollection.CheckIfExistsAsync(tableName));
            Assert.IsFalse(await _tableCollection.CheckIfExistsAsync(tableName + "1"));

            //delete table
            await table1.DeleteAsync();

            //validate if deleted successfully
            Assert.IsFalse(await _tableCollection.CheckIfExistsAsync(tableName));
            Table table3 = await _tableCollection.GetIfExistsAsync(tableName);
            Assert.IsNull(table3);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllTables()
        {
            //create two tables
            string tableName1 = Recording.GenerateAssetName("testtable1");
            string tableName2 = Recording.GenerateAssetName("testtable2");
            Table table1 = (await _tableCollection.CreateOrUpdateAsync(tableName1)).Value;
            Table table2 = (await _tableCollection.CreateOrUpdateAsync(tableName2)).Value;

            //validate two tables
            Table table3 = null;
            Table table4 = null;
            int count = 0;
            await foreach (Table table in _tableCollection.GetAllAsync())
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
            CorsRules cors = new CorsRules();
            cors.CorsRulesValue.Add(new CorsRule(
                allowedHeaders: new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" },
                allowedMethods: new CorsRuleAllowedMethodsItem[] { "GET", "HEAD", "POST", "OPTIONS", "MERGE", "PUT" },
                 allowedOrigins: new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                exposedHeaders: new string[] { "x-ms-meta-*" },
                maxAgeInSeconds: 100));
            TableServiceData parameter = new TableServiceData()
            {
                Cors = cors,
            };
            _tableService = (await _tableService.CreateOrUpdateAsync(parameter)).Value;

            //validate
            Assert.AreEqual(_tableService.Data.Cors.CorsRulesValue.Count, 1);
        }
    }
}
