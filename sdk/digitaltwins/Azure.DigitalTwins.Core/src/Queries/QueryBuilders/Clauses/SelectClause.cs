// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Custom object for a SELECT clause. Only meant to be used when adding SELECT to a query. Hidden from user.
    /// </summary>
    internal class SelectClause : BaseClause
    {
        /// <summary>
        /// The argument for the SELECT clause (eg. *).
        /// </summary>
        public string ClauseArg { get; set; }

        /// <summary>
        /// Constructor for SELECT clause.
        /// </summary>
        /// <param name="argument"> Argument for what to select (collection, property, etc.). </param>
        internal SelectClause(string argument)
        {
            // TODO -- select multiple arguments (string[])
            Type = ClauseType.SELECT;
            ClauseArg = argument;
        }

        public override string Stringify()
        {
            StringBuilder selectComponents = new StringBuilder();
            selectComponents.Append("SELECT");

            // TODO -- support multiple select arguments
            // TODO -- spaces?
            selectComponents.Append(ClauseArg);

            return selectComponents.ToString();
        }
    }
}
