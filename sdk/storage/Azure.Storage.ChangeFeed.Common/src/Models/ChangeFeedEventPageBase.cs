// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// A page of change feed events, used as the return type for paginated change feed reads.
    /// The continuation token is a serialized <see cref="ChangeFeedCursor"/>.
    /// </summary>
    internal class ChangeFeedEventPageBase<TEvent> : Page<TEvent>
    {
        /// <inheritdoc />
        public override IReadOnlyList<TEvent> Values { get; }

        /// <inheritdoc />
        public override string ContinuationToken { get; }

        /// <inheritdoc />
        public override Response GetRawResponse() => null;

        /// <summary>
        /// Parameterless constructor for mocking.
        /// </summary>
        public ChangeFeedEventPageBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeFeedEventPageBase{TEvent}"/> class.
        /// </summary>
        /// <param name="events">The events in this page.</param>
        /// <param name="continuationToken">Serialized cursor to resume reading, or null if at the end.</param>
        public ChangeFeedEventPageBase(List<TEvent> events, string continuationToken)
        {
            Values = events;
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Creates an empty page with no events and no continuation token.
        /// </summary>
        /// <returns>An empty <see cref="ChangeFeedEventPageBase{TEvent}"/>.</returns>
        public static ChangeFeedEventPageBase<TEvent> Empty()
            => new ChangeFeedEventPageBase<TEvent>(new List<TEvent>(), null);
    }
}
