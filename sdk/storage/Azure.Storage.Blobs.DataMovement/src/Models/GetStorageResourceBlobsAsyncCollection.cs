// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement.Models
{
    /// <summary>
    /// Converts the existing Page of Blob Items to BlobStorageResource
    /// as each call to ListBlobs come backs
    /// </summary>
    internal class GetStorageResourceBlobsAsyncCollection : StorageCollectionEnumerator<BlobStorageResource>
    {
        private StorageCollectionEnumerator<BlobItem> _getBlobsCollection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="getBlobsCollection"></param>
        public GetStorageResourceBlobsAsyncCollection(StorageCollectionEnumerator<BlobItem> getBlobsCollection)
        {
            _getBlobsCollection = getBlobsCollection;
        }

        /// <summary>
        /// Gets the next page / calls the GetBlobsInternal call with the continuation token
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <param name="pageSizeHint"></param>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<Page<BlobStorageResource>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
