// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Creating_A_Virtual_Network_Namespaces

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Resources;

#endregion Snippet:Creating_A_Virtual_Network_Namespaces

using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample3_CreatingAVirtualNetwork
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateResourceGroupAsync()
        {
            #region Snippet:Creating_A_Virtual_Network_CreateResourceGroup

            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            string resourceGroupName = "myResourceGroup";
            ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
            ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroupResource resourceGroup = operation.Value;

            #endregion Snippet:Creating_A_Virtual_Network_CreateResourceGroup
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateVirtualNetworkAsync()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceGroupCollection resourceGroups = (await client.GetDefaultSubscriptionAsync()).GetResourceGroups();

            string resouceGroupName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resouceGroupName);

            #region Snippet:Creating_A_Virtual_Network_CreateVirtualNetwork

            string vnetName = "myVnetName";
            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
            {
                // You can specify many options for the Virtual Network in here
                Location = "WestUS2",
                AddressPrefixes = { "10.0.0.0/16", }
            };

            ArmOperation<VirtualNetworkResource> armOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
            VirtualNetworkResource virtualNetworkResource = armOperation.Value;

            #endregion Snippet:Creating_A_Virtual_Network_CreateVirtualNetwork
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateSubnetAsync()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceGroupCollection resourceGroups = (await client.GetDefaultSubscriptionAsync()).GetResourceGroups();

            string resouceGroupName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resouceGroupName);

            string vnetName = "myVnetName";
            VirtualNetworkResource virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnetName);

            #region Snippet:Creating_A_Virtual_Network_CreateSubnet

            string subnetName = $"{vnetName}_Subnet1";
            SubnetData subnetData = new SubnetData()
            {
                Name = subnetName,
                AddressPrefix = "10.0.1.0/24"
            };

            ArmOperation<SubnetResource> armOperation = await virtualNetworkResource.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnetName, subnetData);
            SubnetResource subnetResource = armOperation.Value;

            #endregion Snippet:Creating_A_Virtual_Network_CreateSubnet
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateSubnetByAnotherWayAsync()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceGroupCollection resourceGroups = (await client.GetDefaultSubscriptionAsync()).GetResourceGroups();

            string resouceGroupName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resouceGroupName);

            #region Snippet:Creating_A_Virtual_Network_CreateSubnetByAnotherWay

            string vnetName = "myVnetName";
            string subnet1Name = $"{vnetName}_Subnet1";

            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
            {
                Location = "WestUS2",
                AddressPrefixes = { "10.0.0.0/16" },
                Subnets =
                {
                    new SubnetData
                    {
                        Name = subnet1Name,
                        AddressPrefix = "10.0.0.0/24"
                    }
                }
            };

            ArmOperation<VirtualNetworkResource> armOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, virtualNetworkData);
            VirtualNetworkResource virtualNetworkResource = armOperation.Value;

            #endregion Snippet:Creating_A_Virtual_Network_CreateSubnetByAnotherWay
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ModifyingSubnetsInVirtualNetworkAsync()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceGroupCollection resourceGroups = (await client.GetDefaultSubscriptionAsync()).GetResourceGroups();

            string resouceGroupName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resouceGroupName);

            string vnetName = "myVnetName";
            VirtualNetworkResource virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnetName);

            #region Snippet:Creating_A_Virtual_Network_ModifyingSubnetsInVirtualNetwork

            string subnet2Name = $"{vnetName}_Subnet2";
            SubnetData subnetData = new SubnetData()
            {
                Name = subnet2Name,
                AddressPrefix = "10.0.1.0/24"
            };

            ArmOperation<SubnetResource> armOperation = await virtualNetworkResource.GetSubnets().CreateOrUpdateAsync(WaitUntil.Completed, subnet2Name, subnetData);
            SubnetResource subnetResource = armOperation.Value;

            #endregion Snippet:Creating_A_Virtual_Network_ModifyingSubnetsInVirtualNetwork
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GetAllSubnetsCountAsync()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            ResourceGroupCollection resourceGroups = (await client.GetDefaultSubscriptionAsync()).GetResourceGroups();

            string resouceGroupName = "myResourceGroup";
            ResourceGroupResource resourceGroup = await resourceGroups.GetAsync(resouceGroupName);

            string vnetName = "myVnetName";

            #region Snippet:Creating_A_Virtual_Network_GetAllSubnetsCount

            VirtualNetworkResource virtualNetworkResource = await resourceGroup.GetVirtualNetworks().GetAsync(vnetName);
            Console.WriteLine(virtualNetworkResource.Data.Subnets.Count);

            #endregion Snippet:Creating_A_Virtual_Network_GetAllSubnetsCount
        }
    }
}
