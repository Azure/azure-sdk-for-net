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

        private ToolCollection GetToolCollection()
            => GetResourceGroupReference(ResourceGroupName).GetTools();

        private ToolResource GetToolReference()
            => Client.GetToolResource(ToolResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, ToolName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<ToolResource> operation = await GetToolCollection().CreateOrUpdateAsync(WaitUntil.Completed, ToolName, new ToolData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(ToolName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<ToolResource> response = await GetToolCollection().GetAsync(ToolName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(ToolName));
        }

        [RecordedTest]
        public async Task ListByResourceGroup()
        {
            List<ToolResource> items = new List<ToolResource>();
            await foreach (ToolResource item in GetToolCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task ListBySubscription()
        {
            List<ToolResource> items = new List<ToolResource>();
            await foreach (ToolResource item in GetSubscriptionReference().GetToolsAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Update()
        {
            ArmOperation<ToolResource> operation = await GetToolReference().UpdateAsync(WaitUntil.Completed, new ToolData(AzureLocation.UKSouth));

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
