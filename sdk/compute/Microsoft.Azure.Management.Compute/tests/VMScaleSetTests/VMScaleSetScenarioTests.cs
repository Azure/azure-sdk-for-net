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
    public class VMScaleSetScenarioTests : VMScaleSetVMTestsBase
    {
        /// <summary>
        /// Covers following Operations:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations")]
        public void TestVMScaleSetScenarioOperations()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestScaleSetOperationsInternal(context);
            }
        }

        /// <summary>
        /// Covers following Operations for ManagedDisks:
        /// Create RG
        /// Create Storage Account
        /// Create Network Resources
        /// Create VMScaleSet with extension
        /// Get VMScaleSet Model View
        /// Get VMScaleSet Instance View
        /// List VMScaleSets in a RG
        /// List Available Skus
        /// Delete VMScaleSet
        /// Delete RG
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_SingleZone()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, zones: new List<string> { "1" });
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support local diff disks.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_DiffDisks")]
        public void TestVMScaleSetScenarioOperations_DiffDisks()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardDS5V2, hasManagedDisks: true,
                        hasDiffDisks: true);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support encryption at host 
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_EncryptionAtHost")]
        public void TestVMScaleSetScenarioOperations_EncryptionAtHost()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardDS1V2, hasManagedDisks: true,
                        encryptionAtHostEnabled: true);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it in region which support DiskEncryptionSet resource for the Disks
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_With_DiskEncryptionSet")]
        public void TestVMScaleSetScenarioOperations_With_DiskEncryptionSet()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                string diskEncryptionSetId = getDefaultDiskEncryptionSetId();

                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");

                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardA1V2, hasManagedDisks: true, osDiskSizeInGB: 175, diskEncryptionSetId: diskEncryptionSetId);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_UltraSSD")]
        public void TestVMScaleSetScenarioOperations_UltraSSD()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardE4sV3, hasManagedDisks: true,
                        useVmssExtension: false, zones: new List<string> { "1" }, enableUltraSSD: true, osDiskSizeInGB: 175);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones")]
        public void TestVMScaleSetScenarioOperations_ManagedDisks_PirImage_Zones()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(
                        context, 
                        hasManagedDisks: true, 
                        useVmssExtension: false, 
                        zones: new List<string> { "1", "3" }, 
                        osDiskSizeInGB: 175);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// To record this test case, you need to run it again zone supported regions like eastus2euap.
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_PpgScenario")]
        public void TestVMScaleSetScenarioOperations_PpgScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, isPpgScenario: true);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_AutomaticPlacementOnDedicatedHostGroup")]
        public void TestVMScaleSetScenarioOperations_AutomaticPlacementOnDedicatedHostGroup()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                // This test was recorded in WestUSValidation, where the platform image typically used for recording is not available.
                // Hence the following custom image was used.
                //ImageReference imageReference = new ImageReference
                //{
                //    Publisher = "AzureRT.PIRCore.TestWAStage",
                //    Offer = "TestUbuntuServer",
                //    Sku = "16.04",
                //    Version = "latest"
                //};
                //using (MockContext context = MockContext.Start(this.GetType()))
                //{
                //    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, isAutomaticPlacementOnDedicatedHostGroupScenario: true,
                //        vmSize: VirtualMachineSizeTypes.StandardD2sV3, faultDomainCount: 1, capacity: 1, shouldOverProvision: false,
                //        validateVmssVMInstanceView: true, imageReference: imageReference, validateListSku: false, deleteAsPartOfTest: false);
                //}
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, isAutomaticPlacementOnDedicatedHostGroupScenario: true,
                        vmSize: VirtualMachineSizeTypes.StandardD2sV3, faultDomainCount: 1, capacity: 1, shouldOverProvision: false,
                        validateVmssVMInstanceView: true, validateListSku: false, deleteAsPartOfTest: false);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_UsingCapacityReservationGroup")]
        public void TestVMScaleSetScenarioOperations_UsingCapacityReservationGroup()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");

                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false, associateWithCapacityReservationGroup: true,
                        vmSize: VirtualMachineSizeTypes.StandardDS1V2, faultDomainCount: 1, shouldOverProvision: false,
                        validateVmssVMInstanceView: true, capacity: 1, validateListSku: false, deleteAsPartOfTest: false);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_SpotTryRestorePolicy")]
        public void TestVMScaleSetScenarioOperations_SpotTryRestorePolicy()
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
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    SpotRestorePolicy spotRestorePolicy = new SpotRestorePolicy(enabled: true, restoreTimeout: "PT1H");
                    var createVmssResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.Overprovision = true;
                            vmScaleSet.VirtualMachineProfile.Priority = VirtualMachinePriorityTypes.Spot;
                            vmScaleSet.VirtualMachineProfile.EvictionPolicy = VirtualMachineEvictionPolicyTypes.Deallocate;
                            vmScaleSet.SpotRestorePolicy = spotRestorePolicy;
                            vmScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1V2;
                            vmScaleSet.Sku.Tier = "Standard";
                            vmScaleSet.Sku.Capacity = 2;
                        },
                        createWithManagedDisks: true);

                    ValidateVMScaleSet(inputVMScaleSet, createVmssResponse, true);

                    VirtualMachineScaleSet getVmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getVmss, true);

                    Assert.NotNull(getVmss);
                    Assert.NotNull(getVmss.SpotRestorePolicy);
                    Assert.True(getVmss.SpotRestorePolicy.Enabled);
                    Assert.Equal(spotRestorePolicy.RestoreTimeout, getVmss.SpotRestorePolicy.RestoreTimeout);

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

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_PriorityMixPolicy")]
        public void TestVMScaleSetScenarioOperations_PriorityMixPolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // create a resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = GetPlatformVMImage(useWindowsImage: true);

                    var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                    var publicIPConfiguration = new VirtualMachineScaleSetPublicIPAddressConfiguration();
                    publicIPConfiguration.Name = "pip1";
                    publicIPConfiguration.IdleTimeoutInMinutes = 10;

                    PriorityMixPolicy priorityMixPolicy = new PriorityMixPolicy(baseRegularPriorityCount: 2, regularPriorityPercentageAboveBase: 50);

                    var createVmssResponse = CreateVMScaleSet_NoAsyncTracking(
                        rgName,
                        vmssName,
                        storageAccountOutput,
                        imageRef,
                        out inputVMScaleSet,
                        null,
                        (vmScaleSet) =>
                        {
                            vmScaleSet.VirtualMachineProfile.Priority = VirtualMachinePriorityTypes.Spot;
                            vmScaleSet.VirtualMachineProfile.EvictionPolicy = VirtualMachineEvictionPolicyTypes.Deallocate;
                            vmScaleSet.OrchestrationMode = OrchestrationMode.Flexible.ToString();
                            vmScaleSet.Sku.Name = VirtualMachineSizeTypes.StandardA1V2;
                            vmScaleSet.Sku.Tier = "Standard";
                            vmScaleSet.Sku.Capacity = 4;
                            vmScaleSet.PriorityMixPolicy = priorityMixPolicy;
                            vmScaleSet.PlatformFaultDomainCount = 1;
                            vmScaleSet.UpgradePolicy = null;
                            vmScaleSet.Overprovision = null;
                            vmScaleSet.SinglePlacementGroup = false;
                            vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkApiVersion = NetworkApiVersion.TwoZeroTwoZeroHyphenMinusOneOneHyphenMinusZeroOne;
                            vmScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].PublicIPAddressConfiguration = publicIPConfiguration;
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false);

                    ValidateVMScaleSet(inputVMScaleSet, createVmssResponse, true);

                    VirtualMachineScaleSet getVmss = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                    ValidateVMScaleSet(inputVMScaleSet, getVmss, true);
                    
                    Assert.NotNull(getVmss);
                    Assert.NotNull(getVmss.PriorityMixPolicy);
                    Assert.Equal(2, getVmss.PriorityMixPolicy.BaseRegularPriorityCount);
                    Assert.Equal(50, getVmss.PriorityMixPolicy.RegularPriorityPercentageAboveBase);

                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                }
                finally
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                    // clean up the created resources
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_ScheduledEvents")]
        public void TestVMScaleSetScenarioOperations_ScheduledEvents()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    TestScaleSetOperationsInternal(context, hasManagedDisks: true, useVmssExtension: false,
                        vmScaleSetCustomizer:
                        vmScaleSet =>
                        {
                            vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile = new ScheduledEventsProfile
                            {
                                TerminateNotificationProfile = new TerminateNotificationProfile
                                {
                                    Enable = true,
                                    NotBeforeTimeout = "PT6M",
                                },
                                OsImageNotificationProfile = new OSImageNotificationProfile
                                {
                                    Enable = true,
                                    NotBeforeTimeout = "PT15M",
                                }
                            };
                        },
                        vmScaleSetValidator: vmScaleSet =>
                        {
                            Assert.True(true == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.TerminateNotificationProfile?.Enable);
                            Assert.True("PT6M" == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.TerminateNotificationProfile?.NotBeforeTimeout);
                            Assert.True(true == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.OsImageNotificationProfile?.Enable);
                            Assert.True("PT15M" == vmScaleSet.VirtualMachineProfile.ScheduledEventsProfile?.OsImageNotificationProfile?.NotBeforeTimeout);
                        });
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest")]
        public void TestVMScaleSetScenarioOperations_AutomaticRepairsPolicyTest()
        {
            string environmentVariable = "AZURE_VM_TEST_LOCATION";
            string region = "eastus";
            string originalTestLocation = Environment.GetEnvironmentVariable(environmentVariable);

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    Environment.SetEnvironmentVariable(environmentVariable, region);
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
                            },
                            createWithManagedDisks: true,
                            createWithPublicIpAddress: false,
                            createWithHealthProbe: true);

                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Set Automatic Repairs to true 
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = true
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Update Automatic Repairs default values 
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = true,
                            GracePeriod = "PT35M",
                            RepairAction = "replace"
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);

                        // Set automatic repairs to null 
                        inputVMScaleSet.AutomaticRepairsPolicy = null;
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == true);
                        Assert.Equal("PT35M", getResponse.AutomaticRepairsPolicy.GracePeriod, ignoreCase: true);
                        Assert.Equal("replace", getResponse.AutomaticRepairsPolicy.RepairAction, ignoreCase: true);

                        // Test other repair actions. Must disable before changing repair action
                        foreach (string repairAction in new List<string> { "restart", "reimage" })
                        {
                            // Disable auto repairs so we can update repair Action
                            inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                            {
                                Enabled = false,
                            };
                            UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);
                            getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                            Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == false);

                            // Now we can update repairAction
                            inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                            {
                                Enabled = true,
                                GracePeriod = "PT35M",
                                RepairAction = repairAction
                            };
                            UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                            getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                            ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                            Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                            Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == true);
                            Assert.Equal("PT35M", getResponse.AutomaticRepairsPolicy.GracePeriod, ignoreCase: true);
                            Assert.Equal(repairAction, getResponse.AutomaticRepairsPolicy.RepairAction, ignoreCase: true);
                        }

                        // Disable Automatic Repairs
                        inputVMScaleSet.AutomaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = false
                        };
                        UpdateVMScaleSet(rgName, vmssName, inputVMScaleSet);

                        getResponse = m_CrpClient.VirtualMachineScaleSets.Get(rgName, vmssName);
                        Assert.NotNull(getResponse.AutomaticRepairsPolicy);
                        Assert.True(getResponse.AutomaticRepairsPolicy.Enabled == false);
                    }
                    finally
                    {
                        //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                        //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                        m_ResourcesClient.ResourceGroups.Delete(rgName);
                    }
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_OrchestrationService")]
        public void TestVMScaleSetScenarioOperations_OrchestrationService()
        {
            string environmentVariable = "AZURE_VM_TEST_LOCATION";
            string region = "eastus";
            string originalTestLocation = Environment.GetEnvironmentVariable(environmentVariable);

            try
            {
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    Environment.SetEnvironmentVariable(environmentVariable, region);
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

                        AutomaticRepairsPolicy automaticRepairsPolicy = new AutomaticRepairsPolicy()
                        {
                            Enabled = true
                        };
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
                            },
                            createWithManagedDisks: true,
                            createWithPublicIpAddress: false,
                            createWithHealthProbe: true,
                            automaticRepairsPolicy: automaticRepairsPolicy);

                        ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                        var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);

                        Assert.True(getInstanceViewResponse.OrchestrationServices.Count == 1);
                        Assert.Equal("Running", getInstanceViewResponse.OrchestrationServices[0].ServiceState);
                        Assert.Equal("AutomaticRepairs", getInstanceViewResponse.OrchestrationServices[0].ServiceName);

                        OrchestrationServiceStateInput orchestrationServiceStateInput = new OrchestrationServiceStateInput()
                        {
                            ServiceName = OrchestrationServiceNames.AutomaticRepairs,
                            Action = OrchestrationServiceStateAction.Suspend
                        };

                        m_CrpClient.VirtualMachineScaleSets.SetOrchestrationServiceState(rgName, vmssName, orchestrationServiceStateInput);

                        getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                        Assert.Equal(OrchestrationServiceState.Suspended.ToString(), getInstanceViewResponse.OrchestrationServices[0].ServiceState);

                        orchestrationServiceStateInput.Action = OrchestrationServiceStateAction.Resume;
                        m_CrpClient.VirtualMachineScaleSets.SetOrchestrationServiceState(rgName, vmssName, orchestrationServiceStateInput);
                        getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                        Assert.Equal(OrchestrationServiceState.Running.ToString(), getInstanceViewResponse.OrchestrationServices[0].ServiceState);

                        //m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                    }
                    finally
                    {
                        //Cleanup the created resources. But don't wait since it takes too long, and it's not the purpose
                        //of the test to cover deletion. CSM does persistent retrying over all RG resources.
                        m_ResourcesClient.ResourceGroups.Delete(rgName);
                    }
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperations_DisablingHyperthreadingAndConstrainedvCPUsScenario")]
        public void TestVMScaleSetScenarioOperations_DisablingHyperthreadingAndConstrainedvCPUsScenario()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            try
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                using (MockContext context = MockContext.Start(this.GetType()))
                {
                    EnsureClientsInitialized(context);

                    TestScaleSetOperationsInternal(context, vmSize: VirtualMachineSizeTypes.StandardD4V3,
                        hardwareProfile: new VirtualMachineScaleSetHardwareProfile(),
                        vmScaleSetCustomizer:
                        vmScaleSet =>
                        {
                            vmScaleSet.VirtualMachineProfile.HardwareProfile.VmSizeProperties = new VMSizeProperties
                            {
                                VCPUsAvailable = 1,
                                VCPUsPerCore = 1
                            };
                        },
                        vmScaleSetValidator: vmScaleSet =>
                        {
                            Assert.True(1 == vmScaleSet.VirtualMachineProfile.HardwareProfile?.VmSizeProperties?.VCPUsAvailable);
                            Assert.True(1 == vmScaleSet.VirtualMachineProfile.HardwareProfile?.VmSizeProperties?.VCPUsPerCore);
                        });
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
            }
        }

        /// <summary>
        /// This test creates a VMSS with PIR image and serviceArtifactReference defined.
        /// Once the VMSS is created, it verifies whether the response contains serviceArtifactReference or not
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperation_PirImageWithServiceArtifactReferenceId")]
        public void TestVMScaleSetScenarioOperation_PirImageWithServiceArtifactReferenceId()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                var serviceArtifaceReferenceId = "/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/crparcobvt/providers/Microsoft.Compute/galleries/galleryForArcoBvt/serviceArtifacts/serviceArtifactWithPirImage/vmArtifactsProfiles/myVMP";

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = new ImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2022-datacenter",
                        Version = "latest"
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
                            vmScaleSet.VirtualMachineProfile.ServiceArtifactReference = new ServiceArtifactReference()
                            {
                                Id = serviceArtifaceReferenceId
                            };
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Automatic;
                            vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                            {
                                EnableAutomaticOSUpgrade = true
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    Assert.True(string.Equals(serviceArtifaceReferenceId, getResponse.VirtualMachineProfile.ServiceArtifactReference.Id, StringComparison.OrdinalIgnoreCase),
                        "ServiceArtifactReference.Id are not matching");
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
        /// This test creates a VMSS with PIR image and securityPostureReference defined.
        /// Once the VMSS is created, it verifies whether the response contains securityPostureReference or not
        /// </summary>
        [Fact]
        [Trait("Name", "TestVMScaleSetScenarioOperation_SecurityPostureReferenceId")]
        public void TestVMScaleSetScenarioOperation_SecurityPostureReferenceId()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");

                // Create resource group
                var rgName = TestUtilities.GenerateName(TestPrefix);
                var vmssName = TestUtilities.GenerateName("vmss");
                string storageAccountName = TestUtilities.GenerateName(TestPrefix);
                VirtualMachineScaleSet inputVMScaleSet;
                var securityPostureId = "/CommunityGalleries/Microsoft.Compute/SecurityPostures/WindowsVMSS/versions/1.0.0";

                try
                {
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
                    EnsureClientsInitialized(context);
                    ImageReference imageRef = new ImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2022-datacenter",
                        Version = "latest"
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
                            vmScaleSet.VirtualMachineProfile.SecurityPostureReference = new SecurityPostureReference()
                            {
                                Id = securityPostureId
                            };
                            vmScaleSet.Overprovision = false;
                            vmScaleSet.UpgradePolicy.Mode = UpgradeMode.Automatic;
                            vmScaleSet.UpgradePolicy.AutomaticOSUpgradePolicy = new AutomaticOSUpgradePolicy()
                            {
                                EnableAutomaticOSUpgrade = true
                            };
                        },
                        createWithManagedDisks: true,
                        createWithPublicIpAddress: false,
                        createWithHealthProbe: true);

                    ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks: true);
                    Assert.True(string.Equals(securityPostureId, getResponse.VirtualMachineProfile.SecurityPostureReference?.Id, StringComparison.OrdinalIgnoreCase),
                        "SecurityPostureReference.Id are not matching");
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

        private void TestScaleSetOperationsInternal(MockContext context, string vmSize = null, bool hasManagedDisks = false, bool useVmssExtension = true, 
            bool hasDiffDisks = false, IList<string> zones = null, int? osDiskSizeInGB = null, bool isPpgScenario = false, bool? enableUltraSSD = false, 
            Action<VirtualMachineScaleSet> vmScaleSetCustomizer = null, Action<VirtualMachineScaleSet> vmScaleSetValidator = null, string diskEncryptionSetId = null,
            bool? encryptionAtHostEnabled = null, bool isAutomaticPlacementOnDedicatedHostGroupScenario = false,
            int? faultDomainCount = null, int? capacity = null, bool shouldOverProvision = true, bool validateVmssVMInstanceView = false,
            ImageReference imageReference = null, bool validateListSku = true, bool deleteAsPartOfTest = true,
            bool associateWithCapacityReservationGroup = false, VirtualMachineScaleSetHardwareProfile hardwareProfile = null)
        {
            EnsureClientsInitialized(context);

            ImageReference imageRef = imageReference ?? GetPlatformVMImage(useWindowsImage: true);
            const string expectedOSName = "Windows Server 2012 R2 Datacenter", expectedOSVersion = "Microsoft Windows NT 6.3.9600.0", expectedComputerName = "test000000", expectedHyperVGeneration = "V1";

            // Create resource group
            var rgName = TestUtilities.GenerateName(TestPrefix);
            var vmssName = TestUtilities.GenerateName("vmss");
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            VirtualMachineScaleSet inputVMScaleSet;

            VirtualMachineScaleSetExtensionProfile extensionProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = new List<VirtualMachineScaleSetExtension>()
                {
                    GetTestVMSSVMExtension(autoUpdateMinorVersion:false),
                }
            };

            try
            {
                var storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                m_CrpClient.VirtualMachineScaleSets.Delete(rgName, "VMScaleSetDoesNotExist");

                string ppgId = null;
                string ppgName = null;
                if (isPpgScenario)
                {
                    ppgName = ComputeManagementTestUtilities.GenerateName("ppgtest");
                    ppgId = CreateProximityPlacementGroup(rgName, ppgName);
                }

                string dedicatedHostGroupName = null, dedicatedHostName = null, dedicatedHostGroupReferenceId = null, dedicatedHostReferenceId = null;
                if (isAutomaticPlacementOnDedicatedHostGroupScenario)
                {
                    dedicatedHostGroupName = ComputeManagementTestUtilities.GenerateName("dhgtest");
                    dedicatedHostName = ComputeManagementTestUtilities.GenerateName("dhtest");
                    dedicatedHostGroupReferenceId = Helpers.GetDedicatedHostGroupRef(m_subId, rgName, dedicatedHostGroupName);
                    dedicatedHostReferenceId = Helpers.GetDedicatedHostRef(m_subId, rgName, dedicatedHostGroupName, dedicatedHostName);
                }

                bool singlePlacementGroup = true;
                string capacityReservationGroupName = null, capacityReservationGroupReferenceId = null, capacityReservationName = null;
                if (associateWithCapacityReservationGroup)
                {
                    capacityReservationGroupName = ComputeManagementTestUtilities.GenerateName("crgtest");
                    capacityReservationName = ComputeManagementTestUtilities.GenerateName("crtest");
                    CreateCapacityReservationGroup(rgName, capacityReservationGroupName);
                    CreateCapacityReservation(rgName, capacityReservationGroupName, capacityReservationName, VirtualMachineSizeTypes.StandardDS1V2, reservedCount: 1);
                    capacityReservationGroupReferenceId = Helpers.GetCapacityReservationGroupRef(m_subId, rgName, capacityReservationGroupName);
                    singlePlacementGroup = false;
                }

                VirtualMachineScaleSet getResponse = CreateVMScaleSet_NoAsyncTracking(
                    rgName,
                    vmssName,
                    storageAccountOutput,
                    imageRef,
                    out inputVMScaleSet,
                    useVmssExtension ? extensionProfile : null,
                    (vmScaleSet) => {
                        vmScaleSet.Overprovision = shouldOverProvision;
                        if (!String.IsNullOrEmpty(vmSize))
                        {
                            vmScaleSet.Sku.Name = vmSize;
                        }
                        vmScaleSetCustomizer?.Invoke(vmScaleSet);
                    },
                    createWithManagedDisks: hasManagedDisks,
                    hasDiffDisks : hasDiffDisks,
                    zones: zones,
                    osDiskSizeInGB: osDiskSizeInGB,
                    ppgId: ppgId,
                    enableUltraSSD: enableUltraSSD,
                    diskEncryptionSetId: diskEncryptionSetId,
                    encryptionAtHostEnabled: encryptionAtHostEnabled,
                    faultDomainCount: faultDomainCount,
                    capacity: capacity,
                    dedicatedHostGroupReferenceId: dedicatedHostGroupReferenceId,
                    dedicatedHostGroupName: dedicatedHostGroupName,
                    dedicatedHostName: dedicatedHostName,
                    capacityReservationGroupReferenceId: capacityReservationGroupReferenceId,
                    singlePlacementGroup: singlePlacementGroup,
                    hardwareProfile: hardwareProfile);

                if (diskEncryptionSetId != null)
                {
                    Assert.True(getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet != null, "OsDisk.ManagedDisk.DiskEncryptionSet is null");
                    Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.OsDisk.ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                        "OsDisk.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");

                    Assert.Equal(1, getResponse.VirtualMachineProfile.StorageProfile.DataDisks.Count);
                    Assert.True(getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet != null, ".DataDisks.ManagedDisk.DiskEncryptionSet is null");
                    Assert.True(string.Equals(diskEncryptionSetId, getResponse.VirtualMachineProfile.StorageProfile.DataDisks[0].ManagedDisk.DiskEncryptionSet.Id, StringComparison.OrdinalIgnoreCase),
                        "DataDisks.ManagedDisk.DiskEncryptionSet.Id is not matching with expected DiskEncryptionSet resource");
                }

                if (!string.IsNullOrEmpty(capacityReservationGroupReferenceId))
                {
                    Assert.True(getResponse.VirtualMachineProfile.CapacityReservation.CapacityReservationGroup != null, "CapacityReservation.CapacityReservationGroup is null");
                    Assert.True(string.Equals(capacityReservationGroupReferenceId, getResponse.VirtualMachineProfile.CapacityReservation.CapacityReservationGroup.Id, StringComparison.OrdinalIgnoreCase),
                        "CapacityReservation.CapacityReservationGroup.Id is not matching with expected CapacityReservationGroup resource");

                    CapacityReservation capacityReservation =
                         m_CrpClient.CapacityReservations.Get(rgName, capacityReservationGroupName, capacityReservationName, CapacityReservationInstanceViewTypes.InstanceView);

                    var queryForVmssVM = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                    queryForVmssVM.SetFilter(vm => vm.LatestModelApplied == true);
                    var listVmssVMsResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, queryForVmssVM);
                    string expectedVMReferenceId = Helpers.GetVMScaleSetVMReferenceId(m_subId, rgName, vmssName, listVmssVMsResponse.First().InstanceId);

                    Assert.True(capacityReservation.VirtualMachinesAssociated.Any(), "capacityReservation.VirtualMachinesAssociated is not empty");
                    Assert.True(string.Equals(expectedVMReferenceId, capacityReservation.VirtualMachinesAssociated.First().Id, StringComparison.OrdinalIgnoreCase),
                        "capacityReservation.VirtualMachinesAssociated are not matching");

                    /*
                    Assert.True(capacityReservation.InstanceView.UtilizationInfo.VirtualMachinesAllocated.Any(), "InstanceView.UtilizationInfo.VirtualMachinesAllocated is empty");
                    Assert.True(string.Equals(expectedVMReferenceId, capacityReservation.InstanceView.UtilizationInfo.VirtualMachinesAllocated.First().Id),
                        "InstanceView.UtilizationInfo.VirtualMachinesAllocated are not matching");
                    */
                }

                if (encryptionAtHostEnabled != null)
                {
                    Assert.True(getResponse.VirtualMachineProfile.SecurityProfile.EncryptionAtHost == encryptionAtHostEnabled.Value, 
                        "SecurityProfile.EncryptionAtHost is not same as expected");
                }

                ValidateVMScaleSet(inputVMScaleSet, getResponse, hasManagedDisks, ppgId: ppgId, dedicatedHostGroupReferenceId: dedicatedHostGroupReferenceId);

                var getInstanceViewResponse = m_CrpClient.VirtualMachineScaleSets.GetInstanceView(rgName, vmssName);
                Assert.NotNull(getInstanceViewResponse);
                ValidateVMScaleSetInstanceView(inputVMScaleSet, getInstanceViewResponse);

                if (isPpgScenario)
                {
                    ProximityPlacementGroup outProximityPlacementGroup = m_CrpClient.ProximityPlacementGroups.Get(rgName, ppgName);
                    Assert.Equal(1, outProximityPlacementGroup.VirtualMachineScaleSets.Count);
                    string expectedVmssReferenceId = Helpers.GetVMScaleSetReferenceId(m_subId, rgName, vmssName);
                    Assert.Equal(expectedVmssReferenceId, outProximityPlacementGroup.VirtualMachineScaleSets.First().Id, StringComparer.OrdinalIgnoreCase);
                }

                var listResponse = m_CrpClient.VirtualMachineScaleSets.List(rgName);
                ValidateVMScaleSet(inputVMScaleSet, listResponse.FirstOrDefault(x => x.Name == vmssName), hasManagedDisks);

                if (validateListSku)
                {
                    var listSkusResponse = m_CrpClient.VirtualMachineScaleSets.ListSkus(rgName, vmssName);
                    Assert.NotNull(listSkusResponse);
                    Assert.False(listSkusResponse.Count() == 0);
                }

                if (zones != null)
                {
                    var query = new Microsoft.Rest.Azure.OData.ODataQuery<VirtualMachineScaleSetVM>();
                    query.SetFilter(vm => vm.LatestModelApplied == true);
                    var listVMsResponse = m_CrpClient.VirtualMachineScaleSetVMs.List(rgName, vmssName, query);
                    Assert.False(listVMsResponse == null, "VMScaleSetVMs not returned");
                    Assert.True(listVMsResponse.Count() == inputVMScaleSet.Sku.Capacity);

                    foreach (var vmScaleSetVM in listVMsResponse)
                    {
                        string instanceId = vmScaleSetVM.InstanceId;
                        var getVMResponse = m_CrpClient.VirtualMachineScaleSetVMs.Get(rgName, vmssName, instanceId);
                        ValidateVMScaleSetVM(inputVMScaleSet, instanceId, getVMResponse, hasManagedDisks);
                    }
                }

                if (validateVmssVMInstanceView)
                {
                    VirtualMachineScaleSetVMInstanceView vmssVMInstanceView = m_CrpClient.VirtualMachineScaleSetVMs.GetInstanceView(rgName, vmssName, "0");
                    ValidateVMScaleSetVMInstanceView(vmssVMInstanceView, hasManagedDisks, expectedComputerName, expectedOSName, expectedOSVersion, expectedHyperVGeneration, dedicatedHostReferenceId);
                }

                vmScaleSetValidator?.Invoke(getResponse);

                if (deleteAsPartOfTest)
                {
                    m_CrpClient.VirtualMachineScaleSets.Delete(rgName, vmssName);
                }
            }
            finally
            {
                if (deleteAsPartOfTest)
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
                else
                {
                    // Fire and forget. No need to wait for RG deletion completion
                    m_ResourcesClient.ResourceGroups.BeginDelete(rgName);
                }
            }
        }
    }
}
