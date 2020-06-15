// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class NetworkInterfaceTests : NetworkTestsManagementClientBase
    {
        public NetworkInterfaceTests(bool isAsync) : base(isAsync)
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
        public async Task NetworkInterfaceApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create publicIP
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            var publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            Response<PublicIPAddress> getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24" } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new PublicIPAddress ()
                        {
                            Id = getPublicIpAddressResponse.Value.Id
                        },
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);

            //if single CA, primary flag will be set
            Assert.True(getNicResponse.Value.IpConfigurations[0].Primary);
            Assert.AreEqual(1, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.AreEqual(getPublicIpAddressResponse.Value.Id, getNicResponse.Value.IpConfigurations[0].PublicIPAddress.Id);
            Assert.AreEqual(getSubnetResponse.Value.Id, getNicResponse.Value.IpConfigurations[0].Subnet.Id);
            Assert.NotNull(getNicResponse.Value.ResourceGuid);

            // Verify List IpConfigurations in NetworkInterface
            AsyncPageable<NetworkInterfaceIPConfiguration> listNicIpConfigurationsAP = NetworkManagementClient.NetworkInterfaceIPConfigurations.ListAsync(resourceGroupName, nicName);
            List<NetworkInterfaceIPConfiguration> listNicIpConfigurations = await listNicIpConfigurationsAP.ToEnumerableAsync();
            Assert.AreEqual(ipConfigName, listNicIpConfigurations.First().Name);
            Assert.NotNull(listNicIpConfigurations.First().Etag);

            // Verify Get IpConfiguration in NetworkInterface
            Response<NetworkInterfaceIPConfiguration> getNicIpConfiguration = await NetworkManagementClient.NetworkInterfaceIPConfigurations.GetAsync(resourceGroupName, nicName, ipConfigName);
            Assert.AreEqual(ipConfigName, getNicIpConfiguration.Value.Name);
            Assert.NotNull(getNicIpConfiguration.Value.Etag);

            // Verify List LoadBalancers in NetworkInterface
            AsyncPageable<LoadBalancer> listNicLoadBalancersAP = NetworkManagementClient.NetworkInterfaceLoadBalancers.ListAsync(resourceGroupName, nicName);
            List<LoadBalancer> listNicLoadBalancers = await listNicLoadBalancersAP.ToEnumerableAsync();
            Assert.IsEmpty(listNicLoadBalancers);

            // Get all Nics
            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.AreEqual(getNicResponse.Value.Name, getListNicResponse.First().Name);
            Assert.AreEqual(getNicResponse.Value.Etag, getListNicResponse.First().Etag);
            Assert.AreEqual(getNicResponse.Value.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);

            // Get all Nics in subscription
            AsyncPageable<NetworkInterface> listNicSubscriptionAP = NetworkManagementClient.NetworkInterfaces.ListAllAsync();
            List<NetworkInterface> listNicSubscription = await listNicSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNicSubscription);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete PublicIPAddress
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, publicIpName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task NetworkInterfaceWithAcceleratedNetworkingTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>()
                {
                    new Subnet()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                    }
                }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            // IDnsSuffix is a read-only property, hence not specified below
            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                EnableAcceleratedNetworking = true,
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Primary = true,
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PrivateIPAddressVersion = IPVersion.IPv4,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    },
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.AreEqual(1, getNicResponse.Value.IpConfigurations.Count);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task NetworkInterfaceMultiIpConfigTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create publicIP
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            Response<PublicIPAddress> getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24" } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string ipconfigName2 = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Primary = true,
                        PublicIPAddress = new PublicIPAddress ()
                        {
                            Id = getPublicIpAddressResponse.Value.Id
                        },
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    },
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipconfigName2,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Primary = false,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.True(getNicResponse.Value.IpConfigurations[0].Primary);
            Assert.AreEqual(2, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.AreEqual(ipconfigName2, getNicResponse.Value.IpConfigurations[1].Name);
            Assert.False(getNicResponse.Value.IpConfigurations[1].Primary);
            Assert.AreEqual(getPublicIpAddressResponse.Value.Id, getNicResponse.Value.IpConfigurations[0].PublicIPAddress.Id);
            Assert.AreEqual(getSubnetResponse.Value.Id, getNicResponse.Value.IpConfigurations[0].Subnet.Id);
            Assert.AreEqual(getSubnetResponse.Value.Id, getNicResponse.Value.IpConfigurations[1].Subnet.Id);
            Assert.NotNull(getNicResponse.Value.ResourceGuid);

            // Get all Nics
            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.AreEqual(getNicResponse.Value.Name, getListNicResponse.First().Name);
            Assert.AreEqual(getNicResponse.Value.Etag, getListNicResponse.First().Etag);
            Assert.AreEqual(getNicResponse.Value.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);
            Assert.AreEqual(getNicResponse.Value.IpConfigurations[1].Etag, getListNicResponse.First().IpConfigurations[1].Etag);

            // Get all Nics in subscription
            AsyncPageable<NetworkInterface> listNicSubscriptionAP = NetworkManagementClient.NetworkInterfaces.ListAllAsync();
            List<NetworkInterface> listNicSubscription = await listNicSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNicSubscription);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete PublicIPAddress
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, publicIpName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task AssertMultiIpConfigOnDifferentSubnetFails()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName2 = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                Subnets = new List<Subnet>()
                {
                    new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", },
                    new Subnet() { Name = subnetName2, AddressPrefix = "10.0.1.0/24" }
                }
            };
            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnet1Response = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);
            Response<Subnet> getSubnet2Response = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName2);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");
            string ipconfigName2 = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Primary = true,
                        Subnet = new Subnet()
                        {
                            Id = getSubnet1Response.Value.Id
                        }
                    },
                        new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipconfigName2,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Primary = false,
                        Subnet = new Subnet()
                        {
                            Id = getSubnet2Response.Value.Id
                        }
                    }
                }
            };

            try
            {
                // Test NIC apis
                NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
                Response<NetworkInterface> putNicResponse = await WaitForCompletionAsync(putNicResponseOperation);
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message.Contains("cannot belong to different subnets"));
            }
        }

        [Test]
        public async Task NetworkInterfaceDnsSettingsTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            var nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                DnsSettings = new NetworkInterfaceDnsSettings()
                {
                    DnsServers = new List<string> { "1.0.0.1", "1.0.0.2" },
                    InternalDnsNameLabel = "idnstest",
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.AreEqual(1, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.AreEqual(2, getNicResponse.Value.DnsSettings.DnsServers.Count);
            Assert.IsTrue(getNicResponse.Value.DnsSettings.DnsServers.Contains("1.0.0.1"));
            Assert.IsTrue(getNicResponse.Value.DnsSettings.DnsServers.Contains("1.0.0.2"));
            Assert.AreEqual("idnstest", getNicResponse.Value.DnsSettings.InternalDnsNameLabel);
            Assert.AreEqual(0, getNicResponse.Value.DnsSettings.AppliedDnsServers.Count);
            Assert.True(getNicResponse.Value.IpConfigurations[0].Primary);
            Assert.NotNull(getNicResponse.Value.DnsSettings.InternalFqdn);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        /// currently this test is failing because of nrp valdiation check:cannot have multiple IPv4 IpConfigurations if it specifies a Ipv6 IpConfigurations. Ipv4 Ipconfig Count: 2
        /// will remove ignore tag once the check in nrp is removed.
        [Test]
        public async Task NetworkInterfaceApiIPv6MultiCATest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces", Network.Tests.Helpers.FeaturesInfo.Type.All);
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create publicIP
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddress publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,

                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>() { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24" } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("dualstacknic");
            string ipConfigName = Recording.GenerateAssetName("ipv4ipconfig");
            string ipv6IpConfigName = Recording.GenerateAssetName("ipv6ipconfig");
            string ipConfigName2 = Recording.GenerateAssetName("ipv4ipconfig2");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Primary = true,
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PrivateIPAddressVersion = IPVersion.IPv4,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    },
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipv6IpConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PrivateIPAddressVersion = IPVersion.IPv6,
                    },

                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName2,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PrivateIPAddressVersion = IPVersion.IPv4,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.NotNull(getNicResponse.Value.ResourceGuid);
            Assert.AreEqual(getSubnetResponse.Value.Id, getNicResponse.Value.IpConfigurations[0].Subnet.Id);
            Assert.AreEqual(IPVersion.IPv4, getNicResponse.Value.IpConfigurations[0].PrivateIPAddressVersion);

            // Ipv6 specific asserts
            Assert.AreEqual(3, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipv6IpConfigName, getNicResponse.Value.IpConfigurations[1].Name);
            Assert.True(getNicResponse.Value.IpConfigurations[0].Primary);
            Assert.Null(getNicResponse.Value.IpConfigurations[1].Subnet);
            Assert.AreEqual(IPVersion.IPv6, getNicResponse.Value.IpConfigurations[1].PrivateIPAddressVersion);

            // Get all Nics
            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.AreEqual(getNicResponse.Value.Name, getListNicResponse.First().Name);
            Assert.AreEqual(getNicResponse.Value.Etag, getListNicResponse.First().Etag);
            Assert.AreEqual(getNicResponse.Value.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);
            Assert.AreEqual(getNicResponse.Value.IpConfigurations[1].Etag, getListNicResponse.First().IpConfigurations[1].Etag);

            // Get all Nics in subscription
            AsyncPageable<NetworkInterface> listNicSubscriptionAP = NetworkManagementClient.NetworkInterfaces.ListAllAsync();
            List<NetworkInterface> listNicSubscription = await listNicSubscriptionAP.ToEnumerableAsync();
            Assert.IsNotEmpty(listNicSubscription);

            // Delete Nic
            NetworkInterfacesDeleteOperation deleteOperation = await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);
            await WaitForCompletionAsync(deleteOperation);
            getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete PublicIPAddress
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, publicIpName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task NetworkInterfaceDnsSettingsTestIdnsSuffix()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24" } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            // IDnsSuffix is a read-only property, hence not specified below
            var nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                DnsSettings = new NetworkInterfaceDnsSettings()
                {
                    DnsServers = new List<string> { "1.0.0.1", "1.0.0.2" },
                    InternalDnsNameLabel = "idnstest",
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.AreEqual(1, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.AreEqual(2, getNicResponse.Value.DnsSettings.DnsServers.Count);
            Assert.IsTrue(getNicResponse.Value.DnsSettings.DnsServers.Contains("1.0.0.1"));
            Assert.IsTrue(getNicResponse.Value.DnsSettings.DnsServers.Contains("1.0.0.2"));
            Assert.AreEqual("idnstest", getNicResponse.Value.DnsSettings.InternalDnsNameLabel);
            Assert.AreEqual(0, getNicResponse.Value.DnsSettings.AppliedDnsServers.Count);
            Assert.NotNull(getNicResponse.Value.DnsSettings.InternalFqdn);

            // IDnsSuffix is a read-only property. Ensure the response contains some value.
            Assert.NotNull(getNicResponse.Value.DnsSettings.InternalDomainNameSuffix);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task NetworkInterfaceEnableIPForwardingTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, subnetName);

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = getSubnetResponse.Value.Id
                        }
                    }
                },
                EnableIPForwarding = false,
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());
            Assert.Null(getNicResponse.Value.VirtualMachine);
            Assert.Null(getNicResponse.Value.MacAddress);
            Assert.AreEqual(1, getNicResponse.Value.IpConfigurations.Count);
            Assert.AreEqual(ipConfigName, getNicResponse.Value.IpConfigurations[0].Name);
            Assert.False(getNicResponse.Value.EnableIPForwarding);

            getNicResponse.Value.EnableIPForwarding = true;
            await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, getNicResponse);
            getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual(getNicResponse.Value.Name, nicName);
            Assert.True(getNicResponse.Value.EnableIPForwarding);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        public async Task NetworkInterfaceNetworkSecurityGroupTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            string securityRule1 = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            // Create network security group
            string destinationPortRange = "123-3500";
            NetworkSecurityGroup networkSecurityGroup = new NetworkSecurityGroup()
            {
                Location = location,
                SecurityRules = new List<SecurityRule>()
                {
                    new SecurityRule()
                    {
                        Name = securityRule1,
                        Access = SecurityRuleAccess.Allow,
                        Description = "Test security rule",
                        DestinationAddressPrefix = "*",
                        DestinationPortRange = destinationPortRange,
                        Direction = SecurityRuleDirection.Inbound,
                        Priority = 500,
                        Protocol = SecurityRuleProtocol.Tcp,
                        SourceAddressPrefix = "*",
                        SourcePortRange = "655"
                    }
                }
            };

            // Put Nsg
            NetworkSecurityGroupsCreateOrUpdateOperation putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await WaitForCompletionAsync(putNsgResponseOperation);
            Assert.AreEqual("Succeeded", putNsgResponse.Value.ProvisioningState.ToString());

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = putVnetResponse.Value.Subnets[0].Id
                        }
                    }
                },
                NetworkSecurityGroup = putNsgResponse
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());

            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            // Verify nic - nsg association
            Assert.AreEqual(getNicResponse.Value.NetworkSecurityGroup.Id, getNsgResponse.Value.Id);
            Assert.AreEqual(getNsgResponse.Value.NetworkInterfaces[0].Id, getNicResponse.Value.Id);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete NSG
            await NetworkManagementClient.NetworkSecurityGroups.StartDeleteAsync(resourceGroupName, networkSecurityGroupName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        [Ignore("Track2: Need to use an existing virtual machine, but not create it in test case ")]
        public async Task NetworkInterfaceEffectiveNetworkSecurityGroupTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            string securityRule1 = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            // Create network security group
            string destinationPortRange = "123-3500";
            NetworkSecurityGroup networkSecurityGroup = new NetworkSecurityGroup()
            {
                Location = location,
                SecurityRules = new List<SecurityRule>()
                {
                    new SecurityRule()
                    {
                        Name = securityRule1,
                        Access = SecurityRuleAccess.Allow,
                        Description = "Test security rule",
                        DestinationAddressPrefix = "*",
                        DestinationPortRange = destinationPortRange,
                        Direction = SecurityRuleDirection.Inbound,
                        Priority = 500,
                        Protocol = SecurityRuleProtocol.Tcp,
                        SourceAddressPrefix = "*",
                        SourcePortRange = "655"
                    }
                }
            };

            // Put Nsg
            NetworkSecurityGroupsCreateOrUpdateOperation putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            Response<NetworkSecurityGroup> putNsgResponse = await WaitForCompletionAsync(putNsgResponseOperation);
            Assert.AreEqual("Succeeded", putNsgResponse.Value.ProvisioningState.ToString());

            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = putVnetResponse.Value.Subnets[0].Id
                        }
                    }
                },
                NetworkSecurityGroup = putNsgResponse
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());

            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            // Verify nic - nsg association
            Assert.AreEqual(getNicResponse.Value.NetworkSecurityGroup.Id, getNsgResponse.Value.Id);
            Assert.AreEqual(getNsgResponse.Value.NetworkInterfaces[0].Id, getNicResponse.Value.Id);

            // Get effective NSGs
            NetworkInterfacesListEffectiveNetworkSecurityGroupsOperation effectiveNsgsOperation = await NetworkManagementClient.NetworkInterfaces.StartListEffectiveNetworkSecurityGroupsAsync(resourceGroupName, nicName);
            Response<EffectiveNetworkSecurityGroupListResult> effectiveNsgs = await WaitForCompletionAsync(effectiveNsgsOperation);
            Assert.NotNull(effectiveNsgs);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete NSG
            await NetworkManagementClient.NetworkSecurityGroups.StartDeleteAsync(resourceGroupName, networkSecurityGroupName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }

        [Test]
        [Ignore("Track2: Need to use an existing virtual machine, but not create it in test case ")]
        public async Task NetworkInterfaceEffectiveRouteTableTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/networkInterfaces");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create Vnet
            // Populate parameter for Put Vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string subnetName = Recording.GenerateAssetName("azsmnet");
            string routeTableName = Recording.GenerateAssetName("azsmnet");
            string route1Name = Recording.GenerateAssetName("azsmnet");

            RouteTable routeTable = new RouteTable() { Location = location, };
            routeTable.Routes = new List<Route>();

            Route route1 = new Route()
            {
                AddressPrefix = "192.168.1.0/24",
                Name = route1Name,
                NextHopIpAddress = "23.108.1.1",
                NextHopType = RouteNextHopType.VirtualAppliance
            };

            routeTable.Routes.Add(route1);

            // Put RouteTable
            RouteTablesCreateOrUpdateOperation putRouteTableResponseOperation = await NetworkManagementClient.RouteTables.StartCreateOrUpdateAsync(resourceGroupName, routeTableName, routeTable);
            Response<RouteTable> putRouteTableResponse = await WaitForCompletionAsync(putRouteTableResponseOperation);
            Assert.AreEqual("Succeeded", putRouteTableResponse.Value.ProvisioningState.ToString());

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>() { new Subnet() { Name = subnetName, AddressPrefix = "10.0.0.0/24", RouteTable = putRouteTableResponse } }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            Response<VirtualNetwork> putVnetResponse = await WaitForCompletionAsync(putVnetResponseOperation);
            // Create Nic
            string nicName = Recording.GenerateAssetName("azsmnet");
            string ipConfigName = Recording.GenerateAssetName("azsmnet");

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = ipConfigName,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        Subnet = new Subnet()
                        {
                            Id = putVnetResponse.Value.Subnets[0].Id
                        }
                    }
                }
            };

            // Test NIC apis
            NetworkInterfacesCreateOrUpdateOperation putNicResponseOperation = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nicName, nicParameters);
            await WaitForCompletionAsync(putNicResponseOperation);
            Response<NetworkInterface> getNicResponse = await NetworkManagementClient.NetworkInterfaces.GetAsync(resourceGroupName, nicName);
            Assert.AreEqual("Succeeded", getNicResponse.Value.ProvisioningState.ToString());

            // Get effective NSGs
            NetworkInterfacesGetEffectiveRouteTableOperation effectiveRouteTableOperation = await NetworkManagementClient.NetworkInterfaces.StartGetEffectiveRouteTableAsync(resourceGroupName, nicName);
            Response<EffectiveRouteListResult> effectiveRouteTable = await WaitForCompletionAsync(effectiveRouteTableOperation);
            Assert.NotNull(effectiveRouteTable);

            // Delete Nic
            await NetworkManagementClient.NetworkInterfaces.StartDeleteAsync(resourceGroupName, nicName);

            AsyncPageable<NetworkInterface> getListNicResponseAP = NetworkManagementClient.NetworkInterfaces.ListAsync(resourceGroupName);
            List<NetworkInterface> getListNicResponse = await getListNicResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getListNicResponse);

            // Delete routetable
            await NetworkManagementClient.RouteTables.StartDeleteAsync(resourceGroupName, routeTableName);

            // Delete VirtualNetwork
            await NetworkManagementClient.VirtualNetworks.StartDeleteAsync(resourceGroupName, vnetName);
        }
    }
}
