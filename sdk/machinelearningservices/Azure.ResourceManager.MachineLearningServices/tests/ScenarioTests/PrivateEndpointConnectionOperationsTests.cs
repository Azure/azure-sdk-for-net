// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MachineLearningServices.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.ScenarioTests
{
    public class PrivateEndpointConnectionOperationsTests : MachineLearningServicesManagerTestBase
    {
        public PrivateEndpointConnectionOperationsTests(bool isAsync)
         : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            var workspace = await CreateMLWorkspaceAsync(rg, workspaceName);
            await PreparePrivateEndpoint(rg.Data.Name, workspace.Id.ToString());

            // Connection name is a random value?
            var connections = await workspace.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            await connections.FirstOrDefault().DeleteAsync();
            connections = await workspace.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.Zero(connections.Count);
        }

        [TestCase]
        [RecordedTest]
        public async Task StartDelete()
        {
            ResourceGroup rg = await CreateTestResourceGroup();
            var workspaceName = Recording.GenerateAssetName("testmlCreate");
            var workspace = await CreateMLWorkspaceAsync(rg, workspaceName);
            await PreparePrivateEndpoint(rg.Data.Name, workspace.Id.ToString());

            // Connection name is a random value?
            var connections = await workspace.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            await (await connections.FirstOrDefault().StartDeleteAsync()).WaitForCompletionResponseAsync();
            connections = await workspace.GetPrivateEndpointConnections().GetAllAsync().ToEnumerableAsync();
            Assert.Zero(connections.Count);
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

        private async Task PreparePrivateEndpoint(string rgName, string workspaceId)
        {
            var networkClient = new NetworkManagementClient(Client.DefaultSubscription.Id.SubscriptionId, TestEnvironment.Credential);

            // Create a VNet
            var vnetName = Recording.GenerateAssetName("testmlvnet");
            var vnetParameter = new Network.Models.VirtualNetwork()
            {
                AddressSpace = new Network.Models.AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16" }
                },
                Location = TestEnvironment.Location,
                Subnets = {
                    new Network.Models.Subnet() { Name = "frontendSubnet", AddressPrefix = "10.0.1.0/24", PrivateEndpointNetworkPolicies = "Disabled"},
                    new Network.Models.Subnet() { Name = "backendSubnet", AddressPrefix = "10.0.2.0/24", PrivateEndpointNetworkPolicies = "Disabled"},
                }
            };
            var vnet = await (await networkClient.VirtualNetworks.StartCreateOrUpdateAsync(rgName, vnetName, vnetParameter)).WaitForCompletionAsync();

            // Create a PrivateEndpoint
            var connectionName = Recording.GenerateAssetName("testmlCon");
            var endpointName = Recording.GenerateAssetName("testmlep");
            var endpointParameter = new Network.Models.PrivateEndpoint()
            {
                Location = TestEnvironment.Location,
                PrivateLinkServiceConnections = {
                    new Network.Models.PrivateLinkServiceConnection()
                    {
                        Name = connectionName,
                        PrivateLinkServiceId = workspaceId,
                        GroupIds = { "amlworkspace" },
                        RequestMessage = "Please approve my connection."
                    }
                },
                Subnet = new Network.Models.Subnet() { Id = vnet.Value.Subnets.FirstOrDefault().Id }
            };
            var endpoint = await (await networkClient.PrivateEndpoints.StartCreateOrUpdateAsync(rgName, endpointName, endpointParameter)).WaitForCompletionAsync();
        }
    }
}
