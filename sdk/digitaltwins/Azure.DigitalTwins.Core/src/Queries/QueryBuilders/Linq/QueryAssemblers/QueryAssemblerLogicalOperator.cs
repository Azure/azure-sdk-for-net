// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Logical operators (AND/OR) and the ADT query language.
    /// </summary>
    internal class QueryAssemblerLogicalOperator
    {
        private WhereClauseAssemblerLogic _whereLogic;

        internal QueryAssemblerLogicalOperator(WhereClauseAssemblerLogic whereLogic)
        {
            _whereLogic = whereLogic;
        }

        /// <summary>
        /// Adds the AND logical operator to a query.
        /// </summary>
        /// <returns> A query that already contains SELECT and FROM. </returns>
        public WhereClauseAssemblerLogic And()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.And} ");
            return _whereLogic;
        }

        /// <summary>
        /// Adds the OR logical operator to a query.
        /// </summary>
        /// <returns> A query that already contains SELECT and FROM. </returns>
        public WhereClauseAssemblerLogic Or()
        {
            _whereLogic.AppendLogicalOperator($" {QueryConstants.Or} ");
            return _whereLogic;
        }

        public string GetQueryText()
        {
            return _whereLogic.GetLogicText();
        }
    }
}
