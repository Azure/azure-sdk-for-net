// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom object for a WHERE clause. Only meant to be used when adding WHERE to a query. Hidden from user.
    /// </summary>
    internal class WhereClause : BaseClause
    {
        /// <summary>
        /// Condition object that encodes the logical condition behind the WHERE clause.
        /// </summary>
        public BaseCondition Condition { get; set; }

        /// <summary>
        /// Constructor for a WHERE clause.
        /// </summary>
        /// <param name="condition"> Condition argument for the WHERE clause. </param>
        public WhereClause(BaseCondition condition)
        {
            Type = ClauseType.WHERE;
            Condition = condition;
        }
    }
}
