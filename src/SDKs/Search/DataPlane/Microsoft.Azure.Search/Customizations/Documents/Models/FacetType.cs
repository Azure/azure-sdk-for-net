// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Specifies the type of a facet query result.
    /// </summary>
    public enum FacetType
    {
        /// <summary>
        /// The facet counts documents with a particular field value.
        /// </summary>
        Value = 0,

        /// <summary>
        /// The facet counts documents with a field value in a particular range.
        /// </summary>
        Range
    }
}
