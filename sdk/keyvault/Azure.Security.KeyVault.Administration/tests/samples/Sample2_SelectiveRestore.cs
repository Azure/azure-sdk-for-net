// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample2_SelectiveRestore : BackupRestoreTestBase
    {
        public Sample2_SelectiveRestore(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public async Task BackupAndRestoreSampleAsync()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;

            // Create a Uri with the storage container.
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Make sure we have a key to back up and restore.
            KeyVaultKey key = await KeyClient.CreateKeyAsync(Recording.GenerateId(), KeyType.Oct);

            // Start the backup.
            KeyVaultBackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            Response<KeyVaultBackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            await WaitForOperationAsync();

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupResult.Value.FolderUri;

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            #region Snippet:SelectiveRestoreAsync
#if SNIPPET
            string keyName = "<key name to restore>";
#else
            string keyName = key.Name;

            RegisterKeyForCleanup(keyName);
#endif

            // Start the restore for a specific key that was previously backed up using the backupBlobUri returned from a previous BackupOperation.
            KeyVaultSelectiveKeyRestoreOperation restoreOperation = await Client.StartSelectiveKeyRestoreAsync(keyName, folderUri, sasToken);

            // Wait for completion of the RestoreOperation.
            KeyVaultSelectiveKeyRestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion

            Assert.That(restoreOperation.HasValue, Is.True);
            Assert.That(restoreResult.StartTime, Is.Not.EqualTo(default));
            Assert.That(restoreResult.EndTime, Is.Not.EqualTo(default));

            await WaitForOperationAsync();
        }
    }
}
