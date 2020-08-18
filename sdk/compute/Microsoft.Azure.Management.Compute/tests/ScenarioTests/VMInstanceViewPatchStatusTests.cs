// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Compute.Tests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Management.Compute.Tests.ScenarioTests
{
    public class VMInstanceViewPatchStatusTests : VMTestBase
    {
        private const string RgName = "PatchStatusRg";
        private const string VmName = "testVm";

        //How to re-record this test:
        // 1. Manually create Resource group and VM
        // update the constants for RgName and VmName
        // 2. invoke CRP install patch api
        // 3. Then run this test
        [Fact()]
        public void GetVMInstanceViewWithPatchStatus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);
                VirtualMachineInstanceView vmInstanceView = m_CrpClient.VirtualMachines.InstanceView(RgName, VmName);

                Assert.NotNull(vmInstanceView);
                Assert.NotNull(vmInstanceView.PatchStatus);
                Assert.NotNull(vmInstanceView.PatchStatus.AvailablePatchSummary);
                Assert.Equal(0, vmInstanceView.PatchStatus.AvailablePatchSummary.CriticalAndSecurityPatchCount);
                Assert.Equal(1, vmInstanceView.PatchStatus.AvailablePatchSummary.OtherPatchCount);
                Assert.True(vmInstanceView.PatchStatus.AvailablePatchSummary.RebootPending);
                Assert.NotNull(vmInstanceView.PatchStatus.AvailablePatchSummary.StartTime);
                Assert.NotNull(vmInstanceView.PatchStatus.AvailablePatchSummary.LastModifiedTime);
                Assert.NotNull(vmInstanceView.PatchStatus.AvailablePatchSummary.AssessmentActivityId);
                Assert.NotNull(vmInstanceView.PatchStatus.LastPatchInstallationSummary);
                Assert.Equal("Succeeded", vmInstanceView.PatchStatus.LastPatchInstallationSummary.Status);
                Assert.Equal(0, vmInstanceView.PatchStatus.LastPatchInstallationSummary.ExcludedPatchCount);
                Assert.Equal(0, vmInstanceView.PatchStatus.LastPatchInstallationSummary.FailedPatchCount);
                Assert.Equal(0, vmInstanceView.PatchStatus.LastPatchInstallationSummary.NotSelectedPatchCount);
                Assert.Equal(2, vmInstanceView.PatchStatus.LastPatchInstallationSummary.InstalledPatchCount);
                Assert.Equal(0, vmInstanceView.PatchStatus.LastPatchInstallationSummary.PendingPatchCount);
                Assert.NotNull(vmInstanceView.PatchStatus.LastPatchInstallationSummary.InstallationActivityId);
                //Assert.False(vmInstanceView.PatchStatus.LastPatchInstallationSummary.MaintenanceWindowExceeded);
                Assert.NotNull(vmInstanceView.PatchStatus.LastPatchInstallationSummary.StartTime);
                Assert.NotNull(vmInstanceView.PatchStatus.LastPatchInstallationSummary.LastModifiedTime);

                //Assert.NotNull(vmInstanceView.PatchStatus.ConfigurationStatusSummary);
                //Assert.NotNull(vmInstanceView.PatchStatus.ConfigurationStatusSummary.LastModifiedTime);
                //Assert.Equal("Ready", vmInstanceView.PatchStatus.ConfigurationStatusSummary.PatchModeProvisioningState);
            }
        }
    }
}
