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

        protected override ShareServiceClient GetOAuthSourceServiceClient()
            => SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth);

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string prefix = null)
            => new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(prefix), default);

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
            List<string> sourceNames = new List<string>();

            // Get source directory client and list the paths
            ShareDirectoryClient sourceDirectory = string.IsNullOrEmpty(sourcePrefix) ?
                sourceContainer.GetRootDirectoryClient() :
                sourceContainer.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceNames.AddRange(page.Values.Select((ShareFileItem item) => item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destinationNames = new List<string>();

            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            await foreach (Page<ShareFileItem> page in destinationDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                destinationNames.AddRange(page.Values.Select((ShareFileItem item) => item.Name));
            }
            Assert.AreEqual(sourceNames.Count, destinationNames.Count);
            sourceNames.Sort();
            destinationNames.Sort();
            for (int i = 0; i < sourceNames.Count; i++)
            {
                // Verify file name to match the
                // (prefix folder path) + (the blob name without the blob folder prefix)
                // TODO: verify if files returns the entire path, and if we really need to be parsing the prefix
                string sourceNonPrefixed = sourceNames[i].Substring(sourcePrefix.Length + 1);
                Assert.AreEqual(
                    sourceNonPrefixed,
                    destinationNames[i].Substring(destinationPrefix.Length + 1));

                // Verify Download
                string sourceFileName = Path.Combine(sourcePrefix, sourceNonPrefixed);
                using Stream sourceStream = await sourceDirectory.GetFileClient(sourceNames[i]).OpenReadAsync();
                using Stream destinationStream = await destinationDirectory.GetFileClient(destinationNames[i]).OpenReadAsync();
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
    }
}
