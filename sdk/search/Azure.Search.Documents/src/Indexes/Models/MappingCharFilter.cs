// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class MappingCharFilter
    {
        /// <summary> A list of mappings of the following format: &quot;a=&gt;b&quot; (all occurrences of the character &quot;a&quot; will be replaced with character &quot;b&quot;). </summary>
        public IList<string> Mappings { get; }
    }
}
