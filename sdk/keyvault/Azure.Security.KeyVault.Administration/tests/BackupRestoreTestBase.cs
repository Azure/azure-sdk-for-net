// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [NonParallelizable]
    public abstract class BackupRestoreTestBase : AdministrationTestBase
    {
        public KeyVaultBackupClient Client { get; private set; }

        internal string SasToken { get; private set; }
        internal string BlobContainerName = "backup";
        internal string BlobContainerNameMultiPart = "backup/some/folder/name";

        public BackupRestoreTestBase(bool isAsync, RecordedTestMode? mode)
            : base(isAsync, mode)
        {
            Sanitizer = new BackupRestoreRecordedTestSanitizer();
        }

        internal KeyVaultBackupClient GetClient(bool isInstrumented = true)
        {
            var client = new KeyVaultBackupClient(
                Uri,
                TestEnvironment.Credential,
                InstrumentClientOptions(new KeyVaultAdministrationClientOptions()));
            return isInstrumented ? InstrumentClient(client) : client;
        }

        protected override void Start()
        {
            Client = GetClient();
            SasToken = GenerateSasToken();

            base.Start();
        }

        // The service polls every second, so wait a bit to make sure the operation appears completed.
        protected async Task WaitForOperationAsync() =>
            await DelayAsync(TimeSpan.FromSeconds(2));

        private string GenerateSasToken()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return RecordedTestSanitizer.SanitizeValue;
            }
            // Create a service level SAS that only allows reading from service
            // level APIs
            AccountSasBuilder sas = new AccountSasBuilder
            {
                // Allow access to blobs.
                Services = AccountSasServices.Blobs,

                // Allow access to the service level APIs.
                ResourceTypes = AccountSasResourceTypes.All,

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
