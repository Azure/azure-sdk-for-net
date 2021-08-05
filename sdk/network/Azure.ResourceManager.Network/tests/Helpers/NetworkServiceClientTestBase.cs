// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Tests;
using Azure.ResourceManager.TestFramework;

using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Helpers
{
    [RunFrequency(RunTestFrequency.Manually)]
    public class NetworkServiceClientTestBase : ManagementRecordedTestBase<NetworkManagementTestEnvironment>
    {
        public NetworkServiceClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public bool IsTestTenant = false;
        public static TimeSpan ZeroPollingInterval { get; } = TimeSpan.FromSeconds(0);
        public Dictionary<string, string> Tags { get; internal set; }

        public ResourcesManagementClient ResourceManagementClient { get; set; }
        public StorageManagementClient StorageManagementClient { get; set; }
        public ComputeManagementClient ComputeManagementClient { get; set; }
        public ArmClient ArmClient { get; set; }

        public Resources.Subscription Subscription
        {
            get
            {
                return ArmClient.DefaultSubscription;
            }
        }

        public Resources.ResourceGroup ResourceGroup
        {
            get
            {
                return Subscription.GetResourceGroups().Get(TestEnvironment.ResourceGroup).Value;
            }
        }

        public Resources.ResourceGroup GetResourceGroup(string name)
        {
            return Subscription.GetResourceGroups().Get(name).Value;
        }

        //public NetworkInterfacesOperations NetworkInterfacesOperations { get; set; }
        public ProvidersOperations ProvidersOperations { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public ResourcesOperations ResourcesOperations { get; set; }
        //public NetworkManagementOperations ServiceOperations { get; set; }
        //public PrivateLinkServicesOperations PrivateLinkServicesOperations { get; set; }

        protected void Initialize()
        {
            ResourceManagementClient = GetResourceManagementClient();
            StorageManagementClient = GetStorageManagementClient();
            ComputeManagementClient = GetComputeManagementClient();
            ArmClient = GetArmClient();

            //NetworkInterfacesOperations = NetworkManagementClient.NetworkInterfaces;
            ProvidersOperations = ResourceManagementClient.Providers;
            ResourceGroupsOperations = ResourceManagementClient.ResourceGroups;
            ResourcesOperations = ResourceManagementClient.Resources;
            //ServiceOperations = NetworkManagementClient.NetworkManagement;
            //PrivateLinkServicesOperations = NetworkManagementClient.PrivateLinkServices;
        }

        protected ResourcesManagementClient GetResourceManagementClient()
        {
            var options = InstrumentClientOptions(new ResourcesManagementClientOptions());

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                options);
        }

        private StorageManagementClient GetStorageManagementClient()
        {
            return InstrumentClient(new StorageManagementClient(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 InstrumentClientOptions(new StorageManagementClientOptions())));
        }

        private ComputeManagementClient GetComputeManagementClient()
        {
            return InstrumentClient(new ComputeManagementClient(TestEnvironment.SubscriptionId,
                 TestEnvironment.Credential,
                 InstrumentClientOptions(new ComputeManagementClientOptions())));
        }

        //private ArmClient GetArmClient()
        //{
            //if (string.IsNullOrEmpty(TestEnvironment.SubscriptionId))
            //{
            //    return new ArmClient(TestEnvironment.Credential);
            //} else
            //{
            //    return new ArmClient(TestEnvironment.SubscriptionId, TestEnvironment.Credential);
            //}
        //}

        protected async Task<Response<Resources.ResourceGroup>> CreateResourceGroup(string name)
        {
            return await Subscription.GetResourceGroups().CreateOrUpdateAsync(name, new ResourceGroupData(TestEnvironment.Location));
        }

        public async Task CreateVm(
            ResourcesManagementClient resourcesClient,
            string resourceGroupName,
            string location,
            string virtualMachineName,
            string storageAccountName,
            string networkInterfaceName,
            string networkSecurityGroupName,
            string diagnosticsStorageAccountName,
            string deploymentName,
            string adminPassword)
        {
            string deploymentParams = "{" +
                "\"resourceGroupName\": {\"value\": \"" + resourceGroupName + "\"}," +
                "\"location\": {\"value\": \"" + location + "\"}," +
                "\"virtualMachineName\": { \"value\": \"" + virtualMachineName + "\"}," +
                "\"virtualMachineSize\": { \"value\": \"Standard_DS1_v2\"}," +
                "\"adminUsername\": { \"value\": \"netanalytics32\"}," +
                "\"storageAccountName\": { \"value\": \"" + storageAccountName + "\"}," +
                "\"routeTableName\": { \"value\": \"" + resourceGroupName + "RT\"}," +
                "\"virtualNetworkName\": { \"value\": \"" + resourceGroupName + "-vnet\"}," +
                "\"networkInterfaceName\": { \"value\": \"" + networkInterfaceName + "\"}," +
                "\"networkSecurityGroupName\": { \"value\": \"" + networkSecurityGroupName + "\"}," +
                "\"adminPassword\": { \"value\": \"" + adminPassword + "\"}," +
                "\"storageAccountType\": { \"value\": \"Premium_LRS\"}," +
                "\"diagnosticsStorageAccountName\": { \"value\": \"" + diagnosticsStorageAccountName + "\"}," +
                "\"diagnosticsStorageAccountId\": { \"value\": \"Microsoft.Storage/storageAccounts/" + diagnosticsStorageAccountName + "\"}," +
                "\"diagnosticsStorageAccountType\": { \"value\": \"Standard_LRS\"}," +
                "\"addressPrefix\": { \"value\": \"10.17.3.0/24\"}," +
                "\"subnetName\": { \"value\": \"default\"}, \"subnetPrefix\": { \"value\": \"10.17.3.0/24\"}," +
                "\"publicIpAddressName\": { \"value\": \"" + virtualMachineName + "-ip\"}," +
                "\"publicIpAddressType\": { \"value\": \"Dynamic\"}" +
                "}";
            string templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "DeploymentTemplate.json"));

            DeploymentProperties deploymentProperties = new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = templateString,
                Parameters = deploymentParams
            };
            Deployment deploymentModel = new Deployment(deploymentProperties);

            Operation<DeploymentExtended> deploymentWait = await resourcesClient.Deployments.StartCreateOrUpdateAsync(resourceGroupName, deploymentName, deploymentModel);
            await deploymentWait.WaitForCompletionAsync();
        }

        public async Task CreateVmss(ResourcesManagementClient resourcesClient, string resourceGroupName, string deploymentName)
        {
            string templateString = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestData", "VmssDeploymentTemplate.json"));

            DeploymentProperties deploymentProperties = new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = templateString
            };
            Deployment deploymentModel = new Deployment(deploymentProperties);
            Operation<DeploymentExtended> deploymentWait = await resourcesClient.Deployments.StartCreateOrUpdateAsync(resourceGroupName, deploymentName, deploymentModel);
            await deploymentWait.WaitForCompletionAsync();
        }

        public async Task<ExpressRouteCircuit> CreateDefaultExpressRouteCircuit(string resourceGroupName, string circuitName, string location)
        {
            var sku = new ExpressRouteCircuitSku
            {
                Name = "Premium_MeteredData",
                Tier = "Premium",
                Family = "MeteredData"
            };

            var provider = new ExpressRouteCircuitServiceProviderProperties
            {
                BandwidthInMbps = Convert.ToInt32(ExpressRouteTests.Circuit_BW),
                PeeringLocation = ExpressRouteTests.Circuit_Location,
                ServiceProviderName = ExpressRouteTests.Circuit_Provider
            };

            var circuit = new ExpressRouteCircuitData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                Sku = sku,
                ServiceProviderProperties = provider
            };

            // Put circuit
            var circuitContainer = GetResourceGroup(resourceGroupName).GetExpressRouteCircuits();
            Operation<ExpressRouteCircuit> circuitOperation = await circuitContainer.StartCreateOrUpdateAsync(circuitName, circuit);
            Response<ExpressRouteCircuit> circuitResponse = await circuitOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", circuitResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await circuitContainer.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName)
        {
            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
            };

            var circuitContainer = GetResourceGroup(resourceGroupName).GetExpressRouteCircuits();
            Operation<ExpressRouteCircuitPeering> peerOperation = await circuitContainer.Get(circuitName).Value.GetExpressRouteCircuitPeerings().StartCreateOrUpdateAsync(ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await circuitContainer.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithIpv6MicrosoftPeering(string resourceGroupName, string circuitName)
        {
            var ipv6Peering = new Ipv6ExpressRouteCircuitPeeringConfig()
            {
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix_V6,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix_V6,
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix_V6
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
            };

            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                Ipv6PeeringConfig = ipv6Peering
            };

            var circuitContainer = GetResourceGroup(resourceGroupName).GetExpressRouteCircuits();
            Operation<ExpressRouteCircuitPeering> peerOperation = await circuitContainer.Get(circuitName).Value.GetExpressRouteCircuitPeerings().StartCreateOrUpdateAsync(ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await circuitContainer.GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<ExpressRouteCircuit> UpdateDefaultExpressRouteCircuitWithMicrosoftPeering(string resourceGroupName, string circuitName,
            RouteFilter filter)
        {
            var peering = new ExpressRouteCircuitPeeringData()
            {
                Name = ExpressRoutePeeringType.MicrosoftPeering.ToString(),
                PeeringType = ExpressRoutePeeringType.MicrosoftPeering,
                PeerASN = Convert.ToInt32(ExpressRouteTests.MS_PeerASN),
                PrimaryPeerAddressPrefix = ExpressRouteTests.MS_PrimaryPrefix,
                SecondaryPeerAddressPrefix = ExpressRouteTests.MS_SecondaryPrefix,
                VlanId = Convert.ToInt32(ExpressRouteTests.MS_VlanId),
                MicrosoftPeeringConfig = new ExpressRouteCircuitPeeringConfig()
                {
                    AdvertisedPublicPrefixes = {
                        ExpressRouteTests.MS_PublicPrefix
                    },
                    LegacyMode = Convert.ToInt32(true)
                },
                RouteFilter = { Id = filter.Id }
            };

            Operation<ExpressRouteCircuitPeering> peerOperation = await GetResourceGroup(resourceGroupName).GetExpressRouteCircuits().Get(circuitName).Value.GetExpressRouteCircuitPeerings().StartCreateOrUpdateAsync(ExpressRouteTests.Peering_Microsoft, peering);
            Response<ExpressRouteCircuitPeering> peerResponse = await peerOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", peerResponse.Value.Data.ProvisioningState.ToString());
            Response<ExpressRouteCircuit> getCircuitResponse = await GetResourceGroup(resourceGroupName).GetExpressRouteCircuits().GetAsync(circuitName);

            return getCircuitResponse;
        }

        public async Task<PublicIPAddress> CreateDefaultPublicIpAddress(string name, string domainNameLabel, string location, PublicIPAddressContainer publicIPAddressContainer)
        {
            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            Operation<PublicIPAddress> putPublicIpAddressOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(name, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(name);

            return getPublicIpAddressResponse;
        }

        public async Task<PublicIPAddress> CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location)
        {
            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel }
            };

            // Put nic1PublicIpAddress
            var publicIPAddressContainer = GetResourceGroup(resourceGroupName).GetPublicIPAddresses();
            Operation<PublicIPAddress> putPublicIpAddressOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(name, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(name);

            return getPublicIpAddressResponse;
        }

        public async Task<NetworkInterface> CreateNetworkInterface(string name, string resourceGroupName, string publicIpAddressId, string subnetId,
            string location, string ipConfigName)
        {
            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IpConfigurations = {
                    new NetworkInterfaceIPConfiguration()
                    {
                         Name = ipConfigName,
                         PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                         Subnet = new SubnetData() { Id = subnetId }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new PublicIPAddressData() { /*Id = publicIpAddressId*/ };
            }

            // Test NIC apis
            var networkInterfaceContainer = GetResourceGroup(resourceGroupName).GetNetworkInterfaces();
            await networkInterfaceContainer.StartCreateOrUpdateAsync(name, nicParameters);
            Response<NetworkInterface> getNicResponse = await networkInterfaceContainer.GetAsync(name);
            Assert.AreEqual(getNicResponse.Value.Data.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.Value.Data.IpConfigurations[0].Primary);

            Assert.AreEqual("Succeeded", getNicResponse.Value.Data.ProvisioningState.ToString());

            return getNicResponse;
        }
        public async Task<NetworkInterface> CreateNetworkInterface(string name,  string publicIpAddressId, string subnetId,
            string location, string ipConfigName, NetworkInterfaceContainer networkInterfaceContainer)
        {
            var nicParameters = new NetworkInterfaceData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                IpConfigurations = {
                    new NetworkInterfaceIPConfiguration()
                    {
                         Name = ipConfigName,
                         PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                         Subnet = new SubnetData() { Id = subnetId }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new PublicIPAddressData() { /*Id = publicIpAddressId*/ };
            }

            // Test NIC apis
            await networkInterfaceContainer.StartCreateOrUpdateAsync(name, nicParameters);
            Response<NetworkInterface> getNicResponse = await networkInterfaceContainer.GetAsync(name);
            Assert.AreEqual(getNicResponse.Value.Data.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.True(getNicResponse.Value.Data.IpConfigurations[0].Primary);

            Assert.AreEqual("Succeeded", getNicResponse.Value.Data.ProvisioningState.ToString());

            return getNicResponse;
        }
        public async Task<VirtualNetwork> CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            var virtualNetworkContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworks();
            await virtualNetworkContainer.StartCreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkContainer.GetAsync(vnetName);

            return getVnetResponse;
        }

        public async Task<VirtualNetwork> CreateVirtualNetwork(string vnetName, string subnetName, string location, VirtualNetworkContainer virtualNetworkContainer)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            await virtualNetworkContainer.StartCreateOrUpdateAsync(vnetName, vnet);
            Response<VirtualNetwork> getVnetResponse = await virtualNetworkContainer.GetAsync(vnetName);

            return getVnetResponse;
        }

        public static string GetChildLbResourceId(string subscriptionId, string resourceGroupName, string lbname, string childResourceType, string childResourceName)
        {
            return
                string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName);
        }

        protected ApplicationGatewayContainer GetApplicationGatewayContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetApplicationGateways();
        }

        protected LoadBalancerContainer GetLoadBalancerContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetLoadBalancers();
        }

        protected LoadBalancerContainer GetLoadBalancerContainer(Resources.ResourceGroup resourceGroup)
        {
            return resourceGroup.GetLoadBalancers();
        }

        protected PublicIPAddressContainer GetPublicIPAddressContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetPublicIPAddresses();
        }

        protected VirtualNetworkContainer GetVirtualNetworkContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetVirtualNetworks();
        }

        protected VirtualNetworkContainer GetVirtualNetworkContainer(Resources.ResourceGroup resourceGroup)
        {
            return resourceGroup.GetVirtualNetworks();
        }
        protected NetworkInterfaceContainer GetNetworkInterfaceContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkInterfaces();
        }

        protected NetworkSecurityGroupContainer GetNetworkSecurityGroupContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkSecurityGroups();
        }

        protected RouteTableContainer GetRouteTableContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetRouteTables();
        }

        protected RouteFilterContainer GetRouteFilterContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetRouteFilters();
        }

        protected NetworkWatcherContainer GetNetworkWatcherContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetNetworkWatchers();
        }

        protected VirtualNetworkGatewayContainer GetVirtualNetworkGatewayContainer(string resourceGroupName)
        {
            return GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
        }
    }
}
