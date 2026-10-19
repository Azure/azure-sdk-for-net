// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests.Scenario
{
    public class EdgeActionCollectionTests : EdgeActionsManagementTestBase
    {
        public EdgeActionCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task Exists()
        {
            SubscriptionResource subscription = Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{TestEnvironment.SubscriptionId}"));
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "dotnetsdk-edgeaction-test-");
            EdgeActionCollection collection = rg.GetEdgeActions();

            bool exists = await collection.ExistsAsync("nonexistent-edgeaction", TestCancellationToken);
            Assert.IsFalse(exists);
            Assert.That((await collection.GetIfExistsAsync("nonexistent-edgeaction", TestCancellationToken)).HasValue, Is.False);
        }
    }
}
