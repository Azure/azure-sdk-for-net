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
        private ResourceGroupResource _resourceGroup;
        private string _storageAccountName, _storageAccountKey, _sqlVmGroupName;

        public SqlVmGroupTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            string rgName = Recording.GenerateAssetName("sqlvmtestrg");
            _storageAccountName = Recording.GenerateAssetName("sqlvmteststorage");
            _sqlVmGroupName = Recording.GenerateAssetName("sqlvmgrp");
            Subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroupAsync(Subscription, rgName, AzureLocation.WestUS);
            if (Mode == RecordedTestMode.Playback)
            {
                _storageAccountKey = "Sanitized";
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    _storageAccountKey = await CreateStorageAccountAsync(_resourceGroup, _storageAccountName);
                }
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateGetDeleteSqlVirtualMachineGroup()
        {
            // Create SQL VM group
            var sqlVmGroupCollection = _resourceGroup.GetSqlVmGroups();
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(_resourceGroup, _sqlVmGroupName, _storageAccountName, _storageAccountKey);
            Assert.AreEqual(_sqlVmGroupName, sqlVmGroup.Data.Name);
            // Get SQL VM group
            SqlVmGroupResource sqlVmGroupFromGet = await sqlVmGroupCollection.GetAsync(_sqlVmGroupName);
            Assert.AreEqual(_sqlVmGroupName, sqlVmGroupFromGet.Data.Name);
            // List by subscription
            var count = 0;
            await foreach (var sqlVmGroupFromList in Subscription.GetSqlVmGroupsAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
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
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(_resourceGroup, _sqlVmGroupName, _storageAccountName, _storageAccountKey);
            Assert.AreEqual(_sqlVmGroupName, sqlVmGroup.Data.Name);
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
            Assert.AreEqual(_sqlVmGroupName, sqlVmGroupFromGet.Data.Name);
            Assert.AreEqual(1, sqlVmGroupFromGet.Data.Tags.Keys.Count);
            Assert.AreEqual(value, sqlVmGroupFromGet.Data.Tags[key]);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            SqlVmGroupResource sqlVmGroup = await CreateSqlVmGroupAsync(_resourceGroup, _sqlVmGroupName, _storageAccountName, _storageAccountKey);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            SqlVmGroupResource updatedSqlVmGroup = await sqlVmGroup.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedSqlVmGroup.Data.Tags);
        }
    }
}
