// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationCrudTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroup _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;

        public CommunicationCrudTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(true,SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus")));
            ResourceGroup rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            ArmClient = GetArmClient();
            _resourceGroup = await ArmClient.GetResourceGroup(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var communicationService in _resourceGroup.GetCommunicationServices())
            {
                await communicationService.DeleteAsync(true);
            }
        }

        [Test]
        public async Task Exists()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServices();
            await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            bool exists = await collection.ExistsAsync(communicationServiceName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communicationService = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            Assert.IsNotNull(communicationService);
            Assert.AreEqual(communicationServiceName, communicationService.Data.Name);
            Assert.AreEqual(_location, communicationService.Data.Location);
            Assert.AreEqual(_dataLocation, communicationService.Data.DataLocation);
        }

        [Test]
        public async Task Delete()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServices();
            var communicationService = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            await communicationService.DeleteAsync(true);
            bool exists = await collection.ExistsAsync(communicationServiceName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServices();
            await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var communicationService = await collection.GetAsync(communicationServiceName);
            Assert.IsNotNull(communicationService);
            Assert.AreEqual(communicationServiceName, communicationService.Value.Data.Name);
            Assert.AreEqual(_location, communicationService.Value.Data.Location);
            Assert.AreEqual(_dataLocation, communicationService.Value.Data.DataLocation);
        }

        [Test]
        public async Task GetAll()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var list = await _resourceGroup.GetCommunicationServices().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(communicationServiceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location, list.FirstOrDefault().Data.Location);
            Assert.AreEqual(_dataLocation, list.FirstOrDefault().Data.DataLocation);
        }
    }
}
