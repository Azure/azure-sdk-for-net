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
    public class VMDataDiskTests : VMTestBase
    {
        public VMDataDiskTests(bool isAsync)
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
        public async Task TestVMDataDiskScenario()
        {
            EnsureClientsInitialized(DefaultLocation);
            ImageReference imgageRef = await GetPlatformVMImage(useWindowsImage: true);
            // Create resource group
            var rgName = Recording.GenerateAssetName(TestPrefix);
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");
            VirtualMachine inputVM;
            bool passed = false;
            try
            {
                // Create Storage Account, so that both the VMs can share it
                var storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

                Action<VirtualMachine> addDataDiskToVM = vm =>
                {
                    string containerName = Recording.GenerateAssetName("testvmdatadiskscenario", TestPrefix);
                    var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
                    var vhduri = vhdContainer + string.Format("/{0}.vhd", Recording.GenerateAssetName("testvmdatadiskscenario", TestPrefix));

                    vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                    foreach (int index in new int[] { 1, 2 })
                    {
                        var diskName = "dataDisk" + index;
                        var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, Recording.GenerateAssetName("testvmdatadiskscenario", TestPrefix));
                        var dd = new DataDisk(1 + index, DiskCreateOptionTypes.Empty)
                        {
                            Caching = CachingTypes.None,
                            Image = null,
                            DiskSizeGB = 10,
                            Name = diskName,
                            Vhd = new VirtualHardDisk
                            {
                                Uri = ddUri
                            }
                        };
                        vm.StorageProfile.DataDisks.Add(dd);
                    }

                    var testStatus = new InstanceViewStatus
                    {
                        Code = "test",
                        Message = "test"
                    };

                    var testStatusList = new List<InstanceViewStatus> { testStatus };

                    // Negative tests for a bug in 5.0.0 that read-only fields have side-effect on the request body
                    /* vm.InstanceView = new VirtualMachineInstanceView
                    {
                        Statuses = testStatusList,
                        VmAgent = new VirtualMachineAgentInstanceView
                        {
                            Statuses = testStatusList,
                            ExtensionHandlers = {
                                new VirtualMachineExtensionHandlerInstanceView
                                {
                                    Status = testStatus,
                                    Type = "test",
                                    TypeHandlerVersion = "test"
                                }
                            },
                            VmAgentVersion = "test"
                        },
                        Disks = {
                            new DiskInstanceView
                            {
                                Statuses = testStatusList,
                                Name = "test"
                            }
                        },
                        Extensions = {
                            new VirtualMachineExtensionInstanceView
                            {
                                Statuses = testStatusList
                            }
                        }
                    }; */
                };

                var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imgageRef, addDataDiskToVM);
                VirtualMachine vm1 = returnTwoVM.Item1;
                inputVM = returnTwoVM.Item2;
                string inputVMName = returnTwoVM.Item3;
                var getVMWithInstanceViewResponse = await VirtualMachinesOperations.GetAsync(rgName, inputVMName);
                Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                var vm2 = getVMWithInstanceViewResponse;
                var vmReCreateResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, getVMWithInstanceViewResponse.Value.Name, getVMWithInstanceViewResponse));

                await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, inputVMName));

                passed = true;
                Assert.True(passed);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
