// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.Blobs.Listeners
{
    public class StorageBlobScanInfoManagerTests
    {
        [Fact]
        public async Task LoadLatestScan_NoContainer_ReturnsNull()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var account = new FakeStorageAccount();
            var client = account.CreateCloudBlobClient();

            // by default there is no table in this client
            var manager = new StorageBlobScanInfoManager(hostId, client);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.Null(result);
        }

        [Fact]
        public async Task LoadLatestScan_NoBlob_ReturnsNull()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var account = new FakeStorageAccount();
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            var manager = new StorageBlobScanInfoManager(hostId, client);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.Null(result);
        }

        [Fact]
        public async Task LoadLatestScan_Returns_Timestamp()
        {
            string hostId = "host-" + Guid.NewGuid().ToString();
            string storageAccountName = "account=" + Guid.NewGuid().ToString();
            string containerName = "container-" + Guid.NewGuid().ToString();

            var account = new FakeStorageAccount();
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();
            DateTime now = DateTime.UtcNow;
            var blob = GetBlockBlobReference(client, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ \"LatestScan\" : \"{0}\" }}", now.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, client);

            var result = await manager.LoadLatestScanAsync(storageAccountName, containerName);

            Assert.Equal(now, result);
        }

        [Fact]
        public async Task UpdateLatestScan_Inserts()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var account = new FakeStorageAccount();
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();
            DateTime now = DateTime.UtcNow;

            var manager = new StorageBlobScanInfoManager(hostId, client);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(client, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTime)(scanInfoJson["LatestScan"]);

            Assert.Equal(now, storedTime);
            Assert.Equal(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        [Fact]
        public async Task UpdateLatestScan_Updates()
        {
            string hostId = Guid.NewGuid().ToString();
            string storageAccountName = Guid.NewGuid().ToString();
            string containerName = Guid.NewGuid().ToString();

            var account = new FakeStorageAccount();
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(HostContainerNames.Hosts);
            await container.CreateIfNotExistsAsync();

            DateTime now = DateTime.UtcNow;
            DateTime past = now.AddMinutes(-1);

            var blob = GetBlockBlobReference(client, hostId, storageAccountName, containerName);
            await blob.UploadTextAsync(string.Format("{{ 'LatestScan' : '{0}' }}", past.ToString("o")));

            var manager = new StorageBlobScanInfoManager(hostId, client);

            await manager.UpdateLatestScanAsync(storageAccountName, containerName, now);

            var scanInfo = GetBlockBlobReference(client, hostId, storageAccountName, containerName).DownloadText();
            var scanInfoJson = JObject.Parse(scanInfo);
            var storedTime = (DateTime)scanInfoJson["LatestScan"];

            Assert.Equal(now, storedTime);
            Assert.Equal(now, await manager.LoadLatestScanAsync(storageAccountName, containerName));
        }

        private CloudBlockBlob GetBlockBlobReference(CloudBlobClient blobClient, string hostId, string storageAccountName, string containerName)
        {
            string blobScanInfoDirectoryPath = string.Format(CultureInfo.InvariantCulture, "blobscaninfo/{0}", hostId);
            var blobScanInfoDirectory = blobClient.GetContainerReference(HostContainerNames.Hosts).GetDirectoryReference(blobScanInfoDirectoryPath);

            string blobName = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/scanInfo", storageAccountName, containerName);
            return blobScanInfoDirectory.SafeGetBlockBlobReference(blobName);
        }
    }
}