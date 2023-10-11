// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Router Job Worker Selector. </summary>
    public partial class AcsRouterWorkerSelector
    {
        internal float? TtlSeconds { get; }

        /// <summary> Router Job Worker Selector TTL. </summary>
        public TimeSpan? TimeToLive => TtlSeconds.HasValue ? TimeSpan.FromSeconds(TtlSeconds.Value) : null;
    }
}