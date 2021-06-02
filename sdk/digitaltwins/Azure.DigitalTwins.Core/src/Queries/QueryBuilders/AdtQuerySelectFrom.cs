// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that contains a SELECT and FROM clause.
    /// </summary>
    internal class AdtQuerySelectFrom : AdtQuery
    {
        /// <summary>
        /// Adds a WHERE and its conditional argument(s) clause to the query object. Meant to be used for simple
        /// conditions involving operators or with basic ADT functions.
        /// </summary>
        /// <param name="condition"> A custom object that encodes the logical statement nested within the WHERE clause. </param>
        /// <returns> The ADTQuery object itself. </returns>
        internal AdtQuery Where(BaseCondition condition)
        {
            Console.WriteLine(condition);
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatum condition (SQL-like syntax) in string format. </param>
        /// <returns> The ADTQuery object itself. </returns>
        public AdtQuery Where(string condition)
        {
            Console.WriteLine(condition);
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the IS_DEFINED function (along with IS_DEFINED's argument) to the query.
        /// Meant to be used any time a user needs to use IS_DEFINED
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> The ADTQuery object itself. </returns>
        public AdtQuery WhereIsDefined(string property)
        {
            Console.WriteLine(property);
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the IS_NULL function (along with its argument) to the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> The ADTQuery object itself. </returns>
        public AdtQuery WhereIsNull(string expression)
        {
            Console.WriteLine(expression);
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the STARTSWITH function (along with its arguments) to the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the beginning of. </param>
        /// <param name="beginningString"> String representing the beginning to check for. </param>
        /// <returns> The ADTQuery object itself. </returns>
        public AdtQuery WhereStartsWith(string stringToCheck, string beginningString)
        {
            Console.Write(stringToCheck);
            Console.WriteLine(beginningString);
            return this;
        }

        /*
         WhereEndsWith defined in a similar manner.
         */

        /// <summary>
        /// Adds both a WHERE clause and the IS_OF_MODEL function (along with its arguments) to the query.
        /// </summary>
        /// <param name="model"> Model ID to check for. </param>
        /// <param name="exact"> Whether or not an exact match is required. </param>
        /// <returns> The ADTQuery object itself. </returns>
        public AdtQuery WhereIsOfModel(string model, bool exact = false)
        {
            Console.WriteLine(model);
            Console.WriteLine(exact);
            return this;
        }
    }
}
