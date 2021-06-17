// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.DigitalTwins.Core.QueryBuilder;

namespace Azure.DigitalTwins.Core.Queries.QueryBuilders
{
    /// <summary>
    /// Azure DigitalTwins Query builder that facilitates writing queries against ADT instances.
    /// </summary>
    public class AdtQueryBuilder
    {
        private readonly SelectQuery _selectQuery;
        private readonly FromQuery _fromQuery;
        private readonly WhereQuery _whereQuery;

        /// <summary>
        /// Initializes an instance of an AdtQueryBuilder object.
        /// </summary>
        public AdtQueryBuilder()
        {
            _whereQuery = new WhereQuery(this);
            _fromQuery = new FromQuery(this, _whereQuery);
            _selectQuery = new SelectQuery(this, _fromQuery);
        }

        /// <summary>
        /// Specifies the list of columns that the query will return
        /// </summary>
        /// <param name="args"> The arguments that can be queried (e.g., *, somePropertyName, etc.) </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery Select(params string[] args)
        {
            return _selectQuery.Select(args);
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e. the number of results to return. </param>
        /// <param name="args"> The arguments that can be optionally passed with top (e.g., property name). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTop(int count, params string[] args)
        {
            return _selectQuery.SelectTop(count, args);
        }

        /// <summary>
        /// Used to return the number of items that meet the query requirements.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount()
        {
            return _selectQuery.SelectCount();
        }

        /// <summary>
        /// Used to provide the entire SELECT clause as opposed to providing individual field (column) names.
        /// </summary>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsQueryByilderOverride" language="csharp">
        /// // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
        /// new AdtQueryBuilder()
        /// .SelectOverride("TOP(3) Room, Temperature")
        /// .From(AdtCollection.DigitalTwins)
        /// .Build()
        /// </code>
        /// </example>
        /// <param name="literalQuery"> Query in string format. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectOverride(string literalQuery)
        {
            return _selectQuery.Select(literalQuery);
        }

        /// <summary>
        /// Turns AdtQueryBuilder into a string.
        /// </summary>
        /// <returns> String represenation of query. </returns>
        public string Stringify()
        {
            StringBuilder finalQuery = new StringBuilder();

            // build the select string
            finalQuery.Append(_selectQuery.GetQueryText());

            // build the from string
            finalQuery.Append(' ').Append(_fromQuery.GetQueryText());

            // build the where string
            finalQuery.Append(' ').Append(_whereQuery.GetQueryText());

            return finalQuery.ToString().Trim();
        }
    }
}
