// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a delay strategy with 0 interval.
    /// This is normally used for testing, like record playback.
    /// </summary>
    internal class ZeroPollingStrategy : DelayStrategy
    {
        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) => TimeSpan.Zero;
    }
}
