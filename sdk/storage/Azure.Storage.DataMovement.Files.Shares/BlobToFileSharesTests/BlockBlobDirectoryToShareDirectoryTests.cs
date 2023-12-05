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
using Azure.Storage.Test.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class BlockBlobDirectoryToShareDirectoryTests : StartTransferDirectoryCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public BlockBlobDirectoryToShareDirectoryTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = destinationContainer.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        protected override Task CreateDirectoryInSourceAsync(BlobContainerClient sourceContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override async Task CreateObjectInDestinationAsync(ShareClient container, long? objectLength = null, string objectName = null, Stream contents = null, CancellationToken cancellationToken = default)
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

        protected override async Task CreateObjectInSourceAsync(BlobContainerClient container, long? objectLength = null, string objectName = null, Stream contents = null, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);
            if (contents != default)
            {
                await blobClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
            else
            {
                var data = new byte[0];
                using (var stream = new MemoryStream(data))
                {
                    await blobClient.UploadAsync(
                        content: stream,
                        cancellationToken: cancellationToken);
                }
            }
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(ShareClient containerClient, string directoryPath)
        {
            // Authorize with SAS when performing operations
            if (containerClient.CanGenerateSasUri)
            {
                Uri uri = containerClient.GenerateSasUri(Sas.ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
                ShareClient sasClient = InstrumentClient(new ShareClient(uri, GetShareOptions()));
                return new ShareDirectoryStorageResourceContainer(sasClient.GetDirectoryClient(directoryPath), default);
            }
            return new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(directoryPath), default);
        }

        protected override ShareClient GetOAuthDestinationContainerClient(string containerName)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override BlobContainerClient GetOAuthSourceContainerClient(string containerName)
        {
            BlobClientOptions options = SourceClientBuilder.GetOptions();
            BlobServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetBlobContainerClient(containerName);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        protected override StorageResourceContainer GetSourceStorageResourceContainer(BlobContainerClient containerClient, string directoryPath)
            => new BlobStorageResourceContainer(containerClient, new BlobStorageResourceContainerOptions() { BlobDirectoryPrefix = directoryPath, BlobType = BlobType.Block });

        protected override async Task VerifyEmptyDestinationContainerAsync(ShareClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            IList<ShareFileItem> items = await destinationDirectory.GetFilesAndDirectoriesAsync(cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(BlobContainerClient sourceContainer, string sourcePrefix, ShareClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(prefix: sourcePrefix, cancellationToken: cancellationToken).AsPages())
            {
                sourceFileNames.AddRange(page.Values.Select((BlobItem item) => item.Name.Substring(sourcePrefix.Length + 1)));
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            await foreach ((ShareDirectoryClient dir, ShareFileClient file) in ScanShareDirectoryAsync(
                destinationDirectory, cancellationToken).ConfigureAwait(false))
            {
                if (file != default)
                {
                    destinationFileNames.Add(file.Path.Substring(destinationPrefix.Length + 1));
                }
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
                string sourceFullName = string.Join("/", sourcePrefix, sourceFileNames[i]);
                using Stream sourceStream = await sourceContainer.GetBlobClient(sourceFullName).OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationDirectory.GetFileClient(destinationFileNames[i]).OpenReadAsync(cancellationToken: cancellationToken);
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
