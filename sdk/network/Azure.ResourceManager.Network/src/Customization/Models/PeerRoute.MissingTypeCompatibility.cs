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
    /// <summary> Compatibility type for peer routes. </summary>
    public partial class PeerRoute : IJsonModel<PeerRoute>, IPersistableModel<PeerRoute>
    {
        /// <summary> Initializes a new instance of <see cref="PeerRoute"/>. </summary>
        public PeerRoute()
        {
        }

        /// <summary> The peer route network. </summary>
        [Azure.ResourceManager.Network.WirePath("network")]
        public string Network { get; }

        /// <summary> The next hop. </summary>
        [Azure.ResourceManager.Network.WirePath("nextHop")]
        public string NextHop { get; }

        /// <summary> The source peer. </summary>
        [Azure.ResourceManager.Network.WirePath("sourcePeer")]
        public string SourcePeer { get; }

        /// <summary> The origin. </summary>
        [Azure.ResourceManager.Network.WirePath("origin")]
        public string Origin { get; }

        /// <summary> The AS path. </summary>
        [Azure.ResourceManager.Network.WirePath("asPath")]
        public string AsPath { get; }

        /// <summary> The local address. </summary>
        [Azure.ResourceManager.Network.WirePath("localAddress")]
        public string LocalAddress { get; }

        /// <summary> The route weight. </summary>
        [Azure.ResourceManager.Network.WirePath("weight")]
        public int? Weight { get; }

        PeerRoute IJsonModel<PeerRoute>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new PeerRoute();
        void IJsonModel<PeerRoute>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
        PeerRoute IPersistableModel<PeerRoute>.Create(BinaryData data, ModelReaderWriterOptions options) => new PeerRoute();
        string IPersistableModel<PeerRoute>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
        BinaryData IPersistableModel<PeerRoute>.Write(ModelReaderWriterOptions options) => BinaryData.FromString("{}");

        /// <summary> Writes the model as JSON. </summary>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { writer.WriteStartObject(); writer.WriteEndObject(); }
    }
}
