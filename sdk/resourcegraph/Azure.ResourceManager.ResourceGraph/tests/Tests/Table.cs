// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.ResourceGraph.Tests
{
    public class Table
    {
        [JsonPropertyName("columns")]
        public IList<Column> Columns { get; set; }
        [JsonPropertyName("rows")]
        public IList<IList<object>> Rows { get;  set; }
    }
}
