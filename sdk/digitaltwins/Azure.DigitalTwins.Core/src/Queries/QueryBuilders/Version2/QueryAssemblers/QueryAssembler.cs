// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    internal class QueryAssembler
    {
        private SelectClause _clause;
        private readonly FromClauseAssembler _fromQuery;
        private readonly WhereClauseAssembler _whereStatement;
        private readonly WhereClauseAssemblerLogic _whereLogic;
        private readonly SelectClauseAssembler _selectAs;

        /// <summary>
        /// Initializes an instance of an AdtQueryBuilder object.
        /// </summary>
        public QueryAssembler()
        {
            _whereLogic = new WhereClauseAssemblerLogic(this);
            _whereStatement = new WhereClauseAssembler(this, _whereLogic);
            _fromQuery = new FromClauseAssembler(this, _whereStatement);
            _selectAs = new SelectClauseAssembler(this, _fromQuery);
        }

        /// <summary>
        /// Specifies the list of columns that the query will return.
        /// </summary>
        /// <param name="args">The arguments that can be queried (e.g., *, somePropertyName, etc.)</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler Select(params string[] args)
        {
            _clause = new SelectClause(args);
            return _selectAs;
        }

        /// <summary>
        /// Specifies the list of all possible columns to return.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler SelectAll()
        {
            _clause = new SelectClause(new string[] { "*" });
            return _selectAs;
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <param name="args">The arguments that can be optionally passed with top (e.g., property name).</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler SelectTop(int count, params string[] args)
        {
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            // append optional arguments separated by commas
            topArg.Append(string.Join(", ", args));

            _clause = new SelectClause(new string[] { topArg.ToString() });
            return _selectAs;
        }

        /// <summary>
        /// Used to return only a certain number of top items that meet the query requirements.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler SelectTopAll(int count)
        {
            // turn into correct format -- eg. SELECT TOP(3)
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            _clause = new SelectClause(new string[] { topArg.ToString() });
            return _selectAs;
        }

        /// <summary>
        /// Used to return the number of items that meet the query requirements.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler SelectCount()
        {
            string countArg = $"{QueryConstants.Count}() ";

            _clause = new SelectClause(new string[] { countArg });
            return _selectAs;
        }

        /// <summary>
        /// Used to provide the entire SELECT clause as opposed to providing individual field (column) names.
        /// </summary>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsQueryBuilderOverride" language="csharp">
        /// // SELECT TOP(3) Room, Temperature FROM DIGITALTWINS
        /// new DigitalTwinsQueryBuilder()
        /// .SelectCustom(&quot;TOP(3) Room, Temperature&quot;)
        /// .Build();
        /// </code>
        /// </example>
        /// <param name="customQuery">Query in string format.</param>
        /// <returns> Query that contains a select clause. </returns>
        public SelectClauseAssembler SelectCustom(string customQuery)
        {
            _clause = new SelectClause(new string[] { customQuery });
            return _selectAs;
        }

        /// <summary>
        /// Used to alias selectable properties in place of the AS keyword.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the ADT Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns> Query that contains an aliased select clause. </returns>
        public SelectClauseAssembler SelectAs(string field, string alias)
        {
            return _selectAs.SelectAs(field, alias);
        }

        internal string GetSelectText()
        {
            if (_clause?.ClauseArgs == null)
            {
                return string.Empty;
            }

            var selectComponents = new StringBuilder();
            selectComponents.Append(string.Join(", ", _clause.ClauseArgs));

            return selectComponents.ToString().Trim();
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
            string selectStatementQueryText = GetSelectText();
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
