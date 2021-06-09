// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Clause objects make up an entire query. Each kind of clause takes in a different set of arguments
    /// and are implemented as children of a general clause class.
    /// </summary>
    internal abstract class ClauseBase
    {
        /// <summary>
        /// The type of the given clause.
        /// </summary>
        public ClauseType Type { get; set; }
    }
}
