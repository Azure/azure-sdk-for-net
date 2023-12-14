// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
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

        private async Task<ShareFileClient> CreateFileClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                await fileClient.CreateAsync(objectLength.Value);

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri sourceUri = fileClient.GenerateSasUri(Sas.ShareFileSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new ShareFileClient(sourceUri, GetOptions()));
        }

        protected override Task<ShareFileClient> GetSourceObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null)
            => CreateFileClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

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
            Stream contents = null)
            => CreateFileClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetDestinationStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

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
    }
}
