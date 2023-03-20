// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Communication;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationServiceTagTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;

        public CommunicationServiceTagTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus")));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            ArmClient = GetArmClient();
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var collection = _resourceGroup.GetCommunicationServiceResources(Guid.Parse(_resourceGroup.Id.SubscriptionId), _resourceGroup.Id.ResourceGroupName);

            await foreach (var communicationService in collection)
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
            var collection = _resourceGroup.GetCommunicationServiceResources(Guid.Parse(_resourceGroup.Id.SubscriptionId), _resourceGroup.Id.ResourceGroupName);
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
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
            var collection = _resourceGroup.GetCommunicationServiceResources(Guid.Parse(_resourceGroup.Id.SubscriptionId), _resourceGroup.Id.ResourceGroupName);
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
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
            var collection = _resourceGroup.GetCommunicationServiceResources(Guid.Parse(_resourceGroup.Id.SubscriptionId), _resourceGroup.Id.ResourceGroupName);
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
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
