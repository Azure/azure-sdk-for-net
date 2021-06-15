// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT and FROM clause.
    /// </summary>
    public sealed class WhereQuery : QueryBase
    {
        private readonly AdtQueryBuilder _parent;
        private IList<WhereClause> _clauses;

        internal WhereQuery(AdtQueryBuilder parent)
        {
            _parent = parent;
            _clauses = new List<WhereClause>();
        }

        /// <summary>
        /// Adds a WHERE and the conditional arguments for a comparison to the query object. Used to compare ADT properties
        /// using the query language's comparison operators.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The comparison operator being invoked. </param>
        /// <param name="value"> The value being checked against a Field. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereComparison(string field, QueryComparisonOperator comparisonOperator, string value)
        {
            _clauses.Add(new WhereClause(new ComparisonCondition(field, comparisonOperator, value)));
            return this;
        }

        /// <summary>
        /// Adds a WHERE and the conditional arugments for a contains conditional statement to the query object. Used to search
        /// a field for a user specified property.
        /// </summary>
        /// <param name="value"> User specified property to look for. </param>
        /// <param name="containOperator"> ADT contains operator defined by the ADT query language. </param>
        /// <param name="searched"> Field of possible options to check for the 'value' parameter. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereContains(string value, QueryContainOperator containOperator, string[] searched)
        {
            _clauses.Add(new WhereClause(new ContainsCondition(value, containOperator, searched)));
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatim condition (SQL-like syntax) in string format. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereOverride(string condition)
        {
            _clauses.Add(new WhereClause(condition));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsDefined(string property)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsDefined}({property})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsNull(string expression)
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
        public WhereQuery WhereStartsWith(string stringToCheck, string beginningString)
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
        public WhereQuery WhereEndsWith(string stringToCheck, string endingString)
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
        public WhereQuery WhereIsOfModel(string model, bool exact = false)
        {
            if (exact)
            {
                _clauses.Add(new WhereClause($"{QueryConstants.IsOfModel}('{model}', exact)"));
            }
            else
            {
                _clauses.Add(new WhereClause($"{QueryConstants.IsOfModel}('{model}')"));
            }

            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_bool">IS_BOOL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as boolean. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsBool(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsBool}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_number">IS_NUMBER</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as a number. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsNumber(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsNumber}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_string">IS_STRING</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as a string. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsString(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsString}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_primative">IS_PRIMATIVE</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as primative. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsPrimative(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsPrimative}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_object">IS_OBJECT</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression that the query is looking for as an object. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsObject(string expression)
        {
            _clauses.Add(new WhereClause($"{QueryConstants.IsObject}({expression})"));
            return this;
        }

        /// <summary>
        /// Adds the logical operator AND to the query.
        /// </summary>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery And()
        {
            return this;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            return _parent;
        }

        /// <inheritdoc/>
        public override string Stringify()
        {
            if (_clauses.Any())
            {
                // Where keyword only needs to be appened one time, happends outside of loop
                StringBuilder whereComponents = new StringBuilder();
                whereComponents.Append($"{QueryConstants.Where} ");

                // Parse each Where conditional statement
                for (int i = 0; i < _clauses.Count - 1; i++)
                {
                    whereComponents.Append(_clauses[i].Condition);

                    // Add AND logical operator by default for multiple WHERE coditions
                    whereComponents.Append($" {QueryConstants.And} ");
                }

                // Attach final argument (outside of loop to avoid an extra And operator
                whereComponents.Append(_clauses[_clauses.Count - 1].Condition);
                return whereComponents.ToString().Trim();
            }

            return string.Empty;
        }

        /*
        * The rest of the logical operators defined in a similar manner.
        */
    }
}
