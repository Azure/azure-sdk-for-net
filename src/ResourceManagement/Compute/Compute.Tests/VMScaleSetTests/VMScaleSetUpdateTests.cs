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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetUpdateTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// ScaleOut VMScaleSet
        /// ScaleIn VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetScalingOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");


                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    // Scale Out VMScaleSet
                    inputVMScaleSet.Sku.Capacity = 3;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    // Scale In VMScaleSet
                    inputVMScaleSet.Sku.Capacity = 1;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Update VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetUpdateOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    inputVMScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1;
                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                            {
                                GetTestVMSSVMExtension(),
                            }
                    };
                    inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
