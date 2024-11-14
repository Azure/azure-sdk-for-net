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
    public abstract class BlobBaseClientTransferValidationTests<TBlobClient> : TransferValidationTestBase<
        BlobServiceClient,
        BlobContainerClient,
        TBlobClient,
        BlobClientOptions,
        BlobTestEnvironment>
        where TBlobClient : BlobBaseClient
    {
        private const string _blobResourcePrefix = "test-blob-";

        public BlobBaseClientTransferValidationTests(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion,
            RecordedTestMode? mode = null)
            : base(async, _blobResourcePrefix, mode)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(
            BlobServiceClient service = null,
            string containerName = null,
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None)
        {
            var disposingContainer = await ClientBuilder.GetTestContainerAsync(service: service, containerName: containerName);

            disposingContainer.Container.ClientConfiguration.TransferValidation.Upload.ChecksumAlgorithm = uploadAlgorithm;
            disposingContainer.Container.ClientConfiguration.TransferValidation.Download.ChecksumAlgorithm = downloadAlgorithm;

            return disposingContainer;
        }

        protected override async Task<Response> DownloadPartitionAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions transferValidation,
            HttpRange range = default)
        {
            var response = await client.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransferValidation = transferValidation,
                Range = range
            });

            await response.Value.Content.CopyToAsync(destination);
            return response.GetRawResponse();
        }

        protected override async Task ParallelDownloadAsync(
            TBlobClient client,
            Stream destination,
            DownloadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions)
            => await client.DownloadToAsync(destination, new BlobDownloadToOptions
            {
                TransferValidation = transferValidation,
                TransferOptions = transferOptions,
            });

        protected override async Task<Stream> OpenReadAsync(
            TBlobClient client,
            DownloadTransferValidationOptions transferValidation,
            int internalBufferSize)
            => await client.OpenReadAsync(new BlobOpenReadOptions(false)
            {
                BufferSize = internalBufferSize,
                TransferValidation = transferValidation
            });

        [Test]
        public override void TestAutoResolve()
        {
            Assert.AreEqual(
                StorageChecksumAlgorithm.StorageCrc64,
                TransferValidationOptionsExtensions.ResolveAuto(StorageChecksumAlgorithm.Auto));
        }

        #region Added Tests
        [TestCaseSource("GetValidationAlgorithms")]
        public async Task ExpectedDownloadStreamingStreamTypeReturned(StorageChecksumAlgorithm algorithm)
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
            DownloadTransferValidationOptions transferValidation = algorithm == StorageChecksumAlgorithm.None
                ? default
                : new DownloadTransferValidationOptions { ChecksumAlgorithm = algorithm };

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                TransferValidation = transferValidation,
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            // validated stream is buffered
            Assert.AreEqual(typeof(MemoryStream), response.Value.Content.GetType());
        }

        [Test]
        public async Task ExpectedDownloadStreamingStreamTypeReturned_None()
        {
            await using var test = await GetDisposingContainerAsync();

            // Arrange
            var data = GetRandomBuffer(Constants.KB);
            BlobClient blob = InstrumentClient(test.Container.GetBlobClient(GetNewResourceName()));
            using (var stream = new MemoryStream(data))
            {
                await blob.UploadAsync(stream);
            }

            // Act
            Response<BlobDownloadStreamingResult> response = await blob.DownloadStreamingAsync(new BlobDownloadOptions
            {
                Range = new HttpRange(length: data.Length)
            });

            // Assert
            // unvalidated stream type is private; just check we didn't get back a buffered stream
            Assert.AreNotEqual(typeof(MemoryStream), response.Value.Content.GetType());
        }
        #endregion
    }
}
