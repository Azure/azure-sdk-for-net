// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.ChangeFeed.Common
{
    /// <summary>
    /// Represents a change feed event with a timestamp, used for event-level time filtering.
    /// </summary>
    internal interface IChangeFeedEvent
    {
        /// <summary>
        /// The UTC timestamp when the event occurred.
        /// </summary>
        DateTimeOffset EventTime { get; }
    }
}
