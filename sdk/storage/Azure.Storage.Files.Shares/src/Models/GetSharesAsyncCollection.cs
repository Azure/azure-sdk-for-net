// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    internal class GetSharesAsyncCollection : StorageCollectionEnumerator<ShareItem>
    {
        private readonly ShareServiceClient _client;
        private readonly ShareTraits _traits;
        private readonly ShareStates _states;
        private readonly string _prefix;

        public GetSharesAsyncCollection(
            ShareServiceClient client,
            ShareTraits traits = ShareTraits.None,
            ShareStates states = ShareStates.None,
            string prefix = default)
        {
            _client = client;
            _traits = traits;
            _states = states;
            _prefix = prefix;
        }

        public override async ValueTask<Page<ShareItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<SharesSegment> response = await _client.GetSharesInternal(
                continuationToken,
                _traits,
                _states,
                _prefix,
                pageSizeHint,
                async,
                cancellationToken).ConfigureAwait(false);

            return Page<ShareItem>.FromValues(
                response.Value.ShareItems.ToShareItems().ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}

namespace Azure.Storage.Files.Shares
{
    /// <summary>
    /// File service helpers.
    /// </summary>
    internal static partial class ShareExtensions
    {
        /// <summary>
        /// Convert the details into ListSharesIncludeType values.
        /// </summary>
        /// <returns>ListSharesIncludeType values</returns>
        internal static IEnumerable<ListSharesIncludeType> AsIncludeItems(ShareTraits traits, ShareStates states)
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation.
            var items = new List<ListSharesIncludeType>();
            if ((states & ShareStates.Deleted) == ShareStates.Deleted)
            {
                items.Add(ListSharesIncludeType.Deleted);
            }
            if ((traits & ShareTraits.Metadata) == ShareTraits.Metadata)
            {
                items.Add(ListSharesIncludeType.Metadata);
            }
            if ((states & ShareStates.Snapshots) == ShareStates.Snapshots)
            {
                items.Add(ListSharesIncludeType.Snapshots);
            }
            return items.Count > 0 ? items : null;
        }
    }
}
