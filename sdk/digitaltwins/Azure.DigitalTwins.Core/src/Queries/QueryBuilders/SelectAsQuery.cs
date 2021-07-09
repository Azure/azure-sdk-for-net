// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// TODO.
    /// </summary>
    public sealed class SelectAsQuery : QueryBase
    {
        private FromQuery _fromQuery;
        private AdtQueryBuilder _parent;
        private List<string> _clauses;

        internal SelectAsQuery(AdtQueryBuilder parent, FromQuery fromQuery)
        {
            _fromQuery = fromQuery;
            _parent = parent;
            _clauses = new List<string>();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="literal"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public SelectAsQuery SelectAs(string literal, string alias)
        {
            _clauses.Add($"{literal} {QueryConstants.As} {alias}");
            return this;
        }

        /// <summary>
        /// Adds the FROM clause and its argument to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum different collections that users can query from. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereStatement From(AdtCollection collection)
        {
            return _fromQuery.From(collection);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public WhereStatement From(AdtCollection collection, string alias)
        {
            return _fromQuery.From(collection, alias);
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection"> The name of the collection. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereStatement FromCustom(string collection)
        {
            return _fromQuery.FromCustom(collection);
        }

        // rest of From methods implemented in similar manner

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            // Build can only be called on queries that have (at minimum) SELECT and FROM clauses
            throw new InvalidOperationException("Invalid query: Missing a FROM clause.");
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            if (_clauses.Count == 0)
            {
                return string.Empty;
            }

            string aliasedComponents = string.Join(", ", _clauses);
            return aliasedComponents;
        }
    }
}
