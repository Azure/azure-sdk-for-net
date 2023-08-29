// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class InternetGatewayTests : ManagedNetworkFabricManagementTestBase
    {
        public InternetGatewayTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public InternetGatewayTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task InternetGateways_List()
        {
            TestContext.Out.WriteLine($"Entered into the InternetGateway tests....");
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this InternetGatewayResource
            NetworkFabricInternetGatewayCollection collection = resourceGroupResource.GetNetworkFabricInternetGateways();

            // invoke the operation and iterate over the result
            await foreach (NetworkFabricInternetGatewayResource item in collection.GetAllAsync())
            {
                NetworkFabricInternetGatewayData resourceData = item.Data;
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
