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
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string ipPrefixName = TestEnvironment.IpPrefixName;

            TestContext.Out.WriteLine($"Entered into the IpPrefix tests....");
            TestContext.Out.WriteLine($"Provided IpPrefixName name : {ipPrefixName}");

            ResourceIdentifier ipPrefixResourceId = IPPrefixResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, ipPrefixName);
            TestContext.Out.WriteLine($"IpPrefixResourceId: {ipPrefixResourceId}");

            // Get the collection of this IpPrefix
            IPPrefixCollection collection = ResourceGroupResource.GetIPPrefixes();

            TestContext.Out.WriteLine($"IpPrefix Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            IPPrefixData data =
                new IPPrefixData(new AzureLocation(TestEnvironment.Location), new IPPrefixPropertiesIPPrefixRulesItem[]
                {
                    new IPPrefixPropertiesIPPrefixRulesItem(CommunityActionType.Permit,12,"1.1.1.0/24")
                    {
                        Condition = Condition.EqualTo,
                        SubnetMaskLength = 24,
                    }
                })
                {
                    Annotation = "annotationValue",
                    Tags =
                    {
                        ["key6404"] = "",
                    },
                };

            ArmOperation<IPPrefixResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ipPrefixName, data);
            IPPrefixResource createResult = lro.Value;
            Assert.AreEqual(ipPrefixName, createResult.Data.Name);

            IPPrefixResource ipPrefix = Client.GetIPPrefixResource(ipPrefixResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            IPPrefixResource getResult = await ipPrefix.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(ipPrefixName, getResult.Data.Name);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<IPPrefixResource>();
            IPPrefixCollection collectionOp = ResourceGroupResource.GetIPPrefixes();
            await foreach (IPPrefixResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<IPPrefixResource>();
            await foreach (IPPrefixResource item in DefaultSubscription.GetIPPrefixesAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipPrefix.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
