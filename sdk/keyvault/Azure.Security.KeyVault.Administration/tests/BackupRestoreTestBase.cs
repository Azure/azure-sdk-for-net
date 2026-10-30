// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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

            // The storage account disallows shared-key access, so sign the SAS with a user delegation
            // key (Azure AD) obtained via the same credential used for Key Vault instead of an account key.
            var serviceClient = new BlobServiceClient(new Uri(TestEnvironment.StorageUri), TestEnvironment.Credential);
            DateTimeOffset expiresOn = DateTimeOffset.UtcNow.AddHours(1);
            UserDelegationKey delegationKey = serviceClient.GetUserDelegationKey(DateTimeOffset.UtcNow.AddMinutes(-5), expiresOn, CancellationToken.None);

            BlobSasBuilder sas = new BlobSasBuilder
            {
                BlobContainerName = BlobContainerName,
                Resource = "c",
                ExpiresOn = expiresOn
            };
            sas.SetPermissions(BlobSasPermissions.All);

            // return a SAS token
            return sas.ToSasQueryParameters(delegationKey, TestEnvironment.AccountName).ToString();
        }
    }
}
