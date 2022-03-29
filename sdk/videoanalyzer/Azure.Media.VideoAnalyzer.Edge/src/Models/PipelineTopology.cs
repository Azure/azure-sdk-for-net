// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class PipelineTopology
    {
        /// <summary>
        ///  Deserialize PipelineTopology.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A Json string representation of a PipelineTopology.</returns>
        public static PipelineTopology Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializePipelineTopology(element);
        }
    }
}
