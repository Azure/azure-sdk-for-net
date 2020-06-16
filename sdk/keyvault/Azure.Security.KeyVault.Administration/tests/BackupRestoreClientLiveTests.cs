// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupRestoreClientLiveTests : BackupRestoreTestBase
    {
        public BackupRestoreClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        [Ignore("Waiting on a service bug to be resolved.")]
        public async Task Backup()
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(60));
            BackupOperation backupOperation = await Client.StartFullBackupAsync(new Uri(TestEnvironment.StorageUri), SasToken, source.Token);

            FullBackupDetails result = await backupOperation.WaitForCompletionAsync(source.Token);

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(result.AzureStorageBlobContainerUri, Is.Not.Empty);
        }
    }
}
