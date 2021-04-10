// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// Implements a "manual" version of an exponential back off retry policy
    /// that allows us to block before sending the next request instead of
    /// immediately after we get a response.
    /// </summary>
    internal class ManualRetryDelay
    {
        /// <summary>
        /// The initial delay we use for calculating back off.
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(0.8);

        /// <summary>
        /// The maximum delay between attempts.
        /// </summary>
        public TimeSpan MaxDelay { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Randomize with jitter.
        /// </summary>
        private readonly Random _jitter = new Random();

        /// <summary>
        /// The number of recent attempts that have been throttled.
        /// </summary>
        private int _throttledAttempts;

        /// <summary>
        /// When we should wait until before sending our next request.
        /// </summary>
        private DateTimeOffset? _waitUntil;

        /// <summary>
        /// Update whether the last request was throttled.
        /// </summary>
        /// <param name="throttled">
        /// Whether the last request was throttled.
        /// </param>
        public void Update(bool throttled)
        {
            if (throttled)
            {
                _throttledAttempts++;

                // Use the same logic from Azure.Core's RetryPolicy
                TimeSpan delay = TimeSpan.FromMilliseconds(
                    Math.Min(
                        (1 << (_throttledAttempts - 1)) * _jitter.Next((int)(Delay.TotalMilliseconds * 0.8), (int)(Delay.TotalMilliseconds * 1.2)),
                        MaxDelay.TotalMilliseconds));

                // Instead of blocking now, let's figure out how long we should
                // block until and we can do that before the next request if it
                // comes in too soon.
                _waitUntil = DateTimeOffset.Now.Add(delay);
            }
            else
            {
                _throttledAttempts = 0;
                _waitUntil = null;
            }
        }

        /// <summary>
        /// Wait until our retry delay has elapsed, if needed.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that will delay if needed.</returns>
        public async Task WaitIfNeededAsync(CancellationToken cancellationToken = default)
        {
            TimeSpan? wait = _waitUntil - DateTimeOffset.Now;
            if (wait >= TimeSpan.Zero)
            {
                await Task.Delay(wait.Value, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
