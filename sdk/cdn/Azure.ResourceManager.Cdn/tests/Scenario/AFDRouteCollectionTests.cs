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
    public class AFDRouteCollectionTests : CdnManagementTestBase
    {
        public AFDRouteCollectionTests(bool isAsync)
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
            Profile AFDProfile = await CreateAFDProfile(rg, AFDProfileName, SkuName.StandardAzureFrontDoor);
            string AFDEndpointName = Recording.GenerateAssetName("AFDEndpoint-");
            AFDEndpoint AFDEndpointInstance = await CreateAFDEndpoint(AFDProfile, AFDEndpointName);
            string AFDOriginGroupName = Recording.GenerateAssetName("AFDOriginGroup-");
            AFDOriginGroup AFDOriginGroupInstance = await CreateAFDOriginGroup(AFDProfile, AFDOriginGroupName);
            string AFDOriginName = Recording.GenerateAssetName("AFDOrigin-");
            _ = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string routeName = Recording.GenerateAssetName("AFDRoute");
            Route route = await CreateRoute(AFDEndpointInstance, routeName, AFDOriginGroupInstance, ruleSet);
            Assert.AreEqual(routeName, route.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDEndpointInstance.GetRoutes().CreateOrUpdateAsync(null, route.Data));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDEndpointInstance.GetRoutes().CreateOrUpdateAsync(routeName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
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
            _ = await CreateAFDOrigin(AFDOriginGroupInstance, AFDOriginName);
            string ruleSetName = Recording.GenerateAssetName("AFDRuleSet");
            RuleSet ruleSet = await CreateRuleSet(AFDProfile, ruleSetName);
            string routeName = Recording.GenerateAssetName("AFDRoute");
            _ = await CreateRoute(AFDEndpointInstance, routeName, AFDOriginGroupInstance, ruleSet);
            int count = 0;
            await foreach (var tempRoute in AFDEndpointInstance.GetRoutes().GetAllAsync())
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
            Route getRoute = await AFDEndpointInstance.GetRoutes().GetAsync(routeName);
            ResourceDataHelper.AssertValidRoute(route, getRoute);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await AFDEndpointInstance.GetRoutes().GetAsync(null));
        }
    }
}
