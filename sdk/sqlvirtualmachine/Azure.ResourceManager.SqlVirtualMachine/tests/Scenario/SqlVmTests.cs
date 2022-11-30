// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class SqlVmTests : SqlVirtualMachineManagementTestBase
    {
        public SqlVmTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateGetUpdateDeleteListSqlVirtualMachine()
        {
            // Create SQL VM
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "sqlvmtestrg", AzureLocation.WestUS);
            var sqlVmCollections = rg.GetSqlVms();
            Dictionary<ResourceIdentifier, SqlVmResource> sqlVms = new Dictionary<ResourceIdentifier, SqlVmResource>();
            SqlVmResource sqlVm = null;
            for ( int i = 0; i < 3; i++ )
            {
                sqlVm = await CreateSqlVmAsync(rg);
                Assert.NotNull(sqlVm.Data);
                sqlVms.Add(sqlVm.Id, sqlVm);
            }
            // Get SQL VM
            foreach ( var sqlVmFromDict in sqlVms.Values )
            {
                SqlVmResource sqlVmFromGet = await sqlVmCollections.GetAsync(sqlVmFromDict.Data.Name);
                ValidateSqlVirtualMachine(sqlVmFromGet.Data, sqlVmFromDict.Data);
            }
            // Update
            string key = "test", value = "updateTag";
            SqlVmResource sqlVmFromUpdate = (await sqlVm.UpdateAsync(WaitUntil.Completed, new SqlVmPatch(){
                Tags =
                {
                    { key, value }
                }
            })).Value;
            ValidateSqlVirtualMachine(sqlVmFromUpdate.Data, sqlVm.Data, sameTags: false);
            Assert.AreEqual(1, sqlVmFromUpdate.Data.Tags.Count);
            Assert.AreEqual(value, sqlVmFromUpdate.Data.Tags[key]);
            // Delete
            await sqlVmFromUpdate.DeleteAsync(WaitUntil.Completed);
            sqlVms.Remove(sqlVmFromUpdate.Id);
            // List
            var count = 0;
            await foreach (var sqlVmFromList in sqlVmCollections)
            {
                Assert.NotNull(sqlVmFromList.Data);
                Assert.True(sqlVms.ContainsKey(sqlVmFromList.Id));
                Assert.AreNotEqual(sqlVmFromList.Id, sqlVmFromUpdate.Id);
                ValidateSqlVirtualMachine(sqlVmFromList.Data, sqlVms[sqlVmFromList.Id].Data);
                count++;
            }
            Assert.True(sqlVms.Count == count);
            // List by subscription
            count = 0;
            await foreach (var sqlVmFromList in Subscription.GetSqlVmsAsync())
            {
                Assert.NotNull(sqlVmFromList.Data);
                Assert.True(sqlVms.ContainsKey(sqlVmFromList.Id));
                Assert.AreNotEqual(sqlVmFromList.Id, sqlVmFromUpdate.Id);
                ValidateSqlVirtualMachine(sqlVmFromList.Data, sqlVms[sqlVmFromList.Id].Data);
                count++;
            }
            Assert.True(sqlVms.Count == count);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "sqlvmtestrg", AzureLocation.WestUS);
            var sqlVmCollections = rg.GetSqlVms();
            Dictionary<ResourceIdentifier, SqlVmResource> sqlVms = new Dictionary<ResourceIdentifier, SqlVmResource>();
            SqlVmResource sqlVm = await CreateSqlVmAsync(rg);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            SqlVmResource updatedSqlVm = await sqlVm.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedSqlVm.Data.Tags);
        }

        private static void ValidateSqlVirtualMachine(SqlVmData sqlVM1, SqlVmData sqlVM2, bool sameTags = true)
        {
            Assert.AreEqual(sqlVM1.Id, sqlVM2.Id);
            Assert.AreEqual(sqlVM1.Name, sqlVM2.Name);
            Assert.AreEqual(sqlVM1.Location, sqlVM2.Location);
            Assert.AreEqual(sqlVM1.SqlManagement, sqlVM2.SqlManagement);
            if (sameTags)
            {
                Assert.True(ValidateTags(sqlVM1, sqlVM2));
            }
        }

        private static bool ValidateTags(SqlVmData sqlVM1, SqlVmData sqlVM2)
        {
            return ValidateTags(sqlVM1.Tags, sqlVM2.Tags);
        }

        private static bool ValidateTags(IDictionary<string, string> tags1, IDictionary<string, string> tags2)
        {
            if (tags1 == null && tags2 == null)
            {
                return true;
            }

            if (tags1 == null || tags2 == null || tags1.Count != tags2.Count)
            {
                return false;
            }

            foreach (string s in tags1.Keys)
            {
                if (!tags2.ContainsKey(s) || !tags1[s].Equals(tags2[s]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
