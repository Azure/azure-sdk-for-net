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
        /// Specifies the list of columns that the query will return.
        /// </summary>
        /// <param name="args">The arguments that can be queried (e.g., *, somePropertyName, etc.)</param>
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
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <param name="args">The arguments that can be optionally passed with top (e.g., property name).</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectTop(int count, params string[] args)
        {
            return _selectQuery.SelectTop(count, args);
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
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
        /// <param name="customQuery">Query in string format.</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectAsQuery SelectCustom(string customQuery)
        {
            return _selectQuery.SelectCustom(customQuery);
        }

        /// <summary>
        /// Used to alias selectable properties in place of the AS keyword.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the ADT Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns> Query that contains an aliased select clause. </returns>
        public SelectAsQuery SelectAs(string field, string alias)
        {
            return _selectAs.SelectAs(field, alias);
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns> String represenation of query. </returns>
        public string GetQueryText()
        {
            var finalQuery = new StringBuilder();
            finalQuery.Append(QueryConstants.Select).Append(' ');

            // build the select string
            string selectStatementQueryText = _selectQuery.GetQueryText();
            string selectStatementAliasedQueryText = _selectAs.GetQueryText();

            bool nonAliasedSelectStatements = selectStatementQueryText.Length > 0;
            bool aliasedSelectStatements = selectStatementAliasedQueryText.Length > 0;

            // add aliased select components
            if (nonAliasedSelectStatements)
            {
                // begin with any non-aliased select components
                finalQuery.Append(selectStatementQueryText);

                if (aliasedSelectStatements)
                {
                    finalQuery.Append($", ");
                }
            }

            finalQuery.Append(selectStatementAliasedQueryText);

            // build the from string
            finalQuery.Append(' ').Append(QueryConstants.From).Append(' ');
            finalQuery.Append(_fromQuery.GetQueryText());

            // build the where string
            string whereGetQueryText = _whereStatement.GetQueryText();

            if (!string.IsNullOrWhiteSpace(whereGetQueryText))
            {
                finalQuery.Append(' ').Append(QueryConstants.Where).Append(' ');
                finalQuery.Append(_whereStatement.GetQueryText());
            }

            return finalQuery.ToString().Trim();
        }
    }
}
