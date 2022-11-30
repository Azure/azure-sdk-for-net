// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabric.Tests
{
    public class ServiceFabricClusterTests : ServiceFabricManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;

        private ServiceFabricClusterCollection _serviceFabricClusterCollection => _resourceGroup.GetServiceFabricClusters();

        public ServiceFabricClusterTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string clusterName = SessionRecording.GenerateAssetName("cluster");
            var cluster = await CreateServiceFabricCluster(_resourceGroup, clusterName);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(clusterName, cluster.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string clusterName = SessionRecording.GenerateAssetName("cluster");
            await CreateServiceFabricCluster(_resourceGroup, clusterName);
            bool flag = await _serviceFabricClusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string clusterName = SessionRecording.GenerateAssetName("cluster");
            await CreateServiceFabricCluster(_resourceGroup, clusterName);
            var cluster = await _serviceFabricClusterCollection.GetAsync(clusterName);
            Assert.IsNotNull(cluster);
            Assert.AreEqual(clusterName, cluster.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string clusterName = SessionRecording.GenerateAssetName("cluster");
            await CreateServiceFabricCluster(_resourceGroup, clusterName);
            var list = await _serviceFabricClusterCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string clusterName = SessionRecording.GenerateAssetName("cluster");
            var cluster = await CreateServiceFabricCluster(_resourceGroup, clusterName);
            bool flag = await _serviceFabricClusterCollection.ExistsAsync(clusterName);
            Assert.IsTrue(flag);

            await cluster.DeleteAsync(WaitUntil.Completed);
            flag = await _serviceFabricClusterCollection.ExistsAsync(clusterName);
            Assert.IsFalse(flag);
        }
    }
}
