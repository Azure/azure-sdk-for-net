﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class FullBackupClientLiveTests : BackupRestoreTestBase
    {
        public FullBackupClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [RecordedTest]
        public async Task BackupAndRestore()
        {
            var source = new CancellationTokenSource(TimeSpan.FromMinutes(2));

            UriBuilder builder = new UriBuilder(TestEnvironment.StorageUri);
            builder.Path = BlobContainerName;

            // Start the backup.
            BackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, "?" + SasToken, source.Token);

            // Wait for completion of the LRO.
            Uri backupResult = await backupOperation.WaitForCompletionAsync(source.Token);

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(backupResult, Is.Not.Null);
            Assert.That(backupOperation.HasValue, Is.True);

            // Start the restore.
            RestoreOperation restoreOperation = await Client.StartRestoreAsync(backupResult, "?" + SasToken, source.Token);

            // Wait for completion of the LRO
            var restoreResult = await restoreOperation.WaitForCompletionAsync(source.Token);

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(restoreResult, Is.Not.Null);
            Assert.That(restoreOperation.HasValue, Is.True);
        }
    }
}
