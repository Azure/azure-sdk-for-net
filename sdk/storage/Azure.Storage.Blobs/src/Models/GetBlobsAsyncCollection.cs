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
    internal class GetBlobsAsyncCollection : StorageCollectionEnumerator<BlobItem>
    {
        private readonly BlobContainerClient _client;
        private readonly BlobTraits _traits;
        private readonly BlobStates _states;
        private readonly string _prefix;

        public GetBlobsAsyncCollection(
            BlobContainerClient client,
            BlobTraits traits,
            BlobStates states,
            string prefix)
        {
            _client = client;
            _traits = traits;
            _states = states;
            _prefix = prefix;
        }

        public override async ValueTask<Page<BlobItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<BlobsFlatSegment> response = await _client.GetBlobsInternal(
                continuationToken,
                _traits,
                _states,
                _prefix,
                pageSizeHint,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<BlobItem>.FromValues(
                response.Value.BlobItems.ToBlobItems().ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlobTraits/BlobStates enum methods
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the details into ListBlobsIncludeItem values.
        /// </summary>
        /// <returns>ListBlobsIncludeItem values</returns>
        internal static IEnumerable<ListBlobsIncludeItem> AsIncludeItems(BlobTraits traits, BlobStates states)
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation.
            var items = new List<ListBlobsIncludeItem>();
            if ((traits & BlobTraits.CopyStatus) == BlobTraits.CopyStatus)
            {
                items.Add(ListBlobsIncludeItem.Copy);
            }
            if ((states & BlobStates.Deleted) == BlobStates.Deleted)
            {
                items.Add(ListBlobsIncludeItem.Deleted);
            }
            if ((traits & BlobTraits.Metadata) == BlobTraits.Metadata)
            {
                items.Add(ListBlobsIncludeItem.Metadata);
            }
            if ((states & BlobStates.Snapshots) == BlobStates.Snapshots)
            {
                items.Add(ListBlobsIncludeItem.Snapshots);
            }
            if ((traits & BlobTraits.Tags) == BlobTraits.Tags)
            {
                items.Add(ListBlobsIncludeItem.Tags);
            }
            if ((states & BlobStates.Uncommitted) == BlobStates.Uncommitted)
            {
                items.Add(ListBlobsIncludeItem.Uncommittedblobs);
            }
            if ((states & BlobStates.Version) == BlobStates.Version)
            {
                items.Add(ListBlobsIncludeItem.Versions);
            }
            return items.Count > 0 ? items : null;
        }
    }
}
