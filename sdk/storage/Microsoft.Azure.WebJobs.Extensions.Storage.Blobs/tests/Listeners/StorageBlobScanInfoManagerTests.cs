// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class StorageBlobScanInfoManagerTests
    {
        private BlobServiceClient blobServiceClient;

        public StorageBlobScanInfoManagerTests()
        {
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
        }

        [Test]
        public async Task LoadLatestScan_NoContainer_ReturnsNull()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            // by default there is no table in this client
            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.Null(result);
        }

        [Test]
        public async Task LoadLatestScan_NoBlob_ReturnsNull()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.Null(result);
        }

        [Test]
        public async Task LoadLatestScan_Returns_Timestamp()
        {
            string hostId = "host-" + Guid.NewGuid().ToString();
            string storageAccountName = "account=" + Guid.NewGuid().ToString();
            string containerName = "container-" + Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();
            DateTime now = DateTime.UtcNow;
            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", now.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.AreEqual(now, result);
        }

        [Test]
        public async Task UpdateLatestScan_Inserts()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();
            DateTime now = DateTime.UtcNow;

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTime)(scanInfoJson["LatestScan"]);

            Assert.AreEqual(now, storedTime);
            Assert.AreEqual(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        [Test]
        public async Task UpdateLatestScan_Updates()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            DateTime now = DateTime.UtcNow;
            DateTime past = now.AddMinutes(-1);

            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ 'LatestScan' : '{0}' }}", past.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTime)scanInfoJson["LatestScan"];

            Assert.AreEqual(now, storedTime);
            Assert.AreEqual(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        private BlockBlobClient GetBlockBlobReference(BlobServiceClient blobClient, string hostId, string storageAccountName, string containerName)
        {
            string blobScanInfoDirectoryPath = string.Format(CultureInfo.InvariantCulture, "blobscaninfo/{0}", hostId);
            var blobScanInfoDirectory = blobClient.GetBlobContainerClient(HostContainerNames.Hosts);

            string blobName = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/scanInfo", storageAccountName, containerName);
            return blobScanInfoDirectory.SafeGetBlockBlobReference(blobScanInfoDirectoryPath, blobName);
        }
    }
}
