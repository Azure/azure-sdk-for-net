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
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System.Linq;
using System.Net;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.Azure;

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
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;

                Action<VirtualMachine> AddCertificateInfo = SetCertificateInfo;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM, AddCertificateInfo);

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

        public void SetCertificateInfo(VirtualMachine vm)
        {
            SourceVaultReference vault = GetDefaultSourceVault();

            VaultCertificate vmCert = GetDefaultVaultCert();

            var secretGroup = new VaultSecretGroup() {SourceVault = vault, VaultCertificates = new List<VaultCertificate>(){vmCert}};

            vm.OSProfile.Secrets = new List<VaultSecretGroup>() { secretGroup };
        }

        //TODO: Create Source Vault Dynamically
        public SourceVaultReference GetDefaultSourceVault()
        {
            return new SourceVaultReference()
            {
                ReferenceUri = @"/subscriptions/05cacd0c-6f9b-492e-b673-d8be41a7644f/resourceGroups/RgTest1/providers/Microsoft.KeyVault/vaults/TestVault123"
            };
        }

        // TODO: Create VaultCertificate Dynamically
        public VaultCertificate GetDefaultVaultCert()
        {
            return new VaultCertificate() { CertificateUrl = @"https://testvault123.vault.azure.net/secrets/Test1/514ceb769c984379a7e0230bdd703272", CertificateStore = "MY" };
        }
    }
}
