// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class PageBlobClientTransferValidationTests : BlobBaseClientTransferValidationTests<PageBlobClient>
    {
        public PageBlobClientTransferValidationTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override async Task<PageBlobClient> GetResourceClientAsync(
            BlobContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            StorageChecksumAlgorithm uploadAlgorithm = StorageChecksumAlgorithm.None,
            StorageChecksumAlgorithm downloadAlgorithm = StorageChecksumAlgorithm.None,
            BlobClientOptions options = null)
        {
            options ??= ClientBuilder.GetOptions();
            options.TransferValidation.Upload.ChecksumAlgorithm = uploadAlgorithm;
            options.TransferValidation.Download.ChecksumAlgorithm = downloadAlgorithm;

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            var pageBlob = InstrumentClient(container.GetPageBlobClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await pageBlob.CreateAsync(resourceLength);
            }
            return pageBlob;
        }

        protected override async Task<Stream> OpenWriteAsync(
            PageBlobClient client,
            UploadTransferValidationOptions transferValidation,
            int internalBufferSize)
        {
            return await client.OpenWriteAsync(false, 0, new PageBlobOpenWriteOptions
            {
                TransferValidation = transferValidation,
                BufferSize = internalBufferSize
            });
        }

        protected override Task ParallelUploadAsync(
            PageBlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions)
        {
            TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "PageBlobClient contains no definition for parallel upload.");
            return Task.CompletedTask;
        }

        protected override async Task<Response> UploadPartitionAsync(
            PageBlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation)
        {
            return (await client.UploadPagesAsync(source, 0, new PageBlobUploadPagesOptions
            {
                TransferValidation = transferValidation
            })).GetRawResponse();
        }

        protected override async Task SetupDataAsync(PageBlobClient client, Stream data)
        {
            using Stream writestream = await client.OpenWriteAsync(false, 0);
            await data.CopyToAsync(writestream);
            await writestream.FlushAsync();
        }

        protected override bool ParallelUploadIsChecksumExpected(Request request)
        {
            return true;
        }

        #region Test Overrides
        // base test uses non-512 multiples to help with edge cases. Fix those values here.
        [Test]
        public override async Task OpenWriteSuccessfulHashComputation(
            [ValueSource(nameof(GetValidationAlgorithms))] StorageChecksumAlgorithm algorithm,
            [Values(Constants.KB)] int streamBufferSize,
            [Values(512)] int dataSize)
            => await base.OpenWriteSuccessfulHashComputation(algorithm, streamBufferSize, dataSize);

        [Test]
        public override async Task OpenWriteSucceedsWithCallerProvidedCrc(
            [Values(Constants.KB)] int dataSize,
            [Values(Constants.KB, 512)] int bufferSize)
            => await base.OpenWriteSucceedsWithCallerProvidedCrc(dataSize, bufferSize);

        [Test]
        public override async Task OpenWriteFailsOnCallerProvidedCrcMismatch(
            [Values(Constants.KB)] int dataSize,
            [Values(Constants.KB, 512)] int bufferSize)
            => await base.OpenWriteFailsOnCallerProvidedCrcMismatch(dataSize, bufferSize);
        #endregion
    }
}
