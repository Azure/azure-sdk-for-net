// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT and FROM clause.
    /// </summary>
    public class WhereQuery : QueryBase<WhereClause>
    {
        private AdtQueryBuilder _parent;

        internal WhereQuery(AdtQueryBuilder parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Adds a WHERE and its conditional argument(s) clause to the query object. Meant to be used for simple
        /// conditions involving operators or with basic ADT functions. Multiple WHERE clauses are appended using
        /// the AND logical operator.
        /// </summary>
        /// <param name="condition"> A custom object that encodes the logical statement nested within the WHERE clause. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        internal WhereQuery Where(BaseCondition condition)
        {
            Console.WriteLine(condition);
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatim condition (SQL-like syntax) in string format. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery Where(string condition)
        {
            Console.WriteLine(condition);
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_defined">IS_DEFINED</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsDefined(string property)
        {
            Console.WriteLine(property);
            return this;
        }

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_null">IS_NULL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsNull(string expression)
        {
            Console.WriteLine(expression);
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
            Console.Write(stringToCheck);
            Console.WriteLine(beginningString);
            return this;
        }

        /*
         WhereEndsWith defined in a similar manner.
         */

        /// <summary>
        /// Adds the <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-functions#is_of_model">IS_OF_MODEL</see> function to the condition statement of the query.
        /// </summary>
        /// <param name="model"> Model ID to check for. </param>
        /// <param name="exact"> Whether or not an exact match is required. </param>
        /// <returns> ADT query that already contains SELECT and FROM. </returns>
        public WhereQuery WhereIsOfModel(string model, bool exact = false)
        {
            Console.WriteLine(model);
            Console.WriteLine(exact);
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
            throw new NotImplementedException();
        }
        /*
* The rest of the logical operators defined in a similar manner.
*/
    }
}
