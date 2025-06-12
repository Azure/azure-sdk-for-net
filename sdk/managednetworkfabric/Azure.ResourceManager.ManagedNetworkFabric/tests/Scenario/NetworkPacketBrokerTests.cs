// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NetworkPacketBrokerTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkPacketBrokerTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkPacketBrokerTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkPacketBroker()
        {
            TestContext.Out.WriteLine($"Entered into the NetworkPacketBroker tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.NetworkPacketBrokerName name : {TestEnvironment.NetworkPacketBrokerName}");

            ResourceIdentifier networkPacketBrokerResourceId = NetworkPacketBrokerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkPacketBrokerName);
            TestContext.Out.WriteLine($"networkPacketBrokerResourceId: {networkPacketBrokerResourceId}");
            TestContext.Out.WriteLine($"NetworkPacketBroker Test started.....");

            // Get individual resource details by name
            NetworkPacketBrokerResource networkPacketBroker = Client.GetNetworkPacketBrokerResource(networkPacketBrokerResourceId);
            NetworkPacketBrokerResource result = await networkPacketBroker.GetAsync();
            NetworkPacketBrokerData networkPacketBrokerData = result.Data;
            TestContext.Out.WriteLine($"Succeeded on id: {networkPacketBrokerData.Id}");

            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            NetworkPacketBrokerCollection collection = resourceGroupResource.GetNetworkPacketBrokers();
            // List by Resource
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkPacketBrokerResource>();
            await foreach (NetworkPacketBrokerResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);
            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            await foreach (NetworkPacketBrokerResource resourceData in subscriptionResource.GetNetworkPacketBrokersAsync())
            {
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");
        }
    }
}
