// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SqlVirtualMachine.Models;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.SqlVirtualMachine.Tests
{
    public class SqlVirtualMachineManagementTestBase : ManagementRecordedTestBase<SqlVirtualMachineManagementTestEnvironment>
    {
        protected const string ImageOffer = "SQL2017-WS2016";
        protected const string DomainName = "Domain";

        protected const string AdminLogin = "myvmadmin";
        protected const string AdminPassword = "sql@zure123!";

        protected ArmClient Client { get; private set; }

        protected SubscriptionResource Subscription { get; set; }

        protected SqlVirtualMachineManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            JsonPathSanitizers.Add("$..storageAccountPrimaryKey");
        }

        protected SqlVirtualMachineManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            JsonPathSanitizers.Add("$..storageAccountPrimaryKey");
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgName, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<string> CreateStorageAccountAsync(ResourceGroupResource rg, string storageAccountName)
        {
            StorageAccountCreateOrUpdateContent input = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.StorageV2, AzureLocation.WestUS);
            var lro = await rg.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, storageAccountName, input);
            var storageAccount = lro.Value;
            return (await storageAccount.GetKeysAsync().FirstOrDefaultAsync(_ => true)).Value;
        }

        protected async Task<SqlVmGroupResource> CreateSqlVmGroupAsync(ResourceGroupResource rg, string sqlVmGroupName, string storageAccountName, string storageAccountKey)
        {
            var lro = await rg.GetSqlVmGroups().CreateOrUpdateAsync(WaitUntil.Completed, sqlVmGroupName, new SqlVmGroupData(rg.Data.Location)
            {
                SqlImageOffer = ImageOffer,
                SqlImageSku = SqlVmGroupImageSku.Enterprise,
                WindowsServerFailoverClusterDomainProfile = new WindowsServerFailoverClusterDomainProfile()
                {
                    SqlServiceAccount = GetUsername("sqlService", DomainName),
                    ClusterOperatorAccount = GetUsername(AdminLogin, DomainName),
                    DomainFqdn = $"{DomainName}.com",
                    StorageAccountUri = new Uri($"https://{storageAccountName}.blob.core.windows.net/"),
                    StorageAccountPrimaryKey = storageAccountKey,
                    ClusterSubnetType = SqlVmClusterSubnetType.SingleSubnet,
                }
            });
            return lro.Value;
        }

        protected async Task<SqlVmResource> CreateSqlVmAsync(ResourceGroupResource rg, ResourceIdentifier vmIdentifier)
        {
            SqlVmResource sqlVm = (await rg.GetSqlVms().CreateOrUpdateAsync(WaitUntil.Completed, vmIdentifier.Name, new SqlVmData(rg.Data.Location)
            {
                VirtualMachineResourceId = vmIdentifier,
                SqlServerLicenseType = SqlServerLicenseType.Payg,
                SqlManagement = SqlManagementMode.Full,
                SqlImageSku = SqlImageSku.Enterprise,
                SqlImageOffer = ImageOffer,
                ServerConfigurationsManagementSettings = new SqlServerConfigurationsManagementSettings()
                {
                    SqlConnectivityUpdateSettings = new SqlConnectivityUpdateSettings()
                    {
                        SqlAuthUpdateUserName = "sqlLogin",
                        SqlAuthUpdatePassword = AdminPassword,
                        ConnectivityType = SqlServerConnectivityType.Private,
                        Port = 1433
                    },
                    SqlStorageUpdateSettings = new SqlStorageUpdateSettings()
                    {
                        DiskCount = 1,
                        DiskConfigurationType = SqlVmDiskConfigurationType.New,
                        StartingDeviceId = 2
                    },
                    SqlWorkloadTypeUpdateSettings = new SqlWorkloadTypeUpdateSettings()
                    {
                        SqlWorkloadType = SqlWorkloadType.Oltp
                    }
                },
                AutoPatchingSettings = new SqlVmAutoPatchingSettings()
                {
                    IsEnabled = false
                }
            })).Value;
            return sqlVm;
        }

        protected async Task<VirtualMachineResource> CreateVmAsync(ResourceGroupResource rg, NetworkSecurityGroupResource nsg, NetworkInterfaceResource nic, string vmName)
        {
            VirtualMachineResource vm = (await rg.GetVirtualMachines().CreateOrUpdateAsync(WaitUntil.Completed, vmName, new VirtualMachineData(rg.Data.Location)
            {
                HardwareProfile = new VirtualMachineHardwareProfile
                {
                    VmSize = VirtualMachineSizeType.StandardDS132V2
                },
                NetworkProfile = new VirtualMachineNetworkProfile
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference
                        {
                            Id = nic.Id
                        }
                    }
                },
                StorageProfile = new VirtualMachineStorageProfile
                {
                    ImageReference = new ImageReference
                    {
                        Publisher = "MicrosoftSQLServer",
                        Offer = ImageOffer,
                        Sku = "Enterprise",
                        Version = "latest"
                    },
                    OSDisk = new VirtualMachineOSDisk(DiskCreateOptionType.FromImage)
                    {
                        Caching = CachingType.None,
                        ManagedDisk = new VirtualMachineManagedDisk
                        {
                            StorageAccountType = StorageAccountType.StandardLrs,
                        },
                        WriteAcceleratorEnabled = false
                    },
                    DataDisks =
                    {
                        new VirtualMachineDataDisk(0, DiskCreateOptionType.Empty)
                        {
                            Caching = CachingType.None,
                            WriteAcceleratorEnabled = false,
                            DiskSizeGB = 30,
                            ManagedDisk = new VirtualMachineManagedDisk
                            {
                                StorageAccountType = StorageAccountType.StandardLrs,
                            },
                        }
                    }
                },
                OSProfile = new VirtualMachineOSProfile
                {
                    AdminUsername = AdminLogin,
                    AdminPassword = AdminPassword,
                    ComputerName = vmName,
                    WindowsConfiguration = new WindowsConfiguration
                    {
                        ProvisionVmAgent = true
                    }
                }
            })).Value;
            return vm;
        }

        protected async Task<NetworkInterfaceResource> CreateNetworkInterfaceAsync(ResourceGroupResource rg, VirtualNetworkResource vnet, NetworkSecurityGroupResource nsg, string publicIPAddressName, string domainName, string nicName, string nicIPConfName)
        {
            SubnetData subnetData = vnet.Data.Subnets.First();
            PublicIPAddressResource publicIPAddress = (await rg.GetPublicIPAddresses().CreateOrUpdateAsync(WaitUntil.Completed, publicIPAddressName, new PublicIPAddressData()
            {
                Location = rg.Data.Location,
                Tags =
                {
                    { "key", "value" }
                },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainName
                }
            })).Value;

            NetworkInterfaceResource nic = (await rg.GetNetworkInterfaces().CreateOrUpdateAsync(WaitUntil.Completed, nicName, new NetworkInterfaceData()
            {
                Location = rg.Data.Location,
                IPConfigurations =
                {
                    new NetworkInterfaceIPConfigurationData()
                    {
                        Name = nicIPConfName,
                        Subnet = subnetData,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        PublicIPAddress = publicIPAddress.Data
                    }
                },
                NetworkSecurityGroup = nsg.Data
            })).Value;
            return nic;
        }

        protected async Task<VirtualNetworkResource> CreateVirtualNetworkAsync(ResourceGroupResource rg, NetworkSecurityGroupResource nsg, string vnetName, string subnetName)
        {
            VirtualNetworkResource vnet = (await rg.GetVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, vnetName, new VirtualNetworkData()
            {
                Location = rg.Data.Location,
                AddressPrefixes = { "10.0.0.0/16" },
                Subnets =
                {
                    new SubnetData()
                    {
                        Name = subnetName,
                        AddressPrefix = "10.0.0.0/24",
                        NetworkSecurityGroup = nsg.Data
                    }
                }
            })).Value;
            return vnet;
        }

        protected async Task<NetworkSecurityGroupResource> CreateNetworkSecurityGroupAsync(ResourceGroupResource rg, string nsgName)
        {
            NetworkSecurityGroupResource nsg = (await rg.GetNetworkSecurityGroups().CreateOrUpdateAsync(WaitUntil.Completed, nsgName, new NetworkSecurityGroupData()
            {
                Location = rg.Data.Location,
                SecurityRules =
                {
                    new SecurityRuleData()
                    {
                        Name = "default-allow-rdp",
                        Priority = 1000,
                        Protocol = SecurityRuleProtocol.Tcp,
                        Access = SecurityRuleAccess.Allow,
                        Direction = SecurityRuleDirection.Inbound,
                        Description = "Allow inbound traffic from VNET",
                        SourceAddressPrefix = "*",
                        SourcePortRange = "*",
                        DestinationAddressPrefix = "*",
                        DestinationPortRange = "*"
                    }
                }
            })).Value;
            return nsg;
        }

        private static string GetUsername(string username, string domain)
        {
            return username + "@" + domain + ".com";
        }
    }
}
