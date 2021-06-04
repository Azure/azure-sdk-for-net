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
    public class FromQuery : QueryBase
    {
        private WhereQuery _innerQuery;
        private AdtQueryBuilder _parent;
        private IList<FromClause> _clauses;

        internal FromQuery(AdtQueryBuilder parent, WhereQuery selectPart)
        {
            _parent = parent;

            // TODO -- change to just a singular from clause
            _clauses = new List<FromClause>();
            _innerQuery = selectPart;
        }

        /// <summary>
        /// Adds the FROM clause and its argument to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum different collections that users can query from. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereQuery From(AdtCollection collection)
        {
            Console.WriteLine(collection);
            _clauses.Add(new FromClause(collection));
            return _innerQuery;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection"> The name of the collection. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public WhereQuery From(string collection)
        {
            Console.WriteLine(collection);
            _clauses.Add(new FromClause(collection));
            return _innerQuery;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            return _parent;
        }

        /// <inheritdoc/>
        public override string Stringify()
        {
            StringBuilder fromComponents = new StringBuilder();
            fromComponents.Append(" FROM ");

            if (_clauses[0].Collection == AdtCollection.DigitalTwins)
            {
                fromComponents.Append("DIGITALTWINS ");
            }
            else
            {
                fromComponents.Append("RELATIONSHIPS ");
            }

            return fromComponents.ToString();
        }
    }
}
