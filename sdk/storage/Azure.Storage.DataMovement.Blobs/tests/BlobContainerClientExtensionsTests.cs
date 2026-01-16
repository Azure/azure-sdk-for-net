// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using BaseBlobs::Azure.Storage.Blobs;
using DMBlobs::Azure.Storage.Blobs;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [NonParallelizable]
    public class BlobContainerClientExtensionsTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            ExtensionMockTransferManager = new MockTransferManager();

            _backupTransferManagerValue = (Lazy<TransferManager>)typeof(BlobContainerClientExtensions).GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

            typeof(BlobContainerClientExtensions).GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, new Lazy<TransferManager>(() => ExtensionMockTransferManager));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            typeof(BlobContainerClientExtensions).GetField("s_defaultTransferManager", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, _backupTransferManagerValue);
        }

        [Test]
        public async Task VerifyStartUploadDirectoryAsync([Values] bool addBlobDirectoryPath, [Values] bool addTransferOptions)
        {
            var accountUrl = "https://mockstorageaccount.blob.core.windows.net/";

            var containerName = "mockcontainer";

            var blobDirectoryPrefix = addBlobDirectoryPath ? "blobDirectoryPrefix" : null;

            var blobUri = new Uri(accountUrl + (addBlobDirectoryPath ? containerName + "/" + blobDirectoryPrefix : containerName));

            var directoryPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);

            var options = addTransferOptions ? new TransferOptions() : (TransferOptions)null;

            var assertionComplete = false;

            ExtensionMockTransferManager.OnStartTransferContainerAsync = (sourceResource, destinationResource, transferOptions) =>
            {
                Assert.That(sourceResource.Uri.LocalPath, Is.EqualTo(directoryPath));
                Assert.That(destinationResource.Uri.AbsoluteUri, Is.EqualTo(blobUri));
                Assert.That(transferOptions, Is.EqualTo(options));
                Assert.That(destinationResource, Is.InstanceOf<BlobStorageResourceContainer>());

                assertionComplete = true;
            };

            var client = new BlobServiceClient(new Uri(accountUrl), new DefaultAzureCredential()).GetBlobContainerClient(containerName);

            if (addTransferOptions)
            {
                await client.UploadDirectoryAsync(WaitUntil.Started, directoryPath, new BlobContainerClientTransferOptions
                {
                    BlobContainerOptions = new() { BlobPrefix = blobDirectoryPrefix },
                    TransferOptions = options
                });
            }
            else
            {
                await client.UploadDirectoryAsync(WaitUntil.Started, directoryPath, blobDirectoryPrefix);
            }

            Assert.That(assertionComplete, Is.True);
        }

        [Test]
        public async Task VerifyStartDownloadToDirectoryAsync([Values] bool addBlobDirectoryPath, [Values] bool addTransferOptions)
        {
            var accountUrl = "https://mockstorageaccount.blob.core.windows.net/";

            var containerName = "mockcontainer";

            var blobDirectoryPrefix = addBlobDirectoryPath ? "blobDirectoryPrefix" : null;

            var blobUri = new Uri(accountUrl + (addBlobDirectoryPath ? containerName + "/" + blobDirectoryPrefix : containerName));

            var directoryPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar);

            var options = addTransferOptions ? new TransferOptions() : (TransferOptions)null;

            var expSourceResourceType = addBlobDirectoryPath ? typeof(BlobStorageResourceContainer) : typeof(BlobStorageResourceContainer);

            var assertionComplete = false;

            ExtensionMockTransferManager.OnStartTransferContainerAsync = (sourceResource, destinationResource, transferOptions) =>
            {
                Assert.That(destinationResource.Uri.LocalPath, Is.EqualTo(directoryPath));
                Assert.That(sourceResource.Uri.AbsoluteUri, Is.EqualTo(blobUri));
                Assert.That(transferOptions, Is.EqualTo(options));
                Assert.That(sourceResource, Is.InstanceOf(expSourceResourceType));

                assertionComplete = true;
            };

            var client = new BlobServiceClient(new Uri(accountUrl), new DefaultAzureCredential()).GetBlobContainerClient(containerName);

            if (addTransferOptions)
            {
                await client.DownloadToDirectoryAsync(WaitUntil.Started, directoryPath, new BlobContainerClientTransferOptions
                {
                    BlobContainerOptions = new() { BlobPrefix = blobDirectoryPrefix },
                    TransferOptions = options
                });
            }
            else
            {
                await client.DownloadToDirectoryAsync(WaitUntil.Started, directoryPath, blobDirectoryPrefix);
            }

            Assert.That(assertionComplete, Is.True);
        }

        private MockTransferManager ExtensionMockTransferManager { get; set; }

        private Lazy<TransferManager> _backupTransferManagerValue;

        private class MockTransferManager : TransferManager
        {
            public MockTransferManager() { }

            public Action<StorageResource, StorageResource, TransferOptions> OnStartTransferContainerAsync { get; set; }

            public override Task<TransferOperation> StartTransferAsync(StorageResource sourceResource, StorageResource destinationResource, TransferOptions transferOptions = null, CancellationToken cancellationToken = default)
            {
                if (OnStartTransferContainerAsync != null)
                {
                    OnStartTransferContainerAsync(sourceResource, destinationResource, transferOptions);
                }

                return Task.FromResult<TransferOperation>(null);
            }
        }
    }
}
