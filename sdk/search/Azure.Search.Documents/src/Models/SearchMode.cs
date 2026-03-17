// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Specifies whether any or all of the search terms must be matched in order to count the document as a match.
    /// </summary>
    public enum SearchMode
    {
        /// <summary>
        /// Any search terms may match.
        /// </summary>
        Any,

        /// <summary>
        /// All search terms must match.
        /// </summary>
        All,
    }
}
