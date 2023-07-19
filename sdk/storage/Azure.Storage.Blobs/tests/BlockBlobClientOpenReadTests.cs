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

namespace Azure.Storage.Blobs.Tests
{
    public class BlockBlobClientOpenReadTests : BlobBaseClientOpenReadTests<BlockBlobClient>
    {
        public BlockBlobClientOpenReadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        #region Client-Specific Impl
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

        protected override async Task StageDataAsync(BlockBlobClient client, Stream data)
        {
            // open write ensures stage blocks, allowing later modifications if necessary
            using Stream writeStream = await client.OpenWriteAsync(overwrite: true);
            await data.CopyToAsync(writeStream);
        }

        protected override async Task ModifyDataAsync(BlockBlobClient client, Stream data, ModifyDataMode mode)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            switch (mode)
            {
                case ModifyDataMode.Replace:
                    await UpdateBlobContentsAsync(client, data);
                    break;
                case ModifyDataMode.Append:
                    await UpdateBlobContentsAsync(
                        client,
                        data,
                        await client.GetBlockListAsync());
                    break;
                default:
                    throw Errors.InvalidArgument(nameof(mode));
            }
        }

        private async Task UpdateBlobContentsAsync(BlockBlobClient client, Stream data, BlockList blockList = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            // open write doesn't support modification, we need to manually edit the blob

            // arbitrary limit just in case `data` is ever larger than max block size
            const int maxBlockSize = 4 * Constants.MB;
            var buffer = new byte[maxBlockSize];

            int lastReadSize;
            List<string> blockIds = blockList?.CommittedBlocks.Select(block => block.Name).ToList() ?? new List<string>();
            long position = blockList?.CommittedBlocks.Select(block => block.SizeLong).Sum() ?? 0;
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
        #endregion
    }
}
