// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    [BlobsClientTestFixture]
    public abstract class BlobBaseClientTransactionalHashingTests<TBlobClient> : TransferValidationTestBase<
        BlobServiceClient,
        BlobContainerClient,
        TBlobClient,
        BlobClientOptions,
        BlobTestEnvironment>
        where TBlobClient : BlobBaseClient
    {
        private const string _blobResourcePrefix = "test-blob-";

        public BlobBaseClientTransactionalHashingTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            RecordedTestMode? mode = null)
            : base(async, _blobResourcePrefix, mode)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(
            BlobServiceClient service = null,
            string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service: service, containerName: containerName);

        protected override async Task<Response> DownloadPartitionAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions hashingOptions,
            HttpRange range = default)
        {
            var response = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = range
            });

            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelDownloadAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await client.DownloadToAsync(destination, new BlobDownloadToOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions,
            });

        protected override async Task<Stream> OpenReadAsync(
            TBlobClient client,
            DownloadTransferValidationOptions hashingOptions,
            int internalBufferSize)
            => await client.OpenReadAsync(new BlobOpenReadOptions(false)
            {
                BufferSize = internalBufferSize,
                TransactionalHashingOptions = hashingOptions
            });

        #region Added Tests
        // hashing, so we buffered the stream to hash then rewind before returning to user
        [TestCase(ValidationAlgorithm.MD5, true)]
        [TestCase(ValidationAlgorithm.StorageCrc64, true)]
        // no hashing, so we save users a buffer
        [TestCase(ValidationAlgorithm.None, false)]
        public async Task ExpectedDownloadStreamingStreamTypeReturned(ValidationAlgorithm algorithm, bool isBuffered)
        {
            await using var test = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewResourceName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }
            // don't make options instance at all for no hash request
            DownloadTransferValidationOptions hashingOptions = algorithm == ValidationAlgorithm.None
                ? default
                : new DownloadTransferValidationOptions { Algorithm = algorithm };

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            if (isBuffered)
            {
                Assert.AreEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
            // actual unbuffered stream type is private; just check we didn't get back a buffered stream
            else
            {
                Assert.AreNotEqual(typeof(MemoryStream), response.Value.Content.GetType());
            }
        }
        #endregion
    }
}
