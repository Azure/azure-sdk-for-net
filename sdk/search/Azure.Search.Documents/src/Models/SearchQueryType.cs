// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Specifies the syntax of the search query.  The default is "simple".
    /// Use "full" if your query uses the Lucene query syntax.
    /// </summary>
    [CodeGenSchema("QueryType")]
    public enum SearchQueryType
    {
        /// <summary>
        /// Use the simple query syntax.
        /// </summary>
        Simple,

        /// <summary>
        /// Use the full Lucene query syntax.
        /// </summary>
        Full
    }
}
