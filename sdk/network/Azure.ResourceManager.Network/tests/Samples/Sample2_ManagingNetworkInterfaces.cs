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
            VirtualNetworkContainer virtualNetworkContainer = resourceGroup.GetVirtualNetworks();
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
            VirtualNetwork virtualNetwork = await virtualNetworkContainer.CreateOrUpdate(vnetName, vnetInput).WaitForCompletionAsync();

            #region Snippet:Managing_Networks_CreateANetworkInterface
            PublicIPAddressContainer publicIPAddressContainer = resourceGroup.GetPublicIPAddresses();
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
            PublicIPAddress publicIPAddress = await publicIPAddressContainer.CreateOrUpdate(publicIPAddressName, publicIPInput).WaitForCompletionAsync();

            NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();
            string networkInterfaceName = "myNetworkInterface";
            NetworkInterfaceData networkInterfaceInput = new NetworkInterfaceData()
            {
                Location = resourceGroup.Data.Location,
                IpConfigurations = {
                    new NetworkInterfaceIPConfiguration()
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
            NetworkInterface networkInterface = await networkInterfaceContainer.CreateOrUpdate(networkInterfaceName, networkInterfaceInput).WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Networks_ListAllNetworkInterfaces
            NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

            AsyncPageable<NetworkInterface> response = networkInterfaceContainer.GetAllAsync();
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
            NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceContainer.GetAsync("myVnet");
            Console.WriteLine(virtualNetwork.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetIfExists()
        {
            #region Snippet:Managing_Networks_GetANetworkInterfaceIfExists
            NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceContainer.GetIfExistsAsync("foo");
            if (virtualNetwork != null)
            {
                Console.WriteLine(virtualNetwork.Data.Name);
            }

            if (await networkInterfaceContainer.CheckIfExistsAsync("bar"))
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
            NetworkInterfaceContainer networkInterfaceContainer = resourceGroup.GetNetworkInterfaces();

            NetworkInterface virtualNetwork = await networkInterfaceContainer.GetAsync("myVnet");
            await virtualNetwork.DeleteAsync();
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            // With the container, we can create a new resource group with an specific name
            string rgName = "myRgName";
            Location location = Location.WestUS2;
            resourceGroup = await rgContainer.CreateOrUpdate(rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
        }
    }
}
