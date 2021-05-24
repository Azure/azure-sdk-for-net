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
    [CodeGenModel("QueryType")]
    public enum SearchQueryType
    {
        /// <summary>
        /// Uses the simple query syntax for searches.
        /// <para>Search text is interpreted using a simple query language that allows for symbols such as +, * and \"\".
        /// Queries are evaluated across all searchable fields by default, unless the searchFields parameter is specified.</para>
        /// </summary>
        Simple,

        /// <summary>
        /// Uses the full Lucene query syntax for searches.
        /// <para>Search text is interpreted using the Lucene query language which allows field-specific and weighted searches, as well as other advanced features.</para>
        /// </summary>
        Full,
    }
}
