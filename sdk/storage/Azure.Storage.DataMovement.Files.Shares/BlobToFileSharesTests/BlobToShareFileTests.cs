// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Storage.Files.Shares.Tests;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public class BlobToShareFileTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public BlobToShareFileTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(
            BlobServiceClient service = default,
            string containerName = default)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        /// <summary>
        /// Gets the specific storage resource from the given BlockBlobClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected override StorageResourceItem GetSourceStorageResourceItem(BlockBlobClient objectClient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calls the OpenRead method on the BlockBlobClient.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected override Task<Stream> SourceOpenReadAsync(BlockBlobClient objectClient)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected override Task<bool> SourceExistsAsync(BlockBlobClient objectClient)
        {
            throw new NotImplementedException();
        }

        protected override Task<BlockBlobClient> GetSourceObjectClientAsync(BlobContainerClient container, long? objectLength = null, bool createResource = false, string objectName = null, BlobClientOptions options = null, Stream contents = null)
        {
            throw new NotImplementedException();
        }

        protected override Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            throw new NotImplementedException();
        }

        protected override Task<ShareFileClient> GetDestinationObjectClientAsync(ShareClient container, long? objectLength = null, bool createResource = false, string objectName = null, ShareClientOptions options = null, Stream contents = null)
        {
            throw new NotImplementedException();
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(ShareFileClient objectClient)
        {
            throw new NotImplementedException();
        }

        protected override Task<Stream> DestinationOpenReadAsync(ShareFileClient objectClient)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DestinationExistsAsync(ShareFileClient objectClient)
        {
            throw new NotImplementedException();
        }
    }
}
