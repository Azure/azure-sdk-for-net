// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Data;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{

    [TestFixture]
    public class BackupRestoreOperationTests: ClientTestBase
    {
        public BackupRestoreOperationTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task UpdateStatusThrowsOnError()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            var failedBackup = new FullBackupDetailsInternal(
                "failed",
                "failure details",
                new KeyVaultServiceError("500", "failed backup", null),
                DateTimeOffset.Now.AddMinutes(-5),
                now, "12345", "https://")
            var operation = new BackupOperation()
        }
    }
}
