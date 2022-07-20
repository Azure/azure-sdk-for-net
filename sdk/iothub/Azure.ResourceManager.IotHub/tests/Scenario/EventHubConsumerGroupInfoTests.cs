// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotHub.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class EventHubConsumerGroupInfoTests : IotHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public EventHubConsumerGroupInfoTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("IotHub-RG-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            _resourceGroupIdentifier = rgLro.Value.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await Client.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        private async Task<EventHubConsumerGroupInfoResource> CreateConsumerGroup(IotHubDescriptionResource iothub, string consumerGroupName)
        {
            EventHubConsumerGroupInfoCreateOrUpdateContent data = new EventHubConsumerGroupInfoCreateOrUpdateContent(consumerGroupName) { };
            var consumerGroupInfos = await iothub.GetEventHubConsumerGroupInfos("events").CreateOrUpdateAsync(WaitUntil.Completed, consumerGroupName, data);
            return consumerGroupInfos.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string consumerGroupName = Recording.GenerateAssetName("consumerGroup-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var consumerGroupInfos = await CreateConsumerGroup(iothub,consumerGroupName);
            Assert.IsNotNull(consumerGroupInfos);
            Assert.AreEqual(consumerGroupName, consumerGroupInfos.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string consumerGroupName = Recording.GenerateAssetName("consumerGroup-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            await CreateConsumerGroup(iothub, consumerGroupName);
            bool flag = await iothub.GetEventHubConsumerGroupInfos("events").ExistsAsync(consumerGroupName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            var groupInfo = await iothub.GetEventHubConsumerGroupInfos("events").GetAsync("$Default");
            Assert.IsNotNull(groupInfo);
            Assert.AreEqual("$Default", groupInfo.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);

            var list = await iothub.GetEventHubConsumerGroupInfos("events").GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual("$Default", list.FirstOrDefault().Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            string consumerGroupName = Recording.GenerateAssetName("consumerGroup-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var deleteConsumerGroup = await CreateConsumerGroup(iothub, consumerGroupName);
            bool flag = await iothub.GetEventHubConsumerGroupInfos("events").ExistsAsync(consumerGroupName);
            Assert.IsTrue(flag);
            await deleteConsumerGroup.DeleteAsync(WaitUntil.Completed);
            flag = await iothub.GetEventHubConsumerGroupInfos("events").ExistsAsync(consumerGroupName);
            Assert.IsFalse(flag);
        }
    }
}
