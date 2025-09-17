// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.ComputeSchedule.Tests.Helpers
{
    public static class ResourceUtils
    {
        public static VirtualMachineData GetBasicWindowsVirtualMachineData(AzureLocation location, string computerName, ResourceIdentifier nicID,
            string adminUsername = "adminuser")
        {
            var vmData = new VirtualMachineData(location)
            {
                AdditionalCapabilities = new()
                {
                    HibernationEnabled = true
                },
                HardwareProfile = new()
                {
                    VmSize = "Standard_D2ads_v5"
                },
                OSProfile = new()
                {
                    AdminUsername = adminUsername,
                    AdminPassword = "Aa1!" + adminUsername,
                    ComputerName = computerName,
                    WindowsConfiguration = new()
                    {
                        ProvisionVmAgent = true,
                        IsAutomaticUpdatesEnabled = true,
                        PatchSettings = new()
                        {
                            PatchMode = WindowsVmGuestPatchMode.AutomaticByPlatform,
                            AssessmentMode = WindowsPatchAssessmentMode.ImageDefault
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
                        OSType = SupportedOperatingSystemType.Windows,
                        Caching = CachingType.ReadWrite,
                        ManagedDisk = new()
                        {
                            StorageAccountType = StorageAccountType.StandardLrs
                        },
                        DeleteOption = DiskDeleteOptionType.Detach,
                        DiskSizeGB = 127
                    },
                    ImageReference = new()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2022-datacenter-azure-edition",
                        Version = "latest",
                    },
                }
            };

            return vmData;
        }
    }
}
