// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Models
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
        Range,

        /// <summary>
        /// The facet sums all documents with a field value.
        /// </summary>
        Sum,

        /// <summary>
        /// The facet averages all documents with a field value.
        /// </summary>
        Average,

        /// <summary>
        /// The facet finds the minimum field value from the documents.
        /// </summary>
        Minimum,

        /// <summary>
        /// The facet finds the maximum field value from the documents.
        /// </summary>
        Maximum,

        /// <summary>
        /// The facet calculates the cardinality of a field value from the documents.
        /// </summary>
        Cardinality
    }
}
