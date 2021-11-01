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
        public async Task CheckNameAvailabilityWithSub()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string endpointName = Recording.GenerateAssetName("endpoint-");
            CheckNameAvailabilityInput checkNameAvailabilityInput = new CheckNameAvailabilityInput(endpointName);
            CheckNameAvailabilityOutput checkNameAvailabilityOutput  = await subscription.CheckNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput);
            Assert.True(checkNameAvailabilityOutput.NameAvailable);
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string profileName = Recording.GenerateAssetName("profile-");
            Profile profile = await CreateProfile(rg, profileName, SkuName.StandardMicrosoft);
            endpointName = Recording.GenerateAssetName("endpoint-");
            Endpoint endpoint = await CreateEndpoint(profile, endpointName);
            CheckNameAvailabilityInput checkNameAvailabilityInput2 = new CheckNameAvailabilityInput(endpoint.Data.Name);
            checkNameAvailabilityOutput = await subscription.CheckNameAvailabilityWithSubscriptionAsync(checkNameAvailabilityInput2);
            Assert.False(checkNameAvailabilityOutput.NameAvailable);
        }
    }
}
