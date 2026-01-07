// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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
            AzureLocation location = new AzureLocation("eastus2euap", "eastus2euap");
            _resourceGroup = await CreateResourceGroupAsync(location);
            _partnerRegistrationCollection = _resourceGroup.GetPartnerRegistrations();
        }

        [Test]
        public async Task CreateOrUpdate()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var registration = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            ValidatePartnerRegistration(registration, partnerRegistrationName);
        }

        [Test]
        public async Task Exist()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            bool flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.That(flag, Is.True);
        }

        [Test]
        public async Task Get()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            var registration = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            ValidatePartnerRegistration(registration, partnerRegistrationName);
        }

        [Test]
        public async Task GetAll()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            var list = await _partnerRegistrationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePartnerRegistration(list.First(item => item.Data.Name == partnerRegistrationName), partnerRegistrationName);
            // Get all registrations created within a resourceGroup
            Assert.That(list, Is.Not.Null);
            Assert.GreaterOrEqual(list.Count, 1);
            Assert.That(partnerRegistrationName, Is.EqualTo(list.FirstOrDefault().Data.Name));
            // Get all registrations created within the subscription irrespective of the resourceGroup
            var registrationsInAzureSubscription = await DefaultSubscription.GetPartnerRegistrationsAsync().ToEnumerableAsync();
            Assert.That(registrationsInAzureSubscription, Is.Not.Null);
            Assert.GreaterOrEqual(registrationsInAzureSubscription.Count, 1);
            var falseFlag = false;
            foreach (var item in registrationsInAzureSubscription)
            {
                if (item.Data.Name == partnerRegistrationName)
                {
                    falseFlag = true;
                    break;
                }
            }
            Assert.That(falseFlag, Is.True);
        }

        [Ignore("28/02/2025: This test is failing in the pipeline, because of API Issue, enable it in RECORD mode once the api is fixed")]
        [Test]
        public async Task Update()
        {
            // Arrange
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var topic = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            var patch = new Models.PartnerRegistrationPatch
            {
                Tags = { { "env", "test" }, { "owner", "sdk-test" } }
            };
            await topic.UpdateAsync(WaitUntil.Completed, patch);
            // Retrieve the updated topic
            var updatedTopic = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            Assert.That(updatedTopic.Value, Is.Not.Null);
        }

        [Test]
        public async Task Delete()
        {
            string partnerRegistrationName = Recording.GenerateAssetName("PartnerRegistration");
            var registration = await CreatePartnerRegistration(_resourceGroup, partnerRegistrationName);
            bool flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.That(flag, Is.True);

            await registration.DeleteAsync(WaitUntil.Completed);
            flag = await _partnerRegistrationCollection.ExistsAsync(partnerRegistrationName);
            Assert.That(flag, Is.False);
        }

        [Ignore("28/02/2025: This test is failing in the pipeline, because of API Issue, enable it in RECORD mode once the api is fixed")]
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
            Assert.That(registration.Data.Tags.Count, Is.EqualTo(1));
            KeyValuePair<string, string> tag = registration.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.That(tag.Key, Is.EqualTo("addtagkey"));
            Assert.That(tag.Value, Is.EqualTo("addtagvalue"));

            // RemoveTag
            await registration.RemoveTagAsync("addtagkey");
            registration = await _partnerRegistrationCollection.GetAsync(partnerRegistrationName);
            Assert.That(registration.Data.Tags.Count, Is.EqualTo(0));
        }

        private void ValidatePartnerRegistration(PartnerRegistrationResource partnerRegistration, string partnerRegistrationName)
        {
            Assert.That(partnerRegistration, Is.Not.Null);
            Assert.That(partnerRegistration.Data.Id, Is.Not.Null);
            Assert.That(partnerRegistration.Data.Name, Is.EqualTo(partnerRegistrationName));
            Assert.That(partnerRegistration.Data.ResourceType.ToString(), Is.EqualTo("Microsoft.EventGrid/partnerRegistrations"));
            Assert.That(partnerRegistration.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(partnerRegistration.Data.Location.ToString(), Is.EqualTo("Global"));
        }
    }
}
