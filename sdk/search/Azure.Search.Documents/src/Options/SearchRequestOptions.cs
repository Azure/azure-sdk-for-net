// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Options to customize a Search operation's behavior.
    /// </summary>
    public class SearchRequestOptions
    {
        /// <summary>
        /// An optional caller-defined value that identifies the given request.
        /// If specified, this will be included in response information as a
        /// way to map the request.
        /// </summary>
        public Guid? ClientRequestId { get; set; }

        /// <summary>
        /// Initializes a new instance of the SearchRequestOptions class.
        /// </summary>
        public SearchRequestOptions() { }
    }
}
