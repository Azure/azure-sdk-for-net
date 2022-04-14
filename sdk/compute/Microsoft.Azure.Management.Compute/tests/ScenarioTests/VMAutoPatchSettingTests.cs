// Copyright (c) Microsoft Corporation. All rights reserved.
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
                var patchSettings = new PatchSettings
                {
                    PatchMode = "Manual"
                };
                StartPatchSettingTest(context, useWindowsProfile: true, enableAutomaticUpdates: false, windowsPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsValueOfAutomaticByOS()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new PatchSettings
                {
                    PatchMode = "AutomaticByOS",
                };
                StartPatchSettingTest(context, useWindowsProfile: true, enableAutomaticUpdates: true, windowsPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsValuesOfAutomaticByPlatform()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new PatchSettings
                {
                    PatchMode = "AutomaticByPlatform",
                    AssessmentMode = "AutomaticByPlatform",
                };
                StartPatchSettingTest(context, useWindowsProfile: true, enableAutomaticUpdates: false, windowsPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationAutomaticByPlatformSettings()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new PatchSettings
                {
                    PatchMode = "AutomaticByPlatform",
                };
                patchSettings.AutomaticByPlatformSettings = new WindowsVMGuestPatchAutomaticByPlatformSettings
                {
                    RebootSetting = "IfRequired",
                };
                StartPatchSettingTest(context, useWindowsProfile: true, enableAutomaticUpdates: false, windowsPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingWindowsConfigurationPatchSettingsAssessmentModeOfImageDefault()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new PatchSettings
                {
                    AssessmentMode = "ImageDefault",
                };
                StartPatchSettingTest(context, useWindowsProfile: true, enableAutomaticUpdates: false, windowsPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationPatchSettingsValueOfImageDefault()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new LinuxPatchSettings
                {
                    PatchMode = "ImageDefault"
                };
                StartPatchSettingTest(context, useWindowsProfile: false, enableAutomaticUpdates: false, linuxPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationPatchSettingsValuesOfAutomaticByPlatform()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new LinuxPatchSettings
                {
                    PatchMode = "AutomaticByPlatform",
                    AssessmentMode = "AutomaticByPlatform",
                };
                StartPatchSettingTest(context, useWindowsProfile: false, enableAutomaticUpdates: false, linuxPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationAutomaticByPlatformSettings()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new LinuxPatchSettings
                {
                    PatchMode = "AutomaticByPlatform",
                };
                patchSettings.AutomaticByPlatformSettings = new LinuxVMGuestPatchAutomaticByPlatformSettings
                {
                    RebootSetting = "IfRequired",
                };
                StartPatchSettingTest(context, useWindowsProfile: false, enableAutomaticUpdates: false, linuxPatchSettings: patchSettings);
            }
        }

        [Fact()]
        public void TestVMWithSettingLinuxConfigurationPatchSettingsAssessmentModeOfImageDefault()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var patchSettings = new LinuxPatchSettings
                {
                    AssessmentMode = "ImageDefault",
                };
                StartPatchSettingTest(context, useWindowsProfile: false, enableAutomaticUpdates: false, linuxPatchSettings: patchSettings);
            }
        }

        private void StartPatchSettingTest(MockContext context, bool useWindowsProfile, bool enableAutomaticUpdates, PatchSettings windowsPatchSettings=null, LinuxPatchSettings linuxPatchSettings=null)
        {
            EnsureClientsInitialized(context);

            string rgName = ComputeManagementTestUtilities.GenerateName(TestPrefix);

            // The following variables are defined here to allow validation
            string autoLogonContent = null;
            Action<VirtualMachine> configurePatchSetting;
            Action<VirtualMachine> validateConfigurationPatchSetting;

            if(useWindowsProfile)
            {
                configurePatchSetting = inputVM =>
                {
                    autoLogonContent = GetAutoLogonContent(5, inputVM.OsProfile.AdminUsername, inputVM.OsProfile.AdminPassword);
                    SetWindowsConfigurationPatchSettings(windowsPatchSettings, enableAutomaticUpdates, autoLogonContent, inputVM);
                };

                validateConfigurationPatchSetting = 
                    outputVM => ValidateWinPatchSettings(windowsPatchSettings, enableAutomaticUpdates, autoLogonContent, outputVM);
            }
            else
            {
                configurePatchSetting = inputVM =>
                {
                    SetLinuxConfigurationPatchSettings(linuxPatchSettings, inputVM);
                };

                validateConfigurationPatchSetting =
                    outputVM => ValidateLinuxPatchSettings(linuxPatchSettings, outputVM);
            }

            TestVMWithOSProfile(
                rgName: rgName,
                useWindowsProfile: useWindowsProfile,
                vmCustomizer: configurePatchSetting,
                vmValidator: validateConfigurationPatchSetting);
            
        }

        private void ValidateWinPatchSettings(PatchSettings windowsPatchSettings, bool enableAutomaticUpdates, string autoLogonContent, VirtualMachine outputVM)
        {
            var osProfile = outputVM.OsProfile;

            Assert.Null(osProfile.LinuxConfiguration);
            Assert.NotNull(osProfile.WindowsConfiguration);

            Assert.True(osProfile.WindowsConfiguration.ProvisionVMAgent != null && osProfile.WindowsConfiguration.ProvisionVMAgent.Value);
            Assert.True(osProfile.WindowsConfiguration.EnableAutomaticUpdates != null && osProfile.WindowsConfiguration.EnableAutomaticUpdates.Value == enableAutomaticUpdates);

            // PatchSetting checks
            Assert.NotNull(osProfile.WindowsConfiguration.PatchSettings);
            Assert.Equal(osProfile.WindowsConfiguration.PatchSettings.EnableHotpatching, windowsPatchSettings.EnableHotpatching);

            if (windowsPatchSettings.PatchMode != null)
            {
                Assert.NotNull(osProfile.WindowsConfiguration.PatchSettings.PatchMode);
                Assert.Equal(osProfile.WindowsConfiguration.PatchSettings.PatchMode, windowsPatchSettings.PatchMode);

                // Verifying AutomaticByPlatformSettings
                if (osProfile.WindowsConfiguration.PatchSettings.PatchMode == "AutomaticByPlatform" &&
                    osProfile.WindowsConfiguration.PatchSettings.AutomaticByPlatformSettings != null)
                {
                    Assert.Equal("IfRequired", osProfile.WindowsConfiguration.PatchSettings.AutomaticByPlatformSettings.RebootSetting);
                }
            }
            else
            {
                // By default in supported API versions, a value is provided in the VM model even if one is
                // not specified by the user. 
                Assert.Null(osProfile.WindowsConfiguration.PatchSettings.AutomaticByPlatformSettings);
                if (osProfile.WindowsConfiguration.EnableAutomaticUpdates == false)
                {
                    Assert.Equal("Manual", osProfile.WindowsConfiguration.PatchSettings.PatchMode);
                }
                else
                {
                    Assert.Equal("AutomaticByOS", osProfile.WindowsConfiguration.PatchSettings.PatchMode);
                }
                
            }

            if (windowsPatchSettings.AssessmentMode != null)
            {
                Assert.NotNull(osProfile.WindowsConfiguration.PatchSettings.AssessmentMode);
                Assert.Equal(osProfile.WindowsConfiguration.PatchSettings.AssessmentMode, windowsPatchSettings.AssessmentMode);
            }
            else
            {
                // By default in supported API versions, a value is provided in the VM model even if one is
                // not specified by the user.
                Assert.Equal("ImageDefault", osProfile.WindowsConfiguration.PatchSettings.AssessmentMode);
            }
        }

        private void ValidateLinuxPatchSettings(LinuxPatchSettings linuxPatchSettings, VirtualMachine outputVM)
        {
            var osProfile = outputVM.OsProfile;

            Assert.NotNull(osProfile.LinuxConfiguration);
            Assert.Null(osProfile.WindowsConfiguration);

            Assert.True(osProfile.LinuxConfiguration.ProvisionVMAgent != null && osProfile.LinuxConfiguration.ProvisionVMAgent.Value);

            // PatchSetting checks
            Assert.NotNull(osProfile.LinuxConfiguration.PatchSettings);
            if (linuxPatchSettings.PatchMode != null)
            {
                Assert.NotNull(osProfile.LinuxConfiguration.PatchSettings.PatchMode);
                Assert.Equal(osProfile.LinuxConfiguration.PatchSettings.PatchMode, linuxPatchSettings.PatchMode);

                // Verifying AutomaticByPlatformSettings
                if (osProfile.LinuxConfiguration.PatchSettings.PatchMode == "AutomaticByPlatform" &&
                    osProfile.LinuxConfiguration.PatchSettings.AutomaticByPlatformSettings != null)
                {
                    Assert.Equal("IfRequired", osProfile.LinuxConfiguration.PatchSettings.AutomaticByPlatformSettings.RebootSetting);
                }
            }
            else
            {
                // By default in supported API versions, a value is provided in the VM model even if one is
                // not specified by the user. 
                Assert.Equal("ImageDefault", osProfile.LinuxConfiguration.PatchSettings.PatchMode);
                Assert.Null(osProfile.LinuxConfiguration.PatchSettings.AutomaticByPlatformSettings);
            }

            if (linuxPatchSettings.AssessmentMode != null)
            {
                Assert.NotNull(osProfile.LinuxConfiguration.PatchSettings.AssessmentMode);
                Assert.Equal(osProfile.LinuxConfiguration.PatchSettings.AssessmentMode, linuxPatchSettings.AssessmentMode);
            }
            else
            {
                // By default in supported API versions, a value is provided in the VM model even if one is
                // not specified by the user.
                Assert.Equal("ImageDefault", osProfile.LinuxConfiguration.PatchSettings.AssessmentMode);
            }
        }

        private void TestVMWithOSProfile(
           string rgName,
           bool useWindowsProfile,
           Action<VirtualMachine> vmCustomizer = null,
           Action<VirtualMachine> vmValidator = null)
        {
            string storageAccountName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
            string asName = ComputeManagementTestUtilities.GenerateName("as");

            ImageReference imageRef = useWindowsProfile ? GetPlatformVMImage(useWindowsProfile) : GetPlatformVMImage(useWindowsProfile, "18.04-LTS");

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

        private void SetWindowsConfigurationPatchSettings(PatchSettings patchSetting,  bool enableAutomaticUpdates, string autoLogonContent, VirtualMachine inputVM)
        {
            var osProfile = inputVM.OsProfile;
            osProfile.WindowsConfiguration = new WindowsConfiguration
            {
                ProvisionVMAgent = true,
                EnableAutomaticUpdates = enableAutomaticUpdates,
                PatchSettings = patchSetting,
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

        private void SetLinuxConfigurationPatchSettings(LinuxPatchSettings linuxPatchSettings, VirtualMachine inputVM)
        {
            var osProfile = inputVM.OsProfile;
            string sshPath = "/home/" + osProfile.AdminUsername + "/.ssh/authorized_keys";
            osProfile.LinuxConfiguration = new LinuxConfiguration
            {
                ProvisionVMAgent = true,
                PatchSettings = linuxPatchSettings,
                DisablePasswordAuthentication = true,
                Ssh = new SshConfiguration
                {
                    PublicKeys = new List<SshPublicKey>
                    {
                        new SshPublicKey
                        {
                            Path = sshPath,
                            KeyData = DefaultSshPublicKey,
                        }
                    }
                }
            };
        }
    }
}
