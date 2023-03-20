// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationServiceTagTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private TenantResource _tenantResource;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;
        private Guid _subscriptionId;
        private string _resourceGroupName;

        public CommunicationServiceTagTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {;
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus")));

            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;

            _subscriptionId = Guid.Parse(rg.Id.SubscriptionId);
            _resourceGroupName = _resourceGroupIdentifier.ResourceGroupName;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            ArmClient = GetArmClient();
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _tenantResource = await ArmClient.GetTenants().GetAllAsync().FirstOrDefaultAsync(t=>t != null);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var communicationService in _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName))
            {
                await communicationService.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            await communication.AddTagAsync("testkey", "testvalue");
            communication = await collection.GetAsync(communicationServiceName);
            var tagValue = communication.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            await communication.AddTagAsync("testkey", "testvalue");
            communication = await collection.GetAsync(communicationServiceName);
            var tagValue = communication.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            await communication.RemoveTagAsync("testkey");
            communication = await collection.GetAsync(communicationServiceName);
            var tag = communication.Data.Tags;
            Assert.IsTrue(tag.Count == 0);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            await communication.AddTagAsync("testkey", "testvalue");
            communication = await collection.GetAsync(communicationServiceName);
            var tagValue = communication.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            var tag = new Dictionary<string, string>() { { "newtestkey", "newtestvalue" } };
            await communication.SetTagsAsync(tag);
            communication = await collection.GetAsync(communicationServiceName);
            tagValue = communication.Data.Tags.FirstOrDefault();
            Assert.IsTrue(communication.Data.Tags.Count == 1);
            Assert.AreEqual(tagValue.Key, "newtestkey");
            Assert.AreEqual(tagValue.Value, "newtestvalue");
        }
    }
}
