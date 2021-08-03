// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query object that already contains a select clause.
    /// </summary>
    internal sealed class FromClauseAssembler
    {
        private readonly WhereClauseAssembler _upsteamWhereStatement;
        private readonly QueryAssembler _parent;
        private FromClause _clause;

        internal FromClauseAssembler(QueryAssembler parent, WhereClauseAssembler upsteamWhereStatement)
        {
            _parent = parent;
            _upsteamWhereStatement = upsteamWhereStatement;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The name of the collection.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public WhereClauseAssembler FromCustom(string collection)
        {
            _clause = new FromClause(collection);
            return _upsteamWhereStatement;
        }

        public string GetQueryText()
        {
            var fromComponents = new StringBuilder();
            fromComponents.Append(_clause.Collection);

            return fromComponents.ToString();
        }
    }
}
