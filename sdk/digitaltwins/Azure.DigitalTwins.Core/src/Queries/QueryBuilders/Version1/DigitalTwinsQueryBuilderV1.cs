// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Azure DigitalTwins Query builder that facilitates writing queries against Digital Twins instances.
    /// </summary>
    public class DigitalTwinsQueryBuilderV1
    {
        private readonly List<SelectClause> _selectClauses;
        private readonly List<string> _selectAsClauses;
        private readonly string _alias;

        private FromClause _fromClause;
        private WhereQuery _whereQuery;

        private string _queryText;

        /// <summary>
        /// Create a Digital Twins query without automatically specifying or aliasing a query-able collection.
        /// </summary>
        public DigitalTwinsQueryBuilderV1()
        {
            _selectClauses = new List<SelectClause>();
            _selectAsClauses = new List<string>();
            _whereQuery = new WhereQuery();
        }

        /// <summary>
        /// Create a Digital Twins query and automatically specify a query-able collection and (optionally) specify a collection alias.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <param name="alias">Alias for query-able collection.</param>
        public DigitalTwinsQueryBuilderV1(DigitalTwinsCollection collection, string alias = null)
        {
            _selectClauses = new List<SelectClause>();
            _selectAsClauses = new List<string>();
            _alias = alias;
            _fromClause = new FromClause(collection);
            _whereQuery = new WhereQuery();
        }

        /// <summary>
        /// Specifies the list of columns that the query will return.
        /// </summary>
        /// <param name="args">The arguments that can be queried (e.g., *, somePropertyName, etc.)</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 Select(params string[] args)
        {
            _selectClauses.Add(new SelectClause(args));
            return this;
        }

        /// <summary>
        /// Specifies the list of all possible columns to return.
        /// </summary>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectAll()
        {
            _selectClauses.Add(new SelectClause(new string[] { "*" }));
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well as well as specific properties to select.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of instances to return.</param>
        /// <param name="args">The arguments that can be optionally passed with top (e.g., property name).</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectTop(int count, params string[] args)
        {
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            // append optional arguments separated by commas
            topArg.Append(string.Join(", ", args));
            _selectClauses.Add(new SelectClause(new string[] { topArg.ToString() }));

            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the Digital Twins query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectTopAll(int count)
        {
            // turn into correct format -- e.g. SELECT TOP(3)
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})");
            _selectClauses.Add(new SelectClause(new string[] { topArg.ToString() }));

            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-count">COUNT()</see> aggregate from the Digital Twins query language.
        /// </summary>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectCount()
        {
            string countArg = $"{QueryConstants.Count}()";

            _selectClauses.Add(new SelectClause(new string[] { countArg }));
            return this;
        }

        /// <summary>
        /// Used when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="customQuery">Query in string format.</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectCustom(string customQuery)
        {
            Argument.AssertNotNullOrWhiteSpace(customQuery, nameof(customQuery));

            _selectClauses.Add(new SelectClause(new string[] { customQuery }));
            return this;
        }

        /// <summary>
        /// Used to select properties with the desired alias.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the Digital Twins Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 SelectAs(string field, string alias)
        {
            Argument.AssertNotNullOrWhiteSpace(field, nameof(field));
            Argument.AssertNotNullOrWhiteSpace(alias, nameof(alias));

            _selectAsClauses.Add($"{field} {QueryConstants.As} {alias}");
            return this;
        }

        /// <summary>
        /// Adds the FROM clause, its argument, and an alias for its argument into the query.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <param name="alias">Collection alias (optional).</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 From(DigitalTwinsCollection collection, string alias = default)
        {
            _fromClause = new FromClause(collection, alias);
            return this;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 FromCustom(string collection)
        {
            Argument.AssertNotNullOrWhiteSpace(collection, nameof(collection));

            _fromClause = new FromClause(collection);
            return this;
        }

        /// <summary>
        /// Adds a WHERE clause to the query.
        /// </summary>
        /// <param name="whereLogic">Delegate that contains methods from the <see cref="WhereQuery"/> class.</param>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 Where(Func<WhereQuery, WhereQuery> whereLogic)
        {
            whereLogic.Invoke(_whereQuery);
            return this;
        }

        /// <summary>
        /// Constructs the string representation of the current state of the query builder.
        /// </summary>
        /// <returns>The <see cref="DigitalTwinsQueryBuilderV1"/> object itself.</returns>
        public DigitalTwinsQueryBuilderV1 Build()
        {
            var queryString = new StringBuilder();

            // Add alias to query string
            bool aliasedCollection = _alias != null;
            bool nonAliasedSelectStatements = _selectClauses.Any();

            if (aliasedCollection && !nonAliasedSelectStatements)
            {
                // if no select statement, build select all by default
                _selectClauses.Add(new SelectClause(new string[] { _alias }));
                nonAliasedSelectStatements = !nonAliasedSelectStatements;
            }

            // Determine basic layout of select clause for spacing and comma purposes
            bool aliasedSelectStatements = _selectAsClauses.Any();
            bool nestedQuery = !(aliasedSelectStatements || nonAliasedSelectStatements);

            // Add select clauses
            if (!nestedQuery)
            {
                queryString.Append(QueryConstants.Select).Append(' ');
            }

            foreach (SelectClause clause in _selectClauses)
            {
                string selectClauseString;
                if (clause?.ClauseArgs == null)
                {
                    selectClauseString = string.Empty;
                }
                else
                {
                    selectClauseString = string.Join(", ", clause?.ClauseArgs);
                }

                queryString.Append(selectClauseString);
            }

            if (aliasedSelectStatements)
            {
                if (nonAliasedSelectStatements)
                {
                    queryString.Append(", ");
                }

                queryString.Append(string.Join(", ", _selectAsClauses));
            }

            // add from clause
            if (!nestedQuery)
            {
                queryString.Append(' ').Append(QueryConstants.From).Append(' ');
                queryString.Append(_fromClause?.Collection).Append(' ');
            }

            if (aliasedCollection)
            {
                queryString.Append(_alias).Append(' ');
            }

            if (_whereQuery != null)
            {
                string whereClauseText = _whereQuery.GetQueryText();

                if (!string.IsNullOrEmpty(whereClauseText))
                {
                    queryString.Append(QueryConstants.Where).Append(' ');
                }

                queryString.Append(whereClauseText);
            }

            _queryText = queryString.ToString().Trim();
            return this;
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns>String representation of the current state of the query builder.</returns>
        public string GetQueryText()
        {
            if (string.IsNullOrEmpty(_queryText))
            {
                Build();
            }

            return _queryText;
        }
    }
}
