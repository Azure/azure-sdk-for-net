// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Azure DigitalTwins Query builder that facilitates writing queries against ADT instances.
    /// </summary>
    public class AdtQueryBuilder
    {
        private readonly SelectQuery _selectQuery;
        private readonly FromQuery _fromQuery;
        private readonly WhereStatement _whereStatement;
        private readonly WhereLogic _whereLogic;

        /// <summary>
        /// Initializes an instance of an AdtQueryBuilder object.
        /// </summary>
        public AdtQueryBuilder()
        {
            _whereLogic = new WhereLogic(this);
            _whereStatement = new WhereStatement(this, _whereLogic);
            _fromQuery = new FromQuery(this, _whereStatement);
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
        /// Specifies the list of all possible columns to return.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectAll()
        {
            return _selectQuery.SelectAll();
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
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e. the number of results to return. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTopAll(int count)
        {
            return _selectQuery.SelectTopAll(count);
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
        /// <code snippet="Snippet:DigitalTwinsQueryBuilderOverride" language="csharp">
        /// // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
        /// new AdtQueryBuilder()
        /// .SelectCustom(&quot;TOP(3) Room, Temperature&quot;)
        /// .From(AdtCollection.DigitalTwins)
        /// .Build();
        /// </code>
        /// </example>
        /// <param name="customQuery"> Query in string format. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCustom(string customQuery)
        {
            return _selectQuery.Select(customQuery);
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns> String represenation of query. </returns>
        public string GetQueryText()
        {
            var finalQuery = new StringBuilder();

            // build the select string
            finalQuery.Append(_selectQuery.GetQueryText());

            // build the from string
            finalQuery.Append(' ').Append(_fromQuery.GetQueryText());

            // build the where string
            finalQuery.Append(' ').Append(_whereStatement.GetQueryText());

            return finalQuery.ToString().Trim();
        }
    }
}
