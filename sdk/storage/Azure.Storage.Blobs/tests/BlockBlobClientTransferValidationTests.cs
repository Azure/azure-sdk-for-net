// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlockBlobClientTransferValidationTests : BlobBaseClientTransferValidationTests<BlockBlobClient>
    {
        public BlockBlobClientTransferValidationTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override Task<BlockBlobClient> GetResourceClientAsync(
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
            return Task.FromResult(InstrumentClient(container.GetBlockBlobClient(resourceName ?? GetNewResourceName())));
        }

        protected override async Task<Stream> OpenWriteAsync(
            BlockBlobClient client,
            UploadTransferValidationOptions transferValidation,
            int internalBufferSize)
        {
            return await client.OpenWriteAsync(true, new BlockBlobOpenWriteOptions
            {
                TransferValidation = transferValidation,
                BufferSize = internalBufferSize
            });
        }

        protected override async Task ParallelUploadAsync(
            BlockBlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation,
            StorageTransferOptions transferOptions)
            => await client.UploadAsync(source, new BlobUploadOptions
            {
                TransferValidation = transferValidation,
                TransferOptions = transferOptions
            });

        protected override async Task<Response> UploadPartitionAsync(
            BlockBlobClient client,
            Stream source,
            UploadTransferValidationOptions transferValidation)
        {
            return (await client.StageBlockAsync(
                Convert.ToBase64String(Recording.Random.NewGuid().ToByteArray()),
                source,
                new BlockBlobStageBlockOptions
                {
                    TransferValidation = transferValidation
                })).GetRawResponse();
        }

        protected override async Task SetupDataAsync(BlockBlobClient client, Stream data)
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
        //        Assert.Inconclusive("Blob swagger currently doesn't support crc on PUT Blob");
        //    }
        //    return base.ParallelUploadOneShotSuccessfulHashComputation(algorithm);
        //}
        #endregion
    }
}
