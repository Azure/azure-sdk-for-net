// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryBillingContainersOperationsTest : DeviceRegistryManagementTestBase
    {
        private readonly string _subscriptionId = "8c64812d-6e59-4e65-96b3-14a7cdb1a4e4";
        private readonly string _billingContainerName = "deviceregistry-test-billingcontainer-sdk";
        private readonly string _provisioningStateSucceeded = "Succeeded";

        public DeviceRegistryBillingContainersOperationsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task BillingContainersCrudOperationsTest()
        {
            var subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{_subscriptionId}"));

            // Read DeviceRegistry BillingContainer
            var billingContainerReadResponse = await subscription.GetBillingContainerAsync(_billingContainerName, CancellationToken.None);
            Assert.IsNotNull(billingContainerReadResponse.Value);
            Assert.AreEqual(billingContainerReadResponse.Value.Data.Properties.ProvisioningState, _provisioningStateSucceeded);

            // List DeviceRegistry BillingContainer by Subscription
            var billingContainerResourcesListBySubscription = new List<BillingContainerResource>();
            var billingContainerResourceListBySubscriptionAsyncIterator = subscription.GetBillingContainers();
            await foreach (var billingContainerEntry in billingContainerResourceListBySubscriptionAsyncIterator)
            {
                billingContainerResourcesListBySubscription.Add(billingContainerEntry);
            }
            Assert.IsNotEmpty(billingContainerResourcesListBySubscription);
            Assert.AreEqual(billingContainerResourcesListBySubscription.Count, 1);
            Assert.AreEqual(billingContainerResourcesListBySubscription[0].Data.Properties.ProvisioningState, _provisioningStateSucceeded);
        }
    }
}
