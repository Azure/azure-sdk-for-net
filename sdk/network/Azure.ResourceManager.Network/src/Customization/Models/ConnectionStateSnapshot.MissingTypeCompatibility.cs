// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

#pragma warning disable SA1402 // Compatibility shims for multiple removed GA types are grouped intentionally.
namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility type for connection state snapshots. </summary>
    public partial class ConnectionStateSnapshot : IJsonModel<ConnectionStateSnapshot>, IPersistableModel<ConnectionStateSnapshot>
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionStateSnapshot"/>. </summary>
        public ConnectionStateSnapshot()
        {
            Hops = Array.Empty<ConnectivityHopInfo>();
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

        ConnectionStateSnapshot IJsonModel<ConnectionStateSnapshot>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ConnectionStateSnapshot();
        void IJsonModel<ConnectionStateSnapshot>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        ConnectionStateSnapshot IPersistableModel<ConnectionStateSnapshot>.Create(BinaryData data, ModelReaderWriterOptions options) => new ConnectionStateSnapshot();
        string IPersistableModel<ConnectionStateSnapshot>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ConnectionStateSnapshot>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }
}
