// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public static class Helpers
    {
        public static string GetAvailabilitySetRef(string subId, string resourceGrpName, string availabilitySetName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.AvailabilitySets, availabilitySetName);
        }

        public static string GetProximityPlacementGroupRef(string subId, string resourceGrpName, string proximityPlacementGroupName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.ProximityPlacementGroups, proximityPlacementGroupName);
        }

        public static string GetDedicatedHostGroupRef(string subId, string resourceGrpName, string dedicatedHostGroupName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.HostGroups, dedicatedHostGroupName);
        }

        public static string GetDedicatedHostRef(string subId, string resourceGrpName, string dedicatedHostGroupName, string dedicatedHostName)
        {
            return GetSubEntityReferenceId(subId, resourceGrpName, ApiConstants.HostGroups, dedicatedHostGroupName, ApiConstants.Hosts, dedicatedHostName);
        }

        public static string GetVMReferenceId(string subId, string resourceGrpName, string vmName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VirtualMachines, vmName);
        }

        public static string GetVMScaleSetReferenceId(string subId, string resourceGrpName, string vmssName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VMScaleSets, vmssName);
        }

        private static string GetEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName);
        }

        private static string GetSubEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName, string subEntityType, string subEntityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}/{8}/{9}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName, subEntityType, subEntityName);
        }

        public static void DeleteIfExists(this IResourceGroupsOperations rgOps, string rgName)
        {
            try
            {
                rgOps.Delete(rgName);
            }
            catch (CloudException)
            {
                // Ignore
            }
        }

        public static void ValidateVirtualMachineSizeListResponse(IEnumerable<VirtualMachineSize> vmSizeListResponse, bool hasAZ = false,
            bool? writeAcceleratorEnabled = null, bool hasDiffDisks = false)
        {
            var expectedVMSizePropertiesList = GetExpectedVirtualMachineSize(hasAZ, writeAcceleratorEnabled, hasDiffDisks);

            IEnumerable<VirtualMachineSize> vmSizesPropertyList = vmSizeListResponse;
            Assert.NotNull(vmSizesPropertyList);
            Assert.True(vmSizesPropertyList.Count() > 1, "ListVMSizes should return more than 1 VM sizes");

            VirtualMachineSize expectedVMSizeProperties = expectedVMSizePropertiesList[0];
            VirtualMachineSize vmSizeProperties =
                vmSizesPropertyList.FirstOrDefault(x => x.Name == expectedVMSizeProperties.Name);
            Assert.NotNull(vmSizeProperties);
            CompareVMSizes(expectedVMSizeProperties, vmSizeProperties);

            expectedVMSizeProperties = expectedVMSizePropertiesList[1];
            vmSizeProperties = vmSizesPropertyList.FirstOrDefault(x => x.Name.Equals(expectedVMSizeProperties.Name, StringComparison.Ordinal));
            Assert.NotNull(vmSizeProperties);
            CompareVMSizes(expectedVMSizeProperties, vmSizeProperties);
        }

        private static List<VirtualMachineSize> GetExpectedVirtualMachineSize(bool hasAZ, bool? writeAcceleratorEnabled = null, bool hasDiffDisks = false)
        {
            var expectedVMSizePropertiesList = new List<VirtualMachineSize>();
            if (writeAcceleratorEnabled.HasValue && writeAcceleratorEnabled.Value)
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardM64s,
                    MemoryInMB = 1024000,
                    NumberOfCores = 64,
                    OsDiskSizeInMB = 1047552,
                    ResourceDiskSizeInMB = 2048000,
                    MaxDataDiskCount = 64
                });
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardM6416ms,
                    MemoryInMB = 1792000,
                    NumberOfCores = 64,
                    OsDiskSizeInMB = 1047552,
                    ResourceDiskSizeInMB = 2048000,
                    MaxDataDiskCount = 64
                });
            }
            else if (hasAZ)
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardD1V2,
                    MemoryInMB = 3584,
                    NumberOfCores = 1,
                    OsDiskSizeInMB = 1047552,
                    ResourceDiskSizeInMB = 51200,
                    MaxDataDiskCount = 4
                });

                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardD2V2,
                    MemoryInMB = 7168,
                    NumberOfCores = 2,
                    OsDiskSizeInMB = 102400,
                    ResourceDiskSizeInMB = 102400,
                    MaxDataDiskCount = 8
                });
            }
            else if (hasDiffDisks)
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardDS1V2,
                    MemoryInMB = 3584,
                    NumberOfCores = 1,
                    OsDiskSizeInMB = 1047552,
                    ResourceDiskSizeInMB = 7168,
                    MaxDataDiskCount = 4
                });

                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                {
                    Name = VirtualMachineSizeTypes.StandardDS2V2,
                    MemoryInMB = 7168,
                    NumberOfCores = 2,
                    OsDiskSizeInMB = 1047552,
                    ResourceDiskSizeInMB = 14336,
                    MaxDataDiskCount = 8
                });
            }
            else
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                    {
                        Name = VirtualMachineSizeTypes.StandardA0,
                        MemoryInMB = 768,
                        NumberOfCores = 1,
                        OsDiskSizeInMB = 130048,
                        ResourceDiskSizeInMB = 20480,
                        MaxDataDiskCount = 1
                    });
                expectedVMSizePropertiesList.Add(new VirtualMachineSize()
                    {
                        Name = VirtualMachineSizeTypes.StandardA1,
                        MemoryInMB = 1792,
                        NumberOfCores = 1,
                        OsDiskSizeInMB = 130048,
                        ResourceDiskSizeInMB = 71680,
                        MaxDataDiskCount = 2
                    });
            }


            return expectedVMSizePropertiesList;
        }

        private static void CompareVMSizes(VirtualMachineSize expectedVMSize, VirtualMachineSize vmSize)
        {
            Assert.True(expectedVMSize.MemoryInMB == vmSize.MemoryInMB,
                string.Format("memoryInMB is correct for VMSize: {0}", expectedVMSize.Name));
            Assert.True(expectedVMSize.NumberOfCores == vmSize.NumberOfCores,
                string.Format("numberOfCores is correct for VMSize: {0}", expectedVMSize.Name));
            // TODO: Will re-enable after CRP rollout
            //Assert.True(expectedVMSize.OSDiskSizeInMB == vmSize.OSDiskSizeInMB,
            //    string.Format("osDiskSizeInMB is correct for VMSize: {0}", expectedVMSize.Name));
            Assert.True(expectedVMSize.ResourceDiskSizeInMB == vmSize.ResourceDiskSizeInMB,
                string.Format("resourceDiskSizeInMB is correct for VMSize: {0}", expectedVMSize.Name));
            Assert.True(expectedVMSize.MaxDataDiskCount == vmSize.MaxDataDiskCount,
                string.Format("maxDataDiskCount is correct for VMSize: {0}", expectedVMSize.Name));
        }
    }
}
