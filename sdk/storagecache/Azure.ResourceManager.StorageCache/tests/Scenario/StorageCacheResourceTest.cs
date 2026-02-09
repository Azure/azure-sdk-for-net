// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Scenario
{
    internal class StorageCacheResourceTest : StorageCacheManagementTestBase
    {
        public StorageCacheResourceTest(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Delete()
        {
            await AzureResourceTestHelper.TestDelete<StorageCacheResource>(
                async () => await this.CreateOrUpdateStorageCache(),
                async (cache) => await cache.DeleteAsync(WaitUntil.Completed),
                async (cache) => await cache.GetAsync());
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task Update()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();

            string policyName = "newone";
            scr.Data.SecurityAccessPolicies.Add(
                new NfsAccessPolicy(
                    name: policyName,
                    accessRules: new NfsAccessRule[]
                    {
                        new NfsAccessRule(scope: NfsAccessRuleScope.Default, access: NfsAccessRuleAccess.ReadWrite)
                        {
                            AllowSubmountAccess = true,
                            AllowSuid = false,
                            EnableRootSquash = false
                        },
                    }));

            ArmOperation<StorageCacheResource> lro = await scr.UpdateAsync(
                waitUntil: WaitUntil.Completed,
                data: scr.Data);

            this.VerifyStorageCache(lro.Value, scr.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task UpdateSpaceAllocation()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();
            StorageTargetResource str = await this.CreateOrUpdateStorageTarget(scr);

            IEnumerable<StorageTargetSpaceAllocation> spaceAllocationVar = new StorageTargetSpaceAllocation[]
            {
                new StorageTargetSpaceAllocation()
                {
                    AllocationPercentage = 100,
                    Name = str.Data.Name,
                },
            };
            ArmOperation lro = await scr.UpdateSpaceAllocationAsync(
                waitUntil: WaitUntil.Completed,
                spaceAllocation: spaceAllocationVar);

            Assert.IsFalse(lro.WaitForCompletionResponse().IsError);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("Skip test as the StorageCache service is end-of-lifed.")]
        public async Task OtherCacheOperations()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();
            ArmOperation operation = await scr.EnableDebugInfoAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);
            operation = await scr.FlushAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);
            operation = await scr.StopAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);
            operation = await scr.StartAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);
            operation = await scr.UpgradeFirmwareAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);
        }
    }
}
