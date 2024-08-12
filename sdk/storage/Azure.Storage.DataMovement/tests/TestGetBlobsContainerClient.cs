// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

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
        private List<string> _blobNames;

        public TestGetBlobsContainerClient(
            Uri uri,
            List<string> blobNames,
            BlobClientOptions options = default)
            : base(uri, options)
        {
            _blobNames = new List<string>(blobNames);
        }

        /// <summary>
        /// Returns specific GetBlobs listing in the "foo" directory.
        /// </summary>
        /// <param name="traits">Will not be applicable in this test instance.</param>
        /// <param name="states">Will not be applicable in this test instance.</param>
        /// <param name="prefix">Will be overridden with the prefix "foo"</param>
        /// <param name="cancellationToken">Will not apply in this instance.</param>
        /// <returns></returns>
        public override AsyncPageable<BlobItem> GetBlobsAsync(
            BlobTraits traits = BlobTraits.None,
            BlobStates states = BlobStates.None,
            string prefix = "foo",
            CancellationToken cancellationToken = default)
        {
            List<BlobItem> blobItems = _blobNames.Select(
                blobName => BlobsModelFactory.BlobItem(
                    name: blobName,
                    properties: BlobsModelFactory.BlobItemProperties(
                    accessTierInferred: true,
                    contentLength: 1024,
                    blobType: BlobType.Block,
                    eTag: new ETag("etag")))).ToList();

            return AsyncPageable<BlobItem>.FromPages(new List<Page<BlobItem>>()
                {
                    Page<BlobItem>.FromValues(
                        blobItems,
                        continuationToken: null,
                        response: null)
                });
        }

        /// <summary>
        /// Overriding the Core method of GetBlockBlobClient because overriding
        /// the extension method is not possible.
        /// </summary>
        /// <param name="blobName">Name of the blob in the respective container</param>
        /// <returns>The respective block blob client to the container</returns>
        protected override BlockBlobClient GetBlockBlobClientCore(string blobName)
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
