// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Query that already contains a SELECT, FROM and a WHERE statement.
    /// </summary>
    internal sealed class WhereClauseAssemblerLogic
    {
        private readonly QueryAssembler _parent;
        private readonly QueryAssemblerLogicalOperator _logicalOperator;
        private readonly StringBuilder _conditions;

        internal WhereClauseAssemblerLogic(QueryAssembler parent)
        {
            _parent = parent;
            _logicalOperator = new QueryAssemblerLogicalOperator(this);
            _conditions = new StringBuilder();
        }

        internal void AppendLogicalOperator(string logicalOperator)
        {
            _conditions.Append(logicalOperator);
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="condition">The verbatim condition (SQL-like syntax) in string format.</param>
        /// <returns>Logical operator to combine different WHERE functions or conditions.</returns>
        public QueryAssemblerLogicalOperator CustomClause(string condition)
        {
            _conditions.Append(condition);
            return _logicalOperator;
        }

        internal QueryAssembler BuildLogic()
        {
            return _parent;
        }

        internal string GetLogicText()
        {
            bool notEmpty = _conditions.Length > 0;
            return notEmpty ? _conditions.ToString() : string.Empty;
        }
    }
}
