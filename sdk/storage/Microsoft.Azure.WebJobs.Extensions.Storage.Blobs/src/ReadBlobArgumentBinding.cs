// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal static class ReadBlobArgumentBinding
    {
        public static Task<Stream> TryBindStreamAsync(BlobBaseClient blob, ValueBindingContext context)
        {
            return TryBindStreamAsync(blob, context.CancellationToken);
        }

        public static async Task<Stream> TryBindStreamAsync(BlobBaseClient blob, CancellationToken cancellationToken)
        {
            Stream rawStream;
            try
            {
                rawStream = await blob.OpenReadAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception)
            {
                // Testing generic error case since specific error codes are not available for FetchAttributes
                // (HEAD request), including OpenRead.
                if (!exception.IsNotFound())
                {
                    throw;
                }

                return null;
            }

            return rawStream;
        }
    }
}
