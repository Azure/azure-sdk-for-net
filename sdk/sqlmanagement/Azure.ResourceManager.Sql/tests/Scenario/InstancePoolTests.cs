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

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class InstancePoolTests : SqlManagementClientBase
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
            //var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().GetAsync("Sql-RG-1000");
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
            //Prerequisites: 1. create NetworkSecurityGroup
            string networkSecurityGroupName = SessionRecording.GenerateAssetName("networkSecurityGroup-");
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData()
            {
                Location = AzureLocation.WestUS2,
            };
            var networkSecurityGroup = await _resourceGroup.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);

            //2. create Route table
            string routeTableName = SessionRecording.GenerateAssetName("routeTable-");
            RouteTableData routeTableData = new RouteTableData()
            {
                Location = AzureLocation.WestUS2,
            };
            var routeTable = await _resourceGroup.GetRouteTables().CreateOrUpdateAsync(WaitUntil.Completed, routeTableName, routeTableData);

            //3. create Virtual network
            string vnetName = SessionRecording.GenerateAssetName("vnet-");
            var vnetData = new VirtualNetworkData()
            {
                Location = "westus2",
                Subnets =
                {
                    new SubnetData() { Name = "subnet01", AddressPrefix = "10.10.1.0/24", },
                    new SubnetData()
                    {
                        Name = "ManagedInstance",
                        AddressPrefix = "10.10.2.0/24",
                        Delegations =
                        {
                            new ServiceDelegation() { ServiceName  = "Microsoft.Sql/managedInstances",Name="Microsoft.Sql/managedInstances" ,ResourceType="Microsoft.Sql"}
                        },
                        RouteTable = new RouteTableData(){ Id = routeTable.Value.Data.Id },
                        NetworkSecurityGroup = new NetworkSecurityGroupData(){ Id = networkSecurityGroup.Value.Data.Id },
                    }
                },
            };
            vnetData.AddressPrefixes.Add("10.10.0.0/16");
            var vnet = await _resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnetData);
            ResourceIdentifier subnetId = new ResourceIdentifier($"{vnet.Value.Data.Id.ToString()}/subnets/ManagedInstance");
            InstancePoolData data = new InstancePoolData(AzureLocation.WestUS2)
            {
                Sku = new SqlSku("GP_Gen5", "GeneralPurpose", null, "Gen5", null),
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
            Assert.AreEqual(instancePoolName,instancePool.Data.Name);
            Assert.AreEqual(8,instancePool.Data.VCores);

            // 2.CheckIfExist
            Assert.IsTrue(collection.Exists(instancePoolName));

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
            InstancePoolResource instancePool = await CreateInstancePool(instancePoolName);
            var list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, list.Count);

            await instancePool.DeleteAsync(WaitUntil.Completed);
            list = await _resourceGroup.GetInstancePools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, list.Count);
        }
    }
}
