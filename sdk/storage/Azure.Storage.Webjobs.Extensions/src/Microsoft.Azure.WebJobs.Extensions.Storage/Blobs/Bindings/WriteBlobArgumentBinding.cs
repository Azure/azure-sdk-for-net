// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
    internal static class WriteBlobArgumentBinding
    {
        public static async Task<WatchableCloudBlobStream> BindStreamAsync(ICloudBlob blob,
            ValueBindingContext context, IBlobWrittenWatcher blobWrittenWatcher)
        {
            var blockBlob = blob as CloudBlockBlob;

            if (blockBlob == null)
            {
                throw new InvalidOperationException("Cannot bind to page or append blobs using 'out string', 'TextWriter', or writable 'Stream' parameters.");
            }

            BlobCausalityManager.SetWriter(blob.Metadata, context.FunctionInstanceId);

            CloudBlobStream rawStream = await blockBlob.OpenWriteAsync(context.CancellationToken);
            IBlobCommitedAction committedAction = new BlobCommittedAction(blob, blobWrittenWatcher);
            return new WatchableCloudBlobStream(rawStream, committedAction);
        }
    }
}