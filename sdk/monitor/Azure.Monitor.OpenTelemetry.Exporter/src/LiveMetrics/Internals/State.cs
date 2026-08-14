// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal enum LiveMetricsState
    {
        Disabled = 0,
        Ping,
        Post,
        Backoff,
    }

    internal class State
    {
        private LiveMetricsState _state = LiveMetricsState.Disabled;

        public void Update(LiveMetricsState state) => _state = state;

        public bool IsEnabled() => _state == LiveMetricsState.Post;
    }
}
