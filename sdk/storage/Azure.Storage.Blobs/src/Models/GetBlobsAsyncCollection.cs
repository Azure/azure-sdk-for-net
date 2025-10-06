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
        private readonly string _startFrom;

        public GetBlobsAsyncCollection(
            BlobContainerClient client,
            BlobTraits traits,
            BlobStates states,
            string prefix,
            string startFrom)
        {
            _client = client;
            _traits = traits;
            _states = states;
            _prefix = prefix;
            _startFrom = startFrom;
        }

        public override async ValueTask<Page<BlobItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<ListBlobsFlatSegmentResponse> response;

            if (async)
            {
                response = await _client.GetBlobsInternal(
                    marker: continuationToken,
                    traits: _traits,
                    states: _states,
                    prefix: _prefix,
                    startFrom: _startFrom,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                response = _client.GetBlobsInternal(
                    marker: continuationToken,
                    traits: _traits,
                    states: _states,
                    prefix: _prefix,
                    startFrom: _startFrom,
                    pageSizeHint: pageSizeHint,
                    async: async,
                    cancellationToken: cancellationToken)
                    .EnsureCompleted();
            }

            return Page<BlobItem>.FromValues(
                response.Value.Segment.BlobItems.ToBlobItems(),
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
            if ((traits & BlobTraits.ImmutabilityPolicy) == BlobTraits.ImmutabilityPolicy)
            {
                items.Add(ListBlobsIncludeItem.Immutabilitypolicy);
            }
            if ((traits & BlobTraits.LegalHold) == BlobTraits.LegalHold)
            {
                items.Add(ListBlobsIncludeItem.Legalhold);
            }
            if ((states & BlobStates.Uncommitted) == BlobStates.Uncommitted)
            {
                items.Add(ListBlobsIncludeItem.Uncommittedblobs);
            }
            if ((states & BlobStates.Version) == BlobStates.Version)
            {
                items.Add(ListBlobsIncludeItem.Versions);
            }
            if ((states & BlobStates.DeletedWithVersions) == BlobStates.DeletedWithVersions)
            {
                items.Add(ListBlobsIncludeItem.DeletedWithVersions);
            }
            return items.Count > 0 ? items : null;
        }
    }
}
