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

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return await DestinationClientBuilder.GetTestShareAsync(oauthService, containerName, cancellationToken: cancellationToken);
        }

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            ShareClient containerClient,
            string prefix,
            TransferPropertiesTestType propertiesTestType = default)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), GetShareFileStorageResourceOptions(propertiesTestType));

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            ShareClientOptions options = SourceClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return await SourceClientBuilder.GetTestShareAsync(oauthService, containerName, cancellationToken: cancellationToken);
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
            => await CreateDirectoryAsync(container: sourceContainer, directoryPath: directoryPath, cancellationToken: cancellationToken);

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
            => await CreateDirectoryAsync(container: destinationContainer, directoryPath: directoryPath, cancellationToken: cancellationToken);

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
            Assert.That(items, Is.Empty);
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
            Assert.That(sourceDirectoryNames.Count, Is.EqualTo(destinationDirectoryNames.Count));
            for (int i = 0; i < sourceDirectoryNames.Count; i++)
            {
                Assert.That(sourceDirectoryNames[i], Is.EqualTo(destinationDirectoryNames[i]));

                // Verify Preservation
                ShareDirectoryClient sourceClient = sourceDirectory.GetSubdirectoryClient(sourceDirectoryNames[i]);
                ShareDirectoryClient destinationClient = destinationDirectory.GetSubdirectoryClient(destinationDirectoryNames[i]);
                await VerifyPropertiesCopyAsync(
                    propertiesTestType,
                    sourceClient,
                    destinationClient);
            }

            // Assert file and file contents
            Assert.That(sourceFileNames.Count, Is.EqualTo(destinationFileNames.Count));
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                Assert.That(sourceFileNames[i], Is.EqualTo(destinationFileNames[i]));

                // Verify Download
                string sourceFileName = Path.Combine(sourcePrefix, sourceFileNames[i]);
                ShareFileClient sourceClient = sourceDirectory.GetFileClient(sourceFileNames[i]);
                ShareFileClient destinationClient = destinationDirectory.GetFileClient(destinationFileNames[i]);
                using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
                Assert.That(StreamsAreEqual(sourceStream, destinationStream), Is.True);
                await VerifyPropertiesCopyAsync(
                    propertiesTestType,
                    sourceClient,
                    destinationClient);
            }
        }

        private bool StreamsAreEqual(Stream s1, Stream s2)
        {
            if (s1.Length != s2.Length)
                return false;

            s1.Position = 0;
            s2.Position = 0;

            int byte1, byte2;
            do
            {
                byte1 = s1.ReadByte();
                byte2 = s2.ReadByte();
                if (byte1 != byte2)
                    return false;
            } while (byte1 != -1);

            return true;
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

        private async Task CreateShareFileNfsAndHardLinkAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            await fileClient.CreateAsync(
                maxSize: objectLength.Value,
                cancellationToken: cancellationToken);

            ShareFileClient hardlinkClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient($"{objectName}-hardlink"));

            // Create Hardlink
            await hardlinkClient.CreateHardLinkAsync(
                targetFile: $"{container.GetRootDirectoryClient().Name}/{objectName}");

            // Assert hardlink was successfully created
            ShareFileProperties properties = await hardlinkClient.GetPropertiesAsync();
            Assert.That(properties.PosixProperties.LinkCount, Is.EqualTo(2));
            Assert.That(properties.PosixProperties.FileType, Is.EqualTo(NfsFileType.Regular));
        }

        private async Task CreateShareFileNfsAndSymLinkAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            await fileClient.CreateAsync(
                maxSize: objectLength.Value,
                cancellationToken: cancellationToken);

            ShareFileClient symlinkClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient($"{objectName}-symlink"));

            // Create Symlink
            await symlinkClient.CreateSymbolicLinkAsync(linkText: fileClient.Uri.AbsolutePath);

            // Assert symlink was successfully created
            ShareFileProperties properties = await symlinkClient.GetPropertiesAsync();
            Assert.That(properties.PosixProperties.LinkCount, Is.EqualTo(1));
            Assert.That(properties.PosixProperties.FileType, Is.EqualTo(NfsFileType.SymLink));
        }

        private async Task CreateDirectoryAsync(ShareClient container,
            string directoryPath,
            ShareDirectoryCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(options: options, cancellationToken: cancellationToken);
        }

        internal async Task CreateDirectoryTreeSmbAsync(
            ShareClient client,
            string sourcePrefix,
            ShareDirectoryCreateOptions options,
            int size)
        {
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            string itemName2 = string.Join("/", sourcePrefix, "item2");
            await CreateObjectInSourceAsync(client, size, itemName1);
            await CreateObjectInSourceAsync(client, size, itemName2);

            string subDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryAsync(client, subDirPath, options);
            string itemName3 = string.Join("/", subDirPath, "item3");
            await CreateObjectInSourceAsync(client, size, itemName3);

            string subDirPath2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryAsync(client, subDirPath2, options);
            string itemName4 = string.Join("/", subDirPath2, "item4");
            await CreateObjectInSourceAsync(client, size, itemName4);
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

                Assert.That(destinationProperties.Metadata, Is.Empty);
                Assert.That(destinationProperties.ContentDisposition, Is.Null);
                Assert.That(destinationProperties.ContentLanguage, Is.Null);
                Assert.That(destinationProperties.CacheControl, Is.Null);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(_defaultContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(_defaultContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(_defaultCacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(_defaultContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(_defaultFileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(_defaultFileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(_defaultFileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(_defaultFileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);

                string sourcePermissionStr = RemoveSacl(sourcePermission.Permission);
                string destPermissionStr = RemoveSacl(fullPermission.Permission);
                Assert.That(sourcePermissionStr, Is.EqualTo(destPermissionStr));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNoPermissions)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfs)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.PosixProperties.Owner, Is.EqualTo(destinationProperties.PosixProperties.Owner));
                Assert.That(sourceProperties.PosixProperties.Group, Is.EqualTo(destinationProperties.PosixProperties.Group));
                Assert.That(sourceProperties.PosixProperties.FileMode.ToString(), Is.EqualTo(destinationProperties.PosixProperties.FileMode.ToString()));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfsNoPermissions)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfsToSmb)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                // FileChangedOn is not preserved for NFS -> SMB transfers
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveSmbToNfs)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
            }
            else // Default properties
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.ContentDisposition, Is.EqualTo(destinationProperties.ContentDisposition));
                Assert.That(sourceProperties.ContentLanguage, Is.EqualTo(destinationProperties.ContentLanguage));
                Assert.That(sourceProperties.CacheControl, Is.EqualTo(destinationProperties.CacheControl));
                Assert.That(sourceProperties.ContentType, Is.EqualTo(destinationProperties.ContentType));
                Assert.That(sourceProperties.SmbProperties.FileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));
            }
        }

        protected async Task VerifyPropertiesCopyAsync(
            TransferPropertiesTestType transferPropertiesTestType,
            ShareDirectoryClient sourceClient,
            ShareDirectoryClient destinationClient)
        {
            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(destinationProperties.Metadata, Is.Empty);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(destinationProperties.SmbProperties.FileAttributes, Is.EqualTo(_defaultDirectoryAttributes));
                Assert.That(destinationProperties.SmbProperties.FileCreatedOn, Is.EqualTo(_defaultFileCreatedOn));
                Assert.That(destinationProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(_defaultFileLastWrittenOn));
                Assert.That(destinationProperties.SmbProperties.FileChangedOn, Is.EqualTo(_defaultFileChangedOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));

                // Check if the permissions are the same. Permission Keys will be different as they are defined by the share service.
                ShareClient sourceShareClient = sourceClient.GetParentShareClient();
                ShareFilePermission sourcePermission = await sourceShareClient.GetPermissionAsync(sourceProperties.SmbProperties.FilePermissionKey);

                ShareClient parentDestinationClient = destinationClient.GetParentShareClient();
                ShareFilePermission fullPermission = await parentDestinationClient.GetPermissionAsync(destinationProperties.SmbProperties.FilePermissionKey);

                string sourcePermissionStr = RemoveSacl(sourcePermission.Permission);
                string destPermissionStr = RemoveSacl(fullPermission.Permission);
                Assert.That(sourcePermissionStr, Is.EqualTo(destPermissionStr));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNoPermissions)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileAttributes, Is.EqualTo(destinationProperties.SmbProperties.FileAttributes));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfs)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.PosixProperties.Owner, Is.EqualTo(destinationProperties.PosixProperties.Owner));
                Assert.That(sourceProperties.PosixProperties.Group, Is.EqualTo(destinationProperties.PosixProperties.Group));
                Assert.That(sourceProperties.PosixProperties.FileMode.ToString(), Is.EqualTo(destinationProperties.PosixProperties.FileMode.ToString()));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfsNoPermissions)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveNfsToSmb)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                // FileChangedOn is not preserved for NFS -> SMB transfers
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.PreserveSmbToNfs)
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
            }
            else // Default properties
            {
                ShareDirectoryProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareDirectoryProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(sourceProperties.SmbProperties.FileCreatedOn, Is.EqualTo(destinationProperties.SmbProperties.FileCreatedOn));
                Assert.That(sourceProperties.SmbProperties.FileLastWrittenOn, Is.EqualTo(destinationProperties.SmbProperties.FileLastWrittenOn));
                Assert.That(sourceProperties.SmbProperties.FileChangedOn, Is.EqualTo(destinationProperties.SmbProperties.FileChangedOn));
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
        public async Task ShareDirectoryToShareDirectory_PreserveSmb_NoExistingDestNoOverwriteModeSet(bool? filePermissions)
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
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.ReadOnly | NtfsFileAttributes.Archive,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, directoryCreateOptions, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, FilePermissions = filePermissions });

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
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        public async Task ShareDirectoryToShareDirectory_PreserveSmb_ExistingDestOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions() { CreationMode = StorageResourceCreationMode.OverwriteIfExists };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptionsSrc = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                FilePermission = new ShareFilePermission() { Permission = "O:BAG:BAD:(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;BU)S:NO_ACCESS_CONTROL" },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.Hidden | NtfsFileAttributes.ReadOnly,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };

            ShareDirectoryCreateOptions directoryCreateOptionsDest = new ShareDirectoryCreateOptions()
            {
                Metadata = DataProvider.BuildTags(),
                FilePermission = new ShareFilePermission() { Permission = _defaultPermissions },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.System,
                    FileCreatedOn = new DateTimeOffset(2021, 8, 1, 9, 5, 55, default),
                    FileChangedOn = new DateTimeOffset(2021, 9, 1, 9, 5, 55, default),
                    FileLastWrittenOn = new DateTimeOffset(2021, 10, 1, 9, 5, 55, default),
                },
            };

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryAsync(destination.Container, destPrefix, directoryCreateOptionsDest);
            await CreateDirectoryTreeSmbAsync(destination.Container, destPrefix, directoryCreateOptionsDest, DataMovementTestConstants.KB);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        public async Task ShareDirectoryToShareDirectory_PreserveSmb_ExistingDestNoOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptionsSrc = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                FilePermission = new ShareFilePermission() { Permission = "O:BAG:BAD:(A;;FA;;;SY)(A;;FA;;;BA)(A;;0x1200a9;;;BU)S:NO_ACCESS_CONTROL" },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.Hidden | NtfsFileAttributes.ReadOnly,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };

            ShareDirectoryCreateOptions directoryCreateOptionsDest = new ShareDirectoryCreateOptions()
            {
                Metadata = DataProvider.BuildTags(),
                FilePermission = new ShareFilePermission() { Permission = _defaultPermissions },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.System,
                    FileCreatedOn = new DateTimeOffset(2021, 8, 1, 9, 5, 55, default),
                    FileChangedOn = new DateTimeOffset(2021, 9, 1, 9, 5, 55, default),
                    FileLastWrittenOn = new DateTimeOffset(2021, 10, 1, 9, 5, 55, default),
                },
            };

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryAsync(destination.Container, destPrefix, directoryCreateOptionsDest);
            await CreateDirectoryTreeSmbAsync(destination.Container, destPrefix, directoryCreateOptionsDest, DataMovementTestConstants.KB);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, FilePermissions = filePermissions });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            TransferOperation transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            Assert.That(testEventsRaised.FailedEvents.Count, Is.EqualTo(1));
            Assert.That(testEventsRaised.FailedEvents.FirstOrDefault().Exception.Message, Is.EqualTo(
                $"Share Directory `{destination.Container.GetDirectoryClient(destPrefix + "/bar").Path}` already exists. Cannot overwrite directory."));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveSmb_NoExistingDestOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            TransferOptions options = new TransferOptions() { CreationMode = StorageResourceCreationMode.OverwriteIfExists };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                FilePermission = new ShareFilePermission() { Permission = _defaultPermissions },
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.ReadOnly | NtfsFileAttributes.Archive,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, directoryCreateOptions, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        public async Task ShareDirectoryToShareDirectory_PreserveNfs_NoExistingDestNoOverwriteModeSet(bool? filePermissions)
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
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

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
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveNfs_ExistingDestOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions() { CreationMode = StorageResourceCreationMode.OverwriteIfExists };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptionsSrc = new ShareDirectoryCreateOptions()
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

            ShareDirectoryCreateOptions directoryCreateOptionsDest = new ShareDirectoryCreateOptions()
            {
                Metadata = DataProvider.BuildTags(),
                SmbProperties = new FileSmbProperties()
                {
                    FileCreatedOn = new DateTimeOffset(2021, 8, 1, 9, 5, 55, default),
                    FileLastWrittenOn = new DateTimeOffset(2021, 9, 1, 9, 5, 55, default),
                },
                PosixProperties = new FilePosixProperties()
                {
                    Owner = "3000",
                    Group = "3001",
                    FileMode = NfsFileMode.ParseOctalFileMode("0770"),
                }
            };

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc);
            await CreateDirectoryTreeNfsAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryAsync(destination.Container, destPrefix, directoryCreateOptionsDest);
            await CreateDirectoryTreeNfsAsync(destination.Container, destPrefix, directoryCreateOptionsDest, DataMovementTestConstants.KB);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveNfs_ExistingDestNoOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            ShareDirectoryCreateOptions directoryCreateOptionsSrc = new ShareDirectoryCreateOptions()
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

            ShareDirectoryCreateOptions directoryCreateOptionsDest = new ShareDirectoryCreateOptions()
            {
                Metadata = DataProvider.BuildTags(),
                SmbProperties = new FileSmbProperties()
                {
                    FileCreatedOn = new DateTimeOffset(2021, 8, 1, 9, 5, 55, default),
                    FileLastWrittenOn = new DateTimeOffset(2021, 9, 1, 9, 5, 55, default),
                },
                PosixProperties = new FilePosixProperties()
                {
                    Owner = "3000",
                    Group = "3001",
                    FileMode = NfsFileMode.ParseOctalFileMode("0770"),
                }
            };

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc);
            await CreateDirectoryTreeNfsAsync(source.Container, sourcePrefix, directoryCreateOptionsSrc, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryAsync(destination.Container, destPrefix, directoryCreateOptionsDest);
            await CreateDirectoryTreeNfsAsync(destination.Container, destPrefix, directoryCreateOptionsDest, DataMovementTestConstants.KB);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.That(testEventsRaised.FailedEvents.Count, Is.EqualTo(1));
            Assert.That(testEventsRaised.FailedEvents.FirstOrDefault().Exception.Message, Is.EqualTo(
                $"Share Directory `{destination.Container.GetDirectoryClient(destPrefix + "/bar").Path}` already exists. Cannot overwrite directory."));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveNfs_NoExistingDestOverwriteModeSet(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions() { CreationMode = StorageResourceCreationMode.OverwriteIfExists };
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
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
        public async Task ShareDirectoryToShareDirectory_SmbDestinationOptionsOverride()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            // This will be overridden by destination options
            ShareDirectoryCreateOptions sourceDirOptions = new ShareDirectoryCreateOptions
            {
                Metadata = new Dictionary<string, string> { { "src", "nfsdir" } },
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = NtfsFileAttributes.Directory,
                    FileCreatedOn = new DateTimeOffset(2024, 5, 1, 10, 0, 0, default),
                    FileLastWrittenOn = new DateTimeOffset(2024, 5, 1, 11, 0, 0, default),
                    FileChangedOn = new DateTimeOffset(2024, 5, 1, 12, 0, 0, default)
                }
            };

            // Create source directory
            await CreateDirectoryAsync(source.Container, sourcePrefix, sourceDirOptions);
            string sourceSubDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryAsync(source.Container, sourceSubDirPath, sourceDirOptions);

            // Destination options (override)
            ShareFileStorageResourceOptions destOptions = new ShareFileStorageResourceOptions
            {
                FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.ReadOnly | NtfsFileAttributes.Archive,
                FileCreatedOn = new DateTimeOffset(2025, 1, 1, 1, 1, 1, default),
                FileLastWrittenOn = new DateTimeOffset(2025, 1, 2, 2, 2, 2, default),
                FileChangedOn = new DateTimeOffset(2025, 1, 3, 2, 2, 2, default),
                DirectoryMetadata = new Dictionary<string, string> { { "dest", "overridedir" } },
            };

            // Create destination directory
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions());

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                destOptions);

            // Transfer
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManagerOptions managerOptions = new TransferManagerOptions() { MaximumConcurrency = 1 };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

            // Get destination directory properties
            string destSubDirPath = string.Join("/", destPrefix, "bar");
            ShareDirectoryClient destDirClient = destination.Container.GetDirectoryClient(destSubDirPath);
            ShareDirectoryProperties destDirProps = await destDirClient.GetPropertiesAsync();

            // Assert destination properties are as set in options
            Assert.That(destOptions.DirectoryMetadata, Is.EqualTo(destDirProps.Metadata));
            Assert.That(destOptions.FileAttributes, Is.EqualTo(destDirProps.SmbProperties.FileAttributes));
            Assert.That(destOptions.FileCreatedOn, Is.EqualTo(destDirProps.SmbProperties.FileCreatedOn));
            Assert.That(destOptions.FileLastWrittenOn, Is.EqualTo(destDirProps.SmbProperties.FileLastWrittenOn));
            Assert.That(destOptions.FileChangedOn, Is.EqualTo(destDirProps.SmbProperties.FileChangedOn));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_NfsDestinationOptionsOverride(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            // This will be overridden by destination options
            ShareDirectoryCreateOptions sourceDirOptions = new ShareDirectoryCreateOptions
            {
                Metadata = new Dictionary<string, string> { { "src", "nfsdir" } },
                SmbProperties = new FileSmbProperties
                {
                    FileCreatedOn = new DateTimeOffset(2024, 5, 1, 10, 0, 0, default),
                    FileLastWrittenOn = new DateTimeOffset(2024, 5, 1, 11, 0, 0, default),
                },
                PosixProperties = new FilePosixProperties
                {
                    Owner = "345",
                    Group = "123",
                    FileMode = NfsFileMode.ParseOctalFileMode("1777"),
                }
            };

            // Create source directory
            await CreateDirectoryAsync(source.Container, sourcePrefix, sourceDirOptions);
            string sourceSubDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryAsync(source.Container, sourceSubDirPath, sourceDirOptions);

            // Destination options (override)
            ShareFileStorageResourceOptions destOptions = new ShareFileStorageResourceOptions
            {
                FileCreatedOn = new DateTimeOffset(2025, 1, 1, 1, 1, 1, default),
                FileLastWrittenOn = new DateTimeOffset(2025, 1, 2, 2, 2, 2, default),
                DirectoryMetadata = new Dictionary<string, string> { { "dest", "overridedir" } },
                ShareProtocol = ShareProtocol.Nfs,
                FilePermissions = filePermissions
            };

            // Create destination directory
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                destOptions);

            // Transfer
            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManagerOptions managerOptions = new TransferManagerOptions() { MaximumConcurrency = 1 };
            TransferManager transferManager = new TransferManager(managerOptions);

            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

            // Get destination directory properties
            string destSubDirPath = string.Join("/", destPrefix, "bar");
            ShareDirectoryClient destDirClient = destination.Container.GetDirectoryClient(destSubDirPath);
            ShareDirectoryProperties destDirProps = await destDirClient.GetPropertiesAsync();

            // Assert destination properties are as set in options
            Assert.That(destOptions.DirectoryMetadata, Is.EqualTo(destDirProps.Metadata));
            Assert.That(destOptions.FileCreatedOn, Is.EqualTo(destDirProps.SmbProperties.FileCreatedOn));
            Assert.That(destOptions.FileLastWrittenOn, Is.EqualTo(destDirProps.SmbProperties.FileLastWrittenOn));

            if (filePermissions == true)
            {
                // Should preserve NFS properties from source
                ShareDirectoryClient sourceDirClient = source.Container.GetDirectoryClient(sourceSubDirPath);
                ShareDirectoryProperties sourceDirProps = await sourceDirClient.GetPropertiesAsync();
                Assert.That(sourceDirProps.PosixProperties.Owner, Is.EqualTo(destDirProps.PosixProperties.Owner));
                Assert.That(sourceDirProps.PosixProperties.Group, Is.EqualTo(destDirProps.PosixProperties.Group));
                Assert.That(sourceDirProps.PosixProperties.FileMode.ToOctalFileMode(), Is.EqualTo(destDirProps.PosixProperties.FileMode.ToOctalFileMode()));
            }
            else
            {
                // Should use default NFS properties
                Assert.That(destDirProps.PosixProperties.Owner, Is.EqualTo("0"));
                Assert.That(destDirProps.PosixProperties.Group, Is.EqualTo("0"));
                Assert.That(destDirProps.PosixProperties.FileMode.ToOctalFileMode(), Is.EqualTo("0755"));
            }
        }

        [RecordedTest]
        [TestCase(ShareProtocol.Nfs, ShareProtocol.Nfs)]
        [TestCase(ShareProtocol.Smb, ShareProtocol.Smb)]
        public async Task ValidateProtocolAsync_SmbShareDirectoryToSmbShareDirectory_CompareProtocolSetToActual(ShareProtocol sourceProtocol, ShareProtocol destProtocol)
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
                new ShareFileStorageResourceOptions() { ShareProtocol = sourceProtocol });

            ShareDirectoryClient destClient = destination.Container.GetDirectoryClient(destPrefix);
            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destClient,
                new ShareFileStorageResourceOptions() { ShareProtocol = destProtocol });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            if (sourceProtocol == ShareProtocol.Smb && destProtocol == ShareProtocol.Smb)
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options).ConfigureAwait(false);

                // Act
                using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.That(transfer, Is.Not.Null);
                Assert.That(transfer.HasCompleted, Is.True);
                Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
                Assert.That(ex.Message, Is.EqualTo($"The Protocol set on the source '{ShareProtocols.Nfs}' does not match the actual Protocol of the share '{ShareProtocols.Smb}'."));
            }
        }

        [RecordedTest]
        [TestCase(ShareProtocol.Nfs, ShareProtocol.Nfs)]
        [TestCase(ShareProtocol.Smb, ShareProtocol.Smb)]
        public async Task ValidateProtocolAsync_NfsShareDirectoryToNfsShareDirectory_CompareProtocolSetToActual(ShareProtocol sourceProtocol, ShareProtocol destProtocol)
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
                new ShareFileStorageResourceOptions() { ShareProtocol = sourceProtocol });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = destProtocol });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Act and Assert
            if (sourceProtocol == ShareProtocol.Nfs && destProtocol == ShareProtocol.Nfs)
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

                // Act
                using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.That(transfer, Is.Not.Null);
                Assert.That(transfer.HasCompleted, Is.True);
                Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
                Assert.That(ex.Message, Is.EqualTo($"The Protocol set on the source '{ShareProtocols.Smb}' does not match the actual Protocol of the share '{ShareProtocols.Nfs}'."));
            }
        }

        [RecordedTest]
        public async Task ShareDirectoryToShareDirectory_NfsHardLink()
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
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            await CreateShareFileNfsAndHardLinkAsync(source.Container, DataMovementTestConstants.KB, itemName1);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = true });

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
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

            await VerifyResultsAsync(
                sourceContainer: source.Container,
                sourcePrefix: sourcePrefix,
                destinationContainer: destination.Container,
                destinationPrefix: destPrefix,
                propertiesTestType: TransferPropertiesTestType.PreserveNfs);

            ShareDirectoryClient destinationDirectory = destination.Container.GetDirectoryClient(destPrefix);
            ShareFileClient destinationClient = destinationDirectory.GetFileClient("item1-hardlink");
            ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();
            // Assert the hardlink was copied as regular file
            Assert.That(destinationProperties.PosixProperties.LinkCount, Is.EqualTo(1));
            Assert.That(destinationProperties.PosixProperties.FileType, Is.EqualTo(NfsFileType.Regular));
        }

        [RecordedTest]
        public async Task ShareDirectoryToShareDirectory_NfsSymbolicLink()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            await CreateShareFileNfsAndSymLinkAsync(source.Container, DataMovementTestConstants.KB, itemName1);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

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
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

            // List all files in source folder path
            List<string> sourceFileNames = new List<string>();
            List<string> sourceDirectoryNames = new List<string>();
            ShareDirectoryClient sourceDirectory = source.Container.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
                sourceDirectoryNames.AddRange(page.Values.Where((ShareFileItem item) => item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }

            // List all files in the destination folder path
            List<string> destinationFileNames = new List<string>();
            List<string> destinationDirectoryNames = new List<string>();
            ShareDirectoryClient destinationDirectory = destination.Container.GetDirectoryClient(destPrefix);
            await foreach (Page<ShareFileItem> page in destinationDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                destinationFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
                destinationDirectoryNames.AddRange(page.Values.Where((ShareFileItem item) => item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }

            // Assert subdirectories
            Assert.That(sourceDirectoryNames.Count, Is.EqualTo(destinationDirectoryNames.Count));
            Assert.That(sourceDirectoryNames, Is.EqualTo(destinationDirectoryNames));
            // Ensure the Symlink file was skipped and not copied
            Assert.That(sourceFileNames.Count, Is.EqualTo(2));
            Assert.That(destinationFileNames.Count, Is.EqualTo(1));
            Assert.That(sourceFileNames, Does.Contain("item1-symlink"));
            Assert.That(destinationFileNames, Does.Not.Contain("item1-symlink"));
            Assert.That(destinationFileNames[0], Is.EqualTo("item1"));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryNfsToShareDirectorySmb(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareSasNfsAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

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
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb, FilePermissions = filePermissions });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions() { MaximumConcurrency = 1 };
            TransferManager transferManager = new TransferManager(managerOptions);

            if (filePermissions == true)
            {
                var ex = Assert.ThrowsAsync<NotSupportedException>(async () =>
                    await transferManager.StartTransferAsync(sourceResource, destinationResource, options));
                Assert.That(ex.Message, Is.EqualTo("Permission preservation is not supported in NFS -> SMB or SMB -> NFS transfers"));
            }
            else
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options).ConfigureAwait(false);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.That(transfer, Is.Not.Null);
                Assert.That(transfer.HasCompleted, Is.True);
                Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

                await VerifyResultsAsync(
                    sourceContainer: source.Container,
                    sourcePrefix: sourcePrefix,
                    destinationContainer: destination.Container,
                    destinationPrefix: destPrefix,
                    propertiesTestType: TransferPropertiesTestType.PreserveNfsToSmb);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectorySmbToShareDirectoryNfs(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareSasNfsAsync();

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
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.ReadOnly | NtfsFileAttributes.Archive,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };
            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix, directoryCreateOptions);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, directoryCreateOptions, DataMovementTestConstants.KB);
            // setup destination
            await CreateDirectoryInDestinationAsync(destination.Container, destPrefix);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions() { MaximumConcurrency = 1 };
            TransferManager transferManager = new TransferManager(managerOptions);

            if (filePermissions == true)
            {
                var ex = Assert.ThrowsAsync<NotSupportedException>(async () =>
                    await transferManager.StartTransferAsync(sourceResource, destinationResource, options));
                Assert.That(ex.Message, Is.EqualTo("Permission preservation is not supported in NFS -> SMB or SMB -> NFS transfers"));
            }
            else
            {
                // Start transfer and await for completion.
                TransferOperation transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options).ConfigureAwait(false);

                // Act
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    transfer,
                    testEventsRaised,
                    cancellationTokenSource.Token);

                // Assert
                testEventsRaised.AssertUnexpectedFailureCheck();
                Assert.That(transfer, Is.Not.Null);
                Assert.That(transfer.HasCompleted, Is.True);
                Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

                await VerifyResultsAsync(
                    sourceContainer: source.Container,
                    sourcePrefix: sourcePrefix,
                    destinationContainer: destination.Container,
                    destinationPrefix: destPrefix,
                    propertiesTestType: TransferPropertiesTestType.PreserveSmbToNfs);
            }
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public async Task ShareDirectoryToShareDirectory_PreserveNfs_OAuth(bool? filePermissions)
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await SourceClientBuilder.GetTestShareOauthNfsAsync(TestEnvironment.Credential);
            await using IDisposingContainer<ShareClient> destination = await DestinationClientBuilder.GetTestShareOauthNfsAsync(TestEnvironment.Credential);

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
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destination.Container.GetDirectoryClient(destPrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs, FilePermissions = filePermissions });

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));

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
    }
}
