// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    /// Extensions methods to MediaGraphTopologyCollection to add serialization and deserialization
    /// </summary>
    public partial class MediaGraphTopologyCollection
    {
        /// <summary>
        ///  Serialize MediaGraphTopologyCollection.
        /// </summary>
        /// <returns>
        /// Serialized Graph Topology Collection.
        /// </returns>
        public string Serialize()
        {
            return SerializeMediaGraphTopologyCollectionInternal(this);
        }

        internal static string SerializeMediaGraphTopologyCollectionInternal(IUtf8JsonSerializable serializable)
        {
            using var memoryStream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(memoryStream))
            {
                serializable.Write(writer);
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        /// <summary>
        ///  Deserialize MediaGraphTopology.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// Deserialized Graph Topologogy Collection.
        /// </returns>
        public static MediaGraphTopologyCollection Deserialize(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            return DeserializeMediaGraphTopologyCollection(element);
        }
    }
}
