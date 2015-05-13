//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Compute.Tests
{
    public class OSProfileTests : VMTestBase
    {
        private static readonly string CustomData = Convert.ToBase64String(Encoding.UTF8.GetBytes("echo 'Hello World'"));

        private const string OOBESystem = PassNames.OOBESystem;
        private const string MicrosoftWindowsShellSetup = ComponentNames.MicrosoftWindowsShellSetup;
        private const string AutoLogon = SettingNames.AutoLogon;

        private const string PacificStandardTime = "Pacific Standard Time";
        
        private const string DefaultSshPublicKey = 
            "MIIDszCCApugAwIBAgIJALBV9YJCF/tAMA0GCSqGSIb3DQEBBQUAMEUxCzAJBgNV" +
            "BAYTAkFVMRMwEQYDVQQIEwpTb21lLVN0YXRlMSEwHwYDVQQKExhJbnRlcm5ldCBX" +
            "aWRnaXRzIFB0eSBMdGQwHhcNMTUwMzIyMjI1NDQ5WhcNMTYwMzIxMjI1NDQ5WjBF" +
            "MQswCQYDVQQGEwJBVTETMBEGA1UECBMKU29tZS1TdGF0ZTEhMB8GA1UEChMYSW50" +
            "ZXJuZXQgV2lkZ2l0cyBQdHkgTHRkMIIBIDANBgkqhkiG9w0BAQEFAAOCAQ0AMIIB" +
            "CAKCAQEAxDC+OfmB+tQ+P1MLmuuW2hJLdcK8m4DLgAk5l8bQDNBcVezt+bt/ZFMs" +
            "CHBhfTZG9O9yqMn8IRUh7/7jfQm6DmXCgtxj/uFiwT+F3out5uWvMV9SjFYvu9kJ" +
            "NXiDC2u3l4lHV8eHde6SbKiZB9Jji9FYQV4YiWrBa91j9I3hZzbTL0UCiJ+1PPoL" +
            "Rx/T1s9KT5Wn8m/z2EDrHWpetYu45OA7nzyIFOyQup5oWadWNnpk6HkCGutl9t9b" +
            "cLdjXjXPm9wcy1yxIB3Dj/Y8Hnulr80GJlUtUboDm8TExGc4YaPJxdn0u5igo5gZ" +
            "c6qnqH/BMd1nsyICx6AZnKBXBycoSQIBI6OBpzCBpDAdBgNVHQ4EFgQUzWhrCCDs" +
            "ClANCGlKZ64rHp2BDn0wdQYDVR0jBG4wbIAUzWhrCCDsClANCGlKZ64rHp2BDn2h" +
            "SaRHMEUxCzAJBgNVBAYTAkFVMRMwEQYDVQQIEwpTb21lLVN0YXRlMSEwHwYDVQQK" +
            "ExhJbnRlcm5ldCBXaWRnaXRzIFB0eSBMdGSCCQCwVfWCQhf7QDAMBgNVHRMEBTAD" +
            "AQH/MA0GCSqGSIb3DQEBBQUAA4IBAQCUaJnX0aBzwBkbJrBS5YvkZnNKLdc4oHgC" +
            "/Nsr/9pwXzFYYXkdqpTw2nygH0C0WuPVVrG3Y3EGx/UIGDtLbwMvZJhQN9mZH3oX" +
            "+c3HGqBnXGuDRrtsfsK1ywAofx9amZfKNk/04/Rt3POdbyD1/AOADw2zMokbIapX" +
            "+nMDUtD/Tew9+0qU9+dcFMrFE1N4utlrFHlrLFbiCA/eSegP6gOeu9mqZv7UHIz2" +
            "oe6IQTw7zJF7xuBIzTYwjOCM197GKW7xc4GU4JZIN+faZ7njl/fxfUNdlqvgZUUn" +
            "kfdrzU3PZPl0w9NuncgEje/PZ+YtZvIsnH7MLSPeIGNQwW6V2kc8";

        [Fact(Skip = "TODO: Wait for KMS Client")]
        public void TestVMWithWindowsOSProfile()
        {
            string autoLogonContentFormat = 
                "<UserAccounts><AdministratorPassword><Value>{0}</Value><PlainText>true</PlainText></AdministratorPassword></UserAccounts>";
            string autoLogonContent = null;
            Uri winRMCertificateUrl = new Uri("http://keyVaultName.vault.azure.net/secrets/secretName/secretVersion");

            Action<VirtualMachine> enableWinRMCustomDataAndUnattendContent = inputVM =>
            {
                OSProfile osProfile = inputVM.OSProfile;
                osProfile.CustomData = CustomData;
                // Used for verification
                autoLogonContent = string.Format(autoLogonContentFormat, osProfile.AdminPassword);
                osProfile.WindowsConfiguration = new WindowsConfiguration
                {
                    ProvisionVMAgent = true,
                    EnableAutomaticUpdates = false,
                    TimeZone = PacificStandardTime,
                    AdditionalUnattendContents = new List<AdditionalUnattendContent>
                    {
                        new AdditionalUnattendContent 
                        {
                            PassName = OOBESystem,
                            ComponentName = MicrosoftWindowsShellSetup,
                            SettingName = AutoLogon,
                            Content = autoLogonContent
                        }
                    },
                    WinRMConfiguration = new WinRMConfiguration
                    {
                        Listeners = new List<WinRMListener>
                        {
                            new WinRMListener
                            {
                                Protocol = ProtocolTypes.Http,
                                CertificateUrl = null,
                            },
                            // TODO: Add WinRM tests when KMS is ready
                            /*
                            new WinRMListener
                            {
                                Protocol = ProtocolTypes.Https,
                                CertificateUrl = winRMCertificateUrl,
                            }
                            */
                        }
                    },
                };
            };

            Action<VirtualMachine> validateWinRMCustomDataAndUnattendContent = outputVM =>
            {
                OSProfile osProfile = outputVM.OSProfile;
                // CustomData:
                Assert.Equal(osProfile.CustomData, CustomData);

                Assert.Null(osProfile.LinuxConfiguration);
                Assert.NotNull(osProfile.WindowsConfiguration);
                
                Assert.True(osProfile.WindowsConfiguration.ProvisionVMAgent.Value);
                Assert.False(osProfile.WindowsConfiguration.EnableAutomaticUpdates.Value);

                // TimeZone
                Assert.Equal(PacificStandardTime, osProfile.WindowsConfiguration.TimeZone);

                // WinRM
                Assert.NotNull(osProfile.WindowsConfiguration.WinRMConfiguration);
                var listeners = osProfile.WindowsConfiguration.WinRMConfiguration.Listeners;
                Assert.NotNull(listeners);
                Assert.Equal(2, listeners.Count);

                if (listeners[0].Protocol.Equals(ProtocolTypes.Http, StringComparison.InvariantCultureIgnoreCase))
                {
                    Assert.Null(listeners[0].CertificateUrl);

                    Assert.True(listeners[1].Protocol.Equals(ProtocolTypes.Https, StringComparison.InvariantCultureIgnoreCase));
                    // TODO: verify exact url once secrets are in
                    Assert.NotNull(listeners[1].CertificateUrl);
                }
                else if (listeners[0].Protocol.Equals(ProtocolTypes.Https, StringComparison.InvariantCultureIgnoreCase))
                {
                    // TODO: verify exact url once secrets are in
                    Assert.NotNull(listeners[0].CertificateUrl);

                    Assert.True(listeners[1].Protocol.Equals(ProtocolTypes.Http, StringComparison.InvariantCultureIgnoreCase));
                    Assert.Null(listeners[1].CertificateUrl);
                }
                else
                {
                    // Unexpected value for winRM Listener protocol
                    Assert.True(false);
                }

                // AdditionalUnattendContent
                var additionalContents = osProfile.WindowsConfiguration.AdditionalUnattendContents;
                Assert.NotNull(additionalContents);
                Assert.Equal(1, additionalContents.Count);
                Assert.Equal(OOBESystem, additionalContents[0].PassName);
                Assert.Equal(MicrosoftWindowsShellSetup, additionalContents[0].ComponentName);
                Assert.Equal(AutoLogon, additionalContents[0].SettingName);
                Assert.Equal(autoLogonContent, additionalContents[0].Content);
            };

            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                TestVMWithOSProfile(
                    useWindowsProfile: true,
                    vmCustomizer: enableWinRMCustomDataAndUnattendContent,
                    vmValidator: null);
                    //vmValidator: validateWinRMCustomDataAndUnattendContent);
            }
        }

        [Fact]
        public void TestVMWithLinuxOSProfile()
        {
            string sshPath = null;

            Action<VirtualMachine> enableSSHAndCustomData = customizedVM =>
            {
                OSProfile osProfile = customizedVM.OSProfile;
                sshPath = "/home/" + osProfile.AdminUsername + "/.ssh/authorized_keys";
                osProfile.CustomData = CustomData;
                osProfile.LinuxConfiguration = new LinuxConfiguration
                {
                    DisablePasswordAuthentication = false,
                    SshConfiguration = new SshConfiguration
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
            };

            Action<VirtualMachine> validateWinRMCustomDataAndUnattendContent = outputVM =>
            {
                OSProfile osProfile = outputVM.OSProfile;
                Assert.Equal<string>(CustomData, osProfile.CustomData);
                
                Assert.Null(osProfile.WindowsConfiguration);
                
                Assert.NotNull(osProfile.LinuxConfiguration);
                Assert.NotNull(osProfile.LinuxConfiguration.SshConfiguration);
                var publicKeys = osProfile.LinuxConfiguration.SshConfiguration.PublicKeys;
                Assert.NotNull(osProfile.LinuxConfiguration.SshConfiguration.PublicKeys);

                Assert.False(osProfile.LinuxConfiguration.DisablePasswordAuthentication.Value);
                
                Assert.Equal(1, publicKeys.Count);
                Assert.Equal(sshPath, publicKeys[0].Path);
                Assert.Equal(DefaultSshPublicKey, publicKeys[0].KeyData);
            };

            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                TestVMWithOSProfile(
                    useWindowsProfile: false,
                    vmCustomizer: enableSSHAndCustomData,
                    vmValidator: validateWinRMCustomDataAndUnattendContent);
            }
        }

        private void TestVMWithOSProfile(
            bool useWindowsProfile,
            Action<VirtualMachine> vmCustomizer = null,
            Action<VirtualMachine> vmValidator = null)
        {
            string rgName = TestUtilities.GenerateName(TestPrefix);
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            string asName = TestUtilities.GenerateName("as");

            string imgRefId = GetPlatformOSImage(useWindowsProfile);

            VirtualMachine inputVM;
            try
            {
                StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachine vm = CreateVM(rgName, asName, storageAccountOutput, imgRefId, out inputVM, vmCustomizer);
                
                // TODO: Remove these 2 lines once tested against prod (re-recording occurs). 
                // These 2 lines are needed since the previous operation does a Get, which in the old recording does not
                // return the CreateOptionType required field.
                vm.StorageProfile.DataDisks.ForEach(dd => dd.CreateOption = DiskCreateOptionTypes.Empty);
                vm.StorageProfile.OSDisk.CreateOption = DiskCreateOptionTypes.Empty;

                VirtualMachineGetResponse getVMWithInstanceViewResponse =
                    m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, inputVM.Name);
                Assert.True(getVMWithInstanceViewResponse.StatusCode == HttpStatusCode.OK);
                ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse.VirtualMachine);

                var lroResponse = m_CrpClient.VirtualMachines.CreateOrUpdate(rgName, vm);
                Assert.True(lroResponse.Status == ComputeOperationStatus.Succeeded);
                if (vmValidator != null)
                {
                    vmValidator(vm);
                }

                var deleteOperationResponse = m_CrpClient.VirtualMachines.BeginDeleting(rgName, vm.Name);
                Assert.True(deleteOperationResponse.StatusCode == HttpStatusCode.Accepted);

                // TODO: VM delete operation takes too long, disable it for now
                // lroResponse = m_CrpClient.VirtualMachines.Delete(rgName, vm.Name);
                // Assert.True(lroResponse.Status == ComputeOperationStatus.Succeeded);
            }
            finally
            {
                if (m_ResourcesClient != null)
                {
                    // TODO: RG delete operation takes too long, disable it for now
                    // var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.Delete(rgName);
                    // Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.OK);
                    var deleteResourceGroupResponse = m_ResourcesClient.ResourceGroups.BeginDeleting(rgName);
                    Assert.True(deleteResourceGroupResponse.StatusCode == HttpStatusCode.Accepted);
                }
            }
        }
    }
}
