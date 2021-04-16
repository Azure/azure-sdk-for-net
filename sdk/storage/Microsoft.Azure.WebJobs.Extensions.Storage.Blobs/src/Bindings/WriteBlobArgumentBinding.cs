// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal static class WriteBlobArgumentBinding
    {
        public static async Task<CacheAfterWriteStream> BindStreamAsync(BlobWithContainer<BlobBaseClient> blob,
            ValueBindingContext context, IBlobWrittenWatcher blobWrittenWatcher, IFunctionDataCache functionDataCache)
        {
            var blockBlob = blob.BlobClient as BlockBlobClient;

            if (blockBlob == null)
            {
                throw new InvalidOperationException("Cannot bind to page or append blobs using 'out string', 'TextWriter', or writable 'Stream' parameters.");
            }
            var functionID = context.FunctionInstanceId;
            BlobProperties properties = await blockBlob.FetchPropertiesOrNullIfNotExistAsync().ConfigureAwait(false);
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            if (properties != null && properties.Metadata != null)
            {
                metadata = new Dictionary<string, string>(properties.Metadata);
            }

            BlobCausalityManager.SetWriter(metadata, functionID);
            BlockBlobOpenWriteOptions options = new BlockBlobOpenWriteOptions()
            {
                Metadata = metadata,
            };
            Stream rawStream = await blockBlob.OpenWriteAsync(true, options).ConfigureAwait(false);
            IBlobCommitedAction committedAction = new BlobCommittedAction(blob, blobWrittenWatcher);

            Stream notifyingStream = new NotifyingBlobStream(rawStream, committedAction);

            return await Task.FromResult(new CacheAfterWriteStream(context.SharedMemoryMetadata, functionDataCache, blob, notifyingStream)).ConfigureAwait(false);
        }
    }
}
