// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Compute.Tests
{
    public class VMScaleSetRollingUpgradeTests : VMScaleSetTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// Upgrade scale set with an extension
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetRollingUpgrade")]
        public void TestVMScaleSetRollingUpgrade()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                        {
                            GetTestVMSSVMExtension(),
                        }
                    };

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var getResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                    Assert.NotNull(getInstanceViewResponse);
                    ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                    var getVMInstanceViewResponse = m_CrpClient.VirtualMachineScaleSetVMs.GetInstanceView(rgName, vmssName, "0");
                    Assert.NotNull(getVMInstanceViewResponse);
                    Assert.NotNull(getVMInstanceViewResponse.VmHealth);
                    Assert.Equal("HealthState/healthy", getVMInstanceViewResponse.VmHealth.Status.Code);

                    // Update the VMSS by adding an extension
                    inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                    Assert.NotNull(getInstanceViewResponse);
                    ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
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
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Perform a rolling OS upgrade
        /// Validate the rolling upgrade completed
        /// Perform another rolling OS upgrade
        /// Cancel the rolling upgrade
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetRollingUpgradeAPIs")]
        public void TestVMScaleSetRollingUpgradeAPIs()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    imageRef.Version = "latest";

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var getResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSetRollingUpgrades.StartOSUpgrade(rgName, vmssName);
                    var rollingUpgradeStatus = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.GetLatest(rgName, vmssName);
                    Assert.Equal(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Progress.SuccessfulInstanceCount);

                    var upgradeTask = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.BeginStartOSUpgradeWithHttpMessagesAsync(rgName, vmssName);

                    m_CrpClient.VirtualMachineScaleSetRollingUpgrades.Cancel(rgName, vmssName);

                    rollingUpgradeStatus = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.GetLatest(rgName, vmssName);

                    Assert.True(rollingUpgradeStatus.RunningStatus.Code == RollingUpgradeStatusCode.Cancelled);
                    Assert.True(rollingUpgradeStatus.Progress.PendingInstanceCount >= 0);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
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
        /// Create Network Resources with an SLB probe to use as a health probe
        /// Create VMScaleSet in rolling upgrade mode
        /// Perform a rolling OS upgrade
        /// Validate Upgrade History
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetRollingUpgradeHistory")]
        public void TestVMScaleSetRollingUpgradeHistory()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "southcentralus");
                    EnsureClientsInitialized(context);

                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                    imageRef.Version = "latest";

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var getResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Rolling;
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSetRollingUpgrades.StartOSUpgrade(rgName, vmssName);
                    var rollingUpgradeHistory = m_CrpClient.VirtualMachineScaleSets.GetOSUpgradeHistory(rgName, vmssName);
                    Assert.NotNull(rollingUpgradeHistory);
                    Assert.True(rollingUpgradeHistory.Count() == 1);
                    Assert.Equal(inputVMScaleSet.Sku.Capacity, rollingUpgradeHistory.First().Properties.Progress.SuccessfulInstanceCount);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        /// <summary>
        /// Testing Automatic OS Upgrades
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetAutomaticOSUpgrade")]
        public void TestVMScaleSetAutomaticOSUpgrade()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);

                ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);
                imageRef.Version = "latest";

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                try
                {
                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var getResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.AutoOSUpgradePolicy =new AutoOSUpgradePolicy()
                            {
                                DisableAutoRollback = false
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    // Set Automatic OS Upgrade 
                    inputVMScaleSet.UpgradePolicy.AutomaticOSUpgrade = true;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    // with upgrade policy as null
                    inputVMScaleSet.UpgradePolicy.AutoOSUpgradePolicy = null;
                    inputVMScaleSet.UpgradePolicy.AutomaticOSUpgrade = false;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    Assert.NotNull(getResponse.UpgradePolicy.AutoOSUpgradePolicy);
                    Assert.True(getResponse.UpgradePolicy.AutoOSUpgradePolicy.DisableAutoRollback == false);

                    // Toggle Disable Auto Rollback
                    inputVMScaleSet.UpgradePolicy.AutoOSUpgradePolicy = new AutoOSUpgradePolicy()
                    {
                        DisableAutoRollback = true
                    };
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    
                }
                finally
                {
                    //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                    //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        // Does the following operations:
        // Create ResourceGroup
        // Create StorageAccount
        // Create VMSS in Automatic Mode
        // Perform an extension rolling upgrade
        // Delete ResourceGroup
        [Fact(Skip = "TODO: Re-record due to version update")]
        [Trait("Name", "TestVMScaleSetExtensionUpgradeAPIs")]
        public void TestVMScaleSetExtensionUpgradeAPIs()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
                
                string rgName = TestUtilities.GenerateName(TestPrefix);
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                    EnsureClientsInitialized(context);

                    // Windows VM image
                    ImageReference imageRef = GetPlatformVMImage(true);
                    imageRef.Version = "latest";
                    var extension = GetTestVMSSVMExtension();
                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                    {
                        extension,
                    }
                    };

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var getResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        extensionProfile,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Automatic;
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    m_CrpClient.VirtualMachineScaleSetRollingUpgrades.StartExtensionUpgrade(rgName, vmssName);
                    var rollingUpgradeStatus = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.GetLatest(rgName, vmssName);
                    Assert.Equal(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Progress.SuccessfulInstanceCount);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup resource group and revert default location to the original location
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }
    }
}
