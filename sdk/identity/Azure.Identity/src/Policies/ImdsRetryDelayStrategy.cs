// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// A delay strategy for IMDS retry operations that ensures 410 responses are retried
    /// for at least 70 seconds total duration as required by Azure IMDS documentation.
    /// </summary>
    internal class ImdsRetryDelayStrategy : DelayStrategy
    {
        private readonly TimeSpan _defaultDelay;
        private readonly TimeSpan _delay410;

        public ImdsRetryDelayStrategy(TimeSpan? defaultDelay = null, TimeSpan? maxDelay = null)
            : base(maxDelay)
        {
            _defaultDelay = defaultDelay ?? TimeSpan.FromSeconds(0.8);

            // For 410 responses, we need at least 70 seconds total retry duration
            // With 5 retries using exponential backoff: delays of d, 2d, 4d, 8d, 16d sum to 31d
            // Accounting for jitter (which can reduce delays by 20%), we need 31d * 0.8 >= 70
            // So we need d >= 70/24.8 = 2.82 seconds. Using 3 seconds to be safe.
            _delay410 = TimeSpan.FromSeconds(3);
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber)
        {
            // If this is a 410 response, use the extended delay to ensure 70+ seconds total
            if (response?.Status == 410)
            {
                // Use exponential backoff: 3s, 6s, 12s, 24s, 48s = 93s total (min 74.4s with jitter)
                return TimeSpan.FromMilliseconds((1 << (retryNumber - 1)) * _delay410.TotalMilliseconds);
            }

            // For all other responses, use standard exponential backoff
            return TimeSpan.FromMilliseconds((1 << (retryNumber - 1)) * _defaultDelay.TotalMilliseconds);
        }
    }
}