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
        public BlobClientOptions.ServiceVersion StorageVersion => BlobClientOptions.ServiceVersion.V2019_02_02;

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            try
            {
                // Try multiple container and blob names to make sure we hit different blob servers
                for (int i = 0; i < 10; i++)
                {
                    var client = new BlobServiceClient(BlobStorageEndpoint, Credential, new BlobClientOptions(StorageVersion));
                    var container = client.GetBlobContainerClient(Guid.NewGuid().ToString());
                    await container.CreateIfNotExistsAsync();

                    var blob = container.GetBlobClient(Guid.NewGuid().ToString());
                    await blob.UploadAsync(new MemoryStream());
                    await blob.DeleteAsync();
                    await container.DeleteAsync();
                }

                return await base.IsEnvironmentReadyAsync();
            }
            catch (RequestFailedException e) when (e is { Status: 403, ErrorCode: "AuthorizationPermissionMismatch"})
            {
                return false;
            }
        }
    }
}