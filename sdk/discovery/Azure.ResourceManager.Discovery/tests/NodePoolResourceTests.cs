// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for NodePool resource operations.
    /// NodePool is a child resource of Supercomputer.
    /// </summary>
    public class NodePoolResourceTests : DiscoveryManagementTestBase
    {
        public NodePoolResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Requires existing NodePool in the supercomputer")]
        public async Task ListNodePoolsBySupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(TestEnvironment.SupercomputerName);

            // Act
            var nodePools = new List<NodePoolResource>();
            await foreach (var nodePool in supercomputer.Value.GetNodePools().GetAllAsync())
            {
                nodePools.Add(nodePool);
            }

            // Assert
            Assert.That(nodePools, Is.Not.Null);
        }

        [RecordedTest]
        [Ignore("Requires existing NodePool in the supercomputer")]
        public async Task GetNodePool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(TestEnvironment.SupercomputerName);

            // TODO: Replace with actual node pool name from TestEnvironment
            var nodePoolName = "test-nodepool";

            // Act
            var nodePool = await supercomputer.Value.GetNodePools().GetAsync(nodePoolName);

            // Assert
            Assert.That(nodePool.Value, Is.Not.Null);
            Assert.That(nodePool.Value.Data.Name, Is.EqualTo(nodePoolName));
        }

        [RecordedTest]
        [Ignore("Requires NodePoolProperties with VM size and network configuration")]
        public async Task CreateNodePool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(TestEnvironment.SupercomputerName);
            var nodePoolName = Recording.GenerateAssetName("nodepool-");

            // TODO: NodePool creation requires:
            // 1. NodePoolProperties with VmSize
            // 2. Network configuration (subnet IDs)
            // 3. Node count and scaling configuration
            var nodePoolData = new NodePoolData(DefaultLocation)
            {
                Tags =
                {
                    { "test", "value" }
                }
            };

            // Act
            var operation = await supercomputer.Value.GetNodePools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                nodePoolName,
                nodePoolData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(nodePoolName));
        }

        [RecordedTest]
        [Ignore("Requires existing NodePool to update")]
        public async Task UpdateNodePool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(TestEnvironment.SupercomputerName);

            // TODO: Replace with actual node pool name from TestEnvironment
            var nodePoolName = "test-nodepool";
            var nodePool = await supercomputer.Value.GetNodePools().GetAsync(nodePoolName);

            // Create update data with modified tags
            var updateData = nodePool.Value.Data;
            updateData.Tags["updated"] = "true";

            // Act
            var operation = await supercomputer.Value.GetNodePools().CreateOrUpdateAsync(
                WaitUntil.Completed,
                nodePoolName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("updated"), Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing NodePool to delete")]
        public async Task DeleteNodePool()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(TestEnvironment.SupercomputerName);

            // TODO: Either create a NodePool first, then delete it
            // Or use an existing node pool that can be deleted
            var nodePoolName = "nodepool-to-delete";
            var nodePool = await supercomputer.Value.GetNodePools().GetAsync(nodePoolName);

            // Act
            var operation = await nodePool.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }
    }
}
