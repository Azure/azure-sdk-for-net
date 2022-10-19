// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ServiceFabric.Tests
{
    internal class ServiceFabricApplicationTests : ServiceFabricManagementTestBase
    {
        private ResourceIdentifier _serviceFabricClusterIdentifier;
        private ServiceFabricClusterResource _serviceFabricCluster;

        private ServiceFabricApplicationCollection _serviceFabricApplicationCollection => _serviceFabricCluster.GetServiceFabricApplications();

        public ServiceFabricApplicationTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.WestUS2));
            var cluster = await CreateServiceFabricCluster(rgLro.Value, SessionRecording.GenerateAssetName("cluster"));
            _serviceFabricClusterIdentifier = cluster.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _serviceFabricCluster = await Client.GetServiceFabricClusterResource(_serviceFabricClusterIdentifier).GetAsync();
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _serviceFabricApplicationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
