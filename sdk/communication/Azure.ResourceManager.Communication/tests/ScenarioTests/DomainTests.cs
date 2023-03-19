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
using Azure.ResourceManager.Communication;

namespace Azure.ResourceManager.Communication.Tests
{
    public class DomainTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EmailServiceResource _emailService;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _emailServiceName;
        private string _location;
        private string _dataLocation;

        public DomainTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, SessionRecording.GenerateAssetName(ResourceGroupPrefix), new ResourceGroupData(new AzureLocation("westus")));
            ResourceGroupResource rg = rgLro.Value;
            _resourceGroupIdentifier = rg.Id;
            _emailServiceName = SessionRecording.GenerateAssetName("email-test");
            await CreateDefaultEmailServices(_emailServiceName, rg);
            _location = ResourceLocation;
            _dataLocation = ResourceDataLocation;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            ArmClient = GetArmClient();
            _resourceGroup = await ArmClient.GetResourceGroupResource(_resourceGroupIdentifier).GetAsync();
            _emailService = _resourceGroup.GetEmailServiceResource(Guid.Parse(_resourceGroup.Id.SubscriptionId), _resourceGroup.Id.ResourceGroupName, _emailServiceName);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var domain in _emailService.GetCommunicationDomainResources().GetAllAsync())
            {
                await domain.DeleteAsync(WaitUntil.Completed);
            }
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.AddTagAsync("testkey", "testvalue");
            domain = await collection.GetAsync(domainName);
            var tagValue = domain.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.AddTagAsync("testkey", "testvalue");
            domain = await collection.GetAsync(domainName);
            var tagValue = domain.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            await domain.RemoveTagAsync("testkey");
            domain = await collection.GetAsync(domainName);
            var tag = domain.Data.Tags;
            Assert.IsTrue(tag.Count == 0);
        }

        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(ArmClient, useTagResource);
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.AddTagAsync("testkey", "testvalue");
            domain = await collection.GetAsync(domainName);
            var tagValue = domain.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
            var tag = new Dictionary<string, string>() { { "newtestkey", "newtestvalue" } };
            await domain.SetTagsAsync(tag);
            domain = await collection.GetAsync(domainName);
            tagValue = domain.Data.Tags.FirstOrDefault();
            Assert.IsTrue(domain.Data.Tags.Count == 1);
            Assert.AreEqual(tagValue.Key, "newtestkey");
            Assert.AreEqual(tagValue.Value, "newtestvalue");
        }

        [Test]
        public async Task Exists()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            await CreateDefaultDomain(domainName, _emailService);
            bool exists = await collection.ExistsAsync(domainName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var domain = await CreateDefaultDomain(domainName, _emailService);
            Assert.IsNotNull(domain);
            Assert.AreEqual(domainName, domain.Data.Name);
            Assert.AreEqual(_location.ToString().ToLower(), domain.Data.Location.ToString().ToLower());
            Assert.AreEqual(_dataLocation.ToString().ToLower(), domain.Data.DataLocation.ToString().ToLower());
        }

        [Test]
        public async Task Update()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var domain1 = await CreateDefaultDomain(domainName, _emailService);
            var patch = new CommunicationDomainResourcePatch()
            {
                UserEngagementTracking = UserEngagementTracking.Enabled
            };
            var domain2 = (await domain1.UpdateAsync(WaitUntil.Completed, patch)).Value;
            Assert.IsNotNull(domain2);
            Assert.AreEqual(domain1.Data.Name, domain2.Data.Name);
        }

        [Test]
        public async Task Delete()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(domainName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            await CreateDefaultDomain(domainName, _emailService);
            var domain = await collection.GetAsync(domainName);
            Assert.IsNotNull(domain);
            Assert.AreEqual(domainName, domain.Value.Data.Name);
            Assert.AreEqual(_location.ToString().ToLower(), domain.Value.Data.Location.ToString().ToLower());
            Assert.AreEqual(_dataLocation.ToString().ToLower(), domain.Value.Data.DataLocation.ToString().ToLower());
        }

        [Test]
        public async Task GetAll()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            await CreateDefaultDomain(domainName, _emailService);
            var list = await _emailService.GetCommunicationDomainResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(domainName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location.ToString().ToLower(), list.FirstOrDefault().Data.Location.ToString().ToLower());
            Assert.AreEqual(_dataLocation.ToString().ToLower(), list.FirstOrDefault().Data.DataLocation.ToString().ToLower());
        }

        [Test]
        public async Task VerificationOperation()
        {
            string domainName = Recording.GenerateAssetName("domain-") + ".com";
            var collection = _emailService.GetCommunicationDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            var data = new DomainsRecordVerificationContent(DomainRecordVerificationType.Spf);
            await domain.InitiateVerificationAsync(WaitUntil.Completed, data);
            await domain.CancelVerificationAsync(WaitUntil.Completed, data);
        }
    }
}
