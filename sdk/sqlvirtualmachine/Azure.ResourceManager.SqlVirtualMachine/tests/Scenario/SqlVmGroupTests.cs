// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.SqlVirtualMachine.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class SqlVmGroupTests : SqlVirtualMachineManagementTestBase
    {
        public SqlVmGroupTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateGetDeleteSqlVirtualMachineGroup()
        {
            // Create SQL VM group
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "sqlvmtestrg", AzureLocation.WestUS);
            StorageAccountResource storageAccount = await CreateStorageAccountAsync(rg);
            var sqlVmGroupCollection = rg.GetSqlVmGroups();
            var sqlVmGroupName = Recording.GenerateAssetName("sqlvmgrp");
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(rg, sqlVmGroupName, storageAccount);
            Assert.AreEqual(sqlVmGroupName, sqlVmGroup.Data.Name);
            // Get SQL VM group
            SqlVmGroupResource sqlVmGroupFromGet = await sqlVmGroupCollection.GetAsync(sqlVmGroupName);
            Assert.AreEqual(sqlVmGroupName, sqlVmGroupFromGet.Data.Name);
            // List by subscription
            var count = 0;
            await foreach (var sqlVmGroupFromList in Subscription.GetSqlVmGroupsAsync())
            {
                Assert.AreEqual(sqlVmGroupName, sqlVmGroupFromList.Data.Name);
                count++;
            }
            Assert.AreEqual(1, count);
            // Delete SQL VM group
            await sqlVmGroupFromGet.DeleteAsync(WaitUntil.Completed);
            // List SQL VM group
            count = 0;
            await foreach (var sqlVmGroupFromList in sqlVmGroupCollection)
            {
                count++;
            }
            Assert.AreEqual(0, count);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateUpdateGetSqlVirtualMachineGroup()
        {
            // Create SQL VM group
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "sqlvmtestrg", AzureLocation.WestUS);
            StorageAccountResource storageAccount = await CreateStorageAccountAsync(rg);
            var sqlVmGroupCollection = rg.GetSqlVmGroups();
            var sqlVmGroupName = Recording.GenerateAssetName("sqlvmgrp");
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(rg, sqlVmGroupName, storageAccount);
            Assert.AreEqual(sqlVmGroupName, sqlVmGroup.Data.Name);
            // Update SQL VM group
            string key = "test", value = "updateTag";
            SqlVmGroupResource sqlVmGroupFromUpdate = (await sqlVmGroup.UpdateAsync(WaitUntil.Completed, new SqlVmGroupPatch()
            {
                Tags =
                {
                    { key, value }
                }
            })).Value;
            Assert.AreEqual(1, sqlVmGroupFromUpdate.Data.Tags.Keys.Count);
            Assert.AreEqual(value, sqlVmGroupFromUpdate.Data.Tags[key]);
            // Get SQL VM group
            SqlVmGroupResource sqlVmGroupFromGet = await sqlVmGroupFromUpdate.GetAsync();
            Assert.AreEqual(sqlVmGroupName, sqlVmGroupFromGet.Data.Name);
            Assert.AreEqual(1, sqlVmGroupFromGet.Data.Tags.Keys.Count);
            Assert.AreEqual(value, sqlVmGroupFromGet.Data.Tags[key]);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "sqlvmtestrg", AzureLocation.WestUS);
            StorageAccountResource storageAccount = await CreateStorageAccountAsync(rg);
            var sqlVmGroupCollection = rg.GetSqlVmGroups();
            var sqlVmGroupName = Recording.GenerateAssetName("sqlvmgrp");
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(rg, sqlVmGroupName, storageAccount);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            SqlVmGroupResource updatedSqlVmGroup = await sqlVmGroup.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedSqlVmGroup.Data.Tags);
        }
    }
}
