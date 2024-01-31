// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [PlaybackOnly("SDK do not support creating partner configuraion, it must be manually created before running this case")]
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

            // Delete
            await configuration.DeleteAsync(WaitUntil.Completed);
        }
    }
}
