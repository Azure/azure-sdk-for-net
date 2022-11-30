// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ResourceMover.Tests
{
    internal class MoverResourceTests : ResourceMoverManagementTestBase
    {
        public MoverResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            MoverResourceSetResource moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string vnetName = Recording.GenerateAssetName("Vnet-");
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            string moverResourceName = Recording.GenerateAssetName("MoverResource-");
            MoverResource moverResource = await CreateMoverResource(moverResourceSet, virtualNetwork.Id, moverResourceName);
            Assert.AreEqual(moverResourceName, moverResource.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            MoverResourceSetResource moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string vnetName = Recording.GenerateAssetName("Vnet-");
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            string moverResourceName = Recording.GenerateAssetName("MoverResource-");
            _ = await CreateMoverResource(moverResourceSet, virtualNetwork.Id, moverResourceName);
            int count = 0;
            await foreach (var tempMoverResource in moverResourceSet.GetMoverResources().GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            MoverResourceSetResource moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string vnetName = Recording.GenerateAssetName("Vnet-");
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            string moverResourceName = Recording.GenerateAssetName("MoverResource-");
            MoverResource moverResource = await CreateMoverResource(moverResourceSet, virtualNetwork.Id, moverResourceName);
            MoverResource getMoverResource = await moverResourceSet.GetMoverResources().GetAsync(moverResourceName);
            AssertValidMoverResource(moverResource, getMoverResource);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            MoverResourceSetResource moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            string vnetName = Recording.GenerateAssetName("Vnet-");
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            string moverResourceName = Recording.GenerateAssetName("MoverResource-");
            MoverResource moverResource = await CreateMoverResource(moverResourceSet, virtualNetwork.Id, moverResourceName);
            await moverResource.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await moverResource.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private void AssertValidMoverResource(MoverResource model, MoverResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.ProvisioningState, getResult.Data.Properties.ProvisioningState);
                Assert.AreEqual(model.Data.Properties.SourceId, getResult.Data.Properties.SourceId);
                Assert.AreEqual(model.Data.Properties.TargetId, getResult.Data.Properties.TargetId);
                Assert.AreEqual(model.Data.Properties.ExistingTargetId, getResult.Data.Properties.ExistingTargetId);
                Assert.AreEqual(model.Data.Properties.IsResolveRequired, getResult.Data.Properties.IsResolveRequired);
            }
        }
    }
}
