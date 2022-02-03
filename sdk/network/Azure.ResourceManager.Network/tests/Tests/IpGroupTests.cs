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
    public class IpGroupTests : NetworkServiceClientTestBase
    {
        private ResourceGroup _resourceGroup;
        private string _ipGroupName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public IpGroupTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            Subscription subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(true,SessionRecording.GenerateAssetName("IpGroupRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _ipGroupName = SessionRecording.GenerateAssetName("IpGroupRG-");
            await StopSessionRecordingAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await _resourceGroup.DeleteAsync(true);
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
            if (await _resourceGroup.GetIpGroups().ExistsAsync(_ipGroupName))
            {
                var ipGroup = await _resourceGroup.GetIpGroups().GetAsync(_ipGroupName);
                await ipGroup.Value.DeleteAsync(true);
            }
        }

        private async Task<IpGroupCreateOrUpdateOperation> CreateIpGroup(string ipGroupName)
        {
            var container = _resourceGroup.GetIpGroups();
            var data = new IpGroupData();
            data.Location = AzureLocation.WestUS2;
            var ipGroup = await container.CreateOrUpdateAsync(true, ipGroupName, data);
            return ipGroup;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var ipGroup = await CreateIpGroup(_ipGroupName);
            Assert.IsNotNull(ipGroup.Value.Data);
            Assert.AreEqual(_ipGroupName, ipGroup.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateIpGroup(_ipGroupName);
            var ipGroup = await _resourceGroup.GetIpGroups().GetAsync(_ipGroupName);
            Assert.IsNotNull(ipGroup.Value.Data);
            Assert.AreEqual(_ipGroupName, ipGroup.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll ()
        {
            await CreateIpGroup(_ipGroupName);
            var ipGroupList = await _resourceGroup.GetIpGroups().GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, ipGroupList.Count);
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            await CreateIpGroup(_ipGroupName);
            Assert.IsTrue(await _resourceGroup.GetIpGroups().ExistsAsync(_ipGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var ipGroup  = await CreateIpGroup(_ipGroupName);
            await ipGroup.Value.DeleteAsync(true);
            var ipGroupList = await _resourceGroup.GetIpGroups().GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(ipGroupList);
        }
    }
}
