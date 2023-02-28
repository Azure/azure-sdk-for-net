// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using Azure.Storage;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    // Though RecordingTestBase is attributed [NonParallelizable] now, make sure these tests never run in parallel if that ever changes
    // or an intermediate base class adds [Parallelizable] in the future.
    //
    // Note: CIs still build/test all assemblies in parallel, so MHSM Keys tests may still run simultaneously.
    [NonParallelizable]
    [IgnoreServiceError(404, "NotFound", Message = "The given jobId is not found", Reason = "Backup/restore tests have inherent concurrency issues")]
    [IgnoreServiceError(409, "Conflict", Message = "User triggered Restore operation is in progress", Reason = "Backup/restore tests have inherent concurrency issues")]
    public abstract class BackupRestoreTestBase : AdministrationTestBase
    {
        public KeyVaultBackupClient Client { get; private set; }

        internal string SasToken { get; private set; }
        internal string BlobContainerName = "backup";
        internal string BlobContainerNameMultiPart = "backup/some/folder/name";

        public BackupRestoreTestBase(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(isAsync, serviceVersion, mode)
        {
            JsonPathSanitizers.Add("$..token");
            SanitizedQueryParameters.Add("sig");
        }

        internal KeyVaultBackupClient GetClient()
        {
            var client = new KeyVaultBackupClient(
                Uri,
                TestEnvironment.Credential,
                InstrumentClientOptions(new KeyVaultAdministrationClientOptions(ServiceVersion)
                {
                    Diagnostics =
                    {
                        LoggedHeaderNames =
                        {
                            "x-ms-request-id",
                        },
                    },
                }));

            return InstrumentClient(client);
        }

        protected override void Start()
        {
            Client = GetClient();
            SasToken = GenerateSasToken();

            base.Start();
        }

        // The service polls every second, so wait a bit to make sure the operation appears completed.
        protected async Task WaitForOperationAsync() => await DelayAsync();

        private string GenerateSasToken()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return SanitizeValue;
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
