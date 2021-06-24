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
        private StringBuilder _conditions;

        internal LogicalOperator(WhereLogic whereLogic, StringBuilder conditions)
        {
            _whereLogic = whereLogic;
            _conditions = conditions;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public WhereLogic And()
        {
            _conditions.Append(QueryConstants.And);
            return _whereLogic;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public WhereLogic Or()
        {
            _conditions.Append(QueryConstants.Or);
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
