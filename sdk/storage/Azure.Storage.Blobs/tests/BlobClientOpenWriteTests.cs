// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobClientOpenWriteTests : BlobBaseClientOpenWriteTests<BlobClient>
    {
        public BlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // Validate every test didn't accidentally use client-side encryption when writing a blob.
            AdditionalAssertions += async (client) =>
            {
                IDictionary<string, string> metadata = (await client.GetPropertiesAsync()).Value.Metadata;
                Assert.IsFalse(metadata.ContainsKey(Constants.ClientSideEncryption.EncryptionDataKey));
            };
        }

        /// <summary>
        /// For derived classes to mimic <see cref="BlobClientOpenWriteTests(bool, BlobClientOptions.ServiceVersion)"/>
        /// and have a place to pass a <see cref="RecordedTestMode"/> through.
        /// </summary>
        /// <param name="async"></param>
        /// <param name="serviceVersion"></param>
        protected BlobClientOpenWriteTests(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode)
            : base(async, serviceVersion, mode)
        {
        }

        #region Client-Specific Impl
        protected override BlobClient GetResourceClient(BlobContainerClient container, string resourceName = null, BlobClientOptions options = null)
        {
            Argument.AssertNotNull(container, nameof(container));

            string blobName = resourceName ?? GetNewResourceName();

            if (options == null)
            {
                return container.GetBlobClient(blobName);
            }

            container = InstrumentClient(new BlobContainerClient(container.Uri, Tenants.GetNewSharedKeyCredentials(), options ?? ClientBuilder.GetOptions()));
            return InstrumentClient(container.GetBlobClient(blobName));
        }

        protected override async Task InitializeResourceAsync(BlobClient client, Stream data = null)
        {
            Argument.AssertNotNull(client, nameof(client));

            data ??= new MemoryStream(Array.Empty<byte>());
            await client.UploadAsync(data);
        }

        protected override async Task ModifyAsync(BlobClient client, Stream data)
        {
            Argument.AssertNotNull(client, nameof(client));
            Argument.AssertNotNull(data, nameof(data));

            // need a block blob client to modify
            var blockClient = ClientBuilder.ToBlockBlobClient(client);

            // arbitrary limit just in case `data` is ever larger than max block size
            const int maxBlockSize = 4 * Constants.MB;
            var buffer = new byte[maxBlockSize];

            int lastReadSize;
            var blockList = (await blockClient.GetBlockListAsync()).Value.CommittedBlocks;
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
                await blockClient.StageBlockAsync(blockId, new MemoryStream(buffer, 0, lastReadSize));
                blockIds.Add(blockId);
            }
            await blockClient.CommitBlockListAsync(blockIds);
        }

        protected override async Task<Stream> OpenWriteAsync(
            BlobClient client,
            bool overwrite,
            int? bufferSize = null,
            BlobRequestConditions conditions = null,
            Dictionary<string, string> metadata = null,
            Dictionary<string, string> tags = null,
            HttpHeaderParameters httpHeaders = null,
            IProgress<long> progressHandler = null)
            => await client.OpenWriteAsync(overwrite, new BlobOpenWriteOptions
               {
                   BufferSize = bufferSize,
                   OpenConditions = conditions,
                   Metadata = metadata,
                   Tags = tags,
                   HttpHeaders = httpHeaders.ToBlobHttpHeaders(),
                   ProgressHandler = progressHandler
               });
        #endregion
    }
}
