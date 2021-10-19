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
    public class TableTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private TableServiceContainer _tableServiceContainer;
        private TableService _tableService;
        private TableContainer _tableContainer;
        public TableTests(bool async) : base(async)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetTableContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _tableServiceContainer = _storageAccount.GetTableServices();
            _tableService = await _tableServiceContainer.GetAsync("default");
            _tableContainer = _tableService.GetTables();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountContainer = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
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
            Table table1 = (await _tableContainer.CreateOrUpdateAsync(tableName)).Value;
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);

            //validate if created successfully
            Table table2 = await _tableContainer.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.IsTrue(await _tableContainer.CheckIfExistsAsync(tableName));
            Assert.IsFalse(await _tableContainer.CheckIfExistsAsync(tableName + "1"));

            //delete table
            await table1.DeleteAsync();

            //validate if deleted successfully
            Assert.IsFalse(await _tableContainer.CheckIfExistsAsync(tableName));
            Table table3 = await _tableContainer.GetIfExistsAsync(tableName);
            Assert.IsNull(table3);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllTables()
        {
            //create two tables
            string tableName1 = Recording.GenerateAssetName("testtable1");
            string tableName2 = Recording.GenerateAssetName("testtable2");
            Table table1 = (await _tableContainer.CreateOrUpdateAsync(tableName1)).Value;
            Table table2 = (await _tableContainer.CreateOrUpdateAsync(tableName2)).Value;

            //validate two tables
            Table table3 = null;
            Table table4 = null;
            int count = 0;
            await foreach (Table table in _tableContainer.GetAllAsync())
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
            _tableService = await _tableService.SetServicePropertiesAsync(parameter);

            //validate
            Assert.AreEqual(_tableService.Data.Cors.CorsRulesValue.Count, 1);
        }
    }
}
