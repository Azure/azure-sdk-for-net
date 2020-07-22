// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMDiskSizeTests : VMTestBase
    {
        public VMDiskSizeTests(bool isAsync)
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

        [Test]
        public async Task TestVMDiskSizeScenario()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);
            var image = await VirtualMachineImagesOperations.GetAsync(
                this.m_location, imageRef.Publisher, imageRef.Offer, imageRef.Sku, imageRef.Version);
            Assert.True(image != null);

            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef, (vm) =>
             {
                 vm.StorageProfile.OsDisk.DiskSizeGB = 150;
             });
            var vm1 = returnTwoVM.Item1;
            inputVM = returnTwoVM.Item2;
            var getVMResponse = await VirtualMachinesOperations.GetAsync(rgName, inputVM.Name);
            ValidateVM(inputVM, getVMResponse, Helpers.GetVMReferenceId(m_subId, rgName, inputVM.Name));
        }
    }
}
