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
                Subscription subscription = await Client.GetDefaultSubscriptionAsync();
                string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
                CheckNameAvailabilityInput checkNameAvailabilityInput = new CheckNameAvailabilityInput(cdnEndpointName);
                CheckNameAvailabilityOutput checkNameAvailabilityOutput = await tenant.CheckNameAvailabilityAsync(checkNameAvailabilityInput);
                Assert.True(checkNameAvailabilityOutput.NameAvailable);
                ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
                string cdnProfileName = Recording.GenerateAssetName("profile-");
                Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
                cdnEndpointName = Recording.GenerateAssetName("endpoint-");
                CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
                CheckNameAvailabilityInput checkNameAvailabilityInput2 = new CheckNameAvailabilityInput(cdnEndpoint.Data.Name);
                checkNameAvailabilityOutput = await tenant.CheckNameAvailabilityAsync(checkNameAvailabilityInput2);
                Assert.False(checkNameAvailabilityOutput.NameAvailable);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameAvailabilityWithSub()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CheckNameAvailabilityInput checkNameAvailabilityInput = new CheckNameAvailabilityInput(cdnEndpointName);
            CheckNameAvailabilityOutput checkNameAvailabilityOutput  = await subscription.CheckNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput);
            Assert.True(checkNameAvailabilityOutput.NameAvailable);
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string cdnProfileName = Recording.GenerateAssetName("profile-");
            Profile cdnProfile = await CreateCdnProfile(rg, cdnProfileName, SkuName.StandardMicrosoft);
            cdnEndpointName = Recording.GenerateAssetName("endpoint-");
            CdnEndpoint cdnEndpoint = await CreateCdnEndpoint(cdnProfile, cdnEndpointName);
            CheckNameAvailabilityInput checkNameAvailabilityInput2 = new CheckNameAvailabilityInput(cdnEndpoint.Data.Name);
            checkNameAvailabilityOutput = await subscription.CheckNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput2);
            Assert.False(checkNameAvailabilityOutput.NameAvailable);
        }
    }
}
