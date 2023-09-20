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
    public class IpPrefixTests : ManagedNetworkFabricManagementTestBase
    {
        public IpPrefixTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public IpPrefixTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task IpPrefixes()
        {
            TestContext.Out.WriteLine($"Entered into the IpPrefix tests....");
            TestContext.Out.WriteLine($"Provided IpPrefixName name : {TestEnvironment.IpPrefixName}");

            ResourceIdentifier ipPrefixResourceId = NetworkFabricIPPrefixResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.IpPrefixName);
            TestContext.Out.WriteLine($"IpPrefixResourceId: {ipPrefixResourceId}");

            // Get the collection of this IpPrefix
            NetworkFabricIPPrefixCollection collection = ResourceGroupResource.GetNetworkFabricIPPrefixes();

            TestContext.Out.WriteLine($"IpPrefix Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricIPPrefixData data = new NetworkFabricIPPrefixData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotation",
                IPPrefixRules =
                {
                    new IPPrefixRule(CommunityActionType.Permit, 4155123341,"10.10.10.10/30")
                    {
                        Condition = IPPrefixRuleCondition.GreaterThanOrEqualTo,
                        SubnetMaskLength = "31",
                    }
                },
                Tags =
                {
                    ["keyID"] = "KeyValue",
                },
            };
            ArmOperation<NetworkFabricIPPrefixResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.IpPrefixName, data);
            NetworkFabricIPPrefixResource createResult = lro.Value;
            Assert.AreEqual(TestEnvironment.IpPrefixName, createResult.Data.Name);

            NetworkFabricIPPrefixResource ipPrefix = Client.GetNetworkFabricIPPrefixResource(ipPrefixResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricIPPrefixResource getResult = await ipPrefix.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(TestEnvironment.IpPrefixName, getResult.Data.Name);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricIPPrefixResource>();
            NetworkFabricIPPrefixCollection collectionOp = ResourceGroupResource.GetNetworkFabricIPPrefixes();
            await foreach (NetworkFabricIPPrefixResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricIPPrefixResource item in subscriptionResource.GetNetworkFabricIPPrefixesAsync())
            {
                NetworkFabricIPPrefixData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipPrefix.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
