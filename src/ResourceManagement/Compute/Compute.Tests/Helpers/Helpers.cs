// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.Azure;
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

        public static string GetVMReferenceId(string subId, string resourceGrpName, string vmName)
        {
            return GetEntityReferenceId(subId, resourceGrpName, ApiConstants.VirtualMachines, vmName);
        }

        private static string GetEntityReferenceId(string subId, string resourceGrpName, string controllerName, string entityName)
        {
            return string.Format("/{0}/{1}/{2}/{3}/{4}/{5}/{6}/{7}",
                ApiConstants.Subscriptions, subId, ApiConstants.ResourceGroups, resourceGrpName,
                ApiConstants.Providers, ApiConstants.ResourceProviderNamespace, controllerName,
                entityName);
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

        public static void ValidateVirtualMachineSizeListResponse(IEnumerable<VirtualMachineSize> vmSizeListResponse)
        {
            var expectedVMSizePropertiesList = new List<VirtualMachineSize>()
            {
                new VirtualMachineSize()
                {
                    Name = "Standard_A0",
                    MemoryInMB = 768,
                    NumberOfCores = 1,
                    OsDiskSizeInMB = 130048,
                    ResourceDiskSizeInMB = 20480,
                    MaxDataDiskCount = 1
                },
                new VirtualMachineSize()
                {
                    Name = "Standard_A1",
                    MemoryInMB = 1792,
                    NumberOfCores = 1,
                    OsDiskSizeInMB = 130048,
                    ResourceDiskSizeInMB = 71680,
                    MaxDataDiskCount = 2
                }
            };

            IEnumerable<VirtualMachineSize> vmSizesPropertyList = vmSizeListResponse;
            Assert.NotNull(vmSizesPropertyList);
            Assert.True(vmSizesPropertyList.Count() > 1, "ListVMSizes should return more than 1 VM sizes");

            VirtualMachineSize expectedVMSizeProperties = expectedVMSizePropertiesList[0];
            VirtualMachineSize vmSizeProperties =
                vmSizesPropertyList.FirstOrDefault(x => x.Name == expectedVMSizeProperties.Name);
            Assert.NotNull(vmSizeProperties);
            CompareVMSizes(expectedVMSizeProperties, vmSizeProperties);

            expectedVMSizeProperties = expectedVMSizePropertiesList[1];
            vmSizeProperties = vmSizesPropertyList.FirstOrDefault(x => x.Name == expectedVMSizeProperties.Name);
            Assert.NotNull(vmSizeProperties);
            CompareVMSizes(expectedVMSizeProperties, vmSizeProperties);
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
