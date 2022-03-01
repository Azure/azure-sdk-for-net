﻿#region Snippet:Using_Statements
using System;
using System.Linq;
using Azure.Identity;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
#endregion
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    internal class MigrationGuide
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task MigrationExample()
        {
            #region Snippet:Construct_Client
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            #endregion

            #region Snippet:Create_ResourceGroup
            Subscription subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            AzureLocation location = AzureLocation.WestUS2;
            string resourceGroupName = "QuickStartRG";

            ResourceGroupData resourceGroupData = new ResourceGroupData(location);
            ArmOperation<ResourceGroup> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(true, resourceGroupName, resourceGroupData);
            ResourceGroup resourceGroup = resourceGroupOperation.Value;
            #endregion

            #region Snippet:Create_AvailabilitySet
            string virtualMachineName = "quickstartvm";
            AvailabilitySetData availabilitySetData = new AvailabilitySetData(location);
            AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
            ArmOperation<AvailabilitySet> availabilitySetOperation = await availabilitySets.CreateOrUpdateAsync(true, virtualMachineName + "_aSet", availabilitySetData);
            AvailabilitySet availabilitySet = availabilitySetOperation.Value;
            #endregion

            #region Snippet:Create_Vnet_and_Subnet
            string virtualNetworkName = "MYVM" + "_vnet";
            string subnetName = "mySubnet";

            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
            {
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24"
                    }
                }
            };
            VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
            virtualNetworkData.AddressPrefixes.Add("10.0.0.0/16");
            ArmOperation<VirtualNetwork> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(true, virtualNetworkName, virtualNetworkData);
            VirtualNetwork virtualNetwork = virtualNetworkOperation.Value;
            #endregion

            #region Snippet:Create_NetworkSecurityGroup
            string networkSecurityGroupName = virtualMachineName + "_nsg";
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData() { Location = location };
            NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
            ArmOperation<NetworkSecurityGroup> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(true, networkSecurityGroupName, networkSecurityGroupData);
            NetworkSecurityGroup networkSecurityGroup = networkSecurityGroupOperation.Value;
            #endregion

            #region Snippet:Create_NetworkInterface
            string networkInterfaceName = virtualMachineName + "_nic";
            NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
                PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
            };

            NetworkInterfaceData nicData = new NetworkInterfaceData();
            nicData.Location = location;
            nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
            NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
            ArmOperation<NetworkInterface> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(true, networkInterfaceName, nicData);
            NetworkInterface networkInterface = networkInterfaceOperation.Value;
            #endregion

            #region Snippet:Create_VirtualMachine
            VirtualMachineData virutalMachineData = new VirtualMachineData(location);
            virutalMachineData.OSProfile.AdminUsername = "admin-username";
            virutalMachineData.OSProfile.AdminPassword = "admin-p4$$w0rd";
            virutalMachineData.OSProfile.ComputerName = "computer-name";
            virutalMachineData.AvailabilitySetId = availabilitySet.Id;
            NetworkInterfaceReference nicReference = new NetworkInterfaceReference();
            nicReference.Id = networkInterface.Id;
            virutalMachineData.NetworkProfile.NetworkInterfaces.Add(nicReference);

            VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
            ArmOperation<VirtualMachine> virtualMachineOperation = await virtualMachines.CreateOrUpdateAsync(true, virtualMachineName, virutalMachineData);
            VirtualMachine virtualMachine = virtualMachineOperation.Value;
            Console.WriteLine("VM ID: " + virtualMachine.Id);
            #endregion
        }
    }
}
