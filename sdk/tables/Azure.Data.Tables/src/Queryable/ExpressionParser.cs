// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal class ExpressionParser : ExpressionVisitor
    {
        /// <summary>
        /// Gets or sets the filter expression to use in the table query.
        /// </summary>
        /// <value>A string containing the filter expression to use in the query.</value>
        public string FilterString { get; set; }

        internal void Translate(Expression e)
        {
            Visit(e);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            FilterString = ExpressionWriter.ExpressionToString(node.Body);
            return node;
        }
    }
}
