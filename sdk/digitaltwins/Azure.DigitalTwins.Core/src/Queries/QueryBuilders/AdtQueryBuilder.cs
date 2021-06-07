// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    ///
    /// </summary>
    public class AdtQueryBuilder
    {
        private readonly SelectQuery _selectQuery;
        private readonly FromQuery _fromQuery;
        private readonly WhereQuery _whereQuery;

        /// <summary>
        ///
        /// </summary>
        public AdtQueryBuilder()
        {
            _whereQuery = new WhereQuery(this);
            _fromQuery = new FromQuery(this, _whereQuery);
            _selectQuery = new SelectQuery(this, _fromQuery);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public FromQuery Select(params string[] args)
        {
            return _selectQuery.Select(args);
        }

        /// <summary>
        /// Used when applying the TOP() aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e the number of instances to return. </param>
        /// <param name="args"> The arguments that can be optionally passed with top (eg property name). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTop(int count, params string[] args)
        {
            return _selectQuery.SelectTop(count, args);
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount()
        {
            return _selectQuery.SelectCount();
        }

        /// <summary>
        /// Called when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="literalQuery"> Query in string format. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectOverride(string literalQuery)
        {
            return _selectQuery.SelectOverride(literalQuery);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder finalQuery = new StringBuilder();

            // build the select string
            string selectString = _selectQuery.Stringify();
            finalQuery.Append(selectString);

            // build the from string
            string fromString = _fromQuery.Stringify();
            finalQuery.Append(fromString);

            // build the where string
            // TODO -- how to see if we need a where clause?
            string whereString = _whereQuery.Stringify();
            finalQuery.Append(whereString);

            return finalQuery.ToString().Trim();
        }
    }
}
