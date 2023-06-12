// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Maps.Search
{
    /// <summary> Initializes a new instance of SearchAddressQuery. </summary>
    public partial class SearchAddressQuery
    {
        /// <summary> The query string user wants to search. </summary>
        public string Query { get; }

        /// <summary> Search address options </summary>
        public SearchAddressOptions SearchAddressOptions { get; }

        /// <summary> Initializes a new instance of SearchAddressQuery. </summary>
        /// <param name="query"> The query string user wants to search. </param>
        /// <param name="options"> Search address options. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        public SearchAddressQuery(string query, SearchAddressOptions options = null)
        {
            Argument.AssertNotNull(query, nameof(query));
            this.Query = query;
            this.SearchAddressOptions = options;
        }
    }
}
