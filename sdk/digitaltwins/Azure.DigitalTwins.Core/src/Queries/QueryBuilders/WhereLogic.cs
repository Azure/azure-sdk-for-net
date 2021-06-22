// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT, FROM and a WHERE statement.
    /// </summary>
    public sealed class WhereLogic : QueryBase
    {
        private readonly AdtQueryBuilder _parent;
        private IList<WhereClause> _clauses;

        internal WhereLogic(AdtQueryBuilder parent)
        {
            _parent = parent;
            _clauses = new List<WhereClause>();
        }

        /// <summary>
        /// Adds  the conditional arguments for a comparison to the query object. Used to compare ADT properties
        /// using the query language's comparison operators.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The comparison operator being invoked. </param>
        /// <param name="value"> The value being checked against a Field. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic Compare<T>(string field, QueryComparisonOperator comparisonOperator, T value)
        {
            _clauses.Add(new WhereClause(new ComparisonCondition<T>(field, comparisonOperator, value)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value"> User specified property to look for. </param>
        /// <param name="searched"> Field of possible options to check for the 'value' parameter. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic Contains(string value, string[] searched)
        {
            _clauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.In, searched)));
            return this;
        }

        /// <summary>
        /// Adds the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value"> User specified property to look for. </param>
        /// <param name="searched"> Field of possible options to check for the 'value' parameter. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic NotContains(string value, string[] searched)
        {
            _clauses.Add(new WhereClause(new ContainsCondition(value, QueryContainsOperator.NotIn, searched)));
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatim condition (SQL-like syntax) in string format. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic CustomClause(string condition)
        {
            _clauses.Add(new WhereClause(condition));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic IsDefined(string property)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsDefined}({property})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic IsNull(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsNull}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#startswith">STARTSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the beginning of. </param>
        /// <param name="beginningString"> String representing the beginning to check for. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic StartsWith(string stringToCheck, string beginningString)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.StartsWith}({stringToCheck}, '{beginningString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#endswith">ENDSWITH</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the ending of. </param>
        /// <param name="endingString"> String representing the ending to check for. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic EndsWith(string stringToCheck, string endingString)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.EndsWith}({stringToCheck}, '{endingString}')"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model"> Model ID to check for. </param>
        /// <param name="exact"> Whether or not an exact match is required. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereLogic IsOfModel(string model, bool exact = false)
        {
            var whereClauseArg = new StringBuilder();
            whereClauseArg.Append($"{QueryConstants.IsOfModel}('{model}'");

            if (exact)
            {
                whereClauseArg.Append(", exact");
            }

            whereClauseArg.Append(')');
            _clauses.Add(new WhereClause(whereClauseArg.ToString()));

            return this;
        }

        /// <summary>
        /// Adds a user-specified ADT query language function to check an expression's type against a built type in the ADT query language.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as a specified type. </param>
        /// <param name="type"> The type in the ADT query language being checked for. </param>
        /// <returns></returns>
        public WhereLogic IsOfType(string expression, AdtDataType type)
        {
            string functionName = QueryConstants.IsOfTypeConversions[type];
            _clauses.Add(new WhereClause($"{functionName}({expression})"));
            return this;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            return _parent;
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            if (_clauses.Any())
            {
                // Where keyword only needs to be appened one time, happends outside of loop
                var whereLogicComponents = new StringBuilder();

                var conditions = new List<string>(_clauses.Count);
                foreach (WhereClause _clause in _clauses)
                {
                    conditions.Add(_clause.Condition);
                }

                whereLogicComponents.Append(string.Join($" {QueryConstants.And} ", conditions).Trim());
                return whereLogicComponents.ToString().Trim();
            }

            return string.Empty;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public WhereLogic IsTrue(Func<WhereLogic, WhereLogic> p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public WhereLogic Or()
        {
            return this;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public WhereLogic And()
        {
            return this;
        }
    }
}
