// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class VMOperationalTests : VMTestBase
    {
        public VMOperationalTests(bool isAsync)
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

        public class Image
        {
            //[JsonProperty("uri")]
            public string Uri { get; set; }
        }

        public class OSDisk
        {
            //[JsonProperty("image")]
            public Image Image { get; set; }
        }

        public class StorageProfile
        {
            //[JsonProperty("osDisk")]
            public OSDisk OSDisk { get; set; }
        }

        public class Properties
        {
            //[JsonProperty("storageProfile")]
            public StorageProfile StorageProfile { get; set; }
        }

        public class Resource
        {
            //[JsonProperty("properties")]
            public Properties Properties { get; set; }
        }

        public class Template
        {
            //[JsonProperty("resources")]
            public List<Resource> Resources { get; set; }
        }

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
        /// RunCommand VM
        /// Deallocate VM
        /// Generalize VM
        /// Capture VM
        /// Delete RG
        /// </summary>
        [Test]
        [Ignore("need to be tested by compute team")]
        public async Task TestVMOperations()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string as1Name = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

            var returnTwovm = await CreateVM(rg1Name, as1Name, storageAccountOutput, imageRef);
            var vm1 = returnTwovm.Item1;
            inputVM1 = returnTwovm.Item2;
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartStartAsync(rg1Name, vm1.Name));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartRedeployAsync(rg1Name, vm1.Name));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartRestartAsync(rg1Name, vm1.Name));

            var runCommandImput = new RunCommandInput("RunPowerShellScript")
            {
                Script = {
                            "param(",
                            "    [string]$arg1,",
                            "    [string]$arg2",
                            ")",
                            "echo This is a sample script with parameters $arg1 $arg2"
                        },
                Parameters = {
                            new RunCommandInputParameter("arg1","value1"),
                            new RunCommandInputParameter("arg2","value2"),
                        }
            };
            RunCommandResult result = (await WaitForCompletionAsync(await VirtualMachinesOperations.StartRunCommandAsync(rg1Name, vm1.Name, runCommandImput))).Value;
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.True(result.Value.Count > 0);

            await WaitForCompletionAsync(await VirtualMachinesOperations.StartPowerOffAsync(rg1Name, vm1.Name));
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeallocateAsync(rg1Name, vm1.Name));
            await VirtualMachinesOperations.GeneralizeAsync(rg1Name, vm1.Name);

            VirtualMachine ephemeralVM;
            string as2Name = as1Name + "_ephemeral";
            var returnTwoVM = await CreateVM(rg1Name, as2Name, storageAccountName, imageRef, hasManagedDisks: true, hasDiffDisks: true, vmSize: VirtualMachineSizeTypes.StandardDS5V2.ToString(),
                osDiskStorageAccountType: StorageAccountTypes.StandardLRS.ToString(), dataDiskStorageAccountType: StorageAccountTypes.StandardLRS.ToString());
            ephemeralVM = returnTwoVM.Item2;
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartReimageAsync(rg1Name, ephemeralVM.Name));
            var captureParams = new VirtualMachineCaptureParameters(Recording.GenerateAssetName(TestPrefix), Recording.GenerateAssetName(TestPrefix), true);

            var captureResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCaptureAsync(rg1Name, vm1.Name, captureParams));

            Assert.NotNull(captureResponse);
            Assert.True(captureResponse.Value.Resources.Count > 0);
            string resource = captureResponse.Value.Resources[0].ToString();
            Assert.IsTrue(resource.ToLowerInvariant().Contains(captureParams.DestinationContainerName.ToLowerInvariant()));
            Assert.IsTrue(resource.ToLowerInvariant().Contains(captureParams.VhdPrefix.ToLowerInvariant()));
            Resource template = JsonSerializer.Deserialize<Resource>(resource);
            string imageUri = template.Properties.StorageProfile.OSDisk.Image.Uri;
            Assert.False(string.IsNullOrEmpty(imageUri));

            // Create 3rd VM from the captured image
            // TODO : Provisioning Time-out Issues
            VirtualMachine inputVM2;
            string as3Name = as1Name + "b";
            returnTwovm = await CreateVM(rg1Name, as3Name, storageAccountOutput, imageRef,
                vm =>
                {
                    vm.StorageProfile.ImageReference = null;
                    vm.StorageProfile.OsDisk.Image = new VirtualHardDisk { Uri = imageUri };
                    vm.StorageProfile.OsDisk.Vhd.Uri = vm.StorageProfile.OsDisk.Vhd.Uri.Replace(".vhd", "copy.vhd");
                    vm.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
                }, false, false);
            var vm3 = returnTwovm.Item1;
            inputVM2 = returnTwovm.Item2;
            Assert.True(vm3.StorageProfile.OsDisk.Image.Uri == imageUri);
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// Redeploy VM
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMOperations_Redeploy()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1;

            bool passed = false;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

            var returnTwovm = await CreateVM(rg1Name, asName, storageAccountOutput, imageRef);
            VirtualMachine vm1 = returnTwovm.Item1;
            inputVM1 = returnTwovm.Item2;
            var redeployOperationResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartRedeployAsync(rg1Name, vm1.Name));
            //.BeginRedeployWithHttpMessagesAsync
            //Assert.Equal(HttpStatusCode.Accepted, redeployOperationResponse.Result.Response.StatusCode);
            var lroResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartRedeployAsync(rg1Name,
                vm1.Name));
            //var lroResponse = await VirtualMachinesClient.StartRedeployAsync(rg1Name,
            //    vm1.Name).GetAwaiter().GetResult();
            //Assert.Equal(ComputeOperationStatus.Succeeded, lroResponse.Status);

            passed = true;
            Assert.True(passed);
        }
        [Test]
        public async Task TestVMOperations_Reapply()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1;

            bool passed = false;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

            var returnTwovm = await CreateVM(rg1Name, asName, storageAccountOutput, imageRef);
            VirtualMachine vm1 = returnTwovm.Item1;
            inputVM1 = returnTwovm.Item2;
            var reapplyperationResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartReapplyAsync(rg1Name, vm1.Name));
            var lroResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartReapplyAsync(rg1Name,
                vm1.Name));
            //var lroResponse =  await VirtualMachinesClient.StartReapplyAsync(rg1Name,
            //    vm1.Name).GetAwaiter().GetResult();

            passed = true;
            Assert.True(passed);
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// Start VM
        /// Shutdown VM with skipShutdown = true
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMOperations_PowerOffWithSkipShutdown()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1;

            bool passed = false;
            // Create Storage Account for this VM
            var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

            var returnTwovm = await CreateVM(rg1Name, asName, storageAccountOutput, imageRef);
            VirtualMachine vm1 = returnTwovm.Item1;
            inputVM1 = returnTwovm.Item2;
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartStartAsync(rg1Name, vm1.Name));
            // Shutdown VM with SkipShutdown = true
            await WaitForCompletionAsync(await VirtualMachinesOperations.StartPowerOffAsync(rg1Name, vm1.Name, true));
            passed = true;
            Assert.True(passed);
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// GET VM Model View
        /// PerformMaintenance VM
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMOperations_PerformMaintenance()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1 = null;
            string inputVM1Name = null;

            bool passed = false;
            try
            {
                // Create Storage Account, so that both the VMs can share it
                var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

                var returnTwovm = await CreateVM(rg1Name, asName, storageAccountOutput, imageRef);
                VirtualMachine vm1 = returnTwovm.Item1;
                inputVM1 = returnTwovm.Item2;
                inputVM1Name = returnTwovm.Item3;
                await WaitForCompletionAsync(await VirtualMachinesOperations.StartPerformMaintenanceAsync(rg1Name, vm1.Name));
                passed = true;
            }
            catch (Exception cex)
            {
                passed = true;
                string expectedMessage = $"Operation 'performMaintenance' is not allowed on VM '{inputVM1Name}' since the Subscription of this VM" +
                    " is not eligible.";
                Assert.IsTrue(cex.Message.Contains(expectedMessage));
            }
            Assert.True(passed);
        }
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VM
        /// Call SimulateEviction on that VM
        /// Delete RG
        /// </summary>
        [Test]
        public async Task TestVMOperations_SimulateEviction()
        {
            EnsureClientsInitialized(DefaultLocation);

            ImageReference imageRef = await GetPlatformVMImage(useWindowsImage: true);

            // Create resource group
            string rg1Name = Recording.GenerateAssetName(TestPrefix) + 1;
            string asName = Recording.GenerateAssetName("as");
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            VirtualMachine inputVM1;

            bool passed = false;
            // Create Storage Account, so that both the VMs can share it
            var storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);

            var returnTwoVM = await CreateVM(rg1Name,
                                           asName,
                                           storageAccountOutput.Name,
                                           imageRef,
                                           (virtualMachine) =>
                                           {
                                               virtualMachine.Priority = VirtualMachinePriorityTypes.Spot;
                                               virtualMachine.AvailabilitySet = null;
                                               virtualMachine.BillingProfile = new BillingProfile { MaxPrice = -1 };
                                           },
                                           vmSize: VirtualMachineSizeTypes.StandardA1.ToString());
            VirtualMachine vm1 = returnTwoVM.Item1;
            inputVM1 = returnTwoVM.Item2;

            await VirtualMachinesOperations.SimulateEvictionAsync(rg1Name, vm1.Name);
            passed = true;
            Assert.True(passed);
        }
    }
}
