// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary> Specifies whether any or all of the search terms must be matched in order to count the document as a match. </summary>
    [CodeGenType("SearchMode")]
    public enum SearchMode
    {
        /// <summary> Any of the search terms must be matched in order to count the document as a match. </summary>
        Any,
        /// <summary> All of the search terms must be matched in order to count the document as a match. </summary>
        All
    }
}
