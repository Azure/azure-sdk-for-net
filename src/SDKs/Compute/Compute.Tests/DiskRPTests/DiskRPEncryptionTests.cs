// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPEncryptionTests : DiskRPTestsBase
    {
        private static string DiskRPLocation = "westcentralus";

        /// <summary>
        /// positive test for testing disks encryption
        /// to enable this test, replace [Fact(Skip = "skipping positive test")] with [Fact]
        /// a valid keyvault is needed for this test
        /// encrypted disk will be retrievable through the encryptionkeyuri
        /// </summary>
        [Fact(Skip = "skipping positive test")]
        public void DiskEncryptionPositiveTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                string testVaultId = @"/subscriptions/" + m_CrpClient.SubscriptionId + "/resourceGroups/diskrplonglived/providers/Microsoft.KeyVault/vaults/swaggerkeyvault";
                string encryptionKeyUri = @"https://swaggerkeyvault.vault.azure.net/secrets/swaggersecret/5684fd3915004bf39bda23df2d21b088";

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                disk.EncryptionSettings = GetDiskEncryptionSettings(testVaultId, encryptionKeyUri);
                disk.Location = DiskRPLocation;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup { Location = DiskRPLocation });
                    //put disk
                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.EncryptionSettings.DiskEncryptionKey.SecretUrl, diskOut.EncryptionSettings.DiskEncryptionKey.SecretUrl);
                    Assert.Equal(disk.EncryptionSettings.DiskEncryptionKey.SourceVault.Id, diskOut.EncryptionSettings.DiskEncryptionKey.SourceVault.Id);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        [Fact]
        public void DiskEncryptionNegativeTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                EnsureClientsInitialized(context);
                string fakeTestVaultId =
                @"/subscriptions/" + m_CrpClient.SubscriptionId + "/resourceGroups/testrg/providers/Microsoft.KeyVault/vaults/keyvault";
                string fakeEncryptionKeyUri = @"https://testvault.vault.azure.net/secrets/swaggersecret/test123";

                var rgName = TestUtilities.GenerateName(TestPrefix);
                var diskName = TestUtilities.GenerateName(DiskNamePrefix);
                Disk disk = GenerateDefaultDisk(DiskCreateOption.Empty, rgName, 10);
                disk.EncryptionSettings = GetDiskEncryptionSettings(fakeTestVaultId, fakeEncryptionKeyUri);
                disk.Location = DiskRPLocation;

                try
                {
                    m_ResourcesClient.ResourceGroups.CreateOrUpdate(rgName,
                        new ResourceGroup {Location = DiskRPLocation});

                    m_CrpClient.Disks.CreateOrUpdate(rgName, diskName, disk);
                    Disk diskOut = m_CrpClient.Disks.Get(rgName, diskName);

                    Validate(disk, diskOut, disk.Location);
                    Assert.Equal(disk.EncryptionSettings.DiskEncryptionKey.SecretUrl, diskOut.EncryptionSettings.DiskEncryptionKey.SecretUrl);
                    Assert.Equal(disk.EncryptionSettings.DiskEncryptionKey.SourceVault.Id, diskOut.EncryptionSettings.DiskEncryptionKey.SourceVault.Id);
                    m_CrpClient.Disks.Delete(rgName, diskName);
                }
                catch(CloudException ex)
                {
                    string coreresponsestring = fakeEncryptionKeyUri +
                        " is not a valid versioned Key Vault Secret URL. It should be in the format https://<vaultEndpoint>/secrets/<secretName>/<secretVersion>.";
                    Assert.Equal(coreresponsestring, ex.Message);
                    Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                }
            }
        }

        private EncryptionSettings GetDiskEncryptionSettings(string testVaultId, string encryptionKeyUri, bool setEnabled = true)
        {
            EncryptionSettings diskEncryptionSettings = new EncryptionSettings
            {
                Enabled = true,
                DiskEncryptionKey = new KeyVaultAndSecretReference
                {
                    SecretUrl = encryptionKeyUri,
                    SourceVault = new SourceVault
                    {
                        Id = testVaultId
                    }
                }
            };
            return diskEncryptionSettings;
        }
    }
}
