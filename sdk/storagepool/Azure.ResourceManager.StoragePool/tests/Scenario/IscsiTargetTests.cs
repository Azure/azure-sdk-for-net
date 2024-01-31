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
    public class IscsiTargetTests : StoragePoolTestBase
    {
        private string SubnetResourceId;
        protected ResourceGroupResource _resourceGroup;

        public IscsiTargetTests(bool isAsync) : base(isAsync)
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
        public async Task IscsiTargetCrudOperations()
        {
            var diskPoolName = Recording.GenerateAssetName("diskpool-");
            var diskPoolCollection = _resourceGroup.GetDiskPools();

            var sku = new StoragePoolSku("Standard_S1");
            var diskPoolCreate = new DiskPoolCreateOrUpdateContent(sku, DefaultLocation, new Core.ResourceIdentifier(SubnetResourceId)) { };
            diskPoolCreate.AvailabilityZones.Add("1");

            // create disk pool
            var response = await diskPoolCollection.CreateOrUpdateAsync(WaitUntil.Completed, diskPoolName, diskPoolCreate);
            var diskPool = response.Value;
            Assert.AreEqual(diskPoolName, diskPool.Data.Name);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, diskPool.Data.ProvisioningState);

            // create iSCSI target
            var targetCollection = diskPool.GetDiskPoolIscsiTargets();
            var iscsiTargetName = Recording.GenerateAssetName("target-");
            var iscsiTargetCreate = new DiskPoolIscsiTargetCreateOrUpdateContent(DiskPoolIscsiTargetAclMode.Dynamic);

            var targetCreateResponse = await targetCollection.CreateOrUpdateAsync(WaitUntil.Completed, iscsiTargetName, iscsiTargetCreate);
            var iscsiTarget = targetCreateResponse.Value;
            Assert.AreEqual(iscsiTargetName, iscsiTarget.Data.Name);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, iscsiTarget.Data.ProvisioningState);

            // update iSCSI target -- by updating the managed by property
            var dataStoreId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/myResourceGroup/providers/Microsoft.AVS/privateClouds/myPrivateCloud/clusters/Cluster-1/datastores/datastore1";
            iscsiTargetCreate.ManagedBy = dataStoreId;
            iscsiTargetCreate.ManagedByExtended.Add(dataStoreId);
            var targetUpdateResponse = await targetCollection.CreateOrUpdateAsync(WaitUntil.Completed, iscsiTargetName, iscsiTargetCreate);
            iscsiTarget = targetUpdateResponse.Value;

            Assert.AreEqual(dataStoreId, iscsiTarget.Data.ManagedBy);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, iscsiTarget.Data.ProvisioningState);

            // remove managed by reference
            iscsiTargetCreate.ManagedBy = "";
            iscsiTargetCreate.ManagedByExtended.Remove(dataStoreId);
            targetUpdateResponse = await targetCollection.CreateOrUpdateAsync(WaitUntil.Completed, iscsiTargetName, iscsiTargetCreate);
            iscsiTarget = targetUpdateResponse.Value;

            Assert.AreEqual(null, iscsiTarget.Data.ManagedBy);
            Assert.AreEqual(DiskPoolIscsiTargetProvisioningState.Succeeded, iscsiTarget.Data.ProvisioningState);

            // delete iSCSI target
            var targetDeleteResponse = await iscsiTarget.DeleteAsync(WaitUntil.Completed);
            try
            {
                var getResponse = await targetCollection.GetAsync(iscsiTargetName);
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(StatusCodes.Status404NotFound, e.Status);
            }
        }
    }
}
