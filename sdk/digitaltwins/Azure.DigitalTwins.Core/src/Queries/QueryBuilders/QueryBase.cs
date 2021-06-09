// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    /// Parent class for all query clauses.
    /// </summary>
    public abstract class QueryBase
    {
        /// <summary>
        /// Finalizes query.
        /// </summary>
        /// <returns> Parent querybuilder class. </returns>
        public abstract AdtQueryBuilder Build();

        /// <summary>
        /// Represents a query clause in string format.
        /// </summary>
        /// <returns> Query in string format. </returns>
        public abstract string Stringify();
    }
}
