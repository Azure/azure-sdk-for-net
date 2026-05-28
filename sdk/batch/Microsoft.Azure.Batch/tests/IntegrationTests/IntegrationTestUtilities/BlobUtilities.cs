using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using BatchClientIntegrationTests.IntegrationTestUtilities;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Batch.Integration.Tests.IntegrationTestUtilities
{
    public static class BlobUtilities
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

        public static List<BlobItem> GetAllBlobs(this BlobContainerClient containerClient, BlobTraits traits = BlobTraits.None | BlobTraits.Metadata)
        {
            List<BlobItem> blobs = new List<BlobItem>();

            string continuationToken = null;

            while (continuationToken != string.Empty)
            {
                var resultSegment = containerClient.GetBlobs(traits).AsPages(continuationToken);

                foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    foreach (var blob in blobPage.Values)
                    {
                        blobs.Add(blob);
                    }

                    continuationToken = blobPage.ContinuationToken;
                }
            }

            return blobs;
        }
    }
}
