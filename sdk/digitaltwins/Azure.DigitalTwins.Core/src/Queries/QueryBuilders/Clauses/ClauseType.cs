// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Types of clauses that can be added to a query.
    /// </summary>
    public enum ClauseType
    {
        /// <summary>
        /// Select clause.
        /// </summary>
        SELECT = 0,

        /// <summary>
        /// From clause.
        /// </summary>
        FROM = 1,

        /// <summary>
        /// Where clause.
        /// </summary>
        WHERE = 2

        // TODO -- JOIN
    }
}
