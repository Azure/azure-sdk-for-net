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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRouteResource afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            await afdRoute.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await afdRoute.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-");
            string afdProfileName = Recording.GenerateAssetName("AFDProfile-");
            ProfileResource afdProfileResource = await CreateAfdProfile(rg, afdProfileName, CdnSkuName.StandardAzureFrontDoor);
            string afdEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AfdEndpointResource afdEndpointInstance = await CreateAfdEndpoint(afdProfileResource, afdEndpointName);
            string afdOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AfdOriginGroupResource afdOriginGroupInstance = await CreateAfdOriginGroup(afdProfileResource, afdOriginGroupName);
            string afdOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AfdOriginResource afdOriginInstance = await CreateAfdOrigin(afdOriginGroupInstance, afdOriginName);
            string afdRuleSetName = Recording.GenerateAssetName("AFDRuleSet");
            AfdRuleSetResource afdRuleSet = await CreateAfdRuleSet(afdProfileResource, afdRuleSetName);
            string afdRouteName = Recording.GenerateAssetName("AFDRoute");
            AfdRouteResource afdRoute = await CreateAfdRoute(afdEndpointInstance, afdRouteName, afdOriginGroupInstance, afdRuleSet);
            AfdRoutePatch updateOptions = new AfdRoutePatch
            {
                EnabledState = EnabledState.Disabled
            };
            var lro = await afdRoute.UpdateAsync(WaitUntil.Completed, updateOptions);
            AfdRouteResource updatedAfdRoute = lro.Value;
            ResourceDataHelper.AssertAfdRouteUpdate(updatedAfdRoute, updateOptions);
        }
    }
}
