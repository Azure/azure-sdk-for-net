// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMCertificateTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM with certificate
        /// GET VM Model View
        /// Delete VM
        /// Delete RG
        /// </summary>
        [Fact(Skip = "TODO: Wait for KMS Client")]
        public void TestVMCertificatesOperations()
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

                Action<VirtualMachine> AddCertificateInfo = SetCertificateInfo;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM, AddCertificateInfo);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private void SetCertificateInfo(VirtualMachine vm)
        {
            SubResource vault = GetDefaultSourceVault();

            VaultCertificate vmCert = GetDefaultVaultCert();

            var secretGroup = new VaultSecretGroup() {SourceVault = vault, VaultCertificates = new List<VaultCertificate>(){vmCert}};

            vm.OsProfile.Secrets = new List<VaultSecretGroup>() { secretGroup };
        }

        //TODO: Create Source Vault Dynamically
        public SubResource GetDefaultSourceVault()
        {
            return new SubResource()
            {
                Id = @"/subscriptions/05cacd0c-6f9b-492e-b673-d8be41a7644f/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123"
            };
        }

        // TODO: Create VaultCertificate Dynamically
        public VaultCertificate GetDefaultVaultCert()
        {
            return new VaultCertificate() { CertificateUrl = @"https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bdd703272", CertificateStore = "MY" };
        }
    }
}
