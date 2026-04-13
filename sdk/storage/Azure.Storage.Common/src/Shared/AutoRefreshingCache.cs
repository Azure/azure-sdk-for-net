// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// A thread-safe cache for a single expiring value that supports automatic proactive
    /// background refresh.  Only one acquisition runs at a time; concurrent callers wait
    /// on the same <see cref="TaskCompletionSource{TValue}"/> rather than issuing duplicate
    /// acquire calls.
    /// <para>
    /// Modeled after <c>BearerTokenAuthenticationPolicy.AccessTokenCache</c> in Azure.Core
    /// but fully generic.
    /// </para>
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of value to cache.  Must implement <see cref="IExpiringValue"/> so the cache
    /// can determine when to expire and proactively refresh.
    /// </typeparam>
    internal sealed class AutoRefreshingCache<TValue> where TValue : struct, IExpiringValue
    {
        /// <summary>
        /// Delegate the cache calls to acquire or refresh the value.
        /// </summary>
        /// <param name="async">Whether the operation should be performed asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The newly acquired value.</returns>
        public delegate ValueTask<TValue> AcquireDelegate(bool async, CancellationToken cancellationToken);

        private readonly object _syncObj = new object();
        private readonly AcquireDelegate _acquire;
        private readonly TimeSpan _backgroundAcquireTimeout;

        /// <summary>
        /// The current cache state.  Must be updated under <see cref="_syncObj"/>.
        /// </summary>
        private CacheState _state;

        /// <summary>
        /// Creates a new <see cref="AutoRefreshingCache{TValue}"/>.
        /// </summary>
        /// <param name="acquire">
        /// Delegate that acquires a fresh <typeparamref name="TValue"/>.  Called on the first
        /// request, when the cached value expires, or when a background refresh is triggered.
        /// </param>
        /// <param name="backgroundAcquireTimeout">
        /// Maximum time allowed for a background refresh attempt before the cache falls back to
        /// the current (still-valid) value and retries later.
        /// </param>
        public AutoRefreshingCache(AcquireDelegate acquire, TimeSpan backgroundAcquireTimeout)
        {
            _acquire = acquire ?? throw new ArgumentNullException(nameof(acquire));
            _backgroundAcquireTimeout = backgroundAcquireTimeout;
        }

        /// <summary>
        /// Returns the cached value, acquiring or refreshing it as necessary.
        /// The first caller triggers acquisition; concurrent callers wait on the same result.
        /// When the value approaches expiry, a background refresh is initiated so that no
        /// caller blocks on a stale value.
        /// Note: this method may throw exceptions from the acquire delegate.
        /// </summary>
        public async ValueTask<TValue> GetAsync(bool async, CancellationToken cancellationToken)
        {
            int maxCancellationRetries = 3;

            while (true)
            {
                bool shouldAcquire = EvaluateState(out CacheState localState);
                TValue value;

                if (shouldAcquire)
                {
                    // Background acquisition
                    if (localState.BackgroundValueTcs != null)
                    {
                        // Background refresh: return the current (still valid) value and
                        // kick off the refresh in the background.
                        value = await GetCurrentValue(localState, async, waitForCompletion: false, cancellationToken).ConfigureAwait(false);
                        _ = Task.Run(() => AcquireInBackgroundAsync(localState.BackgroundValueTcs, value, async));
                        return value;
                    }

                    // Foreground acquisition: this thread is responsible for acquiring.
                    try
                    {
                        await AcquireAndSetResultAsync(localState.CurrentValueTcs, async, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        localState.CurrentValueTcs.SetCanceled();
                    }
                    catch (Exception exception)
                    {
                        localState.CurrentValueTcs.SetException(exception);
                        // The exception will be thrown on the next lines when we touch
                        // the TCS.Task result, preventing UnobservedTaskException.
                    }
                }

                try
                {
                    value = await GetCurrentValue(localState, async, waitForCompletion: true, cancellationToken).ConfigureAwait(false);
                    return value;
                }
                catch (TaskCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    maxCancellationRetries--;

                    if (!cancellationToken.CanBeCanceled && maxCancellationRetries <= 0)
                    {
                        throw;
                    }

                    // Another thread's acquisition was canceled — retry.
                    continue;
                }
            }
        }

        /// <summary>
        /// Signals that the cached value should be proactively refreshed in the background.
        /// If the current value is still valid, the next call to <see cref="GetAsync"/> will
        /// return it immediately while a background refresh is initiated.
        /// </summary>
        public void ScheduleRefresh()
        {
            lock (_syncObj)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                if (_state == null
                    || !_state.CurrentValueTcs.Task.IsCompleted
                    || _state.CurrentValueTcs.Task.Status != TaskStatus.RanToCompletion
                    || _state.BackgroundValueTcs != null
                    || _state.IsCurrentValueFailedOrExpired(now)
                    || _state.NeedsBackgroundRefresh(now))
                {
                    return;
                }

                // Push RefreshOn to now so NeedsBackgroundRefresh returns true on the
                // next EvaluateState call, which will create the BackgroundValueTcs and
                // return shouldAcquire = true in one atomic step.
                TValue current = _state.CurrentValueTcs.Task.Result;
                _state = _state.WithCurrentValueRefreshOn(current, now);
            }
        }

        /// <summary>
        /// Clears the cached value entirely.  The next call to <see cref="GetAsync"/> will
        /// trigger a fresh acquisition.
        /// </summary>
        public void Invalidate()
        {
            lock (_syncObj)
            {
                _state = null;
            }
        }

        /// <summary>
        /// Evaluates the current cache state and determines whether the caller should acquire
        /// a fresh value.  This is the core state machine, ported from
        /// <c>AccessTokenCache.RefreshTokenRequestState</c> but without context-matching logic.
        /// </summary>
        /// <returns><c>true</c> if the caller should invoke the acquire delegate.</returns>
        private bool EvaluateState(out CacheState updatedState)
        {
            // Lock-free fast path: value is valid and doesn't need refresh.
            var localState = _state;
            if (localState != null && localState.CurrentValueTcs.Task.IsCompleted)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                if (!localState.IsBackgroundValueAvailable(now) // no valid background result waiting to be promoted
                    && !localState.IsCurrentValueFailedOrExpired(now) // the current value is valid and not expiring
                    && !localState.NeedsBackgroundRefresh(now)) // not close enough to expiry to need a background refresh
                {
                    updatedState = localState;
                    return false;
                }
            }

            lock (_syncObj)
            {
                // First call or after invalidation.
                if (_state == null)
                {
                    _state = CacheState.NewState();
                    updatedState = _state;
                    return true;
                }

                // Acquisition is in progress — wait on the current TCS to finish.
                if (!_state.CurrentValueTcs.Task.IsCompleted)
                {
                    if (_state.BackgroundValueTcs != null)
                    {
                        // discards background value since current acquisition is still in-flight
                        _state = _state.WithDefaultBackgroundValueTcs();
                    }
                    updatedState = _state;
                    return false;
                }

                DateTimeOffset now = DateTimeOffset.UtcNow;

                // Background refresh completed successfully — promote to current.
                if (_state.IsBackgroundValueAvailable(now))
                {
                    _state = _state.WithBackgroundValueAsCurrent();
                }

                // Current value has failed or expired — need to re-acquire.
                if (_state.IsCurrentValueFailedOrExpired(now))
                {
                    _state = _state.WithNewCurrentValueTcs();
                    updatedState = _state;
                    return true;
                }

                // Current value is still valid but approaching expiry — background refresh.
                if (_state.NeedsBackgroundRefresh(now))
                {
                    _state = _state.WithNewBackgroundValueTcs();
                    updatedState = _state;
                    return true;
                }

                // Current value is valid.
                updatedState = _state;
                return false;
            }
        }

        /// <summary>
        /// Calls the acquire delegate and sets the result on the target TCS.
        /// </summary>
        private async ValueTask AcquireAndSetResultAsync(
            TaskCompletionSource<TValue> targetTcs,
            bool async,
            CancellationToken cancellationToken)
        {
            TValue value = async
                ? await _acquire(true, cancellationToken).ConfigureAwait(false)
                : _acquire(false, cancellationToken).EnsureCompleted();

            targetTcs.SetResult(value);
        }

        /// <summary>
        /// Runs the acquire delegate in the background with a timeout.  If it fails or times
        /// out, the background TCS is completed with the current value so callers aren't
        /// blocked — they'll retry on the next request.
        /// </summary>
        private async ValueTask AcquireInBackgroundAsync(
            TaskCompletionSource<TValue> backgroundTcs,
            TValue currentValue,
            bool async)
        {
            var cts = new CancellationTokenSource(_backgroundAcquireTimeout);
            try
            {
                await AcquireAndSetResultAsync(backgroundTcs, async, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cts.IsCancellationRequested)
            {
                // Timed out — keep the current value, retry immediately on next call.
                backgroundTcs.SetResult((TValue)currentValue.WithRefreshOn(DateTimeOffset.UtcNow));
            }
            catch (Exception)
            {
                // Acquire failed — keep the current value, throttle retries.
                backgroundTcs.SetResult((TValue)currentValue.WithRefreshOn(DateTimeOffset.UtcNow + _backgroundAcquireTimeout));
            }
            finally
            {
                cts.Dispose();
            }
        }

        /// <summary>
        /// Awaits the current value from the given state's TCS.
        /// </summary>
        private static async ValueTask<TValue> GetCurrentValue(
            CacheState state,
            bool async,
            bool waitForCompletion,
            CancellationToken cancellationToken)
        {
            if (async)
            {
                if (waitForCompletion && !state.CurrentValueTcs.Task.IsCompleted)
                {
                    await state.CurrentValueTcs.Task.AwaitWithCancellation(cancellationToken);
                }
                return await state.CurrentValueTcs.Task.ConfigureAwait(false);
            }
            else
            {
                if (waitForCompletion && !state.CurrentValueTcs.Task.IsCompleted)
                {
                    try
                    {
                        state.CurrentValueTcs.Task.Wait(cancellationToken);
                    }
                    catch (AggregateException) { } // ignore here to rethrow via EnsureCompleted
                }
#pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                return state.CurrentValueTcs.Task.EnsureCompleted();
#pragma warning restore AZC0104
            }
        }

        /// <summary>
        /// Immutable snapshot of the cache's state.  Each state transition creates a new instance.
        /// </summary>
        private sealed class CacheState
        {
            public TaskCompletionSource<TValue> CurrentValueTcs { get; }
            public TaskCompletionSource<TValue> BackgroundValueTcs { get; }

            private CacheState(
                TaskCompletionSource<TValue> currentValueTcs,
                TaskCompletionSource<TValue> backgroundValueTcs)
            {
                CurrentValueTcs = currentValueTcs;
                BackgroundValueTcs = backgroundValueTcs;
            }

            private static TaskCompletionSource<TValue> NewTcs() =>
                new TaskCompletionSource<TValue>(TaskCreationOptions.RunContinuationsAsynchronously);

            public static CacheState NewState() =>
                new CacheState(NewTcs(), default);

            public bool IsBackgroundValueAvailable(DateTimeOffset now) =>
                BackgroundValueTcs != null
                && BackgroundValueTcs.Task.Status == TaskStatus.RanToCompletion
                && BackgroundValueTcs.Task.Result.ExpiresOn > now;

            public bool IsCurrentValueFailedOrExpired(DateTimeOffset now) =>
                CurrentValueTcs.Task.Status != TaskStatus.RanToCompletion
                || now >= CurrentValueTcs.Task.Result.ExpiresOn;

            public bool NeedsBackgroundRefresh(DateTimeOffset now) =>
                now >= CurrentValueTcs.Task.Result.RefreshOn
                && BackgroundValueTcs == null;

            public CacheState WithDefaultBackgroundValueTcs() =>
                new CacheState(CurrentValueTcs, default);

            public CacheState WithBackgroundValueAsCurrent() =>
                new CacheState(BackgroundValueTcs, default);

            public CacheState WithNewCurrentValueTcs() =>
                new CacheState(NewTcs(), default);

            public CacheState WithNewBackgroundValueTcs() =>
                new CacheState(CurrentValueTcs, NewTcs());

            public CacheState WithCurrentValueRefreshOn(TValue currentValue, DateTimeOffset refreshOn)
            {
                var updatedValue = (TValue)currentValue.WithRefreshOn(refreshOn);
                var tcs = NewTcs();
                tcs.SetResult(updatedValue);
                return new CacheState(tcs, default);
            }
        }
    }
}
