// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
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
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string networkFabricId = TestEnvironment.ValidNetworkFabricId;
            string l2IsolationDomainName= TestEnvironment.L2IsolationDomainName;

            // get the collection of this L2Isolation
            var collection = ResourceGroupResource.GetL2IsolationDomains();

            TestContext.Out.WriteLine($"Entered into the L2Isolation Domain tests....");

            TestContext.Out.WriteLine($"Provided NetworkFabric Id : {networkFabricId}");

            ResourceIdentifier l2DomainResourceId = L2IsolationDomainResource.CreateResourceIdentifier(subscriptionId, ResourceGroupResource.Id.Name, l2IsolationDomainName);

            TestContext.Out.WriteLine($"l2DomainResourceId: {l2DomainResourceId}");

            TestContext.Out.WriteLine($"L2 Isolation Domain Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            L2IsolationDomainData data = new L2IsolationDomainData(new AzureLocation(TestEnvironment.Location))
            {
                NetworkFabricId = networkFabricId,
                VlanId = 501,
                Mtu = 1500,
            };
            ArmOperation<L2IsolationDomainResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, l2IsolationDomainName, data);
            Assert.AreEqual(createResult.Value.Data.Name, l2IsolationDomainName);

            L2IsolationDomainResource l2IsolationDomain = Client.GetL2IsolationDomainResource(l2DomainResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            L2IsolationDomainResource getResult = await l2IsolationDomain.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, l2IsolationDomainName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<L2IsolationDomainResource>();
            L2IsolationDomainCollection collectionOp = ResourceGroupResource.GetL2IsolationDomains();
            await foreach (L2IsolationDomainResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<L2IsolationDomainResource>();
            await foreach (L2IsolationDomainResource item in DefaultSubscription.GetL2IsolationDomainsAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update Admin State
            TestContext.Out.WriteLine($"POST started.....");
            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Enable,
            };
            await l2IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);

            body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Disable,
            };
            await l2IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await l2IsolationDomain.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
