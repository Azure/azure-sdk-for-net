// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Tests
{
    public class BlockBlobClientOpenWriteTests : BlobBaseClientOpenWriteTests<BlockBlobClient>
    {
        public BlockBlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        protected override BlockBlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string blobName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetBlockBlobClient(blobName);
            }

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetBlockBlobClient(blobName));
        }

        protected override async Task InitializeResourceAsync(BlockBlobClient client, Stream data = null)
        {
            data ??= new MemoryStream(Array.Empty<byte>());
            await client.UploadAsync(data);
        }

        protected override async Task ModifyAsync(BlockBlobClient client, Stream data)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            // open write doesn't support modification, we need to manually edit the blob

            // arbitrary limit just in case `data` is ever larger than max block size
            const int maxBlockSize = 4 * Constants.MB;
            var buffer = new byte[maxBlockSize];

            int lastReadSize;
            var blockList = (await client.GetBlockListAsync()).Value.CommittedBlocks;
            List<string> blockIds = blockList?.Select(block => block.Name).ToList() ?? new List<string>();
            long position = blockList.Select(block => block.SizeLong).Sum();
            while (true)
            {
                lastReadSize = await data.ReadAsync(buffer, 0, buffer.Length);
                if (lastReadSize == 0)
                {
                    break;
                }

                string blockId = Shared.StorageExtensions.GenerateBlockId(position);
                await client.StageBlockAsync(blockId, new MemoryStream(buffer, 0, lastReadSize));
                blockIds.Add(blockId);
            }
            await client.CommitBlockListAsync(blockIds);
        }

        protected override async Task<Stream> OpenWriteAsync(
            BlockBlobClient client,
            bool overwrite,
            int? bufferSize = null,
            BlobRequestConditions conditions = null,
            Dictionary<string, string> metadata = null,
            Dictionary<string, string> tags = null,
            HttpHeaderParameters httpHeaders = null,
            IProgress<long> progressHandler = null)
            => await client.OpenWriteAsync(overwrite, new BlockBlobOpenWriteOptions
            {
                BufferSize = bufferSize,
                OpenConditions = conditions,
                Metadata = metadata,
                Tags = tags,
                HttpHeaders = httpHeaders.ToBlobHttpHeaders(),
                ProgressHandler = progressHandler
            });
    }
}
