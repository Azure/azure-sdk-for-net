// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

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
            BlobServiceClient serviceClient = new BlobServiceClient(
                new Uri(TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint),
                GetOAuthCredential(TestConfigurations.DefaultTargetOAuthTenant));
            try
            {
                await serviceClient.GetPropertiesAsync();
                var containerName = Guid.NewGuid().ToString();
                var blobName = Guid.NewGuid().ToString();
                var containerClient = serviceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync();
                var blobClient = containerClient.GetAppendBlobClient(blobName);
                await blobClient.CreateIfNotExistsAsync();
                await containerClient.DeleteIfExistsAsync();
            } catch (RequestFailedException e) when (e.Status == 403 && e.ErrorCode == "AuthorizationPermissionMismatch")
            {
                return false;
            }
            return true;
        }
    }
}
