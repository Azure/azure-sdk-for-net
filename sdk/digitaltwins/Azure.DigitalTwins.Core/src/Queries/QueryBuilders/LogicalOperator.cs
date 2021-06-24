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
    public class LogicalOperator : QueryBase
    {
        private WhereLogic _whereLogic;

        internal LogicalOperator(WhereLogic whereLogic)
        {
            _whereLogic = whereLogic;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public WhereLogic And()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.And} ");
            return _whereLogic;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public WhereLogic Or()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.Or} ");
            return _whereLogic;
        }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <returns></returns>
        public override AdtQueryBuilder Build()
        {
            return _whereLogic.Build();
        }

        /// <summary>
        /// TODO. Inheritdoc
        /// </summary>
        /// <returns></returns>
        public override string GetQueryText()
        {
            return _whereLogic.GetQueryText();
        }
    }
}
