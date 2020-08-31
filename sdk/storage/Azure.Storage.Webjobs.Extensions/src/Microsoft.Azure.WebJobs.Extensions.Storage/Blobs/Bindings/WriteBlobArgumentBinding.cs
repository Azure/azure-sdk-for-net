// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs;
using System.IO;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    internal static class WriteBlobArgumentBinding
    {
        public static async Task<WatchableCloudBlobStream> BindStreamAsync(BlobContainerClient container, BlobBaseClient blob,
            ValueBindingContext context, IBlobWrittenWatcher blobWrittenWatcher)
        {
            var blockBlob = blob as BlockBlobClient;

            if (blockBlob == null)
            {
                throw new InvalidOperationException("Cannot bind to page or append blobs using 'out string', 'TextWriter', or writable 'Stream' parameters.");
            }
            var functionID = context.FunctionInstanceId;
            // TODO (kasobol-msft) What is this ???
            //BlobCausalityManager.SetWriter(blob.Metadata, context.FunctionInstanceId);

            Stream rawStream = await blockBlob.OpenWriteAsync(true).ConfigureAwait(false);
            IBlobCommitedAction committedAction = new BlobCommittedAction(container, blob, blobWrittenWatcher);
            return await Task.FromResult(new WatchableCloudBlobStream(rawStream, committedAction)).ConfigureAwait(false);
        }
    }
}
