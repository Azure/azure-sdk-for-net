// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobTestEnvironment : StorageTestEnvironment
    {
        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            return await DoesOAuthWorkAsync();
        }

        private async Task<bool> DoesOAuthWorkAsync()
        {
            TestContext.Error.WriteLine($"Blob Probing OAuth {Process.GetCurrentProcess().Id}");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    BlobServiceClient serviceClient = new BlobServiceClient(
                        new Uri(TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint), Credential);
                    await serviceClient.GetPropertiesAsync();
                    var containerName = Guid.NewGuid().ToString();
                    var containerClient = serviceClient.GetBlobContainerClient(containerName);
                    await containerClient.CreateIfNotExistsAsync();
                    try
                    {
                        await containerClient.GetPropertiesAsync();
                        var blobName = Guid.NewGuid().ToString();
                        var blobClient = containerClient.GetAppendBlobClient(blobName);
                        await blobClient.CreateIfNotExistsAsync();
                        await blobClient.GetPropertiesAsync();

                        var userDelegationKey = await serviceClient.GetUserDelegationKeyAsync(startsOn: null, expiresOn: DateTimeOffset.UtcNow.AddHours(1));
                        var sasBuilder = new BlobSasBuilder(BlobSasPermissions.All, DateTimeOffset.UtcNow.AddHours(1))
                        {
                            BlobContainerName = containerName,
                            BlobName = blobName,
                        };
                        var sas = sasBuilder.ToSasQueryParameters(userDelegationKey.Value, serviceClient.AccountName).ToString();
                        await new BlobBaseClient(blobClient.Uri, new AzureSasCredential(sas)).GetPropertiesAsync();
                    }
                    finally
                    {
                        await containerClient.DeleteIfExistsAsync();
                    }
                }
            } catch (RequestFailedException e) when (e.Status == 403 && e.ErrorCode == "AuthorizationPermissionMismatch")
            {
                TestContext.Error.WriteLine($"Blob Probing OAuth - not ready {Process.GetCurrentProcess().Id}");
                return false;
            }
            TestContext.Error.WriteLine($"Blob Probing OAuth - ready {Process.GetCurrentProcess().Id}");
            return true;
        }
    }
}
