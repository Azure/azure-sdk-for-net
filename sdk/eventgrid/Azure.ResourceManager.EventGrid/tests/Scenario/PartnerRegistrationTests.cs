// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    public class PartnerRegistrationTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PartnerRegistrationCollection _partnerRegistrationCollection;

        public PartnerRegistrationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            _partnerRegistrationCollection = _resourceGroup.GetPartnerRegistrations();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var registration = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            ValidatePartnerRegistration(registration, partnerRegistrationName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            bool flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            var registration = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            ValidatePartnerRegistration(registration, partnerRegistrationName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            var list = await _partnerRegistrationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePartnerRegistration(list.First(item => item.Data.Name == partnerRegistrationName), partnerRegistrationName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var registration = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            bool flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.IsTrue(flag);

            await registration.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var registration = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);

            // AddTag
            await registration.AddTagAsync("addtagkey", "addtagvalue");
            registration = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            Assert.AreEqual(1, registration.Data.Tags.Count);
            KeyValuePair<string, string> tag = registration.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await registration.RemoveTagAsync("addtagkey");
            registration = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            Assert.AreEqual(0, registration.Data.Tags.Count);
        }

        private void ValidatePartnerRegistration(PartnerRegistrationResource partnerRegistration, string partnerRegistrationName)
        {
            Assert.IsNotNull(partnerRegistration);
            Assert.IsNotNull(partnerRegistration.Data.Id);
            Assert.AreEqual(partnerRegistrationName, partnerRegistration.Data.Name);
            Assert.AreEqual("Microsoft.EventGrid/partnerRegistrations", partnerRegistration.Data.ResourceType.ToString());
            Assert.AreEqual("Succeeded", partnerRegistration.Data.ProvisioningState.ToString());
            Assert.AreEqual("Global", partnerRegistration.Data.Location.ToString());
        }
    }
}
