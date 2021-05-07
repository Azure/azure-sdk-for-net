// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ResourceGroupOperationsTests : ResourceManagerTestBase
    {
        public ResourceGroupOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
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
            await deleteOp.WaitForCompletionResponseAsync();
        }

        [TestCase]
        [RecordedTest]
        public void StartDeleteNonExistantRg()
        {
            var rgOp = InstrumentClientExtension(Client.GetResourceGroupOperations($"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/fake"));
            var deleteOpTask = rgOp.StartDeleteAsync();
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await deleteOpTask);
            Assert.AreEqual(404, exception.Status);
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
        [RecordedTest]
        public async Task MoveResources()
        {
            ResourceGroup rg1 = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            ResourceGroup rg2 = await Client.DefaultSubscription.GetResourceGroups().Construct(LocationData.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            var genericResources = Client.DefaultSubscription.GetGenericResources();
            var data = new GenericResourceData();
            data.Location = LocationData.WestUS2;
            data.Sku = new Sku("Aligned");
            var propertyBag = new Dictionary<string, object>();
            propertyBag.Add("platformUpdateDomainCount", 5);
            propertyBag.Add("platformFaultDomainCount", 2);
            data.Properties = propertyBag;
            var asetId = rg1.Id.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            var aset = await genericResources.CreateOrUpdateAsync(asetId, data);
            int countRg1 = 0;
            int countRg2 = 0;
            await foreach (var resource in genericResources.ListByResourceGroupAsync(rg1.Id.Name))
                countRg1++;
            await foreach (var resource in genericResources.ListByResourceGroupAsync(rg2.Id.Name))
                countRg2++;
            Assert.AreEqual(1, countRg1);
            Assert.AreEqual(0, countRg2);
            var moveInfo = new ResourcesMoveInfo();
            moveInfo.TargetResourceGroup = rg2.Id;
            moveInfo.Resources.Add(aset.Value.Id);
            await rg1.MoveResourcesAsync(moveInfo);
            countRg1 = 0;
            countRg2 = 0;
            await foreach (var resource in genericResources.ListByResourceGroupAsync(rg1.Id.Name))
                countRg1++;
            await foreach (var resource in genericResources.ListByResourceGroupAsync(rg2.Id.Name))
                countRg2++;
            Assert.AreEqual(0, countRg1);
            Assert.AreEqual(1, countRg2);
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
