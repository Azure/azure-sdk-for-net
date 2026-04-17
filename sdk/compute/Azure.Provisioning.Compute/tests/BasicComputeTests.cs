// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Network;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Compute.Tests;

public class BasicComputeTests
{
    internal static Trycep CreateAvailabilitySetTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter availabilitySetName = new(nameof(availabilitySetName), typeof(string))
                {
                    Description = "Availability Set Name",
                    Value = "myAvSet"
                };
                infra.Add(availabilitySetName);

                ProvisioningParameter faultDomainCount = new(nameof(faultDomainCount), typeof(int))
                {
                    Description = "Number of fault domains",
                    Value = 3
                };
                infra.Add(faultDomainCount);

                ProvisioningParameter updateDomainCount = new(nameof(updateDomainCount), typeof(int))
                {
                    Description = "Number of update domains",
                    Value = 20
                };
                infra.Add(updateDomainCount);

                AvailabilitySet avset = new(nameof(avset), AvailabilitySet.ResourceVersions.V2025_04_01)
                {
                    Name = availabilitySetName,
                    Sku = new ComputeSku { Name = "Aligned" },
                    PlatformFaultDomainCount = faultDomainCount,
                    PlatformUpdateDomainCount = updateDomainCount
                };
                infra.Add(avset);

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.compute/availability-set-create-3FDs-20UDs")]
    public async Task CreateAvailabilitySet()
    {
        await using Trycep test = CreateAvailabilitySetTest();
        TestContext.WriteLine(test.Bicep);
        test.Compare(
            """
            @description('Availability Set Name')
            param availabilitySetName string = 'myAvSet'

            @description('Number of fault domains')
            param faultDomainCount int = 3

            @description('Number of update domains')
            param updateDomainCount int = 20

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource avset 'Microsoft.Compute/availabilitySets@2025-04-01' = {
              name: availabilitySetName
              location: location
              properties: {
                platformFaultDomainCount: faultDomainCount
                platformUpdateDomainCount: updateDomainCount
              }
              sku: {
                name: 'Aligned'
              }
            }
            """);
    }

    internal static Trycep CreateSimpleWindowsVmTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                ProvisioningParameter adminUsername = new(nameof(adminUsername), typeof(string))
                {
                    Description = "Username for the Virtual Machine."
                };
                infra.Add(adminUsername);

                ProvisioningParameter adminPassword = new(nameof(adminPassword), typeof(string))
                {
                    Description = "Password for the Virtual Machine.",
                    IsSecure = true
                };
                infra.Add(adminPassword);

                ProvisioningParameter vmSize = new(nameof(vmSize), typeof(string))
                {
                    Description = "Size of the virtual machine.",
                    Value = "Standard_D2s_v5"
                };
                infra.Add(vmSize);

                NetworkSecurityGroup nsg = new(nameof(nsg), NetworkSecurityGroup.ResourceVersions.V2020_05_01)
                {
                    SecurityRules =
                    [
                        new SecurityRule("allowRdp")
                        {
                            Name = "default-allow-3389",
                            Priority = 1000,
                            Access = SecurityRuleAccess.Allow,
                            Direction = SecurityRuleDirection.Inbound,
                            Protocol = SecurityRuleProtocol.Tcp,
                            SourcePortRange = "*",
                            SourceAddressPrefix = "*",
                            DestinationPortRange = "3389",
                            DestinationAddressPrefix = "*"
                        }
                    ]
                };
                infra.Add(nsg);

                VirtualNetwork vnet = new(nameof(vnet), VirtualNetwork.ResourceVersions.V2021_08_01)
                {
                    AddressSpace = new VirtualNetworkAddressSpace
                    {
                        AddressPrefixes = ["10.0.0.0/16"]
                    },
                    Subnets =
                    [
                        new SubnetResource("subnet")
                        {
                            Name = "default",
                            AddressPrefix = "10.0.0.0/24"
                        }
                    ]
                };
                infra.Add(vnet);

                NetworkInterface nic = new(nameof(nic));
                infra.Add(nic);

                VirtualMachine vm = new(nameof(vm), VirtualMachine.ResourceVersions.V2025_04_01)
                {
                    HardwareProfile = new VirtualMachineHardwareProfile
                    {
                        VmSize = vmSize
                    },
                    StorageProfile = new VirtualMachineStorageProfile
                    {
                        ImageReference = new ImageReference
                        {
                            Publisher = "MicrosoftWindowsServer",
                            Offer = "WindowsServer",
                            Sku = "2022-datacenter-azure-edition",
                            Version = "latest"
                        },
                        OSDisk = new VirtualMachineOSDisk
                        {
                            CreateOption = DiskCreateOptionType.FromImage,
                            ManagedDisk = new VirtualMachineManagedDisk
                            {
                                StorageAccountType = StorageAccountType.StandardLrs
                            }
                        }
                    },
                    OSProfile = new VirtualMachineOSProfile
                    {
                        ComputerName = "myVM",
                        AdminUsername = adminUsername,
                        AdminPassword = adminPassword
                    },
                    NetworkProfile = new VirtualMachineNetworkProfile
                    {
                        NetworkInterfaces =
                        [
                            new VirtualMachineNetworkInterfaceReference
                            {
                                Id = nic.Id
                            }
                        ]
                    }
                };
                infra.Add(vm);

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.compute/vm-simple-windows/main.bicep")]
    public async Task CreateSimpleWindowsVm()
    {
        await using Trycep test = CreateSimpleWindowsVmTest();
        TestContext.WriteLine(test.Bicep);
        test.Compare(
            """
            @description('Username for the Virtual Machine.')
            param adminUsername string

            @secure()
            @description('Password for the Virtual Machine.')
            param adminPassword string

            @description('Size of the virtual machine.')
            param vmSize string = 'Standard_D2s_v5'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource nsg 'Microsoft.Network/networkSecurityGroups@2020-05-01' = {
              name: take('nsg-${uniqueString(resourceGroup().id)}', 80)
              location: location
              properties: {
                securityRules: [
                  {
                    name: 'default-allow-3389'
                    properties: {
                      access: 'Allow'
                      destinationAddressPrefix: '*'
                      destinationPortRange: '3389'
                      direction: 'Inbound'
                      priority: 1000
                      protocol: 'Tcp'
                      sourceAddressPrefix: '*'
                      sourcePortRange: '*'
                    }
                  }
                ]
              }
            }

            resource vnet 'Microsoft.Network/virtualNetworks@2021-08-01' = {
              name: take('vnet-${uniqueString(resourceGroup().id)}', 64)
              properties: {
                addressSpace: {
                  addressPrefixes: [
                    '10.0.0.0/16'
                  ]
                }
                subnets: [
                  {
                    name: 'default'
                    properties: {
                      addressPrefix: '10.0.0.0/24'
                    }
                  }
                ]
              }
              location: location
            }

            resource nic 'Microsoft.Network/networkInterfaces@2025-05-01' = {
              name: take('nic-${uniqueString(resourceGroup().id)}', 80)
              location: location
            }

            resource vm 'Microsoft.Compute/virtualMachines@2025-04-01' = {
              name: take('vm${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                hardwareProfile: {
                  vmSize: vmSize
                }
                networkProfile: {
                  networkInterfaces: [
                    {
                      id: nic.id
                    }
                  ]
                }
                osProfile: {
                  computerName: 'myVM'
                  adminUsername: adminUsername
                  adminPassword: adminPassword
                }
                storageProfile: {
                  imageReference: {
                    publisher: 'MicrosoftWindowsServer'
                    offer: 'WindowsServer'
                    sku: '2022-datacenter-azure-edition'
                    version: 'latest'
                  }
                  osDisk: {
                    createOption: 'FromImage'
                    managedDisk: {
                      storageAccountType: 'Standard_LRS'
                    }
                  }
                }
              }
            }
            """);
    }
}
