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
    internal class IotHubPrivateEndpointGroupInformationTests : IotHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public IotHubPrivateEndpointGroupInformationTests(bool isAsync) : base(isAsync)
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

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            bool isExisted = await iothub.GetAllIotHubPrivateEndpointGroupInformation().ExistsAsync("iotHub");
            Assert.IsTrue(isExisted);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            string groupId = $"{iothub.Data.Id}/PrivateLinkResources/iotHub";
            var groupIdInfo = await iothub.GetAllIotHubPrivateEndpointGroupInformation().GetAsync("iotHub");
            Assert.IsNotNull(groupIdInfo);
            Assert.AreEqual(groupId, groupIdInfo.Value.Data.Id.ToString());
            Assert.AreEqual("iotHub", groupIdInfo.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var iothub = await CreateIotHub(_resourceGroup, iotHubName);
            var list = await iothub.GetAllIotHubPrivateEndpointGroupInformation().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            Assert.AreEqual("iotHub", list.FirstOrDefault().Data.Name);
        }
    }
}
