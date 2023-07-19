// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample3_BackRestoreResume : BackupRestoreTestBase
    {
        public Sample3_BackRestoreResume(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        [RecordedTest]
        public async Task ResumeBackupRestore()
        {
            var blobStorageUrl = TestEnvironment.StorageUri;
            var blobContainerName = BlobContainerName;
            var sasToken = "?" + SasToken;
            var managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            // Create a Uri with the storage container
            UriBuilder builder = new UriBuilder(blobStorageUrl)
            {
                Path = blobContainerName,
            };

            // Start the backup.
            KeyVaultBackupOperation originalBackupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);
            var backupOperationId = originalBackupOperation.Id;

            #region Snippet:ResumeBackupAsync
#if SNIPPET
            // Construct a new KeyVaultBackupClient or use an existing one.
            KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
#else
            var client = Client;
#endif

            // Construct a BackupOperation using a KeyVaultBackupClient and the Id from a previously started operation.
            KeyVaultBackupOperation backupOperation = new KeyVaultBackupOperation(client, backupOperationId);
#if !SNIPPET
            backupOperation = InstrumentOperation(backupOperation);
#endif

            // Wait for completion of the BackupOperation.
            Response<KeyVaultBackupResult> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri folderUri = backupResult.Value.FolderUri;
            #endregion

            Assert.That(folderUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            await WaitForOperationAsync();

            // Start the restore using the backupBlobUri returned from a previous BackupOperation.
            KeyVaultRestoreOperation originalRestoreOperation = await Client.StartRestoreAsync(folderUri, sasToken);
            var restoreOperationId = originalRestoreOperation.Id;

            #region Snippet:ResumeRestoreAsync
            // Construct a RestoreOperation using a KeyVaultBackupClient and the Id from a previously started operation.
            KeyVaultRestoreOperation restoreOperation = new KeyVaultRestoreOperation(client, restoreOperationId);
#if !SNIPPET
            restoreOperation = InstrumentOperation(restoreOperation);
#endif

            // Wait for completion of the RestoreOperation.
            KeyVaultRestoreResult restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion

            Assert.That(restoreOperation.HasValue, Is.True);
            Assert.That(restoreResult.StartTime, Is.Not.EqualTo(default));
            Assert.That(restoreResult.EndTime, Is.Not.EqualTo(default));

            await WaitForOperationAsync();
        }
    }
}
