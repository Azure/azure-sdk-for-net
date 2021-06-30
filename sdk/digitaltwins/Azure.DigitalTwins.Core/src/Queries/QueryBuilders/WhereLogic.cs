// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT, FROM and a WHERE statement.
    /// </summary>
    public sealed class WhereLogic
    {
        private readonly AdtQueryBuilder _parent;
        private readonly LogicalOperator _logicalOperator;
        private readonly StringBuilder _conditions;

        internal WhereLogic(AdtQueryBuilder parent)
        {
            _parent = parent;
            _logicalOperator = new LogicalOperator(this);
            _conditions = new StringBuilder();
        }

        internal void AppendLogicalOperator(string logicalOperator)
        {
            _conditions.Append(logicalOperator);
        }

        /// <summary>
        /// Adds  the conditional arguments for a comparison to the query object. Used to compare ADT properties
        /// using the query language's comparison operators.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The comparison operator being invoked. </param>
        /// <param name="value"> The value being checked against a Field. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator Compare<T>(string field, QueryComparisonOperator comparisonOperator, T value)
        {
            _conditions.Append(new WhereClause(new ComparisonCondition<T>(field, comparisonOperator, value)).Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value"> User specified property to look for. </param>
        /// <param name="searched"> Field of possible options to check for the 'value' parameter. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator Contains(string value, string[] searched)
        {
            _conditions.Append(new WhereClause(new ContainsCondition(value, QueryContainsOperator.In, searched)).Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value"> User specified property to look for. </param>
        /// <param name="searched"> Field of possible options to check for the 'value' parameter. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator NotContains(string value, string[] searched)
        {
            _conditions.Append(new WhereClause(new ContainsCondition(value, QueryContainsOperator.NotIn, searched)).Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatim condition (SQL-like syntax) in string format. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator CustomClause(string condition)
        {
            _conditions.Append(condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator IsDefined(string property)
        {
            _conditions.Append(new WhereClause($"{QueryConstants.IsDefined}({property})").Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator IsNull(string expression)
        {
            _conditions.Append(new WhereClause($"{QueryConstants.IsNull}({expression})").Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#startswith">STARTSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the beginning of. </param>
        /// <param name="beginningString"> String representing the beginning to check for. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator StartsWith(string stringToCheck, string beginningString)
        {
            _conditions.Append(new WhereClause($"{QueryConstants.StartsWith}({stringToCheck}, '{beginningString}')").Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#endswith">ENDSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the ending of. </param>
        /// <param name="endingString"> String representing the ending to check for. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator EndsWith(string stringToCheck, string endingString)
        {
            _conditions.Append(new WhereClause($"{QueryConstants.EndsWith}({stringToCheck}, '{endingString}')").Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model"> Model Id to check for. </param>
        /// <param name="exact"> Whether or not an exact match is required. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator IsOfModel(string model, bool exact = false)
        {
            var whereClauseArg = new StringBuilder();
            whereClauseArg.Append($"{QueryConstants.IsOfModel}('{model}'");

            if (exact)
            {
                whereClauseArg.Append(", exact");
            }

            whereClauseArg.Append(')');
            _conditions.Append(whereClauseArg.ToString());

            return _logicalOperator;
        }

        /// <summary>
        /// Adds a user-specified ADT query language function to check an expression's type against a built type in the ADT query language.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as a specified type. </param>
        /// <param name="type"> The type in the ADT query language being checked for. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator IsOfType(string expression, AdtDataType type)
        {
            string functionName = QueryConstants.DataTypeToFunctionNameMap[type];
            _conditions.Append(new WhereClause($"{functionName}({expression})").Condition);
            return _logicalOperator;
        }

        /// <summary>
        /// Used to add nested WHERE conditions to a query.
        /// </summary>
        /// <param name="nested"> WhereLogic methods to perform within a set of parenthesis. </param>
        /// <returns> Logical operator to combine different WHERE functions or conditions. </returns>
        public LogicalOperator Parenthetical(Func<WhereLogic, LogicalOperator> nested)
        {
            var nestedLogic = new WhereLogic(null);
            nested.Invoke(nestedLogic);

            _conditions.Append(new WhereClause("(" + nestedLogic.GetLogicText() + ")").Condition);

            return _logicalOperator;
        }

        internal AdtQueryBuilder BuildLogic()
        {
            return _parent;
        }

        internal string GetLogicText()
        {
            bool notEmpty = _conditions.Length > 0;
            return notEmpty ? _conditions.ToString() : string.Empty;
        }
    }
}
