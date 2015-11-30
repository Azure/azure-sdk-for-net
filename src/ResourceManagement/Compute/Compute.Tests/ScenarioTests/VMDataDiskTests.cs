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

using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMDataDiskTests : VMTestBase
    {
        [Fact]
        public void TestVMDataDiskScenario()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                ImageReference imgageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                string asName = TestUtilities.GenerateName("as");
                VirtualMachine inputVM;
                bool passed = false;

                try
                {
                    // Create Storage Account, so that both the VMs can share it
                    var storageAccountOutput = CreateStorageAccount( rgName, storageAccountName );

                    Action<VirtualMachine> addDataDiskToVM = vm =>
                    {
                        string containerName = TestUtilities.GenerateName(TestPrefix);
                        var vhdContainer = string.Format(Constants.StorageAccountBlobUriTemplate, storageAccountName) + containerName;
                        var vhduri = vhdContainer + string.Format("/{0}.vhd", TestUtilities.GenerateName(TestPrefix));

                        vm.HardwareProfile.VirtualMachineSize = VirtualMachineSizeTypes.StandardA4;
                        vm.StorageProfile.DataDisks = new List<DataDisk>();
                        foreach (int index in new int[] {1, 2})
                        {
                            var diskName = "dataDisk" + index;
                            var ddUri = vhdContainer + string.Format("/{0}{1}.vhd", diskName, TestUtilities.GenerateName(TestPrefix));
                            var dd = new DataDisk
                            {
                                Caching = CachingTypes.None,
                                SourceImage = null,
                                DiskSizeGB = 10,
                                CreateOption = DiskCreateOptionTypes.Empty,
                                Lun = 1 + index,
                                Name = diskName,
                                VirtualHardDisk = new VirtualHardDisk
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
                        vm.InstanceView = new VirtualMachineInstanceView
                        {
                            Statuses = testStatusList,
                            VMAgent = new VirtualMachineAgentInstanceView
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
                                VMAgentVersion = "test"
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
                        };
                    };

                    var vm1 = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imgageRef, out inputVM, addDataDiskToVM);

                    var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, inputVM.Name);
                    Assert.True(getVMWithInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(getVMWithInstanceViewResponse.VirtualMachine != null, "VM in Get");
                    ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse.VirtualMachine);

                    var vm2 = getVMWithInstanceViewResponse.VirtualMachine;
                    var vmReCreateResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, getVMWithInstanceViewResponse.VirtualMachine);
                    Assert.True(vmReCreateResponse.Status != ComputeOperationStatus.Failed);

                    var lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, inputVM.Name);
                    Assert.True(lroResponse.Status != OperationStatus.Failed);

                    passed = true;
                }
                finally
                {
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                    Assert.True(passed);
                }
            }
        }
    }
}
