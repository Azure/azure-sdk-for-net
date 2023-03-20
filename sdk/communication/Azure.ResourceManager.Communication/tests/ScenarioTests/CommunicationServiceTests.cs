// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Communication.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationServiceTests : CommunicationManagementClientLiveTestBase
    {
        private TenantResource _tenantResource;
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;
        private Guid _subscriptionId;
        private string _resourceGroupName;

        public CommunicationServiceTests(bool isAsync)
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
            _tenantResource = await ArmClient.GetTenants().GetAllAsync().FirstOrDefaultAsync(t => t != null);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var communicationService in _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName).GetAllAsync())
            {
                await communicationService.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task GetKeys()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            var keys = await communication.GetKeysAsync();
            Assert.NotNull(keys.Value.PrimaryKey);
            Assert.NotNull(keys.Value.SecondaryKey);
            Assert.NotNull(keys.Value.PrimaryConnectionString);
            Assert.NotNull(keys.Value.SecondaryConnectionString);
        }

        [Test]
        public async Task RegenerateKey()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            var keys = await communication.GetKeysAsync();
            string primaryKey = keys.Value.PrimaryKey;
            string secondaryKey = keys.Value.SecondaryKey;
            string primaryConnectionString = keys.Value.PrimaryConnectionString;
            string secondaryConnectionString = keys.Value.SecondaryConnectionString;
            var parameter = new RegenerateCommunicationServiceKeyContent() { KeyType = CommunicationServiceKeyType.Primary };
            var newkeys = await communication.RegenerateKeyAsync(parameter);
            // values are being sanitized, so comparing "Sanitized" to "Sanitized" will always be true. only checking for not null
            // Assert.AreNotEqual(primaryKey, newkeys.Value.PrimaryKey);
            // Assert.AreNotEqual(primaryConnectionString, newkeys.Value.PrimaryConnectionString);
            Assert.IsFalse(string.IsNullOrEmpty(newkeys.Value.PrimaryKey));
            Assert.IsFalse(string.IsNullOrEmpty(newkeys.Value.PrimaryConnectionString));
            parameter = new RegenerateCommunicationServiceKeyContent() { KeyType = CommunicationServiceKeyType.Secondary };
            newkeys = await communication.RegenerateKeyAsync(parameter);
            // Assert.AreNotEqual(secondaryKey, newkeys.Value.SecondaryKey);
            // Assert.AreNotEqual(secondaryConnectionString, newkeys.Value.SecondaryConnectionString);
            Assert.IsFalse(string.IsNullOrEmpty(newkeys.Value.SecondaryKey));
            Assert.IsFalse(string.IsNullOrEmpty(newkeys.Value.SecondaryConnectionString));
        }

        [Test]
        public async Task LinkNotificationHub()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communication = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
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
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            bool exists = await collection.ExistsAsync(communicationServiceName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communicationService = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            Assert.IsNotNull(communicationService);
            Assert.AreEqual(communicationServiceName, communicationService.Data.Name);
            Assert.AreEqual(_location.ToString(), communicationService.Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), communicationService.Data.DataLocation.ToString());
        }

        [Test]
        public async Task Update()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var communication1 = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
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
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            var communicationService = await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            await communicationService.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(communicationServiceName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string communicationServiceName = Recording.GenerateAssetName("communication-service-");
            var collection = _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName);
            await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
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
            await CreateDefaultCommunicationServices(_subscriptionId, _resourceGroupName, communicationServiceName, _tenantResource);
            var list = await _tenantResource.GetCommunicationServiceResources(_subscriptionId, _resourceGroupName).GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(communicationServiceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location.ToString(), list.FirstOrDefault().Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), list.FirstOrDefault().Data.DataLocation.ToString());
        }
    }
}
