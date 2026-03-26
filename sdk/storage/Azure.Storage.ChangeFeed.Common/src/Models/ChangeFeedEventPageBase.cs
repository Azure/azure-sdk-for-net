// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    internal class ChangeFeedEventPageBase<TEvent> : Page<TEvent>
    {
        public override IReadOnlyList<TEvent> Values { get; }
        public override string ContinuationToken { get; }
        public override Response GetRawResponse() => null;

        public ChangeFeedEventPageBase() { }

        public ChangeFeedEventPageBase(List<TEvent> events, string continuationToken)
        {
            Values = events;
            ContinuationToken = continuationToken;
        }

        public static ChangeFeedEventPageBase<TEvent> Empty()
            => new ChangeFeedEventPageBase<TEvent>(new List<TEvent>(), null);
    }
}
