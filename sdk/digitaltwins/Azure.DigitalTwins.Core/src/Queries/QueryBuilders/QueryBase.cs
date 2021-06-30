// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Parent class for all query clauses.
    /// </summary>
    public abstract class QueryBase
    {
        /// <summary>
        /// Used to construct final query.
        /// </summary>
        /// <returns> Parent querybuilder class. </returns>
        public abstract AdtQueryBuilder Build();

        /// <summary>
        /// Represents a query clause in string format.
        /// </summary>
        /// <returns> Query in string format. </returns>
        public abstract string GetQueryText();
    }
}
