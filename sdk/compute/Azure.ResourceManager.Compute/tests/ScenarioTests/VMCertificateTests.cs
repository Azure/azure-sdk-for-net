// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMCertificateTests : VMTestBase
    {
        public VMCertificateTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

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
        [Test]
        [Ignore("skip in track 1: TODO: Wait for KMS Client")]
        public async Task TestVMCertificatesOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            Action<VirtualMachine> AddCertificateInfo = SetCertificateInfo;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef, AddCertificateInfo);
            VirtualMachine vm1 = returnTwoVM.Item1;
            inputVM = returnTwoVM.Item2;
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVM.Name));
        }

        private void SetCertificateInfo(VirtualMachine vm)
        {
            SubResource vault = GetDefaultSourceVault();

            VaultCertificate vmCert = GetDefaultVaultCert();

            var secretGroup = new VaultSecretGroup() { SourceVault = vault, VaultCertificates = { vmCert } };

            vm.OsProfile.Secrets.Add(secretGroup);
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
