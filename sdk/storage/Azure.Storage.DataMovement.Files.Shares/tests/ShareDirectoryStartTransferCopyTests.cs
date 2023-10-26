// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test.Shared;
using Azure.Storage.Files.Shares.Tests;
using NUnit.Framework;
using System.Security.AccessControl;
using Microsoft.Extensions.Options;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
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
            Stream contents = default)
            => await CreateShareFileAsync(container, objectLength, objectName, contents);

        protected override async Task CreateObjectInDestinationAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null)
            => await CreateShareFileAsync(container, objectLength, objectName, contents);

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(ShareClient containerClient, string prefix)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), default);

        protected override ShareClient GetOAuthSourceContainerClient(string containerName)
        {
            ShareClientOptions options = SourceClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override ShareClient GetOAuthDestinationContainerClient(string containerName)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, options);
            return oauthService.GetShareClient(containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            service ??= SourceClientBuilder.GetServiceClientFromSharedKeyConfig(SourceClientBuilder.Tenants.TestConfigDefault, SourceClientBuilder.GetOptions());
            ShareServiceClient sasService = new ShareServiceClient(service.GenerateAccountSasUri(
                Sas.AccountSasPermissions.All,
                SourceClientBuilder.Recording.UtcNow.AddDays(1),
                Sas.AccountSasResourceTypes.All),
                SourceClientBuilder.GetOptions());
            return await SourceClientBuilder.GetTestShareAsync(sasService, containerName);
        }

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string prefix = null)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), default);

        protected override async Task CreateDirectoryInSourceAsync(ShareClient sourceContainer, string directoryPath)
            => await CreateDirectoryTree(sourceContainer, directoryPath);

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath)
            => await CreateDirectoryTree(destinationContainer, directoryPath);

        protected override async Task VerifyEmptyDestinationContainerAsync(ShareClient destinationContainer, string destinationPrefix)
        {
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            IList<ShareFileItem> items = await destinationDirectory.GetFilesAndDirectoriesAsync().ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            ShareClient sourceContainer,
            string sourcePrefix,
            ShareClient destinationContainer,
            string destinationPrefix)
        {
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
                using Stream sourceStream = await sourceDirectory.GetFileClient(sourceFileNames[i]).OpenReadAsync();
                using Stream destinationStream = await destinationDirectory.GetFileClient(destinationFileNames[i]).OpenReadAsync();
                Assert.AreEqual(sourceStream, destinationStream);
            }
        }

        private async Task CreateShareFileAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default)
        {
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents);
            }
        }

        private async Task CreateDirectoryTree(ShareClient container, string directoryPath)
        {
            // Parse for parent directory names and create the parent directory(s).
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync();
        }
    }
}
