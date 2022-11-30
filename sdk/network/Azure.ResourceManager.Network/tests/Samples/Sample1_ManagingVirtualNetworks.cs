// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#region Snippet:Manage_Networks_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
#endregion Snippet:Manage_Networks_Namespaces

namespace Azure.ResourceManager.Network.Tests.Samples
{
    public class Sample1_ManagingVirtualNetworks
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateOrUpdate()
        {
            #region Snippet:Managing_Networks_CreateAVirtualNetwork
            VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

            string vnetName = "myVnet";

            // Use the same location as the resource group
            VirtualNetworkData input = new VirtualNetworkData()
            {
                Location = resourceGroup.Data.Location,
                AddressPrefixes = { "10.0.0.0/16", },
                DhcpOptionsDnsServers = { "10.1.1.1", "10.1.2.4" },
                Subnets = { new SubnetData() { Name = "mySubnet", AddressPrefix = "10.0.1.0/24", } }
            };

            VirtualNetworkResource vnet = await virtualNetworkCollection.CreateOrUpdate(WaitUntil.Completed, vnetName, input).WaitForCompletionAsync();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task List()
        {
            #region Snippet:Managing_Networks_ListAllVirtualNetworks
            VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

            AsyncPageable<VirtualNetworkResource> response = virtualNetworkCollection.GetAllAsync();
            await foreach (VirtualNetworkResource virtualNetwork in response)
            {
                Console.WriteLine(virtualNetwork.Data.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task Get()
        {
            #region Snippet:Managing_Networks_GetAVirtualNetwork
            VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

            VirtualNetworkResource virtualNetwork = await virtualNetworkCollection.GetAsync("myVnet");
            Console.WriteLine(virtualNetwork.Data.Name);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteVirtualNetwork()
        {
            #region Snippet:Managing_Networks_DeleteAVirtualNetwork
            VirtualNetworkCollection virtualNetworkCollection = resourceGroup.GetVirtualNetworks();

            VirtualNetworkResource virtualNetwork = await virtualNetworkCollection.GetAsync("myVnet");
            await virtualNetwork.DeleteAsync(WaitUntil.Completed);
            #endregion
        }

        [SetUp]
        protected async Task initialize()
        {
            #region Snippet:Readme_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            #endregion

            #region Snippet:Readme_GetResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ResourceGroupResource resourceGroup = await rgCollection.CreateOrUpdate(WaitUntil.Started, rgName, new ResourceGroupData(location)).WaitForCompletionAsync();
            #endregion

            this.resourceGroup = resourceGroup;
        }
    }
}
