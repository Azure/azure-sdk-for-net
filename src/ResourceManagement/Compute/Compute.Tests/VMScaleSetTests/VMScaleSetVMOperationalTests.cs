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
using System.Linq.Expressions;
using System.Net;
using System.Text;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetVMOperationalTests : VMScaleSetVMTestsBase 
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Get VMScaleSetVM Model View
        /// Get VMScaleSetVM Instance View
        /// List VMScaleSetVMs Model View
        /// List VMScaleSetVMs Instance View
        /// Start VMScaleSetVM
        /// Stop VMScaleSetVM
        /// Restart VMScaleSetVM
        /// Deallocate VMScaleSetVM
        /// Delete VMScaleSetVM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetVMOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                const string instanceId = "0";
                VirtualMachineScaleSet inputVMScaleSet;

                bool passed = false;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);
                    
                    var getResponse = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmScaleSet.Name, instanceId);

                    VirtualMachineScaleSetVM vmScaleSetVMModel = GenerateVMScaleSetVMModel(vmScaleSet, instanceId);
                    ValidateVMScaleSetVM(vmScaleSetVMModel, vmScaleSet.Sku.Name, getResponse);

                    var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSetVMs.GetInstanceView(rgName, vmScaleSet.Name, instanceId);
                    Assert.True(getInstanceViewResponse != null, "VMScaleSetVM not returned.");
                    ValidateVMScaleSetVMInstanceView(getInstanceViewResponse);

                    var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                    query.SetFilter(vm => vm.LatestModelApplied == true);
                    var listResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query);
                    Assert.False(listResponse == null, "VMScaleSetVMs not returned");
                    Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);

                    query.Filter = null;
                    query.Expand = "instanceView";
                    listResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query, "instanceView");
                    Assert.False(listResponse == null, "VMScaleSetVMs not returned");
                    Assert.True(listResponse.Count() == inputVMScaleSet.Sku.Capacity);
                    
                    m_CrpClient.VirtualMachineScaleSetVMs.Start(rgName, vmScaleSet.Name, instanceId);
                    // TODO: Re-enable the test once GA
                    //m_CrpClient.VirtualMachineScaleSetVMs.Reimage(rgName, vmScaleSet.Name, instanceId);
                    m_CrpClient.VirtualMachineScaleSetVMs.Restart(rgName, vmScaleSet.Name, instanceId);
                    m_CrpClient.VirtualMachineScaleSetVMs.PowerOff(rgName, vmScaleSet.Name, instanceId);
                    m_CrpClient.VirtualMachineScaleSetVMs.Deallocate(rgName, vmScaleSet.Name, instanceId);
                    m_CrpClient.VirtualMachineScaleSetVMs.Delete(rgName, vmScaleSet.Name, instanceId);

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
    }
}