// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom object for a SELECT clause. Only meant to be used when adding SELECT to a query.
    /// </summary>
    internal class SelectClause
    {
        /// <summary>
        /// Constructor for SELECT clause.
        /// </summary>
        /// <param name="arguments"> Arguments for what to select (collection, property, etc.). </param>
        internal SelectClause(string[] arguments)
        {
            ClauseArgs = arguments;
        }

        /// <summary>
        /// The argument for the SELECT clause (eg. SELECT Temperature, Humidity, Occupants FROM ...).
        /// </summary>
        public string[] ClauseArgs { get; private set; }
    }
}
