// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMDiskEncryptionTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM with DiskEncryptionSettings
        /// GET VM Model View
        /// Delete VM
        /// Delete RG
        /// TODO: Add negative test case validation
        /// </summary>
        [Fact]
        [Trait("Name", "TestDiskEncryption")]
        public void TestVMDiskEncryption()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    //Create VM with encryptionKey
                    VirtualMachine inputVM1;
                    CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM1,
                        (vm) =>
                        {
                            vm.StorageProfile.OsDisk.EncryptionSettings = GetEncryptionSettings();
                            vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardD1;
                        }, waitForCompletion: false);
                    //Create VM with encryptionKey and KEK
                    VirtualMachine inputVM2;
                    CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM2,
                        (vm) =>
                        {
                            vm.StorageProfile.OsDisk.EncryptionSettings = GetEncryptionSettings(addKek:true);
                            vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardD1;
                        }, waitForCompletion: false);
                    
                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM1.Name);
                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM2.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
