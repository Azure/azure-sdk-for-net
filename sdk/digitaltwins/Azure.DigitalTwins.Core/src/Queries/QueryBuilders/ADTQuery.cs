// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    // NOTE -- accessibility internal for now to bypass needing static.
    /// <summary>
    /// Custom ADT query builder class that facilitates building queries against an ADT instance.
    /// </summary>
    internal class AdtQuery
    {
        /// <summary>
        /// Used to prevent needing static.
        /// </summary>
        protected string someString { get; set; }

        /// <summary>
        /// The substance of the query is broken down into clauses, stored in a list
        /// for future parsing purposes.
        /// </summary>
        protected List<BaseClause> Clauses { get; set; } = new List<BaseClause>();

        /// <summary>
        /// Adds a new clause to the Clauses component. Internally called within this class by
        /// public methods that correspond to different clauses themselves (see Select, From, Where).
        /// </summary>
        /// <param name="clause"> The new clause object. </param>
        protected void AddQueryComponent(BaseClause clause)
        {
            Clauses.Add(clause);
        }

        ///// <summary>
        /////  Removes the most recently added component from the Clauses list.
        ///// </summary>
        //protected void RemoveQueryComponent()
        //{
        //}

        /// <summary>
        /// Called to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="args"> The arguments that define what we select (eg. *). </param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuerySelect Select(params string[] args)
        {
            Console.WriteLine(someString);
            Console.WriteLine(args);
            return new AdtQuerySelect();
        }

        /// <summary>
        /// Used when applying the TOP() aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count"> The argument for TOP(), ie the number of instances to return. </param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuerySelect SelectTop(int count)
        {
            Console.WriteLine(someString);
            Console.WriteLine(count);
            return new AdtQuerySelect();
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <param name="args"> The arguments that we define what we select (eg. a property name, *, collection). </param>
        /// <returns> Query that contains a select clause. </returns>
        public AdtQuerySelect SelectCount(params string[] args)
        {
            Console.WriteLine(someString);
            Console.WriteLine(args);
            return new AdtQuerySelect();
        }

        /// <summary>
        /// Parses the Query object into a string representation.
        /// </summary>
        /// <returns> The query in string format. </returns>
        public override string ToString()
        {
            return "";
        }
    }
}
