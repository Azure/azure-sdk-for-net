// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Shared;
using Azure.Storage.Test.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareDirectoryToPageBlobDirectoryTests : StartTransferDirectoryCopyTestBase
        <ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly object _serviceVersion;

        public ShareDirectoryToPageBlobDirectoryTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
        }

        protected override Task CreateDirectoryInDestinationAsync(BlobContainerClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override async Task CreateDirectoryInSourceAsync(ShareClient sourceContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = sourceContainer.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        protected override async Task CreateObjectInDestinationAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            PageBlobClient blobClient = container.GetPageBlobClient(objectName);
            if (contents != default)
            {
                await UploadPagesAsync(blobClient, contents, cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await UploadPagesAsync(
                        blobClient,
                        stream,
                        cancellationToken);
                }
            }
        }

        private async Task UploadPagesAsync(
            PageBlobClient blobClient,
            Stream contents,
            CancellationToken cancellationToken)
        {
            long size = contents.Length;
            Assert.IsTrue(size % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await blobClient.CreateIfNotExistsAsync(size, cancellationToken: cancellationToken).ConfigureAwait(false);
            long offset = 0;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset, cancellationToken: cancellationToken);
                offset += blockSize;
            }
        }

        protected override async Task CreateObjectInSourceAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(BlobContainerClient sourceContainerClient, string directoryPath)
            => new BlobStorageResourceContainer(sourceContainerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = BlobType.Page });

        protected override BlobContainerClient GetOAuthDestinationContainerClient(string containerName)
        {
            BlobClientOptions options = DestinationClientBuilder.GetOptions();
            BlobServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetBlobContainerClient(containerName);
        }

        protected override ShareClient GetOAuthSourceContainerClient(string containerName)
        {
            ShareClientOptions options = SourceClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(
            ShareServiceClient service = null,
            string containerName = null,
            CancellationToken cancellationToken = default)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string directoryPath)
        {
            // Authorize with SAS when performing operations
            if (containerClient.CanGenerateSasUri)
            {
                Uri sourceUri = containerClient.GenerateSasUri(Sas.ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
                ShareClient sasClient = InstrumentClient(new ShareClient(sourceUri, GetShareOptions()));
                return new ShareDirectoryStorageResourceContainer(sasClient.GetDirectoryClient(directoryPath), default);
            }
            return new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(directoryPath), default);
        }

        protected override async Task VerifyEmptyDestinationContainerAsync(BlobContainerClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            IList<BlobItem> items = await destinationContainer.GetBlobsAsync(prefix: destinationPrefix, cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            ShareClient sourceContainer,
            string sourcePrefix,
            BlobContainerClient destinationContainer,
            string destinationPrefix,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            ShareDirectoryClient sourceDirectory = string.IsNullOrEmpty(sourcePrefix) ?
                sourceContainer.GetRootDirectoryClient() :
                sourceContainer.GetDirectoryClient(sourcePrefix);
            await foreach ((ShareDirectoryClient dir, ShareFileClient file) in ScanShareDirectoryAsync(
                sourceDirectory, cancellationToken).ConfigureAwait(false))
            {
                if (file != default)
                {
                    sourceFileNames.Add(file.Path.Substring(sourcePrefix.Length + 1));
                }
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            await foreach (Page<BlobItem> page in destinationContainer.GetBlobsAsync(prefix: destinationPrefix, cancellationToken: cancellationToken).AsPages())
            {
                destinationFileNames.AddRange(page.Values.Select((BlobItem item) => item.Name.Substring(destinationPrefix.Length + 1)));
            }

            // Assert file and file contents
            Assert.AreEqual(sourceFileNames.Count, destinationFileNames.Count);
            sourceFileNames.Sort();
            destinationFileNames.Sort();
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                Assert.AreEqual(
                    sourceFileNames[i],
                    destinationFileNames[i]);

                // Verify contents
                string destinationFullName = string.Join("/", destinationPrefix, destinationFileNames[i]);
                using Stream sourceStream = await sourceDirectory.GetFileClient(sourceFileNames[i]).OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationContainer.GetBlobClient(destinationFullName).OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);
            }
        }

        public ShareClientOptions GetShareOptions()
        {
            var options = new ShareClientOptions((ShareClientOptions.ServiceVersion)_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        private async IAsyncEnumerable<(ShareDirectoryClient Dir, ShareFileClient File)> ScanShareDirectoryAsync(
            ShareDirectoryClient directory,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(directory, nameof(directory));

            Queue<ShareDirectoryClient> toScan = new();
            toScan.Enqueue(directory);

            while (toScan.Count > 0)
            {
                ShareDirectoryClient current = toScan.Dequeue();
                await foreach (ShareFileItem item in current.GetFilesAndDirectoriesAsync(
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (item.IsDirectory)
                    {
                        ShareDirectoryClient subdir = current.GetSubdirectoryClient(item.Name);
                        toScan.Enqueue(subdir);
                        yield return (Dir: subdir, File: null);
                    }
                    else
                    {
                        yield return (Dir: null, File: current.GetFileClient(item.Name));
                    }
                }
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public override Task DirectoryToDirectory_OAuth()
        {
            // NoOp this test since File To Blob
            return Task.CompletedTask;
        }
    }
}
