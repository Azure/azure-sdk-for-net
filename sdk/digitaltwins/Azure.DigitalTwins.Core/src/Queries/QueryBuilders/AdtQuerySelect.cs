// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query object that already contains a select clause.
    /// </summary>
    internal class AdtQuerySelect : AdtQuery
    {
        /// <summary>
        /// Adds the FROM clause and its arugment to the query via the Clauses component.
        /// </summary>
        /// <param name="collection"> An enum different collections that users can query from. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public AdtQuerySelectFrom From(AdtCollection collection)
        {
            Console.WriteLine(someString);
            Console.WriteLine(collection);
            return new AdtQuerySelectFrom();
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection"> The name of the collection. </param>
        /// <returns> ADT query with select and from clause. </returns>
        public AdtQuerySelectFrom From(string collection)
        {
            Console.WriteLine(collection);
            Console.WriteLine(someString);
            return new AdtQuerySelectFrom();
        }
    }
}
