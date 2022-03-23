// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Network.Tests
{
    public class ExpandResourceTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;

        public ExpandResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        [Test]
        [RecordedTest]
        public async Task ExpandResourceTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource lbPublicIp = await CreateDefaultPublicIpAddress(
                lbPublicIpName,
                lbDomaingNameLabel,
                location,
                resourceGroup.GetPublicIPAddresses());

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");
            string nic3name = Recording.GenerateAssetName("azsmnet");

            NetworkInterfaceResource nic1 = await CreateNetworkInterface(
                nic1name,
                null,
                vnet.Data.Subnets[0].Id,
                location,
                "ipconfig",
                resourceGroup.GetNetworkInterfaces());

            NetworkInterfaceResource nic2 = await CreateNetworkInterface(
                nic2name,
                null,
                vnet.Data.Subnets[0].Id,
                location,
                "ipconfig",
                resourceGroup.GetNetworkInterfaces());

            NetworkInterfaceResource nic3 = await CreateNetworkInterface(
                nic3name,
                null,
                vnet.Data.Subnets[0].Id,
                location,
                "ipconfig",
                resourceGroup.GetNetworkInterfaces());

            // Create the LoadBalancer
            var lbName = Recording.GenerateAssetName("azsmnet");
            var frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            var backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            var loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            var probeName = Recording.GenerateAssetName("azsmnet");
            var inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            var inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadBalancerData = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfigurationData()
                    {
                        Name = frontendIpConfigName,
                        PublicIPAddress = new PublicIPAddressData()
                        {
                            Id = lbPublicIp.Id
                        }
                    }
                },
                BackendAddressPools = {
                    new BackendAddressPoolData()
                    {
                        Name = backEndAddressPoolName,
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
                        IdleTimeoutInMinutes = 15,
                        BackendAddressPool = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                        },
                        Probe = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "probes", probeName)
                        }
                    }
                },
                Probes = {
                    new ProbeData()
                    {
                        Name = probeName,
                        Protocol = ProbeProtocol.Http,
                        Port = 80,
                        RequestPath = "healthcheck.aspx",
                        IntervalInSeconds = 10,
                        NumberOfProbes = 2
                    }
                },
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            LoadBalancerResource loadBalancer = (await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadBalancerData)).Value;

            // Associate the nic with LB
            //nic1.GetNetworkInterfaceIPConfigurations().List().First().`
            // TODO: where do we have the following?
            //nic1.IpConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.BackendAddressPools.First());
            //nic1.IpConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.InboundNatRules.First());
            //nic2.IpConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.BackendAddressPools.First());
            //nic3.IpConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.InboundNatRules[1]);
            nic1.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());
            nic1.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(loadBalancer.Data.InboundNatRules[0]);
            nic2.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());
            nic2.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(loadBalancer.Data.InboundNatRules[1]);
            nic3.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());

            // Put Nics
            var networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            var createOrUpdateOperation1 = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic1name, nic1.Data);
            await createOrUpdateOperation1.WaitForCompletionAsync();

            var createOrUpdateOperation2 = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic2name, nic2.Data);
            await createOrUpdateOperation2.WaitForCompletionAsync();

            var createOrUpdateOperation3 = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic3name, nic3.Data);
            await createOrUpdateOperation3.WaitForCompletionAsync();

            // Get Nics
            await networkInterfaceCollection.GetAsync(nic1name);
            await networkInterfaceCollection.GetAsync(nic2name);
            await networkInterfaceCollection.GetAsync(nic3name);

            // Get lb with expanded nics from nat rules
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "InboundNatRules/backendIPConfiguration");

            await foreach (var natRule in loadBalancer.GetInboundNatRules())
            {
                Assert.NotNull(natRule.Data.BackendIPConfiguration);
                Assert.NotNull(natRule.Data.BackendIPConfiguration.Id);
                //Assert.NotNull(natRule.Data.BackendIPConfiguration.Name);
                //Assert.NotNull(natRule.Data.BackendIPConfiguration.Etag);
                //Assert.AreEqual(natRule.Id, natRule.Data.BackendIPConfiguration.LoadBalancerInboundNatRules[0].Id);
            }

            // Get lb with expanded nics from pools
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "BackendAddressPools/backendIPConfigurations");

            await foreach (var pool in loadBalancer.GetBackendAddressPools())
            {
                BackendAddressPoolResource firstPool = await GetFirstPoolAsync(loadBalancer);
                foreach (var ipconfig in firstPool.Data.BackendIPConfigurations)
                {
                    Assert.NotNull(ipconfig.Id);
                    //Assert.NotNull(ipconfig.Name);
                    //Assert.NotNull(ipconfig.Etag);
                    //Assert.AreEqual(pool.Id, ipconfig.LoadBalancerBackendAddressPools[0].Id);
                }
            }

            // Get lb with expanded publicip
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "FrontendIPConfigurations/PublicIPAddress");
            foreach (var ipconfig in loadBalancer.Data.FrontendIPConfigurations)
            {
                Assert.NotNull(ipconfig.PublicIPAddress);
                Assert.NotNull(ipconfig.PublicIPAddress.Id);
                Assert.NotNull(ipconfig.PublicIPAddress.Name);
                Assert.NotNull(ipconfig.PublicIPAddress.Etag);
                Assert.AreEqual(ipconfig.Id, ipconfig.PublicIPAddress.IPConfiguration.Id);
            }

            // Get NIC with expanded subnet
            nic1 = await networkInterfaceCollection.GetAsync(nic1name, "IPConfigurations/Subnet");
            await foreach (NetworkInterfaceIPConfigurationResource ipconfig in nic1.GetNetworkInterfaceIPConfigurations())
            {
                Assert.NotNull(ipconfig.Data.Subnet);
                Assert.NotNull(ipconfig.Data.Subnet.Id);
                //Assert.NotNull(ipconfig.Subnet.Name);
                //Assert.NotNull(ipconfig.Subnet.Etag);
                //Assert.IsNotEmpty(ipconfig.Subnet.IpConfigurations);
            }

            // Get subnet with expanded ipconfigurations
            Response<SubnetResource> subnet = await (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetSubnets().GetAsync(
                subnetName,
                "IPConfigurations");

            foreach (IPConfiguration ipconfig in subnet.Value.Data.IPConfigurations)
            {
                Assert.NotNull(ipconfig.Id);
                //Assert.NotNull(ipconfig.Name);
                //Assert.NotNull(ipconfig.Etag);
                Assert.NotNull(ipconfig.PrivateIPAddress);
            }

            // Get publicIPAddress with expanded ipconfigurations
            Response<PublicIPAddressResource> publicip = await resourceGroup.GetPublicIPAddresses().GetAsync(
                lbPublicIpName,
                "IPConfiguration");

            Assert.NotNull(publicip.Value.Data.IPConfiguration);
            Assert.NotNull(publicip.Value.Data.IPConfiguration.Id);
            //Assert.NotNull(publicip.Value.Data.IpConfiguration.Name);
            //Assert.NotNull(publicip.Value.Data.IpConfiguration.Etag);

            // Delete LoadBalancer
            Operation deleteOperation = await (await loadBalancerCollection.GetAsync(lbName)).Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all NetworkInterfaces
            await (await networkInterfaceCollection.GetAsync(nic1name)).Value.DeleteAsync(WaitUntil.Completed);
            await (await networkInterfaceCollection.GetAsync(nic2name)).Value.DeleteAsync(WaitUntil.Completed);
            await (await networkInterfaceCollection.GetAsync(nic3name)).Value.DeleteAsync(WaitUntil.Completed);

            // Delete all PublicIPAddresses
            await (await resourceGroup.GetPublicIPAddresses().GetAsync(lbPublicIpName)).Value.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<BackendAddressPoolResource> GetFirstPoolAsync(LoadBalancerResource loadBalancer)
        {
            await foreach (var pool in loadBalancer.GetBackendAddressPools())
            {
                return pool;
            }
            throw new InvalidOperationException($"Pool list was empty for {loadBalancer.Id}");
        }
    }
}
