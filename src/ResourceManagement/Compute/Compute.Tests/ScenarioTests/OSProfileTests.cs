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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Azure.Test.HttpRecorder;
using System.Threading.Tasks;
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

        private const string WinRMCertificateResourceName = "WinRMCertificateResource";

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

        private void EnableWinRMCustomDataAndUnattendContent(string rgName, string keyVaultName, Uri winRMCertificateUrl, string autoLogonContent, VirtualMachine inputVM)
        {
            OSProfile osProfile = inputVM.OSProfile;
            osProfile.CustomData = CustomData;
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
                            new WinRMListener
                            {
                                Protocol = ProtocolTypes.Https,
                                CertificateUrl = winRMCertificateUrl,
                            }
                        }
                }
            };
            osProfile.Secrets = new List<VaultSecretGroup>
                {
                    new VaultSecretGroup
                    {
                         SourceVault = SecretVaultHelper.GetVaultId(m_subId, rgName, keyVaultName).Result,
                         VaultCertificates = new List<VaultCertificate>
                         {
                             new VaultCertificate
                             {
                                 CertificateStore = "My",
                                 CertificateUrl = winRMCertificateUrl.AbsoluteUri
                             }
                         }
                    }
                };
        }

        private void ValidateWinRMCustomDataAndUnattendContent(string rgName, string keyVaultName, Uri winRMCertificateUrl, string autoLogonContent, VirtualMachine outputVM)
        {
            OSProfile osProfile = outputVM.OSProfile;
            // CustomData:
            Assert.Equal(osProfile.CustomData, CustomData);

            Assert.Null(osProfile.LinuxConfiguration);
            Assert.NotNull(osProfile.WindowsConfiguration);

            Assert.True(osProfile.WindowsConfiguration.ProvisionVMAgent != null && osProfile.WindowsConfiguration.ProvisionVMAgent.Value);
            Assert.True(osProfile.WindowsConfiguration.EnableAutomaticUpdates != null && !osProfile.WindowsConfiguration.EnableAutomaticUpdates.Value);

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
                Assert.True(listeners[1].CertificateUrl.AbsoluteUri.Equals(winRMCertificateUrl.AbsoluteUri, StringComparison.OrdinalIgnoreCase));
            }
            else if (listeners[0].Protocol.Equals(ProtocolTypes.Https, StringComparison.InvariantCultureIgnoreCase))
            {
                Assert.True(listeners[0].CertificateUrl.AbsoluteUri.Equals(winRMCertificateUrl.AbsoluteUri, StringComparison.OrdinalIgnoreCase));

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
        }

        // See recording instructions in HyakSpec\ReadMe.txt. The key vault URLs produced by the script are plugged
        // into SecretVaultHelper, below.
        [Fact]
        public void TestVMWithWindowsOSProfile()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                string rgName = TestUtilities.GenerateName(TestPrefix);
                string keyVaultName = TestUtilities.GenerateName(TestPrefix);

                string winRMCertificateBase64 = Convert.ToBase64String(
                                                  Encoding.UTF8.GetBytes(
                                                    ReadFromEmbeddedResource(typeof(OSProfileTests), WinRMCertificateResourceName)));

                // The following variables are defined here to allow validation
                string autoLogonContent = null;
                Uri winRMCertificateUrl = SecretVaultHelper.AddSecret(m_subId, rgName, keyVaultName, winRMCertificateBase64).Result;

                Action<VirtualMachine> enableWinRMCustomDataAndUnattendContent = inputVM =>
                    {
                        autoLogonContent = GetAutoLogonContent(5, inputVM.OSProfile.AdminUsername, inputVM.OSProfile.AdminPassword);
                        EnableWinRMCustomDataAndUnattendContent(rgName, keyVaultName, winRMCertificateUrl, autoLogonContent, inputVM);
                    };

                Action<VirtualMachine> validateWinRMCustomDataAndUnattendContent = 
                    outputVM => ValidateWinRMCustomDataAndUnattendContent(rgName, keyVaultName, winRMCertificateUrl, autoLogonContent, outputVM);

                SecretVaultHelper.CreateKeyVault(m_subId, rgName, keyVaultName).Wait();
                
                TestVMWithOSProfile(
                    rgName: rgName,
                    useWindowsProfile: true,
                    vmCustomizer: enableWinRMCustomDataAndUnattendContent,
                    vmValidator: validateWinRMCustomDataAndUnattendContent);

                SecretVaultHelper.DeleteKeyVault(m_subId, rgName, keyVaultName).Wait();
            }
        }

        [Fact]
        public void TestVMWithLinuxOSProfile()
        {
            using (var context = UndoContext.Current)
            {
                context.Start();
                EnsureClientsInitialized();

                string rgName = TestUtilities.GenerateName(TestPrefix);
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

                    Assert.True(osProfile.LinuxConfiguration.DisablePasswordAuthentication != null && !osProfile.LinuxConfiguration.DisablePasswordAuthentication.Value);

                    Assert.Equal(1, publicKeys.Count);
                    Assert.Equal(sshPath, publicKeys[0].Path);
                    Assert.Equal(DefaultSshPublicKey, publicKeys[0].KeyData);
                };

                TestVMWithOSProfile(
                    rgName: rgName,
                    useWindowsProfile: false,
                    vmCustomizer: enableSSHAndCustomData,
                    vmValidator: validateWinRMCustomDataAndUnattendContent);
            }
        }

        private void TestVMWithOSProfile(
            string rgName,
            bool useWindowsProfile,
            Action<VirtualMachine> vmCustomizer = null,
            Action<VirtualMachine> vmValidator = null)
        {
            string storageAccountName = TestUtilities.GenerateName(TestPrefix);
            string asName = TestUtilities.GenerateName("as");

            ImageReference imageRef = GetPlatformVMImage(useWindowsProfile);

            VirtualMachine inputVM;
            try
            {
                StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName);

                VirtualMachine vm = CreateVM_NoAsyncTracking(rgName, asName, storageAccountOutput, imageRef, out inputVM, vmCustomizer);

                VirtualMachineGetResponse getVMWithInstanceViewResponse = m_CrpClient.VirtualMachines.GetWithInstanceView(rgName, inputVM.Name);
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


        public static string ReadFromEmbeddedResource(Type type, string resourceName)
        {
            string result;
            using (Stream manifestResourceStream = type.Assembly.GetManifestResourceStream(type, resourceName) ?? type.Assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader streamReader = new StreamReader(manifestResourceStream))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            return result;
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
    }

    public static class SecretVaultHelper
    {
        // TODO: Please remove once KeyVault ARM client is ready and replace by actual calls to the service.
        // Currently, for new recroding of TestVMWithWindowsOSProfile supporting WinRM with Https listeners, we need to
        // have a certifcate in KeyVault. To do that, we:
        // 1. Execute the script CreateKeyVaultAndCertificateScript.ps1   -SubscriptionName: <subscriptionName> 
        //    using appropriate SubscriptionName  (you can change Region, ResourceGroupName, and KeyVaultName too)
        // 2. Update static values below (e.g. VaultId and CertifcateUrl) with values returned when running the script
        // 3. Complete the recording. 
        // 4. After recording completes, please delete key vault you created by deleting the whole resource group.

        public static string KeyVaultId = "/subscriptions/ccfebd33-45cd-4e22-9389-98982441aa5d/resourceGroups/pslibtestosprofile/providers/Microsoft.KeyVault/vaults/pslibtestkeyvault";

        public static Uri CertificateUrl = new Uri("https://pslibtestkeyvault.vault.azure.net:443/secrets/WinRM/24c727e7449b47cb9d2f385113f59a63");

#pragma warning disable 1998
        public static async Task CreateKeyVault(string subId, string rgName, string keyVaultName)
        {
        }

        public static async Task DeleteKeyVault(string subId, string rgName, string keyVaultName)
        {
        }

        public static async Task<SourceVaultReference> GetVaultId(string subId, string rgName, string keyVaultName)
        {
            return new SourceVaultReference { ReferenceUri = KeyVaultId };
        }

        public static async Task<Uri> AddSecret(string subId, string rgName, string keyVaultName, string secret)
        {
            return CertificateUrl;
        }

        public static async Task DeleteSecret(string subId, string rgName, string keyVaultName, string secret)
        {
        }
#pragma warning restore 1998
    }
}
