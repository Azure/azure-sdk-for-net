// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Cdn.Tests.Helper;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class AfdRouteOperationsTests : CdnManagementTestBase
    {
        public AfdRouteOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOrigin afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRoute afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            await afdRoute.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdRoute.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile afdProfile = await CreateAfdProfile(rg, afdProfileName, SkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpoint afdEndpointInstance = await CreateAfdEndpoint(afdProfile, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroup afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfile, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOrigin afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSet afdRuleSet = await CreateAfdRuleSet(afdProfile, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRoute afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            RouteUpdateOptions updateOptions = new RouteUpdateOptions
            {
                EnabledState = EnabledState.Disabled
            };
            var lro = await afdRoute.UpdateAsync(updateOptions);
            AfdRoute updatedAfdRoute = lro.Value;
            ResourceDataHelper.AssertAfdRouteUpdate(updatedAfdRoute, updateOptions);
        }
    }
}
