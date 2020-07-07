// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPEncryptionTests : DiskRPTestsBase
    {
        public DiskRPEncryptionTests(bool isAsync)
        : base(isAsync)
        {
        }
        private static string DiskRPLocation = "westcentralus";

        /// <summary>
        /// positive test for testing disks encryption
        /// to enable this test, replace [Fact(Skip = "skipping positive test")] with [Fact]
        /// a valid keyvault is needed for this test
        /// encrypted disk will be retrievable through the encryptionkeyuri
        /// </summary>
        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task DiskEncryptionPositiveTest()
        {
            EnsureClientsInitialized(DefaultLocation);
            string testVaultId = @"/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/24/providers/Microsoft.KeyVault/vaults/swaggervault2";
            string encryptionKeyUri = @"https://swaggervault2.vault.azure.net/keys/swaggerkey/6108e4eb47c14bdf863f1465229f8e66";
            string secretUri = @"https://swaggervault2.vault.azure.net/secrets/swaggersecret/c464e5083aab4f73968700e8b077c54d";
            string encryptionSettingsVersion = "1.0";

            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.EncryptionSettingsCollection = GetDiskEncryptionSettings(testVaultId, encryptionKeyUri, secretUri, encryptionSettingsVersion: encryptionSettingsVersion);
            disk.Location = DiskRPLocation;
            await ResourceGroupsOperations.CreateOrUpdateAsync(rgName, new ResourceGroup(DiskRPLocation));
            //put disk
            await WaitForCompletionAsync((await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk)));
            Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);
            Validate(disk, diskOut, disk.Location);
            Assert.AreEqual(encryptionSettingsVersion, diskOut.EncryptionSettingsCollection.EncryptionSettingsVersion);
            Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SecretUrl, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SecretUrl);
            Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SourceVault.Id, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SourceVault.Id);
            Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.KeyUrl, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.KeyUrl);
            Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.SourceVault.Id, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.SourceVault.Id);
            await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
        }

        [Test]
        public async Task DiskEncryptionNegativeTest()
        {
            EnsureClientsInitialized(DefaultLocation);
            string fakeTestVaultId =
            @"/subscriptions/" + TestEnvironment.SubscriptionId + "/resourceGroups/testrg/providers/Microsoft.KeyVault/vaults/keyvault";
            string fakeEncryptionKeyUri = @"https://testvault.vault.azure.net/secrets/swaggersecret/test123";

            var rgName = Recording.GenerateAssetName(TestPrefix);
            var diskName = Recording.GenerateAssetName(DiskNamePrefix);
            Disk disk = await GenerateDefaultDisk(DiskCreateOption.Empty.ToString(), rgName, 10);
            disk.EncryptionSettingsCollection = GetDiskEncryptionSettings(fakeTestVaultId, fakeEncryptionKeyUri, fakeEncryptionKeyUri);
            disk.Location = DiskRPLocation;
            try
            {
                await ResourceGroupsOperations.CreateOrUpdateAsync(rgName,
                    new ResourceGroup(DiskRPLocation));
                await WaitForCompletionAsync((await DisksOperations.StartCreateOrUpdateAsync(rgName, diskName, disk)));
                Disk diskOut = await DisksOperations.GetAsync(rgName, diskName);
                Validate(disk, diskOut, disk.Location);
                Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SecretUrl, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SecretUrl);
                Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SourceVault.Id, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().DiskEncryptionKey.SourceVault.Id);
                Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.KeyUrl, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.KeyUrl);
                Assert.AreEqual(disk.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.SourceVault.Id, diskOut.EncryptionSettingsCollection.EncryptionSettings.First().KeyEncryptionKey.SourceVault.Id);
                await WaitForCompletionAsync(await DisksOperations.StartDeleteAsync(rgName, diskName));
            }
            catch (Exception cex)
            {
                string coreresponsestring = fakeEncryptionKeyUri +
                    " is not a valid versioned Key Vault Secret URL. It should be in the format https://<vaultEndpoint>/secrets/<secretName>/<secretVersion>.";
                Assert.IsTrue(cex.Message.Contains(coreresponsestring));
                //Assert.True(ex.Response.StatusCode == HttpStatusCode.BadRequest);
            }
        }

        private EncryptionSettingsCollection GetDiskEncryptionSettings(string testVaultId, string encryptionKeyUri, string secretUri, bool setEnabled = true, string encryptionSettingsVersion = null)
        {
            EncryptionSettingsCollection diskEncryptionSettings =
                new EncryptionSettingsCollection(true, new List<EncryptionSettingsElement>()
                {
                    (new EncryptionSettingsElement(
                        new KeyVaultAndSecretReference( new SourceVault(testVaultId), secretUri ),
                        new KeyVaultAndKeyReference(new SourceVault(testVaultId), encryptionKeyUri)
                        )
                    )
                }, encryptionSettingsVersion);
            return diskEncryptionSettings;
        }
    }
}
