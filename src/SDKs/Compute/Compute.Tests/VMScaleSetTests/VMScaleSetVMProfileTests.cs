// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.VMScaleSetTests
{
    public class VMScaleSetVMProfileTests : VMScaleSetTestsBase
    {

        /// <summary>
        /// Checks if licenseType can be set through API
        /// </summary>
        [Fact]
        public void TestVMScaleSetWithLicenseType()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                EnsureClientsInitialized(context);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachineScaleSet inputVMScaleSet;

                Action<VirtualMachineScaleSet> vmProfileCustomizer = vmss =>
                {
                    vmss.VirtualMachineProfile.StorageProfile.ImageReference = GetPlatformVMImage(true);
                    vmss.VirtualMachineProfile.LicenseType = "Windows_Server";
                };

                try
                {
                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: null,
                        inputVMScaleSet: out inputVMScaleSet,
                        createWithManagedDisks: true,
                        vmScaleSetCustomizer: vmProfileCustomizer
                        );


                    var response = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);

                    Assert.Equal("Windows_Server", response.VirtualMachineProfile.LicenseType);
                }
                catch (CloudException ex)
                {
                    if(ex.Body.Message.Contains("One or more errors occurred while preparing VM disks. See disk instance view for details."))
                    {
                        return;
                    }
                    throw;
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

            }
        }


        /// <summary>
        /// Checks if diagnostics profile can be set through API
        /// </summary>
        [Fact]
        public void TestVMScaleSetDiagnosticsProfile()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                EnsureClientsInitialized(context);

                // Create resource group
                string rgName = TestUtilities.GenerateName(TestPrefix) + 1;
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachineScaleSet inputVMScaleSet;

                Action<VirtualMachineScaleSet> vmProfileCustomizer = vmss =>
                {
                    vmss.VirtualMachineProfile.DiagnosticsProfile = new DiagnosticsProfile(
                        new BootDiagnostics
                        {
                            Enabled = true,
                            StorageUri = string.Format(Constants.StorageAccountBlobUriTemplate, storageAccountName)
                        });
                };

                try
                {
                    VirtualMachineScaleSet vmScaleSet = CreateVMScaleSet_NoAsyncTracking(
                        rgName: rgName,
                        vmssName: vmssName,
                        storageAccount: storageAccountOutput,
                        imageRef: GetPlatformVMImage(true),
                        inputVMScaleSet: out inputVMScaleSet,
                        createWithManagedDisks: true,
                        vmScaleSetCustomizer: vmProfileCustomizer
                        );

                    var response = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);

                    Assert.True(response.VirtualMachineProfile.DiagnosticsProfile.BootDiagnostics.Enabled.GetValueOrDefault(true));
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.DeleteIfExists(rgName);
                }

            }
        }
    }
}