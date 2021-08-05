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
    public class GatewayOperationsTests : NetworkServiceClientTestBase
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    //await CleanupResourceGroupsAsync();
        //}

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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGateway API
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType, getVirtualNetworkGatewayResponse.Value.Data.VpnType,
                getVirtualNetworkGatewayResponse.Value.Data.Sku.Name, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.Data.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.Data.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);

            // 3. ResizeVirtualNetworkGateway API
            getVirtualNetworkGatewayResponse.Value.Data.Sku = new VirtualNetworkGatewaySku()
            {
                Name = VirtualNetworkGatewaySkuName.Standard,
                Tier = VirtualNetworkGatewaySkuTier.Standard
            };
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Standard, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);

            // 4A. ResetVirtualNetworkGateway API
            VirtualNetworkGatewaysResetOperation resetVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.StartResetAsync();
            await resetVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;

            // 4B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);

            Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType);

            // 5. ListVitualNetworkGateways API
            AsyncPageable<VirtualNetworkGateway> listVirtualNetworkGatewayResponseAP = virtualNetworkGatewayContainer.GetAllAsync();
            List<VirtualNetworkGateway> listVirtualNetworkGatewayResponse = await listVirtualNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count);
            Has.One.EqualTo(listVirtualNetworkGatewayResponse);

            // 6A. DeleteVirtualNetworkGateway API
            // TODO: restore to specific type
            //VirtualNetworkGatewaysDeleteOperation deleteOperation = await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.StartDeleteAsync();
            var deleteOperation = await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
            listVirtualNetworkGatewayResponseAP = virtualNetworkGatewayContainer.GetAllAsync();
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateLocalNetworkGateway API
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";
            string addressPrefixes = "192.168.0.0/16";
            string newAddressPrefixes = "200.168.0.0/16";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { addressPrefixes, }
                }
            };

            var localNetworkGatewayContainer = resourceGroup.Value.GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetLocalNetworkGateway API
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Data.Location,
                getLocalNetworkGatewayResponse.Value.Id, getLocalNetworkGatewayResponse.Value.Data.Name,
                getLocalNetworkGatewayResponse.Value.Data.GatewayIpAddress, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(gatewayIp, getLocalNetworkGatewayResponse.Value.Data.GatewayIpAddress);
            Assert.AreEqual(addressPrefixes, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 3A. UpdateLocalNetworkgateway API :- LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace = new AddressSpace() { AddressPrefixes = { newAddressPrefixes, } };

            putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, getLocalNetworkGatewayResponse.Value.Data);
            putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Data.Location, getLocalNetworkGatewayResponse.Value.Id,
                getLocalNetworkGatewayResponse.Value.Data.Name, getLocalNetworkGatewayResponse.Value.Data.GatewayIpAddress,
                getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(newAddressPrefixes, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 4. ListLocalNetworkGateways API
            AsyncPageable<LocalNetworkGateway> listLocalNetworkGatewayResponseAP = localNetworkGatewayContainer.GetAllAsync();
            List<LocalNetworkGateway> listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Has.One.EqualTo(listLocalNetworkGatewayResponse);

            // 5A. DeleteLocalNetworkGateway API
            // TODO: restore to specific delete
            var deleteOperation = await getLocalNetworkGatewayResponse.Value.StartDeleteAsync();
            //var deleteOperation = await localNetworkGatewayContainer.Get(localNetworkGatewayName).Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
            listLocalNetworkGatewayResponseAP = localNetworkGatewayContainer.GetAllAsync();
            listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Assert.IsEmpty(listLocalNetworkGatewayResponse);
        }

        [Test]
        public async Task VirtualNetworkGatewayConnectionWithBgpTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/connections");
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create a local network gateway with BGP
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
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

            var localNetworkGatewayContainer = resourceGroup.Value.GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.Value.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName,  location,resourceGroup.Value.GetVirtualNetworks());
            Response<Subnet> getSubnetResponse = await resourceGroup.Value.GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = resourceGroup.Value.GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.BgpSettings);
            Assert.False(string.IsNullOrEmpty(getVirtualNetworkGatewayResponse.Value.Data.BgpSettings.BgpPeeringAddress), "The gateway's CA should be populated");

            // Create a virtual network gateway connection with BGP enabled
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc",
                EnableBgp = true
            };

            var virtualNetworkGatewayConnectionContainer = resourceGroup.Value.GetVirtualNetworkGatewayConnections();
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());
            Assert.True(putVirtualNetworkGatewayConnectionResponse.Value.Data.EnableBgp, "Enabling BGP for this connection must succeed");

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}, EnableBgp={12}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.Data.IngressBytesTransferred,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.EnableBgp);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType);
            Assert.True(getVirtualNetworkGatewayConnectionResponse.Value.Data.EnableBgp);

            // 4. ListVitualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TODO: use specific delete
            var deleteOperation = await getVirtualNetworkGatewayConnectionResponse.Value.StartDeleteAsync();
            //VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await virtualNetworkGatewayConnectionContainer.StartDeleteAsync(VirtualNetworkGatewayConnectionName);
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayContainer = resourceGroup.Value.GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.Value.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.Value.GetVirtualNetworks());
            Response<Subnet> getSubnetResponse = await resourceGroup.Value.GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = resourceGroup.Value.GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc",
                IpsecPolicies =
                {
                    new IpsecPolicy(300, 1024, IpsecEncryption.AES128, IpsecIntegrity.SHA256, IkeEncryption.AES192, IkeIntegrity.SHA1, DhGroup.DHGroup2, PfsGroup.PFS1)
                }
            };

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            var virtualNetworkGatewayConnectionContainer = resourceGroup.Value.GetVirtualNetworkGatewayConnections();
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType);
            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IpsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IpsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].SaLifeTimeSeconds);

            // 3A. UpdateVirtualNetworkGatewayConnection API : update ipsec policies and disable TS
            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = false;
            virtualNetworkGatewayConnection.IpsecPolicies.Clear();
            virtualNetworkGatewayConnection.IpsecPolicies.Add(new IpsecPolicy(600, 2048, IpsecEncryption.Gcmaes256, IpsecIntegrity.Gcmaes256, IkeEncryption.AES256, IkeIntegrity.SHA384, DhGroup.DHGroup2048, PfsGroup.ECP384));

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IpsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IpsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies[0].SaLifeTimeSeconds);

            // 4A. UpdateVirtualNetworkGatewayConnection API : remove ipsec policies
            (virtualNetworkGatewayConnection.IpsecPolicies as ChangeTrackingList<IpsecPolicy>).Reset();

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 4B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(0, getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count);

            // 4. ListVitualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TOOD
            //var deleteOperation = await virtualNetworkGatewayConnectionContainer.StartDeleteAsync(VirtualNetworkGatewayConnectionName);
            var deleteOperation = await putVirtualNetworkGatewayConnectionResponse.Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();
            ;

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayContainer = resourceGroup.Value.GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.Value.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.Value.GetVirtualNetworks());

            Response<Subnet> getSubnetResponse = await resourceGroup.Value.GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = resourceGroup.Value.GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Console.WriteLine("Default site :{0} set at Virtual network gateway.", getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Assert.AreEqual(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite.Id, getLocalNetworkGatewayResponse.Value.Id);

            // C. CreaetVirtualNetworkGatewayConnection API
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            var virtualNetworkGatewayConnectionContainer = resourceGroup.Value.GetVirtualNetworkGatewayConnections();
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.Data.IngressBytesTransferred);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType);
            Assert.AreEqual(3, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight);
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // 2A. Remove Default local network site
            getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite = null;
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.Null(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Console.WriteLine("Default site removal from Virtual network gateway is successful.", getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);

            // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
            // TODO: ADO 6005
            //await await virtualNetworkGatewayConnectionContainer.Get(VirtualNetworkGatewayConnectionName).Value.StartResetSharedKey(new ConnectionSharedKey("xyz")).WaitForCompletionAsync();;
            virtualNetworkGatewayConneciton.RoutingWeight = 4;

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionStatus,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.Value.Data.IngressBytesTransferred);
            Assert.AreEqual(4, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight);
            Assert.AreEqual("xyz", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // 4A. ListVirtualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
            List<VirtualNetworkGatewayConnection> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 4B. VirtualNetworkGateway ListConnections API
            // TODO: ADO 6030
            //AsyncPageable<VirtualNetworkGatewayConnectionListEntity> virtualNetworkGatewayListConnectionsResponseAP = virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.ListConnections();
            //List<VirtualNetworkGatewayConnectionListEntity> virtualNetworkGatewayListConnectionsResponse = await virtualNetworkGatewayListConnectionsResponseAP.ToEnumerableAsync();
            //Has.One.EqualTo(virtualNetworkGatewayListConnectionsResponse);
            //Assert.AreEqual(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayListConnectionsResponse.First().Name);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TODO: use specif delete ADO 5998
            //VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await virtualNetworkGatewayConnectionContainer.StartDeleteAsync(VirtualNetworkGatewayConnectionName);
            //var deleteOperation = await ArmClient.GetGenericResourceOperations(virtualNetworkGatewayListConnectionsResponse.First().ResourceGuid).StartDeleteAsync();
            //await deleteOperation.WaitForCompletionAsync();;

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionContainer.GetAllAsync();
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. SetVirtualNetworkGatewayConnectionSharedKey API
            // Pre-requsite:- CreateVirtualNetworkGatewayConnection first
            // Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // c. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);

            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";
            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);
            getLocalNetworkGatewayResponse.Value.Data.Location = location;

            // CreaetVirtualNetworkGatewayConnection API
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            var virtualNetworkGatewayConnectionContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(VirtualNetworkGatewayConnectionName);
            Assert.AreEqual("Succeeded", getVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // 2A. VirtualNetworkGatewayConnectionResetSharedKey API
            string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
            ConnectionResetSharedKey connectionResetSharedKey = new ConnectionResetSharedKey(50);
            VirtualNetworkGatewayConnectionsResetSharedKeyOperation resetConnectionResetSharedKeyResponseOperation = await getVirtualNetworkGatewayConnectionResponse.Value.StartResetSharedKeyAsync(connectionResetSharedKey.KeyLength);
            await resetConnectionResetSharedKeyResponseOperation.WaitForCompletionAsync();
            ;

            // 2B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
            Response<ConnectionSharedKey> getconnectionSharedKeyResponse = await getVirtualNetworkGatewayConnectionResponse.Value.GetSharedKeyAsync();
            Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            Assert.AreNotEqual("abc", getconnectionSharedKeyResponse.Value);

            // 3A.SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
            ConnectionSharedKey connectionSharedKey = new ConnectionSharedKey("TestSharedKeyValue");
            // TODO: ADO 6005
            //VirtualNetworkGatewayConnectionsSetSharedKeyOperation putConnectionSharedKeyResponseOperation = await getVirtualNetworkGatewayConnectionResponse.Value.StartSetSharedKeyAsync(connectionSharedKeyName, connectionSharedKey);
            //await putConnectionSharedKeyResponseOperation.WaitForCompletionAsync();;

            // 3B. GetVirtualNetworkGatewayConnectionSharedKey API
            getconnectionSharedKeyResponse = await getVirtualNetworkGatewayConnectionResponse.Value.GetSharedKeyAsync();
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create LocalNetworkGateway to set as default site
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace() { AddressPrefixes = { "192.168.0.0/16", } }
            };

            var localNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);

            // 1.CreateVirtualNetworkGateway API
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string addressPrefixes = "192.168.0.0/16";
            string newAddressPrefixes = "200.168.0.0/16";

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType, getVirtualNetworkGatewayResponse.Value.Data.VpnType,
                getVirtualNetworkGatewayResponse.Value.Data.Sku.Name, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.Data.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.Data.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(addressPrefixes), "P2S client Address Pool is not set on Gateway!");

            // 3.Update P2S VPNClient Address Pool
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration = new VpnClientConfiguration()
            {
                VpnClientAddressPool = new AddressSpace() { AddressPrefixes = { newAddressPrefixes } }
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(newAddressPrefixes), "P2S client Address Pool Update is Failed!");

            // 3.Add client Root certificate
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "ClientRootCertName";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "SamplePublicCertData";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(samplePublicCertData)
            {
                Name = clientRootCertName,
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Add(clientRootCert);

            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 4. Get client Root certificates
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Count() == 1 &&
                getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates[0].Name.Equals(clientRootCertName), "Vpn client Root certificate upload was Failed!");

            // 5.Generate P2S Vpnclient package
            VpnClientParameters vpnClientParameters = new VpnClientParameters()
            {
                ProcessorArchitecture = ProcessorArchitecture.Amd64
            };
            VirtualNetworkGatewaysGeneratevpnclientpackageOperation packageUrlOperation = await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.StartGeneratevpnclientpackageAsync(vpnClientParameters);
            await packageUrlOperation.WaitForCompletionAsync();
            ;
            //Assert.NotNull(packageUrl);
            //Assert.NotEmpty(packageUrl);
            //Console.WriteLine("Vpn client package Url = {0}", packageUrl);

            // 6.Delete client Root certificate
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Count() == 0);

            // 7. Get Vpn client revoked certificates
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);

            // 8. Try to revoke Vpn client certificate which is not there and verify proper error comes back
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string sampleCertThumpprint = "SampleCertThumbprint";//this._testEnvironment.ConnectionString.KeyValue.DataPairs[TestEnvironmentSettings.SampleCertThumbprint.ToString()];
            VpnClientRevokedCertificate sampleClientCert = new VpnClientRevokedCertificate()
            {
                Name = "sampleClientCert.cer",
                Thumbprint = sampleCertThumpprint
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Add(sampleClientCert);

            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 1);
            Assert.AreEqual("sampleClientCert.cer", getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates[0].Name);

            // 9. Unrevoke previously revoked Vpn client certificate
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);
        }

        // Tests Resource:-VirtualNetworkGateway ActiveActive Feature Test:-
        [Test]
        [Ignore("Track2: The current operation failed due to an intermittent error with gateway 'azsmnet123'. Please try again")]
        public async Task VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. Create Active-Active VirtualNetworkGateway
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName1 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel1 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp1 = await CreateDefaultPublicIpAddress(publicIpName1, resourceGroupName, domainNameLabel1, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp1.Id);

            string publicIpName2 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel2 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp2 = await CreateDefaultPublicIpAddress(publicIpName2, resourceGroupName, domainNameLabel2, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp2.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API

            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetwork virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6} ActiveActive enabled-{7}",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType, getVirtualNetworkGatewayResponse.Value.Data.VpnType,
                getVirtualNetworkGatewayResponse.Value.Data.Sku.Name, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier,
                getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.Data.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.Data.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.HighPerformance, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.Count);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.Active);

            // 3. Update ActiveActive VirtualNetworkGateway to ActiveStandby
            getVirtualNetworkGatewayResponse.Value.Data.Active = false;
            getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.Remove(getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.First(config => config.Name.Equals(ipconfig2.Name)));
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.False(getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(1, getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.Count);

            // 4. Update ActiveStandby VirtualNetworkGateway to ActiveActive again
            getVirtualNetworkGatewayResponse.Value.Data.Active = true;
            getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.Add(ipconfig2);
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.Data.IpConfigurations.Count);
        }

        [Test]
        [Ignore("Track2: Occasionally succeed in online")]
        public async Task VirtualNetworkGatewayBgpRouteApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

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
            var vnet1 = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = { "10.1.0.0/16" } },
                Subnets = { new SubnetData() { Name = gatewaySubnetName, AddressPrefix = "10.1.1.0/24" } }
            };
            PublicIPAddress publicIPAddress = await CreateDefaultPublicIpAddress(gw1IpName, resourceGroupName, gw1IpDomainNameLabel, location);
            var virtualNetworkContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworks();
            VirtualNetworksCreateOrUpdateOperation virtualNetworksCreateOrUpdateOperation = await virtualNetworkContainer.StartCreateOrUpdateAsync(vnet1Name, vnet1);
            Response<VirtualNetwork> vnet1Response = await virtualNetworksCreateOrUpdateOperation.WaitForCompletionAsync();
            ;
            Response<Subnet> gw1Subnet = await virtualNetworkContainer.Get(vnet1Name).Value.GetSubnets().GetAsync(gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw1IpConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = publicIPAddress.Id },
                Subnet = new SubResource() { Id = gw1Subnet.Value.Id }
            };
            var gw1 = new VirtualNetworkGatewayData()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations = { ipconfig1 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 1337, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            PublicIPAddress gw2Ip = await CreateDefaultPublicIpAddress(gw2IpName, resourceGroupName, gw2IpDomainNameLabel, location);
            var vnet2 = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = { "10.2.0.0/16" } },
                Subnets = { new SubnetData() { Name = gatewaySubnetName, AddressPrefix = "10.2.1.0/24", } }
            };
            VirtualNetworksCreateOrUpdateOperation vnet2Operation = await virtualNetworkContainer.StartCreateOrUpdateAsync(vnet2Name, vnet2);
            VirtualNetwork vnet2Response = await vnet2Operation.WaitForCompletionAsync();
            ;
            Response<Subnet> gw2Subnet = await virtualNetworkContainer.Get(vnet2Name).Value.GetSubnets().GetAsync(gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw2IpConfigName,
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                PublicIPAddress = new SubResource() { Id = gw2Ip.Id },
                Subnet = new SubResource() { Id = gw2Subnet.Value.Id }
            };
            var gw2 = new VirtualNetworkGatewayData()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IpConfigurations = { ipconfig2 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 9001, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            List<Task> gatewayDeploymentTasks = new List<Task>
            {
                await Task.Factory.StartNew(async () =>
                {
                    VirtualNetworkGatewaysCreateOrUpdateOperation virtualNetworkGatewaysOperation = await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(gw1Name, gw1);
                    await virtualNetworkGatewaysOperation.WaitForCompletionAsync();;
                }),

                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewaysCreateOrUpdateOperation virtualNetworkGatewaysOperation= await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(gw2Name, gw2);
                    await virtualNetworkGatewaysOperation.WaitForCompletionAsync();;
                })
            };

            Task.WaitAll(gatewayDeploymentTasks.ToArray());

            // Create a vnet to vnet connection between the two gateways
            // configure both gateways in parallel
            Response<VirtualNetworkGateway> gw1GetResponse = await virtualNetworkGatewayContainer.GetAsync(gw1Name);
            Response<VirtualNetworkGateway> gw2GetResponse = await virtualNetworkGatewayContainer.GetAsync(gw2Name);
            Response<PublicIPAddress> gw2IpResponse = await GetResourceGroup(resourceGroupName).GetPublicIPAddresses().GetAsync(gw1IpName);
            string sharedKey = "chocolate";

            string conn1Name = Recording.GenerateAssetName("azsmnet");
            var gw1ToGw2Conn = new VirtualNetworkGatewayConnectionData(gw1GetResponse.Value.Data, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location,
                VirtualNetworkGateway2 = gw2GetResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = sharedKey,
                EnableBgp = true
            };

            string conn2Name = Recording.GenerateAssetName("azsmnet");
            var gw2ToGw1Conn = new VirtualNetworkGatewayConnectionData(gw2GetResponse.Value.Data, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location,
                VirtualNetworkGateway2 = gw1GetResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = sharedKey,
                EnableBgp = true
            };

            var virtualNetworkGatewayConnectionContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            List<Task> gatewayConnectionTasks = new List<Task>
            {
                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewayConnectionsCreateOrUpdateOperation VirtualNetworkGatewayConnectionsCreateOrUpdateOperation = await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(conn1Name, gw1ToGw2Conn);
                    await VirtualNetworkGatewayConnectionsCreateOrUpdateOperation.WaitForCompletionAsync();;
                }),
                await Task.Factory.StartNew(async() =>
                {
                    VirtualNetworkGatewayConnectionsCreateOrUpdateOperation VirtualNetworkGatewayConnectionsCreateOrUpdateOperation =  await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(conn2Name, gw2ToGw1Conn);
                    await VirtualNetworkGatewayConnectionsCreateOrUpdateOperation.WaitForCompletionAsync();;
                })
            };

            Task.WaitAll(gatewayConnectionTasks.ToArray());

            // get bgp info from gw1
            VirtualNetworkGatewaysGetLearnedRoutesOperation learnedRoutesOperation = await virtualNetworkGatewayContainer.Get(gw1Name).Value.StartGetLearnedRoutesAsync();
            Response<GatewayRouteListResult> learnedRoutes = await learnedRoutesOperation.WaitForCompletionAsync();
            ;
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be learned from gw2");
            VirtualNetworkGatewaysGetAdvertisedRoutesOperation advertisedRoutesOperation = await virtualNetworkGatewayContainer.Get(gw1Name).Value.StartGetAdvertisedRoutesAsync(gw2IpResponse.Value.Data.IpAddress);
            Response<GatewayRouteListResult> advertisedRoutes = await advertisedRoutesOperation.WaitForCompletionAsync();
            ;
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be advertised to gw2");
            VirtualNetworkGatewaysGetBgpPeerStatusOperation gw1PeersOperation = await virtualNetworkGatewayContainer.Get(gw1Name).Value.StartGetBgpPeerStatusAsync();
            Response<BgpPeerStatusListResult> gw1Peers = await gw1PeersOperation.WaitForCompletionAsync();
            ;
            Assert.True(gw1Peers.Value.Value.Count() > 0, "At least one peer should be connected");
        }

        [Test]
        [Ignore("Track2: Missing the value of a special environment variable, which is currently uncertain")]
        public async Task VirtualNetworkGatewayGenerateVpnProfileTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/virtualnetworkgateways");
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1.CreateVirtualNetworkGateway
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");
            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName,
                domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetwork virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string addressPrefixes = "192.168.0.0/16";
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "0";// this._testEnvironment.ConnectionString.KeyValue.DataPairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "1";// this._testEnvironment.ConnectionString.KeyValue.DataPairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(samplePublicCertData) { Name = clientRootCertName };
            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse =
               await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);
            Console.WriteLine(
                "Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType, getVirtualNetworkGatewayResponse.Value.Data.VpnType,
                getVirtualNetworkGatewayResponse.Value.Data.Sku.Name, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.Data.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.Data.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.VpnGw2, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
                            .Count == 1 &&
                        getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool
                            .AddressPrefixes[0].Equals(addressPrefixes),
                "P2S client Address Pool is not set on Gateway!");

            // Update P2S VPNClient Address Pool and add radius settings
            string newAddressPrefixes = "200.168.0.0/16";
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration = new VpnClientConfiguration()
            {
                VpnClientAddressPool = new AddressSpace()
                {
                    AddressPrefixes = { newAddressPrefixes }
                },
                RadiusServerAddress = @"8.8.8.8",
                RadiusServerSecret = @"TestRadiusSecret",
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 5.Generate P2S Vpnclient package
            VpnClientParameters vpnClientParameters = new VpnClientParameters()
            {
                RadiusServerAuthCertificate = samplePublicCertData,
                AuthenticationMethod = AuthenticationMethod.Eaptls
            };

            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrl = ""; // await virtualNetworkGatewayContainer.GenerateGatewayVpnProfile(resourceGroupName,virtualNetworkGatewayName, vpnClientParameters);

            Assert.NotNull(packageUrl);
            Assert.IsNotEmpty(packageUrl);
            Console.WriteLine("Vpn client package Url from GENERATE operation = {0}", packageUrl);

            // Retry to get the package url using the get profile API
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrlFromGetOperation = "";// virtualNetworkGatewayContainer.GetGatewayVpnProfile(virtualNetworkGatewayName);
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
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // CreateVirtualNetworkGatewayConnection API
            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIpAddress = gatewayIp,
                LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            LocalNetworkGatewaysCreateOrUpdateOperation putLocalNetworkGatewayResponseOperation = await localNetworkGatewayContainer.StartCreateOrUpdateAsync(localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGateway> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGateway> getLocalNetworkGatewayResponse = await localNetworkGatewayContainer.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetwork API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<Subnet> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
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

            var virtualNetworkGatewayContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            VirtualNetworkGatewaysCreateOrUpdateOperation putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGateway> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGateway> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayContainer.GetAsync(virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
            string virtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            virtualNetworkGatewayConnection.IpsecPolicies.Add(
                    new IpsecPolicy(300, 1024, IpsecEncryption.AES128, IpsecIntegrity.SHA256, IkeEncryption.AES192, IkeIntegrity.SHA1, DhGroup.DHGroup2, PfsGroup.PFS1)
                );

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            var virtualNetworkGatewayConnectionContainer = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            VirtualNetworkGatewayConnectionsCreateOrUpdateOperation putVirtualNetworkGatewayConnectionResponseOperation =
                await virtualNetworkGatewayConnectionContainer.StartCreateOrUpdateAsync(virtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnection> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            ;
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnection> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionContainer.GetAsync(virtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                              "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            // List supported Vpn Devices
            Response<string> supportedVpnDevices = await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayName).Value.SupportedVpnDevicesAsync();
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
                await virtualNetworkGatewayContainer.Get(virtualNetworkGatewayConnectionName).Value.VpnDeviceConfigurationScriptAsync(scriptParams);

            Assert.NotNull(vpnDeviceConfiguration);
            Assert.IsNotEmpty(vpnDeviceConfiguration);
        }
    }
}
