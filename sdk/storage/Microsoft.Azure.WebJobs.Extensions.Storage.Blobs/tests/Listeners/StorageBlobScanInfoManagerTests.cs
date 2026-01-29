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
            DateTimeOffset now = DateTimeOffset.UtcNow;
            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", now.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.AreEqual(now, result);
        }

        [Test]
        public async Task LoadLatestScan_OldDateTimeFormatWithZulu_CanDeserialize()
        {
            // Test backward compatibility with explicit Z (Zulu) timezone marker
            string hostId = "host-" + Guid.NewGuid().ToString();
            string storageAccountName = "account=" + Guid.NewGuid().ToString();
            string containerName = "container-" + Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            DateTime oldDateTime = new DateTime(2025, 1, 15, 10, 30, 45, DateTimeKind.Utc);
            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);

            // Manually create old format with Z suffix
            string oldFormatJson = $"{{ \"LatestScan\" : \"{oldDateTime:yyyy-MM-ddTHH:mm:ss.fffffffZ}\" }}";
            await blob.UploadTextAsync(oldFormatJson);

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.NotNull(result);
            Assert.AreEqual(oldDateTime, result.Value.UtcDateTime);
        }

        [Test]
        public async Task LoadLatestScan_MixedFormats_BothWork()
        {
            // Ensure both old DateTime and new DateTimeOffset formats work
            string hostId1 = "host-" + Guid.NewGuid().ToString();
            string hostId2 = "host-" + Guid.NewGuid().ToString();
            string storageAccountName = "account=" + Guid.NewGuid().ToString();
            string containerName = "container-" + Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            // Old format (DateTime)
            DateTime oldDateTime = DateTime.UtcNow;
            var blob1 = GetBlockBlobReference(blobServiceClient, hostId1, storageAccountName, containerName);
            await blob1.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", oldDateTime.ToString("o")));

            // New format (DateTimeOffset)
            DateTimeOffset newDateTimeOffset = DateTimeOffset.UtcNow;
            var blob2 = GetBlockBlobReference(blobServiceClient, hostId2, storageAccountName, containerName);
            await blob2.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", newDateTimeOffset.ToString("o")));

            var manager1 = new StorageBlobScanInfoManager(hostId1, blobServiceClient);
            var manager2 = new StorageBlobScanInfoManager(hostId2, blobServiceClient);

            var result1 = await manager1.LoadLatestScanAsync(storageAccountName, containerName);
            var result2 = await manager2.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.AreEqual(oldDateTime, result1.Value.UtcDateTime);
            Assert.AreEqual(newDateTimeOffset, result2.Value);
        }

        [Test]
        public async Task UpdateLatestScan_Inserts()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();
            DateTimeOffset now = DateTimeOffset.UtcNow;

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTimeOffset)(scanInfoJson["LatestScan"]);

            Assert.AreEqual(now, storedTime);
            Assert.AreEqual(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        [Test]
        public async Task UpdateLatestScan_DateTimeOffset_Updates()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            DateTimeOffset now = DateTimeOffset.UtcNow;
            DateTimeOffset past = now.AddMinutes(-1);

            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ 'LatestScan' : '{0}' }}", past.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTimeOffset)scanInfoJson["LatestScan"];

            Assert.AreEqual(now, storedTime);
            Assert.AreEqual(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        [Test]
        public async Task UpdateLatestScan_PreservesDateTimeFormat_Updates()
        {
            // Verify that reading old DateTime format and writing new DateTimeOffset format works
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var container = blobServiceClient.GetBlobContainerClient(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            // Write in old DateTime format
            DateTime oldDateTime = new DateTime(2025, 1, 10, 8, 0, 0, DateTimeKind.Utc);
            var blob = GetBlockBlobReference(blobServiceClient, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", oldDateTime.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, blobServiceClient);

            // Read old format
            var loadedTime = await manager.LoadLatestScanAsync(storageAccountName, containerName);
            Assert.NotNull(loadedTime);
            Assert.AreEqual(oldDateTime, loadedTime.Value.UtcDateTime);

            // Update with new format
            DateTimeOffset newTime = DateTimeOffset.UtcNow;
            await manager.UpdateLatestScanAsync(storageAccountName, containerName, newTime);

            // Verify new format is stored and readable
            var updatedTime = await manager.LoadLatestScanAsync(storageAccountName, containerName);
            Assert.AreEqual(newTime, updatedTime);
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
