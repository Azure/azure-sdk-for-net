// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using System.IO;
using NUnit.Framework;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using System.Linq;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFilePauseResumeTransferTests : PauseResumeTransferTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public ShareFilePauseResumeTransferTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(
            string containerName = default,
            ShareServiceClient service = default)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceProvider GetStorageResourceProvider()
            => new ShareFilesStorageResourceProvider(TestEnvironment.Credential);

        protected override async Task<StorageResource> CreateSourceStorageResourceItemAsync(
            long size,
            string fileName,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            await fileClient.CreateAsync(size);
            // create a new file and copy contents of stream into it, and then close the FileStream
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                originalStream.Position = 0;
                await fileClient.UploadAsync(originalStream);
            }
            return ShareFilesStorageResourceProvider.FromClient(fileClient);
        }

        protected override StorageResource CreateDestinationStorageResourceItem(
            string fileName,
            ShareClient container,
            Metadata metadata = default,
            string contentLanguage = default)
        {
            ShareFileStorageResourceOptions testOptions = new()
            {
                FileMetadata = metadata,
                ContentLanguage = contentLanguage is null ? null : new[] { contentLanguage }
            };
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            return ShareFilesStorageResourceProvider.FromClient(fileClient, testOptions);
        }

        protected override async Task AssertDestinationProperties(
            string fileName,
            Metadata expectedMetadata,
            string expectedContentLanguage,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            ShareFileProperties props = (await fileClient.GetPropertiesAsync()).Value;
            Assert.That(props.Metadata, Is.EqualTo(expectedMetadata));
            Assert.That(props.ContentLanguage.First, Is.EqualTo(expectedContentLanguage));
        }

        protected override async Task<Stream> GetStreamFromContainerAsync(Uri uri, ShareClient container)
        {
            var uriBuilder = new ShareUriBuilder(uri);
            string fileName = uriBuilder.DirectoryOrFilePath;
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            if (!await fileClient.ExistsAsync())
            {
                throw new FileNotFoundException($"File not found: {uri}");
            }

            // Download the file to a MemoryStream
            ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
            MemoryStream memoryStream = new MemoryStream();
            await downloadInfo.Content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceContainerAsync(
            long size,
            int count,
            string directoryPath,
            ShareClient container)
        {
            for (int i = 0; i < count; i++)
            {
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(GetNewItemName());
                await fileClient.CreateAsync(size);
                // create a new file and copy contents of stream into it, and then close the FileStream
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    originalStream.Position = 0;
                    await fileClient.UploadAsync(originalStream);
                }
            }
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }

        protected override StorageResource CreateDestinationStorageResourceContainer(
            ShareClient container)
        {
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }
    }
}
