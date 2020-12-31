// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication
{
    /// <summary>
    /// Represents a type that caches an access token,
    /// refreshes it when a request is made while the token is about to expire
    /// and has optional mechanism for proactively refresh the token even if when it is not actively being used.
    /// </summary>
    /// <remarks>
    /// Proactive refreshing does not retry if it fails.
    /// </remarks>
    internal sealed class ThreadSafeRefreshableAccessTokenCache : IDisposable
    {
        internal const int ProactiveRefreshIntervalInMinutes = 10;
        internal const int OnDemandRefreshIntervalInMinutes = 2;

        private readonly object _syncLock = new object();
        private bool _someThreadIsRefreshing;
        private AccessToken _currentToken;
        private bool _valueIsInitialized;

        private readonly bool _scheduleProactivelyRefreshing;
        private IScheduledAction? _scheduledProactiveRefreshing;
        private readonly TimeSpan _proactiveRefreshingInterval = TimeSpan.FromMinutes(ProactiveRefreshIntervalInMinutes);
        private readonly TimeSpan _onDemandRefreshInterval = TimeSpan.FromMinutes(OnDemandRefreshIntervalInMinutes);

        private Func<CancellationToken, ValueTask<AccessToken>> RefreshAsync { get; }
        private Func<CancellationToken, AccessToken> Refresh { get; }

        private Func<Action, TimeSpan, IScheduledAction> Schedule { get; set; }
        private Func<DateTimeOffset> UtcNow { get; set; }

        internal ThreadSafeRefreshableAccessTokenCache(
            Func<CancellationToken, AccessToken> refresher,
            Func<CancellationToken, ValueTask<AccessToken>> asyncRefresher,
            bool refreshProactively,
            Func<Action, TimeSpan, IScheduledAction>? scheduler,
            Func<DateTimeOffset>? utcNowProvider)
            : this(refresher, asyncRefresher, refreshProactively, initialValue: default!, hasInitialValue: false, scheduler, utcNowProvider)
        { }

        internal ThreadSafeRefreshableAccessTokenCache(
            Func<CancellationToken, AccessToken> refresher,
            Func<CancellationToken, ValueTask<AccessToken>> asyncRefresher,
            bool refreshProactively,
            AccessToken initialValue,
            Func<Action, TimeSpan, IScheduledAction>? scheduler,
            Func<DateTimeOffset>? utcNowProvider)
            : this(refresher, asyncRefresher, refreshProactively, initialValue, hasInitialValue: true, scheduler, utcNowProvider)
        { }

        private ThreadSafeRefreshableAccessTokenCache(
            Func<CancellationToken, AccessToken> refresher,
            Func<CancellationToken, ValueTask<AccessToken>> asyncRefresher,
            bool refreshProactively,
            AccessToken initialValue,
            bool hasInitialValue,
            Func<Action, TimeSpan, IScheduledAction>? scheduler,
            Func<DateTimeOffset>? utcNowProvider)
        {
            RefreshAsync = asyncRefresher;
            Refresh = refresher;

            _currentToken = initialValue;
            _valueIsInitialized = hasInitialValue;
            _scheduleProactivelyRefreshing = refreshProactively;

            Schedule = scheduler is null ? (Action action, TimeSpan period) => new ScheduledAction(action, period) : scheduler;
            UtcNow = utcNowProvider is null ? () => DateTimeOffset.UtcNow : utcNowProvider;

            if (refreshProactively)
            {
                TimeSpan dueTime = IsCurrentTokenInRefreshZone()
                       ? TimeSpan.Zero
                       : _currentToken.ExpiresOn - UtcNow() - _proactiveRefreshingInterval;
                _scheduledProactiveRefreshing = ScheduleProactiveRefreshing(dueTime);
            }
        }

        public AccessToken GetValue(CancellationToken cancellationToken)
            => GetValueAsync(async: false, IsCurrentTokenExpiryingSoon, cancellationToken: cancellationToken).EnsureCompleted();

        public ValueTask<AccessToken> GetValueAsync(CancellationToken cancellationToken)
            => GetValueAsync(async: true, IsCurrentTokenExpiryingSoon, cancellationToken: cancellationToken);

        private async ValueTask<AccessToken> GetValueAsync(bool async, Func<bool> shouldRefresh, CancellationToken cancellationToken)
        {
            if (!shouldRefresh())
                return _currentToken;

            // To avoid deadlocks and to support a developer passed function for renewing token that may or may not be thread safe or async, the code below ensures that it:
            // 1. Avoids locking over async operations.
            // 2. Avoids locking over functions passed by developers.

            var shouldThisThreadRefresh = false;
            lock (_syncLock)
            {
                while (shouldRefresh())
                {
                    if (_someThreadIsRefreshing)
                    {
                        if (IsCurrentTokenValid())
                            return _currentToken;

                        WaitTillInProgressThreadFinishesRefreshing();
                    }
                    else
                    {
                        shouldThisThreadRefresh = true;
                        _someThreadIsRefreshing = true;
                        break;
                    }
                }
            }

            if (shouldThisThreadRefresh)
            {
                try
                {
                    AccessToken result = async
                        ? await RefreshAsync(cancellationToken).ConfigureAwait(false)
                        : Refresh(cancellationToken);

                    if (_scheduleProactivelyRefreshing)
                    {
                        TimeSpan schedulingTime = result.ExpiresOn - (UtcNow() + _proactiveRefreshingInterval);

                        _scheduledProactiveRefreshing?.Dispose();
                        _scheduledProactiveRefreshing = ScheduleProactiveRefreshing(schedulingTime);
                    }

                    lock (_syncLock)
                    {
                        _currentToken = result;
                        _valueIsInitialized = true;
                        Thread.MemoryBarrier();
                        _someThreadIsRefreshing = false;
                        NotifyOtherThreadsThatTokenRefreshingFinished();
                    }
                }
                catch
                {
                    lock (_syncLock)
                    {
                        _someThreadIsRefreshing = false;
                        NotifyOtherThreadsThatTokenRefreshingFinished();
                    }

                    throw;
                }
            }

            return _currentToken;

            void WaitTillInProgressThreadFinishesRefreshing()
                => Monitor.Wait(_syncLock);

            void NotifyOtherThreadsThatTokenRefreshingFinished()
                => Monitor.PulseAll(_syncLock);
        }

        private IScheduledAction ScheduleProactiveRefreshing(TimeSpan schedulingTime)
            => Schedule(() => GetValueAsync(async: false, shouldRefresh: IsCurrentTokenInRefreshZone, cancellationToken: new CancellationToken()).EnsureCompleted(), schedulingTime > TimeSpan.Zero ? schedulingTime : TimeSpan.Zero);

        private bool IsCurrentTokenValid()
            => _valueIsInitialized && UtcNow() < _currentToken.ExpiresOn;

        private bool IsCurrentTokenExpiryingSoon()
            => !_valueIsInitialized || UtcNow() >= _currentToken.ExpiresOn - _onDemandRefreshInterval;

        private bool IsCurrentTokenInRefreshZone()
           => !_valueIsInitialized || UtcNow() >= _currentToken.ExpiresOn - _proactiveRefreshingInterval;

        public void Dispose()
            => _scheduledProactiveRefreshing?.Dispose();

        internal interface IScheduledAction : IDisposable { }

        private class ScheduledAction : IScheduledAction
        {
            private readonly Timer _timer;
            private readonly Action _action;

            public ScheduledAction(Action action, TimeSpan period)
            {
                _action = action;
                _timer = new Timer(OnTimerTick);

                // If tokens expiry is greater than ~49days (2^32-2 milliseconds), the proactive refreshing might not work as timers do not support timeouts more than that.
                const uint MAX_SUPPORTED_TIMEOUT = 0xfffffffe;
                var dueTime = (uint)Math.Min(period.TotalMilliseconds, MAX_SUPPORTED_TIMEOUT);
                _ = _timer.Change(dueTime, Timeout.Infinite);
            }

            public void Dispose()
                => _timer.Dispose();

            private void OnTimerTick(object _)
            {
                try
                {
                    _action();
                }
                catch { }
                finally
                {
                    _timer.Dispose();
                }
            }
        }
    }
}
