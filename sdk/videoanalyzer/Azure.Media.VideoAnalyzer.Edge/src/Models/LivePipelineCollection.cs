// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class LivePipelineCollection
    {
        /// <summary>
        ///  Deserialize LivePipelineCollection.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns> Json string representation of a Live Pipeline Collection. </returns>
        public static LivePipelineCollection Deserialize(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement element = doc.RootElement;
            return DeserializeLivePipelineCollection(element);
        }
    }
}
