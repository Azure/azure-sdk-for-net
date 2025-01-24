// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using BaseShares::Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Test.Shared;
using Azure.Storage.Test;
using NUnit.Framework;
using System.Threading;
using Azure.Core;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareDirectoryStartTransferCopyTests : StartTransferDirectoryCopyTestBase<
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private const string _defaultContentType = "text/plain";
        private readonly string[] _defaultContentLanguage = new[] { "en-US", "en-CA" };
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private const string _defaultPermissions = "O:S-1-5-21-2127521184-1604012920-1887927527-21560751G:S-1-5-21-2127521184-1604012920-1887927527-513D:AI(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;S-1-5-21-397955417-626881126-188441444-3053964)S:NO_ACCESS_CONTROL";
        private const NtfsFileAttributes _defaultFileAttributes = NtfsFileAttributes.None;
        private const NtfsFileAttributes _defaultDirectoryAttributes = NtfsFileAttributes.Directory;
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);

        public ShareDirectoryStartTransferCopyTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task CreateObjectInSourceAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
            => await CreateShareFileAsync(
                container: container,
                objectLength: objectLength,
                objectName: objectName,
                contents: contents,
                cancellationToken: cancellationToken);

        protected override async Task CreateObjectInDestinationAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => await CreateShareFileAsync(
                container: container,
                objectLength: objectLength,
                objectName: objectName,
                contents: contents,
                cancellationToken: cancellationToken);

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(
            ShareServiceClient service = null,
            string containerName = null,
            CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName, cancellationToken: cancellationToken);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            ShareClient containerClient,
            string prefix,
            TransferPropertiesTestType propertiesTestType = default)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), GetShareFileStorageResourceOptions(propertiesTestType));

        protected override ShareClient GetOAuthSourceContainerClient(string containerName)
        {
            ShareClientOptions options = SourceClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override ShareClient GetOAuthDestinationContainerClient(string containerName)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
        {
            service ??= SourceClientBuilder.GetServiceClientFromSharedKeyConfig(SourceClientBuilder.Tenants.TestConfigDefault, SourceClientBuilder.GetOptions());
            ShareServiceClient sasService = new ShareServiceClient(service.GenerateAccountSasUri(
                Sas.AccountSasPermissions.All,
                SourceClientBuilder.Recording.UtcNow.AddDays(1),
                Sas.AccountSasResourceTypes.All),
                SourceClientBuilder.GetOptions());
            return await SourceClientBuilder.GetTestShareAsync(sasService, containerName, cancellationToken: cancellationToken);
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string prefix = null)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), default);

        protected override async Task CreateDirectoryInSourceAsync(ShareClient sourceContainer, string directoryPath, CancellationToken cancellationToken = default)
            => await CreateDirectoryTreeAsync(sourceContainer, directoryPath, cancellationToken);

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
            => await CreateDirectoryTreeAsync(destinationContainer, directoryPath, cancellationToken);

        protected override async Task VerifyEmptyDestinationContainerAsync(
            ShareClient destinationContainer,
            string destinationPrefix,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            IList<ShareFileItem> items = await destinationDirectory.GetFilesAndDirectoriesAsync(cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            ShareClient sourceContainer,
            string sourcePrefix,
            ShareClient destinationContainer,
            string destinationPrefix,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();
            List<string> sourceDirectoryNames = new List<string>();

            // Get source directory client and list the paths
            ShareDirectoryClient sourceDirectory = string.IsNullOrEmpty(sourcePrefix) ?
                sourceContainer.GetRootDirectoryClient() :
                sourceContainer.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
                sourceDirectoryNames.AddRange(page.Values.Where((ShareFileItem item) => item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            List<string> destinationDirectoryNames = new List<string>();

            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            await foreach (Page<ShareFileItem> page in destinationDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                destinationFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
                destinationDirectoryNames.AddRange(page.Values.Where((ShareFileItem item) => item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }

            // Assert subdirectories
            Assert.AreEqual(sourceDirectoryNames.Count, destinationDirectoryNames.Count);
            Assert.AreEqual(sourceDirectoryNames, destinationDirectoryNames);

            // Assert file and file contents
            Assert.AreEqual(sourceFileNames.Count, destinationFileNames.Count);
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                Assert.AreEqual(
                    sourceFileNames[i],
                    destinationFileNames[i]);

                // Verify Download
                string sourceFileName = Path.Combine(sourcePrefix, sourceFileNames[i]);
                ShareFileClient sourceClient = sourceDirectory.GetFileClient(sourceFileNames[i]);
                ShareFileClient destinationClient = destinationDirectory.GetFileClient(destinationFileNames[i]);
                using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);
                await VerifyPropertiesCopyAsync(
                    propertiesTestType,
                    sourceClient,
                    destinationClient);
            }
        }

        private async Task CreateShareFileAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            string permissionKey = default;
            if (propertiesType == TransferPropertiesTestType.Preserve)
            {
                PermissionInfo permissionInfo = await container.CreatePermissionAsync(new ShareFilePermission() { Permission = _defaultPermissions }, cancellationToken);
                permissionKey = permissionInfo.FilePermissionKey;
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
                    Metadata = _defaultMetadata,
                    SmbProperties = new FileSmbProperties()
                    {
                        FileAttributes = _defaultFileAttributes,
                        FilePermissionKey = permissionKey,
                        FileCreatedOn = _defaultFileCreatedOn,
                        FileChangedOn = _defaultFileChangedOn,
                        FileLastWrittenOn = _defaultFileLastWrittenOn,
                    },
                },
                cancellationToken: cancellationToken);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        private async Task CreateDirectoryTreeAsync(ShareClient container, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        protected async Task VerifyPropertiesCopyAsync(
            TransferPropertiesTestType transferPropertiesTestType,
            ShareFileClient sourceClient,
            ShareFileClient destinationClient)
        {
            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.IsEmpty(destinationProperties.Metadata);
                Assert.IsNull(destinationProperties.ContentDisposition);
                Assert.IsNull(destinationProperties.ContentLanguage);
                Assert.IsNull(destinationProperties.CacheControl);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.Preserve)
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

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);
                Assert.AreEqual(sourcePermission.Permission, fullPermission.Permission);
            }
            else // Default properties
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
            }
        }

        private ShareFileStorageResourceOptions GetShareFileStorageResourceOptions(TransferPropertiesTestType type)
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
                    FileMetadata = _defaultMetadata,
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
            return options;
        }

        private async Task CopyRemoteObjects_VerifyProperties(
            ShareClient sourceContainer,
            ShareClient destinationContainer,
            TransferPropertiesTestType propertiesType)
        {
            // Arrange
            int size = Constants.KB;
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";
            await CreateDirectoryInSourceAsync(sourceContainer, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateShareFileAsync(sourceContainer, size, itemName1, propertiesType: propertiesType);
            await CreateShareFileAsync(sourceContainer, size, itemName2, propertiesType: propertiesType);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(sourceContainer, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateShareFileAsync(sourceContainer, size, itemName3, propertiesType: propertiesType);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(sourceContainer, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateShareFileAsync(sourceContainer, size, itemName4, propertiesType: propertiesType);

            await CreateDirectoryInDestinationAsync(destinationContainer, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource =
                GetSourceStorageResourceContainer(sourceContainer, sourcePrefix);
            StorageResourceContainer destinationResource =
                GetDestinationStorageResourceContainer(destinationContainer, destPrefix, propertiesType);

            // Create Transfer Manager
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);

            // Verify completion
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            await testEventsRaised.AssertContainerCompletedCheck(4);

            // Assert
            await VerifyResultsAsync(
                sourceContainer,
                sourcePrefix,
                destinationContainer,
                destPrefix,
                propertiesType);
        }
    }
}
