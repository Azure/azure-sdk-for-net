// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Specifies options for listing queues with the 
    /// <see cref="QueueServiceClient.GetQueuesAsync"/> operation.
    /// </summary>
    public struct GetQueuesOptions : IEquatable<GetQueuesOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// queues whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of queues to return. If the
        /// request does not specify <see cref="MaxResults"/>, or specifies a
        /// value greater than 5000, the server will return up to 5000 items.
        /// 
        /// Note that if the listing operation crosses a partition boundary,
        /// then the service will return a <see cref="Page{T}.ContinuationToken"/>
        /// for retrieving the remainder of the results.  For this reason, it
        /// is possible that the service will return fewer results than
        /// specified by <see cref="PageSizeHint"/>, or than the default of
        /// 5000. 
        /// 
        /// If the parameter is set to a value less than or equal to zero, 
        /// a <see cref="StorageRequestFailedException"/> will be thrown.
        /// </summary>
        public int? PageSizeHint { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the queue's metadata should
        /// be included.
        /// </summary>
        public bool IncludeMetadata { get; set; }

        /// <summary>
        /// Convert the details into a <see cref="ListQueuesIncludeType"/> value.
        /// </summary>
        /// <returns>A <see cref="ListQueuesIncludeType"/> value.</returns>
        internal IEnumerable<ListQueuesIncludeType> AsIncludeTypes() =>
            this.IncludeMetadata ?
                new ListQueuesIncludeType[] { ListQueuesIncludeType.Metadata } :
                Array.Empty<ListQueuesIncludeType>();

        /// <summary>
        /// Check if two GetQueuesOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetQueuesOptions other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the <see cref="GetQueuesOptions"/>.
        /// </summary>
        /// <returns>Hash code for the <see cref="GetQueuesOptions"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            this.IncludeMetadata.GetHashCode() ^
            (this.Prefix?.GetHashCode() ?? 0) ^
            this.PageSizeHint.GetHashCode();

        /// <summary>
        /// Check if two <see cref="GetQueuesOptions"/> instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetQueuesOptions left, GetQueuesOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two <see cref="GetQueuesOptions"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetQueuesOptions left, GetQueuesOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two <see cref="GetQueuesOptions"/> instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetQueuesOptions other) =>
            this.IncludeMetadata == other.IncludeMetadata &&
            this.Prefix == other.Prefix &&
            this.PageSizeHint == other.PageSizeHint;
    }

    internal class GetQueuesAsyncCollection : StorageAsyncCollection<QueueItem>
    {
        private readonly QueueServiceClient _client;
        private readonly GetQueuesOptions? _options;

        public GetQueuesAsyncCollection(
            QueueServiceClient client,
            GetQueuesOptions? options,
            CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            this._client = client;
            this._options = options;
            this.PageSizeHint = options?.PageSizeHint;
        }

        protected override async Task<Page<QueueItem>> GetNextPageAsync(
            string continuationToken,
            bool isAsync,
            CancellationToken cancellationToken = default)
        {
            var task = this._client.GetQueuesAsync(
                continuationToken,
                this._options,
                this.PageSizeHint,
                isAsync,
                cancellationToken);
            var response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();

            return new Page<QueueItem>(
                response.Value.QueueItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
