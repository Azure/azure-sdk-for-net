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
    public class AfdSecurityPolicyCollectionTests : CdnManagementTestBase
    {
        public AfdSecurityPolicyCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            Assert.AreEqual(afdSecurityPolicyName, afdSecurityPolicy.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecurityPolicies().CreateOrUpdateAsync(WaitUntil.Completed, null, afdSecurityPolicy.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecurityPolicies().CreateOrUpdateAsync(WaitUntil.Completed, afdSecurityPolicyName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            _ = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            int count = 0;
            await foreach (var tempSecurityPolicy in afdProfile.GetAfdSecurityPolicies().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfile = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdSecurityPolicyName = Recording.GenerateAssetName("AFDSecurityPolicy-");
            AfdSecurityPolicyResource afdSecurityPolicy = await CreateAfdSecurityPolicy(afdProfile, afdEndpointInstance, afdSecurityPolicyName);
            AfdSecurityPolicyResource getAfdSecurityPolicy = await afdProfile.GetAfdSecurityPolicies().GetAsync(afdSecurityPolicyName);
            ResourceDataHelper.AssertValidAfdSecurityPolicy(afdSecurityPolicy, getAfdSecurityPolicy);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await afdProfile.GetAfdSecurityPolicies().GetAsync(null));
        }
    }
}
