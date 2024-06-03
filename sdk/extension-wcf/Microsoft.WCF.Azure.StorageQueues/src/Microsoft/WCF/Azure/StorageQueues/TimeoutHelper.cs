// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WCF.Azure.StorageQueues
{
    internal struct TimeoutHelper
    {
        public static readonly TimeSpan MaxWait = TimeSpan.FromMilliseconds(int.MaxValue);
        private static readonly CancellationToken s_precancelledToken = new CancellationToken(true);

        private bool _cancellationTokenInitialized;
        private bool _deadlineSet;

        private CancellationToken _cancellationToken;
        private DateTime _deadline;

        public TimeoutHelper(TimeSpan timeout)
        {
            Contract.Assert(timeout >= TimeSpan.Zero, "timeout must be non-negative");
            _cancellationToken = default;
            _cancellationTokenInitialized = false;
            OriginalTimeout = timeout;
            _deadline = DateTime.MaxValue;
            _deadlineSet = (timeout == TimeSpan.MaxValue);
        }

        public CancellationToken GetCancellationToken()
        {
            return GetCancellationTokenAsync().Result;
        }

        public async Task<CancellationToken> GetCancellationTokenAsync()
        {
            if (!_cancellationTokenInitialized)
            {
                var timeout = RemainingTime();
                if (timeout >= MaxWait || timeout == Timeout.InfiniteTimeSpan)
                {
                    _cancellationToken = CancellationToken.None;
                }
                else if (timeout > TimeSpan.Zero)
                {
                    _cancellationToken = await TimeoutTokenSource.FromTimeoutAsync((int)timeout.TotalMilliseconds).ConfigureAwait(false);
                }
                else
                {
                    _cancellationToken = s_precancelledToken;
                }
                _cancellationTokenInitialized = true;
            }

            return _cancellationToken;
        }

        public TimeSpan OriginalTimeout { get; }

        public TimeSpan RemainingTime()
        {
            if (!_deadlineSet)
            {
                SetDeadline();
                return OriginalTimeout;
            }
            else if (_deadline == DateTime.MaxValue)
            {
                return TimeSpan.MaxValue;
            }
            else
            {
                TimeSpan remaining = _deadline - DateTime.UtcNow;
                if (remaining <= TimeSpan.Zero)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return remaining;
                }
            }
        }

        private void SetDeadline()
        {
            Contract.Assert(!_deadlineSet, "TimeoutHelper deadline set twice.");
            _deadline = DateTime.UtcNow + OriginalTimeout;
            _deadlineSet = true;
        }
    }

    /// <summary>
    /// This class coalesces timeout tokens because cancelation tokens with timeouts are more expensive to expose.
    /// Disposing too many such tokens will cause thread contentions in high throughput scenario.
    ///
    /// Tokens with target cancelation time 15ms apart would resolve to the same instance.
    /// </summary>
    internal static class TimeoutTokenSource
    {
        /// <summary>
        /// These are constants use to calculate timeout coalescing, for more description see method FromTimeoutAsync
        /// </summary>
        private const int CoalescingFactor = 15;
        private const int GranularityFactor = 2000;
        private const int SegmentationFactor = CoalescingFactor * GranularityFactor;

        private static readonly ConcurrentDictionary<long, Task<CancellationToken>> s_tokenCache =
            new ConcurrentDictionary<long, Task<CancellationToken>>();

        private static readonly Action<object> s_deregisterToken = (object state) =>
        {
            var args = (Tuple<long, CancellationTokenSource>)state;
            Task<CancellationToken> ignored;
            try
            {
                s_tokenCache.TryRemove(args.Item1, out ignored);
            }
            finally
            {
                args.Item2.Dispose();
            }
        };

        public static Task<CancellationToken> FromTimeoutAsync(int millisecondsTimeout)
        {
            // Note that CancellationTokenSource constructor requires input to be >= -1,
            // restricting millisecondsTimeout to be >= -1 would enforce that
            if (millisecondsTimeout < -1)
            {
                throw new ArgumentOutOfRangeException("Invalid millisecondsTimeout value " + millisecondsTimeout);
            }

            // To prevent s_tokenCache growing too large, we have to adjust the granularity of the our coalesce depending
            // on the value of millisecondsTimeout. The coalescing span scales proportionally with millisecondsTimeout which
            // would guarantee constant s_tokenCache size in the case where similar millisecondsTimeout values are accepted.
            // If the method is given a wildly different millisecondsTimeout values all the time, the dictionary would still
            // only grow logarithmically with respect to the range of the input values

            uint currentTime = (uint)Environment.TickCount;
            long targetTime = millisecondsTimeout + currentTime;

            // Formula for our coalescing span:
            // Divide millisecondsTimeout by SegmentationFactor and take the highest bit and then multiply CoalescingFactor back
            var segmentValue = millisecondsTimeout / SegmentationFactor;
            var coalescingSpanMs = CoalescingFactor;
            while (segmentValue > 0)
            {
                segmentValue >>= 1;
                coalescingSpanMs <<= 1;
            }
            targetTime = ((targetTime + (coalescingSpanMs - 1)) / coalescingSpanMs) * coalescingSpanMs;

            Task<CancellationToken> tokenTask;

            if (!s_tokenCache.TryGetValue(targetTime, out tokenTask))
            {
                var tcs = new TaskCompletionSource<CancellationToken>(TaskCreationOptions.RunContinuationsAsynchronously);

                // only a single thread may succeed adding its task into the cache
                if (s_tokenCache.TryAdd(targetTime, tcs.Task))
                {
                    // Since this thread was successful reserving a spot in the cache, it would be the only thread
                    // that construct the CancellationTokenSource
                    var tokenSource = new CancellationTokenSource((int)(targetTime - currentTime));
                    var token = tokenSource.Token;

                    // Clean up cache when Token is canceled
                    token.Register(s_deregisterToken, Tuple.Create(targetTime, tokenSource));

                    // set the result so other thread may observe the token, and return
                    tcs.TrySetResult(token);
                    tokenTask = tcs.Task;
                }
                else
                {
                    // for threads that failed when calling TryAdd, there should be one already in the cache
                    if (!s_tokenCache.TryGetValue(targetTime, out tokenTask))
                    {
                        // In unlikely scenario the token was already cancelled and timed out, we would not find it in cache.
                        // In this case we would simply create a non-coalesced token
                        tokenTask = Task.FromResult(new CancellationTokenSource(millisecondsTimeout).Token);
                    }
                }
            }
            return tokenTask;
        }
    }
}