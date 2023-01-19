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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                        {
                            GetTestVMSSVMExtension(autoUpdateMinorVersion:false),
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
                            vmScaleSet.UpgradePolicy.RollingUpgradePolicy = new RollingUpgradePolicy
                            {
                                MaxBatchInstancePercent = 100,
                                MaxUnhealthyInstancePercent = 100,
                                MaxUnhealthyUpgradedInstancePercent = 100,
                                PauseTimeBetweenBatches = "PT0S",
                                PrioritizeUnhealthyInstances = true,
                                RollbackFailedInstancesOnPolicyBreach = true
                            };
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
                    ComputeManagementTestUtilities.WaitSeconds(600);
                    var vmssStatus = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);

                    inputVMScaleSet.VirtualMachineProfile.ExtensionProfile = extensionProfile;
                    //UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    //getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    //ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    //getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                    //Assert.NotNull(getInstanceViewResponse);
                    //ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                    //m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                            vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                            {
                                EnableAutomaticOSUpgrade = false
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    ComputeManagementTestUtilities.WaitSeconds(600);
                    var vmssStatus = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);

                    m_CrpClient.VirtualMachineScaleSetRollingUpgrades.StartOSUpgrade(rgName, vmssName);
                    var rollingUpgradeStatus = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.GetLatest(rgName, vmssName);
                    Assert.Equal(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Progress.SuccessfulInstanceCount);

                    var upgradeTask = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.BeginStartOSUpgradeWithHttpMessagesAsync(rgName, vmssName);
                    vmssStatus = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);

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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    ComputeManagementTestUtilities.WaitSeconds(600);
                    var vmssStatus = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);

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
        /// Testing Automatic OS Upgrade Policy
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetAutomaticOSUpgradePolicies")]
        public void TestVMScaleSetAutomaticOSUpgradePolicies()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
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
                            vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                            {
                                DisableAutomaticRollback = false
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    // Set Automatic OS Upgrade 
                    inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade = true;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                    // with automatic OS upgrade policy as null
                    inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = null;
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    Assert.NotNull(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy);
                    Assert.True(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy.DisableAutomaticRollback == false);
                    Assert.True(getResponse.UpgradePolicy.AutomaticOSUpgradePolicy.EnableAutomaticOSUpgrade == true);

                    // Toggle Disable Auto Rollback
                    inputVMScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                    {
                        DisableAutomaticRollback = true,
                        EnableAutomaticOSUpgrade = false
                    };
                    UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                    getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
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

        // Does the following operations:
        // Create ResourceGroup
        // Create StorageAccount
        // Create VMSS in Automatic Mode
        // Perform an extension rolling upgrade
        // Delete ResourceGroup
        [Fact]
        [Trait("Name", "TestVMScaleSetExtensionUpgradeAPIs")]
        public void TestVMScaleSetExtensionUpgradeAPIs()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
                
                string rgName = TestUtilities.GenerateName(TestPrefix);
                string vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                    EnsureClientsInitialized(context);

                    // Windows VM image
                    ImageReference imageRef = GetPlatformVMImage(true);
                    imageRef.Version = "latest";
                    var extension = GetTestVMSSVMExtension(autoUpdateMinorVersion:false);
                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                    {
                        extension,
                    }
                    };

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    //m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

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

                    //m_CrpClient.VirtualMachineScaleSetRollingUpgrades.StartExtensionUpgrade(rgName, vmssName);
                    //var rollingUpgradeStatus = m_CrpClient.VirtualMachineScaleSetRollingUpgrades.GetLatest(rgName, vmssName);
                    //Assert.Equal(inputVMScaleSet.Sku.Capacity, rollingUpgradeStatus.Progress.SuccessfulInstanceCount);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // Cleanup resource group and revert default location to the original location
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
        /// Verify max surge is set correctly
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetRollingUpgradeMaxSurge")]
        public void TestVMScaleSetRollingUpgradeMaxSurge()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
                    {
                        Extensions = new List<VirtualMachineScaleSetExtension>()
                        {
                            GetTestVMSSVMExtension(autoUpdateMinorVersion:false),
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
                            vmScaleSet.UpgradePolicy.RollingUpgradePolicy = new RollingUpgradePolicy()
                            {
                                MaxSurge = true
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    Assert.True(getResponse.UpgradePolicy.RollingUpgradePolicy.MaxSurge);
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
    }
}

