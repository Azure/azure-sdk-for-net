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
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24577")]
    public class LoadBalancerTests : NetworkServiceClientTestBase
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

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(
                lbPublicIpName,
                lbDomaingNameLabel,
                location,
                resourceGroup.GetPublicIPAddresses());

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
            var loadBalancer = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
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
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var putLoadBalancerOperation = await resourceGroup.GetLoadBalancers().CreateOrUpdateAsync(lbName, loadBalancer);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            Response<LoadBalancer> getLoadBalancer = await resourceGroup.GetLoadBalancers().GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(lbPublicIp.Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PublicIPAddress.Id);
            Assert.Null(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(15, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(15, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);
            Assert.NotNull(getLoadBalancer.Value.Data.ResourceGuid);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = resourceGroup.GetLoadBalancers().GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.Etag, listLoadBalancer.First().Data.Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = ArmClient.DefaultSubscription.GetLoadBalancersAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.AreEqual(lbName, listLoadBalancerSubscription[0].Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Etag);

            // Verify List BackendAddressPools in LoadBalancer
            var backendAddressPoolContainer = resourceGroup.GetLoadBalancers().Get(lbName).Value.GetBackendAddressPools();
            AsyncPageable<BackendAddressPool> listLoadBalancerBackendAddressPoolsAP = backendAddressPoolContainer.GetAllAsync();
            List<BackendAddressPool> listLoadBalancerBackendAddressPools = await listLoadBalancerBackendAddressPoolsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerBackendAddressPools);
            Assert.AreEqual(backEndAddressPoolName, listLoadBalancerBackendAddressPools.First().Data.Name);
            Assert.NotNull(listLoadBalancerBackendAddressPools.First().Data.Etag);

            // Verify Get BackendAddressPool in LoadBalancer
            Response<BackendAddressPool> getLoadBalancerBackendAddressPool = await backendAddressPoolContainer.GetAsync(backEndAddressPoolName);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancerBackendAddressPool.Value.Data.Name);
            Assert.NotNull(getLoadBalancerBackendAddressPool.Value.Data.Etag);

            // Verify List FrontendIPConfigurations in LoadBalancer
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            var loadBalancerOperations = loadBalancerContainer.Get(lbName).Value;
            AsyncPageable<FrontendIPConfiguration> listLoadBalancerFrontendIPConfigurationsAP = loadBalancerOperations.GetLoadBalancerFrontendIPConfigurationsAsync();
            List<FrontendIPConfiguration> listLoadBalancerFrontendIPConfigurations = await listLoadBalancerFrontendIPConfigurationsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerFrontendIPConfigurations);
            Assert.AreEqual(frontendIpConfigName, listLoadBalancerFrontendIPConfigurations.First().Name);
            Assert.NotNull(listLoadBalancerFrontendIPConfigurations.First().Etag);

            // Verify Get FrontendIPConfiguration in LoadBalancer
            // TODO: ADO 5975
            //Response<FrontendIPConfiguration> getLoadBalancerFrontendIPConfiguration = await loadBalancerOperations.GetLoadBalancerFrontendIPConfigurationAsync();
            //Assert.AreEqual(frontendIpConfigName, getLoadBalancerFrontendIPConfiguration.Value.Name);
            //Assert.NotNull(getLoadBalancerFrontendIPConfiguration.Value.Etag);

            // Verify List LoadBalancingRules in LoadBalancer
            AsyncPageable<LoadBalancingRule> listLoadBalancerLoadBalancingRulesAP = loadBalancerOperations.GetLoadBalancerLoadBalancingRulesAsync();
            List<LoadBalancingRule> listLoadBalancerLoadBalancingRules = await listLoadBalancerLoadBalancingRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerLoadBalancingRules);
            Assert.AreEqual(loadBalancingRuleName, listLoadBalancerLoadBalancingRules.First().Name);
            Assert.NotNull(listLoadBalancerLoadBalancingRules.First().Etag);

            // Verify Get LoadBalancingRule in LoadBalancer
            // TODO: ADO 5975
            //Response<LoadBalancingRule> getLoadBalancerLoadBalancingRule = await loadBalancerOperations.GetLoadBalancerLoadBalancingRuleAsync();
            // Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterfaceData> listLoadBalancerNetworkInterfacesAP = loadBalancerOperations.GetLoadBalancerNetworkInterfacesAsync();
            List<NetworkInterfaceData> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancerNetworkInterfaces);

            // Verify List Probes in LoadBalancer
            AsyncPageable<Probe> listLoadBalancerProbesAP = loadBalancerOperations.GetLoadBalancerProbesAsync();
            List<Probe> listLoadBalancerProbes = await listLoadBalancerProbesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerProbes);
            Assert.AreEqual(probeName, listLoadBalancerProbes.First().Name);
            Assert.NotNull(listLoadBalancerProbes.First().Etag);

            // Verify Get Probe in LoadBalancer
            // TODO: ADO 5975
            //Response<Probe> getLoadBalancerProbe = await loadBalancerOperations.GetLoadBalancerProbeAsync();
            //Assert.AreEqual(probeName, getLoadBalancerProbe.Value.Name);
            //Assert.NotNull(getLoadBalancerProbe.Value.Etag);

            // Prepare the third InboundNatRule
            var inboundNatRule3Params = new InboundNatRuleData()
            {
                FrontendIPConfiguration = new WritableSubResource()
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
            var inboundNatRuleContainer = loadBalancerOperations.GetInboundNatRules();
            var putInboundNatRuleOperation = await inboundNatRuleContainer.CreateOrUpdateAsync(inboundNatRule3Name, inboundNatRule3Params);
            Response<InboundNatRule> putInboundNatRule = await putInboundNatRuleOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual(inboundNatRule3Name, putInboundNatRule.Value.Data.Name);
            Assert.AreEqual(TransportProtocol.Tcp, putInboundNatRule.Value.Data.Protocol);
            Assert.AreEqual(3391, putInboundNatRule.Value.Data.FrontendPort);
            Assert.AreEqual(3389, putInboundNatRule.Value.Data.BackendPort);
            Assert.AreEqual(15, putInboundNatRule.Value.Data.IdleTimeoutInMinutes);
            Assert.False(putInboundNatRule.Value.Data.EnableFloatingIP);

            // Verify Get InboundNatRule in LoadBalancer
            Response<InboundNatRule> getInboundNatRule = await inboundNatRuleContainer.GetAsync(inboundNatRule3Name);
            Assert.AreEqual(inboundNatRule3Name, getInboundNatRule.Value.Data.Name);
            Assert.AreEqual(TransportProtocol.Tcp, getInboundNatRule.Value.Data.Protocol);
            Assert.AreEqual(3391, getInboundNatRule.Value.Data.FrontendPort);
            Assert.AreEqual(3389, getInboundNatRule.Value.Data.BackendPort);
            Assert.AreEqual(15, getInboundNatRule.Value.Data.IdleTimeoutInMinutes);
            Assert.False(getInboundNatRule.Value.Data.EnableFloatingIP);

            // Verify List InboundNatRules in LoadBalancer
            AsyncPageable<InboundNatRule> listInboundNatRulesAP = inboundNatRuleContainer.GetAllAsync();
            List<InboundNatRule> listInboundNatRules = await listInboundNatRulesAP.ToEnumerableAsync();
            Assert.AreEqual(3, listInboundNatRules.Count());
            Assert.AreEqual(inboundNatRule1Name, listInboundNatRules[0].Data.Name);
            Assert.AreEqual(inboundNatRule2Name, listInboundNatRules[1].Data.Name);
            Assert.AreEqual(inboundNatRule3Name, listInboundNatRules[2].Data.Name);

            // Delete InboundNatRule in LoadBalancer
            await getInboundNatRule.Value.DeleteAsync();

            // Delete LoadBalancer
            var deleteOperation1 = await loadBalancerOperations.DeleteAsync();
            await deleteOperation1.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTestWithDynamicIp()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadbalancerparamater = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = vnet.Data.Subnets[0]
                    }
                },
                BackendAddressPools = {
                    new BackendAddressPoolData()
                    {
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var loadBalancerContainer = GetLoadBalancerContainer(resourceGroup);
            var putLoadBalancerOperation = await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancer> getLoadBalancer = await resourceGroup.GetLoadBalancers().GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.Etag, listLoadBalancer.First().Data.Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = ArmClient.DefaultSubscription.GetLoadBalancersAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Etag);

            // Delete LoadBalancer
            await getLoadBalancer.Value.DeleteAsync();

            // Verify Delete
            listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTestWithStaticIp()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadbalancerparamater = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Data.Subnets[0]
                    }
                },
                BackendAddressPools = {
                    new BackendAddressPoolData()
                    {
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
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
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false,
                    },
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var loadBalancerContainer = GetLoadBalancerContainer(resourceGroup);
            var putLoadBalancerOperation = await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.Etag, listLoadBalancer.First().Data.Etag);

            // Verify List LoadBalancer subscription
            AsyncPageable<LoadBalancer> listLoadBalancerSubscriptionAP = ArmClient.DefaultSubscription.GetLoadBalancersAsync();
            List<LoadBalancer> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Etag);

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTestWithDistributionPolicy()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadbalancerparamater = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Data.Subnets[0]
                    }
                },
                BackendAddressPools = {
                    new BackendAddressPoolData()
                    {
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
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
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    },
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadbalancerparamater);

            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id);
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe.Id);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.Etag, listLoadBalancer.First().Data.Etag);

            // Do another put after changing the distribution policy
            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIP;
            await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadbalancerparamater);
            getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            Assert.AreEqual(LoadDistribution.SourceIP, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);

            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIPProtocol;
            await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadbalancerparamater);
            getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            Assert.AreEqual(LoadDistribution.SourceIPProtocol, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync()).WaitForCompletionResponseAsync();

            // Verify Delete
            listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task CreateEmptyLoadBalancer()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the empty LoadBalancer
            string lbname = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadbalancerparamater = new LoadBalancerData() { Location = location, };

            // Create the loadBalancer
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            var putLoadBalancerOperation = await loadBalancerContainer.CreateOrUpdateAsync(lbname, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.False(getLoadBalancer.Value.Data.FrontendIPConfigurations.Any());
            Assert.False(getLoadBalancer.Value.Data.BackendAddressPools.Any());
            Assert.False(getLoadBalancer.Value.Data.LoadBalancingRules.Any());
            Assert.False(getLoadBalancer.Value.Data.Probes.Any());
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync()).WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateLoadBalancerRule()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create the LoadBalancer with an lb rule and no probe
            string lbname = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadbalancerparamater = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Static,
                        PrivateIPAddress = "10.0.0.38",
                        Subnet = vnet.Data.Subnets[0]
                    }
                },
                BackendAddressPools = {
                    new BackendAddressPoolData()
                    {
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbname, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp,
                        FrontendPort = 80,
                        BackendPort = 80,
                        EnableFloatingIP = false,
                        BackendAddressPool = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbname, "backendAddressPools", backEndAddressPoolName)
                        }
                    }
                },
            };

            // Create the loadBalancer
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            await loadBalancerContainer.CreateOrUpdateAsync(lbname, loadbalancerparamater);
            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.Data.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.LoadBalancingRules.Count);
            Assert.False(getLoadBalancer.Value.Data.Probes.Any());
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Add a Probe to the lb rule
            getLoadBalancer.Value.Data.Probes.Add(
                new Probe()
                {
                    Name = probeName,
                    Protocol = ProbeProtocol.Http,
                    Port = 80,
                    RequestPath = "healthcheck.aspx",
                    IntervalInSeconds = 10,
                    NumberOfProbes = 2
                }
            );

            getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe = new WritableSubResource()
            {
                Id = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbname, "probes", probeName)
            };

            // update load balancer
            var putLoadBalancerOperation = await loadBalancerContainer.CreateOrUpdateAsync(lbname, getLoadBalancer.Value.Data);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            getLoadBalancer = await loadBalancerContainer.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.Data.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.LoadBalancingRules.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.Probes.Count);
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Probe.Id);
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync()).WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiNicAssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, lbDomaingNameLabel, location, resourceGroup.GetPublicIPAddresses());

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");
            string nic3name = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nic1 = await CreateNetworkInterface(nic1name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());
            NetworkInterface nic2 = await CreateNetworkInterface(nic2name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());
            NetworkInterface nic3 = await CreateNetworkInterface(nic3name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string backEndAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string loadBalancingRuleName = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatRule2Name = Recording.GenerateAssetName("azsmnet");

            // Populate the loadBalancerCreateOrUpdateParameter
            var loadBalancer = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
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
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRule()
                    {
                        Name = loadBalancingRuleName,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
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
                InboundNatRules = {
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule1Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfiguration = new WritableSubResource()
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
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            var putLoadBalancerOperation = await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadBalancer);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            // Associate the nic with LB
            nic1.Data.IpConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.Data.BackendAddressPools.First());
            nic1.Data.IpConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.Data.InboundNatRules.First());
            nic2.Data.IpConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.Data.BackendAddressPools.First());
            nic2.Data.IpConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.Data.InboundNatRules[1]);

            // Put Nics
            var networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();
            var nic1Operation = await networkInterfaceContainer.CreateOrUpdateAsync(nic1name, nic1.Data);
            await nic1Operation.WaitForCompletionAsync();

            var nic2Operation = await networkInterfaceContainer.CreateOrUpdateAsync(nic2name, nic2.Data);
            await nic2Operation.WaitForCompletionAsync();

            var nic3Operation = await networkInterfaceContainer.CreateOrUpdateAsync(nic3name, nic3.Data);
            await nic3Operation.WaitForCompletionAsync();

            // Get Nics
            nic1 = await networkInterfaceContainer.GetAsync(nic1name);
            nic2 = await networkInterfaceContainer.GetAsync(nic2name);
            nic3 = await networkInterfaceContainer.GetAsync(nic3name);

            // Verify the associations
            getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);
            Assert.AreEqual(2, getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations.Count);
            Assert.AreEqual(getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations[0].Id, nic1.Data.IpConfigurations[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations[1].Id, nic2.Data.IpConfigurations[0].Id);
            Assert.AreEqual(nic1.Data.IpConfigurations[0].Id, getLoadBalancer.Value.Data.InboundNatRules.First().BackendIPConfiguration.Id);

            // Verify List NetworkInterfaces in LoadBalancer// Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterfaceData> listLoadBalancerNetworkInterfacesAP = getLoadBalancer.Value.GetLoadBalancerNetworkInterfacesAsync();
            List<NetworkInterfaceData> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.AreEqual(2, listLoadBalancerNetworkInterfaces.Count());

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all NetworkInterfaces
            await nic1.DeleteAsync();
            await nic2.DeleteAsync();
            await nic2.DeleteAsync();

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync();
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerNatPoolTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, lbDomaingNameLabel, location, resourceGroup.GetPublicIPAddresses());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool2Name = Recording.GenerateAssetName("azsmnet");

            var loadBalancer = new LoadBalancerData()
            {
                Location = location,
                FrontendIPConfigurations = {
                    new FrontendIPConfiguration()
                    {
                        Name = frontendIpConfigName,
                        PublicIPAddress = new PublicIPAddressData()
                        {
                            Id = lbPublicIp.Id
                        }
                    }
                },
                InboundNatPools = {
                    new InboundNatPool()
                    {
                        Name = inboundNatPool1Name,
                        BackendPort = 81,
                        FrontendPortRangeStart = 100,
                        FrontendPortRangeEnd = 105,
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = TransportProtocol.Tcp
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerContainer = resourceGroup.GetLoadBalancers();
            await loadBalancerContainer.CreateOrUpdateAsync(lbName, loadBalancer);
            Response<LoadBalancer> getLoadBalancer = await loadBalancerContainer.GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());

            // Verify the nat pool
            Assert.AreEqual(1, getLoadBalancer.Value.Data.InboundNatPools.Count);
            Assert.AreEqual(inboundNatPool1Name, getLoadBalancer.Value.Data.InboundNatPools[0].Name);
            Assert.AreEqual(81, getLoadBalancer.Value.Data.InboundNatPools[0].BackendPort);
            Assert.AreEqual(100, getLoadBalancer.Value.Data.InboundNatPools[0].FrontendPortRangeStart);
            Assert.AreEqual(105, getLoadBalancer.Value.Data.InboundNatPools[0].FrontendPortRangeEnd);
            Assert.AreEqual(TransportProtocol.Tcp, getLoadBalancer.Value.Data.InboundNatPools[0].Protocol);
            Assert.AreEqual(GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.Value.Data.InboundNatPools[0].FrontendIPConfiguration.Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatPools[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatPools[0].Id);

            // Add a new nat pool
            InboundNatPool natpool2 = new InboundNatPool()
            {
                Name = inboundNatPool2Name,
                BackendPort = 81,
                FrontendPortRangeStart = 107,
                FrontendPortRangeEnd = 110,
                FrontendIPConfiguration = new WritableSubResource() { Id = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName) },
                Protocol = TransportProtocol.Tcp
            };
            getLoadBalancer.Value.Data.InboundNatPools.Add(natpool2);
            await loadBalancerContainer.CreateOrUpdateAsync(lbName, getLoadBalancer.Value.Data);

            // Verify the nat pool
            Assert.AreEqual(2, getLoadBalancer.Value.Data.InboundNatPools.Count);

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancer> listLoadBalancerAP = loadBalancerContainer.GetAllAsync();
            List<LoadBalancer> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync();
        }
    }
}
