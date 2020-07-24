// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupClientLiveTests : BackupRestoreTestBase
    {
        public BackupClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        public async Task Backup()
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(60));

            UriBuilder builder = new UriBuilder(TestEnvironment.StorageUri);
            builder.Path = BlobContainerName;

            BackupOperation backupOperation = await Client.StartBackupAsync(builder.Uri, SasToken, source.Token);

            Uri result = await backupOperation.WaitForCompletionAsync(source.Token);

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(result, Is.Not.Null);
        }
    }
}
