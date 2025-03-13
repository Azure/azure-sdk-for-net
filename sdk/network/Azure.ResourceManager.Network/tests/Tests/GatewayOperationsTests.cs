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

namespace Azure.ResourceManager.Network.Tests
{
    public class GatewayOperationsTests : NetworkServiceClientTestBase
    {
        private SubscriptionResource _subscription;
        public GatewayOperationsTests(bool isAsync) : base(isAsync)
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

        private enum TestEnvironmentSettings
        {
            ClientRootCertName,
            SamplePublicCertData,
            SampleCertThumbprint
        }

        [Test]
        [RecordedTest]
        public async Task VnetGatewayBaseTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");
            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());
            Response<SubnetResource> getSubnetResponse = await (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetSubnets().GetAsync(subnetName);
            Assert.IsNotNull(getSubnetResponse.Value.Data);

            // Create PublicIpAddress
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Assert.IsNotNull(nic1publicIp.Data);

            // Create VirtualNetworkGateway
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGateway = new VirtualNetworkGatewayData()
            {
                Location = location,
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Basic,
                    Tier = VirtualNetworkGatewaySkuTier.Basic
                },
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection = resourceGroup.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data);
            Assert.AreEqual(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data.Name);
            Assert.AreEqual(1, putVirtualNetworkGatewayResponse.Value.Data.Tags.Count);

            // Update
            virtualNetworkGateway.Tags.Add(new KeyValuePair<string, string>("tag2", "value"));
            virtualNetworkGateway.Tags.Add(new KeyValuePair<string, string>("tag3", "value"));
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual(3, putVirtualNetworkGatewayResponse.Value.Data.Tags.Count);

            // Delete VirtualNetworkGateway
            await getVirtualNetworkGatewayResponse.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task VnetGatewayConnectionSiteToSiteTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");
            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());
            Response<SubnetResource> getSubnetResponse = await (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetSubnets().GetAsync(subnetName);
            Assert.IsNotNull(getSubnetResponse.Value.Data);

            // Create LocalNetworkGateway
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayCollection = resourceGroup.GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // Create PublicIpAddress
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Assert.IsNotNull(nic1publicIp.Data);

            // Create VirtualNetworkGateway
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGateway = new VirtualNetworkGatewayData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = new WritableSubResource()
                {
                    Id = getLocalNetworkGatewayResponse.Value.Id
                },
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection = resourceGroup.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data);
            Assert.AreEqual(virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data.Name);
            Assert.AreEqual(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite.Id, getLocalNetworkGatewayResponse.Value.Id.ToString());

            // Test: site-to-site connection
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            var virtualNetworkGatewayConnectionCollection = resourceGroup.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType);
            Assert.AreEqual(3, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight);
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // Remove Default local network site
            getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite = null;
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.Null(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);

            // Update SharedKeyAsync
            //await virtualNetworkGatewayConnectionCollection.Get(VirtualNetworkGatewayConnectionName).Value.SetSharedKeyAsync(new ConnectionSharedKey("xyz"));
            //Assert.AreEqual("xyz", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // Update RoutingWeight
            virtualNetworkGatewayConneciton.RoutingWeight = 4;
            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Assert.AreEqual(4, getVirtualNetworkGatewayConnectionResponse.Value.Data.RoutingWeight);

            // Verify VirtualNetworkGatewayResource Connections.
            AsyncPageable<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            List<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);
            Assert.AreEqual(VirtualNetworkGatewayConnectionName, listVirtualNetworkGatewayConectionResponse[0].Data.Name);

            // delete VirtualNetworkGatewayConnection
            // TODO: use specif delete ADO 5998
            //VirtualNetworkGatewayConnectionDeleteOperation deleteOperation = await virtualNetworkGatewayConnectionCollection.StartDeleteAsync(VirtualNetworkGatewayConnectionName);
            //var deleteOperation = await ArmClient.GetGenericResourceOperations(virtualNetworkGatewayListConnectionsResponse.First().ResourceGuid).StartDeleteAsync(true);
            //await deleteOperation.WaitForCompletionAsync();

            //listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            //listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            //Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        [Test]
        [RecordedTest]
        public async Task VnetGatewayConnectionVnetToVnetTest()
        {
            // 1.Create first Virtual Network Gateway.
            string location1 = "eastus";
            string resourceGroupName1 = Recording.GenerateAssetName("csmrg");
            var resourceGroup1 = await CreateResourceGroup(resourceGroupName1, location1);

            // Create Vnet
            string vnetName1 = Recording.GenerateAssetName("azsmnet");
            string subnetName1 = "GatewaySubnet";
            var vnetData1 = new VirtualNetworkData()
            {
                Location = location1,
                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.54.0.0/16", }
                },
                Subnets = { new SubnetData() { Name = subnetName1, AddressPrefix = "10.54.0.0/24" } }
            };
            var virtualNetworkCollection = resourceGroup1.GetVirtualNetworks();
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName1, vnetData1);
            Response<SubnetResource> getSubnetResponse1 = await (await resourceGroup1.GetVirtualNetworks().GetAsync(vnetName1)).Value.GetSubnets().GetAsync(subnetName1);

            // Create PublicIpAddress
            string publicIpName1 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel1 = Recording.GenerateAssetName("azsmnet");
            PublicIPAddressResource nic1publicIp1 = await CreateDefaultPublicIpAddress(publicIpName1, domainNameLabel1, location1, resourceGroup1.GetPublicIPAddresses());

            // Create VirtualNetworkGateway
            string virtualNetworkGatewayName1 = Recording.GenerateAssetName("azsmnet");
            string ipConfigName1 = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGateway1 = new VirtualNetworkGatewayData()
            {
                Location = location1,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName1,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp1.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse1.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection1 = resourceGroup1.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation1 = await virtualNetworkGatewayCollection1.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName1, virtualNetworkGateway1);
            await putVirtualNetworkGatewayResponseOperation1.WaitForCompletionAsync();

            // 2.Create second Virtual Network Gateway.
            string location2 = "westus2";
            string resourceGroupName2 = Recording.GenerateAssetName("csmrg");
            var resourceGroup2 = await CreateResourceGroup(resourceGroupName2, location2);

            // Create Vnet
            string vnetName2 = Recording.GenerateAssetName("azsmnet");
            string subnetName2 = "GatewaySubnet";
            var vnetData2 = new VirtualNetworkData()
            {
                Location = location2,
                AddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "10.55.0.0/16", }
                },
                Subnets = { new SubnetData() { Name = subnetName2, AddressPrefix = "10.55.0.0/24", } }
            };
            var virtualNetworkCollection2 = resourceGroup2.GetVirtualNetworks();
            var putVnetResponseOperation2 = await virtualNetworkCollection2.CreateOrUpdateAsync(WaitUntil.Completed, vnetName2, vnetData2);
            Response<SubnetResource> getSubnetResponse2 = await (await resourceGroup2.GetVirtualNetworks().GetAsync(vnetName2)).Value.GetSubnets().GetAsync(subnetName2);

            // Create PublicIpAddress
            string publicIpName2 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel2 = Recording.GenerateAssetName("azsmnet");
            PublicIPAddressResource nic2publicIp2 = await CreateDefaultPublicIpAddress(publicIpName2, domainNameLabel2, location2, resourceGroup2.GetPublicIPAddresses());

            // Create VirtualNetworkGateway
            string virtualNetworkGatewayName2 = Recording.GenerateAssetName("azsmnet");
            string ipConfigName2 = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGateway2 = new VirtualNetworkGatewayData()
            {
                Location = location2,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName2,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic2publicIp2.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse2.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection2 = resourceGroup2.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation2 = await virtualNetworkGatewayCollection2.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName2, virtualNetworkGateway2);
            await putVirtualNetworkGatewayResponseOperation2.WaitForCompletionAsync();

            // 3.Test: Vnet-to-Vnet Connections
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGateway1 = await virtualNetworkGatewayCollection1.GetAsync(virtualNetworkGatewayName1);
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGateway2 = await virtualNetworkGatewayCollection2.GetAsync(virtualNetworkGatewayName2);

            string ConnectionName1 = Recording.GenerateAssetName("V1toV2");
            var virtualNetworkGatewayConneciton1 = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGateway1.Value.Data, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location1,
                RoutingWeight = 3,
                VirtualNetworkGateway1 = getVirtualNetworkGateway1.Value.Data,
                VirtualNetworkGateway2 = getVirtualNetworkGateway2.Value.Data,
                SharedKey = "abc123"
            };

            var virtualNetworkGatewayConnectionCollection1 = resourceGroup1.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation1 = await virtualNetworkGatewayConnectionCollection1.CreateOrUpdateAsync(WaitUntil.Completed, ConnectionName1, virtualNetworkGatewayConneciton1);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse1 = await putVirtualNetworkGatewayConnectionResponseOperation1.WaitForCompletionAsync();
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse1 = await virtualNetworkGatewayConnectionCollection1.GetAsync(ConnectionName1);
            Assert.AreEqual(ConnectionName1, getVirtualNetworkGatewayConnectionResponse1.Value.Data.Name);
            Assert.AreEqual("Vnet2Vnet", getVirtualNetworkGatewayConnectionResponse1.Value.Data.ConnectionType.ToString());
            Assert.AreEqual("abc123", getVirtualNetworkGatewayConnectionResponse1.Value.Data.SharedKey);
            Assert.AreEqual(getVirtualNetworkGateway2.Value.Id.ToString(), getVirtualNetworkGatewayConnectionResponse1.Value.Data.VirtualNetworkGateway2.Id.ToString());

            string ConnectionName2 = Recording.GenerateAssetName("V2toV1");
            var virtualNetworkGatewayConneciton2 = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGateway2.Value.Data, VirtualNetworkGatewayConnectionType.Vnet2Vnet)
            {
                Location = location2,
                RoutingWeight = 3,
                VirtualNetworkGateway1 = getVirtualNetworkGateway2.Value.Data,
                VirtualNetworkGateway2 = getVirtualNetworkGateway1.Value.Data,
                SharedKey = "abc123"
            };

            var virtualNetworkGatewayConnectionCollection2 = resourceGroup2.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation2 = await virtualNetworkGatewayConnectionCollection2.CreateOrUpdateAsync(WaitUntil.Completed, ConnectionName2, virtualNetworkGatewayConneciton2);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse2 = await putVirtualNetworkGatewayConnectionResponseOperation2.WaitForCompletionAsync();
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse2 = await virtualNetworkGatewayConnectionCollection2.GetAsync(ConnectionName2);
            Assert.AreEqual(ConnectionName2, getVirtualNetworkGatewayConnectionResponse2.Value.Data.Name);
            Assert.AreEqual("Vnet2Vnet", getVirtualNetworkGatewayConnectionResponse2.Value.Data.ConnectionType.ToString());
            Assert.AreEqual("abc123", getVirtualNetworkGatewayConnectionResponse2.Value.Data.SharedKey);
            Assert.AreEqual(getVirtualNetworkGateway1.Value.Id.ToString(), getVirtualNetworkGatewayConnectionResponse2.Value.Data.VirtualNetworkGateway2.Id.ToString());
        }

        // Tests Resource:-VirtualNetworkGatewayResource 6 APIs:-
        [Test]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGateway API
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
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

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
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
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.Standard, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);

            // 4A. ResetVirtualNetworkGateway API
            var resetVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayName).Value.ResetAsync(WaitUntil.Completed);
            await resetVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();

            // 4B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);

            Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType);

            // 5. ListVitualNetworkGateways API
            AsyncPageable<VirtualNetworkGatewayResource> listVirtualNetworkGatewayResponseAP = virtualNetworkGatewayCollection.GetAllAsync();
            List<VirtualNetworkGatewayResource> listVirtualNetworkGatewayResponse = await listVirtualNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count);
            Has.One.EqualTo(listVirtualNetworkGatewayResponse);

            // 6A. DeleteVirtualNetworkGateway API
            // TODO: restore to specific type
            //VirtualNetworkGatewaysDeleteOperation deleteOperation = await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayName).Value.DeleteAsync(true);
            var deleteOperation = await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayName).Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();

            // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
            listVirtualNetworkGatewayResponseAP = virtualNetworkGatewayCollection.GetAllAsync();
            listVirtualNetworkGatewayResponse = await listVirtualNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayResponse);
        }

        // Tests Resource:-LocalNetworkGatewayResource 5 APIs:-
        [Test]
        [RecordedTest]
        public async Task LocalNettworkGatewayOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
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
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { addressPrefixes, }
                }
            };

            var localNetworkGatewayCollection = resourceGroup.GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetLocalNetworkGateway API
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIPAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Data.Location,
                getLocalNetworkGatewayResponse.Value.Id, getLocalNetworkGatewayResponse.Value.Data.Name,
                getLocalNetworkGatewayResponse.Value.Data.GatewayIPAddress, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(gatewayIp, getLocalNetworkGatewayResponse.Value.Data.GatewayIPAddress);
            Assert.AreEqual(addressPrefixes, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 3A. UpdateLocalNetworkgateway API :- LocalNetworkGatewayResource LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { newAddressPrefixes, } };

            putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, getLocalNetworkGatewayResponse.Value.Data);
            putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGatewayResource LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
            getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);
            Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIPAddress={3} LocalNetworkAddressSpace={4}",
                getLocalNetworkGatewayResponse.Value.Data.Location, getLocalNetworkGatewayResponse.Value.Id,
                getLocalNetworkGatewayResponse.Value.Data.Name, getLocalNetworkGatewayResponse.Value.Data.GatewayIPAddress,
                getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
            Assert.AreEqual(newAddressPrefixes, getLocalNetworkGatewayResponse.Value.Data.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

            // 4. ListLocalNetworkGateways API
            AsyncPageable<LocalNetworkGatewayResource> listLocalNetworkGatewayResponseAP = localNetworkGatewayCollection.GetAllAsync();
            List<LocalNetworkGatewayResource> listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Has.One.EqualTo(listLocalNetworkGatewayResponse);

            // 5A. DeleteLocalNetworkGateway API
            // TODO: restore to specific delete
            var deleteOperation = await getLocalNetworkGatewayResponse.Value.DeleteAsync(WaitUntil.Completed);
            //var deleteOperation = await localNetworkGatewayCollection.Get(localNetworkGatewayName).Value.DeleteAsync(true);
            await deleteOperation.WaitForCompletionResponseAsync();

            // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
            listLocalNetworkGatewayResponseAP = localNetworkGatewayCollection.GetAllAsync();
            listLocalNetworkGatewayResponse = await listLocalNetworkGatewayResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
            Assert.IsEmpty(listLocalNetworkGatewayResponse);
        }

        [Test]
        [RecordedTest]
        public async Task VirtualNetworkGatewayConnectionWithBgpTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            AzureLocation location = AzureLocation.WestUS;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create a local network gateway with BGP
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
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

            var localNetworkGatewayCollection = resourceGroup.GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());
            Response<SubnetResource> getSubnetResponse = await (await resourceGroup.GetVirtualNetworks().GetAsync(vnetName)).Value.GetSubnets().GetAsync(subnetName);
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
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
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

            var virtualNetworkGatewayCollection = resourceGroup.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
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

            var virtualNetworkGatewayConnectionCollection = resourceGroup.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());
            Assert.True(putVirtualNetworkGatewayConnectionResponse.Value.Data.EnableBgp, "Enabling BGP for this connection must succeed");

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
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
            AsyncPageable<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            List<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TODO: use specific delete
            var deleteOperation = await getVirtualNetworkGatewayConnectionResponse.Value.DeleteAsync(WaitUntil.Completed);
            //VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await virtualNetworkGatewayConnectionCollection.DeleteAsync(VirtualNetworkGatewayConnectionName);
            await deleteOperation.WaitForCompletionResponseAsync();

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionResource with IPsec Policies
        [Test]
        [RecordedTest]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayConnectionWithIPsecPoliciesTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayCollection = resourceGroup.GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());
            Response<SubnetResource> getSubnetResponse = await resourceGroup.GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
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

            var virtualNetworkGatewayCollection = resourceGroup.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - IPsec policy and policybased TS enabled
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc",
                IPsecPolicies =
                {
                    new IPsecPolicy(300, 1024, IPsecEncryption.Aes128, IPsecIntegrity.Sha256, IkeEncryption.Aes192, IkeIntegrity.Sha1, DHGroup.DHGroup2, PfsGroup.Pfs1)
                }
            };

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            var virtualNetworkGatewayConnectionCollection = resourceGroup.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IPsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.Value.Data.ConnectionType);
            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IPsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IPsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IPsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IPsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].SaLifeTimeSeconds);

            // 3A. UpdateVirtualNetworkGatewayConnection API : update IPsec policies and disable TS
            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = false;
            virtualNetworkGatewayConnection.IPsecPolicies.Clear();
            virtualNetworkGatewayConnection.IPsecPolicies.Add(new IPsecPolicy(600, 2048, IPsecEncryption.GcmAes256, IPsecIntegrity.GcmAes256, IkeEncryption.Aes256, IkeIntegrity.Sha384, DHGroup.DHGroup2048, PfsGroup.Ecp384));

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IPsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IPsecEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IPsecEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IPsecIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IPsecIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IkeEncryption);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].IkeIntegrity);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].DhGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].PfsGroup);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].SaDataSizeKilobytes);
            Assert.AreEqual(virtualNetworkGatewayConnection.IPsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies[0].SaLifeTimeSeconds);

            // 4A. UpdateVirtualNetworkGatewayConnection API : remove IPsec policies
            (virtualNetworkGatewayConnection.IPsecPolicies as ChangeTrackingList<IPsecPolicy>).Reset();

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 4B. GetVirtualNetworkGatewayConnection API after Updating
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                "IPsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            Assert.AreEqual(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);
            Assert.AreEqual(0, getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count);

            // 4. ListVitualNetworkGatewayConnections API
            AsyncPageable<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            List<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TOOD
            //var deleteOperation = await virtualNetworkGatewayConnectionCollection.DeleteAsync(VirtualNetworkGatewayConnectionName);
            var deleteOperation = await putVirtualNetworkGatewayConnectionResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionResource 5 APIs & Set-Remove default site
        [Test]
        [RecordedTest]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. CreateVirtualNetworkGatewayConnection API
            //A. Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayCollection = resourceGroup.GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, location, resourceGroup.GetVirtualNetworks());

            Response<SubnetResource> getSubnetResponse = await resourceGroup.GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var virtualNetworkGateway = new VirtualNetworkGatewayData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayDefaultSite = new WritableSubResource()
                {
                    Id = getLocalNetworkGatewayResponse.Value.Id
                },
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection = resourceGroup.GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Console.WriteLine("Default site :{0} set at Virtual network gateway.", getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Assert.AreEqual(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite.Id, getLocalNetworkGatewayResponse.Value.Id.ToString());

            // C. CreaetVirtualNetworkGatewayConnection API
            string VirtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            var virtualNetworkGatewayConnectionCollection = resourceGroup.GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
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
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.Null(getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);
            Console.WriteLine("Default site removal from Virtual network gateway is successful.", getVirtualNetworkGatewayResponse.Value.Data.GatewayDefaultSite);

            // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey length => 64
            await getVirtualNetworkGatewayConnectionResponse.Value.ResetSharedKey(WaitUntil.Completed, new ConnectionResetSharedKey(64)).WaitForCompletionAsync();
            virtualNetworkGatewayConneciton.RoutingWeight = 4;

            putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
            getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
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
            AsyncPageable<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            List<VirtualNetworkGatewayConnectionResource> listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Has.One.EqualTo(listVirtualNetworkGatewayConectionResponse);

            // 4B. VirtualNetworkGatewayResource ListConnections API
            var connections = await putVirtualNetworkGatewayResponse.Value.GetConnectionsAsync().ToEnumerableAsync();
            Has.One.EqualTo(connections);
            Assert.AreEqual(VirtualNetworkGatewayConnectionName, connections.First().Name);

            // 5A. DeleteVirtualNetworkGatewayConnection API
            // TODO: use specif delete ADO 5998
            //VirtualNetworkGatewayConnectionsDeleteOperation deleteOperation = await virtualNetworkGatewayConnectionCollection.DeleteAsync(VirtualNetworkGatewayConnectionName);
            //var deleteOperation = await ArmClient.GetGenericResourceOperations(virtualNetworkGatewayListConnectionsResponse.First().ResourceGuid).DeleteAsync(true);
            //await deleteOperation.WaitForCompletionAsync();;

            // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
            listVirtualNetworkGatewayConectionResponseAP = virtualNetworkGatewayConnectionCollection.GetAllAsync();
            listVirtualNetworkGatewayConectionResponse = await listVirtualNetworkGatewayConectionResponseAP.ToEnumerableAsync();
            Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
            Assert.IsEmpty(listVirtualNetworkGatewayConectionResponse);
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Test]
        [RecordedTest]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. SetVirtualNetworkGatewayConnectionSharedKey API
            // Pre-requsite:- CreateVirtualNetworkGatewayConnection first
            // Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource()
                        {
                            Id = nic1publicIp.Id
                        },
                        Subnet = new WritableSubResource()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);

            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";
            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);
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

            var virtualNetworkGatewayConnectionCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(VirtualNetworkGatewayConnectionName);
            Assert.AreEqual("Succeeded", getVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());
            Assert.AreEqual("abc", getVirtualNetworkGatewayConnectionResponse.Value.Data.SharedKey);

            // 2A. VirtualNetworkGatewayConnectionResetSharedKey API
            string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
            ConnectionResetSharedKey connectionResetSharedKey = new ConnectionResetSharedKey(50);
            var resetConnectionResetSharedKeyResponseOperation = await getVirtualNetworkGatewayConnectionResponse.Value.ResetSharedKeyAsync(WaitUntil.Completed, new ConnectionResetSharedKey(connectionResetSharedKey.KeyLength));
            await resetConnectionResetSharedKeyResponseOperation.WaitForCompletionAsync();

            // 2B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
            Response<ConnectionSharedKey> getconnectionSharedKeyResponse = await getVirtualNetworkGatewayConnectionResponse.Value.GetSharedKeyAsync();
            Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            Assert.AreNotEqual("abc", getconnectionSharedKeyResponse.Value);

            // 3A.SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
            ConnectionSharedKey connectionSharedKey = new ConnectionSharedKey("TestSharedKeyValue");
            var setSharedKeyOperation = await getVirtualNetworkGatewayConnectionResponse.Value.SetSharedKeyAsync(WaitUntil.Completed, connectionSharedKey);
            await setSharedKeyOperation.WaitForCompletionAsync();
            ;

            // 3B. GetVirtualNetworkGatewayConnectionSharedKey API
            getconnectionSharedKeyResponse = await getVirtualNetworkGatewayConnectionResponse.Value.GetSharedKeyAsync();
            Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            Assert.AreEqual("TestSharedKeyValue", getconnectionSharedKeyResponse.Value.Value.ToString());
        }

        // Tests Resource:-VirtualNetworkGatewayResource P2S APIs:-
        [Test]
        [RecordedTest]
        [Ignore("Track2: Missing the value of a special environment variable, which is currently uncertain")]
        public async Task VirtualNetworkGatewayP2SOperationsApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create LocalNetworkGatewayResource to set as default site
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "192.168.0.0/16", } }
            };

            var localNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // 1.CreateVirtualNetworkGateway API
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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
                GatewayDefaultSite = new WritableSubResource() { Id = getLocalNetworkGatewayResponse.Value.Id },
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource() { Id = nic1publicIp.Id },
                        Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new VirtualNetworkAddressSpace() { AddressPrefixes = { addressPrefixes } }
                }
            };

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
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
                VpnClientAddressPool = new VirtualNetworkAddressSpace() { AddressPrefixes = { newAddressPrefixes } }
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(newAddressPrefixes), "P2S client Address Pool Update is Failed!");

            // 3.Add client Root certificate
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "ClientRootCertName";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "SamplePublicCertData";// this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(BinaryData.FromString(samplePublicCertData))
            {
                Name = clientRootCertName,
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Add(clientRootCert);

            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 4. Get client Root certificates
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.NotNull(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Count() == 1 &&
                getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates[0].Name.Equals(clientRootCertName), "Vpn client Root certificate upload was Failed!");

            // 5.Generate P2S Vpnclient package
            VpnClientContent content = new VpnClientContent()
            {
                ProcessorArchitecture = ProcessorArchitecture.Amd64
            };
            var packageUrlOperation = await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayName).Value.GenerateVpnClientPackageAsync(WaitUntil.Completed, content);
            await packageUrlOperation.WaitForCompletionAsync();
            //Assert.NotNull(packageUrl);
            //Assert.NotEmpty(packageUrl);
            //Console.WriteLine("Vpn client package Url = {0}", packageUrl);

            // 6.Delete client Root certificate
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRootCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
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

            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 1);
            Assert.AreEqual("sampleClientCert.cer", getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates[0].Name);

            // 9. Unrevoke previously revoked Vpn client certificate
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Clear();
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);
        }

        // Tests Resource:-VirtualNetworkGatewayResource ActiveActive Feature Test:-
        [Test]
        [RecordedTest]
        [Ignore("Track2: The current operation failed due to an intermittent error with gateway 'azsmnet123'. Please try again")]
        public async Task VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1. Create Active-Active VirtualNetworkGateway
            // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName1 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel1 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp1 = await CreateDefaultPublicIpAddress(publicIpName1, resourceGroupName, domainNameLabel1, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp1.Id);

            string publicIpName2 = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel2 = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp2 = await CreateDefaultPublicIpAddress(publicIpName2, resourceGroupName, domainNameLabel2, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp2.Id);

            //B.Prerequisite:-Create Virtual Network using Put VirtualNetworkResource API

            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetworkResource virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);

            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C. CreateVirtualNetworkGateway API
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName1 = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = ipConfigName1,
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                PublicIPAddress = new WritableSubResource() { Id = nic1publicIp1.Id },
                Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
            };

            string ipConfigName2 = Recording.GenerateAssetName("azsmnet");
            VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = ipConfigName2,
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                PublicIPAddress = new WritableSubResource() { Id = nic1publicIp2.Id },
                Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
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
                IPConfigurations = { ipconfig1, ipconfig2 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.HighPerformance, Tier = VirtualNetworkGatewaySkuTier.HighPerformance }
            };

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGateway API
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6} ActiveActive enabled-{7}",
                getVirtualNetworkGatewayResponse.Value.Data.Location,
                getVirtualNetworkGatewayResponse.Value.Id, getVirtualNetworkGatewayResponse.Value.Data.Name,
                getVirtualNetworkGatewayResponse.Value.Data.GatewayType, getVirtualNetworkGatewayResponse.Value.Data.VpnType,
                getVirtualNetworkGatewayResponse.Value.Data.Sku.Name, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier,
                getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.Value.Data.GatewayType);
            Assert.AreEqual(VpnType.RouteBased, getVirtualNetworkGatewayResponse.Value.Data.VpnType);
            Assert.AreEqual(VirtualNetworkGatewaySkuTier.HighPerformance, getVirtualNetworkGatewayResponse.Value.Data.Sku.Tier);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.Count);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.Active);

            // 3. Update ActiveActive VirtualNetworkGatewayResource to ActiveStandby
            getVirtualNetworkGatewayResponse.Value.Data.Active = false;
            getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.Remove(getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.First(config => config.Name.Equals(ipconfig2.Name)));
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.False(getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(1, getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.Count);

            // 4. Update ActiveStandby VirtualNetworkGatewayResource to ActiveActive again
            getVirtualNetworkGatewayResponse.Value.Data.Active = true;
            getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.Add(ipconfig2);
            putVirtualNetworkGatewayResponseOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
            Assert.True(getVirtualNetworkGatewayResponse.Value.Data.Active);
            Assert.AreEqual(2, getVirtualNetworkGatewayResponse.Value.Data.IPConfigurations.Count);
        }

        [Test]
        [RecordedTest]
        [Ignore("Track2: Occasionally succeed in online")]
        public async Task VirtualNetworkGatewayBgpRouteApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
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
                AddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "10.1.0.0/16" } },
                Subnets = { new SubnetData() { Name = gatewaySubnetName, AddressPrefix = "10.1.1.0/24" } }
            };
            PublicIPAddressResource publicIPAddress = await CreateDefaultPublicIpAddress(gw1IpName, resourceGroupName, gw1IpDomainNameLabel, location);
            var virtualNetworkCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworks();
            var virtualNetworksCreateOrUpdateOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnet1Name, vnet1);
            Response<VirtualNetworkResource> vnet1Response = await virtualNetworksCreateOrUpdateOperation.WaitForCompletionAsync();
            Response<SubnetResource> gw1Subnet = await virtualNetworkCollection.Get(vnet1Name).Value.GetSubnets().GetAsync(gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw1IpConfigName,
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                PublicIPAddress = new WritableSubResource() { Id = publicIPAddress.Id },
                Subnet = new WritableSubResource() { Id = gw1Subnet.Value.Id }
            };
            var gw1 = new VirtualNetworkGatewayData()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations = { ipconfig1 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 1337, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            PublicIPAddressResource gw2Ip = await CreateDefaultPublicIpAddress(gw2IpName, resourceGroupName, gw2IpDomainNameLabel, location);
            var vnet2 = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "10.2.0.0/16" } },
                Subnets = { new SubnetData() { Name = gatewaySubnetName, AddressPrefix = "10.2.1.0/24", } }
            };
            var vnet2Operation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnet2Name, vnet2);
            VirtualNetworkResource vnet2Response = await vnet2Operation.WaitForCompletionAsync();
            Response<SubnetResource> gw2Subnet = await virtualNetworkCollection.Get(vnet2Name).Value.GetSubnets().GetAsync(gatewaySubnetName);
            VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
            {
                Name = gw2IpConfigName,
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                PublicIPAddress = new WritableSubResource() { Id = gw2Ip.Id },
                Subnet = new WritableSubResource() { Id = gw2Subnet.Value.Id }
            };
            var gw2 = new VirtualNetworkGatewayData()
            {
                Location = location,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations = { ipconfig2 },
                Sku = new VirtualNetworkGatewaySku() { Name = VirtualNetworkGatewaySkuName.Standard, Tier = VirtualNetworkGatewaySkuTier.Standard },
                BgpSettings = new BgpSettings() { Asn = 9001, BgpPeeringAddress = null, PeerWeight = 5 }
            };

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            List<Task> gatewayDeploymentTasks = new List<Task>
            {
                await Task.Factory.StartNew(async () =>
                {
                    var virtualNetworkGatewaysOperation = await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, gw1Name, gw1);
                    await virtualNetworkGatewaysOperation.WaitForCompletionAsync();;
                }),

                await Task.Factory.StartNew(async() =>
                {
                    var virtualNetworkGatewaysOperation= await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, gw2Name, gw2);
                    await virtualNetworkGatewaysOperation.WaitForCompletionAsync();;
                })
            };

            Task.WaitAll(gatewayDeploymentTasks.ToArray());

            // Create a vnet to vnet connection between the two gateways
            // configure both gateways in parallel
            Response<VirtualNetworkGatewayResource> gw1GetResponse = await virtualNetworkGatewayCollection.GetAsync(gw1Name);
            Response<VirtualNetworkGatewayResource> gw2GetResponse = await virtualNetworkGatewayCollection.GetAsync(gw2Name);
            Response<PublicIPAddressResource> gw2IpResponse = await GetResourceGroup(resourceGroupName).GetPublicIPAddresses().GetAsync(gw1IpName);
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

            var virtualNetworkGatewayConnectionCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            List<Task> gatewayConnectionTasks = new List<Task>
            {
                await Task.Factory.StartNew(async() =>
                {
                    var op = await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, conn1Name, gw1ToGw2Conn);
                    await op.WaitForCompletionAsync();;
                }),
                await Task.Factory.StartNew(async() =>
                {
                    var op =  await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, conn2Name, gw2ToGw1Conn);
                    await op.WaitForCompletionAsync();;
                })
            };

            Task.WaitAll(gatewayConnectionTasks.ToArray());

            // get bgp info from gw1
            var learnedRoutesOperation = await virtualNetworkGatewayCollection.Get(gw1Name).Value.GetLearnedRoutesAsync(WaitUntil.Completed);
            Response<GatewayRouteListResult> learnedRoutes = await learnedRoutesOperation.WaitForCompletionAsync();
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be learned from gw2");
            var advertisedRoutesOperation = await virtualNetworkGatewayCollection.Get(gw1Name).Value.GetAdvertisedRoutesAsync(WaitUntil.Completed, gw2IpResponse.Value.Data.IPAddress);
            Response<GatewayRouteListResult> advertisedRoutes = await advertisedRoutesOperation.WaitForCompletionAsync();
            Assert.True(learnedRoutes.Value.Value.Count() > 0, "At least one route should be advertised to gw2");
            var gw1PeersOperation = await virtualNetworkGatewayCollection.Get(gw1Name).Value.GetBgpPeerStatusAsync(WaitUntil.Completed);
            Response<BgpPeerStatusListResult> gw1Peers = await gw1PeersOperation.WaitForCompletionAsync();
            Assert.True(gw1Peers.Value.Value.Count() > 0, "At least one peer should be connected");
        }

        [Test]
        [RecordedTest]
        [Ignore("Track2: Missing the value of a special environment variable, which is currently uncertain")]
        public async Task VirtualNetworkGatewayGenerateVpnProfileTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // 1.CreateVirtualNetworkGateway
            // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");
            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName,
                domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // B.Prerequisite:-Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            VirtualNetworkResource virtualNetwork = await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);

            // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
            string virtualNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string addressPrefixes = "192.168.0.0/16";
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string clientRootCertName = "0";// this._testEnvironment.ConnectionString.KeyValue.DataPairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
            string samplePublicCertData = "1";// this._testEnvironment.ConnectionString.KeyValue.DataPairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
            VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate(BinaryData.FromString(samplePublicCertData)) { Name = clientRootCertName };
            var virtualNetworkGateway = new VirtualNetworkGatewayData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                EnableBgp = false,
                GatewayType = VirtualNetworkGatewayType.Vpn,
                VpnType = VpnType.RouteBased,
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource() { Id = nic1publicIp.Id },
                        Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new VirtualNetworkAddressSpace()
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

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 2.GetVirtualNetworkGateway API
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse =
               await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);
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
                VpnClientAddressPool = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { newAddressPrefixes }
                },
                RadiusServerAddress = @"8.8.8.8",
                RadiusServerSecret = @"TestRadiusSecret",
            };
            getVirtualNetworkGatewayResponse.Value.Data.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Add(newAddressPrefixes);
            putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse.Value.Data);
            putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());

            // 5.Generate P2S Vpnclient package
            VpnClientContent content = new VpnClientContent()
            {
                RadiusServerAuthCertificate = samplePublicCertData,
                AuthenticationMethod = NetworkAuthenticationMethod.Eaptls
            };

            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrl = ""; // await virtualNetworkGatewayCollection.GenerateGatewayVpnProfile(resourceGroupName,virtualNetworkGatewayName, vpnClientParameters);

            Assert.NotNull(packageUrl);
            Assert.IsNotEmpty(packageUrl);
            Console.WriteLine("Vpn client package Url from GENERATE operation = {0}", packageUrl);

            // Retry to get the package url using the get profile API
            //TODO:Missing the value of a special environment variable, which is currently uncertain
            string packageUrlFromGetOperation = "";// virtualNetworkGatewayCollection.GetGatewayVpnProfile(virtualNetworkGatewayName);
            Assert.NotNull(packageUrlFromGetOperation);
            Assert.IsNotEmpty(packageUrlFromGetOperation);
            Console.WriteLine("Vpn client package Url from GET operation = {0}", packageUrlFromGetOperation);
        }

        [Test]
        [RecordedTest]
        [Ignore("TODO: TRACK2 - Might be test framework issue")]
        public async Task VirtualNetworkGatewayVpnDeviceConfigurationApisTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // CreateVirtualNetworkGatewayConnection API
            // Create LocalNetworkGateway2
            string localNetworkGatewayName = Recording.GenerateAssetName("azsmnet");
            string gatewayIp = "192.168.3.4";

            var localNetworkGateway = new LocalNetworkGatewayData()
            {
                Location = location,
                Tags = { { "test", "value" } },
                GatewayIPAddress = gatewayIp,
                LocalNetworkAddressSpace = new VirtualNetworkAddressSpace()
                {
                    AddressPrefixes = { "192.168.0.0/16", }
                }
            };

            var localNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetLocalNetworkGateways();
            var putLocalNetworkGatewayResponseOperation = await localNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, localNetworkGatewayName, localNetworkGateway);
            Response<LocalNetworkGatewayResource> putLocalNetworkGatewayResponse = await putLocalNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putLocalNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Response<LocalNetworkGatewayResource> getLocalNetworkGatewayResponse = await localNetworkGatewayCollection.GetAsync(localNetworkGatewayName);

            // B. Prerequisite:- Create VirtualNetworkGateway1
            // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddressResource API
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location);
            Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

            // b. Create Virtual Network using Put VirtualNetworkResource API
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = "GatewaySubnet";

            await CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location);
            Response<SubnetResource> getSubnetResponse = await GetResourceGroup(resourceGroupName).GetVirtualNetworks().Get(vnetName).Value.GetSubnets().GetAsync(subnetName);
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
                IPConfigurations =
                {
                    new VirtualNetworkGatewayIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = new WritableSubResource() { Id = nic1publicIp.Id },
                        Subnet = new WritableSubResource() { Id = getSubnetResponse.Value.Id }
                    }
                },
                Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Standard,
                    Tier = VirtualNetworkGatewaySkuTier.Standard
                }
            };

            var virtualNetworkGatewayCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGateways();
            var putVirtualNetworkGatewayResponseOperation =
                await virtualNetworkGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayName, virtualNetworkGateway);
            Response<VirtualNetworkGatewayResource> putVirtualNetworkGatewayResponse = await putVirtualNetworkGatewayResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayResponse.Value.Data.ProvisioningState.ToString());
            Console.WriteLine("Virtual Network Gateway is deployed successfully.");
            Response<VirtualNetworkGatewayResource> getVirtualNetworkGatewayResponse = await virtualNetworkGatewayCollection.GetAsync(virtualNetworkGatewayName);

            // C. CreaetVirtualNetworkGatewayConnection API - IPsec policy and policybased TS enabled
            string virtualNetworkGatewayConnectionName = Recording.GenerateAssetName("azsmnet");
            var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnectionData(getVirtualNetworkGatewayResponse.Value.Data, VirtualNetworkGatewayConnectionType.IPsec)
            {
                Location = location,
                LocalNetworkGateway2 = getLocalNetworkGatewayResponse.Value.Data,
                RoutingWeight = 3,
                SharedKey = "abc"
            };

            virtualNetworkGatewayConnection.IPsecPolicies.Add(
                    new IPsecPolicy(300, 1024, IPsecEncryption.Aes128, IPsecIntegrity.Sha256, IkeEncryption.Aes192, IkeIntegrity.Sha1, DHGroup.DHGroup2, PfsGroup.Pfs1)
                );

            virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

            var virtualNetworkGatewayConnectionCollection = GetResourceGroup(resourceGroupName).GetVirtualNetworkGatewayConnections();
            var putVirtualNetworkGatewayConnectionResponseOperation =
                await virtualNetworkGatewayConnectionCollection.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
            Response<VirtualNetworkGatewayConnectionResource> putVirtualNetworkGatewayConnectionResponse = await putVirtualNetworkGatewayConnectionResponseOperation.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putVirtualNetworkGatewayConnectionResponse.Value.Data.ProvisioningState.ToString());

            // 2. GetVirtualNetworkGatewayConnection API
            Response<VirtualNetworkGatewayConnectionResource> getVirtualNetworkGatewayConnectionResponse = await virtualNetworkGatewayConnectionCollection.GetAsync(virtualNetworkGatewayConnectionName);
            Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                              "IPsecPolicies Count={6}, UsePolicyBasedTS={7}",
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Location, getVirtualNetworkGatewayConnectionResponse.Value.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.Name,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.VirtualNetworkGateway1.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.Value.Data.LocalNetworkGateway2.Id,
                getVirtualNetworkGatewayConnectionResponse.Value.Data.IPsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.Value.Data.UsePolicyBasedTrafficSelectors);

            // List supported Vpn Devices
            Response<string> supportedVpnDevices = await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayName).Value.SupportedVpnDevicesAsync();
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

            //VpnDeviceConfigurationScriptContent scriptParams = new VpnDeviceConfigurationScriptContent()
            //{
            //    DeviceFamily = deviceName,
            //    FirmwareVersion = firmwareVersion,
            //    Vendor = vendorName
            //};

            // TODO -- fix this. To get a VpnDeviceConfigurationScript, we need to find it on an instance of VirtualNetworkGatewayConnection
            //Response<string> vpnDeviceConfiguration =
            //    await virtualNetworkGatewayCollection.Get(virtualNetworkGatewayConnectionName).Value.VpnDeviceConfigurationScriptAsync(scriptParams);

            //Assert.NotNull(vpnDeviceConfiguration);
            //Assert.IsNotEmpty(vpnDeviceConfiguration);
        }
    }
}
