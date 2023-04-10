// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="DelayStrategyInternal"/> with 0 interval.
    /// This is normally used for testing, like record playback.
    /// </summary>
    internal class ZeroPollingStrategy : DelayStrategyInternal
    {
        public override TimeSpan GetNextDelay(Response response, TimeSpan? suggestedInterval) => TimeSpan.Zero;
    }
}
