// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class OSProfileTests : VMTestBase
    {
        private static readonly string CustomData = Convert.ToBase64String(Encoding.UTF8.GetBytes("echo 'Hello World'"));

        private const string OOBESystem = "OobeSystem";
        private const string MicrosoftWindowsShellSetup = "Microsoft-Windows-Shell-Setup";
        private const SettingNames AutoLogon = SettingNames.AutoLogon;

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
        public OSProfileTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        private void EnableWinRMCustomDataAndUnattendContent(string rgName, string keyVaultName, string winRMCertificateUrl, string autoLogonContent, VirtualMachine inputVM)
        {
            var osProfile = inputVM.OsProfile;
            osProfile.CustomData = CustomData;
            osProfile.WindowsConfiguration = new WindowsConfiguration
            {
                ProvisionVMAgent = true,
                EnableAutomaticUpdates = false,
                TimeZone = PacificStandardTime,
                AdditionalUnattendContent = {
                        new AdditionalUnattendContent
                        {
                            PassName = OOBESystem,
                            ComponentName = MicrosoftWindowsShellSetup,
                            SettingName = AutoLogon,
                            Content = autoLogonContent
                        }
                    },
                WinRM = new WinRMConfiguration
                {
                    Listeners = {
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
            osProfile.Secrets.Add(
                    new VaultSecretGroup
                    {
                        SourceVault = SecretVaultHelper.GetVaultId(m_subId, rgName, keyVaultName).Result,
                        VaultCertificates = {
                             new VaultCertificate
                             {
                                 CertificateStore = "My",
                                 CertificateUrl = winRMCertificateUrl
                             }
                         }
                    }
                );
        }

        private void ValidateWinRMCustomDataAndUnattendContent(string winRMCertificateUrl, string autoLogonContent, VirtualMachine outputVM)
        {
            var osProfile = outputVM.OsProfile;
            // CustomData:
            Assert.AreEqual(osProfile.CustomData, CustomData);

            Assert.Null(osProfile.LinuxConfiguration);
            Assert.NotNull(osProfile.WindowsConfiguration);

            Assert.True(osProfile.WindowsConfiguration.ProvisionVMAgent != null && osProfile.WindowsConfiguration.ProvisionVMAgent.Value);
            Assert.True(osProfile.WindowsConfiguration.EnableAutomaticUpdates != null && !osProfile.WindowsConfiguration.EnableAutomaticUpdates.Value);

            // TimeZone
            Assert.AreEqual(PacificStandardTime, osProfile.WindowsConfiguration.TimeZone);

            // WinRM
            Assert.NotNull(osProfile.WindowsConfiguration.WinRM);
            var listeners = osProfile.WindowsConfiguration.WinRM.Listeners;
            Assert.NotNull(listeners);
            Assert.AreEqual(2, listeners.Count);

            if (listeners[0].Protocol == ProtocolTypes.Http)
            {
                Assert.Null(listeners[0].CertificateUrl);
                Assert.True(listeners[1].Protocol == ProtocolTypes.Https);
                Assert.AreEqual(listeners[1].CertificateUrl, winRMCertificateUrl);
            }
            else if (listeners[0].Protocol == ProtocolTypes.Https)
            {
                Assert.AreEqual(listeners[0].CertificateUrl, winRMCertificateUrl);
                Assert.True(listeners[1].Protocol == ProtocolTypes.Http);
                Assert.Null(listeners[1].CertificateUrl);
            }
            else
            {
                // Unexpected value for winRM Listener protocol
                Assert.True(false);
            }

            // AdditionalUnattendContent
            var additionalContents = osProfile.WindowsConfiguration.AdditionalUnattendContent;
            Assert.NotNull(additionalContents);
            Assert.AreEqual(1, additionalContents.Count);
            Assert.AreEqual(OOBESystem, additionalContents[0].PassName);
            Assert.AreEqual(MicrosoftWindowsShellSetup, additionalContents[0].ComponentName);
            Assert.AreEqual(AutoLogon, additionalContents[0].SettingName);
            Assert.AreEqual(autoLogonContent, additionalContents[0].Content);
        }

        // See recording instructions in HyakSpec\ReadMe.txt. The key vault URLs produced by the script are plugged
        // into SecretVaultHelper, below.
        //[Test(Skip = "Secret Vault")]
        [Test]
        [Ignore("skip in track 1")]
        public async Task TestVMWithWindowsOSProfile()
        {
            EnsureClientsInitialized(DefaultLocation);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string keyVaultName = Recording.GenerateAssetName(TestPrefix);

            string winRMCertificateBase64 = Convert.ToBase64String(
                                              Encoding.UTF8.GetBytes(
                                                ReadFromEmbeddedResource(typeof(OSProfileTests), WinRMCertificateResourceName)));

            // The following variables are defined here to allow validation
            string autoLogonContent = null;
            string winRMCertificateUrl = SecretVaultHelper.AddSecret(m_subId, rgName, keyVaultName, winRMCertificateBase64).Result;

            Action<VirtualMachine> enableWinRMCustomDataAndUnattendContent = inputVM =>
            {
                autoLogonContent = GetAutoLogonContent(5, inputVM.OsProfile.AdminUsername, inputVM.OsProfile.AdminPassword);
                EnableWinRMCustomDataAndUnattendContent(rgName, keyVaultName, winRMCertificateUrl, autoLogonContent, inputVM);
            };

            Action<VirtualMachine> validateWinRMCustomDataAndUnattendContent =
                outputVM => ValidateWinRMCustomDataAndUnattendContent(winRMCertificateUrl, autoLogonContent, outputVM);

            SecretVaultHelper.CreateKeyVault(m_subId, rgName, keyVaultName).Wait();

            await TestVMWithOSProfile(
                rgName: rgName,
                useWindowsProfile: true,
                vmCustomizer: enableWinRMCustomDataAndUnattendContent,
                vmValidator: validateWinRMCustomDataAndUnattendContent);
            SecretVaultHelper.DeleteKeyVault(m_subId, rgName, keyVaultName).Wait();
        }

        [Test]
        public async Task TestVMWithLinuxOSProfile()
        {
            EnsureClientsInitialized(DefaultLocation);

            string rgName = Recording.GenerateAssetName(TestPrefix);
            string sshPath = null;

            Action<VirtualMachine> enableSSHAndCustomData = customizedVM =>
            {
                var osProfile = customizedVM.OsProfile;
                sshPath = "/home/" + osProfile.AdminUsername + "/.ssh/authorized_keys";
                osProfile.CustomData = CustomData;
                osProfile.LinuxConfiguration = new LinuxConfiguration
                {
                    DisablePasswordAuthentication = false,
                    Ssh = new SshConfiguration
                    {
                        PublicKeys = {
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
                var osProfile = outputVM.OsProfile;

                Assert.Null(osProfile.WindowsConfiguration);

                Assert.NotNull(osProfile.LinuxConfiguration);
                Assert.NotNull(osProfile.LinuxConfiguration.Ssh);
                var publicKeys = osProfile.LinuxConfiguration.Ssh.PublicKeys;
                Assert.NotNull(osProfile.LinuxConfiguration.Ssh.PublicKeys);

                Assert.True(osProfile.LinuxConfiguration.DisablePasswordAuthentication != null && !osProfile.LinuxConfiguration.DisablePasswordAuthentication.Value);

                Assert.AreEqual(1, publicKeys.Count);
                Assert.AreEqual(sshPath, publicKeys[0].Path);
                Assert.AreEqual(DefaultSshPublicKey, publicKeys[0].KeyData);
            };

            await TestVMWithOSProfile(
                rgName: rgName,
                useWindowsProfile: false,
                vmCustomizer: enableSSHAndCustomData,
                vmValidator: validateWinRMCustomDataAndUnattendContent);
        }

        private async Task TestVMWithOSProfile(
            string rgName,
            bool useWindowsProfile,
            Action<VirtualMachine> vmCustomizer = null,
            Action<VirtualMachine> vmValidator = null)
        {
            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            string asName = Recording.GenerateAssetName("as");

            ImageReference imageRef = await GetPlatformVMImage(useWindowsProfile);

            VirtualMachine inputVM;
            StorageAccount storageAccountOutput = await CreateStorageAccount(rgName, storageAccountName);

            var returnTwoVM = await CreateVM(rgName, asName, storageAccountOutput, imageRef, vmCustomizer);
            VirtualMachine vm = returnTwoVM.Item1;
            inputVM = returnTwoVM.Item2;
            string inputVMName = returnTwoVM.Item3;
            //var getVMWithInstanceViewResponse = await VirtualMachinesClient.GetAsync(rgName, inputVM.Name, InstanceViewTypes.InstanceView);
            var getVMWithInstanceViewResponse = await VirtualMachinesOperations.GetAsync(rgName, inputVMName);
            ValidateVMInstanceView(inputVM, getVMWithInstanceViewResponse);

            var lroResponse = await WaitForCompletionAsync(await VirtualMachinesOperations.StartCreateOrUpdateAsync(rgName, vm.Name, vm));
            Assert.True(lroResponse.Value.ProvisioningState == "Succeeded");
            if (vmValidator != null)
            {
                vmValidator(vm);
            }

            await WaitForCompletionAsync(await VirtualMachinesOperations.StartDeleteAsync(rgName, vm.Name));
        }

        //Not used
        public static string ReadFromEmbeddedResource(Type type, string resourceName)
        {
            throw new NotSupportedException("\'type.Assembly\' is not supported for cross platform");
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

            public static async Task<Azure.ResourceManager.Compute.Models.SubResource> GetVaultId(string subId, string rgName, string keyVaultName)
            {
                return new Azure.ResourceManager.Compute.Models.SubResource { Id = KeyVaultId };
            }

            public static async Task<string> AddSecret(string subId, string rgName, string keyVaultName, string secret)
            {
                return CertificateUrl.AbsoluteUri;
            }

            public static async Task DeleteSecret(string subId, string rgName, string keyVaultName, string secret)
            {
            }
#pragma warning restore 1998
        }
    }
}
