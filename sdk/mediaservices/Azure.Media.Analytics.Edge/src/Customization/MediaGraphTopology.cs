// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.Analytics.Edge.Models
{
    /// <summary>
    ///  Deserialize MediaGraphTopology.
    /// </summary>
    public partial class MediaGraphTopology
    {
        /// <summary>
        ///  Deserialize MediaGraphTopology.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A MediaGraphTopology.</returns>
        public static MediaGraphTopology Deserialize(string json)
        {
            JsonElement element = JsonDocument.Parse(json).RootElement;
            return DeserializeMediaGraphTopology(element);
        }
    }
}
