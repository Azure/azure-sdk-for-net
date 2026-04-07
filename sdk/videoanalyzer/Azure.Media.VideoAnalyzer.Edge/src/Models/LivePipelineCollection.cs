// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    /// <summary>
    /// Extensions methods to LivePipelineCollection to add serialization and deserialization.
    /// </summary>
    public partial class LivePipelineCollection
    {
        /// <summary>
        ///  Deserialize LivePipelineCollection.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A LivePipeline Collection.</returns>
        public static LivePipelineCollection Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeLivePipelineCollection(element);
        }
    }
}
