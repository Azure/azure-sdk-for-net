// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary>
    /// Extensions methods to PipelineTopologyCollection to add serialization and deserialization.
    /// </summary>
    public partial class PipelineTopologyCollection
    {
        /// <summary>
        ///  Deserialize PipelineTopologyCollection.
        /// </summary>
        /// <param name="json">The json data that is to be deserialized.</param>
        /// <returns>A Json string representation of a list of pipeline topologies.</returns>
        public static PipelineTopologyCollection Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializePipelineTopologyCollection(element);
        }
    }
}
