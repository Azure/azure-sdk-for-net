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
        private const string RgName = "PatchStatusRg";
        private const string WindowsVmName = "testVmWindows";
        private const string LinuxVmName = "testVmLinux";

        //How to re-record this test:
        // 1. Manually create Resource group and VM find sub from ComputeManagementClient m_CrpClient.SubscriptionId from VMTestBase,
        // update the constants for RgName and WindowsVmName
        // 2. invoke CRP install patch api
        // 3. Then run this test

        [Fact]
        public void TestVMPatchOperations_AssessPatches_OnWindows()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                VirtualMachineAssessPatchesResult assessPatchesResult = m_CrpClient.VirtualMachines.AssessPatches(RgName, WindowsVmName);

                Assert.NotNull(assessPatchesResult);
                Assert.Equal("Succeeded", assessPatchesResult.Status);
                Assert.NotNull(assessPatchesResult.AssessmentActivityId);
                Assert.NotNull(assessPatchesResult.RebootPending);
                Assert.NotNull(assessPatchesResult.CriticalAndSecurityPatchCount);
                Assert.NotNull(assessPatchesResult.OtherPatchCount);
                Assert.NotNull(assessPatchesResult.StartDateTime);
                Assert.NotNull(assessPatchesResult.AvailablePatches);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].PatchId);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].Name);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].KbId);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].Classifications);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].RebootBehavior);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].PublishedDate);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].ActivityId);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].LastModifiedDateTime);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].AssessmentState);
                // ToDo: add this check after windows change for error object in merged
                // Assert.NotNull(assessPatchesResult.Error);
            }
        }

        [Fact]
        public void TestVMPatchOperations_AssessPatches_OnLinux()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                VirtualMachineAssessPatchesResult assessPatchesResult = m_CrpClient.VirtualMachines.AssessPatches(RgName, LinuxVmName);

                Assert.NotNull(assessPatchesResult);
                Assert.Equal("Succeeded", assessPatchesResult.Status);
                Assert.NotNull(assessPatchesResult.AssessmentActivityId);
                Assert.NotNull(assessPatchesResult.RebootPending);
                Assert.NotNull(assessPatchesResult.CriticalAndSecurityPatchCount);
                Assert.NotNull(assessPatchesResult.OtherPatchCount);
                Assert.NotNull(assessPatchesResult.StartDateTime);
                Assert.NotNull(assessPatchesResult.AvailablePatches);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].PatchId);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].Name);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].Version);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].Classifications);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].RebootBehavior);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].PublishedDate);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].ActivityId);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].LastModifiedDateTime);
                Assert.NotNull(assessPatchesResult.AvailablePatches[0].AssessmentState);
                Assert.NotNull(assessPatchesResult.Error);
            }
        }

        [Fact]
        public void TestVMPatchOperations_InstallPatches_OnWindows()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

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

                VirtualMachineInstallPatchesResult installPatchesResult = m_CrpClient.VirtualMachines.InstallPatches(RgName, WindowsVmName, installPatchesInput);

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, WindowsVmName, null));

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, WindowsVmName, installPatchesInput_WithoutMaxDuration));

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, WindowsVmName, installPatchesInput_WithoutRebootSetting));
            }
        }

        [Fact]
        public void TestVMPatchOperations_InstallPatches_OnLinux()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

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

                VirtualMachineInstallPatchesResult installPatchesResult = m_CrpClient.VirtualMachines.InstallPatches(RgName, LinuxVmName, installPatchesInput);

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, LinuxVmName, null));

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, LinuxVmName, installPatchesInput_WithoutMaxDuration));

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
                Assert.Throws<ValidationException>(() => m_CrpClient.VirtualMachines.InstallPatches(RgName, LinuxVmName, installPatchesInput_WithoutRebootSetting));
            }
        }
    }
}
