// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationServiceTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;

        public CommunicationServiceTests(bool isAsync)
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
            await foreach (var communicationService in _resourceGroup.GetCommunicationServiceResources())
            {
                await communicationService.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testMsi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData("westus2");
            var response = await ArmClient.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, userIdentityId, input);
            return response.Value;
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
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
            var collection = _resourceGroup.GetCommunicationServiceResources();
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
            var collection = _resourceGroup.GetCommunicationServiceResources();
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

        [Test]
        public async Task CreateResourceWithManagedIdentity()
        {
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            CommunicationServiceResourceData data = new CommunicationServiceResourceData(ResourceLocation)
            {
                DataLocation = ResourceDataLocation,
                Identity = identity
            };
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communicationServiceLro = await _resourceGroup.GetCommunicationServiceResources().CreateOrUpdateAsync(WaitUntil.Completed, communicationServiceName, data);
            var resource = communicationServiceLro.Value;
            Assert.AreEqual(resource.Data.Identity.ManagedServiceIdentityType, ManagedServiceIdentityType.SystemAssignedUserAssigned);
        }

        [Test]
        public async Task GetKeys()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var keys = await communication.GetKeysAsync();
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);
        }

        // [Test]
        public async Task RegenerateKey()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var keys = await communication.GetKeysAsync();
            string primaryKey = keys.Value.PrimaryKey;
            string secondaryKey = keys.Value.SecondaryKey;
            string primaryConnectionString = keys.Value.PrimaryConnectionString;
            string secondaryConnectionString = keys.Value.SecondaryConnectionString;
            var parameter = new RegenerateCommunicationServiceKeyContent() { KeyType = CommunicationServiceKeyType.Primary };
            var newkeys = await communication.RegenerateKeyAsync(parameter);
            Assert.AreEqual(primaryKey, newkeys.Value.PrimaryKey);
            Assert.NotNull(primaryConnectionString, keys.Value.PrimaryConnectionString);
            parameter = new RegenerateCommunicationServiceKeyContent() { KeyType = CommunicationServiceKeyType.Secondary };
            newkeys = await communication.RegenerateKeyAsync(parameter);
            Assert.NotNull(secondaryKey, keys.Value.SecondaryKey);
            Assert.NotNull(secondaryConnectionString, keys.Value.SecondaryConnectionString);
        }

        [Test]
        public async Task LinkNotificationHub()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
            var communication = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            // Need to create a NotificationHub first
            var parameter = new LinkNotificationHubContent(new ResourceIdentifier(((CommunicationManagementTestEnvironment)TestEnvironment).NotificationHubsResourceId),
                ((CommunicationManagementTestEnvironment)TestEnvironment).NotificationHubsConnectionString);
            var hub = await communication.LinkNotificationHubAsync(parameter);
            Assert.NotNull(hub.Value.ResourceId);
        }

        [Test]
        public async Task Exists()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
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
            Assert.AreEqual(_location.ToString(), communicationService.Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), communicationService.Data.DataLocation.ToString());
        }

        [Test]
        public async Task Update()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communication1 = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var patch = new CommunicationServiceResourcePatch()
            {
                Tags = { { "newtag", "newvalue" } }
            };
            var communication2 = (await communication1.UpdateAsync(patch)).Value;
            Assert.IsNotNull(communication2);
            Assert.AreEqual("newtag", communication2.Data.Tags.FirstOrDefault().Key);
            Assert.AreEqual(communication1.Data.Name, communication2.Data.Name);
        }

        [Test]
        public async Task Delete()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
            var communicationService = await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            await communicationService.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(communicationServiceName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _resourceGroup.GetCommunicationServiceResources();
            await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var communicationService = await collection.GetAsync(communicationServiceName);
            Assert.IsNotNull(communicationService);
            Assert.AreEqual(communicationServiceName, communicationService.Value.Data.Name);
            Assert.AreEqual(_location.ToString(), communicationService.Value.Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), communicationService.Value.Data.DataLocation.ToString());
        }

        [Test]
        public async Task GetAll()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            await CreateDefaultCommunicationServices(communicationServiceName, _resourceGroup);
            var list = await _resourceGroup.GetCommunicationServiceResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(communicationServiceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location.ToString(), list.FirstOrDefault().Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), list.FirstOrDefault().Data.DataLocation.ToString());
        }
    }
}
