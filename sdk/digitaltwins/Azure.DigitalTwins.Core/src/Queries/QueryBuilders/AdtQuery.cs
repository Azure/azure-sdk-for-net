// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class AdtQuery
    {
        private List<SelectClause> _selectClauses;
        private List<FromClause> _fromClauses;
        private List<WhereClause> _whereClauses;
        private string queryString;

        /// <summary>
        /// TODO.
        /// </summary>
        public AdtQuery()
        {
            _selectClauses = new List<SelectClause>();
            _fromClauses = new List<FromClause>();
            _whereClauses = new List<WhereClause>();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AdtQuery Select(params string[] args)
        {
            // append something into clauses
            Console.WriteLine(args);
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well as well as specific properties to select.
        /// </summary>
        /// <param name="count">The argument for TOP(), ie the number of instances to return.</param>
        /// <param name="args">The arguments that can be optionally passed with top (e.g., property name).</param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuery SelectTop(int count, params string[] args)
        {
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            // append optional arguments separated by commas
            topArg.Append(string.Join(", ", args));

            //_clause = new SelectClause(new string[] { topArg.ToString() });
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuery SelectTopAll(int count)
        {
            // turn into correct format -- eg. SELECT TOP(3)
            var topArg = new StringBuilder().Append($"{QueryConstants.Top}({count})").Append(' ');

            //_clause = new SelectClause(new string[] { topArg.ToString() });
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-clause-select#select-count">COUNT()</see> aggregate from the ADT query language.
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuery SelectCount()
        {
            string countArg = $"{QueryConstants.Count}() ";

            //_clause = new SelectClause(new string[] { countArg });
            return this;
        }

        /// <summary>
        /// Used when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="customQuery">Query in string format.</param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuery SelectCustom(string customQuery)
        {
            Console.WriteLine(customQuery);
            //_clause = new SelectClause(new string[] { customQuery });
            return this;
        }

        /// <summary>
        /// Used to select properties with the desired alias.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the ADT Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns> Query that contains an aliased select clause. </returns>
        public AdtQuery SelectAs(string field, string alias)
        {
            _selectClauses.Add(new SelectClause(new string[] { $"{field} {QueryConstants.As} {alias}" }));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public AdtQuery From(AdtCollection collection)
        {
            Console.WriteLine(collection);
            return this;
        }

        /// <summary>
        /// Adds the FROM clause, its argument, and an alias for its argument into the query.
        /// </summary>
        /// <param name="collection">The collection being queried from.</param>
        /// <param name="alias">The alias being assigned to the collection being queried from.</param>
        /// <returns> ADT query with select from clauses. </returns>
        public AdtQuery From(AdtCollection collection, string alias)
        {
            Console.WriteLine(collection);
            Console.WriteLine(alias);
            //_clause = new FromClause(collection, alias);
            return this;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The name of the collection.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public AdtQuery FromCustom(string collection)
        {
            Console.WriteLine(collection);
            //_clause = new FromClause(collection);
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
        public AdtQuery Compare<T>(string field, QueryComparisonOperator comparisonOperator, T value)
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
        public AdtQuery Contains(string value, string[] searched)
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
        public AdtQuery NotContains(string value, string[] searched)
        {
            _whereClauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.NotIn, searched)));
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public AdtQuery WhereCustom(string condition)
        {
            Console.WriteLine(condition);
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property">The property that the query is looking for as defined.</param>
        /// <returns>TODO.</returns>
        public AdtQuery WhereIsDefined(string property)
        {
            Console.WriteLine(property);
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression">The expression being checked for null.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public AdtQuery WhereIsNull(string expression)
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
        public AdtQuery WhereStartsWith(string stringToCheck, string beginningString)
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
        public AdtQuery WhereEndsWith(string stringToCheck, string endingString)
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
        public AdtQuery WhereIsOfModel(string model, bool exact = false)
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
        public AdtQuery WhereIsOfType(string expression, AdtDataType type)
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
        public AdtQuery Parenthetical(Func<AdtQuery, AdtQuery> nested)
        {
            // RENAME?
            var nestedLogic = new AdtQuery();
            nested.Invoke(nestedLogic);

            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions to a query.
        /// </summary>
        /// <param name="nested">WhereLogic methods to perform within a set of parenthesis.</param>
        /// <returns> Logical operator to combine different WHERE functions or conditions.</returns>
        public AdtQuery And(Func<AdtQuery, AdtQuery> nested)
        {
            // RENAME?
            var nestedLogic = new AdtQuery();
            nested.Invoke(nestedLogic);

            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public AdtQuery And()
        {
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public string GetQueryText()
        {
            queryString = string.Empty;
            return queryString;
        }
    }
}
