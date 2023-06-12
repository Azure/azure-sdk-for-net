// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.ResourceGraph.Tests
{
    public class Column
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public ColumnDataType Type { get; set; }
    }
}
