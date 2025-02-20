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
using Azure.Core.TestFramework;
using DMShare::Azure.Storage.DataMovement.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFileStartTransferUploadTests : StartTransferUploadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        // When the file is created, the last modified time is set to the current time.
        // We need to set the last modified time to a fixed value to make the test recordable/predictable.
        private readonly DateTimeOffset? _defaultFileLastWrittenOn = new DateTimeOffset(2024, 11, 24, 11, 23, 45, TimeSpan.FromHours(10));

        public ShareFileStartTransferUploadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> ExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetObjectClientAsync(
            ShareClient container,
            long? resourceLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = default)
        {
            objectName ??= GetNewObjectName();
            if (createResource)
            {
                if (!resourceLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(resourceLength)}.");
                }
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
                await fileClient.CreateAsync(resourceLength.Value);

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }

                return fileClient;
            }
            return container.GetRootDirectoryClient().GetFileClient(objectName);
        }

        protected override StorageResourceItem GetStorageResourceItem(ShareFileClient objectClient)
        {
            ShareFileStorageResourceOptions options = new();
            if (Mode == RecordedTestMode.Record ||
                Mode == RecordedTestMode.Playback)
            {
                options.FileLastWrittenOn = _defaultFileLastWrittenOn;
            }
            return new ShareFileStorageResource(
                objectClient,
                options);
        }

        protected override Task<Stream> OpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();
    }
}
