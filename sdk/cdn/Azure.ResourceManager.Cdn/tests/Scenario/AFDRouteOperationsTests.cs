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
    public class AFDRouteOperationsTests : CdnManagementTestBase
    {
        public AFDRouteOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string routeName = Recording.GenerateAssetName("AFDRoute");
            Route route = await CreateRoute(AFDEndpointInstance, routeName, AFDOriginGroupInstance, ruleSet);
            await route.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await route.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroup rg = await CreateResourceGroup(subscription, "testRg-");
            string AFDProfileName = Recording.GenerateAssetName("AFDProfile-");
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            AFDOrigin AFDOriginInstance = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string routeName = Recording.GenerateAssetName("AFDRoute");
            Route route = await CreateRoute(AFDEndpointInstance, routeName, AFDOriginGroupInstance, ruleSet);
            RouteUpdateParameters updateParameters = new RouteUpdateParameters
            {
                EnabledState = EnabledState.Disabled
            };
            var lro = await route.UpdateAsync(updateParameters);
            Route updatedRoute = lro.Value;
            ResourceDataHelper.AssertRouteUpdate(updatedRoute, updateParameters);
        }
    }
}
