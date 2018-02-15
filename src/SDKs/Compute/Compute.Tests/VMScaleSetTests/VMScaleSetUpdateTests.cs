// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetUpdateTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// ScaleOut VMScaleSet
        /// ScaleIn VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetScalingOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");


                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    // Scale Out VMScaleSet
                    inputVMScaleSet.Sku.Capacity = 3;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    // Scale In VMScaleSet
                    inputVMScaleSet.Sku.Capacity = 1;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Update VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetUpdateOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    inputVMScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1;
                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                            {
                                GetTestVMSSVMExtension(),
                            }
                    };
                    inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;

                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// This is same as TestVMScaleSetUpdateOperations except that this test calls PATCH API instead of PUT
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet
        /// Update VMScaleSet
        /// Scale VMScaleSet
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        public void TestVMScaleSetPatchOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var vmScaleSet = CreateVMScaleSet_NoAsyncTracking(rgName, vmssName, storageAccountOutput, imageRef, out inputVMScaleSet);

                    var getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    // Adding an extension to the VMScaleSet. We will use Patch to update this.
                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                            {
                                GetTestVMSSVMExtension(),
                            }
                    };
                 
                    VirtualMachineScaleSetUpdate patchVMScaleSet = new VirtualMachineScaleSetUpdate()
                    {
                        VirtualMachineProfile = new VirtualMachineScaleSetUpdateVMProfile()
                        {
                            ExtensionProfile = extensionProfile,
                        },
                    };
                    PatchVMScaleSet(rgName, vmssName, patchVMScaleSet);

                    // Update the inputVMScaleSet and then compare it with response to verify the result.
                    inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;
                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);


                    // Scaling the VMScaleSet now to 3 instances
                    VirtualMachineScaleSetUpdate patchVMScaleSet2 = new VirtualMachineScaleSetUpdate()
                    {
                        Sku = new Sku()
                        {
                            Capacity = 3,
                        },
                    };
                    PatchVMScaleSet(rgName, vmssName, patchVMScaleSet2);

                    // Validate that ScaleSet Scaled to 3 instances
                    inputVMScaleSet.Sku.Capacity = 3;
                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmScaleSet.Name);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmScaleSet.Name);
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
