// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using System.Collections.Generic;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    // NOTE -- accessibility internal for now to bypass needing static.
    /// <summary>
    /// Custom ADT query builder class that facilitates building queries against an ADT instance.
    /// </summary>
    public sealed class SelectQuery : QueryBase
    {
        private readonly FromQuery _innerQuery;
        private readonly AdtQueryBuilder _parent;
        private SelectClause _clause;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectQuery"/> class.
        /// </summary>
        internal SelectQuery(AdtQueryBuilder parent, FromQuery select)
        {
            _parent = parent;
            _innerQuery = select;
        }

        /// <summary>
        /// Called to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="args"> The arguments that define what we select (eg. *). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery Select(params string[] args)
        {
            Console.WriteLine(args);
            _clause = new SelectClause(args);
            return _innerQuery;
        }

        /// <summary>
        /// Used when applying the TOP() aggregate from the ADT query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count"> The argument for TOP(), ie the number of instances to return. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTop(int count)
        {
            // TODO -- can we also have arguments? like property names?
            // turn into correct format -- eg. SELECT TOP(3)
            string topArg = new StringBuilder().Append("TOP").Append('(').Append(count).Append(')').ToString();

            _clause = new SelectClause(new string[] { topArg });
            return _innerQuery;
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <param name="args"> The arguments that we define what we select (eg. a property name, *, collection). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount(params string[] args)
        {
            // TODO -- can we take in arguments? like a property name?
            Console.WriteLine(args);
            string countArg = new StringBuilder().Append("COUNT").Append('(').Append(')').ToString();

            _clause = new SelectClause(new string[] { countArg });
            return _innerQuery;
        }

        /// <summary>
        /// Parses the Query object into a string representation.
        /// </summary>
        /// <returns> The query in string format. </returns>
        public override string ToString()
        {
            return "";
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            throw new InvalidOperationException("You can't just have a select statement");
        }

        /// <inheritdoc/>
        public override string Stringify()
        {
            StringBuilder selectComponents = new StringBuilder();
            selectComponents.Append("SELECT ");

            // one argument
            if (_clause.ClauseArgs.Length == 1)
            {
                selectComponents.Append(_clause.ClauseArgs[0]);
            }
            // multiple arguments
            else
            {
                // instantiate i outside loop to access later
                int i;
                for (i = 0; i < _clause.ClauseArgs.Length - 1; i++)
                {
                    selectComponents.Append(_clause.ClauseArgs[i]);
                    selectComponents.Append(", ");
                }

                // don't put a comma after the last argument
                selectComponents.Append(_clause.ClauseArgs[i]);
            }

            return selectComponents.ToString().Trim();
        }
    }
}
