// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class DedicatedHostOperationsTests : ComputeTestBase
    {
        public DedicatedHostOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DedicatedHostGroup> CreateDedicatedHostGroupAsync(string groupName)
        {
            var container = (await CreateResourceGroupAsync()).GetDedicatedHostGroups();
            var input = ResourceDataHelper.GetBasicDedicatedHostGroup(DefaultLocation, 2);
            return await container.CreateOrUpdateAsync(groupName, input);
        }

        private async Task<DedicatedHost> CreateDedicatedHostAsync(string hostName)
        {
            var hostGroupName = Recording.GenerateAssetName("testDHG-");
            var container = (await CreateDedicatedHostGroupAsync(hostGroupName)).GetDedicatedHosts();
            var input = ResourceDataHelper.GetBasicDedicatedHost(DefaultLocation, "DSv3-Type1", 0);
            return await container.CreateOrUpdateAsync(hostName, input);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            var dedicatedHost = await CreateDedicatedHostAsync(hostName);
            await dedicatedHost.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            var dedicatedHost = await CreateDedicatedHostAsync(hostName);
            var deleteOp = await dedicatedHost.StartDeleteAsync();
            await deleteOp.WaitForCompletionResponseAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            var host1 = await CreateDedicatedHostAsync(hostName);
            DedicatedHost host2 = await host1.GetAsync();

            ResourceDataHelper.AssertHost(host1.Data, host2.Data);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("There is a bug in OperationInternals causing we cannot handle this kind of PATCH LRO right now")]
        public async Task Update()
        {
            var hostName = Recording.GenerateAssetName("testHost-");
            DedicatedHost dedicatedHost = await CreateDedicatedHostAsync(hostName);
            var updatedAutoReplaceOnFailure = false;
            var update = new DedicatedHostUpdate()
            {
                AutoReplaceOnFailure = updatedAutoReplaceOnFailure
            };
            DedicatedHost updatedHost = await dedicatedHost.UpdateAsync(update);

            Assert.AreEqual(updatedAutoReplaceOnFailure, updatedHost.Data.AutoReplaceOnFailure);
        }
    }
}
