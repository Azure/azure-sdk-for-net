// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Azure.Storage.Blobs.Specialized;
using System.IO.Pipelines;
using Azure.Storage.Blobs;

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

            var pipe = new Pipe();
            // TODO (kasobol-msft) find replacement
            //CloudBlobStream rawStream = await blockBlob.OpenWriteAsync(context.CancellationToken).ConfigureAwait(false);
            _ = Task.Run(async () => await blockBlob.UploadAsync(pipe.Reader.AsStream()).ConfigureAwait(false));
            IBlobCommitedAction committedAction = new BlobCommittedAction(container, blob, blobWrittenWatcher);
            return await Task.FromResult(new WatchableCloudBlobStream(pipe.Writer.AsStream(), committedAction)).ConfigureAwait(false);
        }
    }
}
