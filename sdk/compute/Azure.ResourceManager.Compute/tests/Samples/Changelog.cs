// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Changelog_NewUsing
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.Core;
using System;
using System.Linq;
#endregion
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Samples
{
    public class Changelog
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task NewCode()
        {
            #region Snippet:Changelog_New
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());

            AzureLocation location = AzureLocation.WestUS;
            // Create ResourceGroupResource
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
            ArmOperation<ResourceGroupResource> rgOperation = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, "myResourceGroup", new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = rgOperation.Value;

            // Create AvailabilitySet
            AvailabilitySetData availabilitySetData = new AvailabilitySetData(location)
            {
                PlatformUpdateDomainCount = 5,
                PlatformFaultDomainCount = 2,
                Sku = new ComputeSku() { Name = "Aligned" }
            };
            ArmOperation<AvailabilitySetResource> asetOperation = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync(WaitUntil.Completed, "myAvailabilitySet", availabilitySetData);
            AvailabilitySetResource availabilitySet = asetOperation.Value;

            // Create VNet
            VirtualNetworkData vnetData = new VirtualNetworkData()
            {
                Location = location,
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = "mySubnet",
                        AddressPrefix = "10.0.0.0/24",
                    }
                },
                AddressPrefixes =
                {
                    "10.0.0.0/16"
                }
            };
            ArmOperation<VirtualNetworkResource> vnetOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, "myVirtualNetwork", vnetData);
            VirtualNetworkResource vnet = vnetOperation.Value;

            // Create Network interface
            NetworkInterfaceData nicData = new NetworkInterfaceData()
            {
                Location = location,
                IPConfigurations =
                {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = "Primary",
                        Primary = true,
                        Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                    }
                }
            };
            ArmOperation<NetworkInterfaceResource> nicOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, "myNetworkInterface", nicData);
            NetworkInterfaceResource nic = nicOperation.Value;

            VirtualMachineData vmData = new VirtualMachineData(location)
            {
                AvailabilitySet = new WritableSubResource() { Id = availabilitySet.Id },
                NetworkProfile = new VirtualMachineNetworkProfile
                {
                    NetworkInterfaces = { new VirtualMachineNetworkInterfaceReference() { Id = nic.Id } }
                },
                OSProfile = new VirtualMachineOSProfile()
                {
                    ComputerName = "testVM",
                    AdminUsername = "username",
                    AdminPassword = "(YourPassword)",
                    LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVmAgent = true }
                },
                StorageProfile = new VirtualMachineStorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Offer = "UbuntuServer",
                        Publisher = "Canonical",
                        Sku = "18.04-LTS",
                        Version = "latest"
                    }
                },
                HardwareProfile = new VirtualMachineHardwareProfile() { VmSize = VirtualMachineSizeType.StandardB1Ms },
            };
            ArmOperation<VirtualMachineResource> vmOperation = await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync(WaitUntil.Completed, "myVirtualMachine", vmData);
            VirtualMachineResource vm = vmOperation.Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateVmExtension()
        {
            #region Snippet:Changelog_CreateVMExtension
            var vmExtension = new VirtualMachineExtensionData(AzureLocation.WestUS)
            {
                Tags = { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Publisher = "Microsoft.Compute",
                ExtensionType = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                ForceUpdateTag = "RerunExtension",
                Settings = BinaryData.FromObjectAsJson(new { }),
                ProtectedSettings = BinaryData.FromObjectAsJson(new { })
            };
            #endregion
        }
    }
}
