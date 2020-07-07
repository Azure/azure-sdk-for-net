// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class StorageBlobScanInfoManager : IBlobScanInfoManager
    {
        private readonly JsonSerializer _serializer;
        private readonly string _hostId;
        private CloudBlobDirectory _blobScanInfoDirectory;

        public StorageBlobScanInfoManager(string hostId, CloudBlobClient blobClient)
        {
            if (string.IsNullOrEmpty(hostId))
            {
                throw new ArgumentNullException("hostId");
            }
            if (blobClient == null)
            {
                throw new ArgumentNullException("blobClient");
            }

            _hostId = hostId;
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
            _serializer = JsonSerializer.Create(settings);

            string blobScanInfoDirectoryPath = string.Format(CultureInfo.InvariantCulture, "blobscaninfo/{0}", _hostId);
            _blobScanInfoDirectory = blobClient.GetContainerReference(HostContainerNames.Hosts).GetDirectoryReference(blobScanInfoDirectoryPath);
        }

        public async Task<DateTime?> LoadLatestScanAsync(string storageAccountName, string containerName)
        {
            var scanInfoBlob = GetScanInfoBlobReference(storageAccountName, containerName);
            DateTime? latestScan = null;
            try
            {
                string scanInfoLine = await scanInfoBlob.DownloadTextAsync(CancellationToken.None);
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
            catch (StorageException exception)
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
                CloudBlockBlob scanInfoBlob = GetScanInfoBlobReference(storageAccountName, containerName);
                await scanInfoBlob.UploadTextAsync(scanInfoLine);
            }
            catch
            {
                // best effort
            }
        }

        private CloudBlockBlob GetScanInfoBlobReference(string storageAccountName, string containerName)
        {
            // Path to the status blob is:
            // blobScanInfo/{hostId}/{accountName}/{containerName}/scanInfo
            string blobName = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/scanInfo", storageAccountName, containerName);
            return _blobScanInfoDirectory.SafeGetBlockBlobReference(blobName);
        }

        internal class ScanInfo
        {
            public DateTime LatestScan { get; set; }
        }
    }
}
