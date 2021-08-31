// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;

namespace Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests
{
    public class DataProtectionTestEnvironment: TestEnvironment
    {
        public Uri BlobStorageEndpoint => new(GetVariable("BLOB_STORAGE_ENDPOINT"));

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            try
            {
                var client = new BlobServiceClient(BlobStorageEndpoint, Credential);
                var container = client.GetBlobContainerClient("test");
                await container.CreateIfNotExistsAsync();

                var blob = container.GetBlobClient("test-blob");
                await blob.UploadAsync(new MemoryStream());
                await blob.DeleteAsync();
                await container.DeleteAsync();

                return await base.IsEnvironmentReadyAsync();
            }
            catch (RequestFailedException e) when (e is { Status: 403})
            {
                return false;
            }
        }
    }
}