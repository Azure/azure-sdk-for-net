// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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
                    CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetDiagnosticsProfile(storageAccountOutput.Name);
                        });

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
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
