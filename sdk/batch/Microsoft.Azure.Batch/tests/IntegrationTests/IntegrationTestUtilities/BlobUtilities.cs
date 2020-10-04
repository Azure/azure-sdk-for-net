using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using BatchClientIntegrationTests.IntegrationTestUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities
{
    internal static class BlobUtilities
    {
        private static StagingStorageAccount GetStorageAccount()
        {
            return TestUtilities.GetStorageCredentialsFromEnvironment();
        }

        public static StorageSharedKeyCredential GetSharedKeyCredential(StagingStorageAccount storageAccount = null)
        {
            storageAccount ??= GetStorageAccount();
            return new StorageSharedKeyCredential(storageAccount.StorageAccount, storageAccount.StorageAccountKey);
        }

        public static BlobServiceClient GetBlobServiceClient(StagingStorageAccount storageAccount = null)
        {
            storageAccount ??= GetStorageAccount();

            StorageSharedKeyCredential credential = new StorageSharedKeyCredential(storageAccount.StorageAccount, storageAccount.StorageAccountKey);
            BlobServiceClient serviceClient = new BlobServiceClient(storageAccount.BlobUri, credential, null);
            return serviceClient;
        }

        public static BlobContainerClient GetBlobContainerClient(string containerName, StagingStorageAccount storageAccount = null)
        {
            return GetBlobContainerClient(containerName, GetBlobServiceClient(storageAccount), storageAccount);
        }

        public static BlobContainerClient GetBlobContainerClient(string containerName, BlobServiceClient serviceClient, StagingStorageAccount storageAccount = null)
        {
            storageAccount ??= GetStorageAccount();
            serviceClient ??= GetBlobServiceClient(storageAccount);


            BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);
            return containerClient;
        }

        public static string GetWriteableSasUri(BlobContainerClient containerClient, StagingStorageAccount storageAccount)
        {
            var sasBuilder = new BlobSasBuilder
            {
                ExpiresOn = DateTime.UtcNow.AddDays(1),
                BlobContainerName = containerClient.Name,
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Write);
            StorageSharedKeyCredential credentials = GetSharedKeyCredential(storageAccount);
            BlobUriBuilder builder = new BlobUriBuilder(containerClient.Uri);
            builder.Sas = sasBuilder.ToSasQueryParameters(credentials);
            string fullSas = builder.ToString();
            return fullSas;
        }
    }
}
