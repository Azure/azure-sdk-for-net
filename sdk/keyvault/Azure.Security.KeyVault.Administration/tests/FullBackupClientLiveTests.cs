﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class FullBackupClientLiveTests : BackupRestoreTestBase
    {
        public FullBackupClientLiveTests(bool isAsync)
            : base(isAsync, null /* RecordedTestMode.Record /* to re-record */)
        { }

        public TimeSpan Timeout => TimeSpan.FromMinutes(5);

        [RecordedTest]
        public async Task BackupAndRestore()
        {
            var source = new CancellationTokenSource(Timeout);

            UriBuilder builder = new UriBuilder(TestEnvironment.StorageUri);
            builder.Path = BlobContainerName;

            // Start the backup.
            KeyVaultBackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, "?" + SasToken, source.Token);

            // Wait for completion of the LRO.
            KeyVaultBackupResult backupResult = await backupOperation.WaitForCompletionAsync(source.Token);

            await WaitForOperationAsync();

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(backupResult, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            // Start the restore.
            KeyVaultRestoreOperation restoreOperation = await Client.StartRestoreAsync(backupResult.FolderUri, "?" + SasToken, source.Token);

            // Wait for completion of the LRO
            var restoreResult = await restoreOperation.WaitForCompletionAsync(source.Token);

            await WaitForOperationAsync();

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task BackupAndRestoreMultiPartFolderName()
        {
            var source = new CancellationTokenSource(Timeout);

            UriBuilder builder = new UriBuilder(TestEnvironment.StorageUri);
            builder.Path = BlobContainerNameMultiPart;

            // Start the backup.
            KeyVaultBackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, "?" + SasToken, source.Token);

            // Wait for completion of the LRO.
            KeyVaultBackupResult backupResult = await backupOperation.WaitForCompletionAsync(source.Token);

            await WaitForOperationAsync();

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(backupResult, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            // Start the restore.
            KeyVaultRestoreOperation restoreOperation = await Client.StartRestoreAsync(backupResult.FolderUri, "?" + SasToken, source.Token);

            // Wait for completion of the LRO
            var restoreResult = await restoreOperation.WaitForCompletionAsync(source.Token);

            await WaitForOperationAsync();

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }
    }
}
