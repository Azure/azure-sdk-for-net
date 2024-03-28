// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class InstancePoolTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstancePoolTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<InstancePoolResource> CreateInstancePool(string instancePoolName)
        {
            string vnetName = SessionRecording.GenerateAssetName("vnet-");
            var vnet = await CreateVirtualNetwork(vnetName, _resourceGroup);
            ResourceIdentifier subnetId = SubnetResource.CreateResourceIdentifier(_resourceGroup.Id.SubscriptionId, _resourceGroup.Id.Name, vnetName, "ManagedInstance");
            InstancePoolData data = new InstancePoolData(AzureLocation.WestUS2)
            {
                Sku = new SqlSku("GP_Gen5", "GeneralPurpose", null, "Gen5", null, null),
                LicenseType = InstancePoolLicenseType.LicenseIncluded,
                Location = AzureLocation.WestUS2,
                SubnetId = subnetId,
                VCores = 8,
            };
            var instancePoolLro = await _resourceGroup.GetInstancePools().CreateOrUpdateAsync(WaitUntil.Completed, instancePoolName, data);
            return instancePoolLro.Value;
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task InstancePoolApiTests()
        {
            // 1.CreateOrUpdata
            string instancePoolName = Recording.GenerateAssetName("instance-pool-");
            var collection = _resourceGroup.GetInstancePools();
            var instancePool = await CreateInstancePool(instancePoolName);
            Assert.IsNotNull(instancePool);
            Assert.AreEqual(instancePoolName, instancePool.Data.Name);
            Assert.AreEqual(8, instancePool.Data.VCores);

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(instancePoolName));

            // 3.Get
            var getInstancePool = await collection.GetAsync(instancePoolName);
            Assert.AreEqual(instancePoolName, getInstancePool.Value.Data.Name);
            Assert.AreEqual(8, getInstancePool.Value.Data.VCores);

            // 4.GetAll
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);

            //// 5.Delete
            //var deleteInstancePool = await collection.GetAsync(instancePoolName);
            //await deleteInstancePool.Value.DeleteAsync();
            //list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            //Assert.IsNull(list);
        }

        [Test]
        [Ignore("not record yet")]
        [RecordedTest]
        public async Task Delete()
        {
            string instancePoolName = Recording.GenerateAssetName("instance-pool-");
            var collection = _resourceGroup.GetInstancePools();
            InstancePoolResource instancePool = await CreateInstancePool(instancePoolName);
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);

            await instancePool.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
