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
    public class VaultTests : DataProtectionBackupManagementTestBase
    {
        public VaultTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DataProtectionBackupVaultCollection> GetVaultCollection()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetDataProtectionBackupVaults();
        }

        [RecordedTest]
        public async Task VaultApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetVaultCollection();
            var name = Recording.GenerateAssetName("vault");
            var name2 = Recording.GenerateAssetName("vault");
            var name3 = Recording.GenerateAssetName("vault");
            var input = ResourceDataHelpers.GetVaultData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            DataProtectionBackupVaultResource resource = lro.Value;
            Assert.That(resource.Data.Name, Is.EqualTo(name));
            //2.Get
            DataProtectionBackupVaultResource resource2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertVaultData(resource.Data, resource2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }

            Assert.Multiple(async () =>
            {
                Assert.That(count, Is.GreaterThanOrEqualTo(3));
                //4Exists
                Assert.That((bool)await collection.ExistsAsync(name), Is.True);
                Assert.That((bool)await collection.ExistsAsync(name + "1"), Is.False);
            });

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
            //resourceTests
            //5.Get
            DataProtectionBackupVaultResource resource3 = await resource.GetAsync();
            ResourceDataHelpers.AssertVaultData(resource.Data, resource3.Data);
            //6.Delete
            await resource.DeleteAsync(WaitUntil.Completed);
        }
    }
}
