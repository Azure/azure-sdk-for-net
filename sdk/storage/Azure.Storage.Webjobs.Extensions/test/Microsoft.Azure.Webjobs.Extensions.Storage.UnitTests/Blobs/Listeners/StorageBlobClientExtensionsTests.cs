// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Host.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Listeners
{
    public class StorageBlobClientExtensionsTests
    {
        [Theory]
        [InlineData(4000)]
        [InlineData(30000)]
        public async Task ListBlobsAsync_FollowsContinuationTokensToEnd(int blobCount)
        {
            Mock<CloudBlobClient> mockClient = new Mock<CloudBlobClient>(MockBehavior.Strict, new Uri("https://fakestorage"), null);

            int maxResults = 5000;
            List<IListBlobItem> blobs = GetMockBlobs(blobCount);
            int numPages = (int)Math.Ceiling(((decimal)blobCount / maxResults));

            // create the test data pages with continuation tokens
            List<BlobResultSegment> blobSegments = new List<BlobResultSegment>();
            BlobResultSegment initialSegement = null;
            for (int i = 0; i < numPages; i++)
            {
                BlobContinuationToken continuationToken = null;
                if (i < (numPages - 1))
                {
                    // add a token for all but the last page
                    continuationToken = new BlobContinuationToken()
                    {
                        NextMarker = i.ToString()
                    };
                }

                BlobResultSegment segment = new BlobResultSegment(
                    blobs.Skip(i * maxResults).Take(maxResults).ToArray(),
                    continuationToken);

                if (i == 0)
                {
                    initialSegement = segment;
                }
                else
                {
                    blobSegments.Add(segment);
                }
            }

            // Mock the List function to return the correct blob page
            HashSet<BlobContinuationToken> seenTokens = new HashSet<BlobContinuationToken>();
            BlobResultSegment resultSegment = null;
            mockClient.Setup(p => p.ListBlobsSegmentedAsync("test", true, BlobListingDetails.None, null, It.IsAny<BlobContinuationToken>(), null, It.IsAny<OperationContext>(), It.IsAny<CancellationToken>()))
                .Callback<string, bool, BlobListingDetails, int?, BlobContinuationToken, BlobRequestOptions, OperationContext, CancellationToken>(
                    (prefix, useFlatBlobListing, blobListingDetails, maxResultsValue, currentToken, options, operationContext, cancellationToken) =>
                    {
                        // Previously this is where a bug existed - ListBlobsAsync wasn't handling
                        // continuation tokens properly and kept sending the same initial token
                        Assert.DoesNotContain(currentToken, seenTokens);
                        seenTokens.Add(currentToken);

                        if (currentToken == null)
                        {
                            resultSegment = initialSegement;
                        }
                        else
                        {
                            int idx = int.Parse(currentToken.NextMarker);
                            resultSegment = blobSegments[idx];
                        }
                    })
                .Returns(() => { return Task.FromResult(resultSegment); });

            IEnumerable<IListBlobItem> results = await mockClient.Object.ListBlobsAsync("test", true, BlobListingDetails.None, "test", new TestExceptionHandler(), NullLogger<BlobListener>.Instance, CancellationToken.None);

            Assert.Equal(blobCount, results.Count());
        }

        private class FakeBlobItem : IListBlobItem
        {
            public Uri Uri => throw new NotImplementedException();

            public StorageUri StorageUri => throw new NotImplementedException();

            public CloudBlobDirectory Parent => throw new NotImplementedException();

            public CloudBlobContainer Container => throw new NotImplementedException();
        }

        private List<IListBlobItem> GetMockBlobs(int count)
        {
            List<IListBlobItem> blobs = new List<IListBlobItem>();
            for (int i = 0; i < count; i++)
            {
                blobs.Add(new FakeBlobItem());
            }
            return blobs;
        }
    }
}
