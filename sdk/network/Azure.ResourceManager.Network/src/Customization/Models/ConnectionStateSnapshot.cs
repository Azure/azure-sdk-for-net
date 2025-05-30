// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Connection state snapshot. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConnectionStateSnapshot
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ConnectionStateSnapshot"/>. </summary>
        internal ConnectionStateSnapshot()
        {
            Hops = new ChangeTrackingList<ConnectivityHopInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="ConnectionStateSnapshot"/>. </summary>
        /// <param name="networkConnectionState"> The connection state. </param>
        /// <param name="startOn"> The start time of the connection snapshot. </param>
        /// <param name="endOn"> The end time of the connection snapshot. </param>
        /// <param name="evaluationState"> Connectivity analysis evaluation state. </param>
        /// <param name="avgLatencyInMs"> Average latency in ms. </param>
        /// <param name="minLatencyInMs"> Minimum latency in ms. </param>
        /// <param name="maxLatencyInMs"> Maximum latency in ms. </param>
        /// <param name="probesSent"> The number of sent probes. </param>
        /// <param name="probesFailed"> The number of failed probes. </param>
        /// <param name="hops"> List of hops between the source and the destination. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
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

        /// <summary> The connection state. </summary>
        public NetworkConnectionState? NetworkConnectionState { get; }
        /// <summary> The start time of the connection snapshot. </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary> The end time of the connection snapshot. </summary>
        public DateTimeOffset? EndOn { get; }
        /// <summary> Connectivity analysis evaluation state. </summary>
        public EvaluationState? EvaluationState { get; }
        /// <summary> Average latency in ms. </summary>
        public long? AvgLatencyInMs { get; }
        /// <summary> Minimum latency in ms. </summary>
        public long? MinLatencyInMs { get; }
        /// <summary> Maximum latency in ms. </summary>
        public long? MaxLatencyInMs { get; }
        /// <summary> The number of sent probes. </summary>
        public long? ProbesSent { get; }
        /// <summary> The number of failed probes. </summary>
        public long? ProbesFailed { get; }
        /// <summary> List of hops between the source and the destination. </summary>
        public IReadOnlyList<ConnectivityHopInfo> Hops { get; }
    }
}
