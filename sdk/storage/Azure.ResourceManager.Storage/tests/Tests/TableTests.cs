// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using System;
using System.Threading;
using System.Globalization;

namespace Azure.ResourceManager.Storage.Tests
{
    public class TableTests : StorageManagementTestBase
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
            var data = new TableData()
            {
                SignedIdentifiers = {
                    new StorageTableSignedIdentifier("PTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODklMTI")
                    {
                        AccessPolicy = new StorageTableAccessPolicy("raud")
                        {
                            ExpireOn = DateTimeOffset.Parse("2029-12-31T16:00:00.0000000Z")
                        }
                    },
                    new StorageTableSignedIdentifier("MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI")
                    {
                        AccessPolicy = new StorageTableAccessPolicy("ra")
                        {
                            ExpireOn = DateTimeOffset.Parse("2030-09-08T16:00:00.0000000Z")
                        }
                    }
                }
            };
            TableResource table1 = (await _tableCollection.CreateOrUpdateAsync(WaitUntil.Completed, tableName, data)).Value;
            Assert.IsNotNull(table1);
            Assert.AreEqual(table1.Id.Name, tableName);
            Assert.AreEqual(2, table1.Data.SignedIdentifiers.Count);

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
                            maxAgeInSeconds: 100),
                        new StorageCorsRule(
                            allowedOrigins: new string[] { "*" },
                            allowedMethods: new CorsRuleAllowedMethod[] {"GET" },
                            maxAgeInSeconds: 2,
                            exposedHeaders: new string[] { "*" },
                            allowedHeaders: new string[] { "*" }
                            )
                    }
                }
            };
            _tableService = (await _tableService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //Validate CORS Rules
            Assert.AreEqual(parameter.Cors.CorsRules.Count, _tableService.Data.Cors.CorsRules.Count);
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _tableService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            // Get the result ASAP will not have rule
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(8000);
            }
            _tableService = (await _tableService.GetAsync()).Value;

            //Validate CORS Rules
            Assert.AreEqual(parameter.Cors.CorsRules.Count, _tableService.Data.Cors.CorsRules.Count);
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _tableService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }
    }
}
