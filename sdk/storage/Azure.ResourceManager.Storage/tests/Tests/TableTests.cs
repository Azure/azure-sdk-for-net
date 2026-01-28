// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

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
            Assert.That(table1, Is.Not.Null);
            Assert.That(tableName, Is.EqualTo(table1.Id.Name));
            Assert.That(table1.Data.SignedIdentifiers.Count, Is.EqualTo(2));

            //validate if created successfully
            TableResource table2 = await _tableCollection.GetAsync(tableName);
            AssertTableEqual(table1, table2);
            Assert.That((bool)await _tableCollection.ExistsAsync(tableName), Is.True);
            Assert.That((bool)await _tableCollection.ExistsAsync(tableName + "1"), Is.False);

            //delete table
            await table1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.That((bool)await _tableCollection.ExistsAsync(tableName), Is.False);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _tableCollection.GetAsync(tableName); });
            Assert.That(exception.Status, Is.EqualTo(404));
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
            Assert.That(count, Is.EqualTo(2));
            Assert.That(table3, Is.Not.Null);
            Assert.That(table4, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateTableService()
        {
            //update cors
            TableServiceData parameter = new TableServiceData()
            {
                Cors = new StorageCorsRules()
                {
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
            Assert.That(_tableService.Data.Cors.CorsRules.Count, Is.EqualTo(parameter.Cors.CorsRules.Count));
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _tableService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
            }

            // Get the result ASAP will not have rule
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(8000);
            }
            _tableService = (await _tableService.GetAsync()).Value;

            //Validate CORS Rules
            Assert.That(_tableService.Data.Cors.CorsRules.Count, Is.EqualTo(parameter.Cors.CorsRules.Count));
            for (int i = 0; i < parameter.Cors.CorsRules.Count; i++)
            {
                StorageCorsRule getRule = _tableService.Data.Cors.CorsRules[i];
                StorageCorsRule putRule = parameter.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
            }
        }
    }
}
