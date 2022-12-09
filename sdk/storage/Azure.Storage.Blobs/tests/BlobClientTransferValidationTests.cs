// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobClientTransferValidationTests : BlobBaseClientTransferValidationTests<BlobClient>
    {
        public BlobClientTransferValidationTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override Task<BlobClient> GetResourceClientAsync(
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

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options));
            return Task.FromResult(InstrumentClient(container.GetBlobClient(resourceName ?? GetNewResourceName())));
        }

        protected override async Task<Stream> OpenWriteAsync(
            BlobClient client,
            UploadTransferValidationOptions transferValidation,
            int internalBufferSize)
        {
            return await client.OpenWriteAsync(true, new BlobOpenWriteOptions
            {
                TransferValidation = transferValidation,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task ParallelUploadAsync(
            BlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions)
            => await client.UploadAsync(source, new BlobUploadOptions
            {
                TransferValidation = transferValidation,
                TransferOptions = transferOptions
            });

        protected override Task<Response> UploadPartitionAsync(
            BlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation)
        {
            TestHelper.AssertInconclusiveRecordingFriendly(Recording.Mode, "BlobClient contains no definition for a 1:1 upload.");
            return Task.FromResult<Response>(null);
        }

        protected override async Task SetupDataAsync(BlobClient client, Stream data)
        {
            await client.UploadAsync(data);
        }

        protected override bool ParallelUploadIsChecksumExpected(Request request)
        {
            // PUT Blob request
            // this doesn't catch a timeout on the query but we aren't adding a timeout in these tests
            if (string.IsNullOrEmpty(request.Uri.Query))
            {
                return true;
            }

            // PUT Block List request
            if (request.Uri.Query.Contains("comp=blocklist"))
            {
                return false;
            }

            // PUT Block request
            if (request.Uri.Query.Contains("comp=block"))
            {
                return true;
            }

            throw new ArgumentException("Could not interpret given request.");
        }

        #region Modified Tests
        //[TestCase(ValidationAlgorithm.MD5)]
        //[TestCase(ValidationAlgorithm.StorageCrc64)]
        //public override Task ParallelUploadOneShotSuccessfulHashComputation(ValidationAlgorithm algorithm)
        //{
        //    if (algorithm == ValidationAlgorithm.StorageCrc64)
        //    {
        //        /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
        //        * Change this to pass for recording and revert when done. */
        //        Assert.Inconclusive("Blob swagger currently doesn't support crc on PUT Blob");
        //    }
        //    return base.ParallelUploadOneShotSuccessfulHashComputation(algorithm);
        //}
        #endregion
    }
}
