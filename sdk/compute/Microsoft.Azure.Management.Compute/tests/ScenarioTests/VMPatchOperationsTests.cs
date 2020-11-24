// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMPatchOperationsTests : VMTestBase
    {
        /// <summary>
        /// Covers following Operations on a Windows VM:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// POST AssessPatches
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMPatchOperations_AssessPatches_OnWindows()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true, sku: "2016-Datacenter");

                // Create resource group
                string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;

                bool passed = false;
                try
                {
                    VirtualMachineAssessPatchesResult assessPatchesResult = GetAssessPatchesResult(rg1Name, imageRef);

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
               
                    passed = true;
                }
                finally
                {
                    DeleteResourceGroup(rg1Name);
                }

                Assert.True(passed);
            }
        }

        // todo: add this test once version 1.6.11 is released all across
        /// <summary>
        /// Covers following Operations on a Linux VM:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// POST AssessPatches
        /// Delete RG
        /// </summary>
        //[Fact]
        //public void TestVMPatchOperations_AssessPatches_OnLinux()
        //{
        //    using (MockContext context = MockContext.Start(this.GetType()))
        //    {
        //        EnsureClientsInitialized(context);

        //        ImageReference imageRef = GetPlatformVMImage(useWindowsImage: false, sku: "16.04-LTS");

        //        // Create resource group
        //        string rg1Name = TestUtilities.GenerateName(TestPrefix) + 1;

        //        bool passed = false;
        //        try
        //        {
        //            VirtualMachineAssessPatchesResult assessPatchesResult = GetAssessPatchesResult(rg1Name, imageRef);
        //            Assert.NotNull(assessPatchesResult);
        //            Assert.Equal("Succeeded", assessPatchesResult.Status);
        //            Assert.NotNull(assessPatchesResult.AssessmentActivityId);
        //            Assert.NotNull(assessPatchesResult.RebootPending);
        //            Assert.NotNull(assessPatchesResult.CriticalAndSecurityPatchCount);
        //            Assert.NotNull(assessPatchesResult.OtherPatchCount);
        //            Assert.NotNull(assessPatchesResult.StartDateTime);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].PatchId);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].Name);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].Version);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].Classifications);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].RebootBehavior);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].PublishedDate);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].ActivityId);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].LastModifiedDateTime);
        //            Assert.NotNull(assessPatchesResult.AvailablePatches[0].AssessmentState);
        //            Assert.NotNull(assessPatchesResult.Error);

        //            passed = true;
        //        }
        //        finally
        //        {
        //            DeleteResourceGroup(rg1Name);
        //        }

        //        Assert.True(passed);
        //    }
        //}

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create VM
        /// POST AssessPatches
        /// </summary>
        private VirtualMachineAssessPatchesResult GetAssessPatchesResult(string rg1Name, ImageReference imageRef)
        {
            string asName = TestUtilities.GenerateName("as");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachine inputVM1;

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

            return m_CrpClient.VirtualMachines.AssessPatches(rg1Name, vm1.Name);
        }

        private void DeleteResourceGroup(string rg1Name)
        {
            // Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
            // of the test to cover deletion. CSM does persistent retrying over all RG resources.
            var deleteRg1Response = m_ResourcesClient.ResourceGroups.BeginDeleteWithHttpMessagesAsync(rg1Name);
        }
    }
}
