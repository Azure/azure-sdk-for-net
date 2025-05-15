// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Azure.Core.TestFramework;
using System.Text.RegularExpressions;

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
            => await CreateDirectoryAsync(sourceContainer, directoryPath, cancellationToken);

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
            => await CreateDirectoryAsync(destinationContainer, directoryPath, cancellationToken);

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

        private async Task CreateShareFileNfsAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            ShareFileCreateOptions sharefileCreateOptions = new ShareFileCreateOptions()
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
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
                PosixProperties = new FilePosixProperties()
                {
                    Owner = "345",
                    Group = "123",
                    FileMode = NfsFileMode.ParseOctalFileMode("1777"),
                }
            };
            await fileClient.CreateAsync(
                maxSize: objectLength.Value,
                options: sharefileCreateOptions,
                cancellationToken: cancellationToken);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        private async Task CreateDirectoryAsync(ShareClient container, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        private async Task CreateDirectoryAsync(ShareClient container,
            string directoryPath,
            ShareDirectoryCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(options: options, cancellationToken: cancellationToken);
        }

        private async Task CreateDirectoryTreeNfsAsync(ShareClient client,
            string sourcePrefix,
            ShareDirectoryCreateOptions options,
            int size)
        {
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            string itemName2 = string.Join("/", sourcePrefix, "item2");
            await CreateShareFileNfsAsync(client, size, itemName1);
            await CreateShareFileNfsAsync(client, size, itemName2);

            string subDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryAsync(client, subDirPath, options);
            string itemName3 = string.Join("/", subDirPath, "item3");
            await CreateShareFileNfsAsync(client, size, itemName3);

            string subDirPath2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryAsync(client, subDirPath2, options);
            string itemName4 = string.Join("/", subDirPath2, "item4");
            await CreateShareFileNfsAsync(client, size, itemName4);
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
                Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
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
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);

                string sourcePermissionStr = RemoveSacl(sourcePermission.Permission);
                string destPermissionStr = RemoveSacl(fullPermission.Permission);
                Assert.AreEqual(sourcePermissionStr, destPermissionStr);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNoPermissions)
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
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfs)
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
                Assert.AreEqual(sourceProperties.PosixProperties.Owner, destinationProperties.PosixProperties.Owner);
                Assert.AreEqual(sourceProperties.PosixProperties.Group, destinationProperties.PosixProperties.Group);
                Assert.AreEqual(sourceProperties.PosixProperties.FileMode.ToString(), destinationProperties.PosixProperties.FileMode.ToString());
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfsNoPermissions)
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
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
        }

        // removes the SACL from the SDDL string, which is only used for auditing
        private string RemoveSacl(string sddl)
        {
            return Regex.Replace(sddl, @"S:.*$", "", RegexOptions.IgnoreCase).Trim();
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

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveSmb(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                FilePermission = new ShareFilePermission() { Permission = _defaultPermissions },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = _defaultFileAttributes,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeAsync(source.Container, sourcePrefix, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { IsNfs = false, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { IsNfs = false, FilePermissions = filePermissions });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3000));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);

            TransferPropertiesTestType testType = filePermissions == true
                ? TransferPropertiesTestType.Preserve
                : TransferPropertiesTestType.PreserveNoPermissions;
            await VerifyResultsAsync(
                sourceContainer: source.Container,
                sourcePrefix: sourcePrefix,
                destinationContainer: destination.Container,
                destinationPrefix: destPrefix,
                propertiesTestType: testType);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveNfs(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                SmbProperties = new FileSmbProperties()
                {
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
                PosixProperties = new FilePosixProperties()
                {
                    Owner = "345",
                    Group = "123",
                    FileMode = NfsFileMode.ParseOctalFileMode("1777"),
                }
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeNfsAsync(source.Container, sourcePrefix, directoryCreateOptions, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { IsNfs = true });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { IsNfs = true, FilePermissions = filePermissions });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3000));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);

            TransferPropertiesTestType testType = filePermissions == true
                ? TransferPropertiesTestType.PreserveNfs
                : TransferPropertiesTestType.PreserveNfsNoPermissions;
            await VerifyResultsAsync(
                sourceContainer: source.Container,
                sourcePrefix: sourcePrefix,
                destinationContainer: destination.Container,
                destinationPrefix: destPrefix,
                propertiesTestType: testType);
        }

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public async Task ValidateProtocolAsync_SmbShareDirectoryToSmbShareDirectory_CompareProtocolSetToActual(bool sourceIsNfs, bool destIsNfs)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                FilePermission = new ShareFilePermission() { Permission = _defaultPermissions },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = _defaultFileAttributes,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeAsync(source.Container, sourcePrefix, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            ShareDirectoryClient sourceClient = source.Container.GetDirectoryClient(sourcePrefix);
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                sourceClient,
                new ShareFileStorageResourceOptions() { IsNfs = sourceIsNfs });

            ShareDirectoryClient destClient = destination.Container.GetDirectoryClient(destPrefix);
            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destClient,
                new ShareFileStorageResourceOptions() { IsNfs = destIsNfs });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            if (!sourceIsNfs && !destIsNfs)
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options).ConfigureAwait(false);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3000));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(TransferState.Completed, transfer.Status.State);

                await VerifyResultsAsync(
                    sourceContainer: source.Container,
                    sourcePrefix: sourcePrefix,
                    destinationContainer: destination.Container,
                    destinationPrefix: destPrefix,
                    propertiesTestType: TransferPropertiesTestType.PreserveNoPermissions);
            }
            else
            {
                var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                    await transferManager.StartTransferAsync(sourceResource, destinationResource, options));
                Assert.AreEqual($"The Protocol set on the source '{ShareProtocols.Nfs}' does not match the actual Protocol of the share '{ShareProtocols.Smb}'.", ex.Message);
            }
        }

        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(false, false)]
        public async Task ValidateProtocolAsync_NfsShareDirectoryToNfsShareDirectory_CompareProtocolSetToActual(bool sourceIsNfs, bool destIsNfs)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                SmbProperties = new FileSmbProperties()
                {
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
                PosixProperties = new FilePosixProperties()
                {
                    Owner = "345",
                    Group = "123",
                    FileMode = NfsFileMode.ParseOctalFileMode("1777"),
                }
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeNfsAsync(source.Container, sourcePrefix, directoryCreateOptions, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { IsNfs = sourceIsNfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { IsNfs = destIsNfs });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            if (sourceIsNfs && destIsNfs)
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3000));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.NotNull(transfer);
                Assert.IsTrue(transfer.HasCompleted);
                Assert.AreEqual(TransferState.Completed, transfer.Status.State);

                await VerifyResultsAsync(
                    sourceContainer: source.Container,
                    sourcePrefix: sourcePrefix,
                    destinationContainer: destination.Container,
                    destinationPrefix: destPrefix,
                    propertiesTestType: TransferPropertiesTestType.PreserveNfsNoPermissions);
            }
            else
            {
                var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
                    await transferManager.StartTransferAsync(sourceResource, destinationResource, options));
                Assert.AreEqual($"The Protocol set on the source '{ShareProtocols.Smb}' does not match the actual Protocol of the share '{ShareProtocols.Nfs}'.", ex.Message);
            }
        }

        [RecordedTest]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task ValidateProtocolAsync_ShareDirectoryToShareDirectory_ShareTransferNotSupported(bool sourceIsNfs, bool destIsNfs)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix);
            await CreateDirectoryTreeAsync(source.Container, sourcePrefix, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { IsNfs = sourceIsNfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { IsNfs = destIsNfs });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            var ex = Assert.ThrowsAsync<NotSupportedException>(async () =>
                await transferManager.StartTransferAsync(sourceResource, destinationResource, options));
            Assert.AreEqual("This Share transfer is not supported. Currently only NFS -> NFS and SMB -> SMB Share transfers are supported", ex.Message);
        }
    }
}
