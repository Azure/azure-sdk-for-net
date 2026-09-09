// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests.Scenario
{
    public class NodePoolCollectionTests : DiscoveryManagementTestBase
    {
        private const string ResourceGroupName = "rgname";
        private const string SupercomputerName = "sanitized-supercomputer";
        private const string NodePoolName = "sanitized-nodepool";

        public NodePoolCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup() => InitializeClient();

        private DiscoveryNodePoolCollection GetNodePoolCollection()
            => Client.GetDiscoverySupercomputerResource(DiscoverySupercomputerResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, SupercomputerName)).GetDiscoveryNodePools();

        private DiscoveryNodePoolResource GetNodePoolReference()
            => Client.GetDiscoveryNodePoolResource(DiscoveryNodePoolResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupName, SupercomputerName, NodePoolName));

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ArmOperation<DiscoveryNodePoolResource> operation = await GetNodePoolCollection().CreateOrUpdateAsync(WaitUntil.Completed, NodePoolName, new DiscoveryNodePoolData(AzureLocation.UKSouth));

            Assert.That(operation.HasValue, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(NodePoolName));
        }

        [RecordedTest]
        public async Task Get()
        {
            Response<DiscoveryNodePoolResource> response = await GetNodePoolCollection().GetAsync(NodePoolName);

            Assert.That(response.Value.Data.Name, Is.EqualTo(NodePoolName));
        }

        [RecordedTest]
        public async Task ListBySupercomputer()
        {
            List<DiscoveryNodePoolResource> items = new List<DiscoveryNodePoolResource>();
            await foreach (DiscoveryNodePoolResource item in GetNodePoolCollection().GetAllAsync())
            {
                items.Add(item);
            }

            Assert.That(items, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task Delete()
        {
            ArmOperation operation = await GetNodePoolReference().DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
