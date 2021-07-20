// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class DigitalTwinsQueryBuilder
    {
        // TODO -- do we need SelectClause? Can we just use a string??
        private List<SelectClause> _selectClauses;  // rename to regularSelectClauses or someth
        private List<string> _selectAsClauses;
        private string _alias;

        private FromClause _fromClause;
        private List<WhereClause> _whereClauses;
        // private string queryString;

        /// <summary>
        /// TODO.
        /// </summary>
        public DigitalTwinsQueryBuilder()
        {
            _selectClauses = new List<SelectClause>();
            _selectAsClauses = new List<string>();
            //_fromClauses = new FromClause();
            _whereClauses = new List<WhereClause>();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="collection"></param>
        public DigitalTwinsQueryBuilder(string alias, AdtCollection collection)
        {
            _selectClauses = new List<SelectClause>();
            _selectAsClauses = new List<string>();
            _alias = alias;
            _fromClause = new FromClause(collection);
            _whereClauses = new List<WhereClause>();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder Select(params string[] args)
        {
            _selectClauses.Add(new SelectClause(args));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder SelectAll()
        {
            _selectClauses.Add(new SelectClause(new string[] { "*" }));
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well as well as specific properties to select.
        /// </summary>
        /// <param name="count">The argument for TOP(), ie the number of instances to return.</param>
        /// <param name="args">The arguments that can be optionally passed with top (e.g., property name).</param>
        /// <returns> Query that contains a select clause. </returns>
        public DigitalTwinsQueryBuilder SelectTop(int count, params string[] args)
        {
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            // append optional arguments separated by commas
            topArg.Append(string.Join(", ", args));
            _selectClauses.Add(new SelectClause(new string[] { topArg.ToString() }));

            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <returns> Query that contains a select clause. </returns>
        public DigitalTwinsQueryBuilder SelectTopAll(int count)
        {
            // turn into correct format -- eg. SELECT TOP(3)
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})");
            _selectClauses.Add(new SelectClause(new string[] { topArg.ToString() }));

            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-count">COUNT()</see> aggregate from the ADT query language.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public DigitalTwinsQueryBuilder SelectCount()
        {
            string countArg = $"{QueryConstants.Count}()";

            _selectClauses.Add(new SelectClause(new string[] { countArg }));
            return this;
        }

        /// <summary>
        /// Used when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="customQuery">Query in string format.</param>
        /// <returns> Query that contains a select clause. </returns>
        public DigitalTwinsQueryBuilder SelectCustom(string customQuery)
        {
            _selectClauses.Add(new SelectClause(new string[] { customQuery }));
            return this;
        }

        /// <summary>
        /// Used to select properties with the desired alias.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the ADT Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns> Query that contains an aliased select clause. </returns>
        public DigitalTwinsQueryBuilder SelectAs(string field, string alias)
        {
            _selectAsClauses.Add($"{field} {QueryConstants.As} {alias}");
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder From(AdtCollection collection)
        {
            _fromClause = new FromClause(collection);
            return this;
        }

        /// <summary>
        /// Adds the FROM clause, its argument, and an alias for its argument into the query.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <param name="alias">The alias being assigned to the collection being queried from.</param>
        /// <returns> ADT query with select from clauses. </returns>
        public DigitalTwinsQueryBuilder From(AdtCollection collection, string alias)
        {
            _fromClause = new FromClause(collection, alias);
            return this;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The name of the collection.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public DigitalTwinsQueryBuilder FromCustom(string collection)
        {
            _fromClause = new FromClause(collection);
            return this;
        }

        /// <summary>
        /// Adds  the conditional arguments for a comparison to the query object. Used to compare ADT properties
        /// using the query language's comparison operators.
        /// </summary>
        /// <param name="field">The field being checked against a certain value.</param>
        /// <param name="comparisonOperator">The comparison operator being invoked.</param>
        /// <param name="value">The value being checked against a Field.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder Compare<T>(string field, QueryComparisonOperator comparisonOperator, T value)
        {
            _whereClauses.Add(new WhereClause(new ComparisonCondition<T>(field, comparisonOperator, value)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value">User specified property to look for.</param>
        /// <param name="searched">Field of possible options to check for the 'value' parameter.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder Contains(string value, string[] searched)
        {
            _whereClauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.In, searched)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value">User specified property to look for.</param>
        /// <param name="searched">Field of possible options to check for the 'value' parameter.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder NotContains(string value, string[] searched)
        {
            _whereClauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.NotIn, searched)));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder WhereCustom(string condition)
        {
            _whereClauses.Add(new WhereClause(condition));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property">The property that the query is looking for as defined.</param>
        /// <returns>TODO.</returns>
        public DigitalTwinsQueryBuilder WhereIsDefined(string property)
        {
            _whereClauses.Add(new WhereClause($"{QueryConstants.IsDefined}({property})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression">The expression being checked for null.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder WhereIsNull(string expression)
        {
            _whereClauses.Add(new WhereClause($"{QueryConstants.IsNull}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#startswith">STARTSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck">String to check the beginning of.</param>
        /// <param name="beginningString">String representing the beginning to check for.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder WhereStartsWith(string stringToCheck, string beginningString)
        {
            _whereClauses.Add(new WhereClause($"{QueryConstants.StartsWith}({stringToCheck}, '{beginningString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#endswith">ENDSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck">String to check the ending of.</param>
        /// <param name="endingString">String representing the ending to check for.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder WhereEndsWith(string stringToCheck, string endingString)
        {
            _whereClauses.Add(new WhereClause($"{QueryConstants.EndsWith}({stringToCheck}, '{endingString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model">Model Id to check for.</param>
        /// <param name="exact">Whether or not an exact match is required.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder WhereIsOfModel(string model, bool exact = false)
        {
            var whereClauseArg = new StringBuilder();
            whereClauseArg.Append($"{QueryConstants.IsOfModel}('{model}'");

            if (exact)
            {
                whereClauseArg.Append(", exact");
            }

            whereClauseArg.Append(')');
            _whereClauses.Add(new WhereClause(whereClauseArg.ToString()));

            return this;
        }

        /// <summary>
        /// Adds a user-specified ADT query language function to check an expression's type against a built type in the ADT query language.
        /// </summary>
        /// <param name="expression">The expression that the query is looking for as a specified type.</param>
        /// <param name="type">The type in the ADT query language being checked for.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder WhereIsOfType(string expression, AdtDataType type)
        {
            string functionName = QueryConstants.DataTypeToFunctionNameMap[type];
            _whereClauses.Add(new WhereClause($"{functionName}({expression})"));
            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions to a query.
        /// </summary>
        /// <param name="nested">WhereLogic methods to perform within a set of parenthesis.</param>
        /// <returns> Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder Parenthetical(Func<DigitalTwinsQueryBuilder, DigitalTwinsQueryBuilder> nested)
        {
            var nestedLogic = new DigitalTwinsQueryBuilder();
            nested.Invoke(nestedLogic);

            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions to a query.
        /// </summary>
        /// <param name="nested">WhereLogic methods to perform within a set of parenthesis.</param>
        /// <returns> Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder And(Func<DigitalTwinsQueryBuilder, DigitalTwinsQueryBuilder> nested)
        {
            var nestedLogic = new DigitalTwinsQueryBuilder();
            nested.Invoke(nestedLogic);

            And();
            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder And()
        {
            // TODO -- make this less messy
            _whereClauses.Add(new WhereClause(QueryConstants.And));
            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions to a query.
        /// </summary>
        /// <param name="nested">WhereLogic methods to perform within a set of parenthesis.</param>
        /// <returns> Logical operator to combine different WHERE functions or conditions.</returns>
        public DigitalTwinsQueryBuilder Or(Func<DigitalTwinsQueryBuilder, DigitalTwinsQueryBuilder> nested)
        {
            var nestedLogic = new DigitalTwinsQueryBuilder();
            nested.Invoke(nestedLogic);

            Or();
            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public DigitalTwinsQueryBuilder Or()
        {
            // TODO -- make this less messy
            _whereClauses.Add(new WhereClause(QueryConstants.Or));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public string GetQueryText()
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

            if (_whereClauses.Any())
            {
                // Add where clauses
                if (!nestedQuery)
                {
                    queryString.Append(QueryConstants.Where).Append(' ');
                }

                foreach (WhereClause clause in _whereClauses)
                {
                    queryString.Append(clause.Condition).Append(' ');
                }
            }

            return queryString.ToString().Trim();
        }
    }
}
