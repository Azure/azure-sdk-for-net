// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AFDSecurityPolicyCollectionTests : CdnManagementTestBase
    {
        public AFDSecurityPolicyCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            SecurityPolicy securityPolicy = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
            Assert.AreEqual(securityPolicyName, securityPolicy.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecurityPolicies().CreateOrUpdateAsync(null, securityPolicy.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecurityPolicies().CreateOrUpdateAsync(securityPolicyName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            _ = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
            int count = 0;
            await foreach (var tempSecurityPolicy in AFDProfile.GetSecurityPolicies().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.PremiumAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string securityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            SecurityPolicy securityPolicy = await CreateSecurityPolicy(AFDProfile, AFDEndpointInstance, securityPolicyName);
            SecurityPolicy getSecurityPolicy = await AFDProfile.GetSecurityPolicies().GetAsync(securityPolicyName);
            ResourceDataHelper.AssertValidSecurityPolicy(securityPolicy, getSecurityPolicy);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDProfile.GetSecurityPolicies().GetAsync(null));
        }
    }
}
