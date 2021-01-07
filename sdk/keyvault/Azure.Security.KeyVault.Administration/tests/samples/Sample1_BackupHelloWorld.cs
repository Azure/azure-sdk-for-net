// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample1_BackupHelloWorld : BackupRestoreTestBase
    {
        public Sample1_BackupHelloWorld(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public void CreateClientSample()
        {
            var keyVaultUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:HelloCreateKeyVaultBackupClient
            KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task BackupAndRestoreSampleAsync()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;

            #region Snippet:HelloFullBackupAsync
            // Create a Uri with the storage container
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Start the backup.
            BackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            Response<BackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupResult.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            #region Snippet:HelloFullRestoreAsync
            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            RestoreOperation restoreOperation = await Client.StartRestoreAsync(folderUri, sasToken);

            // Wait for completion of the RestoreOperation.
            Response<RestoreResult> restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion

            Assert.That(restoreOperation.HasValue, Is.True);
            Assert.That(restoreResult.Value.StartTime, Is.Not.EqualTo(default));
            Assert.That(restoreResult.Value.EndTime, Is.Not.EqualTo(default));

            await WaitForOperationAsync();
        }

        [RecordedTest]
        [SyncOnly]
        public async Task BackupAndRestoreSampleSync()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;

            #region Snippet:HelloFullBackupSync
            // Create a Uri with the storage container
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Start the backup.
            BackupOperation backupOperation = Client.StartBackup(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            while (!backupOperation.HasCompleted)
            {
                backupOperation.UpdateStatus();
                /*@@*/ await DelayAsync(TimeSpan.FromSeconds(3));
                //@@Thread.Sleep(3000);
            }

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupOperation.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            #region Snippet:HelloFullRestoreSync
            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            RestoreOperation restoreOperation = Client.StartRestore(folderUri, sasToken);

            // Wait for completion of the RestoreOperation.
            while (!restoreOperation.HasCompleted)
            {
                restoreOperation.UpdateStatus();
                /*@@*/ await DelayAsync(TimeSpan.FromSeconds(3));
                //@@Thread.Sleep(3000);
            }
            Uri restoreResult = backupOperation.Value.FolderUri;
            #endregion

            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);

            await WaitForOperationAsync();
        }
    }
}
