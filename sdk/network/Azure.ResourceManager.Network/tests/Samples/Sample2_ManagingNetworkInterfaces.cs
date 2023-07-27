// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Samples
{
    public class Sample2_ManagingNetworkInterfaces
    {
        private ResourceGroupResource resourceGroup;

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
                AddressPrefixes = { "10.0.0.0/16", },
                DhcpOptionsDnsServers = { "10.1.1.1", "10.1.2.4" },
                Subnets = { new SubnetData() { Name = "mySubnet", AddressPrefix = "10.0.1.0/24" } }
            };
            VirtualNetworkResource virtualNetwork = await virtualNetworkCollection.CreateOrUpdate(WaitUntil.Completed, vnetName, vnetInput).WaitForCompletionAsync();

            #region Snippet:Managing_Networks_CreateANetworkInterface
            PublicIPAddressCollection publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            string publicIPAddressName = "myIPAddress";
            PublicIPAddressData publicIPInput = new PublicIPAddressData()
            {
                Location = resourceGroup.Data.Location,
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = "myDomain"
                }
            };
            PublicIPAddressResource publicIPAddress = await publicIPAddressCollection.CreateOrUpdate(WaitUntil.Completed, publicIPAddressName, publicIPInput).WaitForCompletionAsync();

            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();
            string networkInterfaceName = "myNetworkInterface";
            NetworkInterfaceData networkInterfaceInput = new NetworkInterfaceData()
            {
                Location = resourceGroup.Data.Location,
                IPConfigurations = {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = "ipConfig",
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
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
            NetworkInterfaceResource networkInterface = await networkInterfaceCollection.CreateOrUpdate(WaitUntil.Completed, networkInterfaceName, networkInterfaceInput).WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Networks_ListAllNetworkInterfaces
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            AsyncPageable<NetworkInterfaceResource> response = networkInterfaceCollection.GetAllAsync();
            await foreach (NetworkInterfaceResource virtualNetwork in response)
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

            NetworkInterfaceResource virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
            Console.WriteLine(virtualNetwork.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteNetworkInterface()
        {
            #region Snippet:Managing_Networks_DeleteANetworkInterface
            NetworkInterfaceCollection networkInterfaceCollection = resourceGroup.GetNetworkInterfaces();

            NetworkInterfaceResource virtualNetwork = await networkInterfaceCollection.GetAsync("myVnet");
            await virtualNetwork.DeleteAsync(WaitUntil.Completed);
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            resourceGroup = await rgCollection.CreateOrUpdate(WaitUntil.Started, rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
        }
    }
}
