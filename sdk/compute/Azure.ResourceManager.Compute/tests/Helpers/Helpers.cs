// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
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

        public static void ValidateVirtualMachineSizeListResponse(IEnumerable<VirtualMachineSize> vmSizeListResponse, bool hasAZ = false,
           bool? writeAcceleratorEnabled = null, bool hasDiffDisks = false)
        {
            //VirtualMachineSize can be set
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
                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardM64S.ToString(), 64, 1047552, 2048000, 1024000, 64)
                {
                    //Name = VirtualMachineSizeTypes.StandardM64S,
                    //MemoryInMB = 1024000,
                    //NumberOfCores = 64,
                    //OsDiskSizeInMB = 1047552,
                    //ResourceDiskSizeInMB = 2048000,
                    //MaxDataDiskCount = 64
                });
                expectedVMSizePropertiesList.Add(new VirtualMachineSize (VirtualMachineSizeTypes.StandardM6416Ms.ToString(), 64, 1047552, 2048000, 1792000, 64)
                {
                });
            }
            else if (hasAZ)
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardD1V2.ToString(),1, 1047552, 51200, 3584, 4));

                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardD2V2.ToString(), 2, 102400, 102400, 7168, 8));
            }
            else if (hasDiffDisks)
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardDS1V2.ToString(),1,1047552,7168, 3584, 4));

                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardDS2V2.ToString(),2,1047552,14336, 7168, 8));
            }
            else
            {
                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardA0.ToString(),1,130048,20480, 768, 1));
                expectedVMSizePropertiesList.Add(new VirtualMachineSize(VirtualMachineSizeTypes.StandardA1.ToString(),1,130048,71680, 1792, 2));
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
