// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class FixedDelay : Delay
    {
        private readonly TimeSpan _delay;

        public FixedDelay(TimeSpan delay) : base(TimeSpan.FromMilliseconds(delay.TotalMilliseconds))
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber) => _delay;
    }
}