// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
#region Snippet:Using_Statements
using Azure.Core;
using Azure.Identity;
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
        public ArmClient MigrationExample_CreateDefaultClient()
        {
            #region Snippet:Construct_Client
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            #endregion

            return client;
        }

        public ArmClient MigrationExample_CreateClient()
        {
            #region Snippet:Construct_CreateClient
            string clientId = "CLIENT_ID";
            string clientSecret = "CLIENT_SECRET";
            string tenantId = "TENANT_ID";
            string subscription = "SUBSCRIPTION_ID";
            ClientSecretCredential credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            ArmClient client = new ArmClient(credential, subscription);
            #endregion

            return client;
        }

        public async Task<ResourceGroupResource> MigrationExample_CreateRg(ArmClient client)
        {
            #region Snippet:Create_ResourceGroup
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();

            string resourceGroupName = "QuickStartRG";

            ResourceGroupData resourceGroupData = new ResourceGroupData(AzureLocation.WestUS2);
            ArmOperation<ResourceGroupResource> resourceGroupOperation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);
            ResourceGroupResource resourceGroup = resourceGroupOperation.Value;
            #endregion

            return resourceGroup;
        }

        public async Task<AvailabilitySetResource> MigrationExample_CreateAvailabilitySet(ResourceGroupResource resourceGroup)
        {
            #region Snippet:Create_AvailabilitySet
            string availabilitySetName = "QuickstartAvailabilitySet";

            AvailabilitySetData availabilitySetData = new AvailabilitySetData(resourceGroup.Data.Location);
            AvailabilitySetCollection availabilitySets = resourceGroup.GetAvailabilitySets();
            ArmOperation<AvailabilitySetResource> availabilitySetOperation = await availabilitySets.CreateOrUpdateAsync(WaitUntil.Completed, availabilitySetName + "_aSet", availabilitySetData);
            AvailabilitySetResource availabilitySet = availabilitySetOperation.Value;
            #endregion

            return availabilitySet;
        }

        public async Task<VirtualNetworkResource> MigrationExample_CreateVnetSubnet(ResourceGroupResource resourceGroup)
        {
            #region Snippet:Create_Vnet_and_Subnet
            string virtualNetworkName = "QuickstartVnet";
            string subnetName = "QuickstartSubnet";

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
            virtualNetworkData.AddressPrefixes.Add("10.0.0.0/16");
            VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
            ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
            VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
            #endregion

            return virtualNetwork;
        }

        public async Task<NetworkSecurityGroupResource> MigrationExample_Nsg(ResourceGroupResource resourceGroup)
        {
            #region Snippet:Create_NetworkSecurityGroup
            string networkSecurityGroupName = "QuickstartNsg";

            NetworkSecurityGroupData networkSecurityGroupData = new NetworkSecurityGroupData() { Location = resourceGroup.Data.Location };
            NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
            ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkSecurityGroupName, networkSecurityGroupData);
            NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
            #endregion

            return networkSecurityGroup;
        }

        public async Task<NetworkInterfaceResource> MigrationExample_Nic(ResourceGroupResource resourceGroup, VirtualNetworkResource virtualNetwork)
        {
            #region Snippet:Create_NetworkInterface
            string networkInterfaceName = "QuickstartNic";

            NetworkInterfaceIPConfigurationData networkInterfaceIPConfiguration = new NetworkInterfaceIPConfigurationData()
            {
                Name = "Primary",
                Primary = true,
                Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
                PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
            };

            NetworkInterfaceData nicData = new NetworkInterfaceData() { Location = resourceGroup.Data.Location };
            nicData.IPConfigurations.Add(networkInterfaceIPConfiguration);
            NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
            ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
            NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;
            #endregion

            return networkInterface;
        }

        public async Task<VirtualMachineResource> MigrationExample_CreateVm(ResourceGroupResource resourceGroup, AvailabilitySetResource availabilitySet, NetworkInterfaceResource networkInterface)
        {
            #region Snippet:Create_VirtualMachine
            string virtualMachineName = "QuickstartVm";

            VirtualMachineData virutalMachineData = new VirtualMachineData(resourceGroup.Data.Location)
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
            #endregion

            return virtualMachine;
        }

        public async Task<NetworkSecurityGroupResource> MigrationExample_Fluent_CreateNsg(ArmClient client, ResourceGroupResource resourceGroup)
        {
            #region Snippet:Create_Fluent_Nsg
            string networkNsgName = "QuickstartNsg";

            NetworkSecurityGroupData networkNsgData = new NetworkSecurityGroupData()
            {
                Location = resourceGroup.Data.Location,
                SecurityRules =
                    {
                        new SecurityRuleData()
                        {
                            Name = "DenyInternetInComing",
                            Protocol = SecurityRuleProtocol.Asterisk,
                            SourcePortRange = "*",
                            DestinationPortRange = "*",
                            SourceAddressPrefix = "INTERNET",
                            DestinationAddressPrefix = "*",
                            Access = SecurityRuleAccess.Deny,
                            Priority = 100,
                            Direction = SecurityRuleDirection.Inbound,
                        },
                        new SecurityRuleData()
                        {
                            Name = "DenyInternetOutGoing",
                            Protocol = SecurityRuleProtocol.Asterisk,
                            SourcePortRange = "*",
                            DestinationPortRange = "*",
                            SourceAddressPrefix = "*",
                            DestinationAddressPrefix = "internet",
                            Access = SecurityRuleAccess.Deny,
                            Priority = 200,
                            Direction = SecurityRuleDirection.Outbound,
                        }
                    }
            };
            NetworkSecurityGroupCollection networkSecurityGroups = resourceGroup.GetNetworkSecurityGroups();
            ArmOperation<NetworkSecurityGroupResource> networkSecurityGroupOperation = await networkSecurityGroups.CreateOrUpdateAsync(WaitUntil.Completed, networkNsgName, networkNsgData);
            NetworkSecurityGroupResource networkSecurityGroup = networkSecurityGroupOperation.Value;
            #endregion

            return networkSecurityGroup;
        }

        public async Task<VirtualNetworkResource> MigrationExample_Fluent_CreateVnetSubnet(ResourceGroupResource resourceGroup, NetworkSecurityGroupResource networkSecurityGroup)
        {
            #region Snippet:Create_Fluent_Vnet_and_Subnet
            string virtualNetworkName = "QuickstartVnet";
            string subnetName = "QuickstartSubnet";

            VirtualNetworkData virtualNetworkData = new VirtualNetworkData()
                {
                    Location = AzureLocation.EastUS,
                    AddressPrefixes = { "192.168.0.0/16" },
                    Subnets =
                    {
                        new SubnetData()
                            {
                                AddressPrefix = "192.168.2.0/24",
                                Name = subnetName,
                                NetworkSecurityGroup = networkSecurityGroup.Data
                            },
                        new SubnetData()
                            {
                                AddressPrefix = "192.168.1.0/24",
                                Name = "subnet1"
                            }
                    },
                };
            VirtualNetworkCollection virtualNetworks = resourceGroup.GetVirtualNetworks();
            ArmOperation<VirtualNetworkResource> virtualNetworkOperation = await virtualNetworks.CreateOrUpdateAsync(WaitUntil.Completed, virtualNetworkName, virtualNetworkData);
            VirtualNetworkResource virtualNetwork = virtualNetworkOperation.Value;
            #endregion

            return virtualNetwork;
        }

        public async Task<VirtualMachineResource> MigrationExample_Fluent_CreateVm(ResourceGroupResource resourceGroup, VirtualNetworkResource virtualNetwork)
        {
            #region Snippet:Create_Fluent_VirtualMachine
            // Create Nic
            string networkInterfaceName = "QuickstartNic";

            NetworkInterfaceData nicData = new NetworkInterfaceData()
            {
                Location = AzureLocation.EastUS,
                IPConfigurations =
                {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = "default-config",
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        Subnet = new SubnetData() { Id = virtualNetwork.Data.Subnets.First().Id },
                    }
                }
            };
            NetworkInterfaceCollection networkInterfaces = resourceGroup.GetNetworkInterfaces();
            ArmOperation<NetworkInterfaceResource> networkInterfaceOperation = await networkInterfaces.CreateOrUpdateAsync(WaitUntil.Completed, networkInterfaceName, nicData);
            NetworkInterfaceResource networkInterface = networkInterfaceOperation.Value;

            // Create VM
            string virtualMachineName = "QuickstartVm";

            VirtualMachineData virutalMachineData = new VirtualMachineData(AzureLocation.EastUS)
            {
                HardwareProfile = new VirtualMachineHardwareProfile()
                {
                    VmSize = VirtualMachineSizeType.StandardD2V3
                },
                StorageProfile = new VirtualMachineStorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Publisher = "Canonical",
                        Offer = "0001-com-ubuntu-server-jammy",
                        Sku = "22_04-lts-gen2",
                        Version = "latest",
                    },
                    OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Windows,
                        Name = "QuickstartVmOSDisk",
                        Caching = CachingType.ReadOnly,
                        ManagedDisk = new VirtualMachineManagedDisk()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs,
                        },
                    },
                },
                OSProfile = new VirtualMachineOSProfile()
                {
                    AdminUsername = "admin-username",
                    AdminPassword = "admin-p4$$w0rd",
                    ComputerName = "computer-name"
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = networkInterface.Id,
                            Primary = true,
                        }
                    }
                },
            };
            VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
            ArmOperation<VirtualMachineResource> virtualMachineOperation = await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachineName, virutalMachineData);
            VirtualMachineResource virtualMachine = virtualMachineOperation.Value;
            #endregion

            return virtualMachine;
        }

        public async Task<VirtualMachineResource> MigrationExample_UpdateVmByReplace(ResourceGroupResource resourceGroup,VirtualMachineResource virtualMachine, NetworkInterfaceResource networkInterface)
        {
            #region Snippet:UpdateByReplace_Fluent_VirtualMachine
            var virtualMachineDataToModify = new VirtualMachineData(AzureLocation.EastUS)
            {
                HardwareProfile = new VirtualMachineHardwareProfile()
                {
                    VmSize = VirtualMachineSizeType.StandardD2V3
                },
                StorageProfile = new VirtualMachineStorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Publisher = "Canonical",
                        Offer = "0001-com-ubuntu-server-jammy",
                        Sku = "22_04-lts-gen2",
                        Version = "latest",
                    },
                    OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Windows,
                        Name = "QuickstartVmOSDisk",
                        Caching = CachingType.ReadOnly,
                        ManagedDisk = new VirtualMachineManagedDisk()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs,
                        },
                    },
                },
                OSProfile = new VirtualMachineOSProfile()
                {
                    AdminUsername = "admin-username",
                    AdminPassword = "admin-p4$$w0rd",
                    ComputerName = "computer-name"
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = networkInterface.Id,
                            Primary = false,
                        }
                    }
                }
            };
            VirtualMachineCollection virtualMachines = resourceGroup.GetVirtualMachines();
            var virtualMachineModify = (await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachine.Data.Name, virtualMachineDataToModify)).Value;
            #endregion

            return virtualMachineModify;
        }

        public async Task<VirtualMachineResource> MigrationExample_UpdateVmByUpdateAsync(ResourceGroupResource resourceGroup, VirtualMachineResource virtualMachine, NetworkInterfaceResource networkInterface)
        {
            #region Snippet:UpdateByUpdateAsync_Fluent_VirtualMachine
            var patch = new VirtualMachinePatch()
            {
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = networkInterface.Id,
                            Primary = false,
                        }
                    }
                }
            };
            var virtualMachineModify = (await virtualMachine.UpdateAsync(WaitUntil.Completed, patch)).Value;
            #endregion

            return virtualMachineModify;
        }

        public async Task<VirtualMachineResource> MigrationExample_UpdateVmByDataProerty(ResourceGroupResource resourceGroup, VirtualMachineResource virtualMachine, NetworkInterfaceResource networkInterface)
        {
            #region Snippet:UpdateByDataProerty_Fluent_VirtualMachine
            var virtualMachines = resourceGroup.GetVirtualMachines();
            var virtualMachineGet = (await virtualMachines.GetAsync(virtualMachine.Data.Name)).Value;
            virtualMachineGet.Data.NetworkProfile = new VirtualMachineNetworkProfile()
            {
                NetworkInterfaces =
                {
                    new VirtualMachineNetworkInterfaceReference()
                    {
                        Id = networkInterface.Id,
                        Primary = false,
                    }
                }
            };
            var virtualMachineModify = (await virtualMachines.CreateOrUpdateAsync(WaitUntil.Completed, virtualMachine.Data.Name, virtualMachineGet.Data)).Value;
            #endregion

            return virtualMachineModify;
        }

        public async Task MigrationExample_Fluent_ListNetworks(ResourceGroupResource resourceGroup)
        {
            #region Snippet:Create_Fluent_ListNetworks
            await foreach (VirtualNetworkResource virtualNetwork in resourceGroup.GetVirtualNetworks().GetAllAsync())
            {
                // Do something
                Console.WriteLine(virtualNetwork.Data.Name);
            }
            #endregion
        }

        public async Task MigrationExample_Fluent_DeleteNetwork(VirtualNetworkResource virtualNetwork)
        {
            #region Snippet:Create_Fluent_DeleteNetwork
            await virtualNetwork.DeleteAsync(WaitUntil.Completed);
            #endregion
        }
    }
}
