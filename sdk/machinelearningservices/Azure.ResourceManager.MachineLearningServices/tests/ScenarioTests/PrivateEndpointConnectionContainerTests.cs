// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class PrivateEndpointConnectionContainerTests : MachineLearningServicesManagerTestBase
    {
        public PrivateEndpointConnectionContainerTests(bool isAsync)
         : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            var workspace = await CreateMLWorkspaceAsync(rg, workspaceName);

            var networkClient = new NetworkManagementClient(Client.DefaultSubscription.Id.SubscriptionId, TestEnvironment.Credential);
            // Create a VNet
            var vnetName = Recording.GenerateAssetName("testmlvnet");
            var subnetName = Recording.GenerateAssetName("testmlsubnet");
            var vnetParameter = new Network.Models.VirtualNetwork()
            {
                AddressSpace = new Network.Models.AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16" }
                },
                Location = TestEnvironment.Location,
                Subnets = { new Network.Models.Subnet() { Name = subnetName, AddressPrefix = "10.0.1.0/24" } }
            };
            var vnet = await (await networkClient.VirtualNetworks.StartCreateOrUpdateAsync(rg.Data.Name, vnetName, vnetParameter)).WaitForCompletionAsync();

            // Create a PrivateEndpoint
            var endpointName = Recording.GenerateAssetName("testmlep");
            var endpointParameter = new Network.Models.PrivateEndpoint()
            {
                Location = TestEnvironment.Location,
                PrivateLinkServiceConnections = {
                    new Network.Models.PrivateLinkServiceConnection()
                    {
                        PrivateLinkServiceId = workspace.Id.ToString(),
                        GroupIds = { rg.Id.ToString() },
                        RequestMessage = "Please approve my connection."
                    }
                },
                Subnet = vnet.Value.Subnets.FirstOrDefault()
            };
            var endpoint = await (await networkClient.PrivateEndpoints.StartCreateOrUpdateAsync(rg.Data.Name, endpointName, endpointParameter)).WaitForCompletionAsync();

            var connectionName = Recording.GenerateAssetName("testmlCon");
            var connectionParameter = new PrivateEndpointConnectionData()
            {
                PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionState()
                {
                    Status = PrivateEndpointServiceConnectionStatus.Approved,
                    Description = "Auto-Approved"
                }
            };
            var connection = await workspace.GetPrivateEndpointConnections().CreateOrUpdateAsync(connectionName, connectionParameter).ConfigureAwait(false);
            Assert.IsTrue(connection.Value.Data.Name.Equals(connectionName));
        }

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            var workspace = await CreateMLWorkspaceAsync(rg, workspaceName);

            var connectionName = Recording.GenerateAssetName("testmlCon");
            var connectionParameter = new PrivateEndpointConnectionData()
            {
                PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionState()
                {
                    Status = PrivateEndpointServiceConnectionStatus.Approved,
                    Description = "Auto-Approved"
                }
            };
            var connection = await workspace.GetPrivateEndpointConnections().StartCreateOrUpdateAsync(connectionName, connectionParameter);
            Assert.IsTrue(connection.Value.Data.Name.Equals(connectionName));
        }

        private async Task<ResourceGroup> CreateTestResourceGroup()
        {
            return await Client
                .DefaultSubscription
                .GetResourceGroups()
                .CreateOrUpdateAsync(
                    Recording.GenerateAssetName("testmlrg"),
                    new ResourceGroupData(Location.WestUS2));
        }
    }
}
