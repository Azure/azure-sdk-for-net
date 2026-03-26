// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed
{
    /// <summary>
    /// Represents a page of BlobChangeFeedEvent results with a continuation token.
    /// </summary>
    internal class BlobChangeFeedEventPage : Page<BlobChangeFeedEvent>
    {
        /// <inheritdoc/>
        public override IReadOnlyList<BlobChangeFeedEvent> Values { get; }
        /// <inheritdoc/>
        public override string ContinuationToken { get; }
        public override Response GetRawResponse() => null;
        //private Response _raw;

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        public BlobChangeFeedEventPage() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobChangeFeedEventPage"/> class
        /// with the specified events and continuation token.
        /// </summary>
        public BlobChangeFeedEventPage(List<BlobChangeFeedEvent> events, string continuationToken)
        {
            Values = events;
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Creates an empty <see cref="BlobChangeFeedEventPage"/> with no events
        /// and a null continuation token.
        /// </summary>
        public static BlobChangeFeedEventPage Empty()
            => new BlobChangeFeedEventPage(
                new List<BlobChangeFeedEvent>(),
                null);
    }
}
