// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    internal class GetFilesAndDirectoriesAsyncCollection : StorageCollectionEnumerator<ShareFileItem>
    {
        private readonly ShareDirectoryClient _client;
        private readonly string _prefix;
        private readonly ShareFileTraits? _traits;
        private readonly bool? _includeExtendedInfo;

        public GetFilesAndDirectoriesAsyncCollection(
            ShareDirectoryClient client,
            string prefix,
            ShareFileTraits? traits,
            bool? includeExtendedInfo)
        {
            _client = client;
            _prefix = prefix;
            _traits = traits;
            _includeExtendedInfo = includeExtendedInfo;
        }

        public override async ValueTask<Page<ShareFileItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool async,
            CancellationToken cancellationToken)
        {
            Response<ListFilesAndDirectoriesSegmentResponse> response = await _client.GetFilesAndDirectoriesInternal(
                continuationToken,
                _prefix,
                pageSizeHint,
                _traits,
                _includeExtendedInfo,
                async,
                cancellationToken)
                .ConfigureAwait(false);

            var items = new List<ShareFileItem>();
            items.AddRange(response.Value.Segment.DirectoryItems.Select(d => d.ToShareFileItem()));
            items.AddRange(response.Value.Segment.FileItems.Select(f => f.ToShareFileItem()));
            return Page<ShareFileItem>.FromValues(
                items.ToArray(),
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
        internal static IEnumerable<ListFilesIncludeType> AsIncludeItems(ShareFileTraits? traits)
        {
            if (traits == null)
            {
                return null;
            }

            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation.
            List<ListFilesIncludeType> items = new List<ListFilesIncludeType>();
            if ((traits & ShareFileTraits.Attributes) == ShareFileTraits.Attributes)
            {
                items.Add(ListFilesIncludeType.Attributes);
            }
            if ((traits & ShareFileTraits.ETag) == ShareFileTraits.ETag)
            {
                items.Add(ListFilesIncludeType.Etag);
            }
            if ((traits & ShareFileTraits.PermissionKey) == ShareFileTraits.PermissionKey)
            {
                items.Add(ListFilesIncludeType.PermissionKey);
            }
            if ((traits & ShareFileTraits.Timestamps) == ShareFileTraits.Timestamps)
            {
                items.Add(ListFilesIncludeType.Timestamps);
            }
            return items.Count > 0 ? items : null;
        }
    }
}
