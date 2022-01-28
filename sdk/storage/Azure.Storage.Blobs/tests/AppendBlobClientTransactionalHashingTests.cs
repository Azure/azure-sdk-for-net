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
    public class AppendBlobClientTransactionalHashingTests : BlobBaseClientTransactionalHashingTests<AppendBlobClient>
    {
        public AppendBlobClientTransactionalHashingTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override async Task<AppendBlobClient> GetResourceClientAsync(
            BlobContainerClient container,
            int resourceLength = default,
            bool createResource = default,
            string resourceName = null,
            BlobClientOptions options = null)
        {
            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            var appendBlob = InstrumentClient(container.GetAppendBlobClient(resourceName ?? GetNewResourceName()));
            if (createResource)
            {
                await appendBlob.CreateAsync();
            }
            return appendBlob;
        }

        protected override async Task<Stream> OpenWriteAsync(
            AppendBlobClient client,
            UploadTransactionalHashingOptions hashingOptions,
            int internalBufferSize)
        {
            return await client.OpenWriteAsync(true, new AppendBlobOpenWriteOptions
            {
                TransactionalHashingOptions = hashingOptions,
                BufferSize = internalBufferSize
            });
        }

        protected override Task ParallelUploadAsync(
            AppendBlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions,
            StorageTransferOptions transferOptions)
        {
            /* Need to rerecord? Azure.Core framework won't record inconclusive tests.
             * Change this to pass for recording and revert when done. */
            Assert.Inconclusive("AppendBlobClient contains no definition for parallel upload.");
            return Task.CompletedTask;
        }

        protected override async Task<Response> UploadPartitionAsync(
            AppendBlobClient client,
            Stream source,
            UploadTransactionalHashingOptions hashingOptions)
        {
            return (await client.AppendBlockAsync(source, new AppendBlobAppendBlockOptions
            {
                TransactionalHashingOptions = hashingOptions
            })).GetRawResponse();
        }

        protected override async Task SetupDataAsync(AppendBlobClient client, Stream data)
        {
            using Stream writestream = await client.OpenWriteAsync(false);
            await data.CopyToAsync(writestream);
            await writestream.FlushAsync();
        }

        protected override bool ParallelUploadIsHashExpected(Request request)
        {
            return true;
        }
    }
}
