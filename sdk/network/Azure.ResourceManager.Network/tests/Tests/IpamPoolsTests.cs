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
        private ResourceGroupResource _resourceGroup;
        private NetworkManagerResource _networkManager;
        private string _ipamPoolName;

        private ResourceIdentifier _resourceGroupId;
        private ResourceIdentifier _networkManagerId;

        public IpamPoolsTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("ipamPoolRG-"), new ResourceGroupData(AzureLocation.EastUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupId = rg.Id;

            var networkManagerLro = await rg.GetNetworkManagers().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("networkManager-"), new NetworkManagerData());
            NetworkManagerResource networkManager = networkManagerLro.Value;
            _networkManagerId = networkManager.Id;

            _ipamPoolName = SessionRecording.GenerateAssetName("ipamPool-");
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(WaitUntil.Completed);
        }

        [SetUp]
        public async Task TestSetUp()
        {
            var client = GetArmClient();
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupId).GetAsync();
            _networkManager = await client.GetNetworkManagerResource(_networkManagerId).GetAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            if (await _networkManager.GetIpamPools().ExistsAsync(_ipamPoolName))
            {
                IpamPoolResource ipamPool = await _networkManager.GetIpamPools().GetAsync(_ipamPoolName);
                await ipamPool.DeleteAsync(WaitUntil.Completed);
            }
        }

        public async Task<IpamPoolResource> CreateIpamPoolAsync()
        {
            IpamPoolData ipamPoolData = new IpamPoolData();
            ipamPoolData.Location = AzureLocation.EastUS2;
            List<string> addressPrefixes = new List<string>() { "10.0.0.0/16" };
            ipamPoolData.Properties = new IpamPoolProperties()
            {
                Description = string.Empty,
                ParentPoolName = string.Empty,
                AddressPrefixes = addressPrefixes,
            };
            var ipamPoolLro = await (await _networkManager.GetIpamPools().CreateOrUpdateAsync(WaitUntil.Completed, _ipamPoolName, ipamPoolData)).WaitForCompletionAsync();
            return ipamPoolLro.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            IpamPoolResource ipamPool = await CreateIpamPoolAsync();
            Assert.IsNotNull(ipamPool.Data);
            Assert.AreEqual(_ipamPoolName, ipamPool.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateIpamPoolAsync();
            var ipamPool = await _networkManager.GetIpamPools().GetAsync(_ipamPoolName);
            Assert.IsNotNull(ipamPool.Value.Data);
            Assert.AreEqual(_ipamPoolName, ipamPool.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateIpamPoolAsync();
            List<IpamPoolResource> ipamPoolsList = await _networkManager.GetIpamPools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, ipamPoolsList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            IpamPoolResource ipamPool = await CreateIpamPoolAsync();
            List<IpamPoolResource> ipamPoolsList = await _networkManager.GetIpamPools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, ipamPoolsList.Count);

            await ipamPool.DeleteAsync(WaitUntil.Completed);
            ipamPoolsList = await _networkManager.GetIpamPools().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(0, ipamPoolsList.Count);
        }
    }
}
