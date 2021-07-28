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
            var vnetParameter = new Network.Models.VirtualNetwork()
            {
                AddressSpace = new Network.Models.AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16" }
                },
                Location = TestEnvironment.Location,
                Subnets = {
                    new Network.Models.Subnet() { Name = "frontendSubnet", AddressPrefix = "10.0.1.0/24"},
                    new Network.Models.Subnet() { Name = "backendSubnet", AddressPrefix = "10.0.2.0/24"},
                }
            };
            var vnet = await (await networkClient.VirtualNetworks.StartCreateOrUpdateAsync(rg.Data.Name, vnetName, vnetParameter)).WaitForCompletionAsync();

            // Create a load balancer
            var loadName = Recording.GenerateAssetName("testmlload");
            var frontend = new Network.Models.FrontendIPConfiguration()
            {
                Name = "mlfrontend",
                PrivateIPAllocationMethod = Network.Models.IPAllocationMethod.Dynamic,
                Subnet = vnet.Value.Subnets.Where(x => x.Name.Equals("frontendSubnet")).FirstOrDefault()
            };
            var backend = new Network.Models.BackendAddressPool() { Name = "myBackEndPool" };
            var probe = new Network.Models.Probe()
            {
                Name = "myHealthProbe",
                Protocol = Network.Models.ProbeProtocol.Tcp,
                Port = 80,
                IntervalInSeconds = 15,
                NumberOfProbes = 2
            };
            var loadParameter = new Network.Models.LoadBalancer()
            {
                Location = TestEnvironment.Location,
                Sku = new Network.Models.LoadBalancerSku() { Name = Network.Models.LoadBalancerSkuName.Standard },
                FrontendIPConfigurations = { frontend },
                BackendAddressPools = { backend },
                InboundNatRules = {
                    new Network.Models.InboundNatRule()
                    {
                        Name = "RDP-VM0",
                        FrontendIPConfiguration = frontend,
                        Protocol = Network.Models.TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    }
                },
                LoadBalancingRules = {
                    new Network.Models.LoadBalancingRule()
                    {
                        Name = "myHTTPRule",
                        BackendAddressPool = backend,
                        Probe = probe,
                        Protocol = Network.Models.TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        IdleTimeoutInMinutes = 15
                    }
                }
            };
            var loadBalancer = await (await networkClient.LoadBalancers.StartCreateOrUpdateAsync(rg.Data.Name, loadName, loadParameter)).WaitForCompletionAsync();

            // Create a Private Link Service
            var linkName = Recording.GenerateAssetName("testmllink");
            var linkParameter = new Network.Models.PrivateLinkService()
            {
                Location = TestEnvironment.Location,
                EnableProxyProtocol = false,
                LoadBalancerFrontendIpConfigurations = { loadBalancer.Value.FrontendIPConfigurations.FirstOrDefault() },
                IpConfigurations =
                {
                    new Network.Models.PrivateLinkServiceIpConfiguration()
                    {
                        Name = "snet-provider-default-1",
                        PrivateIPAllocationMethod = Network.Models.IPAllocationMethod.Dynamic,
                        PrivateIPAddressVersion = Network.Models.IPVersion.IPv4,
                        Subnet = loadBalancer.Value.FrontendIPConfigurations.FirstOrDefault().Subnet,
                        Primary = false
                    }
                }
            };
            var privateLink = await (await networkClient.PrivateLinkServices.StartCreateOrUpdateAsync(rg.Data.Name, linkName, linkParameter)).WaitForCompletionAsync();
            // Create a PrivateEndpoint
            var endpointName = Recording.GenerateAssetName("testmlep");
            var endpointParameter = new Network.Models.PrivateEndpoint()
            {
                Location = TestEnvironment.Location,
                PrivateLinkServiceConnections = {
                    new Network.Models.PrivateLinkServiceConnection()
                    {
                        PrivateLinkServiceId = privateLink.Value.Id,
                        GroupIds = { "TestGroup" },
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
