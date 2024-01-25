// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NetworkRackTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkRackTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkRackTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkRacks()
        {
            TestContext.Out.WriteLine($"Entered into the NetworkRack tests....");
            TestContext.Out.WriteLine($"Provided networkRack name : {TestEnvironment.NetworkRackName}");

            ResourceIdentifier networkRackResourceId = NetworkRackResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkRackName);
            TestContext.Out.WriteLine($"networkRackResourceId: {networkRackResourceId}");

            TestContext.Out.WriteLine($"NetworkRack Test started.....");

            NetworkRackCollection collection = ResourceGroupResource.GetNetworkRacks();

            NetworkRackResource rack = Client.GetNetworkRackResource(networkRackResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkRackResource getResult = await rack.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkRackName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkRackResource>();
            await foreach (NetworkRackResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkRackResource item in subscriptionResource.GetNetworkRacksAsync())
            {
                NetworkRackData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");
        }
    }
}
