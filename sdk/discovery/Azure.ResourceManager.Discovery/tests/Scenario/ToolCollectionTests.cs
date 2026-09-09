// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class ToolCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string ToolName = "sanitized-tool";

        public ToolCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryToolCollection GetDiscoveryToolCollection()
            => GetResourceGroupReference(ResourceGroupName).GetDiscoveryTools();

        private DiscoveryToolResource GetToolReference()
            => Client.GetDiscoveryToolResource(DiscoveryToolResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, ToolName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryToolResource> operation = await GetDiscoveryToolCollection().CreateOrUpdateAsync(WaitUntil.Completed, ToolName, new DiscoveryToolData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ToolName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryToolResource> response = await GetDiscoveryToolCollection().GetAsync(ToolName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ToolName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<DiscoveryToolResource> items = new List<DiscoveryToolResource>();
            await foreach (DiscoveryToolResource item in GetDiscoveryToolCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<DiscoveryToolResource> items = new List<DiscoveryToolResource>();
            await foreach (DiscoveryToolResource item in GetSubscriptionReference().GetDiscoveryToolsAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<DiscoveryToolResource> operation = await GetToolReference().UpdateAsync(WaitUntil.Completed, new DiscoveryToolData(AzureLocation.UKSouth));

            Assert.That(operation.Value.Data.Name, Is.EqualTo(ToolName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetToolReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
