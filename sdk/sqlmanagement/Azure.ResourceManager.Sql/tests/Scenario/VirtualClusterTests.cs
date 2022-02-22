﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests.Scenario
{
    public class VirtualClusterTests : SqlManagementClientBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;

        public VirtualClusterTests(bool isAsync)
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(true, SessionRecording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
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
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(true);
            }
        }

        [Test]
        [RecordedTest]
        public async Task VirtualClusterApiTests()
        {
            //Because MangedInstance deployment takes a lot of time(more than 4.5 hours), the test cases are not separated separately
            // Create Virtual Cluster
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string networkSecurityGroupName = Recording.GenerateAssetName("network-security-group-");
            string routeTableName = Recording.GenerateAssetName("route-table-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, networkSecurityGroupName, routeTableName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            // 1.CheckIfExist
            string virtualClusterName = (await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync()).FirstOrDefault().Data.Name;
            Assert.IsTrue(await _resourceGroup.GetVirtualClusters().ExistsAsync(virtualClusterName));
            Assert.IsFalse(await _resourceGroup.GetVirtualClusters().ExistsAsync(virtualClusterName + "0"));

            // 2.Get
            var getVirtualCluster = await _resourceGroup.GetVirtualClusters().GetAsync(virtualClusterName);
            Assert.IsNotNull(getVirtualCluster.Value.Data);
            Assert.AreEqual(virtualClusterName, getVirtualCluster.Value.Data.Name);
            Assert.AreEqual("westus2", getVirtualCluster.Value.Data.Location.ToString());

            // 3.GetAll
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(virtualClusterName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual("westus2", list.FirstOrDefault().Data.Location.ToString());

            // 4.Delete - [Ignore("Virtual Cluster have active dependent resources, The parent class should be deleted directly")]
            //var deleteVirtualCluster = (await _resourceGroup.GetVirtualClusters().GetAsync(virtualClusterName)).Value;
            //await deleteVirtualCluster.DeleteAsync();
            //list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            //Assert.IsEmpty(list);
        }
    }
}
