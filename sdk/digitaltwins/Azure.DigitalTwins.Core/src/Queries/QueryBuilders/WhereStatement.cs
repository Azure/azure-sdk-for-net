// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT and FROM clause.
    /// </summary>
    public class WhereStatement : QueryBase
    {
        private readonly WhereLogic _upsteamWhereLogic;
        private readonly AdtQueryBuilder _parent;

        internal WhereStatement(AdtQueryBuilder parent, WhereLogic upsteamWhere)
        {
            _parent = parent;
            _upsteamWhereLogic = upsteamWhere;
        }

        /// <summary>
        /// Adds a WHERE statement to a query.
        /// </summary>
        /// <returns></returns>
        public WhereLogic Where()
        {
            return _upsteamWhereLogic;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            throw new InvalidOperationException("Invalid query: Missing WHERE logic.");
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            return $"{QueryConstants.Where}";
        }
    }
}
