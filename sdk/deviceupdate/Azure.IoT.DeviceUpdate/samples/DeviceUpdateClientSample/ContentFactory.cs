// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.IoT.DeviceUpdate.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;
using File = System.IO.File;

namespace ConsoleTest
{
    /// <summary>
    /// A content factory class used to create ADU artifacts needed for the sample program.
    /// </summary>
    public class ContentFactory
    {
        private const string FileName = "setup.exe";

        private readonly string _storageConnectionString;
        private readonly string _blobContainer;

        /// <summary>
        /// Initializes a new instance of the ContentFactory class.
        /// </summary>
        /// <param name="storageConnectionString">The Azure Storage account connection string.</param>
        /// <param name="blobContainer">The Azure Blob container to use when uploading files.</param>
        public ContentFactory(string storageConnectionString, string blobContainer)
        {
            _storageConnectionString = storageConnectionString;
            _blobContainer = blobContainer;
        }

        /// <summary>
        /// Create import update.
        /// </summary>
        /// <param name="manufacturer">The provider.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <returns>
        /// An asynchronous result that yields the new import update.
        /// </returns>
        public async Task<ImportUpdateInput> CreateImportUpdate(string manufacturer, string name, string version)
        {
            // Create actual update payload (fake "setup.exe")
            string payloadLocalFile = CreateAduPayloadFile(FileName);
            long payloadFileSize = GetFileSize(payloadLocalFile);
            string payloadFileHash = GetFileHash(payloadLocalFile);
            // Upload the payload file to Azure Blob storage
            string payloadUrl = await UploadFileAsync(payloadLocalFile, GenerateStorageId(payloadFileHash));

            // Create import manifest (describing the update and all it's payload files)
            string importManifestFile = CreateImportManifestContent(
                manufacturer,
                name,
                version,
                FileName,
                payloadFileSize,
                payloadFileHash,
                new Tuple<string, string>[] {new Tuple<string, string>(manufacturer.ToLowerInvariant(), name.ToLowerInvariant())});
            long importManifestFileSize = GetFileSize(importManifestFile);
            string importManifestFileHash = GetFileHash(importManifestFile);
            // Upload the import manifest file to Azure Blob storage
            string importManifestUrl = await UploadFileAsync(importManifestFile, GenerateStorageId(importManifestFileHash));

            // Create import update request body (containing Urls to import manifest and update payload files)
            return CreateImportBody(importManifestUrl, importManifestFileSize, importManifestFileHash, payloadUrl);
        }
        
        private string CreateAduPayloadFile(string fileName)
        {
            var content = new
            {
                Scenario = "DeviceUpdateClientSample",
                Timestamp = DateTime.UtcNow.ToString("O"),
            };

            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, JsonConvert.SerializeObject(content, Formatting.Indented));
            
            return filePath;
        }
        
        private string CreateImportManifestContent(string provider, string name, string version, string fileName, long fileSize, string fileHash, Tuple<string, string>[] compatibilityIds)
        {
            var aduContent = new ImportManifest(
                new UpdateId(provider, name, version),
                "microsoft/swupdate:1", "1.2.3.4",
                new List<ImportManifestCompatibilityInfo>(
                    compatibilityIds.Select(c => new ImportManifestCompatibilityInfo(c.Item1, c.Item2))),
                DateTime.UtcNow, new Version(2, 0), new List<ImportManifestFile>()
                {
                    new ImportManifestFile(
                        fileName, 
                        fileSize, 
                        new Dictionary<HashType, string>()
                        {
                            {
                                HashType.Sha256, fileHash
                            }
                        })
                });

            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, JsonConvert.SerializeObject(aduContent, Formatting.Indented));

            return filePath;
        }
        
        private ImportUpdateInput CreateImportBody(string importManifestUrl, long importManifestFileSize, string importManifestFileHash, string payloadUrl)
        {
            return new ImportUpdateInput(
                new ImportManifestMetadata(
                    importManifestUrl, 
                    importManifestFileSize, 
                    new Dictionary<string, string>()
                    {
                        { "SHA256", importManifestFileHash}
                    }), 
                new[]
                {
                    new FileImportMetadata(FileName, payloadUrl)
                });
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

        
        private long GetFileSize(string filePath)
        {
            return new FileInfo(filePath).Length;
        }

        private string GetFileHash(string filePath)
        {
            SHA256 sha256 = SHA256.Create();
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(fileStream);
                return Convert.ToBase64String(hash);
            }
        }

        private string GenerateStorageId(string fileHash)
        {
            return fileHash.Substring(0, 22);
        }
    }
}
