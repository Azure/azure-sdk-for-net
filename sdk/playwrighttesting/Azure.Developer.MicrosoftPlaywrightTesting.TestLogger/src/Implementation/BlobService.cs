// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

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

        private static string GetCloudFilePath(string uri, string fileRelativePath)
        {
            string[] parts = uri.Split(new string[] { ReporterConstants.s_sASUriSeparator }, StringSplitOptions.None);
            string containerUri = parts[0];
            string sasToken = parts.Length > 1 ? parts[1] : string.Empty;

            return $"{containerUri}/{fileRelativePath}?{sasToken}";
        }
    }
}
