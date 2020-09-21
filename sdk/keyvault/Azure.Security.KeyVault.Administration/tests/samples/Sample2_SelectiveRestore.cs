// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample2_SelectiveRestore : BackupRestoreTestBase
    {
        public Sample2_SelectiveRestore(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
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

            // Start the backup.
            BackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, sasToken);

            // Wait for completion of the BackupOperation.
            Response<Uri> backupResult = await backupOperation.WaitForCompletionAsync();

            // Get the Uri for the location of you backup blob.
            Uri backupBlobUri = backupResult.Value;

            Assert.That(backupBlobUri, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            string keyName = PreviouslyBackedUpKeyName;

            #region Snippet:SelectiveRestoreAsync
            // Get the folder name from the backupBlobUri returned from a previous BackupOperation.
            string[] uriSegments = backupBlobUri.Segments;
            string folderName = uriSegments[uriSegments.Length - 1];
            //@@ string keyName = <key name to restore>;

            // Start the restore for a specific key that was previously backed up.
            RestoreOperation restoreOperation = await Client.StartSelectiveRestoreAsync(keyName, builder.Uri, sasToken, folderName);

            // Wait for completion of the RestoreOperation.
            Response restoreResult = await restoreOperation.WaitForCompletionAsync();
            #endregion
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }
    }
}
