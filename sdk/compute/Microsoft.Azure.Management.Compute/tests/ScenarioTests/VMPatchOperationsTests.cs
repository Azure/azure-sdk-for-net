// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMPatchOperationsTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// POST AssessPatches
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMPatchOperations_AssessPatches()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true, sku: "2016-Datacenter");

                // Create resource group
                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1;

                bool passed = false;
                try
                {
                    // Create Storage Account for this VM
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    VirtualMachine vm1 = CreateVM(
                        rg1Name,
                        asName,
                        storageAccountOutput.Name,
                        imageRef,
                        out inputVM1,
                        hasManagedDisks: true,
                        vmSize: VirtualMachineSizeTypes.StandardDS3V2,
                        createWithPublicIpAddress: true);

                    VirtualMachineAssessPatchesResult assessPatchesResult = m_CrpClient.VirtualMachines.AssessPatches(rg1Name, vm1.Name);

                    Assert.NotNull(assessPatchesResult);
                    Assert.Equal("Succeeded", assessPatchesResult.Status);
                    Assert.NotNull(assessPatchesResult.StartDateTime);

                    passed = true;
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    var deleteRg1Response = m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rg1Name);
                }

                Assert.True(passed);
            }
        }
    }
}
