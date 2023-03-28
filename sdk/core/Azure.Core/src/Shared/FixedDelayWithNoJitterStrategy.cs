// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable

namespace Azure.Core.Shared
{
    internal class FixedDelayWithNoJitterStrategy : DelayStrategy
    {
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(1);
        private readonly TimeSpan _delay;

        public FixedDelayWithNoJitterStrategy(TimeSpan? suggestedDelay = default) : base(suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay, 0)
        {
            _delay = suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            _delay;

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber, IDictionary<string, object?> context) =>
            new(_delay);
    }
}