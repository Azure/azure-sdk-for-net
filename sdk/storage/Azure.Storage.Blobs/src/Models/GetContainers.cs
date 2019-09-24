// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing containers with the
    /// <see cref="BlobServiceClient.GetContainersAsync"/> operation.
    /// </summary>
    public struct GetContainersOptions : IEquatable<GetContainersOptions>
    {
        /// <summary>
        /// Gets or sets a string that filters the results to return only
        /// containers whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets a flag specifing that the container's metadata should
        /// be included.
        /// </summary>
        public bool IncludeMetadata { get; set; }

        /// <summary>
        /// Convert the details into a ListContainersIncludeType value.
        /// </summary>
        /// <returns>A ListContainersIncludeType value.</returns>
        internal ListContainersIncludeType? AsIncludeType()
            => IncludeMetadata ?
                ListContainersIncludeType.Metadata :
                (ListContainersIncludeType?)null;

        /// <summary>
        /// Check if two GetContainersOptions instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) =>
            obj is GetContainersOptions other && Equals(other);

        /// <summary>
        /// Get a hash code for the GetContainersOptions.
        /// </summary>
        /// <returns>Hash code for the GetContainersOptions.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            IncludeMetadata.GetHashCode() ^
            Prefix.GetHashCode();

        /// <summary>
        /// Check if two GetContainersOptions instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(GetContainersOptions left, GetContainersOptions right) =>
            left.Equals(right);

        /// <summary>
        /// Check if two GetContainersOptions instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(GetContainersOptions left, GetContainersOptions right) =>
            !(left == right);

        /// <summary>
        /// Check if two GetContainersOptions instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(GetContainersOptions other) =>
            IncludeMetadata == other.IncludeMetadata &&
            Prefix == other.Prefix;
    }

    internal class GetContainersAsyncCollection : StorageCollectionEnumerator<ContainerItem>
    {
        private readonly BlobServiceClient _client;
        private readonly GetContainersOptions? _options;

        public GetContainersAsyncCollection(
            BlobServiceClient client,
            GetContainersOptions? options)
        {
            _client = client;
            _options = options;
        }

        public override async ValueTask<Page<ContainerItem>> GetNextPageAsync(
            string continuationToken,
            int? pageHintSize,
            bool isAsync,
            CancellationToken cancellationToken)
        {
            Task<Response<ContainersSegment>> task = _client.GetContainersInternal(
                continuationToken,
                _options,
                pageHintSize,
                isAsync,
                cancellationToken);
            Response<ContainersSegment> response = isAsync ?
                await task.ConfigureAwait(false) :
                task.EnsureCompleted();
            return new Page<ContainerItem>(
                response.Value.ContainerItems.ToArray(),
                response.Value.NextMarker,
                response.GetRawResponse());
        }
    }
}
