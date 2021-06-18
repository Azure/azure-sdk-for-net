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
    public class WhereStatement : QueryBase
    {
        private readonly WhereLogic _upsteamWhereLogic;
        private readonly AdtQueryBuilder _parent;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="upsteamWhere"></param>
        internal WhereStatement(AdtQueryBuilder parent, WhereLogic upsteamWhere)
        {
            _parent = parent;
            _upsteamWhereLogic = upsteamWhere;
        }

        /// <summary>
        /// TODO.
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
