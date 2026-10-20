// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.Network.Models
{
    public partial class PeerRouteList : IJsonModel<PeerRouteList>
    {
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual PeerRouteList PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePeerRouteList(document.RootElement, options);
        }

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<PeerRouteList>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        BinaryData IPersistableModel<PeerRouteList>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
        PeerRouteList IPersistableModel<PeerRouteList>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
        string IPersistableModel<PeerRouteList>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<PeerRouteList>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            // The compatibility model retains the released single-route wire contract, independently of Value.
            var route = new PeerRoute(LocalAddress, Network, NextHop, SourcePeer, Origin, AsPath, Weight, _additionalBinaryDataProperties);
            using JsonDocument document = JsonDocument.Parse(((IPersistableModel<PeerRoute>)route).Write(options));
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }

        PeerRouteList IJsonModel<PeerRouteList>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual PeerRouteList JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ValidateFormat(options);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePeerRouteList(document.RootElement, options);
        }

        internal static PeerRouteList DeserializePeerRouteList(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            PeerRoute route = PeerRoute.DeserializePeerRoute(element, options);
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            if (options.Format != "W")
            {
                foreach (JsonProperty property in element.EnumerateObject())
                {
                    switch (property.Name)
                    {
                        case "localAddress":
                        case "network":
                        case "nextHop":
                        case "sourcePeer":
                        case "origin":
                        case "asPath":
                        case "weight":
                            break;
                        default:
                            additionalBinaryDataProperties.Add(property.Name, property.Value.GetUtf8Bytes());
                            break;
                    }
                }
            }
            return new PeerRouteList(route.LocalAddress, route.Network, route.NextHop, route.SourcePeer, route.Origin, route.AsPath, route.Weight, additionalBinaryDataProperties);
        }

        private void ValidateFormat(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<PeerRouteList>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PeerRouteList)} does not support '{format}' format.");
            }
        }
    }
}
