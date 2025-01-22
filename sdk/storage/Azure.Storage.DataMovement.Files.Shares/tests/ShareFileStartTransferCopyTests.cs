// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using System.Threading;
using BaseShares::Azure.Storage.Files.Shares.Specialized;
using BaseShares::Azure.Storage.Sas;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFileStartTransferCopyTests : StartTransferCopyTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private const string _defaultContentType = "text/plain";
        private readonly string[] _defaultContentLanguage = new[] { "en-US", "en-CA" };
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private const string _defaultShortPermissions = "O:SYG:SYD:(A;;FA;;;BA)(A;;FA;;;SY)(A;;0x1200a9;;;BU)(A;;0x1301bf;;;AU)(A;;FA;;;SY)";
        private const string _defaultPermissions = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
        private const NtfsFileAttributes _defaultFileAttributes = NtfsFileAttributes.None;
        private const NtfsFileAttributes _defaultDirectoryAttributes = NtfsFileAttributes.Directory;
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public ShareFileStartTransferCopyTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        private async Task<ShareFileClient> CreateFileClientWithShortPermissionsAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = TransferPropertiesTestType.Default)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                string permissions = default;
                if (propertiesType == TransferPropertiesTestType.Preserve)
                {
                    permissions = _defaultPermissions;
                }
                await fileClient.CreateAsync(
                    maxSize: objectLength.Value,
                    options: new ShareFileCreateOptions()
                    {
                        HttpHeaders = new ShareFileHttpHeaders()
                        {
                            ContentLanguage = _defaultContentLanguage,
                            ContentDisposition = _defaultContentDisposition,
                            CacheControl = _defaultCacheControl
                        },
                        Metadata =  _defaultMetadata,
                        SmbProperties = new FileSmbProperties()
                        {
                            FileAttributes = _defaultFileAttributes,
                            FileCreatedOn = _defaultFileCreatedOn,
                            FileChangedOn = _defaultFileChangedOn,
                            FileLastWrittenOn = _defaultFileLastWrittenOn,
                        },
                        FilePermission = new ShareFilePermission() { Permission = permissions }
                    });

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri containerSas = container.GenerateSasUri(ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
            ShareUriBuilder sasBuilder = new ShareUriBuilder(containerSas)
            {
                DirectoryOrFilePath = fileClient.Path
            };
            return InstrumentClient(new ShareFileClient(sasBuilder.ToUri(), GetOptions()));
        }

        private async Task<ShareFileClient> CreateFileClientWithPermissionKeyAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = TransferPropertiesTestType.Default,
            CancellationToken cancellationToken = default)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                string permissionKey = default;
                if (propertiesType == TransferPropertiesTestType.Preserve)
                {
                    PermissionInfo permissionInfo = await container.CreatePermissionAsync(new ShareFilePermission() { Permission = _defaultPermissions } );
                    permissionKey = permissionInfo.FilePermissionKey;
                }
                await fileClient.CreateAsync(
                    maxSize: objectLength.Value,
                    new ShareFileCreateOptions()
                    {
                        HttpHeaders =  new ShareFileHttpHeaders()
                        {
                            ContentLanguage = _defaultContentLanguage,
                            ContentDisposition = _defaultContentDisposition,
                            CacheControl = _defaultCacheControl
                        },
                        Metadata = _defaultMetadata,
                        SmbProperties = new FileSmbProperties()
                        {
                            FileAttributes = _defaultFileAttributes,
                            FilePermissionKey = permissionKey,
                            FileCreatedOn = _defaultFileCreatedOn,
                            FileChangedOn = _defaultFileChangedOn,
                            FileLastWrittenOn = _defaultFileLastWrittenOn,
                        }
                    });

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri containerSas = container.GenerateSasUri(ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
            ShareUriBuilder sasBuilder = new ShareUriBuilder(containerSas)
            {
                DirectoryOrFilePath = fileClient.Path
            };
            return InstrumentClient(new ShareFileClient(sasBuilder.ToUri(), GetOptions()));
        }

        protected override Task<ShareFileClient> GetSourceObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
            => CreateFileClientWithPermissionKeyAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents,
                cancellationToken: cancellationToken);

        protected override StorageResourceItem GetSourceStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        protected override Task<ShareFileClient> GetDestinationObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => CreateFileClientWithPermissionKeyAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents,
                cancellationToken: cancellationToken);

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            ShareFileClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
        {
            ShareFileStorageResourceOptions options = default;
            if (type == TransferPropertiesTestType.NewProperties)
            {
                options = new ShareFileStorageResourceOptions
                {
                    ContentDisposition = _defaultContentDisposition,
                    ContentLanguage = _defaultContentLanguage,
                    CacheControl = _defaultCacheControl,
                    ContentType = _defaultContentType,
                    FileMetadata =  _defaultMetadata,
                    FileAttributes = _defaultFileAttributes,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn
                };
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
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
                    FilePermissions = false
                };
            }
            else if (type == TransferPropertiesTestType.Preserve)
            {
                options = new ShareFileStorageResourceOptions
                {
                    FilePermissions = true
                };
            }
            return new ShareFileStorageResource(objectClient, options);
        }

        protected override Task<Stream> DestinationOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        public ShareClientOptions GetOptions()
        {
            var options = new ShareClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
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

        protected override async Task VerifyPropertiesCopyAsync(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            ShareFileClient sourceClient,
            ShareFileClient destinationClient,
            CancellationToken cancellationToken)
        {
            // Verify completion
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            // Verify Copy - using original source File and Copying the destination
            await testEventsRaised.AssertSingleCompletedCheck();
            using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
            using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
            Assert.AreEqual(sourceStream, destinationStream);

            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.IsEmpty(destinationProperties.Metadata);
                Assert.IsNull(destinationProperties.ContentDisposition);
                Assert.IsNull(destinationProperties.ContentLanguage);
                Assert.IsNull(destinationProperties.CacheControl);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                Assert.AreEqual(sourceProperties.SmbProperties.FileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);
                Assert.AreEqual(sourcePermission.Permission, fullPermission.Permission);
            }
            else // Default properties
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                Assert.AreEqual(sourceProperties.SmbProperties.FileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
        }

        private async Task CopyRemoteObjects_VerifyProperties(
            ShareClient sourceContainer,
            ShareClient destinationContainer,
            TransferPropertiesTestType propertiesType)
        {
            // Create file with properties
            ShareFileClient sourceClient = await CreateFileClientWithPermissionKeyAsync(
                container: sourceContainer,
                objectLength: 0,
                createResource: true,
                propertiesType: propertiesType);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);

            // Destination client - Set Properties
            ShareFileClient destinationClient = await GetDestinationObjectClientAsync(
                container: destinationContainer,
                createResource: false);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(
                destinationClient,
                type: propertiesType);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Act - Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await VerifyPropertiesCopyAsync(
                transfer,
                propertiesType,
                testEventsRaised,
                sourceClient,
                destinationClient,
                cancellationToken: cancellationTokenSource.Token);
        }

        [RecordedTest]
        public async Task ShareFileToShareFile_PermissionKeyDefault()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.Default);
        }

        [RecordedTest]
        public async Task ShareFileToShareFile_PermissionKeyPreserve()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.Preserve);
        }

        [RecordedTest]
        public async Task ShareFileToShareFile_PermissionKeyNoPreserve()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.NoPreserve);
        }

        [RecordedTest]
        [TestCase(TransferPropertiesTestType.NewProperties)]
        [TestCase(TransferPropertiesTestType.Preserve)]
        public async Task ShareFileToShareFile_PermissionValue(TransferPropertiesTestType propertiesType)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            // Create file with properties
            ShareFileClient sourceClient = await CreateFileClientWithShortPermissionsAsync(
                container: source.Container,
                objectLength: 0,
                createResource: true,
                propertiesType: propertiesType);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);

            // Destination client - Set Properties
            ShareFileClient destinationClient = await GetDestinationObjectClientAsync(
                container: destination.Container,
                createResource: false);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(
                destinationClient,
                type: propertiesType);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Act - Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            // Verify Copy - using original source File and Copying the destination
            await testEventsRaised.AssertSingleCompletedCheck();
            using Stream sourceStream = await sourceClient.OpenReadAsync();
            using Stream destinationStream = await destinationClient.OpenReadAsync();
            Assert.AreEqual(sourceStream, destinationStream);
            if (propertiesType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission actualPermissions = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);
                Assert.AreEqual(_defaultShortPermissions, actualPermissions.Permission);
            }
            else if (propertiesType == TransferPropertiesTestType.Preserve)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                Assert.AreEqual(sourceProperties.SmbProperties.FileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);
                Assert.AreEqual(sourcePermission.Permission, fullPermission.Permission);
            }
        }
    }
}
