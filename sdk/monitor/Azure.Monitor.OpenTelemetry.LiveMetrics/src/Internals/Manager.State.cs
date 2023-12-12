// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This partial class encapsulates the State.
    /// This controls if we are in either the Ping or Post state.
    /// </summary>
    internal partial class Manager
    {
        private Timer _timer;

        private Action<object> _callbackAction = obj => { };

        internal readonly State _state = new();

        private void SetPingTimer()
        {
            _state.Update(LiveMetricsState.Ping);
            _callbackAction = OnPing;
            _timer.Change(dueTime: 0, period: 5000);
        }

        private void SetPostTimer()
        {
            _state.Update(LiveMetricsState.Post);
            _callbackAction = OnPost;
            _timer.Change(dueTime: 0, period: 1000);
        }

        private void OnCallback(object state) => _callbackAction.Invoke(state);
    }
}
