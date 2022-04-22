// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class PageBlobClientTransactionalHashingTests : BlobBaseClientTransactionalHashingTests<PageBlobClient>
    {
        public PageBlobClientTransactionalHashingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override async Task<PageBlobClient> GetResourceClientAsync(
            BlobContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            BlobClientOptions options = null)
        {
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
            UploadTransactionalHashingOptions hashingOptions,
            int internalBufferSize)
        {
            return await client.OpenWriteAsync(false, 0, new PageBlobOpenWriteOptions
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override Task ParallelUploadAsync(
            PageBlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
        {
            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Inconclusive("PageBlobClient contains no definition for parallel upload.");
            return Task.CompletedTask;
        }

        protected override async Task<Response> UploadPartitionAsync(
            PageBlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions)
        {
            return (await client.UploadPagesAsync(source, 0, new PageBlobUploadPagesOptions
            {
                TransactionalHashingOptions = hashingOptions
            })).GetRawResponse();
        }

        protected override async Task SetupDataAsync(PageBlobClient client, Stream data)
        {
            using Stream writestream = await client.OpenWriteAsync(false, 0);
            await data.CopyToAsync(writestream);
            await writestream.FlushAsync();
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
        {
            return true;
        }
    }
}
