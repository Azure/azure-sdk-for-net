// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class StorageBlobScanInfoManager : IBlobScanInfoManager
    {
        private readonly JsonSerializer _serializer;
        private readonly string _hostId;
        private readonly string _blobScanInfoDirectoryPath;
        private readonly BlobContainerClient _blobContainerClient;

        public StorageBlobScanInfoManager(string hostId, BlobServiceClient blobClient)
        {
            if (string.IsNullOrEmpty(hostId))
            {
                throw new ArgumentNullException(nameof(hostId));
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException(nameof(blobClient));
            }

            _hostId = hostId;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
            _serializer = JsonSerializer.Create(settings);

            _blobScanInfoDirectoryPath = string.Format(CultureInfo.InvariantCulture, "blobscaninfo/{0}", _hostId);
            _blobContainerClient = blobClient.GetBlobContainerClient(HostContainerNames.Hosts);
        }

        public async Task<DateTime?> LoadLatestScanAsync(string storageAccountName, string containerName)
        {
            var scanInfoBlob = GetScanInfoBlobReference(storageAccountName, containerName);
            DateTime? latestScan = null;
            try
            {
                string scanInfoLine = await scanInfoBlob.DownloadTextAsync(CancellationToken.None).ConfigureAwait(false);
                ScanInfo scanInfo;
                using (StringReader stringReader = new StringReader(scanInfoLine))
                {
                    scanInfo = (ScanInfo)_serializer.Deserialize(stringReader, typeof(ScanInfo));
                }

                if (scanInfo != null)
                {
                    latestScan = scanInfo.LatestScan;
                }

                return latestScan;
            }
            catch (RequestFailedException exception)
            {
                if (exception.IsNotFound())
                {
                    // we haven't saved any scanInfo yet
                    return null;
                }
                throw;
            }
        }

        public async Task UpdateLatestScanAsync(string storageAccountName, string containerName, DateTime latestScan)
        {
            string scanInfoLine;
            ScanInfo scanInfo = new ScanInfo
            {
                LatestScan = latestScan
            };

            using (StringWriter stringWriter = new StringWriter())
            {
                _serializer.Serialize(stringWriter, scanInfo);
                scanInfoLine = stringWriter.ToString();
            }

            try
            {
                BlockBlobClient scanInfoBlob = GetScanInfoBlobReference(storageAccountName, containerName);
                await scanInfoBlob.UploadTextAsync(scanInfoLine).ConfigureAwait(false);
            }
            catch
            {
                // best effort
            }
        }

        private BlockBlobClient GetScanInfoBlobReference(string storageAccountName, string containerName)
        {
            // Path to the status blob is:
            // blobScanInfo/{hostId}/{accountName}/{containerName}/scanInfo
            string blobName = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/scanInfo", storageAccountName, containerName);
            return _blobContainerClient.SafeGetBlockBlobReference(_blobScanInfoDirectoryPath, blobName);
        }

        internal class ScanInfo
        {
            public DateTime LatestScan { get; set; }
        }
    }
}
