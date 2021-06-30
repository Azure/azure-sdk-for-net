// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Logical operators (AND/OR) and the ADT query language.
    /// </summary>
    public class LogicalOperator : QueryBase
    {
        private WhereLogic _whereLogic;

        internal LogicalOperator(WhereLogic whereLogic)
        {
            _whereLogic = whereLogic;
        }

        /// <summary>
        /// Adds the AND logical operator to a query.
        /// </summary>
        /// <returns> A query that already contains SELECT and FROM. </returns>
        public WhereLogic And()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.And} ");
            return _whereLogic;
        }

        /// <summary>
        /// Adds the OR logical operator to a query.
        /// </summary>
        /// <returns> A query that already contains SELECT and FROM. </returns>
        public WhereLogic Or()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.Or} ");
            return _whereLogic;
        }

        /// <inheritdoc/>
        public override AdtQueryBuilder Build()
        {
            return _whereLogic.BuildLogic();
        }

        /// <inheritdoc/>
        public override string GetQueryText()
        {
            return _whereLogic.GetLogicText();
        }
    }
}
