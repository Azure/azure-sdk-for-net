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
        /// <param name="args"> The arguments that can be optionally passed with top (eg property name). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectTop(int count, params string[] args)
        {
            // turn into correct format -- eg. SELECT TOP(3)
            StringBuilder topArg = new StringBuilder().Append("TOP").Append('(').Append(count).Append(')');

            // account for optional arguments
            if (args.Length != 0)
            {
                // TODO -- topargs.append.string.format.... (way around loop)
                // append first argument manually since no comma needed
                topArg.Append(' ').Append(args[0]);

                // append other arguments separated by commas
                for (int i = 1; i < args.Length; i++)
                {
                    topArg.Append(", ").Append(args[i]);
                }
            }

            _clause = new SelectClause(new string[] { topArg.ToString() });
            return _innerQuery;
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount()
        {
            string countArg = new StringBuilder().Append("COUNT").Append('(').Append(')').ToString();

            _clause = new SelectClause(new string[] { countArg });
            return _innerQuery;
        }

        /// <summary>
        /// Called when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="literalQuery"> Query in string format. </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectOverride(string literalQuery)
        {
            // TODO -- just use select?
            // approach 1 - method overload
            // approach 2 - seperate method
            _clause = new SelectClause(new string[] { literalQuery });

            return _innerQuery;
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
