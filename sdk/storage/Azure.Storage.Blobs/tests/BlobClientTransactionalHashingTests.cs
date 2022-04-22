// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobClientTransactionalHashingTests : BlobBaseClientTransactionalHashingTests<BlobClient>
    {
        public BlobClientTransactionalHashingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override Task<BlobClient> GetResourceClientAsync(
            BlobContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            BlobClientOptions options = null)
        {
            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return Task.FromResult(InstrumentClient(container.GetBlobClient(resourceName ?? GetNewResourceName())));
        }

        protected override Task<Stream> OpenWriteAsync(
            BlobClient client,
            UploadTransactionalHashingOptions hashingOptions,
            int internalBufferSize)
        {
            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Inconclusive("BlobClient contains no definition for OpenWriteAsync.");
            return Task.FromResult<Stream>(null);
        }

        protected override async Task ParallelUploadAsync(
            BlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
            => await client.UploadAsync(source, new BlobUploadOptions
            {
                TransactionalHashingOptions = hashingOptions,
                TransferOptions = transferOptions
            });

        protected override Task<Response> UploadPartitionAsync(
            BlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions)
        {
            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Inconclusive("BlobClient contains no definition for a 1:1 upload.");
            return Task.FromResult<Response>(null);
        }

        protected override async Task SetupDataAsync(BlobClient client, Stream data)
        {
            await client.UploadAsync(data);
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
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
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public override Task ParallelUploadOneShotSuccessfulHashComputation(TransactionalHashAlgorithm algorithm)
        {
            if (algorithm == TransactionalHashAlgorithm.StorageCrc64)
            {
                /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
                * Change this to pass for recording and revert when done. */
                Assert.Inconclusive("Blob swagger currently doesn't support crc on PUT Blob");
            }
            return base.ParallelUploadOneShotSuccessfulHashComputation(algorithm);
        }
        #endregion

        #region Added Tests
        [TestCase(TransactionalHashAlgorithm.MD5)]
        [TestCase(TransactionalHashAlgorithm.StorageCrc64)]
        public async Task HashingAndClientSideEncryptionIncompatible(TransactionalHashAlgorithm algorithm)
        {
            await using var disposingContainer = await GetDisposingContainerAsync();

            // Arrange
            const int dataSize = Constants.KB;
            var data = GetRandomBuffer(dataSize);

            var hashingOptions = new UploadTransactionalHashingOptions
            {
                Algorithm = algorithm
            };

            var encryptionOptions = new ClientSideEncryptionOptions(ClientSideEncryptionVersion.V1_0)
            {
                KeyEncryptionKey = new Mock<Core.Cryptography.IKeyEncryptionKey>().Object,
                KeyWrapAlgorithm = "foo"
            };

            var clientOptions = ClientBuilder.GetOptions();
            clientOptions._clientSideEncryptionOptions = encryptionOptions;

            var client = await GetResourceClientAsync(
                disposingContainer.Container,
                resourceLength: dataSize,
                createResource: true,
                options: clientOptions);

            // Act
            using var stream = new MemoryStream(data);

            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await ParallelUploadAsync(client, stream, hashingOptions, transferOptions: default));
            Assert.AreEqual("Client-side encryption and transactional hashing are not supported at the same time.", exception.Message);
        }
        #endregion
    }
}
