// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private ResourceGroupResource _resourceGroup;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _location;
        private string _dataLocation;

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
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task Setup()
        {
            ArmClient = GetArmClient();
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            var list = await _resourceGroup.GetEmailServiceResources().GetAllAsync().ToEnumerableAsync();
            foreach (var emailService in list)
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
            var collection = _resourceGroup.GetEmailServiceResources();
            var email = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.That(tagValue.Key, Is.EqualTo("testkey"));
            Assert.That(tagValue.Value, Is.EqualTo("testvalue"));
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _resourceGroup.GetEmailServiceResources();
            var email = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.That(tagValue.Key, Is.EqualTo("testkey"));
            Assert.That(tagValue.Value, Is.EqualTo("testvalue"));
            await email.RemoveTagAsync("testkey");
            email = await collection.GetAsync(emailServiceName);
            var tag = email.Data.Tags;
            Assert.That(tag.Count, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _resourceGroup.GetEmailServiceResources();
            var email = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            await email.AddTagAsync("testkey", "testvalue");
            email = await collection.GetAsync(emailServiceName);
            var tagValue = email.Data.Tags.FirstOrDefault();
            Assert.That(tagValue.Key, Is.EqualTo("testkey"));
            Assert.That(tagValue.Value, Is.EqualTo("testvalue"));
            var tag = new Dictionary<string, string>() { { "newtestkey", "newtestvalue" } };
            await email.SetTagsAsync(tag);
            email = await collection.GetAsync(emailServiceName);
            tagValue = email.Data.Tags.FirstOrDefault();
            Assert.That(email.Data.Tags.Count, Is.EqualTo(1));
            Assert.That(tagValue.Key, Is.EqualTo("newtestkey"));
            Assert.That(tagValue.Value, Is.EqualTo("newtestvalue"));
        }

        [Test]
        public async Task Exists()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _resourceGroup.GetEmailServiceResources();
            await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            bool exists = await collection.ExistsAsync(emailServiceName);
            Assert.That(exists, Is.True);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var emailService = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            Assert.That(emailService, Is.Not.Null);
            Assert.That(emailService.Data.Name, Is.EqualTo(emailServiceName));
            Assert.That(emailService.Data.Location.ToString(), Is.EqualTo(_location.ToString()));
            Assert.That(emailService.Data.DataLocation.ToString(), Is.EqualTo(_dataLocation.ToString()));
        }

        [Test]
        public async Task Update()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var emailService1 = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            var patch = new EmailServiceResourcePatch();
            var emailService2 = (await emailService1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.That(emailService2, Is.Not.Null);
            Assert.That(emailService1.Data.Name, Is.EqualTo(emailService2.Data.Name));
        }

        [Test]
        public async Task Delete()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _resourceGroup.GetEmailServiceResources();
            var emailService = await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            await emailService.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(emailServiceName);
            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task Get()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            var collection = _resourceGroup.GetEmailServiceResources();
            await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            var emailService = await collection.GetAsync(emailServiceName);
            Assert.That(emailService, Is.Not.Null);
            Assert.That(emailService.Value.Data.Name, Is.EqualTo(emailServiceName));
            Assert.That(emailService.Value.Data.Location.ToString(), Is.EqualTo(_location.ToString()));
            Assert.That(emailService.Value.Data.DataLocation.ToString(), Is.EqualTo(_dataLocation.ToString()));
        }

        [Test]
        public async Task GetAll()
        {
            string emailServiceName = Recording.GenerateAssetName("email-service-");
            await CreateDefaultEmailServices(emailServiceName, _resourceGroup);
            var list = await _resourceGroup.GetEmailServiceResources().GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list.FirstOrDefault().Data.Name, Is.EqualTo(emailServiceName));
            Assert.That(list.FirstOrDefault().Data.Location.ToString(), Is.EqualTo(_location.ToString()));
            Assert.That(list.FirstOrDefault().Data.DataLocation.ToString(), Is.EqualTo(_dataLocation.ToString()));
        }
    }
}
