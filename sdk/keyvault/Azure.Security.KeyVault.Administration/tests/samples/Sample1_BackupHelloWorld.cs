// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using Azure.Identity;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample1_BackupHelloWorld : BackupRestoreTestBase
    {
        public Sample1_BackupHelloWorld(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        public void CreateClientSample()
        {
            var keyVaultUrl = TestEnvironment.KeyVaultUrl;

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
            Response<Uri> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri backupBlobUri = backupResult.Value;
            #endregion

            Assert.That(backupBlobUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            #region Snippet:HelloFullRestoreAsync
            // Get the folder name from the backupBlobUri returned from a previous BackupOperation
            string[] uriSegments = backupBlobUri.Segments;
            string folderName = uriSegments[uriSegments.Length - 1];

            // Start the restore.
            RestoreOperation restoreOperation = await Client.StartRestoreAsync(builder.Uri, sasToken, folderName);

            // Wait for completion of the RestoreOperation.
            Response restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }

        [RecordedTest]
        [SyncOnly]
        public void BackupAndRestoreSampleSync()
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
                Thread.Sleep(3000);
            }

            // Get the Uri for the location of you backup blob.
            Uri backupBlobUri = backupOperation.Value;
            #endregion

            Assert.That(backupBlobUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            #region Snippet:HelloFullRestoreSync
            // Get the folder name from the backupBlobUri returned from a previous BackupOperation
            string[] uriSegments = backupBlobUri.Segments;
            string folderName = uriSegments[uriSegments.Length - 1];

            // Start the restore.
            RestoreOperation restoreOperation = Client.StartRestore(builder.Uri, sasToken, folderName);

            // Wait for completion of the RestoreOperation.
            while (!restoreOperation.HasCompleted)
            {
                restoreOperation.UpdateStatus();
                Thread.Sleep(3000);
            }
            Uri restoreResult = backupOperation.Value;
            #endregion

            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }
    }
}
