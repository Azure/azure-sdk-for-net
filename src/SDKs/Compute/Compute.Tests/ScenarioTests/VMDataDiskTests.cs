// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMDataDiskTests : VMTestBase
    {
        [Fact]
        public void TestVMDataDiskScenario()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                        vm.HardwareProfile.VmSize = VirtualMachineSizeTypes.StandardA4;
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
    }
}
