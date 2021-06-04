// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.DigitalTwins.Core.Queries.QueryBuilders;
using System.Collections.Generic;

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
        private IList<SelectClause> _clauses;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectQuery"/> class.
        /// </summary>
        internal SelectQuery(AdtQueryBuilder parent, FromQuery select)
        {
            _parent = parent;
            _innerQuery = select;
            _clauses = new List<SelectClause>();
        }

        /// <summary>
        /// Called to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="args"> The arguments that define what we select (eg. *). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery Select(params string[] args)
        {
            Console.WriteLine(args);
            _clauses.Add(new SelectClause(args[0]));
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
            Console.WriteLine(count);
            _clauses.Add(new SelectClause(count.ToString(CultureInfo.InvariantCulture)));
            return _innerQuery;
        }

        /// <summary>
        /// Used when applying the COUNT() aggregate from the ADT query language. Similar to SelectTop().
        /// </summary>
        /// <param name="args"> The arguments that we define what we select (eg. a property name, *, collection). </param>
        /// <returns> Query that contains a select clause. </returns>
        public FromQuery SelectCount(params string[] args)
        {
            Console.WriteLine(args);
            _clauses.Add(new SelectClause(args[0]));
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
            throw new NotImplementedException();
        }
    }
}
