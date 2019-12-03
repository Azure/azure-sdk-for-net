// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using SqlVirtualMachine.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using Sku = Microsoft.Azure.Management.Storage.Models.Sku;

namespace Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities
{
    public static class VirtualMachineTestBase
    {
        public static NetworkInterface CreateNetworkInterface(SqlVirtualMachineTestContext context, VirtualNetwork virtualNetwork = null, NetworkSecurityGroup networkSecurityGroup = null)
        {
            // Create NIC
            MockClient client = context.client;
            ComputeManagementClient computeClient = client.computeClient;

            // Create virtual network
            string subnetName = context.generateResourceName();
            if (virtualNetwork == null)
            {
                virtualNetwork = CreateVirtualNetwork(context, subnetName: subnetName);
            }
            Subnet subnet = virtualNetwork.Subnets[0];

            // Create pbulic IP address
            PublicIPAddress publicIPAddress = CreatePublicIP(context);

            // Create Network security group
            if(networkSecurityGroup == null)
            {
                networkSecurityGroup = CreateNsg(context);
            }

            NetworkInterface nicParameters = new NetworkInterface()
            {
                Location = context.location,
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = context.generateResourceName(),
                        Subnet = subnet,
                        PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                        PublicIPAddress = publicIPAddress
                    }
                },
                NetworkSecurityGroup = networkSecurityGroup
            };
            string nicName = context.generateResourceName();
            client.networkClient.NetworkInterfaces.CreateOrUpdate(context.resourceGroup.Name, nicName, nicParameters);
            return client.networkClient.NetworkInterfaces.Get(context.resourceGroup.Name, nicName);
        }

        public static VirtualNetwork CreateVirtualNetwork(SqlVirtualMachineTestContext context, VirtualNetwork vnet = null, NetworkSecurityGroup networkSecurityGroup = null, string subnetName = null)
        {
            if (subnetName == null)
            {
                subnetName = context.generateResourceName();
            }
            if ( networkSecurityGroup == null)
            {
                networkSecurityGroup = CreateNsg(context);
            }
            if (vnet == null)
            {
                vnet = new VirtualNetwork()
                {
                    Location = context.location,
                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                            NetworkSecurityGroup = networkSecurityGroup
                        }
                    }
                };
            }
            string vnetName = context.generateResourceName();
            context.client.networkClient.VirtualNetworks.CreateOrUpdate(context.resourceGroup.Name, vnetName, vnet);
            return context.client.networkClient.VirtualNetworks.Get(context.resourceGroup.Name, vnetName);
        }

        public static NetworkSecurityGroup CreateNsg(SqlVirtualMachineTestContext context, NetworkSecurityGroup nsg = null)
        {
            if (nsg == null)
            {
                nsg = new NetworkSecurityGroup(name: context.generateResourceName())
                {
                    Location = context.location,
                    SecurityRules = new List<SecurityRule>(new SecurityRule[]
                    {
                        new SecurityRule()
                        {
                            Name = "default-allow-rdp",
                            Priority = 1000,
                            Protocol = "TCP",
                            Access = "Allow",
                            Direction = "Inbound",
                            SourceAddressPrefix = "*",
                            SourcePortRange = "*",
                            DestinationAddressPrefix = "*",
                            DestinationPortRange = "3389"
                        }
                    })
                };
            }

            context.client.networkClient.NetworkSecurityGroups.CreateOrUpdate(context.resourceGroup.Name, nsg.Name, nsg);
            return context.client.networkClient.NetworkSecurityGroups.Get(context.resourceGroup.Name, nsg.Name);
        }

        public static PublicIPAddress CreatePublicIP(SqlVirtualMachineTestContext context, PublicIPAddress publicIp = null)
        {
            string publicIpName = context.generateResourceName();
            string domainNameLabel = context.generateResourceName();

            if (publicIp == null)
            {
                publicIp = new PublicIPAddress()
                {
                    Location = context.location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"key", "value"}
                    },
                    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel
                    }
                };
            }
            context.client.networkClient.PublicIPAddresses.CreateOrUpdate(context.resourceGroup.Name, publicIpName, publicIp);
            return context.client.networkClient.PublicIPAddresses.Get(context.resourceGroup.Name, publicIpName);
        }

        public static StorageAccount CreateStorageAccount(SqlVirtualMachineTestContext context)
        {
            string storageAccountName = "dotnetclient" + context.generateResourceName().Replace("-", "");
            var stoInput = new StorageAccountCreateParameters
            {
                Location = context.location,
                Sku = new Sku(SkuName.StandardLRS, SkuTier.Standard),
                Kind = "StorageV2"
            };
            context.client.storageClient.StorageAccounts.Create(context.resourceGroup.Name, storageAccountName, stoInput);
            bool created = false;
            while (!created)
            {
                System.Threading.Thread.Sleep(1000);
                var resourceList = context.client.storageClient.StorageAccounts.ListByResourceGroup(context.resourceGroup.Name);
                created =
                    resourceList.Any(
                        t =>
                            StringComparer.OrdinalIgnoreCase.Equals(t.Name, storageAccountName));
            }

            StorageAccount storageAccount = context.client.storageClient.StorageAccounts.GetProperties(context.resourceGroup.Name, storageAccountName);
            storageAccount.Validate();
            return storageAccount;
        }

        public static VirtualMachine CreateVM(SqlVirtualMachineTestContext context, string name = null, NetworkInterface nic = null, AvailabilitySet availabilitySet = null)
        {
            MockClient client = context.client;
            if (nic == null)
            {
                nic = CreateNetworkInterface(context);
            }

            // Get VM image
            string publisher = Constants.publisher;
            string offer = Constants.imageOffer;
            string sku = Constants.imageSku;
            var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineImageResource>();
            query.Top = 1;
            var images = client.computeClient.VirtualMachineImages.List(
                location: context.location, publisherName: publisher, offer: offer, skus: sku,
                odataQuery: query);
            var image = images.First();
            ImageReference imageRef = new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = image.Name
            };

            // Create VM
            if (name == null)
            {
                name = context.generateResourceName();
            }
            VirtualMachine vm = client.computeClient.VirtualMachines.CreateOrUpdate(context.resourceGroup.Name, name, new VirtualMachine
            {
                Location = context.location,
                HardwareProfile = new HardwareProfile
                {
                    VmSize = "Standard_DS13-2_v2"
                },
                NetworkProfile = new NetworkProfile
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>
                    {
                        new NetworkInterfaceReference
                        {
                            Id = nic.Id
                        }
                    }
                },
                StorageProfile = new StorageProfile
                {
                    ImageReference = imageRef,
                    OsDisk = new OSDisk
                    {
                        Caching = CachingTypes.None,
                        WriteAcceleratorEnabled = false,
                        CreateOption = DiskCreateOption.FromImage,
                        ManagedDisk = new ManagedDiskParameters
                        {
                            StorageAccountType = "Standard_LRS"
                        }

                    },
                    DataDisks = new List<DataDisk>()
                    {
                        new DataDisk()
                        {
                            Caching = CachingTypes.None,
                            WriteAcceleratorEnabled = false,
                            CreateOption = DiskCreateOptionTypes.Empty,
                            Lun = 0,
                            DiskSizeGB = 30,
                            ManagedDisk = new ManagedDiskParameters()
                            {
                                StorageAccountType = "Standard_LRS"
                            }
                        }
                    }
                },
                OsProfile = new OSProfile
                {
                    AdminUsername = Constants.adminLogin,
                    AdminPassword = Constants.adminPassword,
                    ComputerName = name,
                    WindowsConfiguration = new WindowsConfiguration()
                    {
                        ProvisionVMAgent = true
                    }
                },
                AvailabilitySet = availabilitySet == null? null : new Compute.Models.SubResource()
                {
                    Id = availabilitySet.Id
                },
                
            });
            vm.Validate();
            return vm;
        }

        public static VirtualMachineExtension CreateDomain(SqlVirtualMachineTestContext context, VirtualMachine vm, string domainName = default(string), string adminLogin = default(string), string adminPassword = default(string))
        {
            IVirtualMachineExtensionsOperations operations = context.client.computeClient.VirtualMachineExtensions;
            if(domainName == null)
            {
                domainName = Constants.domainName;
            }
            if(adminLogin == null)
            {
                adminLogin = Constants.adminLogin;
                adminPassword = Constants.adminPassword;
            }
            VirtualMachineExtension domain = operations.CreateOrUpdate(context.resourceGroup.Name, vm.Name, "InstallDomainController", new VirtualMachineExtension
            {
                Location = context.location,
                VirtualMachineExtensionType = "DSC",

                Publisher = "Microsoft.Powershell",
                TypeHandlerVersion = "2.71",
                AutoUpgradeMinorVersion = true,
                Settings = new DomainSettings
                {
                    ModulesURL = "https://sqlvirtualmachine.blob.core.windows.net/clitest/CreateADPDC.ps1.zip",
                    ConfigurationFunction = "CreateADPDC.ps1\\CreateADPDC",
                    Properties = new DomainProperties
                    {
                        DomainName = domainName + ".com",
                        Admincreds = new DomainAdminCredentials
                        {
                            UserName = adminLogin,
                            Password = "PrivateSettingsRef:adminPassword"
                        }
                    }
                },
                ProtectedSettings = new DomainProtectedSettings
                {
                    Items = new DomainProtectedSettingsItems
                    {
                        AdminPassword = adminPassword
                    }
                }
            });
            
            domain = operations.CreateOrUpdate(context.resourceGroup.Name, vm.Name, "Domain", new VirtualMachineExtension
            {
                Location = context.location,
                VirtualMachineExtensionType = "CustomScriptExtension",

                Publisher = "Microsoft.Compute",
                TypeHandlerVersion = "1.9",
                AutoUpgradeMinorVersion = true,

                Settings = new CustomScriptExtensionSettings
                {
                    FileUris = new List<string>(new string[] { "https://strdstore.blob.core.windows.net/test/UPN.ps1" }),
                    CommandToExecute = "powershell -ExecutionPolicy Unrestricted -File UPN.ps1 " + adminLogin + " " + domainName+ ".com " + Constants.sqlService + " " + adminPassword,
                    ContentVersion = "1.0.0.0"
                }
            });
            return domain;
        }
    }
}
