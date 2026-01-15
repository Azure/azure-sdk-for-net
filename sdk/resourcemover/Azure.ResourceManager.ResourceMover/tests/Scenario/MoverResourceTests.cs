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
        private MoverResourceSetResource _moverResourceSet;
        private ResourceIdentifier _virtualNetworkId;
        private string _moverResourceName;
        private string _targetVnetName;

        public MoverResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier moverResourceSetId = MoverResourceSetResource.CreateResourceIdentifier(subscription.Id.SubscriptionId, "testRG-ResourceMover", "testMoveCollection");
            _moverResourceSet = await Client.GetMoverResourceSetResource(moverResourceSetId).GetAsync();

            string rgName = Recording.GenerateAssetName("testRg-ResourceMover-");
            string vnetName = Recording.GenerateAssetName("Vnet-");
            _moverResourceName = Recording.GenerateAssetName("MoverResource-");
            _targetVnetName = Recording.GenerateAssetName("targetVnet-");
            ResourceGroupResource rg = await CreateResourceGroup(subscription, rgName, AzureLocation.EastUS);
            VirtualNetworkResource virtualNetwork = await CreareVirtualNetwork(rg, vnetName);
            _virtualNetworkId = virtualNetwork.Id;
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            MoverResource moverResource = await CreateMoverResource(_moverResourceSet, _virtualNetworkId, _moverResourceName, _targetVnetName);
            Assert.That(moverResource.Data.Name, Is.EqualTo(_moverResourceName));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            _ = await CreateMoverResource(_moverResourceSet, _virtualNetworkId, _moverResourceName, _targetVnetName);
            int count = 0;
            await foreach (var tempMoverResource in _moverResourceSet.GetMoverResources().GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            MoverResource moverResource = await CreateMoverResource(_moverResourceSet, _virtualNetworkId, _moverResourceName, _targetVnetName);
            MoverResource getMoverResource = await _moverResourceSet.GetMoverResources().GetAsync(_moverResourceName);
            AssertValidMoverResource(moverResource, getMoverResource);
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            MoverResource moverResource = await CreateMoverResource(_moverResourceSet, _virtualNetworkId, _moverResourceName, _targetVnetName);
            await moverResource.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await moverResource.GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        private void AssertValidMoverResource(MoverResource model, MoverResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.That(getResult.Data.Properties.ProvisioningState, Is.EqualTo(model.Data.Properties.ProvisioningState));
                Assert.That(getResult.Data.Properties.SourceId, Is.EqualTo(model.Data.Properties.SourceId));
                Assert.That(getResult.Data.Properties.TargetId, Is.EqualTo(model.Data.Properties.TargetId));
                Assert.That(getResult.Data.Properties.ExistingTargetId, Is.EqualTo(model.Data.Properties.ExistingTargetId));
                Assert.That(getResult.Data.Properties.IsResolveRequired, Is.EqualTo(model.Data.Properties.IsResolveRequired));
            }
        }
    }
}
