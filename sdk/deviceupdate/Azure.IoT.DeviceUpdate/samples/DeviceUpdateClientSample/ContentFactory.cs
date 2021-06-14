// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace ConsoleTest
{
    public class StubContentFactory
    {        
        private readonly string _storageConnectionString;
        private readonly string _blobContainer;
        
        public StubContentFactory(string storageConnectionString, string blobContainer)
        {
            _storageConnectionString = storageConnectionString;
            _blobContainer = blobContainer;
        }

        public async Task<(string, string, string, string)> CreateImportUpdate(string manufacturer, string name, string version)
        {
            // Upload the payload file to Azure Blob storage
            string payloadUrl = await UploadFileAsync("sample_manifest.txt", "rL0zrlcS1Zkg4HgyZPqryY");
            // Upload the import manifest file to Azure Blob storage
            string importManifestUrl = await UploadFileAsync("sample_content.txt", "NjOvp+rHaYTarfp+7h0h3Z");
            return ("sample_manifest.txt", "rL0zrlcS1Zkg4HgyZPqryY", "sample_content.txt", "NjOvp+rHaYTarfp+7h0h3Z");
        }

        private async Task<string> UploadFileAsync(string localFileToUpload, string storageId)
        {
            if (!CloudStorageAccount.TryParse(_storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new ArgumentException(nameof(_storageConnectionString));
            }

            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_blobContainer);
            await cloudBlobContainer.CreateIfNotExistsAsync();
            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(storageId);
            await cloudBlockBlob.UploadFromFileAsync(localFileToUpload);

            var token = cloudBlockBlob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = SharedAccessBlobPermissions.Read,
                SharedAccessExpiryTime = DateTimeOffset.UtcNow + TimeSpan.FromDays(1),
            });

            return $"{cloudBlockBlob.Uri.ToString()}{token}";
        }
    }
}
