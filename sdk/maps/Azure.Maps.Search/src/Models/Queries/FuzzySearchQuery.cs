// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>{
    public partial class FuzzySearchQuery
    {
        /// <summary> The query string user wants to search. </summary>
        public string Query { get; }

        /// <summary> Fuzzy search options </summary>
        public FuzzySearchOptions FuzzySearchOptions { get; }

        /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>
        /// <param name="query"> The query string user wants to search. </param>
        /// <param name="options"> Fuzzy search options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        public FuzzySearchQuery(string query, FuzzySearchOptions options = null)
        {
            Argument.AssertNotNull(query, nameof(query));
            this.Query = query;
            this.FuzzySearchOptions = options;
        }
    }
}
