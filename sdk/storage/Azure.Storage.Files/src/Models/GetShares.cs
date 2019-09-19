// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Specifies options for listing shares with the 
    /// <see cref="FileServiceClient.GetSharesAsync"/> operation.
    /// </summary>
    public struct GetSharesOptions : IEquatable<GetSharesOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// shares whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; } // No Prefix header is produced if ""

        /// <summary>
        /// Gets or sets a flag specifing that the share's metadata should be
        /// included.
        /// </summary>
        public bool IncludeMetadata { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the share's snapshots should be
        /// included.  Snapshots are listed from oldest to newest.
        /// </summary>
        public bool IncludeSnapshots { get; set; }

        /// <summary>
        /// Convert the details into ListSharesIncludeType values.
        /// </summary>
        /// <returns>ListSharesIncludeType values</returns>
        internal IEnumerable<ListSharesIncludeType> AsIncludeItems()
        {
            // NOTE: Multiple strings MUST be appended in alphabetic order or signing the string for authentication fails!
            // TODO: Remove this requirement by pushing it closer to header generation. 
            var items = new List<ListSharesIncludeType>();
            if (IncludeMetadata) { items.Add(ListSharesIncludeType.Metadata); }
            if (IncludeSnapshots) { items.Add(ListSharesIncludeType.Snapshots); }
            return items.Count > 0 ? items : null;
        }

        /// <summary>
        /// Check if two GetSharesOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetSharesOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the GetSharesOptions.
        /// </summary>
        /// <returns>Hash code for the GetSharesOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            (Prefix?.GetHashCode() ?? 0) ^
            ((IncludeMetadata ? 0b01 : 0) +
             (IncludeSnapshots ? 0b10 : 0));

        /// <summary>
        /// Check if two GetSharesOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetSharesOptions left, GetSharesOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetSharesOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetSharesOptions left, GetSharesOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetSharesOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetSharesOptions other) =>
            Prefix == other.Prefix &&
            IncludeMetadata == other.IncludeMetadata &&
            IncludeSnapshots == other.IncludeSnapshots;
    }

    internal class GetSharesAsyncCollection : StorageAsyncCollection<ShareItem>
    {
        private readonly FileServiceClient _client;
        private readonly GetSharesOptions? _options;

        public GetSharesAsyncCollection(
            FileServiceClient client,
            GetSharesOptions? options,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            _client = client;
            _options = options;
        }

        protected override async Task<Page<ShareItem>> GetNextPageAsync(
            string continuationToken,
            int? pageSizeHint,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<SharesSegment>> task = _client.GetSharesInternal(
                continuationToken,
                _options,
                pageSizeHint,
                isAsync,
                cancellationToken);
            Response<SharesSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            return new Page<ShareItem>(
                response.Value.ShareItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
