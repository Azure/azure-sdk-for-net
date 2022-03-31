// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class NameAvailabilityOperationsTests : CdnManagementTestBase
    {
        public NameAvailabilityOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

       [TestCase]
       [RecordedTest]
        public async Task CheckNameAvailability()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
                string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
                CheckNameAvailabilityInput checkNameAvailabilityInput = new CheckNameAvailabilityInput(cdnEndpointName, ResourceType.MicrosoftCdnProfilesEndpoints);
                CheckNameAvailabilityOutput checkNameAvailabilityOutput = await tenant.CheckCdnNameAvailabilityAsync(checkNameAvailabilityInput);
                Assert.True(checkNameAvailabilityOutput.NameAvailable);
                ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
                string cdnProfileName = Recording.GenerateAssetName("profile-");
                ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
                cdnEndpointName = Recording.GenerateAssetName("endpoint-");
                CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
                CheckNameAvailabilityInput checkNameAvailabilityInput2 = new CheckNameAvailabilityInput(cdnEndpoint.Data.Name, ResourceType.MicrosoftCdnProfilesEndpoints);
                checkNameAvailabilityOutput = await tenant.CheckCdnNameAvailabilityAsync(checkNameAvailabilityInput2);
                Assert.False(checkNameAvailabilityOutput.NameAvailable);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameAvailabilityWithSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CheckNameAvailabilityInput checkNameAvailabilityInput = new CheckNameAvailabilityInput(cdnEndpointName, ResourceType.MicrosoftCdnProfilesEndpoints);
            CheckNameAvailabilityOutput checkNameAvailabilityOutput  = await subscription.CheckCdnNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput);
            Assert.True(checkNameAvailabilityOutput.NameAvailable);
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            ProfileResource cdnProfile = await CreateCdnProfile(rg, cdnProfileName, CdnSkuName.StandardMicrosoft);
            cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpointResource cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            CheckNameAvailabilityInput checkNameAvailabilityInput2 = new CheckNameAvailabilityInput(cdnEndpoint.Data.Name, ResourceType.MicrosoftCdnProfilesEndpoints);
            checkNameAvailabilityOutput = await subscription.CheckCdnNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput2);
            Assert.False(checkNameAvailabilityOutput.NameAvailable);
        }
    }
}
