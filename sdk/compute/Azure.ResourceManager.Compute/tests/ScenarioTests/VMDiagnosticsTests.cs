// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMDiagnosticsTests : VMTestBase
    {
        public VMDiagnosticsTests(bool isAsync)
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
        //[Trait("Name", "TestVMBootDiagnostics")]
        public async Task TestVMBootDiagnostics()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageReference = await GetPlatformVMImage(useWindowsImage: true);
            string resourceGroupName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountForDisksName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountForBootDiagnosticsName = Recording.GenerateAssetName(TestPrefix);
            string availabilitySetName = Recording.GenerateAssetName(TestPrefix);

            StorageAccount storageAccountForDisks = await CreateStorageAccount(resourceGroupName, storageAccountForDisksName);
            StorageAccount storageAccountForBootDiagnostics = await CreateStorageAccount(resourceGroupName, storageAccountForBootDiagnosticsName);

            VirtualMachine inputVM;
            var returnTwoVm = await CreateVM(resourceGroupName, availabilitySetName, storageAccountForDisks, imageReference,
                (vm) =>
                {
                    vm.DiagnosticsProfile = GetDiagnosticsProfile(storageAccountForBootDiagnosticsName);
                });
            inputVM = returnTwoVm.Input;
            string inputVMName = returnTwoVm.Name;
            VirtualMachine getVMWithInstanceViewResponse = await VirtualMachinesOperations.GetAsync(resourceGroupName, inputVMName);
            ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);
            ValidateBootDiagnosticsInstanceView(getVMWithInstanceViewResponse.InstanceView.BootDiagnostics, hasError: false);

            // Make boot diagnostics encounter an error due to a missing boot diagnostics storage account
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeallocateAsync(resourceGroupName, inputVMName));
            await StorageAccountsOperations.DeleteAsync(resourceGroupName, storageAccountForBootDiagnosticsName);
            //await StorageAccountsClient.DeleteWithHttpMessagesAsync(resourceGroupName, storageAccountForBootDiagnosticsName).GetAwaiter().GetResult();
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartStartAsync(resourceGroupName, inputVMName));

            getVMWithInstanceViewResponse = await VirtualMachinesOperations.GetAsync(resourceGroupName, inputVMName);
            ValidateBootDiagnosticsInstanceView(getVMWithInstanceViewResponse.InstanceView.BootDiagnostics, hasError: true);
        }
    }
}
