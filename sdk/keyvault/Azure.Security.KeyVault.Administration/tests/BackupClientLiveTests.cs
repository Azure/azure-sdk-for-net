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
        public BackupClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback /* To record tests, change this argument to RecordedTestMode.Record */)
        { }

        [Test]
        [Ignore("Waiting on a service bug to be resolved.")]
        public async Task Backup()
        {
            var source = new CancellationTokenSource(TimeSpan.FromSeconds(60));
            BackupOperation backupOperation = await Client.StartBackupAsync(new Uri(TestEnvironment.StorageUri), SasToken, source.Token);

            Uri result = await backupOperation.WaitForCompletionAsync(source.Token);

            Assert.That(source.IsCancellationRequested, Is.False);
            Assert.That(result, Is.Not.Null);
        }
    }
}
