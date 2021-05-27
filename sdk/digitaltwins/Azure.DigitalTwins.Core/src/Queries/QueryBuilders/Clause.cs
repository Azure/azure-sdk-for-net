// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Clause objects make up an entire query. There are four different kinds of clauses, SELECT, FROM, JOIN and WHERE.
    /// Each kind of clause takes in a different set of arguments and are implemented as children of a general clause class.
    /// </summary>
    internal abstract class Clause
    {
        /// <summary>
        /// The type of the given clause (out of SELECT, FROM, JOIN and WHERE).
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Custom object for a SELECT clause. Only meant to be used when adding SELECT to a query. Hidden from user.
    /// </summary>
    internal class SelectClause : Clause
    {
        /// <summary>
        /// The argument for the SELECT clause (eg. *).
        /// </summary>
        public string ClauseArg { get; set; }

        /// <summary>
        /// Constructor for SELECT clause.
        /// </summary>
        /// <param name="argument"> Argument for what to select (collection, property, etc.). </param>
        public SelectClause(string argument)
        {
            this.Type = "SELECT";
            this.ClauseArg = argument;
        }
    }

    /// <summary>
    /// Custom object for a FROM clause. Only meant to be used when adding FROM to a query. Hidden from user.
    /// </summary>
    internal class FromClause : Clause
    {
        /// <summary>
        /// The collection to query from. Stored in an enum to give user some intellisense since there are only two possible collection types,
        /// ADT instances or relationships.
        /// </summary>
        public ADTCollection Collection { get; set; }

        /// <summary>
        /// Constructor for a FROM clause.
        /// </summary>
        /// <param name="collection"> Enum Collection that can be either a ADT instance or a relationship. </param>
        public FromClause(ADTCollection collection)
        {
            this.Type = "FROM";
            this.Collection = collection;
        }
    }

    /// <summary>
    /// Custom object for a WHERE clause. Only meant to be used when adding WHERE to a query. Hidden from user.
    /// </summary>
    internal class WhereClause : Clause
    {
        /// <summary>
        /// Condition object that encodes the logical condition behind the WHERE clause.
        /// </summary>
        public QueryCondition Condition { get; set; }

        /// <summary>
        /// Constructor for a WHERE clause. 
        /// </summary>
        /// <param name="condition"> Condition argument for the WHERE clause. </param>
        public WhereClause(QueryCondition condition)
        {
            this.Type = "WHERE";
            this.Condition = condition;
        }
    }
}
