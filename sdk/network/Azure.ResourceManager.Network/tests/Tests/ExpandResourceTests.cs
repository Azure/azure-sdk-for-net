// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ExpandResourceTests : NetworkTestsManagementClientBase
    {
        public ExpandResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ExpandResourceTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(
                lbPublicIpName,
                resourceGroupName,
                lbDomaingNameLabel,
                location,
                NetworkManagementClient);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");
            string nic3name = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nic1 = await CreateNetworkInterface(
                nic1name,
                resourceGroupName,
                null,
                vnet.Subnets[0].Id,
                location,
                "ipconfig",
                NetworkManagementClient);

            NetworkInterface nic2 = await CreateNetworkInterface(
                nic2name,
                resourceGroupName,
                null,
                vnet.Subnets[0].Id,
                location,
                "ipconfig",
                NetworkManagementClient);

            NetworkInterface nic3 = await CreateNetworkInterface(
                nic3name,
                resourceGroupName,
                null,
                vnet.Subnets[0].Id,
                location,
                "ipconfig",
                NetworkManagementClient);

            // Create the LoadBalancer
            var lbName = Recording.GenerateAssetName("azsmnet");
            var frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            var backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            var loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            var probeName = Recording.GenerateAssetName("azsmnet");
            var inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            var inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadBalancer = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PublicIPAddress = new PublicIPAddress()
                        {
                            Id = lbPublicIp.Id
                        }
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backEndAddressPoolName,
                    }
                },
                LoadBalancingRules = new List<LoadBalancingRule>()
                {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
                        IdleTimeoutInMinutes = 15,
                        BackendAddressPool = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                        },
                        Probe = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "probes", probeName)
                        }
                    }
                },
                Probes = new List<Probe>()
                {
                    new Probe()
                    {
                        Name = probeName,
                        Protocol = ProbeProtocol.Http,
                        Port = 80,
                        RequestPath = "healthcheck.aspx",
                        IntervalInSeconds = 10,
                        NumberOfProbes = 2
                    }
                },
                InboundNatRules = new List<InboundNatRule>()
                {
                    new InboundNatRule()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false
                    },
                    new InboundNatRule()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            Operation<LoadBalancer> putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadBalancer);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Associate the nic with LB
            nic1.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool> { getLoadBalancer.Value.BackendAddressPools.First() };
            nic1.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule> { getLoadBalancer.Value.InboundNatRules.First() };
            nic2.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool> { getLoadBalancer.Value.BackendAddressPools.First() };
            nic3.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule> { getLoadBalancer.Value.InboundNatRules[1] };

            // Put Nics
            NetworkInterfacesCreateOrUpdateOperation createOrUpdateOperation1 = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic1name, nic1);
            await WaitForCompletionAsync(createOrUpdateOperation1);

            NetworkInterfacesCreateOrUpdateOperation createOrUpdateOperation2 = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic2name, nic2);
            await WaitForCompletionAsync(createOrUpdateOperation2);

            NetworkInterfacesCreateOrUpdateOperation createOrUpdateOperation3 = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic3name, nic3);
            await WaitForCompletionAsync(createOrUpdateOperation3);

            // Get Nics
            await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic1name);
            await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic2name);
            await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic3name);

            // Get lb with expanded nics from nat rules
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName, "InboundNatRules/backendIPConfiguration");

            foreach (InboundNatRule natRule in getLoadBalancer.Value.InboundNatRules)
            {
                Assert.NotNull(natRule.BackendIPConfiguration);
                Assert.NotNull(natRule.BackendIPConfiguration.Id);
                Assert.NotNull(natRule.BackendIPConfiguration.Name);
                Assert.NotNull(natRule.BackendIPConfiguration.Etag);
                Assert.AreEqual(natRule.Id, natRule.BackendIPConfiguration.LoadBalancerInboundNatRules[0].Id);
            }

            // Get lb with expanded nics from pools
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName, "BackendAddressPools/backendIPConfigurations");

            foreach (BackendAddressPool pool in getLoadBalancer.Value.BackendAddressPools)
            {
                foreach (NetworkInterfaceIPConfiguration ipconfig in getLoadBalancer.Value.BackendAddressPools.First().BackendIPConfigurations)
                {
                    Assert.NotNull(ipconfig.Id);
                    Assert.NotNull(ipconfig.Name);
                    Assert.NotNull(ipconfig.Etag);
                    Assert.AreEqual(pool.Id, ipconfig.LoadBalancerBackendAddressPools[0].Id);
                }
            }

            // Get lb with expanded publicip
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName, "FrontendIPConfigurations/PublicIPAddress");
            foreach (FrontendIPConfiguration ipconfig in getLoadBalancer.Value.FrontendIPConfigurations)
            {
                Assert.NotNull(ipconfig.PublicIPAddress);
                Assert.NotNull(ipconfig.PublicIPAddress.Id);
                Assert.NotNull(ipconfig.PublicIPAddress.Name);
                Assert.NotNull(ipconfig.PublicIPAddress.Etag);
                Assert.AreEqual(ipconfig.Id, ipconfig.PublicIPAddress.IpConfiguration.Id);
            }

            // Get NIC with expanded subnet
            nic1 = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic1name, "IPConfigurations/Subnet");
            foreach (NetworkInterfaceIPConfiguration ipconfig in nic1.IpConfigurations)
            {
                Assert.NotNull(ipconfig.Subnet);
                Assert.NotNull(ipconfig.Subnet.Id);
                Assert.NotNull(ipconfig.Subnet.Name);
                Assert.NotNull(ipconfig.Subnet.Etag);
                Assert.IsNotEmpty(ipconfig.Subnet.IpConfigurations);
            }

            // Get subnet with expanded ipconfigurations
            Response<Subnet> subnet = await NetworkManagementClient.Subnets.GetAsync(
                resourceGroupName,
                vnetName,
                subnetName,
                "IPConfigurations");

            foreach (IPConfiguration ipconfig in subnet.Value.IpConfigurations)
            {
                Assert.NotNull(ipconfig.Name);
                Assert.NotNull(ipconfig.Id);
                Assert.NotNull(ipconfig.Etag);
                Assert.NotNull(ipconfig.PrivateIPAddress);
            }

            // Get publicIPAddress with expanded ipconfigurations
            Response<PublicIPAddress> publicip = await NetworkManagementClient.PublicIPAddresses.GetAsync(
                resourceGroupName,
                lbPublicIpName,
                "IPConfiguration");

            Assert.NotNull(publicip.Value.IpConfiguration);
            Assert.NotNull(publicip.Value.IpConfiguration.Id);
            Assert.NotNull(publicip.Value.IpConfiguration.Name);
            Assert.NotNull(publicip.Value.IpConfiguration.Etag);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all NetworkInterfaces
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nic1name);
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nic2name);
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nic3name);

            // Delete all PublicIPAddresses
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, lbPublicIpName);
        }
    }
}
