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
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Compute.Tests
{
    public class VMOperationalTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// Start VM
        /// Stop VM
        /// Restart VM
        /// Deallocate VM
        /// Generalize VM
        /// Capture VM
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMOperations()
        {
            using (MockContext context = MockContext.Start())
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    VirtualMachine vm1 = CreateVM_NoAsyncTracking(rg1Name, asName, storageAccountOutput, imageRef, out inputVM1);

                    m_CrpClient.VirtualMachines.Start(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Restart(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.PowerOff(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Deallocate(rg1Name, vm1.Name);
                    m_CrpClient.VirtualMachines.Generalize(rg1Name, vm1.Name);

                    var captureParams = new VirtualMachineCaptureParameters
                    {
                        DestinationContainerName = TestUtilities.GenerateName(TestPrefix),
                        VhdPrefix = TestUtilities.GenerateName(TestPrefix),
                        OverwriteVhds = true
                    };

                    var captureResponse = m_CrpClient.VirtualMachines.Capture(rg1Name, vm1.Name, captureParams);

                    Assert.NotNull(captureResponse.Properties.Output);
                    string outputAsString = captureResponse.Properties.Output.ToString();
                    Assert.Equal('{', outputAsString[0]);
                    Assert.True(outputAsString.Contains(captureParams.DestinationContainerName.ToLowerInvariant()));
                    Assert.True(outputAsString.ToLowerInvariant().Contains(captureParams.VhdPrefix.ToLowerInvariant()));
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rg1Name);
                }
            }
        }
    }
}