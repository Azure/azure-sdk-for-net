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
        private ResourceGroupResource _resourceGroup;
        private string _iPGroupName;

        private ResourceIdentifier _resourceGroupIdentifier;

        public IpGroupTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            SubscriptionResource subscription = await GlobalClient.GetDefaultSubscriptionAsync();
            var rgLro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName("IpGroupRG-"), new ResourceGroupData(AzureLocation.WestUS2));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _iPGroupName = SessionRecording.GenerateAssetName("IpGroupRG-");
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
            _resourceGroup = await client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (await _resourceGroup.GetIPGroups().ExistsAsync(_iPGroupName))
            {
                var ipGroup = await _resourceGroup.GetIPGroups().GetAsync(_iPGroupName);
                await ipGroup.Value.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<ArmOperation<IPGroupResource>> CreateIpGroup(string ipGroupName)
        {
            var container = _resourceGroup.GetIPGroups();
            var data = new IPGroupData();
            data.Location = AzureLocation.WestUS2;
            var ipGroup = await container.CreateOrUpdateAsync(WaitUntil.Completed, ipGroupName, data);
            return ipGroup;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var ipGroup = await CreateIpGroup(_iPGroupName);
            Assert.That(ipGroup.Value.Data, Is.Not.Null);
            Assert.That(ipGroup.Value.Data.Name, Is.EqualTo(_iPGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateIpGroup(_iPGroupName);
            var ipGroup = await _resourceGroup.GetIPGroups().GetAsync(_iPGroupName);
            Assert.That(ipGroup.Value.Data, Is.Not.Null);
            Assert.That(ipGroup.Value.Data.Name, Is.EqualTo(_iPGroupName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAll ()
        {
            await CreateIpGroup(_iPGroupName);
            var iPGroupList = await _resourceGroup.GetIPGroups().GetAllAsync().ToEnumerableAsync();
            Assert.That(iPGroupList, Has.Count.EqualTo(1));
        }

        [Test]
        [RecordedTest]
        public async Task CheckIfExist()
        {
            await CreateIpGroup(_iPGroupName);
            Assert.That((bool)await _resourceGroup.GetIPGroups().ExistsAsync(_iPGroupName), Is.True);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            var ipGroup  = await CreateIpGroup(_iPGroupName);
            await ipGroup.Value.DeleteAsync(WaitUntil.Completed);
            var ipGroupList = await _resourceGroup.GetIPGroups().GetAllAsync().ToEnumerableAsync();
            Assert.That(ipGroupList, Is.Empty);
        }
    }
}
