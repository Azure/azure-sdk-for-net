// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseShares;
extern alias DMShare;

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
using Azure.Storage.Common;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    public abstract class StartTransferCopyToShareDirectoryTestBase
        : StartTransferDirectoryCopyTestBase<BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        internal readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        internal const string _defaultContentType = "image/jpeg";
        internal const string _defaultContentLanguageBlob = "en-US";
        internal readonly string[] _defaultContentLanguageShare = new[] { "en-US", "en-CA" };
        internal const string _defaultContentDisposition = "inline";
        internal const string _defaultCacheControl = "no-cache";
        internal const NtfsFileAttributes _defaultFileAttributes = NtfsFileAttributes.None;
        internal readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        public const int MaxReliabilityRetries = 5;
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public StartTransferCopyToShareDirectoryTestBase(
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

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return await DestinationClientBuilder.GetTestShareAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            ShareClient containerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = default)
        {
            ShareFileStorageResourceOptions options = new()
            {
                SkipProtocolValidation = true,
            };
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new ShareFileStorageResourceOptions
                {
                    ContentDisposition = _defaultContentDisposition,
                    ContentLanguage = _defaultContentLanguageShare,
                    CacheControl = _defaultCacheControl,
                    ContentType = _defaultContentType,
                    FileMetadata = _defaultMetadata,
                    FileAttributes = _defaultFileAttributes,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                    SkipProtocolValidation = true
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new ShareFileStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    FileMetadata = default,
                    FileAttributes = default,
                    FileCreatedOn = default,
                    FileLastWrittenOn = default,
                    SkipProtocolValidation = true
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.Preserve)
            {
                options = new ShareFileStorageResourceOptions
                {
                    FilePermissions = true,
                    SkipProtocolValidation = true
                };
            }
            // Authorize with SAS when performing operations
            if (containerClient.CanGenerateSasUri)
            {
                Uri uri = containerClient.GenerateSasUri(BaseShares::Azure.Storage.Sas.ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
                ShareClient sasClient = InstrumentClient(new ShareClient(uri, GetShareOptions()));
                return new ShareDirectoryStorageResourceContainer(sasClient.GetDirectoryClient(directoryPath), options);
            }
            return new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(directoryPath), options);
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

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            BlobServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential);
            return await SourceClientBuilder.GetTestContainerAsync(oauthService, containerName);
        }

        // Blob to File always needs OAuth source container
        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await SourceClientBuilder.GetOAuthTestContainerAsync(containerName, TestEnvironment.Credential);

        protected override async Task VerifyEmptyDestinationContainerAsync(ShareClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            IList<ShareFileItem> items = await destinationDirectory.GetFilesAndDirectoriesAsync(cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            BlobContainerClient sourceContainer,
            string sourcePrefix,
            ShareClient destinationContainer,
            string destinationPrefix,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = sourcePrefix
            };
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).AsPages())
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
                BlobBaseClient sourceClient = sourceContainer.GetBlobClient(sourceFullName);
                ShareFileClient destinationClient = destinationDirectory.GetFileClient(destinationFileNames[i]);
                using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);

                if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
                {
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.IsEmpty(destinationProperties.Metadata);
                    Assert.IsNull(destinationProperties.ContentDisposition);
                    Assert.IsNull(destinationProperties.ContentLanguage);
                    Assert.IsNull(destinationProperties.CacheControl);
                }
                else if (propertiesTestType == TransferPropertiesTestType.NewProperties)
                {
                    BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                    Assert.AreEqual(_defaultContentLanguageShare, destinationProperties.ContentLanguage);
                    Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                    Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                    Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                    Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                    Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
                }
                else //(propertiesTestType == TransferPropertiesTestType.Default ||
                     //propertiesTestType == TransferPropertiesTestType.Preserve)
                {
                    BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                    Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage.First());
                    Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                    Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                    Assert.AreEqual(sourceProperties.CreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                }
            }
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
        public override Task DirectoryToDirectory_OAuth()
        {
            // NoOp this test since File To Blob
            return Task.CompletedTask;
        }
    }
}
