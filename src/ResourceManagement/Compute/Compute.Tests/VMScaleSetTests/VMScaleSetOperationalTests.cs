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
    public class VMScaleSetOperationalTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSet
        /// Stop VMScaleSet
        /// Restart VMScaleSet
        /// Deallocate VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    // TODO: AutoRest skips the following methods - Start, Restart, PowerOff, Deallocate
                    m_CrpClient.VirtualMachineScaleSets.Start(rgName, vmScaleSet.Name);
                    // TODO: Re-enable the test once GA
                    //m_CrpClient.VirtualMachineScaleSets.Reimage(rgName, vmScaleSet.Name);
                    m_CrpClient.VirtualMachineScaleSets.Restart(rgName, vmScaleSet.Name);
                    m_CrpClient.VirtualMachineScaleSets.PowerOff(rgName, vmScaleSet.Name);
                    m_CrpClient.VirtualMachineScaleSets.Deallocate(rgName, vmScaleSet.Name);
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);

                    passed = true;
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }

                Assert.True(passed);
            }
        }
        
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Start VMScaleSet Instances
        /// Stop VMScaleSet Instance
        /// ManualUpgrade VMScaleSet Instance
        /// Restart VMScaleSet Instance
        /// Deallocate VMScaleSet Instance
        /// Delete VMScaleSet Instance
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetBatchOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput, 
                        imageRef: imageRef, 
                        inputVMScaleSet: out inputVMScaleSet, 
                        vmScaleSetCustomizer: 
                            (virtualMachineScaleSet) => virtualMachineScaleSet.UpgradePolicy = new UpgradePolicy { Mode = UpgradeMode.Manual });

                    var virtualMachineScaleSetInstanceIDs = new List<string>() {"0", "1"};

                    m_CrpClient.VirtualMachineScaleSets.Start(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    virtualMachineScaleSetInstanceIDs = new List<string>() { "0" };
                    m_CrpClient.VirtualMachineScaleSets.PowerOff(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.UpdateInstances(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    virtualMachineScaleSetInstanceIDs = new List<string>() { "1" };
                    m_CrpClient.VirtualMachineScaleSets.Restart(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.Deallocate(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);
                    m_CrpClient.VirtualMachineScaleSets.DeleteInstances(rgName, vmScaleSet.Name, virtualMachineScaleSetInstanceIDs);

                    passed = true;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

                Assert.True(passed);
            }
        }
    }
}