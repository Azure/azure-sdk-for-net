// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMDiagnosticsTests : VMTestBase
    {
        /// <summary>
        /// 1) Create a VM with the storage account for disks different from the storage account for boot diagnostics
        /// 2) Validate InstanceView
        /// 3) Deallocate the VM and delete the storage account for boot diagnostics. Start the VM
        /// 4) Validate that the error information for the missing boot diagnostics storage account is available
        ///    in BootDiagnosticsInstanceView
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMBootDiagnostics")]
        public void TestVMBootDiagnostics()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageReference = GetPlatformVMImage(useWindowsImage: true);
                string resourceGroupName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountForBootDiagnosticsName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(resourceGroupName, storageAccountForDisksName);
                    StorageAccount storageAccountForBootDiagnostics = CreateStorageAccount(resourceGroupName, storageAccountForBootDiagnosticsName);

                    VirtualMachine inputVM;
                    CreateVM(resourceGroupName, availabilitySetName, storageAccountForDisks, imageReference, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetDiagnosticsProfile(storageAccountForBootDiagnosticsName);
                        });

                    VirtualMachine getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(resourceGroupName, inputVM.Name, InstanceViewTypes.InstanceView);
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);
                    ValidateBootDiagnosticsInstanceView(getVMWithInstanceViewResponse.InstanceView.BootDiagnostics, hasError: false);
                    RetrieveBootDiagnosticsDataResult bootDiagnosticsData =
                        m_CrpClient.VirtualMachines.RetrieveBootDiagnosticsData(resourceGroupName, inputVM.Name);
                    ValidateBootDiagnosticsData(bootDiagnosticsData);

                    // Make boot diagnostics encounter an error due to a missing boot diagnostics storage account
                    m_CrpClient.VirtualMachines.Deallocate(resourceGroupName, inputVM.Name);
                    m_SrpClient.StorageAccounts.DeleteWithHttpMessagesAsync(resourceGroupName, storageAccountForBootDiagnosticsName).GetAwaiter().GetResult();
                    m_CrpClient.VirtualMachines.Start(resourceGroupName, inputVM.Name);

                    getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(resourceGroupName, inputVM.Name, InstanceViewTypes.InstanceView);
                    ValidateBootDiagnosticsInstanceView(getVMWithInstanceViewResponse.InstanceView.BootDiagnostics, hasError: true);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }

        [Fact]
        [Trait("Name", "TestVMManagedBootDiagnostics")]
        public void TestVMManagedBootDiagnostics()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageReference = GetPlatformVMImage(useWindowsImage: true);
                string resourceGroupName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(resourceGroupName, storageAccountForDisksName);

                    VirtualMachine inputVM;
                    CreateVM(resourceGroupName, availabilitySetName, storageAccountForDisks, imageReference, out inputVM,
                        (vm) =>
                        {
                            vm.DiagnosticsProfile = GetManagedDiagnosticsProfile();
                        }, hasManagedDisks: true);

                    VirtualMachine getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(resourceGroupName, inputVM.Name, InstanceViewTypes.InstanceView);
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks: true);
                    ValidateBootDiagnosticsInstanceView(getVMWithInstanceViewResponse.InstanceView.BootDiagnostics, hasError: false, enabledWithManagedBootDiagnostics: true);
                    RetrieveBootDiagnosticsDataResult bootDiagnosticsData =
                        m_CrpClient.VirtualMachines.RetrieveBootDiagnosticsData(resourceGroupName, inputVM.Name);
                    ValidateBootDiagnosticsData(bootDiagnosticsData);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}

