﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using Xunit;

namespace Compute.Tests
{
    public class VMAutoPatchSettingTests : VMTestBase
    {
        private const PassNames OOBESystem = PassNames.OobeSystem;
        private const ComponentNames MicrosoftWindowsShellSetup = ComponentNames.MicrosoftWindowsShellSetup;
        private const SettingNames AutoLogon = SettingNames.AutoLogon;

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsValueOfManual()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                StartPatchSettingTest(context, "Manual", useWindowsProfile: true, enableAutomaticUpdates: false, enableHotpatching: false);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsValueOfAutomaticByOS()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                StartPatchSettingTest(context, "AutomaticByOS", useWindowsProfile: true, enableAutomaticUpdates: true, enableHotpatching: false);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsValueOfAutomaticByPlatform()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // NOTE: add a test for enableHotpatching once it is available in all regions
                StartPatchSettingTest(context, "AutomaticByPlatform", useWindowsProfile: true, enableAutomaticUpdates: true, enableHotpatching: false);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationPatchSettingsValueOfAutomaticByPlatform()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                StartPatchSettingTest(context, "AutomaticByPlatform", useWindowsProfile: false);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationPatchSettingsValueOfImageDefault()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                StartPatchSettingTest(context, "ImageDefault", useWindowsProfile: false);
            }
        }

        private void StartPatchSettingTest(MockContext context, string patchSettingMode, bool useWindowsProfile, bool enableAutomaticUpdates = false, bool enableHotpatching = false)
        {
            EnsureClientsInitialized(context);

            string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);

            string autoLogonContent = null;
            Action<VirtualMachine> configurePatchSetting;
            Action<VirtualMachine> validateConfigurationPatchSetting;
            if (useWindowsProfile)
            {
                // The following variables are defined here to allow validation
                var windowsPatchSetting = new PatchSettings
                {
                    PatchMode = patchSettingMode,
                    EnableHotpatching = enableHotpatching
                };

                configurePatchSetting = inputVM =>
                {
                    autoLogonContent = GetAutoLogonContent(5, inputVM.OsProfile.AdminUsername, inputVM.OsProfile.AdminPassword);
                    SetWindowsConfigurationPatchSettings(windowsPatchSetting, enableAutomaticUpdates, autoLogonContent, inputVM);
                };

                validateConfigurationPatchSetting =
                    outputVM => ValidateWinPatchSetting(windowsPatchSetting.PatchMode, enableAutomaticUpdates, enableHotpatching, outputVM);
            }
            else
            {
                // The following variables are defined here to allow validation
                var linuxPatchSetting = new LinuxPatchSettings
                {
                    PatchMode = patchSettingMode,
                };

                configurePatchSetting = inputVM =>
                {
                    autoLogonContent = GetAutoLogonContent(5, inputVM.OsProfile.AdminUsername, inputVM.OsProfile.AdminPassword);
                    SetLinuxConfigurationPatchSettings(linuxPatchSetting, inputVM);
                };

                validateConfigurationPatchSetting =
                    outputVM => ValidateLinuxPatchSetting(linuxPatchSetting.PatchMode, enableHotpatching, outputVM);
            }

            TestVMWithOSProfile(
                rgName: rgName,
                useWindowsProfile: useWindowsProfile,
                vmCustomizer: configurePatchSetting,
                vmValidator: validateConfigurationPatchSetting);
        }

        private void ValidateWinPatchSetting(string patchSettingMode, bool enableAutomaticUpdates, bool enableHotpatching, VirtualMachine outputVM)
        {
            var osProfile = outputVM.OsProfile;

            Assert.Null(osProfile.LinuxConfiguration);
            Assert.NotNull(osProfile.WindowsConfiguration);

            Assert.True(osProfile.WindowsConfiguration.ProvisionVMAgent != null && osProfile.WindowsConfiguration.ProvisionVMAgent.Value);
            Assert.True(osProfile.WindowsConfiguration.EnableAutomaticUpdates != null && osProfile.WindowsConfiguration.EnableAutomaticUpdates.Value == enableAutomaticUpdates);
            
            // PatchSetting
            Assert.NotNull(osProfile.WindowsConfiguration.PatchSettings);
            Assert.NotNull(osProfile.WindowsConfiguration.PatchSettings.PatchMode);
            Assert.Equal(osProfile.WindowsConfiguration.PatchSettings.PatchMode, patchSettingMode);
            Assert.Equal(osProfile.WindowsConfiguration.PatchSettings.EnableHotpatching, enableHotpatching);
        }

        private void ValidateLinuxPatchSetting(string patchSettingMode, bool enableHotpatching, VirtualMachine outputVM)
        {
            var osProfile = outputVM.OsProfile;

            Assert.NotNull(osProfile.LinuxConfiguration);
            Assert.Null(osProfile.WindowsConfiguration);

            Assert.True(osProfile.LinuxConfiguration.ProvisionVMAgent != null && osProfile.LinuxConfiguration.ProvisionVMAgent.Value);

            // PatchSetting
            Assert.NotNull(osProfile.LinuxConfiguration.PatchSettings);
            Assert.NotNull(osProfile.LinuxConfiguration.PatchSettings.PatchMode);
            Assert.Equal(osProfile.LinuxConfiguration.PatchSettings.PatchMode, patchSettingMode);
        }

        private void TestVMWithOSProfile(
           string rgName,
           bool useWindowsProfile,
           Action<VirtualMachine> vmCustomizer = null,
           Action<VirtualMachine> vmValidator = null)
        {
            string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            string asName = ComputeManagementTestUtilities.GenerateName("as");

            ImageReference imageRef = useWindowsProfile ? GetPlatformVMImage(useWindowsProfile) : GetPlatformVMImage(useWindowsProfile, "16.04-LTS");

            VirtualMachine inputVM;
            try
            {
                StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachine vm = CreateVM(rgName, asName, storageAccountOutput, imageRef, out inputVM, vmCustomizer);

                var getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.Get(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
                ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

                var lroResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, vm.Name, vm);
                Assert.True(lroResponse.ProvisioningState == "Succeeded");
                if (vmValidator != null)
                {
                    vmValidator(vm);
                }

                m_CrpClient.VirtualMachines.BeginDelete(rgName, vm.Name);
            }
            finally
            {
                if (m_ResourcesClient != null)
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private static string GetAutoLogonContent(uint logonCount, string userName, string password)
        {
            return string.Format(
                "<AutoLogon>" +
                "<Enabled>true</Enabled>" +
                "<LogonCount>{0}</LogonCount>" +
                "<Username>{1}</Username>" +
                "<Password><Value>{2}</Value><PlainText>true</PlainText></Password>" +
                "</AutoLogon>", logonCount, userName, password);
        }

        private void SetWindowsConfigurationPatchSettings(PatchSettings windowsPatchSetting,  bool enableAutomaticUpdates, string autoLogonContent, VirtualMachine inputVM)
        {
            var osProfile = inputVM.OsProfile;
            osProfile.WindowsConfiguration = new WindowsConfiguration
            {
                ProvisionVMAgent = true,
                EnableAutomaticUpdates = enableAutomaticUpdates,
                PatchSettings = windowsPatchSetting,
                AdditionalUnattendContent = new List<AdditionalUnattendContent>
                    {
                        new AdditionalUnattendContent
                        {
                            PassName = OOBESystem,
                            ComponentName = MicrosoftWindowsShellSetup,
                            SettingName = AutoLogon,
                            Content = autoLogonContent
                        }
                    },
            };
        }

        private void SetLinuxConfigurationPatchSettings(LinuxPatchSettings linuxPatchSetting, VirtualMachine inputVM)
        {
            var osProfile = inputVM.OsProfile;
            osProfile.LinuxConfiguration = new LinuxConfiguration
            {
                ProvisionVMAgent = true,
                PatchSettings = linuxPatchSetting,
            };
        }
    }
}
