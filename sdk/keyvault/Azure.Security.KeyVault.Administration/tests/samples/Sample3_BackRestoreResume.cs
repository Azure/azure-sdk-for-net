// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using Azure.Identity;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample3_BackRestoreResume : BackupRestoreTestBase
    {
        public Sample3_BackRestoreResume(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        public async Task ResumeBackupRestore()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;
           // var client = Mode == RecordedTestMode.Playback ? GetClient(null, false) : Client;
            var client = GetClient(false);

            // Create a Uri with the storage container
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Start the backup.
            BackupOperation originalBackupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);
            var backupOperationId = originalBackupOperation.Id;

            #region Snippet:ResumeBackupAsync
            // Construct a new KeyVaultBackupClient or use an existing one.
            //@@KeyVaultBackupClient Client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Construct a BackupOperation using a KeyVaultBackupClient and the Id from a previously started operation.
            BackupOperation backupOperation = new BackupOperation(client, backupOperationId);

            // Wait for completion of the BackupOperation.
            Response<Uri> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri backupBlobUri = backupResult.Value;
            #endregion

            Assert.That(backupBlobUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            // Get the folder name from the backupBlobUri returned from a previous BackupOperation
            string[] uriSegments = backupBlobUri.Segments;
            string folderName = uriSegments[uriSegments.Length - 1];

            // Start the restore.
            RestoreOperation originalRestoreOperation = await Client.StartRestoreAsync(builder.Uri, sasToken, folderName);
            var restoreOperationId = originalRestoreOperation.Id;

            #region Snippet:ResumeRestoreAsync
            // Construct a new KeyVaultBackupClient or use an existing one.
            //@@KeyVaultBackupClient Client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Construct a RestoreOperation using a KeyVaultBackupClient and the Id from a previously started operation.
            RestoreOperation restoreOperation = new RestoreOperation(client, restoreOperationId);

            // Wait for completion of the RestoreOperation.
            Response restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }
    }
}
