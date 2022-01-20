// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

using ResourceGroup = Azure.ResourceManager.Resources.ResourceGroup;
using DiskPoolSku = Azure.ResourceManager.StoragePool.Models.Sku;
using Azure.ResourceManager.StoragePool.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;

namespace Azure.ResourceManager.StoragePool.Tests
{
    [TestFixture(true)]
    public class DiskPoolTests : DiskPoolTestBase
    {
        private string SubnetResourceId;
        private string ManagedDiskId;
        protected ResourceGroup _resourceGroup;

        public DiskPoolTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            SubnetResourceId = "/subscriptions/bc675d74-3b9f-48da-866a-a10149531391/resourceGroups/synthetics-permanent-canadacentral/providers/Microsoft.Network/virtualNetworks/synthetics-vnet/subnets/synthetics-subnet";
            ManagedDiskId = "/subscriptions/bc675d74-3b9f-48da-866a-a10149531391/resourceGroups/synthetics-permanent-canadacentral/providers/Microsoft.Compute/disks/synthetics-test-disk";
        }

        [Test]
        [RecordedTest]
        public async Task DiskPoolCrudOperations()
        {
            var diskPoolName = Recording.GenerateAssetName("diskpool-");
            var diskPoolCollection = _resourceGroup.GetDiskPools();

            var sku = new DiskPoolSku("Standard_S1");
            var diskPoolCreate = new DiskPoolCreate(sku, DefaultLocation, SubnetResourceId) {};
            diskPoolCreate.AvailabilityZones.Add("1");
            // the following additional capability is not needed for non-test disk pools
            diskPoolCreate.AdditionalCapabilities.Add("DiskPool.SkipInfrastructureDeployment");

            // create disk pool
            var response = await diskPoolCollection.CreateOrUpdateAsync(diskPoolName, diskPoolCreate, true);
            var diskPool = response.Value;

            // update disk pool
            diskPoolCreate.Disks.Add(
                new WritableSubResource()
                {
                    Id = new ResourceIdentifier(ManagedDiskId),
                });
            var updateResponse = await diskPoolCollection.CreateOrUpdateAsync(diskPoolName, diskPoolCreate, true);
            diskPool = updateResponse.Value;

            // stop disk pool
            var deallocateResponse = await diskPool.DeallocateAsync(true);

            // start disk pool
            var startResponse = await diskPool.StartAsync(true);

            // delete disk pool
            var deleteResponse = await diskPool.DeleteAsync(true);
        }
    }
}
