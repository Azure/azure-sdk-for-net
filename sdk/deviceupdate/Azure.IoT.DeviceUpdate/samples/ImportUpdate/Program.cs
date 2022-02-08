// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.IoT.DeviceUpdate;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace Samples
{
    /// <summary>
    /// Device Update for IoT Hub Sample: Import new update
    /// </summary>
    internal class Program
    {
        const string PayloadFilename = "payload.json";

        /// <summary>
        /// Device Update for IoT Hub Sample: Import new update
        /// </summary>
        /// <param name="connectionString">Azure Storage connection string to access blob storage to upload payload files.</param>
        /// <param name="blobContainer">Azure Blob Container name to upload payload files to.</param>
        static async Task Main(string connectionString, string blobContainer)
        {
            Console.WriteLine("Device Update for IoT Hub Sample: Import new update version");
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("You have to provider a valid Azure Storage connection string.");
            }
            if (string.IsNullOrWhiteSpace(blobContainer))
            {
                throw new ArgumentException("You have to provider a valid Azure Blob Container name.");
            }

            var credentials = new InteractiveBrowserCredential(Constant.TenantId, Constant.ClientId);
            var client = new DeviceUpdateClient(Constant.AccountEndpoint, Constant.Instance, credentials);

            var updateVersion = DateTime.Now.ToString("yyyy.Mdd.hmm.s");

            Console.WriteLine("New update:");
            Console.WriteLine($"    Provider: {Constant.Provider}");
            Console.WriteLine($"    Name    : {Constant.Name}");
            Console.WriteLine($"    Version : {updateVersion}");

            Console.WriteLine();
            Console.WriteLine("Generating the new update...");
            var contentFactory = new ContentFactory();
            // payload
            var payloadPath = contentFactory.CreateAduPayloadFile(PayloadFilename);
            long payloadFileSize = GetFileSize(payloadPath);
            string payloadFileHash = GetFileHash(payloadPath);
            // import manifest
            var manifestPath = contentFactory.CreateImportManifestContent(
                Constant.Provider, Constant.Name, updateVersion,
                PayloadFilename,
                payloadFileSize,
                payloadFileHash);
            long manifestFileSize = GetFileSize(manifestPath);
            string manifestFileHash = GetFileHash(manifestPath);

            Console.WriteLine();
            Console.WriteLine($"Uploading the new update artifacts to Azure Storage blob container '{blobContainer}'...");
            // upload payload file
            var payloadUrl = await UploadFileAsync(connectionString, blobContainer, GenerateStorageId("payload"), payloadPath);
            // upload manifest file
            var manifestUrl = await UploadFileAsync(connectionString, blobContainer, GenerateStorageId("manifest"), manifestPath);

            Console.WriteLine();
            Console.WriteLine("Importing the new update...");
            //   - import request body
            var body = contentFactory.CreateImportBody(manifestUrl, manifestFileSize, manifestFileHash, PayloadFilename, payloadUrl);

            try
            {
                var response = await client.ImportUpdateAsync(true, "import", RequestContent.Create(body));
                var doc = JsonDocument.Parse(response.Value.ToMemory());
                Console.WriteLine(doc.RootElement.GetProperty("status").ToString());
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static async Task<string> UploadFileAsync(string connectionString, string blobContainer, string storageId, string filePath)
        {
            BlobClient blob = new BlobClient(
                connectionString,
                blobContainer,
                storageId);
            if (!blob.CanGenerateSasUri)
            {
                throw new NotSupportedException("Blob container doesn't support SAS tokens");
            }
            await blob.UploadAsync(filePath);

            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = blobContainer,
                BlobName = storageId,
                Resource = "b"
            };
            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(1);
            sasBuilder.SetPermissions(BlobAccountSasPermissions.Read);

            var sasUri = blob.GenerateSasUri(sasBuilder);

            return sasUri.ToString();
        }

        private static long GetFileSize(string filePath)
        {
            return new FileInfo(filePath).Length;
        }

        private static string GetFileHash(string filePath)
        {
            SHA256 sha256 = SHA256.Create();
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(fileStream);
                return Convert.ToBase64String(hash);
            }
        }

        private static string GenerateStorageId(string prefix)
        {
            return $"{prefix}_{Guid.NewGuid().ToString("N")}";
        }
    }
}
