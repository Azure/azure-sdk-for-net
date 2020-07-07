// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal static class CloudBlobContainerExtensions
    {
        public static async Task<IEnumerable<IListBlobItem>> ListBlobsAsync(this CloudBlobContainer container, string prefix, 
            bool useFlatBlobListing, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            List<IListBlobItem> allResults = new List<IListBlobItem>();
            BlobContinuationToken continuationToken = null;
            BlobResultSegment result;

            do
            {
                result = await container.ListBlobsSegmentedAsync(prefix: prefix, useFlatBlobListing: useFlatBlobListing,
                    blobListingDetails: BlobListingDetails.None, maxResults: null, currentToken: continuationToken,
                    options: null, operationContext: null, cancellationToken: cancellationToken);

                if (result != null)
                {
                    IEnumerable<IListBlobItem> currentResults = result.Results;
                    if (currentResults != null)
                    {
                        allResults.AddRange(currentResults);
                    }

                    continuationToken = result.ContinuationToken;
                }
            } 
            while (result != null && continuationToken != null);

            return allResults;
        }
    }
}
