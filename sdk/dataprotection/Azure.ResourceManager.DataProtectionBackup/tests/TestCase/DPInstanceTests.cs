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
    public class DPInstanceTests : DataProtectionBackupManagementTestBase
    {
        public DPInstanceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<(DataProtectionBackupInstanceCollection InstanceCollection, DataProtectionBackupPolicyCollection PolicyCollection)> GetInstanceCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var vaultCollection = resourceGroup.GetDataProtectionBackupVaults();
            var name = Recording.GenerateAssetName("vault");
            var input = ResourceDataHelpers.GetVaultData();
            var lro = await vaultCollection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataProtectionBackupVaultResource resource = lro.Value;

            return (resource.GetDataProtectionBackupInstances(), resource.GetDataProtectionBackupPolicies());
        }

        [RecordedTest]
        [Ignore("Invalid URI: The format of the URI could not be determined")]
        public async Task InstanceApiTests()
        {
            //0.prepare
            (DataProtectionBackupInstanceCollection collection, DataProtectionBackupPolicyCollection policyCollection) = await GetInstanceCollection();
            var policyData = ResourceDataHelpers.GetDiskPolicyData();
            var policy = (await policyCollection.CreateOrUpdateAsync(WaitUntil.Completed, "diskpolicy2", policyData)).Value;
            //1.CreateOrUpdate
            var name = Recording.GenerateAssetName("instance");
            var name2 = Recording.GenerateAssetName("instance");
            var name3 = Recording.GenerateAssetName("instance");
            var input = ResourceDataHelpers.GetInstanceData(policy.Id, name);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataProtectionBackupInstanceResource resource = lro.Value;
            Assert.AreEqual(name, resource.Data.Name);
            //2.Get
            DataProtectionBackupInstanceResource resource2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertInstanceData(resource.Data, resource2.Data);
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
            DataProtectionBackupInstanceResource resource3 = await resource.GetAsync();
            ResourceDataHelpers.AssertInstanceData(resource.Data, resource3.Data);
            //6.Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
