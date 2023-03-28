// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    ///
    /// </summary>
    internal class FixedDelay : Delay
    {
        private readonly TimeSpan _delay;

        /// <summary>
        ///
        /// </summary>
        /// <param name="delay"></param>
        public  FixedDelay(TimeSpan delay) : base(TimeSpan.FromMilliseconds(delay.TotalMilliseconds))
        {
            _delay = delay;
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber, IDictionary<string, object?> context) => _delay;

        protected override ValueTask<TimeSpan> GetNextDelayCoreAsync(Response? response, int retryNumber, IDictionary<string, object?> context) => new(_delay);
    }
}