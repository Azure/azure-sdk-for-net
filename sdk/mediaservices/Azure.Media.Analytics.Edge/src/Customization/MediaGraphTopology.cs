// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    public partial class MediaGraphTopology
    {
        /// <summary>
        ///  Deserialize MediaGraphTopology.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>
        /// Deserialized Graph Topology.
        /// </returns>
        public static MediaGraphTopology Deserialize(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            return DeserializeMediaGraphTopology(element);
        }
    }
}
