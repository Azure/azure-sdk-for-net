// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class InternetGatewayRuleTests : ManagedNetworkFabricManagementTestBase
    {
        public InternetGatewayRuleTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public InternetGatewayRuleTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task InternetGatewayRules_Operations()
        {
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this NetworkFabricInternetGatewayRuleResource
            NetworkFabricInternetGatewayRuleCollection collection = resourceGroupResource.GetNetworkFabricInternetGatewayRules();

            // invoke the create operation
            NetworkFabricInternetGatewayRuleData data =
                new NetworkFabricInternetGatewayRuleData(new AzureLocation(TestEnvironment.Location), new InternetGatewayRules(InternetGatewayRuleAction.Allow, new string[] { "10.10.10.10" }))
                {
                    Annotation = "annotationValue",
                    Tags =
                    {
                        ["keyID"] = "keyValue",
                    },
                };
            ArmOperation<NetworkFabricInternetGatewayRuleResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.InternetGatewayRuleName, data);
            NetworkFabricInternetGatewayRuleResource result = lro.Value;
            NetworkFabricInternetGatewayRuleData resourceData = result.Data;
            Assert.AreEqual(resourceData.Name, TestEnvironment.InternetGatewayRuleName);
            TestContext.Out.WriteLine($"Create operation succeeded on id: {resourceData.Id}");

            // invoke the get operation
            result = await collection.GetAsync(TestEnvironment.InternetGatewayRuleName);

            resourceData = result.Data;
            Assert.AreEqual(resourceData.Name, TestEnvironment.InternetGatewayRuleName);
            TestContext.Out.WriteLine($"Get Operation succeeded on id: {resourceData.Id}");

            /*
            //invoke the update operation
            ResourceIdentifier networkFabricInternetGatewayRuleResourceId = NetworkFabricInternetGatewayRuleResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.InternetGatewayRuleName);
            NetworkFabricInternetGatewayRuleResource networkFabricInternetGatewayRule = Client.GetNetworkFabricInternetGatewayRuleResource(networkFabricInternetGatewayRuleResourceId);
            NetworkFabricInternetGatewayRulePatch patch = new NetworkFabricInternetGatewayRulePatch()
            {
                Tags =
                {
                    ["key3311"] = "1234",
                },
            };
            ArmOperation<NetworkFabricInternetGatewayRuleResource> patchlro = await networkFabricInternetGatewayRule.UpdateAsync(WaitUntil.Completed, patch);
            NetworkFabricInternetGatewayRuleResource patchResult = patchlro.Value;
            NetworkFabricInternetGatewayRuleData patchResourceData = patchResult.Data;
            Assert.True(patchResult.Data.Tags.ContainsKey("key3311"));

            TestContext.Out.WriteLine($"Patch operation succeeded on id: {patchResourceData.Id}");
            */

            // invoke the list by group operation and iterate over the result
            await foreach (NetworkFabricInternetGatewayRuleResource item in collection.GetAllAsync())
            {
                resourceData = item.Data;
                TestContext.Out.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            TestContext.Out.WriteLine($"List by resource group operation succeeded.");

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            // invoke the list by subscription operation and iterate over the result
            await foreach (NetworkFabricInternetGatewayRuleResource item in subscriptionResource.GetNetworkFabricInternetGatewayRulesAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                NetworkFabricInternetGatewayRuleData listResourceData = item.Data;
                // for demo we just print out the id
                TestContext.Out.WriteLine($"Succeeded on id: {listResourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by subscription operation succeeded.");
        }
    }
}
