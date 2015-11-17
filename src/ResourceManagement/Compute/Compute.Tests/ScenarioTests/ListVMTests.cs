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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class ListVMTests: VMTestBase
    {
        [Fact]
        public void TestListVMInSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rg1Name = baseRGName + "a";
                string rg2Name = baseRGName + "b";
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1, inputVM2;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    var vm1 = CreateVM_NoAsyncTracking(rg1Name, asName, storageAccountOutput, imageRef, out inputVM1);
                    var vm2 = CreateVM_NoAsyncTracking(rg2Name, asName, storageAccountOutput, imageRef, out inputVM2);

                    var listResponse = m_CrpClient.VirtualMachines.ListAll();
                    Assert.True(listResponse.Count() >= 2);
                    Assert.Null(listResponse.NextPageLink);

                    int vmsValidatedCount = 0;

                    foreach (var vm in listResponse)
                    {
                        if (vm.Name == vm1.Name)
                        {
                            ValidateVM(vm, vm1, Helpers.GetVMReferenceId(m_subId, rg1Name, vm1.Name));
                            vmsValidatedCount++;
                        }
                        else if (vm.Name == vm2.Name)
                        {
                            ValidateVM(vm, vm2, Helpers.GetVMReferenceId(m_subId, rg2Name, vm2.Name));
                            vmsValidatedCount++;
                        }
                    }
                    
                    Assert.True(vmsValidatedCount == 2);
                }
                finally
                {
                    // Cleanup the created resources. rg2 first since the VM in it needs to be deleted before the 
                    // storage account, which is in rg1.
                    try
                    {
                        m_ResourcesClient.ResourceGroups.Delete(rg2Name);
                    }
                    finally
                    {
                        m_ResourcesClient.ResourceGroups.Delete(rg1Name);
                    }
                }
            }
        }
    }
}