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
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A Json string representation of a MediaGraphTopology.</returns>
        public static MediaGraphTopology Deserialize(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement element = doc.RootElement;
            return DeserializeMediaGraphTopology(element);
        }
    }
}
