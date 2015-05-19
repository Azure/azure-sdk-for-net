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
using Microsoft.Azure.Test;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage.Models;
using Xunit;

namespace Compute.Tests
{
    public class ListVMTests: VMTestBase
    {
        [Fact]
        public void TestListVMInSubscription()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                string imgRefId = GetPlatformOSImage(useWindowsImage: true);

                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;
                string rg2Name = TestUtilities.GenerateName(TestPrefix) + 2;
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1, inputVM2;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    var vm1 = CreateVM(rg1Name, asName, storageAccountOutput, imgRefId, out inputVM1);
                    var vm2 = CreateVM(rg2Name, asName, storageAccountOutput, imgRefId, out inputVM2);

                    var listResponse = m_CrpClient.VirtualMachines.ListAll(new ListParameters());
                    Assert.True(listResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(listResponse.VirtualMachines.Count >= 2);
                    Assert.Null(listResponse.NextLink);

                    int vmsValidatedCount = 0;

                    foreach (var vm in listResponse.VirtualMachines)
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
                    // Cleanup the created resources
                    try
                    {
                        var deleteRg1Response = m_ResourcesClient.ResourceGroups.Delete(rg1Name);
                        Assert.True(deleteRg1Response.StatusCode == HttpStatusCode.OK);
                    }
                    finally
                    {
                        var deleteRg2Response = m_ResourcesClient.ResourceGroups.Delete(rg2Name);
                        Assert.True(deleteRg2Response.StatusCode == HttpStatusCode.OK);
                    }
                }
            }
        }
    }
}