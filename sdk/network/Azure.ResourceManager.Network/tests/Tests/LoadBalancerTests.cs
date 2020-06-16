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
    public class LoadBalancerTests : NetworkTestsManagementClientBase
    {
        public LoadBalancerTests(bool isAsync) : base(isAsync)
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
        public async Task LoadBalancerApiTestAsync()
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

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule3Name = Recording.GenerateAssetName("azsmnet");

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
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadBalancer);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(lbPublicIp.Id, getLoadBalancer.Value.FrontendIPConfigurations[0].PublicIPAddress.Id);
            Assert.Null(getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[1].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.LoadBalancingRules[0].Id, getLoadBalancer.Value.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(15, getLoadBalancer.Value.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual(probeName, getLoadBalancer.Value.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Probes[0].Id, getLoadBalancer.Value.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(15, getLoadBalancer.Value.InboundNatRules[1].IdleTimeoutInMinutes);
            Assert.NotNull(getLoadBalancer.Value.ResourceGuid);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Name);
            Assert.AreEqual(getLoadBalancer.Value.Etag, listLoadBalancer.First().Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = NetworkManagementClient.LoadBalancers.ListAllAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.AreEqual(lbName, listLoadBalancerSubscription[0].Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Etag);

            // Verify List BackendAddressPools in LoadBalancer
            AsyncPageable<BackendAddressPool> listLoadBalancerBackendAddressPoolsAP = NetworkManagementClient.LoadBalancerBackendAddressPools.ListAsync(resourceGroupName, lbName);
            List<BackendAddressPool> listLoadBalancerBackendAddressPools = await listLoadBalancerBackendAddressPoolsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerBackendAddressPools);
            Assert.AreEqual(backEndAddressPoolName, listLoadBalancerBackendAddressPools.First().Name);
            Assert.NotNull(listLoadBalancerBackendAddressPools.First().Etag);

            // Verify Get BackendAddressPool in LoadBalancer
            Response<BackendAddressPool> getLoadBalancerBackendAddressPool = await NetworkManagementClient.LoadBalancerBackendAddressPools.GetAsync(resourceGroupName, lbName, backEndAddressPoolName);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancerBackendAddressPool.Value.Name);
            Assert.NotNull(getLoadBalancerBackendAddressPool.Value.Etag);

            // Verify List FrontendIPConfigurations in LoadBalancer
            AsyncPageable<FrontendIPConfiguration> listLoadBalancerFrontendIPConfigurationsAP = NetworkManagementClient.LoadBalancerFrontendIPConfigurations.ListAsync(resourceGroupName, lbName);
            List<FrontendIPConfiguration> listLoadBalancerFrontendIPConfigurations = await listLoadBalancerFrontendIPConfigurationsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerFrontendIPConfigurations);
            Assert.AreEqual(frontendIpConfigName, listLoadBalancerFrontendIPConfigurations.First().Name);
            Assert.NotNull(listLoadBalancerFrontendIPConfigurations.First().Etag);

            // Verify Get FrontendIPConfiguration in LoadBalancer
            Response<FrontendIPConfiguration> getLoadBalancerFrontendIPConfiguration = await NetworkManagementClient.LoadBalancerFrontendIPConfigurations.GetAsync(resourceGroupName, lbName, frontendIpConfigName);
            Assert.AreEqual(frontendIpConfigName, getLoadBalancerFrontendIPConfiguration.Value.Name);
            Assert.NotNull(getLoadBalancerFrontendIPConfiguration.Value.Etag);

            // Verify List LoadBalancingRules in LoadBalancer
            AsyncPageable<LoadBalancingRule> listLoadBalancerLoadBalancingRulesAP = NetworkManagementClient.LoadBalancerLoadBalancingRules.ListAsync(resourceGroupName, lbName);
            List<LoadBalancingRule> listLoadBalancerLoadBalancingRules = await listLoadBalancerLoadBalancingRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerLoadBalancingRules);
            Assert.AreEqual(loadBalancingRuleName, listLoadBalancerLoadBalancingRules.First().Name);
            Assert.NotNull(listLoadBalancerLoadBalancingRules.First().Etag);

            // Verify Get LoadBalancingRule in LoadBalancer
            Response<LoadBalancingRule> getLoadBalancerLoadBalancingRule = await NetworkManagementClient.LoadBalancerLoadBalancingRules.GetAsync(resourceGroupName, lbName, loadBalancingRuleName);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancerLoadBalancingRule.Value.Name);
            Assert.NotNull(getLoadBalancerLoadBalancingRule.Value.Etag);

            // Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterface> listLoadBalancerNetworkInterfacesAP = NetworkManagementClient.LoadBalancerNetworkInterfaces.ListAsync(resourceGroupName, lbName);
            List<NetworkInterface> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancerNetworkInterfaces);

            // Verify List Probes in LoadBalancer
            AsyncPageable<Probe> listLoadBalancerProbesAP = NetworkManagementClient.LoadBalancerProbes.ListAsync(resourceGroupName, lbName);
            List<Probe> listLoadBalancerProbes = await listLoadBalancerProbesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerProbes);
            Assert.AreEqual(probeName, listLoadBalancerProbes.First().Name);
            Assert.NotNull(listLoadBalancerProbes.First().Etag);

            // Verify Get Probe in LoadBalancer
            Response<Probe> getLoadBalancerProbe = await NetworkManagementClient.LoadBalancerProbes.GetAsync(resourceGroupName, lbName, probeName);
            Assert.AreEqual(probeName, getLoadBalancerProbe.Value.Name);
            Assert.NotNull(getLoadBalancerProbe.Value.Etag);

            // Prepare the third InboundNatRule
            InboundNatRule inboundNatRule3Params = new InboundNatRule()
            {
                FrontendIPConfiguration = new SubResource()
                {
                    Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                },
                Protocol = TransportProtocol.Tcp,
                FrontendPort = 3391,
                BackendPort = 3389,
                IdleTimeoutInMinutes = 15,
                EnableFloatingIP = false,
            };

            // Verify Put InboundNatRule in LoadBalancer
            InboundNatRulesCreateOrUpdateOperation putInboundNatRuleOperation = await NetworkManagementClient.InboundNatRules.StartCreateOrUpdateAsync(resourceGroupName, lbName, inboundNatRule3Name, inboundNatRule3Params);
            Response<InboundNatRule> putInboundNatRule = await WaitForCompletionAsync(putInboundNatRuleOperation);
            Assert.AreEqual(inboundNatRule3Name, putInboundNatRule.Value.Name);
            Assert.AreEqual(TransportProtocol.Tcp, putInboundNatRule.Value.Protocol);
            Assert.AreEqual(3391, putInboundNatRule.Value.FrontendPort);
            Assert.AreEqual(3389, putInboundNatRule.Value.BackendPort);
            Assert.AreEqual(15, putInboundNatRule.Value.IdleTimeoutInMinutes);
            Assert.False(putInboundNatRule.Value.EnableFloatingIP);

            // Verify Get InboundNatRule in LoadBalancer
            Response<InboundNatRule> getInboundNatRule = await NetworkManagementClient.InboundNatRules.GetAsync(resourceGroupName, lbName, inboundNatRule3Name);
            Assert.AreEqual(inboundNatRule3Name, getInboundNatRule.Value.Name);
            Assert.AreEqual(TransportProtocol.Tcp, getInboundNatRule.Value.Protocol);
            Assert.AreEqual(3391, getInboundNatRule.Value.FrontendPort);
            Assert.AreEqual(3389, getInboundNatRule.Value.BackendPort);
            Assert.AreEqual(15, getInboundNatRule.Value.IdleTimeoutInMinutes);
            Assert.False(getInboundNatRule.Value.EnableFloatingIP);

            // Verify List InboundNatRules in LoadBalancer
            AsyncPageable<InboundNatRule> listInboundNatRulesAP = NetworkManagementClient.InboundNatRules.ListAsync(resourceGroupName, lbName);
            List<InboundNatRule> listInboundNatRules = await listInboundNatRulesAP.ToEnumerableAsync();
            Assert.AreEqual(3, listInboundNatRules.Count());
            Assert.AreEqual(inboundNatRule1Name, listInboundNatRules[0].Name);
            Assert.AreEqual(inboundNatRule2Name, listInboundNatRules[1].Name);
            Assert.AreEqual(inboundNatRule3Name, listInboundNatRules[2].Name);

            // Delete InboundNatRule in LoadBalancer
            await NetworkManagementClient.InboundNatRules.StartDeleteAsync(resourceGroupName, lbName, inboundNatRule3Name);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation1 = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation1);

            // Verify Delete
            listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, lbPublicIpName);
        }

        [Test]
        public async Task LoadBalancerApiTestWithDynamicIp()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadbalancerparamater = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = vnet.Subnets[0]
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false,
                    },
                    new InboundNatRule()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadbalancerparamater);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Subnets[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[1].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.LoadBalancingRules[0].Id, getLoadBalancer.Value.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Probes[0].Id, getLoadBalancer.Value.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.InboundNatRules[1].FrontendPort);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Name);
            Assert.AreEqual(getLoadBalancer.Value.Etag, listLoadBalancer.First().Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = NetworkManagementClient.LoadBalancers.ListAllAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Etag);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task LoadBalancerApiTestWithStaticIp()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadbalancerparamater = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Subnets[0]
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false,
                    },
                    new InboundNatRule()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadbalancerparamater);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Subnets[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[1].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.LoadBalancingRules[0].Id, getLoadBalancer.Value.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Probes[0].Id, getLoadBalancer.Value.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Name);
            Assert.AreEqual(getLoadBalancer.Value.Etag, listLoadBalancer.First().Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = NetworkManagementClient.LoadBalancers.ListAllAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Etag);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task LoadBalancerApiTestWithDistributionPolicy()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadbalancerparamater = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Subnets[0]
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    },
                    new InboundNatRule()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    }
                }
            };

            // Create the loadBalancer
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadbalancerparamater);

            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Subnets[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatRules[1].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.LoadBalancingRules[0].Id, getLoadBalancer.Value.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Probes[0].Id, getLoadBalancer.Value.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.AreEqual(lbName, listLoadBalancer.First().Name);
            Assert.AreEqual(getLoadBalancer.Value.Etag, listLoadBalancer.First().Etag);

            // Do another put after changing the distribution policy
            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIP;
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadbalancerparamater);
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            Assert.AreEqual(LoadDistribution.SourceIP, getLoadBalancer.Value.LoadBalancingRules[0].LoadDistribution);

            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIPProtocol;
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadbalancerparamater);
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            Assert.AreEqual(LoadDistribution.SourceIPProtocol, getLoadBalancer.Value.LoadBalancingRules[0].LoadDistribution);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task CreateEmptyLoadBalancer()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create the empty LoadBalancer
            string lbname = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadbalancerparamater = new LoadBalancer() { Location = location, };

            // Create the loadBalancer
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbname, loadbalancerparamater);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.False(getLoadBalancer.Value.FrontendIPConfigurations.Any());
            Assert.False(getLoadBalancer.Value.BackendAddressPools.Any());
            Assert.False(getLoadBalancer.Value.LoadBalancingRules.Any());
            Assert.False(getLoadBalancer.Value.Probes.Any());
            Assert.False(getLoadBalancer.Value.InboundNatRules.Any());

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbname);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);
        }

        [Test]
        public async Task UpdateLoadBalancerRule()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create the LoadBalancer with an lb rule and no probe
            string lbname = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            LoadBalancer loadbalancerparamater = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Subnets[0]
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbname, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
                        BackendAddressPool = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbname, "backendAddressPools", backEndAddressPoolName)
                        }
                    }
                },
            };

            // Create the loadBalancer
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbname, loadbalancerparamater);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.LoadBalancingRules.Count);
            Assert.False(getLoadBalancer.Value.Probes.Any());
            Assert.False(getLoadBalancer.Value.InboundNatRules.Any());

            // Add a Probe to the lb rule
            getLoadBalancer.Value.Probes = new List<Probe>()
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
            };

            getLoadBalancer.Value.LoadBalancingRules[0].Probe = new SubResource()
            {
                Id = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbname, "probes", probeName)
            };

            // update load balancer
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbname, getLoadBalancer);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.LoadBalancingRules.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Probes.Count);
            Assert.AreEqual(getLoadBalancer.Value.Probes[0].Id, getLoadBalancer.Value.LoadBalancingRules[0].Probe.Id);
            Assert.False(getLoadBalancer.Value.InboundNatRules.Any());

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbname);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task LoadBalancerApiNicAssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, resourceGroupName, lbDomaingNameLabel, location, NetworkManagementClient);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");
            string nic3name = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nic1 = await CreateNetworkInterface(nic1name, resourceGroupName, null, vnet.Subnets[0].Id, location, "ipconfig", NetworkManagementClient);
            NetworkInterface nic2 = await CreateNetworkInterface(nic2name, resourceGroupName, null, vnet.Subnets[0].Id, location, "ipconfig", NetworkManagementClient);
            NetworkInterface nic3 = await CreateNetworkInterface(nic3name, resourceGroupName, null, vnet.Subnets[0].Id, location, "ipconfig", NetworkManagementClient);

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

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
                        Name = backEndAddressPoolName
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
            LoadBalancersCreateOrUpdateOperation putLoadBalancerOperation = await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadBalancer);
            await WaitForCompletionAsync(putLoadBalancerOperation);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Associate the nic with LB
            nic1.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool> { getLoadBalancer.Value.BackendAddressPools.First() };
            nic1.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule> { getLoadBalancer.Value.InboundNatRules.First() };
            nic2.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool> { getLoadBalancer.Value.BackendAddressPools.First() };
            nic3.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule> { getLoadBalancer.Value.InboundNatRules[1] };

            // Put Nics
            NetworkInterfacesCreateOrUpdateOperation nic1Operation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic1name, nic1);
            await WaitForCompletionAsync(nic1Operation);

            NetworkInterfacesCreateOrUpdateOperation nic2Operation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic2name, nic2);
            await WaitForCompletionAsync(nic2Operation);

            NetworkInterfacesCreateOrUpdateOperation nic3Operation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic3name, nic3);
            await WaitForCompletionAsync(nic3Operation);

            // Get Nics
            nic1 = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic1name);
            nic2 = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic2name);
            nic3 = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nic3name);

            // Verify the associations
            getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);
            Assert.AreEqual(2, getLoadBalancer.Value.BackendAddressPools.First().BackendIPConfigurations.Count);
            Assert.AreEqual(getLoadBalancer.Value.BackendAddressPools.First().BackendIPConfigurations[0].Id.ToLower(), nic1.IpConfigurations[0].Id.ToLower());
            Assert.AreEqual(getLoadBalancer.Value.BackendAddressPools.First().BackendIPConfigurations[1].Id.ToLower(), nic2.IpConfigurations[0].Id.ToLower());
            Assert.AreEqual(nic1.IpConfigurations[0].Id, getLoadBalancer.Value.InboundNatRules.First().BackendIPConfiguration.Id);
            Assert.AreEqual(nic3.IpConfigurations[0].Id, getLoadBalancer.Value.InboundNatRules[1].BackendIPConfiguration.Id);

            // Verify List NetworkInterfaces in LoadBalancer// Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterface> listLoadBalancerNetworkInterfacesAP = NetworkManagementClient.LoadBalancerNetworkInterfaces.ListAsync(resourceGroupName, lbName);
            List<NetworkInterface> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.AreEqual(3, listLoadBalancerNetworkInterfaces.Count());

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

        [Test]
        public async Task LoadBalancerNatPoolTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/loadBalancers");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, resourceGroupName, lbDomaingNameLabel, location, NetworkManagementClient);

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool2Name = Recording.GenerateAssetName("azsmnet");

            LoadBalancer loadBalancer = new LoadBalancer()
            {
                Location = location,
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PublicIPAddress = new PublicIPAddress ()
                        {
                            Id = lbPublicIp.Id
                        }
                    }
                },
                InboundNatPools = new List<InboundNatPool>()
                {
                    new InboundNatPool()
                    {
                        Name = inboundNatPool1Name,
                        BackendPort = 81,
                        FrontendPortRangeStart = 100,
                        FrontendPortRangeEnd = 105,
                        FrontendIPConfiguration = new SubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp
                    }
                }
            };

            // Create the loadBalancer
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, loadBalancer);
            Response<LoadBalancer> getLoadBalancer = await NetworkManagementClient.LoadBalancers.GetAsync(resourceGroupName, lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.FrontendIPConfigurations[0].ProvisioningState.ToString());

            // Verify the nat pool
            Assert.AreEqual(1, getLoadBalancer.Value.InboundNatPools.Count);
            Assert.AreEqual(inboundNatPool1Name, getLoadBalancer.Value.InboundNatPools[0].Name);
            Assert.AreEqual(81, getLoadBalancer.Value.InboundNatPools[0].BackendPort);
            Assert.AreEqual(100, getLoadBalancer.Value.InboundNatPools[0].FrontendPortRangeStart);
            Assert.AreEqual(105, getLoadBalancer.Value.InboundNatPools[0].FrontendPortRangeEnd);
            Assert.AreEqual(TransportProtocol.Tcp, getLoadBalancer.Value.InboundNatPools[0].Protocol);
            Assert.AreEqual(GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.Value.InboundNatPools[0].FrontendIPConfiguration.Id);
            Assert.AreEqual(getLoadBalancer.Value.InboundNatPools[0].Id, getLoadBalancer.Value.FrontendIPConfigurations[0].InboundNatPools[0].Id);

            // Add a new nat pool
            InboundNatPool natpool2 = new InboundNatPool()
            {
                Name = inboundNatPool2Name,
                BackendPort = 81,
                FrontendPortRangeStart = 107,
                FrontendPortRangeEnd = 110,
                FrontendIPConfiguration = new SubResource() { Id = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName) },
                Protocol = TransportProtocol.Tcp
            };
            getLoadBalancer.Value.InboundNatPools.Add(natpool2);
            await NetworkManagementClient.LoadBalancers.StartCreateOrUpdateAsync(resourceGroupName, lbName, getLoadBalancer);

            // Verify the nat pool
            Assert.AreEqual(2, getLoadBalancer.Value.InboundNatPools.Count);

            // Delete LoadBalancer
            LoadBalancersDeleteOperation deleteOperation = await NetworkManagementClient.LoadBalancers.StartDeleteAsync(resourceGroupName, lbName);
            await WaitForCompletionAsync(deleteOperation);

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = NetworkManagementClient.LoadBalancers.ListAsync(resourceGroupName);
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, lbPublicIpName);
        }
    }
}
