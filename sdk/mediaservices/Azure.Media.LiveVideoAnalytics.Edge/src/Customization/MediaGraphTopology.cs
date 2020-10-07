// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class MediaGraphTopology
    {
        /// <summary>
        ///  Serialize MediaGraphTopology.
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return SerializeMediaGraphTopologyInternal(this);
        }

        internal static string SerializeMediaGraphTopologyInternal(IUtf8JsonSerializable serializable)
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
        /// <returns></returns>
        public static MediaGraphTopology Deserialize(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            return DeserializeMediaGraphTopology(element);
        }
    }
}
