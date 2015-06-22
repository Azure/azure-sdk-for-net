//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
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

        public static void DeleteIfExists(this IResourceGroupOperations rgOps, string rgName)
        {
            try
            {
                // Delete RG is not supposed to throw on not found error. It should be 204 response status instead.
                // CSM people confirmed [6/16/15] that's a regression and will be fixed.
                var deleteResourceGroupResponse = rgOps.Delete(rgName);
                Assert.Equal(HttpStatusCode.OK, deleteResourceGroupResponse.StatusCode);
            }
            catch (CloudException ex)
            {
                Assert.Equal("ResourceGroupNotFound", ex.Error.Code);
            }
        }            

        public static void ValidateVirtualMachineSizeListResponse(VirtualMachineSizeListResponse vmSizeListResponse)
        {
            List<VirtualMachineSize> expectedVMSizePropertiesList = new List<VirtualMachineSize>()
            {
                new VirtualMachineSize()
                {
                    Name = "Standard_A0",
                    MemoryInMB = 768,
                    NumberOfCores = 1,
                    OSDiskSizeInMB = 130048,
                    ResourceDiskSizeInMB = 20480,
                    MaxDataDiskCount = 1
                },
                new VirtualMachineSize()
                {
                    Name = "Standard_A1",
                    MemoryInMB = 1792,
                    NumberOfCores = 1,
                    OSDiskSizeInMB = 130048,
                    ResourceDiskSizeInMB = 71680,
                    MaxDataDiskCount = 2
                }
            };

            List<VirtualMachineSize> vmSizesPropertyList = vmSizeListResponse.VirtualMachineSizes.ToList();
            Assert.NotNull(vmSizesPropertyList);
            Assert.True(vmSizesPropertyList.Count > 1, "ListVMSizes should return more than 1 VM sizes");

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
