// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileStartTransferDownloadTests : StartTransferDownloadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";

        public ShareFileStartTransferDownloadTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetObjectClientAsync(
            ShareClient container,
            long? objectLength,
            string objectName,
            bool createObject = false,
            ShareClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            if (createObject)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified.");
                }
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
                await fileClient.CreateAsync(objectLength.Value);

                if (contents != default && contents.Length > 0)
                {
                    await fileClient.UploadAsync(contents);
                }

                return fileClient;
            }
            return container.GetRootDirectoryClient().GetFileClient(objectName);
        }

        protected override StorageResourceItem GetStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();
    }
}
