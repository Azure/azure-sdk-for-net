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

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility type for connection monitor query results. </summary>
    public partial class ConnectionMonitorQueryResult : IJsonModel<ConnectionMonitorQueryResult>, IPersistableModel<ConnectionMonitorQueryResult>
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorQueryResult"/>. </summary>
        public ConnectionMonitorQueryResult()
        {
            States = Array.Empty<ConnectionStateSnapshot>();
        }

        /// <summary> Source status. </summary>
        public ConnectionMonitorSourceStatus? SourceStatus { get; }

        /// <summary> Connection state snapshots. </summary>
        public IReadOnlyList<ConnectionStateSnapshot> States { get; }

        ConnectionMonitorQueryResult IJsonModel<ConnectionMonitorQueryResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new ConnectionMonitorQueryResult();
        void IJsonModel<ConnectionMonitorQueryResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        ConnectionMonitorQueryResult IPersistableModel<ConnectionMonitorQueryResult>.Create(BinaryData data, ModelReaderWriterOptions options) => new ConnectionMonitorQueryResult();
        string IPersistableModel<ConnectionMonitorQueryResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<ConnectionMonitorQueryResult>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }
}
