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
using NUnit.Framework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class EmailServiceTests : CommunicationManagementClientLiveTestBase
    {
        private TenantResource _tenantResource;
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;
        private Guid _subscriptionId;
        private string _resourceGroupName;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailServiceTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public EmailServiceTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus2")));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;
            _subscriptionId = Guid.Parse(rg.Id.SubscriptionId);
            _resourceGroupName = _resourceGroupIdentifier.ResourceGroupName;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            ArmClient = GetArmClient();

            _tenantResource = await ArmClient.GetTenants().GetAllAsync().FirstOrDefaultAsync(t => t != null);
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName).GetAllAsync();
            await foreach (var emailService in list)
            {
                await emailService.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var email = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var email = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            await email.RemoveTagAsync("testkey");
            email = await collection.GetAsync(emailServiceName);
            var tag = email.Data.Tags;
            Assert.IsTrue(tag.Count == 0);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var email = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            var tag = new Dictionary<string, string>() { { "newtestkey", "newtestvalue" } };
            await email.SetTagsAsync(tag);
            email = await collection.GetAsync(emailServiceName);
            tagValue = email.Data.Tags.FirstOrDefault();
            Assert.IsTrue(email.Data.Tags.Count == 1);
            Assert.AreEqual(tagValue.Key, "newtestkey");
            Assert.AreEqual(tagValue.Value, "newtestvalue");
        }

        [Test]
        public async Task Exists()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var email = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            bool exists = await collection.ExistsAsync(emailServiceName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var emailService = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            Assert.IsNotNull(emailService);
            Assert.AreEqual(emailServiceName, emailService.Data.Name);
            Assert.AreEqual(_location.ToString(), emailService.Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), emailService.Data.DataLocation.ToString());
        }

        [Test]
        public async Task Update()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var emailService1 = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            var patch = new EmailServiceResourcePatch();
            var emailService2 = (await emailService1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.IsNotNull(emailService2);
            Assert.AreEqual(emailService1.Data.Name, emailService2.Data.Name);
        }

        [Test]
        public async Task Delete()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var emailService = await CreateDefaultEmailServices(_subscriptionId, _resourceGroupName, emailServiceName, _tenantResource);
            await emailService.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(emailServiceName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            var emailService = await collection.GetAsync(emailServiceName);
            Assert.IsNotNull(emailService);
            Assert.AreEqual(emailServiceName, emailService.Value.Data.Name);
            Assert.AreEqual(_location.ToString(), emailService.Value.Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), emailService.Value.Data.DataLocation.ToString());
        }

        [Test]
        public void GetAll()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var list = _tenantResource.GetEmailServiceResources(_subscriptionId, _resourceGroupName);
            Assert.IsNotEmpty(list);
            Assert.AreEqual(emailServiceName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location.ToString(), list.FirstOrDefault().Data.Location.ToString());
            Assert.AreEqual(_dataLocation.ToString(), list.FirstOrDefault().Data.DataLocation.ToString());
        }
    }
}
