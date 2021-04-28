﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.VideoAnalyzer.Edge.Models
{
    public partial class PipelineTopologyCollection
    {
        /// <summary>
        ///  Deserialize PipelineTopology.
        /// </summary>
        /// <param name="json">The json data that is to be deserialized.</param>
        /// <returns>A Json string representation of a list of PipelineTopology.</returns>
        public static PipelineTopologyCollection Deserialize(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement element = doc.RootElement;
            return DeserializePipelineTopologyCollection(element);
        }
    }
}
