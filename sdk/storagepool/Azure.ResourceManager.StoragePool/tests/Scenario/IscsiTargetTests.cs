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
    public class IscsiTargetTests : DiskPoolTestBase
    {
        private string SubnetResourceId;
        private string ManagedDiskId;
        protected ResourceGroup _resourceGroup;

        public IscsiTargetTests(bool isAsync) : base(isAsync)
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
        public async Task IscsiTargetCrudOperations()
        {
            var diskPoolName = Recording.GenerateAssetName("diskpool-");
            var diskPoolCollection = _resourceGroup.GetDiskPools();

            var sku = new DiskPoolSku("Standard_S1");
            var diskPoolCreate = new DiskPoolCreate(sku, DefaultLocation, SubnetResourceId) { };
            diskPoolCreate.AvailabilityZones.Add("1");
            diskPoolCreate.Disks.Add(
               new WritableSubResource()
               {
                   Id = new ResourceIdentifier(ManagedDiskId),
               });

            // create disk pool
            var response = await diskPoolCollection.CreateOrUpdateAsync(true, diskPoolName, diskPoolCreate);
            var diskPool = response.Value;

            // create iSCSI target
            var targetCollection = diskPool.GetIscsiTargets();
            var iscsiTargetName = Recording.GenerateAssetName("target-");
            var iscsiTargetCreate = new IscsiTargetCreate(IscsiTargetAclMode.Dynamic);

            var targetCreateResponse = await targetCollection.CreateOrUpdateAsync(true, iscsiTargetName, iscsiTargetCreate);
            var iscsiTarget = targetCreateResponse.Value;

            // update iSCSI target
            iscsiTargetCreate.Luns.Add(new IscsiLun("lun0", ManagedDiskId));
            var targetUpdateResponse = await targetCollection.CreateOrUpdateAsync(true, iscsiTargetName, iscsiTargetCreate);
            iscsiTarget = targetUpdateResponse.Value;

            // delete iSCSI target
            var targetDeleteResponse = await iscsiTarget.DeleteAsync(true);
        }
    }
}
