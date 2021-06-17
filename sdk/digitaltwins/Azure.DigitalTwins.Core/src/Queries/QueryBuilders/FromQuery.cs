// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query object that already contains a select clause.
    /// </summary>
    public sealed class FromQuery : QueryBase
    {
        private readonly WhereQuery _upstreamWhereQuery;
        private readonly AdtQueryBuilder _parent;
        private IntermediateWhere _upsteamIntermediateWhereQuery;
        private FromClause _clause;

        internal FromQuery(AdtQueryBuilder parent, WhereQuery upstreamWhereQuery)
        {
            _parent = parent;
            _upstreamWhereQuery = upstreamWhereQuery;
        }

        internal FromQuery(AdtQueryBuilder parent, IntermediateWhere upstreamIntermediateWhere, string fixme)
        {
            Console.WriteLine(fixme);
            _parent = parent;
            _upsteamIntermediateWhereQuery = upstreamIntermediateWhere;
        }

        /// <summary>
        /// Adds the FROM clause and its argument to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum different collections that users can query from. </param>
        /// <param name="fix"></param>
        /// <returns> ADT query with select and from clause. </returns>
        public IntermediateWhere From(AdtCollection collection, string fix)
        {
            Console.WriteLine(fix);
            _clause = new FromClause(collection);
            return _upsteamIntermediateWhereQuery;
        }

        /// <summary>
        /// Adds the FROM clause and its argument to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum different collections that users can query from. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereQuery From(AdtCollection collection)
        {
            _clause = new FromClause(collection);
            return _upstreamWhereQuery;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection"> The name of the collection. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereQuery From(string collection)
        {
            _clause = new FromClause(collection);
            return _upstreamWhereQuery;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            return _parent;
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            var fromComponents = new StringBuilder();
            fromComponents.Append(QueryConstants.From)
                .Append(' ')
                .Append(_clause.Collection);

            return fromComponents.ToString();
        }
    }
}
