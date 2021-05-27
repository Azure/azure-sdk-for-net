// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom ADT query builder class that facilitates building queries against an ADT instance.
    /// </summary>
    public class ADTQuery
    {
        /// <summary>
        /// The substance of the query is broken down into clauses, stored in a list
        /// for future parsing purposes.
        /// </summary>
        internal List<Clause> Clauses { get; set; } = new List<Clause>();

        /// <summary>
        /// Adds a new clause to the Clauses component. Internally called within this class by
        /// public methods that correspond to different clauses themselves (see Select, From, Where).
        /// </summary>
        /// <param name="clause"> The new clause object (see Clause.cs) </param>
        /// <returns> The updated list of clauses. </returns>
        internal List<Clause> AddQueryComponent(Clause clause)
        {
            this.Clauses.Add(clause);
            return Clauses;
        }

        /// <summary>
        ///  Removes the most recently added component to the Clauses list.
        /// </summary>
        /// <returns> The updated list of clauses. </returns>
        internal List<Clause> RemoveQueryComponent()
        {
            return Clauses;
        }

        /// <summary>
        /// Called to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="args"> The arguments that define what we select (eg. *). </param>
        /// <returns> The ADTQuery object itself. </returns>
        public ADTQuery Select(params string[] args)
        {
            return this;
        }

        /// <summary>
        /// Used when applying the TOP() aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count"> The argument for TOP(), ie the number of instances to return. </param>
        /// <param name="args"> The arguments that define what we select (eg. *). </param>
        /// <returns> The ADTQuery object itself. </returns>
        public ADTQuery SelectTop(int count)
        {
            return this;
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <param name="args"> The arguments that we define what we select (eg. *). </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery SelectCount(params string[] args)
        {
            return this;
        }

        /// <summary>
        /// Adds the FROM clause and its arugment to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum for the two different collections that users can query from (DT instances or relationships). </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery From(ADTCollection collection)
        {
            return this;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection"> The name of the collection. </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery From(string collection)
        {
            return this;
        }

        /// <summary>
        /// Adds a WHERE and its conditional argument(s) clause to the query object. Meant to be used for simple
        /// conditions involving operators or with basic ADT functions.
        /// </summary>
        /// <param name="condition"> A custom object that encodes the logical statement nested within the WHERE clause. </param>
        /// <returns> The updated Query object. </returns>
        internal ADTQuery Where(QueryCondition condition)
        {
            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition"> The verbatum condition (SQL-like syntax) in string format. </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery Where(string condition)
        {
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the IS_DEFINED function (along with IS_DEFINED's argument) to the query. 
        /// Meant to be used any time a user needs to use IS_DEFINED
        /// </summary>
        /// <param name="property"> The property that the query is looking for as defined. </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery WhereIsDefined(string property)
        {
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the IS_NULL function (along with its argument) to the query.
        /// </summary>
        /// <param name="expression"> The expression being checked for null. </param>
        /// <returns> The updated query object. </returns>
        public ADTQuery WhereIsNull(string expression)
        {
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the STARTSWITH function (along with its arguments) to the query.
        /// </summary>
        /// <param name="stringToCheck"> String to check the beginning of. </param>
        /// <param name="beginningString"> String representing the beginning to check for. </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery WhereStartsWith(string stringToCheck, string beginningString)
        {
            return this;
        }

        /// <summary>
        /// Adds both a WHERE clause and the IS_OF_MODEL function (along with its arguments) to the query.
        /// </summary>
        /// <param name="collection"> The collection to seach when there is more than one (JOIN statements). </param>
        /// <param name="model"> Model ID to check for. </param>
        /// <param name="exact"> Whether or not an exact match is required. </param>
        /// <returns> The updated Query object. </returns>
        public ADTQuery WhereIsOfModel(string model, bool exact = false)
        {
            return this;
        }

        /*
         * The rest of the WHERE methods defined and implemented in this same manner.
         */

        /// <summary>
        /// Adds the logical operator AND to the query.
        /// </summary>
        /// <returns> The updated Query object. </returns>
        public ADTQuery And()
        {
            return this;
        }

        /*
         * The rest of the logical operators defined in a similar manner.
         */

        /// <summary>
        /// Parses the Query object into a string representation.
        /// </summary>
        /// <returns> The Query in string format. </returns>
        public override string ToString()
        {
            return "";
        }
    }
}
