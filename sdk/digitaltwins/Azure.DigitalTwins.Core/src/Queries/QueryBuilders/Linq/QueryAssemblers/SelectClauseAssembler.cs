// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Used to select properties with the aliasing mechanism that allows renaming properties when the service responds.
    /// </summary>
    internal sealed class SelectClauseAssembler
    {
        private FromClauseAssembler _fromQuery;
        private QueryAssembler _parent;
        private List<string> _clauses;

        internal SelectClauseAssembler(QueryAssembler parent, FromClauseAssembler fromQuery)
        {
            _fromQuery = fromQuery;
            _parent = parent;
            _clauses = new List<string>();
        }

        /// <summary>
        /// Used to select properties with the desired alias.
        /// </summary>
        /// <param name="field">The proper name for the selectable property in the ADT Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns> Query that contains an aliased select clause. </returns>
        public SelectClauseAssembler SelectAs(string field, string alias)
        {
            _clauses.Add($"{field} {QueryConstants.As} {alias}");
            return this;
        }

        /// <summary>
        /// An overloaded alternative to passing in a Collection that allows for simply passing in the string name of the collection
        /// that is being queried.
        /// </summary>
        /// <param name="collection">The name of the collection.</param>
        /// <returns> ADT query with select and from clauses. </returns>
        public WhereClauseAssembler FromCustom(string collection)
        {
            return _fromQuery.FromCustom(collection);
        }

        public string GetQueryText()
        {
            if (_clauses.Count == 0)
            {
                return string.Empty;
            }

            string aliasedComponents = string.Join(", ", _clauses);
            return aliasedComponents;
        }
    }
}
