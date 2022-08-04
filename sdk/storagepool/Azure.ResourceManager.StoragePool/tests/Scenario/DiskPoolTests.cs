// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StoragePool.Models;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.ResourceManager.StoragePool.Tests
{
    public class DiskPoolTests : StoragePoolTestBase
    {
        private string SubnetResourceId;
        protected ResourceGroupResource _resourceGroup;

        public DiskPoolTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            _resourceGroup = await CreateResourceGroupAsync(resourceGroupName);
            SubnetResourceId = "/subscriptions/bc675d74-3b9f-48da-866a-a10149531391/resourceGroups/hakkaraj-rg/providers/Microsoft.Network/VirtualNetworks/diskpool-vnet-ae/subnets/default";
        }

        [Test]
        [RecordedTest]
        public async Task DiskPoolCrudOperations()
        {
            var diskPoolName = Recording.GenerateAssetName("diskpool-");
            var diskPoolCollection = _resourceGroup.GetDiskPools();

            var sku = new StoragePoolSku("Standard_S1");
            var diskPoolCreate = new DiskPoolCreateOrUpdateContent(sku, DefaultLocation, new Core.ResourceIdentifier(SubnetResourceId)) {};
            diskPoolCreate.AvailabilityZones.Add("1");
            // the following additional capability is not needed for non-test disk pools
            diskPoolCreate.AdditionalCapabilities.Add("DiskPool.SkipInfrastructureDeployment");

            // create disk pool
            var response = await diskPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, diskPoolName, diskPoolCreate);
            var diskPool = response.Value;
            Assert.AreEqual(diskPoolName, diskPool.Data.Name);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, diskPool.Data.ProvisioningState);

            // update disk pool -- by adding a new tag
            diskPoolCreate.Tags.Add("tag2", "value2");
            var updateResponse = await diskPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, diskPoolName, diskPoolCreate);
            diskPool = updateResponse.Value;
            Assert.AreEqual(diskPoolCreate.Tags, diskPool.Data.Tags);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, diskPool.Data.ProvisioningState);

            // stop disk pool
            var deallocateResponse = await diskPool.DeallocateAsync(WaitUntil.Completed);

            // start disk pool
            var startResponse = await diskPool.StartAsync(WaitUntil.Completed);

            // delete disk pool
            var deleteResponse = await diskPool.DeleteAsync(WaitUntil.Completed);

            try
            {
                var getResponse = await diskPoolCollection.GetAsync(diskPoolName);
            } catch (RequestFailedException e)
            {
                Assert.AreEqual(StatusCodes.Status404NotFound, e.Status);
            }
        }
    }
}
