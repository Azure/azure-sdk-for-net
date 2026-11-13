// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility type for connection state snapshots. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This legacy query snapshot is not supported by the current connection monitor API.")]
    public partial class ConnectionStateSnapshot
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ConnectionStateSnapshot"/>. </summary>
        internal ConnectionStateSnapshot()
        {
            Hops = new ChangeTrackingList<ConnectivityHopInfo>();
        }

        internal ConnectionStateSnapshot(NetworkConnectionState? networkConnectionState, DateTimeOffset? startOn, DateTimeOffset? endOn, EvaluationState? evaluationState, long? avgLatencyInMs, long? minLatencyInMs, long? maxLatencyInMs, long? probesSent, long? probesFailed, IReadOnlyList<ConnectivityHopInfo> hops, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NetworkConnectionState = networkConnectionState;
            StartOn = startOn;
            EndOn = endOn;
            EvaluationState = evaluationState;
            AvgLatencyInMs = avgLatencyInMs;
            MinLatencyInMs = minLatencyInMs;
            MaxLatencyInMs = maxLatencyInMs;
            ProbesSent = probesSent;
            ProbesFailed = probesFailed;
            Hops = hops;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Connection state. </summary>
        public NetworkConnectionState? NetworkConnectionState { get; }

        /// <summary> Start time. </summary>
        public DateTimeOffset? StartOn { get; }

        /// <summary> End time. </summary>
        public DateTimeOffset? EndOn { get; }

        /// <summary> Evaluation state. </summary>
        public EvaluationState? EvaluationState { get; }

        /// <summary> Average latency in milliseconds. </summary>
        public long? AvgLatencyInMs { get; }

        /// <summary> Minimum latency in milliseconds. </summary>
        public long? MinLatencyInMs { get; }

        /// <summary> Maximum latency in milliseconds. </summary>
        public long? MaxLatencyInMs { get; }

        /// <summary> Probes sent. </summary>
        public long? ProbesSent { get; }

        /// <summary> Probes failed. </summary>
        public long? ProbesFailed { get; }

        /// <summary> Connectivity hops. </summary>
        public IReadOnlyList<ConnectivityHopInfo> Hops { get; }
    }
}
