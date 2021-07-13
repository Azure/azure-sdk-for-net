// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// TODO.
    /// </summary>
    public class AdtQuery
    {
        private List<SelectClause> _selectClauses;
        private List<FromClause> _fromClauses;

        /// <summary>
        /// TODO.
        /// </summary>
        public AdtQuery()
        {
            _selectClauses = new List<SelectClause>();
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public AdtQuery Select(params string[] args)
        {
            // append something into clauses
            Console.WriteLine(args);
            return this;
        }

        // rest of select methods in this manner

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public AdtQuery From(AdtCollection collection)
        {
            return this;
        }
    }
}
