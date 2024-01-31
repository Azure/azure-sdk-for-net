// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// A delay strategy that uses a fixed delay with no jitter applied. This is used by data plane LROs.
    /// </summary>
    internal class FixedDelayWithNoJitterStrategy : DelayStrategy
    {
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(1);
        private readonly TimeSpan _delay;

        public FixedDelayWithNoJitterStrategy(TimeSpan? suggestedDelay = default) : base(suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay, 0)
        {
            _delay = suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) =>
            _delay;
    }
}
