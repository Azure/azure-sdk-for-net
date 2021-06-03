// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class QueryBase<T> where T : BaseClause
    {
        /// <summary>
        ///
        /// </summary>
        public IList<T> Clauses => new List<T>();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public abstract AdtQueryBuilder Build();
    }
}
