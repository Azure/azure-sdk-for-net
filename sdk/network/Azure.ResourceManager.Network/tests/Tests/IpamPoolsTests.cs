// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class IpamPoolsTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private string _ipamPoolName;
        private IpamPoolResource _ipamPool;
        private string _staticCidrName;
        private StaticCidrResource _staticCidr;
        private AzureLocation _location = AzureLocation.CentralUS;
        private ResourceIdentifier _networkManagerId;

        public IpamPoolsTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            // Get the default subscription
            _subscription = await GlobalClient.GetDefaultSubscriptionAsync();

            // Create a resource group
            string resourceGroupName = SessionRecording.GenerateAssetName("ipamPool-dotnet-sdk-tests-RG-");
            _resourceGroup = await _subscription.CreateResourceGroupAsync(resourceGroupName, _location);

            // Create a network manager
            string networkManagerName = SessionRecording.GenerateAssetName("networkManager-");
            _networkManager = await _resourceGroup.CreateNetworkManagerAsync(
                networkManagerName,
                _location,
                new List<string> { _subscription.Data.Id },
                new List<NetworkConfigurationDeploymentType> { });

            _networkManagerId = _networkManager.Id;
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _ipamPoolName = SessionRecording.GenerateAssetName("ipamPool-");
            _ipamPool = await _resourceGroup.CreateIpamPoolAsync(_networkManager, _ipamPoolName, _location, new List<string>() { "10.0.0.0/16" });
            _staticCidrName = SessionRecording.GenerateAssetName("staticCidr-");
            _staticCidr = await _ipamPool.CreateStaticCidrAsync(_staticCidrName, new List<string>() { "10.0.0.0/24" });
        }

        [TearDown]
        public async Task Teardown()
        {
            if (await _networkManager.GetIpamPools().ExistsAsync(_ipamPoolName))
            {
                await _ipamPool.DeleteIpamPoolAsync(_networkManager);
            }
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            var ipamPool = await _networkManager.GetIpamPools().GetAsync(_ipamPoolName);
            Assert.IsNotNull(ipamPool.Value.Data);
            Assert.AreEqual(_ipamPoolName, ipamPool.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            List<IpamPoolResource> ipamPoolsList = await _networkManager.GetIpamPools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, ipamPoolsList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            await _ipamPool.DeleteIpamPoolAsync(_networkManager);
            var ipamPoolsList = await _networkManager.GetIpamPools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, ipamPoolsList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetListAssociation()
        {
            var associations = await _ipamPool.PostListAssociatedResourcesAsync();
            Assert.AreEqual(1, associations.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetPoolUsage()
        {
            var usage = await _ipamPool.PostGetPoolUsageAsync();
            Assert.AreEqual(_ipamPool.Data.Properties.AddressPrefixes, usage.AddressPrefixes);
        }

        [Test]
        [RecordedTest]
        public async Task GetStaticCidrs()
        {
            StaticCidrResource staticCidr = await _ipamPool.GetStaticCidrs().GetAsync(_staticCidrName);
            Assert.IsNotNull(staticCidr.Data);
            Assert.AreEqual(_staticCidrName, staticCidr.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllStaticCidrs()
        {
            List<StaticCidrResource> staticCidrsList = await _ipamPool.GetStaticCidrs().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, staticCidrsList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task DeleteStaticCidr()
        {
            await _ipamPool.DeleteStaticCidrAsync(_staticCidr);
            var staticCidrsList = await _ipamPool.GetStaticCidrs().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, staticCidrsList.Count);
        }
    }
}
