// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMDataDiskTests : VMTestBase
    {
        [Fact]
        public void TestVMDataDiskScenario()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imgageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string asName = ComputeManagementTestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                bool passed = false;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount( rgName, storageAccountName );

                    Action<VirtualMachine> addDataDiskToVM = vm =>
                    {
                        string containerName = HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix);
                        var vhdContainer = "https://" + storageAccountName + ".blob.core.windows.net/" + containerName;
                        var vhduri = vhdContainer + string.Format("/{0}.vhd", HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix));

                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA1V2;
                        vm.StorageProfile.DataDisks = new List<DataDisk>();
                        foreach (int index in new int[] {1, 2})
                        {
                            var diskName = "dataDisk" + index;
                            var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, HttpMockServer.GetAssetName("TestVMDataDiskScenario", TestPrefix));
                            var dd = new DataDisk
                            {
                                Caching = CachingTypes.None,
                                Image = null,
                                DiskSizeGB = 10,
                                CreateOption = DiskCreateOptionTypes.Empty,
                                Lun = 1 + index,
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
                                ExtensionHandlers = new List<VirtualMachineExtensionHandlerInstanceView>
                                {
                                    new VirtualMachineExtensionHandlerInstanceView
                                    {
                                        Status = testStatus,
                                        Type = "test",
                                        TypeHandlerVersion = "test"
                                    }
                                },
                                VmAgentVersion = "test"
                            },
                            Disks = new List<DiskInstanceView>
                            {
                                new DiskInstanceView
                                {
                                    Statuses = testStatusList,
                                    Name = "test"
                                }
                            },
                            Extensions = new List<VirtualMachineExtensionInstanceView>
                            {
                                new VirtualMachineExtensionInstanceView
                                {
                                    Statuses = testStatusList
                                }
                            }
                        }; */
                    };

                    var vm1 = CreateVM(rgName, asName, storageAccountOutput, imgageRef, out inputVM, addDataDiskToVM);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                    Assert.True(getVMWithInstanceViewResponse != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                    var vm2 = getVMWithInstanceViewResponse;
                    var vmReCreateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, getVMWithInstanceViewResponse.Name, getVMWithInstanceViewResponse);

                    m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);

                    passed = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(passed);
                }
            }
        }
        
        [Fact]
        [Trait("Name", "TestVMDataDiskScenario_ManagedDisk_ForceDetach")]
        public void TestVMDataDiskScenario_ManagedDisk_ForceDetach()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                EnsureClientsInitialized(context);

                ImageReference imageReference = GetPlatformVMImage(useWindowsImage: true);
                string resourceGroupName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountForDisksName = TestUtilities.GenerateName(TestPrefix);
                string availabilitySetName = TestUtilities.GenerateName(TestPrefix);

                try
                {
                    StorageAccount storageAccountForDisks = CreateStorageAccount(resourceGroupName, storageAccountForDisksName);

                    Action<VirtualMachine> addManagedDataDiskToVM = vm =>
                    {
                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
                        vm.StorageProfile.DataDisks = new List<DataDisk>();

                        var diskName = "dataDisk" + TestUtilities.GenerateGuid();
                        var dd = new DataDisk
                        {
                            Caching = CachingTypes.None,
                            DiskSizeGB = 10,
                            CreateOption = DiskCreateOptionTypes.Empty,
                            Lun = 0,
                            Name = diskName,
                            ManagedDisk = new ManagedDiskParameters()
                            {
                                StorageAccountType = StorageAccountType.StandardLRS
                            }
                        };
                        vm.StorageProfile.DataDisks.Add(dd);

                        var testStatus = new InstanceViewStatus
                        {
                            Code = "test",
                            Message = "test"
                        };

                        var testStatusList = new List<InstanceViewStatus> { testStatus };
                    };

                    VirtualMachine inputVM;
                    CreateVM(resourceGroupName, availabilitySetName, storageAccountForDisks, imageReference, out inputVM, addManagedDataDiskToVM, hasManagedDisks: true);

                    VirtualMachine getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(resourceGroupName, inputVM.Name, InstanceViewTypes.InstanceView);
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse, hasManagedDisks: true);

                    DataDisk diskToBeForceDetached = getVMWithInstanceViewResponse.StorageProfile.DataDisks.FirstOrDefault(disk => disk.Lun == 0);
                    Assert.NotNull(diskToBeForceDetached);

                    Helpers.MarkDataDiskToBeDetached(diskToBeForceDetached, "ForceDetach");

                    var forceDetachVMResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(resourceGroupName, getVMWithInstanceViewResponse.Name, getVMWithInstanceViewResponse);
                    Assert.Equal(0, forceDetachVMResponse.StorageProfile.DataDisks.Count);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    m_ResourcesClient.ResourceGroups.Delete(resourceGroupName);
                }
            }
        }
    }
}

