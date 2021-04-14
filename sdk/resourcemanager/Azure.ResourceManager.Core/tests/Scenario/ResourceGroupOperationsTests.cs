// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    public class ResourceGroupOperationsTests : ResourceManagerTestBase
    {
        public ResourceGroupOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task DeleteRg()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            await rg.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDeleteRg()
        {
            var rgOp = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg = await rgOp.WaitForCompletionAsync();
            var deleteOp = await rg.StartDeleteAsync();
            await deleteOp.WaitForCompletionAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDeleteNonExistantRg()
        {
            var rgOp = InstrumentClientExtension(Client.GetResourceGroupOperations($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/fake"));
            var deleteOp = rgOp.StartDeleteAsync();
            try
            {
                var response = await (await deleteOp).WaitForCompletionAsync();
                Assert.Fail("RequestFailedException was not thrown");
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            await rg.GetAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task ListAvailableLocations()
        {
            ResourceGroup rg = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var locations = await rg.ListAvailableLocationsAsync();
            int count = 0;
            foreach(var location in locations)
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [Ignore("4622 needs complete with a Mocked example to fill in this test")]
        public void CreateResourceFromModel()
        {
            //public ArmResponse<TOperations> CreateResource<TContainer, TOperations, TResource>(string name, TResource model, azure_proto_core.Location location = default)
        }

        [TestCase]
        [Ignore("4622 needs complete with a Mocked example to fill in this test")]
        public void CreateResourceFromModelAsync()
        {
            //public ArmResponse<TOperations> CreateResource<TContainer, TOperations, TResource>(string name, TResource model, azure_proto_core.Location location = default)
        }
    }
}
