// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class LivePipeline
    {
        /// <summary>
        ///  Deserialize LivePipeline.
        /// </summary>
        /// <param name="json">The json to be deserialized.</param>
        /// <returns>A Stream.</returns>
        public static LivePipeline Deserialize(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var element = doc.RootElement;
            return DeserializeLivePipeline(element);
        }
    }
}
