// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sql.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class InstancePoolTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public InstancePoolTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            //var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("Sql-RG-1000");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(Location.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync();
            }
        }

        private async Task<InstancePool> CreateInstancePool(string instancePoolName)
        {
            //Prerequisites: 1. create NetworkSecurityGroup
            string networkSecurityGroupName = SessionRecording.GenerateAssetName("networkSecurityGroup-");
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
            {
                Location = Location.WestUS2,
            };
            var networkSecurityGroup = await _resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(networkSecurityGroupName, networkSecurityGroupData);

            //2. create Route table
            string routeTableName = SessionRecording.GenerateAssetName("routeTable-");
            RouteTableData routeTableData = new RouteTableData()
            {
                Location = Location.WestUS2,
            };
            var routeTable = await _resourceGroup.GetRouteTables().CreateOrUpdateAsync(routeTableName, routeTableData);

            //3. create Virtual network
            string vnetName = SessionRecording.GenerateAssetName("vnet-");
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.10.0.0/16", }
                },
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData()
                    {
                        Name = "ManagedInstance",
                        AddressPrefix = "10.10.2.0/24",
                        Delegations =
                        {
                            new Delegation() { ServiceName  = "Microsoft.Sql/managedInstances",Name="Microsoft.Sql/managedInstances" ,Type="Microsoft.Sql"}
                        },
                        RouteTable = new RouteTableData(){ Id = routeTable.Value.Data.Id.ToString() },
                        NetworkSecurityGroup = new NetworkSecurityGroupData(){ Id = networkSecurityGroup.Value.Data.Id.ToString() },
                    }
                },
            };
            var vnet = await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(vnetName, vnetData);
            string subnetId = $"{vnet.Value.Data.Id.ToString()}/subnets/ManagedInstance";
            InstancePoolData data = new InstancePoolData(Location.WestUS2)
            {
                Sku = new Models.Sku("GP_Gen5", "GeneralPurpose", null, "Gen5", null),
                LicenseType = InstancePoolLicenseType.LicenseIncluded,
                Location = Location.WestUS2,
                SubnetId = subnetId,
                VCores = 8,
            };
            var instancePoolLro = await _resourceGroup.GetInstancePools().CreateOrUpdateAsync(instancePoolName, data);
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
            Assert.AreEqual(instancePoolName,instancePool.Data.Name);
            Assert.AreEqual(8,instancePool.Data.VCores);

            // 2.CheckIfExist
            Assert.IsTrue(collection.CheckIfExists(instancePoolName));

            // 3.Get
            var getInstancePool =await collection.GetAsync(instancePoolName);
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
            InstancePool instancePool = await CreateInstancePool(instancePoolName);
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);

            await instancePool.DeleteAsync();
            list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
