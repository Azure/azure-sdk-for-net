// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using Azure.Storage;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupRestoreTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        public KeyVaultBackupClient Client { get; set; }
        internal string SasToken { get; set; }

        public BackupRestoreTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new BackupRestoreRecordedTestSanitizer();
        }

        public BackupRestoreTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new BackupRestoreRecordedTestSanitizer();
        }

        private KeyVaultBackupClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new KeyVaultBackupClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    TestEnvironment.Credential,
                    recording.InstrumentClientOptions(new KeyVaultBackupClientOptions())));
        }


        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            Client ??= GetClient();
            SasToken ??= GenerateSasToken();

            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Client = GetClient();

                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        private string GenerateSasToken()
        {
            // Create a service level SAS that only allows reading from service
            // level APIs
            AccountSasBuilder sas = new AccountSasBuilder
            {
                // Allow access to blobs.
                Services = AccountSasServices.Blobs,

                // Allow access to the service level APIs.
                ResourceTypes = AccountSasResourceTypes.Service,

                // Access expires in 1 hour.
                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
            };
            // Allow All access
            sas.SetPermissions(AccountSasPermissions.All);

            // Create a SharedKeyCredential that we can use to sign the SAS token
            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(TestEnvironment.AccountName, TestEnvironment.PrimaryStorageAccountKey);

            // return a SAS token
            return sas.ToSasQueryParameters(credential).ToString();
        }
    }
}
