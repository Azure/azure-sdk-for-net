// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTHub.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IoTHub.Tests.Scenario
{
    internal class IoTHubDescriptionTests : IoTHubManagementTestBase
    {
        private ResourceIdentifier _resourceGroupIdentifier;
        private ResourceGroupResource _resourceGroup;
        public IoTHubDescriptionTests(bool isAsync) : base(isAsync)
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
            await CreateIoTHub(_resourceGroup, iotHubName);
            bool isExisted = await _resourceGroup.GetIoTHubDescriptions().ExistsAsync(iotHubName);
            Assert.IsTrue(isExisted);
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var sku = new IoTHubSkuInfo("S1")
            {
                Name = "S1",
                Capacity = 1
            };
            IoTHubDescriptionData data = new IoTHubDescriptionData(AzureLocation.WestUS2, sku) { };
            var iotHub = await _resourceGroup.GetIoTHubDescriptions().CreateOrUpdateAsync(WaitUntil.Completed, iotHubName, data);
            Assert.IsNotNull(iotHub);
            Assert.AreEqual(iotHubName, iotHub.Value.Data.Name);
            Assert.AreEqual("westus2", iotHub.Value.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            await CreateIoTHub(_resourceGroup, iotHubName);
            var getIoTHub = await _resourceGroup.GetIoTHubDescriptions().GetAsync(iotHubName);
            Assert.IsNotNull(getIoTHub);
            Assert.AreEqual(iotHubName, getIoTHub.Value.Data.Name);
            Assert.AreEqual("westus2", getIoTHub.Value.Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            await CreateIoTHub(_resourceGroup, iotHubName);
            var list = await _resourceGroup.GetIoTHubDescriptions().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            //Assert.AreEqual(iotHubName, list.FirstOrDefault().Data.Name);
            //Assert.AreEqual("westus2", list.FirstOrDefault().Data.Location.Name);
        }

        [Test]
        [RecordedTest]
        [Ignore("System.ArgumentNullException : Value cannot be null. (Parameter 'id')")]
        public async Task Delete()
        {
            string iotHubName = Recording.GenerateAssetName("IotHub-");
            var deleteIoTHub = await CreateIoTHub(_resourceGroup, iotHubName);
            bool isExisted = await _resourceGroup.GetIoTHubDescriptions().ExistsAsync(iotHubName);
            Assert.IsTrue(isExisted);
            await deleteIoTHub.DeleteAsync(WaitUntil.Completed);
            isExisted = await _resourceGroup.GetIoTHubDescriptions().ExistsAsync(iotHubName);
            Assert.IsFalse(isExisted);
        }
    }
}
