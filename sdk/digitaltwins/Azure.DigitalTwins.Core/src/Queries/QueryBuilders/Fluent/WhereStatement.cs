// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;

namespace Azure.DigitalTwins.Core.QueryBuilder.Fluent
{
    /// <summary>
    /// Represents the WHERE condition logic. Used to express conditional statements in the DigitalTwins query.
    /// </summary>
    public class WhereStatement
    {
        private readonly List<WhereClause> _whereClauses;

        internal WhereStatement()
        {
            _whereClauses = new List<WhereClause>();
        }

        /// <summary>
        /// Adds the conditional arguments for a comparison to the query object. Used to compare DigitalTwins properties
        /// using the query language's comparison operators.
        /// </summary>
        /// <param name="field">The field being checked against a certain value.</param>
        /// <param name="comparisonOperator">The comparison operator being invoked.</param>
        /// <param name="value">The value being checked against a field.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Compare<T>(string field, QueryComparisonOperator comparisonOperator, T value)
        {
            Argument.AssertNotNullOrWhiteSpace(field, nameof(field));

            _whereClauses.Add(new WhereClause(new ComparisonCondition<T>(field, comparisonOperator, value)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arguments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value">User specified property to look for.</param>
        /// <param name="searched">Field of possible options to check for the <c>value</c> parameter.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Contains(string value, string[] searched)
        {
            Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

            _whereClauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.In, searched)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arguments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value">User specified property to look for.</param>
        /// <param name="searched">Field of possible options to check for the <c>value</c> parameter.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement NotContains(string value, string[] searched)
        {
            Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

            _whereClauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.NotIn, searched)));
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition">The verbatim condition (SQL-like syntax) in string format.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Custom(string condition)
        {
            Argument.AssertNotNullOrWhiteSpace(condition, nameof(condition));

            _whereClauses.Add(new WhereClause(condition));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property">The property that the query is looking for as defined.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement IsDefined(string property)
        {
            Argument.AssertNotNullOrWhiteSpace(property, nameof(property));

            _whereClauses.Add(new WhereClause($"{QueryConstants.IsDefined}({property})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression">The expression being checked for null.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement IsNull(string expression)
        {
            Argument.AssertNotNullOrWhiteSpace(expression, nameof(expression));

            _whereClauses.Add(new WhereClause($"{QueryConstants.IsNull}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#startswith">STARTSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck">String to check the beginning of.</param>
        /// <param name="beginningString">String representing the beginning to check for.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement StartsWith(string stringToCheck, string beginningString)
        {
            Argument.AssertNotNullOrWhiteSpace(stringToCheck, nameof(stringToCheck));
            Argument.AssertNotNullOrWhiteSpace(beginningString, nameof(beginningString));

            _whereClauses.Add(new WhereClause($"{QueryConstants.StartsWith}({stringToCheck}, '{beginningString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#endswith">ENDSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck">String to check the ending of.</param>
        /// <param name="endingString">String representing the ending to check for.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement EndsWith(string stringToCheck, string endingString)
        {
            Argument.AssertNotNullOrWhiteSpace(stringToCheck, nameof(stringToCheck));
            Argument.AssertNotNullOrWhiteSpace(endingString, nameof(endingString));

            _whereClauses.Add(new WhereClause($"{QueryConstants.EndsWith}({stringToCheck}, '{endingString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model">Model Id to check for.</param>
        /// <param name="exact">Whether or not an exact match is required.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement IsOfModel(string model, bool exact = false)
        {
            Argument.AssertNotNullOrWhiteSpace(model, nameof(model));

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
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement IsOfType(string expression, DigitalTwinsDataType type)
        {
            Argument.AssertNotNullOrWhiteSpace(expression, nameof(expression));

            string functionName = QueryConstants.DataTypeToFunctionNameMap[type];
            _whereClauses.Add(new WhereClause($"{functionName}({expression})"));
            return this;
        }

        /// <summary>
        /// Used to add WHERE conditions wrapped in parenthesis to signify precedence to a query.
        /// </summary>
        /// <param name="nested">WhereQuery methods to perform within a set of parenthesis.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Precedence(Func<WhereStatement, WhereStatement> nested)
        {
            var nestedLogic = new WhereStatement();
            nested.Invoke(nestedLogic);

            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions within an AND logical operator to a query.
        /// </summary>
        /// <param name="nested">WhereQuery methods to perform within a set of parenthesis.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement And(Func<WhereStatement, WhereStatement> nested)
        {
            var nestedLogic = new WhereStatement();
            nested.Invoke(nestedLogic);

            And();
            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// Adds the AND logical operator to a query.
        /// </summary>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement And()
        {
            _whereClauses.Add(new WhereClause(QueryConstants.And));
            return this;
        }

        /// <summary>
        /// Used to add nested WHERE conditions within an OR logical operator to a query.
        /// </summary>
        /// <param name="nested">WhereQuery methods to perform within a set of parenthesis.</param>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Or(Func<WhereStatement, WhereStatement> nested)
        {
            var nestedLogic = new WhereStatement();
            nested.Invoke(nestedLogic);

            Or();
            _whereClauses.Add(new WhereClause($"({nestedLogic.GetQueryText()})"));
            return this;
        }

        /// <summary>
        /// Adds the OR logical operator to a query.
        /// </summary>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public WhereStatement Or()
        {
            _whereClauses.Add(new WhereClause(QueryConstants.Or));
            return this;
        }

        /// <summary>
        /// Gets the string representation of a WhereQuery.
        /// </summary>
        /// <returns>The <see cref="WhereStatement"/> object itself.</returns>
        public string GetQueryText()
        {
            var whereClauseString = new StringBuilder();

            if (_whereClauses.Any())
            {
                foreach (WhereClause clause in _whereClauses)
                {
                    whereClauseString.Append(clause.Condition).Append(' ');
                }
            }

            return whereClauseString.ToString().Trim();
        }
    }
}
