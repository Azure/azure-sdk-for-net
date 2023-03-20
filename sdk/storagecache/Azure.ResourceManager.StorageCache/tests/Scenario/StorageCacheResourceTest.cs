// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task Delete()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();
            var operation = await scr.DeleteAsync(WaitUntil.Completed);
            Assert.IsFalse(operation.WaitForCompletionResponse().IsError);

            Assert.ThrowsAsync<RequestFailedException>(async () => await scr.GetAsync());
            try
            {
                StorageCacheResource scrAfterDelete = await scr.GetAsync();
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(e.Status, 404);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();

            string policyName = "default";
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

            Assert.AreEqual(scr.Data.SecurityAccessPolicies.Count, 1);
            Assert.AreEqual(scr.Data.SecurityAccessPolicies[0].Name, policyName);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdateSpaceAllocation()
        {
            StorageCacheResource scr = await this.CreateOrUpdateStorageCache();

            IEnumerable<StorageTargetSpaceAllocation> spaceAllocationVar = new StorageTargetSpaceAllocation[]
            {
                new StorageTargetSpaceAllocation()
                {
                    AllocationPercentage = 25,
                    Name = @"st1"
                },
                new StorageTargetSpaceAllocation()
                {
                    AllocationPercentage = 50,
                    Name = @"st2"
                },
                new StorageTargetSpaceAllocation()
                {
                    AllocationPercentage = 25,
                    Name = @"st3"
                },
            };
            ArmOperation lro = await scr.UpdateSpaceAllocationAsync(
                waitUntil: WaitUntil.Completed,
                spaceAllocation: spaceAllocationVar);

            Assert.IsFalse(lro.WaitForCompletionResponse().IsError);
        }

        [TestCase]
        [RecordedTest]
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
