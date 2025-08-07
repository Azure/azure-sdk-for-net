// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using System.IO;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class BlobService:IBlobService
    {
        private readonly ILogger _logger;

        public BlobService(ILogger? logger)
        {
            _logger = logger ?? new Logger();
        }

        public async Task UploadBufferAsync(string uri, string buffer, string fileRelativePath)
        {
            try
            {
                string cloudFilePath = GetCloudFilePath(uri, fileRelativePath);
                BlobClient blobClient = new(new Uri(cloudFilePath));
                byte[] bufferBytes = Encoding.UTF8.GetBytes(buffer);
                await blobClient.UploadAsync(new BinaryData(bufferBytes), overwrite: true).ConfigureAwait(false);
                _logger.Info($"Uploaded buffer to {fileRelativePath}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to upload buffer: {ex}");
            }
        }

        public void UploadBuffer(string uri, string buffer, string fileRelativePath)
        {
            try
            {
                string cloudFilePath = GetCloudFilePath(uri, fileRelativePath);
                BlobClient blobClient = new(new Uri(cloudFilePath));
                byte[] bufferBytes = Encoding.UTF8.GetBytes(buffer);
                blobClient.Upload(new BinaryData(bufferBytes), overwrite: true);
                _logger.Info($"Uploaded buffer to {fileRelativePath}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Failed to upload buffer: {ex}");
            }
        }

        public void UploadBlobFile(string uri, string fileRelativePath, string filePath)
        {
            string cloudFilePath = GetCloudFilePath(uri, fileRelativePath);
            BlobClient blobClient = new(new Uri(cloudFilePath));
            blobClient.Upload(filePath, overwrite: true);
            _logger.Info($"Uploaded file {filePath} to {fileRelativePath}");
        }
        public string GetCloudFilePath(string uri, string fileRelativePath)
        {
            string[] parts = uri.Split(new string[] { ReporterConstants.s_sASUriSeparator }, StringSplitOptions.None);
            string containerUri = parts[0];
            string sasToken = parts.Length > 1 ? parts[1] : string.Empty;

            return $"{containerUri}/{fileRelativePath}?{sasToken}";
        }
        public string? GetCloudFileName(string filePath, string testExecutionId)
        {
            var fileName = Path.GetFileName(filePath);
            if (fileName == null)
            {
                return null;
            }
            return $"{testExecutionId}/{fileName}"; // TODO check if we need to add {Guid.NewGuid()} for file with same name
        }
    }
}
