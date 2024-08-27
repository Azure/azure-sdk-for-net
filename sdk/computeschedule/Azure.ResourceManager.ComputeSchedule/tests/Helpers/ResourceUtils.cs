// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Helpers
{
    public static class ResourceUtils
    {
        public static VirtualMachineData GetBasicLinuxVirtualMachineData(AzureLocation location, string computerName, ResourceIdentifier nicID, string dummySSHKey,
            string adminUsername = "adminuser")
        {
            return new VirtualMachineData(location)
            {
                HardwareProfile = new()
                {
                    VmSize = VirtualMachineSizeType.StandardD4V3
                },
                OSProfile = new()
                {
                    AdminUsername = adminUsername,
                    ComputerName = computerName,
                    LinuxConfiguration = new()
                    {
                        DisablePasswordAuthentication = true,
                        EnableVmAgentPlatformUpdates = true,
                        SshPublicKeys = {
                                    new()
                                    {
                                        Path = $"/home/{adminUsername}/.ssh/authorized_keys",
                                        KeyData = dummySSHKey,
                                    }
                                }
                    }
                },
                NetworkProfile = new VirtualMachineNetworkProfile()
                {
                    NetworkInterfaces =
                    {
                        new VirtualMachineNetworkInterfaceReference()
                        {
                            Id = nicID,
                            Primary = true,
                        }
                    }
                },
                StorageProfile = new()
                {
                    OSDisk = new(DiskCreateOptionType.FromImage)
                    {
                        OSType = SupportedOperatingSystemType.Linux,
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs
                        }
                    },
                    ImageReference = new()
                    {
                        Publisher = "Canonical",
                        Offer = "UbuntuServer",
                        Sku = "16.04-LTS",
                        Version = "latest",
                    }
                }
            };
        }
    }
}
