// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    internal static class WriteBlobArgumentBinding
    {
        public static async Task<NotifyingBlobStream> BindStreamAsync(BlobWithContainer<BlobBaseClient> blob,
            ValueBindingContext context, IBlobWrittenWatcher blobWrittenWatcher)
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
            return await Task.FromResult(new NotifyingBlobStream(rawStream, committedAction)).ConfigureAwait(false);
        }
    }
}
