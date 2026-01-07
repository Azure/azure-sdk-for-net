// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class VirtualClusterTests : SqlManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public VirtualClusterTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            var lro = await client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("Sql-RG-"), new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroup = lro.Value;
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetManagedInstances().GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        [RecordedTest]
        public async Task VirtualClusterApiTests()
        {
            //Because MangedInstance deployment takes a lot of time(more than 4.5 hours), the test cases are not separated separately
            // Create Virtual Cluster
            string managedInstanceName = Recording.GenerateAssetName("managed-instance-");
            string vnetName = Recording.GenerateAssetName("vnet-");
            var managedInstance = await CreateDefaultManagedInstance(managedInstanceName, vnetName, AzureLocation.WestUS2, _resourceGroup);
            Assert.IsNotNull(managedInstance.Data);

            // 1.CheckIfExist
            string virtualClusterName = (await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync()).FirstOrDefault().Data.Name;
            Assert.That((bool)await _resourceGroup.GetVirtualClusters().ExistsAsync(virtualClusterName), Is.True);
            Assert.That((bool)await _resourceGroup.GetVirtualClusters().ExistsAsync(virtualClusterName + "0"), Is.False);

            // 2.Get
            var getVirtualCluster = await _resourceGroup.GetVirtualClusters().GetAsync(virtualClusterName);
            Assert.IsNotNull(getVirtualCluster.Value.Data);
            Assert.That(getVirtualCluster.Value.Data.Name, Is.EqualTo(virtualClusterName));
            Assert.That(getVirtualCluster.Value.Data.Location.ToString(), Is.EqualTo("westus2"));

            // 3.GetAll
            var list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(virtualClusterName));
            Assert.That(list.FirstOrDefault().Data.Location.ToString(), Is.EqualTo("westus2"));

            // 4.Delete - [Ignore("Virtual Cluster have active dependent resources, The parent class should be deleted directly")]
            //var deleteVirtualCluster = (await _resourceGroup.GetVirtualClusters().GetAsync(virtualClusterName)).Value;
            //await deleteVirtualCluster.DeleteAsync();
            //list = await _resourceGroup.GetVirtualClusters().GetAllAsync().ToEnumerableAsync();
            //Assert.IsEmpty(list);
        }
    }
}
