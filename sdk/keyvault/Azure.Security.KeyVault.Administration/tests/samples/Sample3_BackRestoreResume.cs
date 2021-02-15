// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample3_BackRestoreResume : BackupRestoreTestBase
    {
        public Sample3_BackRestoreResume(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public async Task ResumeBackupRestore()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;
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
            /*@@*/backupOperation._retryAfterSeconds = (int)PollingInterval.TotalSeconds;

            // Wait for completion of the BackupOperation.
            Response<BackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupResult.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            RestoreOperation originalRestoreOperation = await Client.StartRestoreAsync(folderUri, sasToken);
            var restoreOperationId = originalRestoreOperation.Id;

            #region Snippet:ResumeRestoreAsync
            // Construct a new KeyVaultBackupClient or use an existing one.
            //@@KeyVaultBackupClient Client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Construct a RestoreOperation using a KeyVaultBackupClient and the Id from a previously started operation.
            RestoreOperation restoreOperation = new RestoreOperation(client, restoreOperationId);
            /*@@*/restoreOperation._operationInternal._retryAfterSeconds = (int)PollingInterval.TotalSeconds;

            // Wait for completion of the RestoreOperation.
            RestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion

            Assert.That(restoreOperation.HasValue, Is.True);
            Assert.That(restoreResult.StartTime, Is.Not.EqualTo(default));
            Assert.That(restoreResult.EndTime, Is.Not.EqualTo(default));

            await WaitForOperationAsync();
        }
    }
}
