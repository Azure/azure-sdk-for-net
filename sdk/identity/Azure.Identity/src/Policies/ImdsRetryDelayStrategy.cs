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
            // With 3 retries using exponential backoff: delays of d, 2d, 4d sum to 7d
            // Accounting for jitter (which can reduce delays by 20%), we need 7d * 0.8 >= 70
            // So we need d >= 70/5.6 = 12.5 seconds. Using 13 seconds to be safe.
            _delay410 = TimeSpan.FromSeconds(13);
        }

        protected override TimeSpan GetNextDelayCore(Response? response, int retryNumber)
        {
            // If this is a 410 response, use the extended delay to ensure 70+ seconds total
            if (response?.Status == 410)
            {
                // Use exponential backoff: 13s, 26s, 52s = 91s total (min 72.8s with jitter)
                return TimeSpan.FromMilliseconds((1 << (retryNumber - 1)) * _delay410.TotalMilliseconds);
            }

            // For all other responses, use standard exponential backoff
            return TimeSpan.FromMilliseconds((1 << (retryNumber - 1)) * _defaultDelay.TotalMilliseconds);
        }
    }
}