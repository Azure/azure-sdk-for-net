// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options to customize a Search operation's behavior.
    /// </summary>
    [CodeGenSuppress(nameof(SearchRequestOptions), typeof(string), typeof(string))]
    public class SearchRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the SearchRequestOptions class.
        /// </summary>
        public SearchRequestOptions() { }
    }
}
