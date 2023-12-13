// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates the State.
    /// This controls if we are in either the Ping or Post state.
    /// </summary>
    internal partial class Manager
    {
        private Action _callbackAction = () => { };

        internal readonly State _state = new();

        internal TimeSpan _period;
        private readonly TimeSpan _pingPeriod = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _postPeriod = TimeSpan.FromSeconds(1);
        // TODO: WILL NEED ADDITIONAL PERIODS DEFINED FOR BACKOFF.

        private void InitializeState()
        {
            SetPingState();
            Task.Run(() => Run(CancellationToken.None)); // TODO: USE AN ACTUAL CANCELLATION TOKEN
        }

        private void SetPingState()
        {
            _state.Update(LiveMetricsState.Ping);
            _callbackAction = OnPing;
            _period = _pingPeriod;
        }

        private void SetPostState()
        {
            _state.Update(LiveMetricsState.Post);
            _callbackAction = OnPost;
            _period = _postPeriod;
        }

        [SuppressMessage("Usage", "AZC0102: Do not use GetAwaiter().GetResult().", Justification = "The EnsureCompleted() extension method is a wrapper around GetAwaiter().GetResult() without adding value. Worse, it breaks during Debug making it impossible to test Live Metrics.")]
        private void Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var callbackStarted = DateTime.UtcNow;

                _callbackAction.Invoke();

                // Subtract the time spent in this tick when scheduling the next tick so that the average period is close to the intended.
                var timeSpentInThisTick = DateTime.UtcNow - callbackStarted;
                var nextTick = _period - timeSpentInThisTick;
                nextTick = nextTick > TimeSpan.Zero ? nextTick : TimeSpan.Zero;

                Task.Delay(nextTick, cancellationToken).GetAwaiter().GetResult();
            }
        }
    }
}
