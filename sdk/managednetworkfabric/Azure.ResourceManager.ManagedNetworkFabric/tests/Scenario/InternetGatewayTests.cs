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
    public class InternetGatewayTests : ManagedNetworkFabricManagementTestBase
    {
        public InternetGatewayTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public InternetGatewayTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task InternetGateways_List()
        {//fab2nfcrg070623
            TestContext.Out.WriteLine($"Entered into the InternetGateway tests....");
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, "fab2nfcrg070623");
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this InternetGatewayRuleResource
            InternetGatewayCollection collection = resourceGroupResource.GetInternetGateways();

            // invoke the operation and iterate over the result
            await foreach (InternetGatewayResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                InternetGatewayData resourceData = item.Data;
                // for demo we just print out the id
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            Console.WriteLine($"Succeeded");
        }
    }
}
