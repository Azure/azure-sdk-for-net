// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class L2IsolationDomainTests : ManagedNetworkFabricManagementTestBase
    {
        public L2IsolationDomainTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public L2IsolationDomainTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task L2IsolationDomains()
        {
            // get the collection of this L2Isolation

            NetworkFabricL2IsolationDomainCollection collection = ResourceGroupResource.GetNetworkFabricL2IsolationDomains();

            TestContext.Out.WriteLine($"Entered into the L2Isolation Domain tests....");

            TestContext.Out.WriteLine($"Provided NetworkFabric Id : {TestEnvironment.Provisioned_NF_ID}");

            ResourceIdentifier l2DomainResourceId = NetworkFabricL2IsolationDomainResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupResource.Id.Name, TestEnvironment.L2IsolationDomainName);

            TestContext.Out.WriteLine($"l2DomainResourceId: {l2DomainResourceId}");

            TestContext.Out.WriteLine($"L2 Isolation Domain Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricL2IsolationDomainData data = new NetworkFabricL2IsolationDomainData(new AzureLocation(TestEnvironment.Location), new ResourceIdentifier(TestEnvironment.Provisioned_NF_ID), 1000)
            {
                Annotation = "annotation",
                Mtu = 7000,
                Tags =
                {
                    ["keyID"] = "keyValue",
                },
            };

            ArmOperation<NetworkFabricL2IsolationDomainResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.L2IsolationDomainName, data);
            Assert.AreEqual(createResult.Value.Data.Name, TestEnvironment.L2IsolationDomainName);

            NetworkFabricL2IsolationDomainResource l2IsolationDomain = Client.GetNetworkFabricL2IsolationDomainResource(l2DomainResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricL2IsolationDomainResource getResult = await l2IsolationDomain.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.L2IsolationDomainName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricL2IsolationDomainResource>();
            NetworkFabricL2IsolationDomainCollection collectionOp = ResourceGroupResource.GetNetworkFabricL2IsolationDomains();
            await foreach (NetworkFabricL2IsolationDomainResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricL2IsolationDomainResource item in subscriptionResource.GetNetworkFabricL2IsolationDomainsAsync())
            {
                NetworkFabricL2IsolationDomainData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Update Admin State
            TestContext.Out.WriteLine($"POST started.....");
            UpdateAdministrativeStateContent triggerEnable = new UpdateAdministrativeStateContent()
            {
                State = AdministrativeEnableState.Enable
            };
            ArmOperation<DeviceUpdateCommonPostActionResult> test = await l2IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Completed, triggerEnable);

            UpdateAdministrativeStateContent triggerDisable = new UpdateAdministrativeStateContent()
            {
                State = AdministrativeEnableState.Disable
            };
            test = await l2IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Completed, triggerDisable);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await l2IsolationDomain.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
