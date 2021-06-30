// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query object without any clauses.
    /// </summary>
    public sealed class SelectQuery : QueryBase
    {
        private readonly FromQuery _upstreamFromQuery;
        private readonly AdtQueryBuilder _parent;
        private SelectClause _clause;

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        internal SelectQuery(AdtQueryBuilder parent, FromQuery upstreamFromQuery)
        {
            _parent = parent;
            _upstreamFromQuery = upstreamFromQuery;
        }

        /// <summary>
        /// Used to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="args"> The arguments that define what we select (e.g., *). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery Select(params string[] args)
        {
            _clause = new SelectClause(args);
            return _upstreamFromQuery;
        }

        /// <summary>
        /// Used to add a select clause and the all (*) argument to a query.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectAll()
        {
            _clause = new SelectClause(new string[]{ "*" });
            return _upstreamFromQuery;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well as well as specific properties to select.
        /// </summary>
        /// <param name="count"> The argument for TOP(), ie the number of instances to return. </param>
        /// <param name="args"> The arguments that can be optionally passed with top (e.g., property name). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTop(int count, params string[] args)
        {
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            // append optional arguments separated by commas
            topArg.Append(string.Join(", ", args));

            _clause = new SelectClause(new string[] { topArg.ToString() });
            return _upstreamFromQuery;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e. the number of results to return. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTopAll(int count)
        {
            // turn into correct format -- eg. SELECT TOP(3)
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            _clause = new SelectClause(new string[] { topArg.ToString() });
            return _upstreamFromQuery;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-count">COUNT()</see> aggregate from the ADT query language.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount()
        {
            string countArg = $"{QueryConstants.Count}() ";

            _clause = new SelectClause(new string[] { countArg });
            return _upstreamFromQuery;
        }

        /// <summary>
        /// Used when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="literalQuery"> Query in string format. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery Select(string literalQuery)
        {
            _clause = new SelectClause(new string[] { literalQuery });
            return _upstreamFromQuery;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            // Build can only be called on queries that have (at minimum) SELECT and FROM clauses
            throw new InvalidOperationException("Invalid query: Missing a FROM clause.");
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            var selectComponents = new StringBuilder();
            selectComponents.Append(QueryConstants.Select).Append(' ');
            selectComponents.Append(string.Join(", ", _clause.ClauseArgs));

            return selectComponents.ToString().Trim();
        }
    }
}
