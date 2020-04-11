// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    internal class GetBlobContainersAsyncCollection : StorageCollectionEnumerator<BlobContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly BlobContainerTraits _traits;
        private readonly string _prefix;

        public GetBlobContainersAsyncCollection(
            BlobServiceClient client,
            BlobContainerTraits traits,
            string prefix = default)
        {
            _client = client;
            _traits = traits;
            _prefix = prefix;
        }

        public override async ValueTask<Page<BlobContainerItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {

            Response<BlobContainersSegment> response = await _client.GetBlobContainersInternal(
                    continuationToken,
                    _traits,
                    _prefix,
                    pageSizeHint,
                    async,
                    cancellationToken).ConfigureAwait(false);

            return Page<BlobContainerItem>.FromValues(
                response.Value.BlobContainerItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlobContainerTraits/BlobContianerStates enum methods.
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the details into ListContainersIncludeType values.
        /// </summary>
        /// <returns>ListContainersIncludeType values</returns>
        internal static IEnumerable<ListContainersIncludeType> AsIncludeItems(BlobContainerTraits traits)
        {
            var items = new List<ListContainersIncludeType>();
            if ((traits & BlobContainerTraits.Metadata) == BlobContainerTraits.Metadata)
            {
                items.Add(ListContainersIncludeType.Metadata);
            }

            return items.Count > 0 ? items : null;
        }
    }
}
