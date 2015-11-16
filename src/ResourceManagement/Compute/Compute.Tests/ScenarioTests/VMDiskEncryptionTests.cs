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

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMDiskEncryptionTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM with DiskEncryptionSettings
        /// GET VM Model View
        /// Delete VM
        /// Delete RG
        /// TODO: Add negative test case validation
        /// </summary>
        [Fact(Skip = "For AutoRest")]
        [Trait("Name", "TestDiskEncryption")]
        public void TestVMDiskEncryption()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    //Create VM with encryptionKey
                    VirtualMachine inputVM1;
                    CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM1,
                        (vm) =>
                        {
                            vm.StorageProfile.OsDisk.EncryptionSettings = GetEncryptionSettings();
                            vm.HardwareProfile.VmSize = "Standard_D1";
                        });
                    //Create VM with encryptionKey and KEK
                    VirtualMachine inputVM2;
                    CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM2,
                        (vm) =>
                        {
                            vm.StorageProfile.OsDisk.EncryptionSettings = GetEncryptionSettings(addKek:true);
                            vm.HardwareProfile.VmSize = "Standard_D1";
                        });
                    
                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM1.Name);
                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM2.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
