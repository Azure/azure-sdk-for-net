// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class GatewayOperationsTests : NetworkTestsManagementClientBase
    {
        public GatewayOperationsTests(bool isAsync) : base(isAsync)
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

        private enum TestEnvironmentSettings
        {
            ClientRootCertName,
            SamplePublicCertData,
            SampleCertThumbprint
        }

        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Test]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. CreateVirtualNetworkGateway API
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = null,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new SubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Basic,
                    Tier = VirtualNetworkGatewaySkuTier.Basic
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Name,
                getVirtualNetworkGatewayResponse.Value.GatewayType, getVirtualNetworkGatewayResponse.Value.VpnType,
                getVirtualNetworkGatewayResponse.Value.Sku.Name, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Value.Sku.Tier);

            // 3. ResizeVirtualNetworkGateway API
            getVirtualNetworkGatewayResponse.Value.Sku = new VirtualNetworkGatewaySku()
            {
                Name = VirtualNetworkGatewaySkuName.Standard,
                Tier = VirtualNetworkGatewaySkuTier.Standard
            };
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Standard, getVirtualNetworkGatewayResponse.Value.Sku.Tier);

            // 4A. ResetVirtualNetworkGateway API
            VirtualNetworkGatewaysResetOperation resetVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartResetAsync(resourceGroupName, virtualNetworkGatewayName);
            await WaitForCompletionAsync(resetVirtualNetworkGatewayResponseOperation);

            // 4B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);

            Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                getVirtualNetworkGatewayResponse.Value.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Name,
                getVirtualNetworkGatewayResponse.Value.GatewayType);

            // 5. ListVitualNetworkGateways API
            AsyncPageable<VirtualNetworkGateway> listVirtualNetworkGatewayResponseAP = NetworkManagementClient.VirtualNetworkGateways.ListAsync(resourceGroupName);
            List<VirtualNetworkGateway> listVirtualNetworkGatewayResponse = await listVirtualNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count);
            Has.One.EqualTo(listVirtualNetworkGatewayResponse);

            // 6A. DeleteVirtualNetworkGateway API
            VirtualNetworkGatewaysDeleteOperation deleteOperation = await NetworkManagementClient.VirtualNetworkGateways.StartDeleteAsync(resourceGroupName, virtualNetworkGatewayName);
            await WaitForCompletionAsync(deleteOperation);

            // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
            listVirtualNetworkGatewayResponseAP = NetworkManagementClient.VirtualNetworkGateways.ListAsync(resourceGroupName);
            listVirtualNetworkGatewayResponse = await listVirtualNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayResponse);
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Test]
        public async Task LocalNettworkGatewayOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/localNetworkGateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. CreateLocalNetworkGateway API
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";
            string addressPrefixes = "192.168.0.0/16";
            string newAddressPrefixes = "200.168.0.0/16";

            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { addressPrefixes, }
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 2. GetLocalNetworkGateway API
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Location,
                getLocalNetworkGatewayResponse.Value.Id, getLocalNetworkGatewayResponse.Value.Name,
                getLocalNetworkGatewayResponse.Value.GatewayIpAddress, getLocalNetworkGatewayResponse.Value.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(gatewayIp, getLocalNetworkGatewayResponse.Value.GatewayIpAddress);
            Assert.AreEqual(addressPrefixes, getLocalNetworkGatewayResponse.Value.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 3A. UpdateLocalNetworkgateway API :- LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse.Value.LocalNetworkAddressSpace = new AddressSpace() { AddressPrefixes = { newAddressPrefixes, } };

            putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, getLocalNetworkGatewayResponse);
            putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Location, getLocalNetworkGatewayResponse.Value.Id,
                getLocalNetworkGatewayResponse.Value.Name, getLocalNetworkGatewayResponse.Value.GatewayIpAddress,
                getLocalNetworkGatewayResponse.Value.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(newAddressPrefixes, getLocalNetworkGatewayResponse.Value.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 4. ListLocalNetworkGateways API
            AsyncPageable<LocalNetworkGateway> listLocalNetworkGatewayResponseAP = NetworkManagementClient.LocalNetworkGateways.ListAsync(resourceGroupName);
            List<LocalNetworkGateway> listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Has.One.EqualTo(listLocalNetworkGatewayResponse);

            // 5A. DeleteLocalNetworkGateway API
            LocalNetworkGatewaysDeleteOperation deleteOperation = await NetworkManagementClient.LocalNetworkGateways.StartDeleteAsync(resourceGroupName, localNetworkGatewayName);
            await WaitForCompletionAsync(deleteOperation);

            // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
            listLocalNetworkGatewayResponseAP = NetworkManagementClient.LocalNetworkGateways.ListAsync(resourceGroupName);
            listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Assert.IsEmpty(listLocalNetworkGatewayResponse);
        }

        [Test]
        public async Task VirtualNetworkGatewayConnectionWithBgpTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create a local network gateway with BGP
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                },
                BgpSettings = new BgpSettings()
                {
                    Asn = 1234,
                    BgpPeeringAddress = "192.168.0.1",
                    PeerWeight = 3
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new SubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = "Standard",
                    Tier = "Standard"
                },
                BgpSettings = new BgpSettings()
                {
                    Asn = 1337,
                    BgpPeeringAddress = null, // Gateway manager assigns this
                    PeerWeight = 5
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.BgpSettings);
            Assert.False(string.IsNullOrEmpty(getVirtualNetworkGatewayResponse.Value.BgpSettings.BgpPeeringAddress), "The gateway's CA should be populated");

            // Create a virtual network gateway connection with BGP enabled
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection(getVirtualNetworkGatewayResponse, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                RoutingWeight = 3,
                SharedKey = "abc",
                EnableBgp = true
            };
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());
            Assert.True(putVirtualNetworkGatewayConnectionResponse.Value.EnableBgp, "Enabling BGP for this connection must succeed");

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}, EnableBgp={12}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.IngressBytesTransferred,
                getVirtualNetworkGatewayConnectionResponse.Value.EnableBgp);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType);
            Assert.True(getVirtualNetworkGatewayConnectionResponse.Value.EnableBgp);

            // 4. ListVitualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartDeleteAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            await WaitForCompletionAsync(deleteOperation);

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnection with Ipsec Policies
        [Test]
        public async Task VirtualNetworkGatewayConnectionWithIpsecPoliciesTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new SubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Standard,
                    Tier = VirtualNetworkGatewaySkuTier.Standard
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnection(getVirtualNetworkGatewayResponse, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                RoutingWeight = 3,
                SharedKey = "abc",
                IpsecPolicies =
                {
                    new IpsecPolicy(300, 1024, IpsecEncryption.AES128, IpsecIntegrity.SHA256, IkeEncryption.AES192, IkeIntegrity.SHA1, DhGroup.DHGroup2, PfsGroup.PFS1)
                }
            };

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Name,
                    getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType);
            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IpsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IpsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].SaLifeTimeSeconds);

            // 3A. UpdateVirtualNetworkGatewayConnection API : update ipsec policies and disable TS
            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = false;
            virtualNetworkGatewayConnection.IpsecPolicies.Clear();
            virtualNetworkGatewayConnection.IpsecPolicies.Add(new IpsecPolicy(600, 2048, IpsecEncryption.Gcmaes256, IpsecIntegrity.Gcmaes256, IkeEncryption.AES256, IkeIntegrity.SHA384, DhGroup.DHGroup2048, PfsGroup.ECP384));

            putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IpsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IpsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies[0].SaLifeTimeSeconds);

            // 4A. UpdateVirtualNetworkGatewayConnection API : remove ipsec policies
            (virtualNetworkGatewayConnection.IpsecPolicies as ChangeTrackingList<IpsecPolicy>).Reset();

            putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 4B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(0, getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count);

            // 4. ListVitualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            var deleteOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartDeleteAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            await WaitForCompletionAsync(deleteOperation);

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs & Set-Remove default site
        [Test]
        public async Task VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = new SubResource()
                {
                    Id = getLocalNetworkGatewayResponse.Value.Id
                },
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new SubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite);
            Console.WriteLine("Default site :{0} set at Virtual network gateway.", getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite);
            Assert.AreEqual(getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite.Id, getLocalNetworkGatewayResponse.Value.Id);

            // C. CreaetVirtualNetworkGatewayConnection API
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection(getVirtualNetworkGatewayResponse, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                RoutingWeight = 3,
                SharedKey = "abc"
            };
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.IngressBytesTransferred);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType);
            Assert.AreEqual(3, getVirtualNetworkGatewayConnectionResponse.Value.RoutingWeight);
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.SharedKey);

            // 2A. Remove Default local network site
            getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite = null;
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.Null(getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite);
            Console.WriteLine("Default site removal from Virtual network gateway is successful.", getVirtualNetworkGatewayResponse.Value.GatewayDefaultSite);

            // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
            await WaitForCompletionAsync(await NetworkManagementClient.VirtualNetworkGatewayConnections.StartSetSharedKeyAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, new ConnectionSharedKey("xyz")));
            virtualNetworkGatewayConneciton.RoutingWeight = 4;

            putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
            getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.IngressBytesTransferred);
            Assert.AreEqual(4, getVirtualNetworkGatewayConnectionResponse.Value.RoutingWeight);
            Assert.AreEqual("xyz", getVirtualNetworkGatewayConnectionResponse.Value.SharedKey);

            // 4A. ListVirtualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 4B. VirtualNetworkGateway ListConnections API
            AsyncPageable<VirtualNetworkGatewayConnectionListEntity> virtualNetworkGatewayListConnectionsResponseAP = NetworkManagementClient.VirtualNetworkGateways.ListConnectionsAsync(resourceGroupName, virtualNetworkGatewayName);
            List<VirtualNetworkGatewayConnectionListEntity> virtualNetworkGatewayListConnectionsResponse = await virtualNetworkGatewayListConnectionsResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(virtualNetworkGatewayListConnectionsResponse);
            Assert.AreEqual(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayListConnectionsResponse.First().Name);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartDeleteAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            await WaitForCompletionAsync(deleteOperation);

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = NetworkManagementClient.VirtualNetworkGatewayConnections.ListAsync(resourceGroupName);
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Test]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. SetVirtualNetworkGatewayConnectionSharedKey API
            // Pre-requsite:- CreateVirtualNetworkGatewayConnection first
            // Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // c. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = null,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new SubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);

            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";
            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);
            getLocalNetworkGatewayResponse.Value.Location = location;

            // CreaetVirtualNetworkGatewayConnection API
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection(getVirtualNetworkGatewayResponse, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                RoutingWeight = 3,
                SharedKey = "abc"
            };
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, VirtualNetworkGatewayConnectionName);
            Assert.AreEqual("Succeeded", getVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.SharedKey);

            // 2A. VirtualNetworkGatewayConnectionResetSharedKey API
            string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
            ConnectionResetSharedKey connectionResetSharedKey = new ConnectionResetSharedKey(50);
            VirtualNetworkGatewayConnectionsResetSharedKeyOperation resetConnectionResetSharedKeyResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartResetSharedKeyAsync(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);
            await WaitForCompletionAsync(resetConnectionResetSharedKeyResponseOperation);

            // 2B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
            Response<ConnectionSharedKey> getconnectionSharedKeyResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetSharedKeyAsync(resourceGroupName, connectionSharedKeyName);
            Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            Assert.AreNotEqual("abc", getconnectionSharedKeyResponse.Value);

            // 3A.SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
            ConnectionSharedKey connectionSharedKey = new ConnectionSharedKey("TestSharedKeyValue");
            VirtualNetworkGatewayConnectionsSetSharedKeyOperation putConnectionSharedKeyResponseOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartSetSharedKeyAsync(resourceGroupName, connectionSharedKeyName, connectionSharedKey);
            await WaitForCompletionAsync(putConnectionSharedKeyResponseOperation);

            // 3B. GetVirtualNetworkGatewayConnectionSharedKey API
            getconnectionSharedKeyResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetSharedKeyAsync(resourceGroupName, connectionSharedKeyName);
            Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            Assert.AreEqual("TestSharedKeyValue", getconnectionSharedKeyResponse.Value.Value.ToString());
        }

        // Tests Resource:-VirtualNetworkGateway P2S APIs:-
        [Test]
        [Ignore("Track2: Missing the value of a special environment variable, which is currently uncertain")]
        public async Task VirtualNetworkGatewayP2SOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create LocalNetworkGateway to set as default site
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            LocalNetworkGateway localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace() { AddressPrefixes = { "192.168.0.0/16", } }
            };
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);

            // 1.CreateVirtualNetworkGateway API
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string addressPrefixes = "192.168.0.0/16";
            string newAddressPrefixes = "200.168.0.0/16";

            var virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                Sku = new VirtualNetworkGatewaySku
                {
                    Name = VirtualNetworkGatewaySkuName.Basic,
                    Tier = VirtualNetworkGatewaySkuTier.Basic,
                },
                GatewayDefaultSite = new SubResource() { Id = getLocalNetworkGatewayResponse.Value.Id },
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource() { Id = nic1publicIp.Id },
                        Subnet = new SubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new AddressSpace() { AddressPrefixes = { addressPrefixes } }
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Name,
                getVirtualNetworkGatewayResponse.Value.GatewayType, getVirtualNetworkGatewayResponse.Value.VpnType,
                getVirtualNetworkGatewayResponse.Value.Sku.Name, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(addressPrefixes), "P2S client Address Pool is not set on Gateway!");

            // 3.Update P2S VPNClient Address Pool
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration = new VpnClientConfiguration()
            {
                VpnClientAddressPool = new AddressSpace() { AddressPrefixes = { newAddressPrefixes } }
            };
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(newAddressPrefixes), "P2S client Address Pool Update is Failed!");

            // 3.Add client Root certificate
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "ClientRootCertName";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "SamplePublicCertData";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(samplePublicCertData)
            {
                Name = clientRootCertName,
            };
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRootCertificates.Add(clientRootCert);

            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 4. Get client Root certificates
            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRootCertificates.Count() == 1 &&
                getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRootCertificates[0].Name.Equals(clientRootCertName), "Vpn client Root certificate upload was Failed!");

            // 5.Generate P2S Vpnclient package
            VpnClientParameters vpnClientParameters = new VpnClientParameters()
            {
                ProcessorArchitecture = ProcessorArchitecture.Amd64
            };
            VirtualNetworkGatewaysGeneratevpnclientpackageOperation packageUrlOperation = await NetworkManagementClient.VirtualNetworkGateways.StartGeneratevpnclientpackageAsync(resourceGroupName, virtualNetworkGatewayName, vpnClientParameters);
            await WaitForCompletionAsync(packageUrlOperation);
            //Assert.NotNull(packageUrl);
            //Assert.NotEmpty(packageUrl);
            //Console.WriteLine("Vpn client package Url = {0}", packageUrl);

            // 6.Delete client Root certificate
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRootCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRootCertificates.Count() == 0);

            // 7. Get Vpn client revoked certificates
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);

            // 8. Try to revoke Vpn client certificate which is not there and verify proper error comes back
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string sampleCertThumpprint = "SampleCertThumbprint";//this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SampleCertThumbprint.ToString()];
            VpnClientRevokedCertificate sampleClientCert = new VpnClientRevokedCertificate()
            {
                Name = "sampleClientCert.cer",
                Thumbprint = sampleCertThumpprint
            };
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates.Add(sampleClientCert);

            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 1);
            Assert.AreEqual("sampleClientCert.cer", getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates[0].Name);

            // 9. Unrevoke previously revoked Vpn client certificate
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);
        }

        // Tests Resource:-VirtualNetworkGateway ActiveActive Feature Test:-
        [Test]
        [Ignore("Track2: The current operation failed due to an intermittent error with gateway 'azsmnet123'. Please try again")]
        public async Task VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1. Create Active-Active VirtualNetworkGateway
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName1 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel1 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp1 = await CreateDefaultPublicIpAddress(publicIpName1, resourceGroupName, domainNameLabel1, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp1.Id);

            string publicIpName2 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel2 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp2 = await CreateDefaultPublicIpAddress(publicIpName2, resourceGroupName, domainNameLabel2, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp2.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API

            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetwork virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);

            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName1 = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = ipConfigName1,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = nic1publicIp1.Id },
                Subnet = new SubResource() { Id = getSubnetResponse.Value.Id }
            };

            string ipConfigName2 = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = ipConfigName2,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = nic1publicIp2.Id },
                Subnet = new SubResource() { Id = getSubnetResponse.Value.Id }
            };

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                Active = true,
                GatewayDefaultSite = null,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations = { ipconfig1, ipconfig2 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.HighPerformance, Tier = VirtualNetworkGatewaySkuTier.HighPerformance }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6} ActiveActive enabled-{7}",
                getVirtualNetworkGatewayResponse.Value.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Name,
                getVirtualNetworkGatewayResponse.Value.GatewayType, getVirtualNetworkGatewayResponse.Value.VpnType,
                getVirtualNetworkGatewayResponse.Value.Sku.Name, getVirtualNetworkGatewayResponse.Value.Sku.Tier,
                getVirtualNetworkGatewayResponse.Value.Active);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.HighPerformance, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.IpConfigurations.Count);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Active);

            // 3. Update ActiveActive VirtualNetworkGateway to ActiveStandby
            getVirtualNetworkGatewayResponse.Value.Active = false;
            getVirtualNetworkGatewayResponse.Value.IpConfigurations.Remove(getVirtualNetworkGatewayResponse.Value.IpConfigurations.First(config => config.Name.Equals(ipconfig2.Name)));
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.False(getVirtualNetworkGatewayResponse.Value.Active);
            Assert.AreEqual(1, getVirtualNetworkGatewayResponse.Value.IpConfigurations.Count);

            // 4. Update ActiveStandby VirtualNetworkGateway to ActiveActive again
            getVirtualNetworkGatewayResponse.Value.Active = true;
            getVirtualNetworkGatewayResponse.Value.IpConfigurations.Add(ipconfig2);
            putVirtualNetworkGatewayResponseOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Active);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.IpConfigurations.Count);
        }

        [Test]
        [Ignore("Track2: Occasionally succeed in online")]
        public async Task VirtualNetworkGatewayBgpRouteApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            string gatewaySubnetName = "GatewaySubnet";
            string gw1Name = Recording.GenerateAssetName("azsmnet");
            string vnet1Name = Recording.GenerateAssetName("azsmnet");
            string gw1IpName = Recording.GenerateAssetName("azsmnet");
            string gw1IpDomainNameLabel = Recording.GenerateAssetName("azsmnet");
            string gw1IpConfigName = Recording.GenerateAssetName("azsmnet");

            string gw2Name = Recording.GenerateAssetName("azsmnet");
            string vnet2Name = Recording.GenerateAssetName("azsmnet");
            string gw2IpName = Recording.GenerateAssetName("azsmnet");
            string gw2IpDomainNameLabel = Recording.GenerateAssetName("azsmnet");
            string gw2IpConfigName = Recording.GenerateAssetName("azsmnet");

            // Deploy two virtual networks with VPN gateways, in parallel
            VirtualNetwork vnet1 = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = { "10.1.0.0/16" } },
                Subnets = { new Subnet() { Name = gatewaySubnetName, AddressPrefix = "10.1.1.0/24" } }
            };
            PublicIPAddress publicIPAddress = await CreateDefaultPublicIpAddress(gw1IpName, resourceGroupName, gw1IpDomainNameLabel, location, NetworkManagementClient);
            VirtualNetworksCreateOrUpdateOperation virtualNetworksCreateOrUpdateOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnet1Name, vnet1);
            Response<VirtualNetwork> vnet1Response = await WaitForCompletionAsync(virtualNetworksCreateOrUpdateOperation);
            Response<Subnet> gw1Subnet = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnet1Name, gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw1IpConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = publicIPAddress.Id },
                Subnet = new SubResource() { Id = gw1Subnet.Value.Id }
            };
            VirtualNetworkGateway gw1 = new VirtualNetworkGateway()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations = { ipconfig1 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 1337, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            PublicIPAddress gw2Ip = await CreateDefaultPublicIpAddress(gw2IpName, resourceGroupName, gw2IpDomainNameLabel, location, NetworkManagementClient);
            VirtualNetwork vnet2 = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = { "10.2.0.0/16" } },
                Subnets = { new Subnet() { Name = gatewaySubnetName, AddressPrefix = "10.2.1.0/24", } }
            };
            VirtualNetworksCreateOrUpdateOperation vnet2Operation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnet2Name, vnet2);
            VirtualNetwork vnet2Response = await WaitForCompletionAsync(vnet2Operation);
            Response<Subnet> gw2Subnet = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnet2Name, gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw2IpConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = gw2Ip.Id },
                Subnet = new SubResource() { Id = gw2Subnet.Value.Id }
            };
            VirtualNetworkGateway gw2 = new VirtualNetworkGateway()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations = { ipconfig2 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 9001, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            List<Task> gatewayDeploymentTasks = new List<Task>
            {
                await Task.Factory.StartNew(async () =>
                {
                    VirtualNetworkGatewaysCreateOrUpdateOperation virtualNetworkGatewaysOperation = await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, gw1Name, gw1);
                    await WaitForCompletionAsync(virtualNetworkGatewaysOperation);
                }),

                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewaysCreateOrUpdateOperation virtualNetworkGatewaysOperation= await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, gw2Name, gw2);
                    await WaitForCompletionAsync(virtualNetworkGatewaysOperation);
                })
            };

            Task.WaitAll(gatewayDeploymentTasks.ToArray());

            // Create a vnet to vnet connection between the two gateways
            // configure both gateways in parallel
            Response<VirtualNetworkGateway> gw1GetResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, gw1Name);
            Response<VirtualNetworkGateway> gw2GetResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, gw2Name);
            Response<PublicIPAddress> gw2IpResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, gw1IpName);
            string sharedKey = "chocolate";

            string conn1Name = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection gw1ToGw2Conn = new VirtualNetworkGatewayConnection(gw1GetResponse, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location,
                VirtualNetworkGateway2 = gw2GetResponse,
                RoutingWeight = 3,
                SharedKey = sharedKey,
                EnableBgp = true
            };

            string conn2Name = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection gw2ToGw1Conn = new VirtualNetworkGatewayConnection(gw2GetResponse, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location,
                VirtualNetworkGateway2 = gw1GetResponse,
                RoutingWeight = 3,
                SharedKey = sharedKey,
                EnableBgp = true
            };

            List<Task> gatewayConnectionTasks = new List<Task>
            {
                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewayConnectionsCreateOrUpdateOperation VirtualNetworkGatewayConnectionsCreateOrUpdateOperation = await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, conn1Name, gw1ToGw2Conn);
                    await WaitForCompletionAsync(VirtualNetworkGatewayConnectionsCreateOrUpdateOperation);
                }),
                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewayConnectionsCreateOrUpdateOperation VirtualNetworkGatewayConnectionsCreateOrUpdateOperation =  await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, conn2Name, gw2ToGw1Conn);
                    await WaitForCompletionAsync(VirtualNetworkGatewayConnectionsCreateOrUpdateOperation);
                })
            };

            Task.WaitAll(gatewayConnectionTasks.ToArray());

            // get bgp info from gw1
            VirtualNetworkGatewaysGetLearnedRoutesOperation learnedRoutesOperation = await NetworkManagementClient.VirtualNetworkGateways.StartGetLearnedRoutesAsync(resourceGroupName, gw1Name);
            Response<GatewayRouteListResult> learnedRoutes = await WaitForCompletionAsync(learnedRoutesOperation);
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be learned from gw2");
            VirtualNetworkGatewaysGetAdvertisedRoutesOperation advertisedRoutesOperation = await NetworkManagementClient.VirtualNetworkGateways.StartGetAdvertisedRoutesAsync(resourceGroupName, gw1Name, gw2IpResponse.Value.IpAddress);
            Response<GatewayRouteListResult> advertisedRoutes = await WaitForCompletionAsync(advertisedRoutesOperation);
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be advertised to gw2");
            VirtualNetworkGatewaysGetBgpPeerStatusOperation gw1PeersOperation = await NetworkManagementClient.VirtualNetworkGateways.StartGetBgpPeerStatusAsync(resourceGroupName, gw1Name);
            Response<BgpPeerStatusListResult> gw1Peers = await WaitForCompletionAsync(gw1PeersOperation);
            Assert.True(gw1Peers.Value.Value.Count() > 0, "At least one peer should be connected");
        }

        [Test]
        [Ignore("Track2: Missing the value of a special environment variable, which is currently uncertain")]
        public async Task VirtualNetworkGatewayGenerateVpnProfileTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // 1.CreateVirtualNetworkGateway
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");
            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName,
                domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetwork virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                NetworkManagementClient);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string addressPrefixes = "192.168.0.0/16";
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "0";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "1";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(samplePublicCertData) { Name = clientRootCertName };
            var virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource() { Id = nic1publicIp.Id },
                        Subnet = new SubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new AddressSpace()
                    {
                        AddressPrefixes = { addressPrefixes },
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.VpnGw2,
                    Tier = VirtualNetworkGatewaySkuTier.VpnGw2
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation =
                await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse =
               await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);
            Console.WriteLine(
                "Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Name,
                getVirtualNetworkGatewayResponse.Value.GatewayType, getVirtualNetworkGatewayResponse.Value.VpnType,
                getVirtualNetworkGatewayResponse.Value.Sku.Name, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.VpnGw2, getVirtualNetworkGatewayResponse.Value.Sku.Tier);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
                            .Count == 1 &&
                        getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool
                            .AddressPrefixes[0].Equals(addressPrefixes),
                "P2S client Address Pool is not set on Gateway!");

            // Update P2S VPNClient Address Pool and add radius settings
            string newAddressPrefixes = "200.168.0.0/16";
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration = new VpnClientConfiguration()
            {
                VpnClientAddressPool = new AddressSpace()
                {
                    AddressPrefixes = { newAddressPrefixes }
                },
                RadiusServerAddress = @"8.8.8.8",
                RadiusServerSecret = @"TestRadiusSecret",
            };
            getVirtualNetworkGatewayResponse.Value.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation =
                await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
            putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());

            // 5.Generate P2S Vpnclient package
            VpnClientParameters vpnClientParameters = new VpnClientParameters()
            {
                RadiusServerAuthCertificate = samplePublicCertData,
                AuthenticationMethod = AuthenticationMethod.Eaptls
            };

            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrl = ""; // await NetworkManagementClient.VirtualNetworkGateways.GenerateGatewayVpnProfile(resourceGroupName,virtualNetworkGatewayName, vpnClientParameters);

            Assert.NotNull(packageUrl);
            Assert.IsNotEmpty(packageUrl);
            Console.WriteLine("Vpn client package Url from GENERATE operation = {0}", packageUrl);

            // Retry to get the package url using the get profile API
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrlFromGetOperation = "";// NetworkManagementClient.VirtualNetworkGateways.GetGatewayVpnProfile(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(packageUrlFromGetOperation);
            Assert.IsNotEmpty(packageUrlFromGetOperation);
            Console.WriteLine("Vpn client package Url from GET operation = {0}", packageUrlFromGetOperation);
        }

        [Test]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayVpnDeviceConfigurationApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // CreateVirtualNetworkGatewayConnection API
            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGateway()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await NetworkManagementClient.LocalNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await WaitForCompletionAsync(putLocalNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await NetworkManagementClient.LocalNetworkGateways.GetAsync(resourceGroupName, localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, NetworkManagementClient);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, NetworkManagementClient);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            VirtualNetworkGateway virtualNetworkGateway = new VirtualNetworkGateway()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new SubResource() { Id = nic1publicIp.Id },
                        Subnet = new SubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Standard,
                    Tier = VirtualNetworkGatewaySkuTier.Standard
                }
            };

            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation =
                await NetworkManagementClient.VirtualNetworkGateways.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await NetworkManagementClient.VirtualNetworkGateways.GetAsync(resourceGroupName, virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
            string virtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayConnection virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnection(getVirtualNetworkGatewayResponse, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            virtualNetworkGatewayConnection.IpsecPolicies.Add(
                    new IpsecPolicy(300,1024,IpsecEncryption.AES128,IpsecIntegrity.SHA256,IkeEncryption.AES192,IkeIntegrity.SHA1,DhGroup.DHGroup2, PfsGroup.PFS1)
                );

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation =
                await NetworkManagementClient.VirtualNetworkGatewayConnections.StartCreateOrUpdateAsync(resourceGroupName, virtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await WaitForCompletionAsync(putVirtualNetworkGatewayConnectionResponseOperation);
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await NetworkManagementClient.VirtualNetworkGatewayConnections.GetAsync(resourceGroupName, virtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                              "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.UsePolicyBasedTrafficSelectors);

            // List supported Vpn Devices
            Response<string> supportedVpnDevices = await NetworkManagementClient.VirtualNetworkGateways.SupportedVpnDevicesAsync(resourceGroupName, virtualNetworkGatewayName);
            Assert.NotNull(supportedVpnDevices);
            Assert.IsNotEmpty(supportedVpnDevices);

            // Parse the supported devices list
            // Then use the first device to get the configuration
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(supportedVpnDevices);
            XmlNode vendorNode = xmldoc.SelectSingleNode("//Vendor");
            XmlNode deviceNode = vendorNode.FirstChild;
            string vendorName = vendorNode.Attributes["name"].Value;
            string deviceName = deviceNode.Attributes["name"].Value;
            string firmwareVersion = deviceNode.FirstChild.Attributes["name"].Value;

            VpnDeviceScriptParameters scriptParams = new VpnDeviceScriptParameters()
            {
                DeviceFamily = deviceName,
                FirmwareVersion = firmwareVersion,
                Vendor = vendorName
            };

            Response<string> vpnDeviceConfiguration =
                await NetworkManagementClient.VirtualNetworkGateways.VpnDeviceConfigurationScriptAsync(resourceGroupName, virtualNetworkGatewayConnectionName, scriptParams);

            Assert.NotNull(vpnDeviceConfiguration);
            Assert.IsNotEmpty(vpnDeviceConfiguration);
        }
    }
}
