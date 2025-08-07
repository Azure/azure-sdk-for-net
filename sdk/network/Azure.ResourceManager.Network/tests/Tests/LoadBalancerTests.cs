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

namespace Azure.ResourceManager.Network.Tests
{
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class LoadBalancerTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;
        public LoadBalancerTests(bool isAsync, string apiVersion)
        : base(isAsync, LoadBalancerResource.ResourceType, apiVersion)
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
        [Ignore("11/26/2021 Ignored since this test now cannot pass record, need fix")]
        public async Task LoadBalancerApiTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
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
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = LoadBalancingTransportProtocol.Tcp,
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
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            var putLoadBalancerOperation = await resourceGroup.GetLoadBalancers().CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadBalancer);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            Response<LoadBalancerResource> getLoadBalancer = await resourceGroup.GetLoadBalancers().GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(lbPublicIp.Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PublicIPAddress.Id);
            Assert.Null(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id.ToString());
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id.ToString());
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(15, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId.ToString());
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(15, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);
            Assert.NotNull(getLoadBalancer.Value.Data.ResourceGuid);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = resourceGroup.GetLoadBalancers().GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.ETag, listLoadBalancer.First().Data.ETag);

            // Verify List LoadBalancerResource subscription
            AsyncPageable<LoadBalancerResource> listLoadBalancerSubscriptionAP = subscription.GetLoadBalancersAsync();
            List<LoadBalancerResource> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.AreEqual(lbName, listLoadBalancerSubscription[0].Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.ETag);

            // Verify List BackendAddressPools in LoadBalancer
            var backendAddressPoolCollection = resourceGroup.GetLoadBalancers().Get(lbName).Value.GetBackendAddressPools();
            AsyncPageable<BackendAddressPoolResource> listLoadBalancerBackendAddressPoolsAP = backendAddressPoolCollection.GetAllAsync();
            List<BackendAddressPoolResource> listLoadBalancerBackendAddressPools = await listLoadBalancerBackendAddressPoolsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerBackendAddressPools);
            Assert.AreEqual(backEndAddressPoolName, listLoadBalancerBackendAddressPools.First().Data.Name);
            Assert.NotNull(listLoadBalancerBackendAddressPools.First().Data.ETag);

            // Verify Get BackendAddressPoolResource in LoadBalancer
            Response<BackendAddressPoolResource> getLoadBalancerBackendAddressPool = await backendAddressPoolCollection.GetAsync(backEndAddressPoolName);
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancerBackendAddressPool.Value.Data.Name);
            Assert.NotNull(getLoadBalancerBackendAddressPool.Value.Data.ETag);

            // Verify List FrontendIPConfigurations in LoadBalancer
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            var loadBalancerOperations = loadBalancerCollection.Get(lbName).Value;
            AsyncPageable<FrontendIPConfigurationResource> listLoadBalancerFrontendIPConfigurationsAP = loadBalancerOperations.GetFrontendIPConfigurations().GetAllAsync();
            List<FrontendIPConfigurationResource> listLoadBalancerFrontendIPConfigurations = await listLoadBalancerFrontendIPConfigurationsAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerFrontendIPConfigurations);
            Assert.AreEqual(frontendIpConfigName, listLoadBalancerFrontendIPConfigurations.First().Data.Name);
            Assert.NotNull(listLoadBalancerFrontendIPConfigurations.First().Data.ETag);

            // Verify Get FrontendIPConfigurationResource in LoadBalancer
            // TODO: ADO 5975
            //Response<FrontendIPConfigurationResource> getLoadBalancerFrontendIPConfiguration = await loadBalancerOperations.GetLoadBalancerFrontendIPConfigurationAsync();
            //Assert.AreEqual(frontendIpConfigName, getLoadBalancerFrontendIPConfiguration.Value.Name);
            //Assert.NotNull(getLoadBalancerFrontendIPConfiguration.Value.ETag);

            // Verify List LoadBalancingRules in LoadBalancer
            AsyncPageable<LoadBalancingRuleResource> listLoadBalancerLoadBalancingRulesAP = loadBalancerOperations.GetLoadBalancingRules().GetAllAsync();
            List<LoadBalancingRuleResource> listLoadBalancerLoadBalancingRules = await listLoadBalancerLoadBalancingRulesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerLoadBalancingRules);
            Assert.AreEqual(loadBalancingRuleName, listLoadBalancerLoadBalancingRules.First().Data.Name);
            Assert.NotNull(listLoadBalancerLoadBalancingRules.First().Data.ETag);

            // Verify Get LoadBalancingRuleResource in LoadBalancer
            // TODO: ADO 5975
            //Response<LoadBalancingRuleResource> getLoadBalancerLoadBalancingRule = await loadBalancerOperations.GetLoadBalancerLoadBalancingRuleAsync();
            // Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterfaceResource> listLoadBalancerNetworkInterfacesAP = loadBalancerOperations.GetLoadBalancerNetworkInterfacesAsync();
            List<NetworkInterfaceResource> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancerNetworkInterfaces);

            // Verify List Probes in LoadBalancer
            AsyncPageable<ProbeResource> listLoadBalancerProbesAP = loadBalancerOperations.GetProbes().GetAllAsync();
            List<ProbeResource> listLoadBalancerProbes = await listLoadBalancerProbesAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancerProbes);
            Assert.AreEqual(probeName, listLoadBalancerProbes.First().Data.Name);
            Assert.NotNull(listLoadBalancerProbes.First().Data.ETag);

            // Verify Get ProbeResource in LoadBalancer
            // TODO: ADO 5975
            //Response<ProbeResource> getLoadBalancerProbe = await loadBalancerOperations.GetLoadBalancerProbeAsync();
            //Assert.AreEqual(probeName, getLoadBalancerProbe.Value.Name);
            //Assert.NotNull(getLoadBalancerProbe.Value.ETag);

            // Prepare the third InboundNatRule
            var inboundNatRule3Params = new InboundNatRuleData()
            {
                FrontendIPConfiguration = new WritableSubResource()
                {
                    Id = GetChildLbResourceId(TestEnvironment.SubscriptionId,
                                resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                },
                Protocol = LoadBalancingTransportProtocol.Tcp,
                FrontendPort = 3391,
                BackendPort = 3389,
                IdleTimeoutInMinutes = 15,
                EnableFloatingIP = false,
            };

            // Verify Put InboundNatRuleResource in LoadBalancer
            var inboundNatRuleCollection = loadBalancerOperations.GetInboundNatRules();
            var putInboundNatRuleOperation = await inboundNatRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, inboundNatRule3Name, inboundNatRule3Params);
            Response<InboundNatRuleResource> putInboundNatRule = await putInboundNatRuleOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual(inboundNatRule3Name, putInboundNatRule.Value.Data.Name);
            Assert.AreEqual(LoadBalancingTransportProtocol.Tcp, putInboundNatRule.Value.Data.Protocol);
            Assert.AreEqual(3391, putInboundNatRule.Value.Data.FrontendPort);
            Assert.AreEqual(3389, putInboundNatRule.Value.Data.BackendPort);
            Assert.AreEqual(15, putInboundNatRule.Value.Data.IdleTimeoutInMinutes);
            Assert.False(putInboundNatRule.Value.Data.EnableFloatingIP);

            // Verify Get InboundNatRuleResource in LoadBalancer
            Response<InboundNatRuleResource> getInboundNatRule = await inboundNatRuleCollection.GetAsync(inboundNatRule3Name);
            Assert.AreEqual(inboundNatRule3Name, getInboundNatRule.Value.Data.Name);
            Assert.AreEqual(LoadBalancingTransportProtocol.Tcp, getInboundNatRule.Value.Data.Protocol);
            Assert.AreEqual(3391, getInboundNatRule.Value.Data.FrontendPort);
            Assert.AreEqual(3389, getInboundNatRule.Value.Data.BackendPort);
            Assert.AreEqual(15, getInboundNatRule.Value.Data.IdleTimeoutInMinutes);
            Assert.False(getInboundNatRule.Value.Data.EnableFloatingIP);

            // Verify List InboundNatRules in LoadBalancer
            AsyncPageable<InboundNatRuleResource> listInboundNatRulesAP = inboundNatRuleCollection.GetAllAsync();
            List<InboundNatRuleResource> listInboundNatRules = await listInboundNatRulesAP.ToEnumerableAsync();
            Assert.AreEqual(3, listInboundNatRules.Count());
            Assert.AreEqual(inboundNatRule1Name, listInboundNatRules[0].Data.Name);
            Assert.AreEqual(inboundNatRule2Name, listInboundNatRules[1].Data.Name);
            Assert.AreEqual(inboundNatRule3Name, listInboundNatRules[2].Data.Name);

            // Delete InboundNatRuleResource in LoadBalancer
            await getInboundNatRule.Value.DeleteAsync(WaitUntil.Completed);

            // Delete LoadBalancer
            var deleteOperation1 = await loadBalancerOperations.DeleteAsync(WaitUntil.Completed);
            await deleteOperation1.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTestWithDynamicIp()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

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
                    new FrontendIPConfigurationData()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
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
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(LoadBalancingTransportProtocol.Tcp, 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
                        },
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = LoadBalancingTransportProtocol.Tcp,
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
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerCollection = GetLoadBalancerCollection(resourceGroup);
            var putLoadBalancerOperation = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancerResource> getLoadBalancer = await resourceGroup.GetLoadBalancers().GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id.ToString());
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id.ToString());
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId.ToString());
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.ETag, listLoadBalancer.First().Data.ETag);

            // Verify List LoadBalancerResource subscription
            AsyncPageable<LoadBalancerResource> listLoadBalancerSubscriptionAP = subscription.GetLoadBalancersAsync();
            List<LoadBalancerResource> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.ETag);

            // Delete LoadBalancer
            await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed);

            // Verify Delete
            listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task LoadBalancerApiTestWithStaticIp()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

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
                    new FrontendIPConfigurationData()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Static,
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
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = LoadBalancingTransportProtocol.Tcp,
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
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerCollection = GetLoadBalancerCollection(resourceGroup);
            var putLoadBalancerOperation = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id.ToString());
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id.ToString());
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId.ToString());
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Has.One.EqualTo(listLoadBalancer);
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.ETag, listLoadBalancer.First().Data.ETag);

            // Verify List LoadBalancerResource subscription
            AsyncPageable<LoadBalancerResource> listLoadBalancerSubscriptionAP = subscription.GetLoadBalancersAsync();
            List<LoadBalancerResource> listLoadBalancerSubscription = await listLoadBalancerSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listLoadBalancerSubscription);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.Name);
            Assert.NotNull(listLoadBalancerSubscription.First().Data.ETag);

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync(WaitUntil.Completed);
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

            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

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
                    new FrontendIPConfigurationData()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Static,
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
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
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
                        FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    },
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        EnableFloatingIP = false
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadbalancerparamater);

            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbName, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(frontendIpConfigName, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].ProvisioningState.ToString());
            Assert.AreEqual(vnet.Data.Subnets[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].Subnet.Id);
            Assert.NotNull(getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual("10.0.0.38", getLoadBalancer.Value.Data.FrontendIPConfigurations[0].PrivateIPAddress);
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[0].Id.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatRules[1].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatRules[1].Id.ToString());
            Assert.AreEqual(backEndAddressPoolName, getLoadBalancer.Value.Data.BackendAddressPools[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.BackendAddressPools[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.LoadBalancingRules[0].Id, getLoadBalancer.Value.Data.BackendAddressPools[0].LoadBalancingRules[0].Id.ToString());
            Assert.AreEqual(loadBalancingRuleName, getLoadBalancer.Value.Data.LoadBalancingRules[0].Name);
            Assert.AreEqual(LoadDistribution.Default, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.LoadBalancingRules[0].IdleTimeoutInMinutes);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.LoadBalancingRules[0].ProvisioningState.ToString());
            Assert.AreEqual(probeName, getLoadBalancer.Value.Data.Probes[0].Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.Probes[0].ProvisioningState.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId.ToString());
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[0].ProvisioningState.ToString());
            Assert.AreEqual(inboundNatRule1Name, getLoadBalancer.Value.Data.InboundNatRules[0].Name);
            Assert.AreEqual("Tcp", getLoadBalancer.Value.Data.InboundNatRules[0].Protocol.ToString());
            Assert.AreEqual(3389, getLoadBalancer.Value.Data.InboundNatRules[0].FrontendPort);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.InboundNatRules[1].ProvisioningState.ToString());
            Assert.AreEqual(3390, getLoadBalancer.Value.Data.InboundNatRules[1].FrontendPort);
            Assert.AreEqual(4, getLoadBalancer.Value.Data.InboundNatRules[1].IdleTimeoutInMinutes);

            // Verify List LoadBalancer
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.AreEqual(lbName, listLoadBalancer.First().Data.Name);
            Assert.AreEqual(getLoadBalancer.Value.Data.ETag, listLoadBalancer.First().Data.ETag);

            // Do another put after changing the distribution policy
            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIP;
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadbalancerparamater);
            getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

            Assert.AreEqual(LoadDistribution.SourceIP, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);

            loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIPProtocol;
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadbalancerparamater);
            getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

            Assert.AreEqual(LoadDistribution.SourceIPProtocol, getLoadBalancer.Value.Data.LoadBalancingRules[0].LoadDistribution);

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed)).WaitForCompletionResponseAsync();

            // Verify Delete
            listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync(WaitUntil.Completed);
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
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            var putLoadBalancerOperation = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbname, loadbalancerparamater);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.False(getLoadBalancer.Value.Data.FrontendIPConfigurations.Any());
            Assert.False(getLoadBalancer.Value.Data.BackendAddressPools.Any());
            Assert.False(getLoadBalancer.Value.Data.LoadBalancingRules.Any());
            Assert.False(getLoadBalancer.Value.Data.Probes.Any());
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed)).WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
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

            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create the LoadBalancerResource with an lb rule and no probe
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
                    new FrontendIPConfigurationData()
                    {
                        Name = frontendIpConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Static,
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
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbname, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbname, "backendAddressPools", backEndAddressPoolName)
                        }
                    }
                },
            };

            // Create the loadBalancer
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbname, loadbalancerparamater);
            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.Data.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.LoadBalancingRules.Count);
            Assert.False(getLoadBalancer.Value.Data.Probes.Any());
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Add a ProbeResource to the lb rule
            getLoadBalancer.Value.Data.Probes.Add(
                new ProbeData()
                {
                    Name = probeName,
                    Protocol = ProbeProtocol.Http,
                    Port = 80,
                    RequestPath = "healthcheck.aspx",
                    IntervalInSeconds = 10,
                    NumberOfProbes = 2
                }
            );

            getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbname, "probes", probeName);

            // update load balancer
            var putLoadBalancerOperation = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbname, getLoadBalancer.Value.Data);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            getLoadBalancer = await loadBalancerCollection.GetAsync(lbname);

            // Verify the GET LoadBalancer
            Assert.AreEqual(lbname, getLoadBalancer.Value.Data.Name);
            Assert.AreEqual("Succeeded", getLoadBalancer.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual(1, getLoadBalancer.Value.Data.FrontendIPConfigurations.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.BackendAddressPools.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.LoadBalancingRules.Count);
            Assert.AreEqual(1, getLoadBalancer.Value.Data.Probes.Count);
            Assert.AreEqual(getLoadBalancer.Value.Data.Probes[0].Id, getLoadBalancer.Value.Data.LoadBalancingRules[0].Properties.ProbeId.ToString());
            Assert.False(getLoadBalancer.Value.Data.InboundNatRules.Any());

            // Delete LoadBalancer
            await (await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed)).WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete VirtualNetwork
            await vnet.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        [Ignore("11/26/2021 Ignored since this test now cannot pass record, need fix")]
        public async Task LoadBalancerApiNicAssociationTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create lbPublicIP
            string lbPublicIpName = Recording.GenerateAssetName("azsmnet");
            string lbDomaingNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, lbDomaingNameLabel, location, resourceGroup.GetPublicIPAddresses());

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkResource vnet = await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");
            string nic3name = Recording.GenerateAssetName("azsmnet");

            NetworkInterfaceResource nic1 = await CreateNetworkInterface(nic1name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());
            NetworkInterfaceResource nic2 = await CreateNetworkInterface(nic2name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());
            NetworkInterfaceResource nic3 = await CreateNetworkInterface(nic3name, null, vnet.Data.Subnets[0].Id, location, "ipconfig", resourceGroup.GetNetworkInterfaces());

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
                        Name = backEndAddressPoolName
                    }
                },
                LoadBalancingRules = {
                    new LoadBalancingRuleData()
                    {
                        Name = loadBalancingRuleName,
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
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
                            resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        },
                        Protocol = LoadBalancingTransportProtocol.Tcp,
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
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3390,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false,
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            var putLoadBalancerOperation = await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadBalancer);
            await putLoadBalancerOperation.WaitForCompletionAsync();
            ;
            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

            // Associate the nic with LB
            nic1.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.Data.BackendAddressPools.First());
            nic1.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.Data.InboundNatRules.First());
            nic2.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(getLoadBalancer.Value.Data.BackendAddressPools.First());
            nic2.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(getLoadBalancer.Value.Data.InboundNatRules[1]);

            // Put Nics
            var networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            var nic1Operation = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic1name, nic1.Data);
            await nic1Operation.WaitForCompletionAsync();

            var nic2Operation = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic2name, nic2.Data);
            await nic2Operation.WaitForCompletionAsync();

            var nic3Operation = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic3name, nic3.Data);
            await nic3Operation.WaitForCompletionAsync();

            // Get Nics
            nic1 = await networkInterfaceCollection.GetAsync(nic1name);
            nic2 = await networkInterfaceCollection.GetAsync(nic2name);
            nic3 = await networkInterfaceCollection.GetAsync(nic3name);

            // Verify the associations
            getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);
            Assert.AreEqual(2, getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations.Count);
            Assert.AreEqual(getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations[0].Id, nic1.Data.IPConfigurations[0].Id);
            Assert.AreEqual(getLoadBalancer.Value.Data.BackendAddressPools.First().BackendIPConfigurations[1].Id, nic2.Data.IPConfigurations[0].Id);
            Assert.AreEqual(nic1.Data.IPConfigurations[0].Id, getLoadBalancer.Value.Data.InboundNatRules.First().BackendIPConfiguration.Id);

            // Verify List NetworkInterfaces in LoadBalancer// Verify List NetworkInterfaces in LoadBalancer
            AsyncPageable<NetworkInterfaceResource> listLoadBalancerNetworkInterfacesAP = getLoadBalancer.Value.GetLoadBalancerNetworkInterfacesAsync();
            List<NetworkInterfaceResource> listLoadBalancerNetworkInterfaces = await listLoadBalancerNetworkInterfacesAP.ToEnumerableAsync();
            Assert.AreEqual(2, listLoadBalancerNetworkInterfaces.Count());

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all NetworkInterfaces
            await nic1.DeleteAsync(WaitUntil.Completed);
            await nic2.DeleteAsync(WaitUntil.Completed);
            await nic2.DeleteAsync(WaitUntil.Completed);

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync(WaitUntil.Completed);
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

            PublicIPAddressResource lbPublicIp = await CreateDefaultPublicIpAddress(lbPublicIpName, lbDomaingNameLabel, location, resourceGroup.GetPublicIPAddresses());

            // Create the LoadBalancer
            string lbName = Recording.GenerateAssetName("azsmnet");
            string frontendIpConfigName = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool1Name = Recording.GenerateAssetName("azsmnet");
            string inboundNatPool2Name = Recording.GenerateAssetName("azsmnet");

            var loadBalancer = new LoadBalancerData()
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
                InboundNatPools = {
                    new LoadBalancerInboundNatPool()
                    {
                        Name = inboundNatPool1Name,
                        Properties = new LoadBalancerInboundNatPoolProperties(LoadBalancingTransportProtocol.Tcp, frontendPortRangeStart: 100, frontendPortRangeEnd: 105, backendPort: 81)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                        }
                    }
                }
            };

            // Create the loadBalancer
            var loadBalancerCollection = resourceGroup.GetLoadBalancers();
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, loadBalancer);
            Response<LoadBalancerResource> getLoadBalancer = await loadBalancerCollection.GetAsync(lbName);

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
            Assert.AreEqual(LoadBalancingTransportProtocol.Tcp, getLoadBalancer.Value.Data.InboundNatPools[0].Protocol);
            Assert.AreEqual(GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.Value.Data.InboundNatPools[0].Properties.FrontendIPConfigurationId.ToString());
            Assert.AreEqual(getLoadBalancer.Value.Data.InboundNatPools[0].Id, getLoadBalancer.Value.Data.FrontendIPConfigurations[0].InboundNatPools[0].Id.ToString());

            // Add a new nat pool
            LoadBalancerInboundNatPool natpool2 = new LoadBalancerInboundNatPool()
            {
                Name = inboundNatPool2Name,
                Properties = new LoadBalancerInboundNatPoolProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPortRangeStart: 107, frontendPortRangeEnd: 110, backendPort: 81)
                {
                    FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                }
            };
            getLoadBalancer.Value.Data.InboundNatPools.Add(natpool2);
            await loadBalancerCollection.CreateOrUpdateAsync(WaitUntil.Completed, lbName, getLoadBalancer.Value.Data);

            // Verify the nat pool
            Assert.AreEqual(2, getLoadBalancer.Value.Data.InboundNatPools.Count);

            // Delete LoadBalancer
            var deleteOperation = await getLoadBalancer.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);

            // Delete all PublicIPAddresses
            await lbPublicIp.DeleteAsync(WaitUntil.Completed);
        }

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
                        Properties = new LoadBalancingRuleProperties(protocol: LoadBalancingTransportProtocol.Tcp, frontendPort: 80)
                        {
                            FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName),
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPoolId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName),
                            ProbeId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "probes", probeName)
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
                        FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName),
                        Protocol = LoadBalancingTransportProtocol.Tcp,
                        FrontendPort = 3389,
                        BackendPort = 3389,
                        IdleTimeoutInMinutes = 15,
                        EnableFloatingIP = false
                    },
                    new InboundNatRuleData()
                    {
                        Name = inboundNatRule2Name,
                        FrontendIPConfigurationId = GetChildLbResourceId(TestEnvironment.SubscriptionId, resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName),
                        Protocol = LoadBalancingTransportProtocol.Tcp,
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
            nic1.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());
            nic1.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(loadBalancer.Data.InboundNatRules[0]);
            nic2.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());
            nic2.Data.IPConfigurations.First().LoadBalancerInboundNatRules.Add(loadBalancer.Data.InboundNatRules[1]);
            nic3.Data.IPConfigurations.First().LoadBalancerBackendAddressPools.Add(loadBalancer.Data.BackendAddressPools.First());

            // Put Nics
            var networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            nic1 = (await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic1name, nic1.Data)).Value;
            nic2 = (await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic2name, nic2.Data)).Value;
            nic3 = (await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic3name, nic3.Data)).Value;

            // Get lb with expanded nics from nat rules
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "InboundNatRules/backendIPConfiguration");

            await foreach (var natRule in loadBalancer.GetInboundNatRules())
            {
                Assert.NotNull(natRule.Data.BackendIPConfiguration);
                Assert.NotNull(natRule.Data.BackendIPConfiguration.Id);
            }

            // Get lb with expanded nics from pools
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "BackendAddressPools/backendIPConfigurations");

            await foreach (var pool in loadBalancer.GetBackendAddressPools())
            {
                BackendAddressPoolResource firstPool = await GetFirstPoolAsync(loadBalancer);
                foreach (var ipconfig in firstPool.Data.BackendIPConfigurations)
                {
                    Assert.NotNull(ipconfig.Id);
                }
            }

            // Get lb with expanded publicip
            loadBalancer = await loadBalancerCollection.GetAsync(lbName, "FrontendIPConfigurations/PublicIPAddress");
            foreach (var ipconfig in loadBalancer.Data.FrontendIPConfigurations)
            {
                Assert.NotNull(ipconfig.PublicIPAddress);
                Assert.NotNull(ipconfig.PublicIPAddress.Id);
                Assert.NotNull(ipconfig.PublicIPAddress.Name);
                Assert.NotNull(ipconfig.PublicIPAddress.ETag);
                Assert.AreEqual(ipconfig.Id, ipconfig.PublicIPAddress.IPConfiguration.Id);
            }

            // Delete LoadBalancer
            Operation deleteOperation = await (await loadBalancerCollection.GetAsync(lbName)).Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();

            // Verify Delete
            AsyncPageable<LoadBalancerResource> listLoadBalancerAP = loadBalancerCollection.GetAllAsync();
            List<LoadBalancerResource> listLoadBalancer = await listLoadBalancerAP.ToEnumerableAsync();
            Assert.IsEmpty(listLoadBalancer);
        }
    }
}
