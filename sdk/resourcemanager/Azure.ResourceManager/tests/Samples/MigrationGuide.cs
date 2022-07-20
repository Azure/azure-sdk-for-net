#region Snippet:Using_Statements
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
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            AzureLocation location = AzureLocation.WestUS2;
            string resourceGroupName = "QuickStartRG";

            ResourceGroupData resourceGroupData = new ResourceGroupData(location);
            ArmOperation<ResourceGroupResource> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroupResource resourceGroup = resourceGroupOperation.Value;
            #endregion

            #region Snippet:Create_AvailabilitySet
            string virtualMachineName = "quickstartvm";
            AvailabilitySetData availabilitySetData = new AvailabilitySetData(location);
            AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
            ArmOperation<AvailabilitySetResource> availabilitySetOperation = await availabilitySets.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName + "_aSet", availabilitySetData);
            AvailabilitySetResource availabilitySet = availabilitySetOperation.Value;
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
            ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
            VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
            #endregion

            #region Snippet:Create_NetworkSecurityGroup
            string networkSecurityGroupName = virtualMachineName + "_nsg";
            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData() { Location = location };
            NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
            ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);
            NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
            #endregion

            #region Snippet:Create_NetworkInterface
            string networkInterfaceName = virtualMachineName + "_nic";
            NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
            };

            NetworkInterfaceData nicData = new NetworkInterfaceData();
            nicData.Location = location;
            nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
            NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
            ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
            NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;
            #endregion

            #region Snippet:Create_VirtualMachine
            VirtualMachineData virutalMachineData = new VirtualMachineData(location)
            {
                OSProfile = new VirtualMachineOSProfile()
                {
                    AdminUsername = "admin-username",
                    AdminPassword = "admin-p4$$w0rd",
                    ComputerName = "computer-name"
                },
                AvailabilitySetId = availabilitySet.Id,
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = networkInterface.Id
                        }
                    }
                }
            };

            VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
            ArmOperation<VirtualMachineResource> virtualMachineOperation = await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, virutalMachineData);
            VirtualMachineResource virtualMachine = virtualMachineOperation.Value;
            Console.WriteLine("VirtualMachine ID: " + virtualMachine.Id);
            #endregion
        }
    }
}
