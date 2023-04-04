﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable

namespace Azure.Core.Shared
{
    internal class FixedDelayWithNoJitter : Delay
    {
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(1);
        private readonly TimeSpan _delay;

        public FixedDelayWithNoJitter(TimeSpan? suggestedDelay = default) : base(suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay, 0)
        {
            _delay = suggestedDelay.HasValue ? Max(suggestedDelay.Value, DefaultDelay) : DefaultDelay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) =>
            _delay;
    }
}