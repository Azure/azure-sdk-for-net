// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates the State Machine.
    /// This controls if we are in either the Ping or Post state.
    /// </summary>
    /// <remarks>
    /// RULES FOR BACKOFF:
    /// POST: We expect to Post once every second, but no longer than once every 20 seconds.
    /// If we exceed the 20 seconds, we consider this a failure and Stop Posting.
    /// We will wait 60 seconds before Pinging again.
    /// PING: We expect to Ping once every 5 seconds, but no longer than once every 60 seconds.
    /// If we exceed the 60 seconds, we will wait 60 seconds before Pinging again.
    /// </remarks>
    internal partial class Manager
    {
        private Action _callbackAction = () => { };

        private readonly State _state = new();

        private TimeSpan _period;
        private bool _shouldCollect = false;
        private Func<bool> _evaluateBackoff = () => false;

        private readonly TimeSpan _pingPeriod = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _postPeriod = TimeSpan.FromSeconds(1);
        private readonly TimeSpan _backoffPeriod = TimeSpan.FromMinutes(1);

        private readonly TimeSpan _maximumPingInterval = TimeSpan.FromSeconds(60);
        private readonly TimeSpan _maximumPostInterval = TimeSpan.FromSeconds(20);

        internal bool ShouldCollect() => _shouldCollect;

        private void InitializeState()
        {
            SetPingState();
            Task.Run(() => Run(CancellationToken.None)); // TODO: USE AN ACTUAL CANCELLATION TOKEN
            // TODO: Investigate use of a dedicated thread here.
        }

        private void SetPingState()
        {
            _state.Update(LiveMetricsState.Ping);
            _shouldCollect = false;
            _callbackAction = OnPing;
            _period = _pingPeriod;
            _evaluateBackoff = () => _pingHasRun && DateTimeOffset.UtcNow - _lastSuccessfulPing > _maximumPingInterval;
        }

        private void SetPostState()
        {
            _state.Update(LiveMetricsState.Post);
            _shouldCollect = true;
            _callbackAction = OnPost;
            _period = _postPeriod;
            _evaluateBackoff = () => _postHasRun && DateTimeOffset.UtcNow - _lastSuccessfulPost > _maximumPostInterval;
        }

        private void SetBackoffState()
        {
            _state.Update(LiveMetricsState.Backoff);
            _shouldCollect = false;
            _callbackAction = BackoffConcluded;
            _period = _backoffPeriod;
            _evaluateBackoff = () => false;

            _pingHasRun = _postHasRun = false;
        }

        private void BackoffConcluded()
        {
            // when the backoff period is complete, we switch to Ping.
            SetPingState();
        }

        private void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var callbackStarted = DateTimeOffset.UtcNow;

                _callbackAction.Invoke();

                // Subtract the time spent in this tick when scheduling the next tick so that the average period is close to the intended.
                var timeSpentInThisTick = DateTimeOffset.UtcNow - callbackStarted;

                TimeSpan nextTick;

                // Check if we need to backoff.
                if (_evaluateBackoff.Invoke())
                {
                    Debug.WriteLine($"{DateTime.Now}: Backing off.");
                    SetBackoffState();
                    nextTick = _period;
                }
                else
                {
                    nextTick = _period - timeSpentInThisTick;
                    nextTick = nextTick > TimeSpan.Zero ? nextTick : TimeSpan.Zero;
                }

                Task.Delay(nextTick, cancellationToken).Wait();
            }
        }
    }
}
