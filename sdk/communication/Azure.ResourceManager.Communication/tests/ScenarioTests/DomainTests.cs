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
    public class DomainTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EmailServiceResource _emailService;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _emailServiceName;
        private string _location;
        private string _dataLocation;

        public DomainTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
            _emailService = await _resourceGroup.GetEmailServiceResourceAsync(_emailServiceName);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var domain in _emailService.GetDomainResources().GetAllAsync())
            {
                await domain.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task AddTag()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.AddTagAsync("testkey", "testvalue");
            domain = await collection.GetAsync(domainName);
            var tagValue = domain.Data.Tags.FirstOrDefault();
            Assert.AreEqual(tagValue.Key, "testkey");
            Assert.AreEqual(tagValue.Value, "testvalue");
        }

        [Test]
        public async Task RemoveTag()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
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

        [Test]
        public async Task SetTags()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
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
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
            await CreateDefaultDomain(domainName, _emailService);
            bool exists = await collection.ExistsAsync(domainName);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var domain = await CreateDefaultDomain(domainName, _emailService);
            Assert.IsNotNull(domain);
            Assert.AreEqual(domainName, domain.Data.Name);
            Assert.AreEqual(_location, domain.Data.Location);
            Assert.AreEqual(_dataLocation, domain.Data.DataLocation);
        }

        [Test]
        public async Task Delete()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            await domain.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(domainName);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
            await CreateDefaultDomain(domainName, _emailService);
            var domain = await collection.GetAsync(domainName);
            Assert.IsNotNull(domain);
            Assert.AreEqual(domainName, domain.Value.Data.Name);
            Assert.AreEqual(_location, domain.Value.Data.Location);
            Assert.AreEqual(_dataLocation, domain.Value.Data.DataLocation);
        }

        [Test]
        public async Task GetAll()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            await CreateDefaultDomain(domainName, _emailService);
            var list = await _emailService.GetDomainResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(domainName, list.FirstOrDefault().Data.Name);
            Assert.AreEqual(_location, list.FirstOrDefault().Data.Location);
            Assert.AreEqual(_dataLocation, list.FirstOrDefault().Data.DataLocation);
        }

        [Test]
        public async Task VerificationOperation()
        {
            string domainName = Recording.GenerateAssetName("domain-");
            var collection = _emailService.GetDomainResources();
            var domain = await CreateDefaultDomain(domainName, _emailService);
            var data = new VerificationParameter(VerificationType.SPF);
            await domain.InitiateVerificationAsync(WaitUntil.Completed, data);
            await domain.CancelVerificationAsync(WaitUntil.Completed, data);
        }
    }
}
