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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;
using Microsoft.Rest.Azure;
using System.Linq;

namespace Compute.Tests
{
    /// <summary>
    /// Covers following Operations:
    /// Create RG
    /// Create Storage Account
    /// Create VM
    /// GET VM Model View
    /// List Usages
    /// Delete VM
    /// Delete RG
    /// List Usages
    /// </summary>
    public class UsageTests : VMTestBase
    {
        [Fact]
        public void TestListUsages()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // List Usages, and do weak validation to assure that some usages were returned.
                    var luResponse = m_CrpClient.Usage.List(vm1.Location);

                    ValidateListUsageResponse(luResponse);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                catch (Exception e)
                {
                    Assert.Null(e);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        public void ValidateListUsageResponse(IPage<Usage> luResponse)
        {
            Assert.NotNull(luResponse);
            Assert.True(luResponse.Count() > 0);

            // Can't do any validation on primitive fields, but will make sure strings are populated and non-null as expected.
            foreach (var usage in luResponse)
            {
                Assert.True(usage.Name.LocalizedValue != null);
                Assert.True(usage.Name.Value != null);
            }
        }
    }
}
