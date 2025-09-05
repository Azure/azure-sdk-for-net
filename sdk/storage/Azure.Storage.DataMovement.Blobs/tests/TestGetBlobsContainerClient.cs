// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    /// <summary>
    /// Test Wrapper class around BlobContainerClient written specifically
    /// for testing BlobStorageResourceContainer.GetStorageResourcesAsync().
    ///
    /// Moq does not allow mocking of extension method. It also cannot
    /// mock the core GetBlockBlobClient.
    /// </summary>
    public class TestGetBlobsContainerClient : BlobContainerClient
    {
        private Dictionary<string, List<(string Path, bool IsPrefix)>> _blobHierarchy;

        public TestGetBlobsContainerClient(
            Uri uri,
            Dictionary<string, List<(string Path, bool IsPrefix)>> blobHierarchy,
            BlobClientOptions options = default)
            : base(uri, options)
        {
            _blobHierarchy = blobHierarchy;
        }

        public override AsyncPageable<BlobHierarchyItem> GetBlobsByHierarchyAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string delimiter = default,
            string prefix = default,
            CancellationToken cancellationToken = default)
        {
            List<BlobHierarchyItem> blobHierarchyItems = [];
            List<(string Path, bool IsPrefix)> results = _blobHierarchy[prefix];

            foreach ((string, bool) result in results)
            {
                // Prefix
                if (result.Item2)
                {
                    blobHierarchyItems.Add(new BlobHierarchyItem(result.Item1, default));
                }
                // Blob
                else
                {
                    BlobItem blobItem = BlobsModelFactory.BlobItem(
                        name: result.Item1,
                        properties: BlobsModelFactory.BlobItemProperties(
                            accessTierInferred: true,
                            contentLength: 1024,
                            blobType: BlobType.Block,
                            eTag: new ETag("etag")));
                    blobHierarchyItems.Add(new BlobHierarchyItem(default, blobItem));
                }
            }

            return AsyncPageable<BlobHierarchyItem>.FromPages(
                [
                    Page<BlobHierarchyItem>.FromValues(
                        blobHierarchyItems,
                        continuationToken: null,
                        response: null)
                ]);
        }

        /// <summary>
        /// Overriding the Core method of GetBlockBlobClient because overriding
        /// the extension method is not possible.
        /// </summary>
        /// <param name="blobName">Name of the blob in the respective container</param>
        /// <returns>The respective block blob client to the container</returns>
        protected internal override BlockBlobClient GetBlockBlobClientCore(string blobName)
        {
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(Uri)
            {
                BlobName = blobName
            };

            return new BlockBlobClient(
                blobUriBuilder.ToUri());
        }
    }
}
