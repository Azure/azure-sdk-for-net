// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ComputeFleet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.ComputeFleet.Tests
{
    public class ComputeFleetTestBase: ComputeFleetManagementTestBase
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        public ComputeFleetTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        public ComputeFleetTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected async Task<ComputeFleetCollection> GetComputeFleetCollectionAsync()
        {
            _genericResourceCollection = Client.GetGenericResources();
            _resourceGroup = await CreateResourceGroup(DefaultSubscription);
            return _resourceGroup.GetComputeFleets();
        }

        #region ComputeFleetData

        public static ComputeFleetData GetBasicComputeFleetData(
            AzureLocation location,
            string computerNamePrefix,
            ResourceIdentifier subnetId,
            int capacity = 2,
            string adminUsername = "adminuser",
            string allocationStrategy = "LowestPrice")
        {
            var storageProfile = new ComputeFleetVmssStorageProfile()
            {
                OSDisk = new(ComputeFleetDiskCreateOptionType.FromImage)
                {
                    Caching = ComputeFleetCachingType.ReadWrite,
                    ManagedDisk = new()
                    {
                        StorageAccountType = ComputeFleetStorageAccountType.StandardLrs
                    }
                },
                ImageReference = new()
                {
                    Publisher = "Canonical",
                    Offer = "UbuntuServer",
                    Sku = "16.04-LTS",
                    Version = "latest"
                }
            };

            var osProfile = new ComputeFleetVmssOSProfile()
            {
                ComputerNamePrefix = computerNamePrefix,
                AdminUsername = adminUsername,
                LinuxConfiguration = new ComputeFleetLinuxConfiguration()
                {
                    IsPasswordAuthenticationDisabled = true,
                    Ssh = new()
                    {
                        PublicKeys =
                        {
                            new()
                            {
                                Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                KeyData = dummySSHKey
                            }
                        }
                    }
                }
            };

            var computeFleetVmssIPConfiguration = new ComputeFleetVmssIPConfiguration()
            {
                Name = "internalIpConfig",
                Properties = new()
                {
                    Subnet = new()
                    {
                        Id = subnetId
                    }
                }
            };

            var computefleetVmssNetworkConfiguration = new ComputeFleetVmssNetworkConfiguration()
            {
                Name = "exampleNic",
                Properties = new ComputeFleetVmssNetworkConfigurationProperties(
                    new List<ComputeFleetVmssIPConfiguration>()
                    {
                        computeFleetVmssIPConfiguration
                    })
                {
                    IsPrimary = true,
                    IsAcceleratedNetworkingEnabled = false
                }
            };

            var networkProfile = new ComputeFleetVmssNetworkProfile()
            {
                NetworkInterfaceConfigurations =
                {
                    computefleetVmssNetworkConfiguration
                },
                NetworkApiVersion = "2022-07-01"
            };

            var computeProfile = new ComputeFleetComputeProfile()
            {
                ComputeApiVersion = "2023-09-01",
                PlatformFaultDomainCount = 1,
                BaseVirtualMachineProfile = new()
                {
                    StorageProfile = storageProfile,
                    OSProfile = osProfile,
                    NetworkProfile = networkProfile
                }
            };

            return new ComputeFleetData(location:location)
            {
                Properties = new ComputeFleetProperties(
                    vmSizesProfile: new List<ComputeFleetVmSizeProfile>() {
                        new("Standard_D2s_v3"),
                        new("Standard_D4s_v3"),
                        new("Standard_E2s_v3")
                    },
                    computeProfile: computeProfile)
                {
                    SpotPriorityProfile = new()
                    {
                        Capacity = capacity,
                        AllocationStrategy = allocationStrategy,
                        EvictionPolicy = "Delete",
                        IsMaintainEnabled = false
                    },
                    RegularPriorityProfile = new()
                    {
                        Capacity = capacity,
                        MinCapacity = capacity,
                        AllocationStrategy = allocationStrategy,
                    }
                }
            };
        }
        #endregion
    }
}
