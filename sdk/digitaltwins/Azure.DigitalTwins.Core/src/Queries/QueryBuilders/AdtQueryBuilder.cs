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

        private readonly SelectAsQuery _selectAs;

        /// <summary>
        /// Initializes an instance of an AdtQueryBuilder object.
        /// </summary>
        public AdtQueryBuilder()
        {
            _whereLogic = new WhereLogic(this);
            _whereStatement = new WhereStatement(this, _whereLogic);
            _fromQuery = new FromQuery(this, _whereStatement);
            _selectAs = new SelectAsQuery(this, _fromQuery);
            _selectQuery = new SelectQuery(this, _selectAs);
        }

        /// <summary>
        /// Specifies the list of columns that the query will return
        /// </summary>
        /// <param name="args"> The arguments that can be queried (e.g., *, somePropertyName, etc.) </param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery Select(params string[] args)
        {
            return _selectQuery.Select(args);
        }

        /// <summary>
        /// Specifies the list of all possible columns to return.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectAll()
        {
            return _selectQuery.SelectAll();
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e. the number of results to return. </param>
        /// <param name="args"> The arguments that can be optionally passed with top (e.g., property name). </param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectTop(int count, params string[] args)
        {
            return _selectQuery.SelectTop(count, args);
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count"> The argument for TOP(), i.e. the number of results to return. </param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectTopAll(int count)
        {
            return _selectQuery.SelectTopAll(count);
        }

        /// <summary>
        /// Used to return the number of items that meet the query requirements.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectCount()
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
        public SelectAsQuery SelectCustom(string customQuery)
        {
            return _selectQuery.SelectCustom(customQuery);
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="literal"></param>
        /// <param name="alias"></param>
        /// <returns></returns>
        public SelectAsQuery SelectAs(string literal, string alias)
        {
            return _selectAs.SelectAs(literal, alias);
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns> String represenation of query. </returns>
        public string GetQueryText()
        {
            var finalQuery = new StringBuilder();
            finalQuery.Append(QueryConstants.Select).Append(' ');   // TODO move query keywords into here rather than seperate classes

            // build the select string
            string selectStatementQueryText = _selectQuery.GetQueryText();
            string selectStatementAliasedQueryText = _selectAs.GetQueryText();

            bool nonAliasedSelectStatements = selectStatementQueryText.Length > 0;
            bool aliasedSelectStatements = selectStatementAliasedQueryText.Length > 0;

            // begin with any non-aliased select components
            finalQuery.Append(selectStatementQueryText);

            // add aliased select components
            if (nonAliasedSelectStatements && aliasedSelectStatements)
            {
                finalQuery.Append($", ");
            }

            finalQuery.Append(selectStatementAliasedQueryText);

            // build the from string
            finalQuery.Append(' ').Append(_fromQuery.GetQueryText());

            // build the where string
            finalQuery.Append(' ').Append(_whereStatement.GetQueryText());

            return finalQuery.ToString().Trim();
        }
    }
}
