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

using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;

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
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM);

                    // List Usages, and do weak validation to assure that some usages were returned.
                    var luResponse = m_CrpClient.Usage.List(vm1.Location);

                    ValidateListUsageResponse(luResponse);

                    var lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    Assert.True(lroResponse.Status != OperationStatus.Failed);

                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                }
            }
        }

        public void ValidateListUsageResponse(ListUsagesResponse luResponse)
        {
            Assert.True(luResponse.StatusCode == HttpStatusCode.OK);
            Assert.NotNull(luResponse.Usages);
            Assert.True(luResponse.Usages.Count > 0);

            // Can't do any validation on primitive fields, but will make sure strings are populated and non-null as expected.
            foreach(var usage in luResponse.Usages)
            {
                Assert.True(usage.Name.LocalizedValue != null);
                Assert.True(usage.Name.Value != null);
            }
        }
    }
}
