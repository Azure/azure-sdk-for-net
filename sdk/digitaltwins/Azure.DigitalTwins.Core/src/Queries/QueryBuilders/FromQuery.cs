﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query object that already contains a select clause.
    /// </summary>
    public sealed class FromQuery : QueryBase
    {
        private readonly WhereStatement _upsteamWhereStatement;
        private readonly AdtQueryBuilder _parent;
        private FromClause _clause;

        internal FromQuery(AdtQueryBuilder parent, WhereStatement upsteamWhereStatement)
        {
            _parent = parent;
            _upsteamWhereStatement = upsteamWhereStatement;
        }

        /// <summary>
        /// Adds the FROM clause and its argument to the query via the Clauses component.
        /// </summary>
        /// <param name="collection">An enum different collections that users can query from.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public WhereStatement From(AdtCollection collection)
        {
            _clause = new FromClause(collection);
            return _upsteamWhereStatement;
        }

        /// <summary>
        /// Adds the FROM clause, its argument, and an alias for its argument into the query.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <param name="alias">The alias being assigned to the collection being queried from.</param>
        /// <returns> ADT query with select from clauses. </returns>
        public WhereStatement From(AdtCollection collection, string alias)
        {
            _clause = new FromClause(collection, alias);
            return _upsteamWhereStatement;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The name of the collection.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public WhereStatement FromCustom(string collection)
        {
            _clause = new FromClause(collection);
            return _upsteamWhereStatement;
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
            fromComponents.Append(_clause.Collection);

            return fromComponents.ToString();
        }
    }
}
