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
    public class SenderUsernameTests : CommunicationManagementClientLiveTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private EmailServiceResource _emailService;
        private CommunicationDomainResource _domainResource;
        private ResourceIdentifier _resourceGroupIdentifier;
        private string _emailServiceName;
        private string _domainResourceName;
        private string _location;
        private string _dataLocation;

        public SenderUsernameTests(bool isAsync)
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
            _domainResourceName = SessionRecording.GenerateAssetName("domain-") + ".com";
            _emailService = await CreateDefaultEmailServices(_emailServiceName, rg);
            _domainResource = await CreateDefaultDomain(_domainResourceName, _emailService);
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
            _domainResource = await _emailService.GetCommunicationDomainResourceAsync(_domainResourceName);
        }

        [TearDown]
        public async Task TearDown()
        {
            await foreach (var username in _domainResource.GetSenderUsernameResources().GetAllAsync())
            {
                await username.DeleteAsync(WaitUntil.Completed);
            }
        }

        [Test]
        public async Task Exists()
        {
            string username = Recording.GenerateAssetName("un-");
            string displayName = Recording.GenerateAssetName("dn ");
            var collection = _domainResource.GetSenderUsernameResources();
            await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);
            bool exists = await collection.ExistsAsync(username);
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string username = Recording.GenerateAssetName("un-");
            string displayName = Recording.GenerateAssetName("dn ");

            var senderUsername = await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);

            Assert.IsNotNull(senderUsername);
            Assert.AreEqual(username, senderUsername.Data.Username);
            Assert.AreEqual(displayName, senderUsername.Data.DisplayName);
        }

        // todo: follow up on update bug. Updating a record with the same name results in 400 error a username already exists.

        //[Test]
        //public async Task Update()
        //{
        //    string username = Recording.GenerateAssetName("un-");
        //    // string updatedUsername = Recording.GenerateAssetName("updated-un-");
        //    string displayName = Recording.GenerateAssetName("dn ");
        //    string updatedDisplayName = Recording.GenerateAssetName("updated dn ");

        //    var senderUsername1 = await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);
        //    var patch = new SenderUsernameResourceData()
        //    {
        //        Username = senderUsername1.Data.Username,
        //        DisplayName = updatedDisplayName
        //    };
        //    var senderUsername2 = (await senderUsername1.UpdateAsync(WaitUntil.Completed, patch)).Value;

        //    Assert.IsNotNull(senderUsername2);
        //    Assert.AreEqual(senderUsername1.Data.Name, senderUsername2.Data.Name);
        //    Assert.AreNotEqual(senderUsername1.Data.Username, senderUsername2.Data.Username);
        //    Assert.AreNotEqual(senderUsername1.Data.DisplayName, senderUsername2.Data.DisplayName);
        //}

        [Test]
        public async Task Delete()
        {
            string username = Recording.GenerateAssetName("un-");
            string displayName = Recording.GenerateAssetName("dn ");

            var collection = _domainResource.GetSenderUsernameResources();
            var senderUsername = await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);
            await senderUsername.DeleteAsync(WaitUntil.Completed);
            bool exists = await collection.ExistsAsync(username);
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task Get()
        {
            string username = Recording.GenerateAssetName("un-");
            string displayName = Recording.GenerateAssetName("dn ");

            var collection = _domainResource.GetSenderUsernameResources();
            await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);

            var actualSenderUsername = await collection.GetAsync(username);
            Assert.IsNotNull(actualSenderUsername);
            Assert.AreEqual(actualSenderUsername.Value.Data.Username, username);
            Assert.AreEqual(actualSenderUsername.Value.Data.DisplayName, displayName);
        }

        [Test]
        public async Task GetAll()
        {
            string username = Recording.GenerateAssetName("un-");
            string displayName = Recording.GenerateAssetName("dn ");

            await CreateDefaultSenderUsernameResource(username, displayName, _domainResource);

            var list = await _domainResource.GetSenderUsernameResources().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.IsTrue(list.Any(s=>s.HasData && s.Data.Username == username));
            Assert.IsTrue(list.Any(s => s.HasData && s.Data.DisplayName == displayName));
        }
    }
}
