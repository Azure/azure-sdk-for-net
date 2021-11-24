// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Changelog_New
            using Azure.Identity;
            using Azure.ResourceManager;
            using Azure.ResourceManager.Compute.Models;
            using Azure.ResourceManager.Network;
            using Azure.ResourceManager.Network.Models;
            using Azure.ResourceManager.Resources;
            using Azure.ResourceManager.Resources.Models;
            using System.Linq;

#if !SNIPPET
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
#endif
            var armClient = new ArmClient(new DefaultAzureCredential());

            var location = Location.WestUS;
            // Create ResourceGroup
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroupCreateOrUpdateOperation rgOperation = await subscription.GetResourceGroups().CreateOrUpdateAsync("myResourceGroup", new ResourceGroupData(location));
            ResourceGroup resourceGroup = rgOperation.Value;

            // Create AvailabilitySet
            var availabilitySetData = new AvailabilitySetData(location)
            {
                PlatformUpdateDomainCount = 5,
                PlatformFaultDomainCount = 2,
                Sku = new Compute.Models.Sku() { Name = "Aligned" }
            };
            AvailabilitySetCreateOrUpdateOperation asetOperation = await resourceGroup.GetAvailabilitySets().CreateOrUpdateAsync("myAvailabilitySet", availabilitySetData);
            AvailabilitySet availabilitySet = asetOperation.Value;

            // Create VNet
            var vnetData = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = { "10.0.0.0/16" } },
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = "mySubnet",
                        AddressPrefix = "10.0.0.0/24",
                    }
                },
            };
            VirtualNetworkCreateOrUpdateOperation vnetOperation = await resourceGroup.GetVirtualNetworks().CreateOrUpdateAsync("myVirtualNetwork", vnetData);
            VirtualNetwork vnet = vnetOperation.Value;

            // Create Network interface
            var nicData = new NetworkInterfaceData()
            {
                Location = location,
                IpConfigurations =
                {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = "Primary",
                        Primary = true,
                        Subnet = new SubnetData() { Id = vnet.Data.Subnets.First().Id },
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                    }
                }
            };
            NetworkInterfaceCreateOrUpdateOperation nicOperation = await resourceGroup.GetNetworkInterfaces().CreateOrUpdateAsync("myNetworkInterface", nicData);
            NetworkInterface nic = nicOperation.Value;

            var vmData = new VirtualMachineData(location)
            {
                AvailabilitySet = new WritableSubResource() { Id = availabilitySet.Id },
                NetworkProfile = new Compute.Models.NetworkProfile { NetworkInterfaces = { new NetworkInterfaceReference() { Id = nic.Id } } },
                OsProfile = new OSProfile
                {
                    ComputerName = "testVM",
                    AdminUsername = "username",
                    AdminPassword = "(YourPassword)",
                    LinuxConfiguration = new LinuxConfiguration { DisablePasswordAuthentication = false, ProvisionVMAgent = true }
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Offer = "UbuntuServer",
                        Publisher = "Canonical",
                        Sku = "18.04-LTS",
                        Version = "latest"
                    }
                },
                HardwareProfile = new HardwareProfile() { VmSize = VirtualMachineSizeTypes.StandardB1Ms },
            };
            VirtualMachineCreateOrUpdateOperation vmOperation = await resourceGroup.GetVirtualMachines().CreateOrUpdateAsync("myVirtualMachine", vmData);
            VirtualMachine vm = vmOperation.Value;
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CreateVmExtension()
        {
            #region Snippet:Changelog_CreateVMExtension
            var vmExtension = new VirtualMachineExtensionData(Location.WestUS)
            {
                Tags = { { "extensionTag1", "1" }, { "extensionTag2", "2" } },
                Publisher = "Microsoft.Compute",
                TypePropertiesType = "VMAccessAgent",
                TypeHandlerVersion = "2.0",
                AutoUpgradeMinorVersion = true,
                ForceUpdateTag = "RerunExtension",
                Settings = "{}",
                ProtectedSettings = "{}"
            };
            #endregion
        }
    }
}
