// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

using ResourceGroup = Azure.ResourceManager.Resources.ResourceGroup;
using DiskPoolSku = Azure.ResourceManager.StoragePool.Models.Sku;
using Azure.ResourceManager.StoragePool.Models;

namespace Azure.ResourceManager.StoragePool.Tests
{
    public class IscsiTargetTests : StoragePoolTestBase
    {
        private string SubnetResourceId;
        protected ResourceGroup _resourceGroup;

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

            var sku = new DiskPoolSku("Standard_S1");
            var diskPoolCreate = new DiskPoolCreate(sku, DefaultLocation, SubnetResourceId) { };
            diskPoolCreate.AvailabilityZones.Add("1");

            // create disk pool
            var response = await diskPoolCollection.CreateOrUpdateAsync(true, diskPoolName, diskPoolCreate);
            var diskPool = response.Value;

            // create iSCSI target
            var targetCollection = diskPool.GetIscsiTargets();
            var iscsiTargetName = Recording.GenerateAssetName("target-");
            var iscsiTargetCreate = new IscsiTargetCreate(IscsiTargetAclMode.Dynamic);

            var targetCreateResponse = await targetCollection.CreateOrUpdateAsync(true, iscsiTargetName, iscsiTargetCreate);
            var iscsiTarget = targetCreateResponse.Value;

            // update iSCSI target -- by updating the managed by property
            var dataStoreId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/myResourceGroup/providers/Microsoft.AVS/privateClouds/myPrivateCloud/clusters/Cluster-1/datastores/datastore1";
            iscsiTargetCreate.ManagedBy = dataStoreId;
            iscsiTargetCreate.ManagedByExtended.Add(dataStoreId);
            var targetUpdateResponse = await targetCollection.CreateOrUpdateAsync(true, iscsiTargetName, iscsiTargetCreate);
            iscsiTarget = targetUpdateResponse.Value;

            // remove managed by reference
            iscsiTargetCreate.ManagedBy = "";
            iscsiTargetCreate.ManagedByExtended.Remove(dataStoreId);
            targetUpdateResponse = await targetCollection.CreateOrUpdateAsync(true, iscsiTargetName, iscsiTargetCreate);
            iscsiTarget = targetUpdateResponse.Value;

            // delete iSCSI target
            var targetDeleteResponse = await iscsiTarget.DeleteAsync(true);
        }
    }
}
