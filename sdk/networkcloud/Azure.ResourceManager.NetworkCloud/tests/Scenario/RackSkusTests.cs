// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class RackSkusTests : NetworkCloudManagementTestBase
    {
        public RackSkusTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public RackSkusTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task RackSkus()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;

            // List by Subscription
            RackSkuCollection rackSkusCollection = SubscriptionResource.GetRackSkus();
            var listBySubscription = new List<RackSkuResource>();
            await foreach (var item in rackSkusCollection.GetAllAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            var rackSkuName = listBySubscription[0].Data.Name;

            // Get
            ResourceIdentifier rackSkuResourceId = RackSkuResource.CreateResourceIdentifier(subscriptionId, rackSkuName);
            RackSkuResource rackSkuResource = Client.GetRackSkuResource(rackSkuResourceId);
            RackSkuResource getResult = await rackSkuResource.GetAsync();
            Assert.AreEqual(rackSkuName, getResult.Data.Name);
        }
    }
}