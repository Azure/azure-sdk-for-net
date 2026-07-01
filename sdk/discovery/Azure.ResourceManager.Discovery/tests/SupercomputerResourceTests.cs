// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Discovery.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    /// <summary>
    /// Tests for Supercomputer resource operations.
    /// </summary>
    public class SupercomputerResourceTests : DiscoveryManagementTestBase
    {
        public SupercomputerResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]

        public async Task ListSupercomputersBySubscription()
        {
            // Arrange & Act
            var supercomputers = new List<SupercomputerResource>();
            await foreach (var supercomputer in DefaultSubscription.GetSupercomputersAsync())
            {
                supercomputers.Add(supercomputer);
            }

            // Assert
            Assert.That(supercomputers, Is.Not.Null);
            // List may be empty but should not throw
        }

        [RecordedTest]

        public async Task ListSupercomputersByResourceGroup()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);

            // Act
            var supercomputers = new List<SupercomputerResource>();
            await foreach (var supercomputer in resourceGroup.GetSupercomputers().GetAllAsync())
            {
                supercomputers.Add(supercomputer);
            }

            // Assert
            Assert.That(supercomputers, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = TestEnvironment.SupercomputerName;

            // Act
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Assert
            Assert.That(supercomputer.Value, Is.Not.Null);
            Assert.That(supercomputer.Value.Data.Name, Is.EqualTo(supercomputerName));
        }

        [RecordedTest]
        [Ignore("Recording not yet captured")]
        public async Task CreateSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = "test-sc-dotnet02";

            var subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var miId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourcegroups/olawal/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myidentity");
            var subnetId = new ResourceIdentifier($"/subscriptions/{subscriptionId}/resourceGroups/olawal/providers/Microsoft.Network/virtualNetworks/newapiv/subnets/default");

            var identities = new SupercomputerIdentities(
                clusterIdentity: new Discovery.Models.Identity(miId),
                kubeletIdentity: new Discovery.Models.Identity(miId));
            identities.WorkloadIdentities.Add(miId.ToString(), new Azure.ResourceManager.Models.UserAssignedIdentity());

            var supercomputerData = new SupercomputerData(DefaultLocation)
            {
                Properties = new SupercomputerProperties(subnetId, identities),
            };

            // Act
            var operation = await resourceGroup.GetSupercomputers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                supercomputerName,
                supercomputerData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Name, Is.EqualTo(supercomputerName));
        }

        [RecordedTest]
        [Ignore("Requires existing supercomputer to delete - should create first then delete")]
        public async Task DeleteSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = "test-sc-dotnet02";
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Act
            var operation = await supercomputer.Value.DeleteAsync(WaitUntil.Completed);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
        }

        [RecordedTest]
        [Ignore("Requires existing supercomputer with properties that can be updated")]
        public async Task UpdateSupercomputer()
        {
            // Arrange
            var resourceGroup = await GetResourceGroupAsync(TestEnvironment.ResourceGroupName);
            var supercomputerName = TestEnvironment.SupercomputerName;
            var supercomputer = await resourceGroup.GetSupercomputers().GetAsync(supercomputerName);

            // Update tags matching Python/Java pattern
            var updateData = supercomputer.Value.Data;
            updateData.Tags["SkipAutoDeleteTill"] = "2026-12-31";

            // Act
            var operation = await resourceGroup.GetSupercomputers().CreateOrUpdateAsync(
                WaitUntil.Completed,
                supercomputerName,
                updateData);

            // Assert
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.Tags.ContainsKey("SkipAutoDeleteTill"), Is.True);
        }
    }
}
