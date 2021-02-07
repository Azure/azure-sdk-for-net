// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests
{
    public class VMPatchOperationsTests : VMTestBase
    {
        private const string RgName = "PatchStatusRg";
        private const string WindowsVmName = "testVmWindows";
        private const string LinuxVmName = "testLinuxVM";

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
    }
}
