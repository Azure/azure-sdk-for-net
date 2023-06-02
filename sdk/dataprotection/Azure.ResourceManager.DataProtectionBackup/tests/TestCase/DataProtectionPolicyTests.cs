// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataProtectionBackup.Models;
using Azure.ResourceManager.DataProtectionBackup.Tests;
using Azure.ResourceManager.DataProtectionBackup.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.DataProtectionBackup.Tests.TestCase
{
    public class DataProtectionPolicyTests : DataProtectionBackupManagementTestBase
    {
        public DataProtectionPolicyTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataProtectionBackupPolicyCollection> GetPolicyCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var vaultCollection = resourceGroup.GetDataProtectionBackupVaults();
            var name = Recording.GenerateAssetName("vault");
            var input = ResourceDataHelpers.GetVaultData();
            var lro = await vaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataProtectionBackupVaultResource resource = lro.Value;
            return resource.GetDataProtectionBackupPolicies();
        }

        [RecordedTest]
        public async Task PolicyApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetPolicyCollection();
            var name = Recording.GenerateAssetName("policy");
            var name2 = Recording.GenerateAssetName("policy");
            var name3 = Recording.GenerateAssetName("policy");
            var input = ResourceDataHelpers.GetPolicyData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataProtectionBackupPolicyResource resource = lro.Value;
            Assert.AreEqual(name, resource.Data.Name);
            //2.Get
            DataProtectionBackupPolicyResource resource2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertpolicyData(resource.Data, resource2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //resourceTests
            //5.Get
            DataProtectionBackupPolicyResource resource3 = await resource.GetAsync();
            ResourceDataHelpers.AssertpolicyData(resource.Data, resource3.Data);
            //6.Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
