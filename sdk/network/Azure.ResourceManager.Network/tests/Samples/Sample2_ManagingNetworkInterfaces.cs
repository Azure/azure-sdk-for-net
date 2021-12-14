// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Samples
{
    public class Sample2_ManagingNetworkInterfaces
    {
        private ResourceGroup resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();
            string vnetName = "myVnet";
            // Use the same location as the resource group
            VirtualNetworkData vnetInput = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
                AddressSpace = new AddressSpace()
                {
                    AddressPrefixes = { "10.0.0.0/16", }
                },
                DhcpOptions = new DhcpOptions()
                {
                    DnsServers = { "10.1.1.1", "10.1.2.4" }
                },
                Subnets = { new SubnetData() { Name = "mySubnet", AddressPrefix = "10.0.1.0/24" } }
            };
            VirtualNetwork virtualNetwork = await virtualNetworkCollection.CreateOrUpdate(vnetName, vnetInput).WaitForCompletionAsync();

            #region Snippet:Managing_Networks_CreateANetworkInterface
            PublicIPAddressCollection publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            string publicIPAddressName = "myIPAddress";
            PublicIPAddressData publicIPInput = new PublicIPAddressData()
            {
                Location = resourceGroup.Data.Location,
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = "myDomain"
                }
            };
            PublicIPAddress publicIPAddress = await publicIPAddressCollection.CreateOrUpdate(publicIPAddressName, publicIPInput).WaitForCompletionAsync();

            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            string networkInterfaceName = "myNetworkInterface";
            NetworkInterfaceData networkInterfaceInput = new NetworkInterfaceData()
            {
                Location = resourceGroup.Data.Location,
                IpConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = "ipConfig",
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = new PublicIPAddressData()
                        {
                            Id = publicIPAddress.Id
                        },
                        Subnet = new SubnetData()
                        {
                            // use the virtual network just created
                            Id = virtualNetwork.Data.Subnets[0].Id
                        }
                    }
                }
            };
            NetworkInterface networkInterface = await networkInterfaceCollection.CreateOrUpdate(networkInterfaceName, networkInterfaceInput).WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Networks_ListAllNetworkInterfaces
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            AsyncPageable<NetworkInterface> response = networkInterfaceCollection.GetAllAsync();
            await foreach (NetworkInterface virtualNetwork in response)
            {
                Console.WriteLine(virtualNetwork.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_Networks_GetANetworkInterface
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
            Console.WriteLine(virtualNetwork.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists()
        {
            #region Snippet:Managing_Networks_GetANetworkInterfaceIfExists
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceCollection.GetIfExistsAsync("foo");
            if (virtualNetwork != null)
            {
                Console.WriteLine(virtualNetwork.Data.Name);
            }

            if (await networkInterfaceCollection.CheckIfExistsAsync("bar"))
            {
                Console.WriteLine("Network interface 'bar' exists.");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteNetworkInterface()
        {
            #region Snippet:Managing_Networks_DeleteANetworkInterface
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
            await virtualNetwork.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            resourceGroup = await rgCollection.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
        }
    }
}
