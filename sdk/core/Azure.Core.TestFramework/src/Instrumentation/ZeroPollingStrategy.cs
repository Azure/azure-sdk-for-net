// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Implementation of a <see cref="DelayStrategy"/> with 0 interval.
    /// This is normally used for testing, like record playback.
    /// </summary>
    internal class ZeroPollingStrategy : DelayStrategy
    {
        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) => TimeSpan.Zero;

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber,
            IDictionary<string, object?> context) => new(TimeSpan.Zero);
    }
}
