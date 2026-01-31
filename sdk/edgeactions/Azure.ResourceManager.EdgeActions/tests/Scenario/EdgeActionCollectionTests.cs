// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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

        [TestCase]
        [RecordedTest]
        [Ignore("Test recordings not yet available. Will be recorded in future PR.")]
        public async Task Exists()
        {
            // This is a basic smoke test to verify the SDK can be instantiated
            // More comprehensive tests will be added in future PRs
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(subscription, "testRg-1");
            EdgeActionCollection collection = rg.GetEdgeActions();

            bool exists = await collection.ExistsAsync("nonexistent-edgeaction");
            Assert.IsFalse(exists);
        }
    }
}
