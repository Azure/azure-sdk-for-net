// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenType("PathHierarchyTokenizerV2")]
    public partial class PathHierarchyTokenizer
    {
        /// <summary> The delimiter character to use. Default is "/". </summary>
        [CodeGenMember("Delimiter")]
        public char? Delimiter { get; set; }

        /// <summary> The delimiter character to use. Default is "/". </summary>
        [CodeGenMember("Replacement")]
        public char? Replacement { get; set; }
    }
}
