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
    public class IntermediateWhere
    {
        private readonly WhereQuery _upstreamWhereQuery;
        private readonly AdtQueryBuilder _parent;

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="upsteamWhere"></param>
        internal IntermediateWhere(AdtQueryBuilder parent, WhereQuery upsteamWhere)
        {
            _parent = parent;
            _upstreamWhereQuery = upsteamWhere;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public WhereQuery Where()
        {
            return _upstreamWhereQuery;
        }
    }
}
