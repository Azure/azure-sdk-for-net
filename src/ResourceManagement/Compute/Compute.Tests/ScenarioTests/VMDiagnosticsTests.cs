﻿//
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
    public class VMDiagnosticsTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM with DiagnosticsProfile
        /// GET VM Model View
        /// GET VM InstanceView
        /// Delete VM
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMBootDiagnostics")]
        public void TestVMBootDiagnostics()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    VirtualMachine inputVM;
                    CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetDiagnosticsProfile(storageAccountOutput.Name);
                        });
                    
                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, "instanceView");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);
                    
                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
