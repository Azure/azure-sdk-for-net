// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMPatchOperationsTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// POST AssessPatches
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMPatchOperations_AssessPatches()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true, sku: "2016-Datacenter");

                // Create resource group
                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;
                string asName = TestUtilities.GenerateName("as");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachine inputVM1;

                bool passed = false;
                try
                {
                    // Create Storage Account for this VM
                    var storageAccountOutput = CreateStorageAccount(rg1Name, storageAccountName);

                    VirtualMachine vm1 = CreateVM(
                        rg1Name,
                        asName,
                        storageAccountOutput.Name,
                        imageRef,
                        out inputVM1,
                        hasManagedDisks: true,
                        vmSize: VirtualMachineSizeTypes.StandardDS3V2,
                        createWithPublicIpAddress: true);

                    VirtualMachineAssessPatchesResult assessPatchesResult = m_CrpClient.VirtualMachines.AssessPatches(rg1Name, vm1.Name);

                    Assert.NotNull(assessPatchesResult);
                    Assert.Equal("Succeeded", assessPatchesResult.Status);
                    Assert.NotNull(assessPatchesResult.StartDateTime);

                    passed = true;
                }
                finally
                {
                    // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    // of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    var deleteRg1Response = m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rg1Name);
                }

                Assert.True(passed);
            }
        }

        //How to re-record this test:
        // 1. Manually create Resource group and VM
        // update the constants for RgName and VmName
        // 2. Then run this test
        [Fact]
        public void TestVMPatchOperations_InstallPatches_OnWindows()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                string RgName = "PatchStatusRg";
                string VmName = "testVm";

                VirtualMachineInstallPatchesParameters installPatchesInput = new VirtualMachineInstallPatchesParameters
                {
                    MaximumDuration = "PT4H",
                    RebootSetting = "IfRequired",
                    WindowsParameters = new WindowsParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical", 
                            "Security"
                        },
                        MaxPatchPublishDate = DateTime.UtcNow
                    }
                };

                VirtualMachineInstallPatchesResult installPatchesResult = m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput);

                Assert.NotNull(installPatchesResult);
                Assert.Equal("Succeeded", installPatchesResult.Status);
                Assert.NotNull(installPatchesResult.StartDateTime);
                Assert.NotNull(installPatchesResult.InstallationActivityId);
                Assert.NotNull(installPatchesResult.RebootStatus);
                Assert.NotNull(installPatchesResult.MaintenanceWindowExceeded);
                Assert.NotNull(installPatchesResult.ExcludedPatchCount);
                Assert.NotNull(installPatchesResult.NotSelectedPatchCount);
                Assert.NotNull(installPatchesResult.PendingPatchCount);
                Assert.NotNull(installPatchesResult.InstalledPatchCount);
                Assert.NotNull(installPatchesResult.FailedPatchCount);
                Assert.NotNull(installPatchesResult.Patches);
                Assert.NotNull(installPatchesResult.Patches[0].PatchId);
                Assert.NotNull(installPatchesResult.Patches[0].Name);
                Assert.NotNull(installPatchesResult.Patches[0].KbId);
                Assert.NotNull(installPatchesResult.Patches[0].Classifications);
                Assert.NotNull(installPatchesResult.Patches[0].InstallationState);
                // Add this check once windows solution for error objects content is fixed.
                //Assert.NotNull(installPatchesResult.Error);

                // When installPatchInput is not provided. 
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, null));

                // MaximumDuration not provided.
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                VirtualMachineInstallPatchesParameters installPatchesInput_WithoutMaxDuration = new VirtualMachineInstallPatchesParameters
                {
                    RebootSetting = "IfRequired",
                    WindowsParameters = new WindowsParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical",
                            "Security"
                        },
                        MaxPatchPublishDate = DateTime.UtcNow
                    }
                };
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput_WithoutMaxDuration));

                // RebootSetting not provided.
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                VirtualMachineInstallPatchesParameters installPatchesInput_WithoutRebootSetting = new VirtualMachineInstallPatchesParameters
                {
                    MaximumDuration = "PT4H",
                    WindowsParameters = new WindowsParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical",
                            "Security"
                        },
                        MaxPatchPublishDate = DateTime.UtcNow
                    }
                };
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput_WithoutRebootSetting));
            }
        }

        //How to re-record this test:
        // 1. Manually create Resource group and VM
        // update the constants for RgName and VmName
        // 2. Then run this test
        [Fact]
        public void TestVMPatchOperations_InstallPatches_OnLinux()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                string RgName = "PatchStatusRg";
                string VmName = "testVmLinux";

                VirtualMachineInstallPatchesParameters installPatchesInput = new VirtualMachineInstallPatchesParameters
                {
                    MaximumDuration = "PT4H",
                    RebootSetting = "IfRequired",
                    LinuxParameters = new LinuxParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical",
                            "Security"
                        },
                        MaintenanceRunId = DateTime.UtcNow.ToString(),
                    }
                };

                VirtualMachineInstallPatchesResult installPatchesResult = m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput);

                Assert.NotNull(installPatchesResult);
                Assert.Equal("Succeeded", installPatchesResult.Status);
                Assert.NotNull(installPatchesResult.StartDateTime);
                Assert.NotNull(installPatchesResult.InstallationActivityId);
                Assert.NotNull(installPatchesResult.RebootStatus);
                Assert.NotNull(installPatchesResult.MaintenanceWindowExceeded);
                Assert.NotNull(installPatchesResult.ExcludedPatchCount);
                Assert.NotNull(installPatchesResult.NotSelectedPatchCount);
                Assert.NotNull(installPatchesResult.PendingPatchCount);
                Assert.NotNull(installPatchesResult.InstalledPatchCount);
                Assert.NotNull(installPatchesResult.FailedPatchCount);
                Assert.NotNull(installPatchesResult.Patches);
                Assert.NotNull(installPatchesResult.Patches[0].PatchId);
                Assert.NotNull(installPatchesResult.Patches[0].Name);
                Assert.NotNull(installPatchesResult.Patches[0].Version);
                Assert.NotNull(installPatchesResult.Patches[0].Classifications);
                Assert.NotNull(installPatchesResult.Patches[0].InstallationState);
                Assert.NotNull(installPatchesResult.Error);

                // When installPatchInput is not provided. 
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, null));

                // MaximumDuration not provided.
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                VirtualMachineInstallPatchesParameters installPatchesInput_WithoutMaxDuration = new VirtualMachineInstallPatchesParameters
                {
                    RebootSetting = "IfRequired",
                    LinuxParameters = new LinuxParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical",
                            "Security"
                        },
                        MaintenanceRunId = DateTime.UtcNow.ToString(),
                    }
                };
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput_WithoutMaxDuration));

                // RebootSetting not provided.
                // ToDo: Move this to a seperate function once the ARM issue for test session record is fixed
                VirtualMachineInstallPatchesParameters installPatchesInput_WithoutRebootSetting = new VirtualMachineInstallPatchesParameters
                {
                    MaximumDuration = "PT4H",
                    LinuxParameters = new LinuxParameters
                    {
                        ClassificationsToInclude = new List<string>
                        {
                            "Critical",
                            "Security"
                        },
                        MaintenanceRunId = DateTime.UtcNow.ToString(),
                    }
                };
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, VmName, installPatchesInput_WithoutRebootSetting));
            }
        }
    }
}
