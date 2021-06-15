// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom object for a WHERE clause. Only meant to be used when adding WHERE to a query. Hidden from user.
    /// </summary>
    internal class WhereClause
    {
        /// <summary>
        /// Condition object represented in string format that encodes the logical condition behind the WHERE clause.
        /// </summary>
        internal string Condition { get; set; }

        /// <summary>
        /// Constructor for a WHERE clause using the internal condition object.
        /// </summary>
        /// <param name="condition"> Condition argument for the WHERE clause. </param>
        internal WhereClause(ConditionBase condition)
        {
            Condition = condition.Stringify();
        }

        /// <summary>
        /// Constructor for a WHERE clause allowing for user formed strings and prebuilt ADT WHERE function arguments.
        /// </summary>
        /// <param name="condition"></param>
        internal WhereClause(string condition)
        {
            Condition = condition;
        }
    }
}
