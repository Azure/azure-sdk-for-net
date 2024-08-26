// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample1_BackupHelloWorld : BackupRestoreTestBase
    {
        public Sample1_BackupHelloWorld(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [Test]
        public void CreateClientSample()
        {
            var managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:HelloCreateKeyVaultBackupClient
            KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
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
            KeyVaultBackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            Response<KeyVaultBackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of your backup blob.
            Uri folderUri = backupResult.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            #region Snippet:HelloFullRestoreAsync
            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            KeyVaultRestoreOperation restoreOperation = await Client.StartRestoreAsync(folderUri, sasToken);

            // Wait for completion of the RestoreOperation.
            Response<KeyVaultRestoreResult> restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion

            Assert.That(restoreOperation.HasValue, Is.True);
            Assert.That(restoreResult.Value.StartTime, Is.Not.EqualTo(default));
            Assert.That(restoreResult.Value.EndTime, Is.Not.EqualTo(default));

            await WaitForOperationAsync();
        }

        [RecordedTest]
        [AsyncOnly]
        [Ignore("Service preview is not available yet")]
        public async Task PreBackupAndPreRestoreSampleAsync()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;

            // Create a Uri with the storage container
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Check for backup readiness.
            KeyVaultPreBackupOperation backupOperation = await Client.StartPreBackupAsync(builder.Uri, sasToken);

            // Wait for completion of the PreBackupOperation.
            Response<KeyVaultBackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            // Check if the PreBackupOperation has completed successfully.
            Uri folderUri = backupOperation.HasValue ? backupResult.Value.FolderUri : null;

            if (folderUri is null)
            {
                Console.WriteLine($"Backup operation failed. Status: {backupOperation.GetRawResponse().Status}, Reason: {backupOperation.GetRawResponse().ReasonPhrase}");
            }

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            // Check for restore readiness using the backupBlobUri returned from a previous BackupOperation.
            KeyVaultPreRestoreOperation preRestoreOperation = await Client.StartPreRestoreAsync(folderUri, sasToken);

            // Wait for completion of the PreRestoreOperation.
            Response<KeyVaultRestoreResult> preRestoreResult = await preRestoreOperation.WaitForCompletionAsync();

            // Check if the PreRestoreOperation has completed successfully.
            if (preRestoreOperation.HasValue)
            {
                Console.WriteLine($"Pre-restore operation completed successfully. Status: {preRestoreOperation.GetRawResponse().Status}");
            }
            else
            {
                Console.WriteLine($"Pre-restore operation failed. Status: {preRestoreOperation.GetRawResponse().Status}, Reason: {preRestoreOperation.GetRawResponse().ReasonPhrase}");
            }

            Assert.That(preRestoreOperation.HasValue, Is.True);
            Assert.That(preRestoreResult.Value.StartTime, Is.Not.EqualTo(default));
            Assert.That(preRestoreResult.Value.EndTime, Is.Not.EqualTo(default));
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
            KeyVaultBackupOperation backupOperation = Client.StartBackup(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            while (!backupOperation.HasCompleted)
            {
                backupOperation.UpdateStatus();
#if SNIPPET
                Thread.Sleep(3000);
#else
                await DelayAsync(TimeSpan.FromSeconds(3));
#endif
            }

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupOperation.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            #region Snippet:HelloFullRestoreSync
            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            KeyVaultRestoreOperation restoreOperation = Client.StartRestore(folderUri, sasToken);

            // Wait for completion of the RestoreOperation.
            while (!restoreOperation.HasCompleted)
            {
                restoreOperation.UpdateStatus();
#if SNIPPET
                Thread.Sleep(3000);
#else
                await DelayAsync(TimeSpan.FromSeconds(3));
#endif
            }
            Uri restoreResult = backupOperation.Value.FolderUri;
            #endregion

            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);

            await WaitForOperationAsync();
        }
    }
}
