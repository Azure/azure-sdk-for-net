// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.ChangeFeed.Models
{
    internal class BlobChangeFeedEventPage : Page<BlobChangeFeedEvent>
    {
        public override IReadOnlyList<BlobChangeFeedEvent> Values { get; }
        public override string ContinuationToken { get; }
        public override Response GetRawResponse() => null;
        //private Response _raw;

        public BlobChangeFeedEventPage() { }

        public BlobChangeFeedEventPage(List<BlobChangeFeedEvent> events, string continuationToken)
        {
            Values = events;
            ContinuationToken = continuationToken;
        }

        public static BlobChangeFeedEventPage Empty()
            => new BlobChangeFeedEventPage(
                new List<BlobChangeFeedEvent>(),
                null);
    }
}
