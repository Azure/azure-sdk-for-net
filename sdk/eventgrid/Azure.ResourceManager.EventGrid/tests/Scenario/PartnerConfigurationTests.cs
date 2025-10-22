// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EventGrid.Tests
{
    internal class PartnerConfigurationTests : EventGridManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public PartnerConfigurationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroupAsync();
        }

        [Test]
        public async Task PartnerConfigurationE2EOperation()
        {
            var configuration = (CreatePartnerConfiguration(_resourceGroup, Recording.GenerateAssetName("registration"))).Result;

            Assert.IsNotNull(configuration);
            Assert.AreEqual("Microsoft.EventGrid/partnerConfigurations", configuration.Data.ResourceType.ToString());

            // Authorize partner in configuration
            var registration = await CreatePartnerRegistration(_resourceGroup, Recording.GenerateAssetName("registration"));
            var eventGridPartnerContent = new EventGridPartnerContent()
            {
                PartnerRegistrationImmutableId = registration.Data.PartnerRegistrationImmutableId,
            };
            var authorizeResponse = await configuration.AuthorizePartnerAsync(eventGridPartnerContent);
            Assert.AreEqual("Succeeded", authorizeResponse.Value.Data.ProvisioningState.ToString());

            // Update
            var partnerConfigurationPatch = new PartnerConfigurationPatch()
            {
                DefaultMaximumExpirationTimeInDays = 14,
            };
            var response = await configuration.UpdateAsync(WaitUntil.Completed, partnerConfigurationPatch);
            Assert.IsNotNull(response);
            Assert.AreEqual("Succeeded", response.Value.Data.ProvisioningState.ToString());

            // List all partner configurations under the entire subscription
            var partnerConfigurationsInSubscription = await DefaultSubscription.GetPartnerConfigurationsAsync().ToEnumerableAsync();

            Assert.NotNull(partnerConfigurationsInSubscription);

            Assert.GreaterOrEqual(partnerConfigurationsInSubscription.Count, 1);

            // Delete
            await configuration.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        public async Task GetPartnerConfiguration()
        {
            var configuration = (CreatePartnerConfiguration(_resourceGroup, Recording.GenerateAssetName("registration"))).Result;
            var response = await configuration.GetAsync();
            Assert.IsNotNull(response.Value);
            Assert.AreEqual("Microsoft.EventGrid/partnerConfigurations", response.Value.Data.ResourceType.ToString());
        }

        [Test]
        public async Task UnauthorizePartner()
        {
            var configuration = (CreatePartnerConfiguration(_resourceGroup, Recording.GenerateAssetName("registration"))).Result;
            var registration = await CreatePartnerRegistration(_resourceGroup, Recording.GenerateAssetName("registration"));
            var eventGridPartnerContent = new EventGridPartnerContent()
            {
                PartnerRegistrationImmutableId = registration.Data.PartnerRegistrationImmutableId,
            };
            await configuration.AuthorizePartnerAsync(eventGridPartnerContent);

            var unauthorizeResponse = await configuration.UnauthorizePartnerAsync(eventGridPartnerContent);
            Assert.AreEqual("Succeeded", unauthorizeResponse.Value.Data.ProvisioningState.ToString());
        }
    }
}
